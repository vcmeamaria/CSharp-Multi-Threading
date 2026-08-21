// ==========================================
// Snippet 01 - Current Thread Information
// ==========================================
//
// This example shows how to get information
// about the thread that is currently running.
//
// A C# application normally starts with one
// main thread. Thread.CurrentThread allows us
// to access information about that thread.
// ==========================================

using System;
using System.Threading;

public static class Snippet01CurrentThreadInformation
{
    public static void Run()
    {
        Console.WriteLine("==========================================");
        Console.WriteLine("      CURRENT THREAD INFORMATION");
        Console.WriteLine("==========================================");
        Console.WriteLine();


        // ------------------------------------------
        // Get the Current Thread
        // ------------------------------------------
        //
        // Thread.CurrentThread gives us the thread
        // that is currently executing this code.
        //
        // Because this example is being called from
        // our main program, this is currently the
        // application's main thread.

        Thread current = Thread.CurrentThread;


        // ------------------------------------------
        // Give the Thread a Name
        // ------------------------------------------
        //
        // Threads do not automatically need a name.
        //
        // Giving one a name can make debugging and
        // understanding our application easier.
        //
        // A thread's Name can only be assigned once,
        // so we check whether it already has one.

        if (current.Name == null)
        {
            current.Name = "Main Application Thread";
        }


        // ------------------------------------------
        // Display Thread Information
        // ------------------------------------------

        // Name:
        // The human-readable name we gave the thread.
        Console.WriteLine($"Thread Name: {current.Name}");


        // ManagedThreadId:
        // A unique ID assigned to this managed thread
        // while the application is running.
        Console.WriteLine($"Thread ID: {current.ManagedThreadId}");


        // IsBackground:
        // False = foreground thread.
        // True  = background thread.
        //
        // The main application thread is normally
        // a foreground thread.
        Console.WriteLine($"Is Background: {current.IsBackground}");


        // ThreadState:
        // Shows the current state of the thread.
        //
        // Because this thread is executing code right
        // now, we would normally expect "Running".
        Console.WriteLine($"Thread State: {current.ThreadState}");


        // Priority:
        // Indicates the scheduling priority of
        // this thread.
        //
        // The normal/default value is usually Normal.
        Console.WriteLine($"Priority: {current.Priority}");
    }
}