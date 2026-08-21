// ==========================================
// Snippet 06 - Using Thread.Join()
// ==========================================
//
// This example shows how Thread.Join()
// makes one thread wait for another thread
// to finish.
//
// The main thread will start a worker thread
// that simulates downloading a file.
//
// Join() prevents the main thread from
// continuing until that download is complete.
// ==========================================

using System;
using System.Threading;

public static class Snippet06ThreadJoin
{
    public static void Run()
    {
        Console.WriteLine("==========================================");
        Console.WriteLine("           USING THREAD.JOIN()");
        Console.WriteLine("==========================================");
        Console.WriteLine();


        // ------------------------------------------
        // Create the Worker Thread
        // ------------------------------------------
        //
        // This thread will run the DownloadFile
        // method.

        Thread worker = new Thread(DownloadFile);


        // ------------------------------------------
        // Start the Worker Thread
        // ------------------------------------------
        //
        // The worker thread now begins executing
        // DownloadFile().

        worker.Start();


        // The main thread continues immediately
        // after Start().

        Console.WriteLine("Waiting for download to finish...");


        // ------------------------------------------
        // Join the Worker Thread
        // ------------------------------------------
        //
        // Join() pauses the CURRENT thread
        // until the worker thread finishes.
        //
        // In this example:
        //
        // Main thread
        //      ↓
        // worker.Join()
        //      ↓
        // WAIT
        //      ↓
        // Worker finishes
        //      ↓
        // Main thread continues

        worker.Join();


        // This line cannot run until the worker
        // thread has finished.

        Console.WriteLine("Download completed. Continue main program.");
    }


    // ==========================================
    // Worker Thread Method
    // ==========================================

    static void DownloadFile()
    {
        // Sleep for 3 seconds to simulate
        // a file being downloaded.

        Thread.Sleep(3000);


        // This runs on the worker thread.

        Console.WriteLine("File downloaded.");
    }
}