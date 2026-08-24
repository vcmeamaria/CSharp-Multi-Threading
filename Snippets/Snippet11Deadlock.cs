// ==========================================
// Snippet 11 - Deadlock
// ==========================================
//
// A deadlock happens when two or more threads
// are waiting for each other and none of them
// can continue.
//
// The example uses two locks:
//
// lockA
// lockB
//
// Thread 1:
//     Locks A
//     Then tries to lock B
//
// Thread 2:
//     Locks B
//     Then tries to lock A
//
// This can cause both threads to wait forever.
// ==========================================

using System;
using System.Threading;

public static class Snippet11Deadlock
{
    // ------------------------------------------
    // Two Shared Lock Objects
    // ------------------------------------------

    static readonly object lockA = new object();
    static readonly object lockB = new object();


    public static void Run()
    {
        Console.WriteLine("==========================================");
        Console.WriteLine("                 DEADLOCK");
        Console.WriteLine("==========================================");
        Console.WriteLine();

        Console.WriteLine("Thread 1 will lock A, then try to lock B.");
        Console.WriteLine("Thread 2 will lock B, then try to lock A.");
        Console.WriteLine();


        // ------------------------------------------
        // Create Two Threads
        // ------------------------------------------

        Thread t1 = new Thread(Method1);
        Thread t2 = new Thread(Method2);


        // Start both threads.

        t1.Start();
        t2.Start();


        // Wait for both demonstrations to finish.
        //
        // Because we use TryEnter() below,
        // neither thread will wait forever.

        t1.Join();
        t2.Join();


        Console.WriteLine();
        Console.WriteLine("Deadlock demonstration finished.");
    }


    // ==========================================
    // Thread 1
    // ==========================================

    static void Method1()
    {
        // Thread 1 locks A first.

        lock (lockA)
        {
            Console.WriteLine("Thread 1 locked A");


            // Pause for one second.
            //
            // This gives Thread 2 time to
            // acquire lock B.

            Thread.Sleep(1000);


            Console.WriteLine("Thread 1 is now trying to lock B...");


            // --------------------------------------
            // Try to Acquire B
            // --------------------------------------
            //
            // In the PDF's unsafe example,
            // this is simply:
            //
            // lock (lockB)
            //
            // If Thread 2 already holds B,
            // Thread 1 could wait forever.
            //
            // We use TryEnter() with a timeout
            // so our console application does
            // not become permanently stuck.

            bool lockBTaken = false;

            try
            {
                Monitor.TryEnter(
                    lockB,
                    TimeSpan.FromSeconds(2),
                    ref lockBTaken
                );

                if (lockBTaken)
                {
                    Console.WriteLine("Thread 1 locked B");
                }
                else
                {
                    Console.WriteLine(
                        "Thread 1 could not get B - deadlock risk detected."
                    );
                }
            }
            finally
            {
                if (lockBTaken)
                {
                    Monitor.Exit(lockB);
                }
            }
        }
    }


    // ==========================================
    // Thread 2
    // ==========================================

    static void Method2()
    {
        // Thread 2 does the opposite.
        //
        // It locks B first.

        lock (lockB)
        {
            Console.WriteLine("Thread 2 locked B");


            // Give Thread 1 time to keep
            // holding lock A.

            Thread.Sleep(1000);


            Console.WriteLine("Thread 2 is now trying to lock A...");


            // --------------------------------------
            // Try to Acquire A
            // --------------------------------------
            //
            // In the unsafe PDF example,
            // Thread 2 would simply use:
            //
            // lock (lockA)
            //
            // But Thread 1 may already hold A.

            bool lockATaken = false;

            try
            {
                Monitor.TryEnter(
                    lockA,
                    TimeSpan.FromSeconds(2),
                    ref lockATaken
                );

                if (lockATaken)
                {
                    Console.WriteLine("Thread 2 locked A");
                }
                else
                {
                    Console.WriteLine(
                        "Thread 2 could not get A - deadlock risk detected."
                    );
                }
            }
            finally
            {
                if (lockATaken)
                {
                    Monitor.Exit(lockA);
                }
            }
        }
    }
}