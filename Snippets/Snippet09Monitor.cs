// ==========================================
// Snippet 09 - Using Monitor
// ==========================================
//
// This example shows how Monitor can be used
// to control access to shared data.
//
// In the previous example, we used:
//
// lock (lockObject)
// {
//     counter++;
// }
//
// Monitor gives us more manual control over
// when the lock is entered and released.
// ==========================================

using System;
using System.Threading;

public static class Snippet09Monitor
{
    // ------------------------------------------
    // Shared Data
    // ------------------------------------------

    static int counter = 0;


    // ------------------------------------------
    // Lock Object
    // ------------------------------------------
    //
    // Both threads will use this object
    // when accessing the shared counter.

    static readonly object lockObject = new object();


    public static void Run()
    {
        Console.WriteLine("==========================================");
        Console.WriteLine("              USING MONITOR");
        Console.WriteLine("==========================================");
        Console.WriteLine();


        // Reset the counter each time the
        // example is run.

        counter = 0;


        // ------------------------------------------
        // Create Two Threads
        // ------------------------------------------

        Thread t1 = new Thread(Increment);
        Thread t2 = new Thread(Increment);


        // Start both worker threads.

        t1.Start();
        t2.Start();


        // Wait for both threads to finish.

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
                "Success: Monitor protected the shared counter."
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

    static void Increment()
    {
        for (int i = 0; i < 100000; i++)
        {
            // --------------------------------------
            // Enter the Lock
            // --------------------------------------
            //
            // Monitor.Enter() attempts to acquire
            // the lock.
            //
            // If another thread already has it,
            // this thread waits.

            Monitor.Enter(lockObject);

            try
            {
                // Only one thread at a time can
                // reach this protected section.

                counter++;
            }
            finally
            {
                // ----------------------------------
                // Release the Lock
                // ----------------------------------
                //
                // Monitor.Exit() releases the lock
                // so another thread can use it.
                //
                // We put this inside finally so
                // the lock is released even if
                // something goes wrong inside try.

                Monitor.Exit(lockObject);
            }
        }
    }
}