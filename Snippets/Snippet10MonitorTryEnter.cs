// ==========================================
// Snippet 10 - Using Monitor.TryEnter()
// ==========================================
//
// This example shows how Monitor.TryEnter()
// can attempt to acquire a lock without
// waiting forever.
//
// Instead of blocking indefinitely, we can
// give the lock attempt a timeout.
// ==========================================

using System;
using System.Threading;

public static class Snippet10MonitorTryEnter
{
    // ------------------------------------------
    // Lock Object
    // ------------------------------------------
    //
    // This object represents the resource
    // we want to protect.

    static readonly object lockObject = new object();


    public static void Run()
    {
        Console.WriteLine("==========================================");
        Console.WriteLine("          USING MONITOR.TRYENTER()");
        Console.WriteLine("==========================================");
        Console.WriteLine();


        // ------------------------------------------
        // Track Whether the Lock Was Acquired
        // ------------------------------------------
        //
        // lockTaken starts as false.
        //
        // Monitor.TryEnter() will change it to true
        // if the lock is successfully acquired.

        bool lockTaken = false;


        try
        {
            // --------------------------------------
            // Try to Acquire the Lock
            // --------------------------------------
            //
            // TryEnter() attempts to acquire
            // lockObject.
            //
            // We give it a timeout of 2 seconds.
            //
            // If the lock becomes available within
            // that time, lockTaken becomes true.
            //
            // If not, lockTaken stays false.

            Monitor.TryEnter(
                lockObject,
                TimeSpan.FromSeconds(2),
                ref lockTaken
            );


            // --------------------------------------
            // Check the Result
            // --------------------------------------

            if (lockTaken)
            {
                Console.WriteLine("Lock acquired.");
                Console.WriteLine();
                Console.WriteLine(
                    "The protected resource can now be accessed."
                );
            }
            else
            {
                Console.WriteLine("Could not acquire lock.");
            }
        }
        finally
        {
            // --------------------------------------
            // Release the Lock Safely
            // --------------------------------------
            //
            // We should only call Monitor.Exit()
            // if we actually acquired the lock.

            if (lockTaken)
            {
                Monitor.Exit(lockObject);

                Console.WriteLine();
                Console.WriteLine("Lock released.");
            }
        }
    }
}