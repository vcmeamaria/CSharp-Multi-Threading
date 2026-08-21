// ==========================================
// Snippet 08 - Fix Race Condition with lock
// ==========================================
//
// In the previous example, two threads
// changed the same counter at the same time.
//
// This caused a race condition and some
// increments were lost.
//
// In this example, we fix the problem
// using the lock keyword.
// ==========================================

using System;
using System.Threading;

public static class Snippet08LockRaceCondition
{
    // ------------------------------------------
    // Shared Data
    // ------------------------------------------
    //
    // Just like the previous example,
    // both threads will modify this counter.

    static int counter = 0;


    // ------------------------------------------
    // Lock Object
    // ------------------------------------------
    //
    // This object is used to control access
    // to the shared counter.
    //
    // Only one thread can hold this lock
    // at a time.
    //
    // readonly means this variable will keep
    // referring to the same object.

    static readonly object lockObject = new object();


    public static void Run()
    {
        Console.WriteLine("==========================================");
        Console.WriteLine("       FIX RACE CONDITION WITH LOCK");
        Console.WriteLine("==========================================");
        Console.WriteLine();


        // Reset the counter every time we run
        // this example from the console menu.

        counter = 0;


        // ------------------------------------------
        // Create Two Worker Threads
        // ------------------------------------------
        //
        // Both threads still run the same method
        // and still share the same counter.

        Thread t1 = new Thread(IncrementCounter);
        Thread t2 = new Thread(IncrementCounter);


        // Start both threads.

        t1.Start();
        t2.Start();


        // Wait until both threads finish.

        t1.Join();
        t2.Join();


        // ------------------------------------------
        // Display the Result
        // ------------------------------------------

        Console.WriteLine("Expected Counter: 200000");
        Console.WriteLine($"Actual Counter:   {counter}");

        Console.WriteLine();

        if (counter == 200000)
        {
            Console.WriteLine(
                "Success: the lock protected the shared counter."
            );
        }
        else
        {
            Console.WriteLine(
                "Unexpected result: the counter was not 200000."
            );
        }
    }


    // ==========================================
    // Worker Thread Method
    // ==========================================

    static void IncrementCounter()
    {
        for (int i = 0; i < 100000; i++)
        {
            // --------------------------------------
            // LOCK THE SHARED RESOURCE
            // --------------------------------------
            //
            // Before changing counter, the thread
            // must acquire lockObject.
            //
            // If another thread already has the
            // lock, this thread waits.
            //
            // Once the first thread leaves the
            // lock block, the other thread can enter.

            lock (lockObject)
            {
                counter++;
            }
        }
    }
}