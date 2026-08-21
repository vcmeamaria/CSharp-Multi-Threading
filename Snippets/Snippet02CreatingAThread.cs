// ==========================================
// Snippet 02 - Creating a Thread
// ==========================================
//
// This example shows how to create a new
// worker thread in C#.
//
// The application already has its main thread.
// We will create a second thread and ask it
// to run a separate method.
// ==========================================

using System;
using System.Threading;

public static class Snippet02CreatingAThread
{
    public static void Run()
    {
        Console.WriteLine("==========================================");
        Console.WriteLine("           CREATING A THREAD");
        Console.WriteLine("==========================================");
        Console.WriteLine();


        // ------------------------------------------
        // Create a New Thread
        // ------------------------------------------
        //
        // The Thread constructor needs to know
        // which method the new thread should run.
        //
        // Here, we tell it to run PrintNumbers.
        //
        // At this point the thread exists,
        // but it has NOT started running yet.

        Thread workerThread = new Thread(PrintNumbers);


        // ------------------------------------------
        // Start the Worker Thread
        // ------------------------------------------
        //
        // Start() tells the new thread to begin
        // executing the PrintNumbers method.

        workerThread.Start();


        // ------------------------------------------
        // Main Thread Continues
        // ------------------------------------------
        //
        // Starting another thread does NOT mean
        // the main thread automatically waits.
        //
        // Both threads can now make progress.

        Console.WriteLine("Main thread is running...");


        // ------------------------------------------
        // Wait for the Worker Thread
        // ------------------------------------------
        //
        // We use Join() here so that our console
        // example does not return to the menu
        // while the worker thread is still running.
        //
        // We will study Join() properly in
        // a later example.

        workerThread.Join();

        Console.WriteLine();
        Console.WriteLine("Worker thread has finished.");
    }


    // ==========================================
    // Worker Thread Method
    // ==========================================

    static void PrintNumbers()
    {
        // This method will run on our new
        // worker thread.

        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine($"Worker Thread: {i}");


            // Sleep pauses the CURRENT thread.
            //
            // In this case, the worker thread
            // pauses for 500 milliseconds.
            //
            // 500 milliseconds = half a second.

            Thread.Sleep(500);
        }
    }
}