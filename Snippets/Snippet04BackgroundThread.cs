// ==========================================
// Snippet 04 - Foreground vs Background Thread
// ==========================================
//
// This example shows the difference between
// foreground and background threads.
//
// A foreground thread keeps the application alive.
//
// A background thread does NOT keep the
// application alive. If all foreground threads
// finish, background threads are automatically
// stopped.
// ==========================================

using System;
using System.Threading;

public static class Snippet04BackgroundThread
{
    public static void Run()
    {
        Console.WriteLine("==========================================");
        Console.WriteLine("      FOREGROUND VS BACKGROUND THREAD");
        Console.WriteLine("==========================================");
        Console.WriteLine();


        // ------------------------------------------
        // Create a Worker Thread
        // ------------------------------------------
        //
        // This thread will run the DoWork method.

        Thread backgroundThread = new Thread(DoWork);


        // ------------------------------------------
        // Make it a Background Thread
        // ------------------------------------------
        //
        // Threads are foreground threads by default.
        //
        // Setting IsBackground to true changes this
        // worker into a background thread.

        backgroundThread.IsBackground = true;


        // Display its type so we can see the value.

        Console.WriteLine(
            $"Is background thread: {backgroundThread.IsBackground}"
        );

        Console.WriteLine();


        // ------------------------------------------
        // Start the Background Thread
        // ------------------------------------------

        backgroundThread.Start();


        // ------------------------------------------
        // Main Thread Continues
        // ------------------------------------------
        //
        // The main thread does not automatically
        // wait for the background thread.

        Console.WriteLine("Main thread has reached the end of the example.");
        Console.WriteLine();


        // ------------------------------------------
        // Important: Our Console Menu
        // ------------------------------------------
        //
        // In the standalone example from the
        // learning material, the Main method ends
        // here.
        //
        // Because the worker is a BACKGROUND thread,
        // the application may close before it gets
        // the chance to print all 10 numbers.
        //
        // Our project is slightly different because
        // Program.cs keeps the main application alive
        // with a console menu.
        //
        // Without this Join(), the background thread
        // could continue printing while our menu is
        // being displayed.
        //
        // We therefore wait here only to keep our
        // learning project tidy.

        backgroundThread.Join();


        Console.WriteLine();
        Console.WriteLine("Background thread demo finished.");
    }


    // ==========================================
    // Background Thread Method
    // ==========================================

    static void DoWork()
    {
        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine($"Background work: {i}");

            // Pause this background thread
            // for one second.

            Thread.Sleep(1000);
        }
    }
}