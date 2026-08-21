// ==========================================
// Snippet 05 - Thread Life Cycle
// ==========================================
//
// This example shows how the state of a
// thread changes during its life cycle.
//
// We will inspect the thread:
//
// 1. Before it starts
// 2. While it is working
// 3. After it has finished
// ==========================================

using System;
using System.Threading;

public static class Snippet05ThreadLifeCycle
{
    public static void Run()
    {
        Console.WriteLine("==========================================");
        Console.WriteLine("            THREAD LIFE CYCLE");
        Console.WriteLine("==========================================");
        Console.WriteLine();


        // ------------------------------------------
        // Create the Thread
        // ------------------------------------------
        //
        // We create a thread and tell it to run
        // the Work method.
        //
        // The thread exists, but Start() has not
        // been called yet.

        Thread thread = new Thread(Work);


        // ------------------------------------------
        // State 1 - Before Start
        // ------------------------------------------
        //
        // Because the thread has been created but
        // has not started, its state is Unstarted.

        Console.WriteLine($"Before Start: {thread.ThreadState}");


        // ------------------------------------------
        // Start the Thread
        // ------------------------------------------

        thread.Start();


        // Pause the MAIN thread briefly.
        //
        // This gives the worker thread time to
        // start executing the Work method.

        Thread.Sleep(100);


        // ------------------------------------------
        // State 2 - After Start
        // ------------------------------------------
        //
        // The worker thread is now active.
        //
        // Because Work() contains Thread.Sleep(),
        // you may see WaitSleepJoin here rather
        // than Running.

        Console.WriteLine($"After Start: {thread.ThreadState}");


        // ------------------------------------------
        // Wait for the Thread to Finish
        // ------------------------------------------
        //
        // Join() makes the current thread wait
        // until this worker thread has completed.

        thread.Join();


        // ------------------------------------------
        // State 3 - After Join
        // ------------------------------------------
        //
        // Once the worker thread has completely
        // finished, its state becomes Stopped.

        Console.WriteLine($"After Join: {thread.ThreadState}");
    }


    // ==========================================
    // Worker Thread Method
    // ==========================================

    static void Work()
    {
        Console.WriteLine();
        Console.WriteLine("Thread is working...");


        // Sleep pauses THIS worker thread
        // for one second.
        //
        // While sleeping, the thread normally
        // enters the WaitSleepJoin state.

        Thread.Sleep(1000);
    }
}