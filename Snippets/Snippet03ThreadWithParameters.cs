// ==========================================
// Snippet 03 - Thread with Parameters
// ==========================================
//
// This example shows how to pass information
// to a thread when we start it.
//
// In the previous example, the worker thread
// simply ran a method.
//
// This time, we will also send a message
// into that method.
// ==========================================

using System;
using System.Threading;

public static class Snippet03ThreadWithParameters
{
    public static void Run()
    {
        Console.WriteLine("==========================================");
        Console.WriteLine("          THREAD WITH PARAMETERS");
        Console.WriteLine("==========================================");
        Console.WriteLine();


        // ------------------------------------------
        // Create the Thread
        // ------------------------------------------
        //
        // PrintMessage expects a parameter.
        //
        // Because of this, the thread will allow
        // us to provide an object when Start()
        // is called.

        Thread thread = new Thread(PrintMessage);


        // ------------------------------------------
        // Start the Thread with Data
        // ------------------------------------------
        //
        // Start() can receive an object that will
        // be passed into the PrintMessage method.
        //
        // Here, we are passing a string.

        thread.Start("Hello from parameterized thread!");


        // ------------------------------------------
        // Wait for the Thread
        // ------------------------------------------
        //
        // We use Join() so our console menu waits
        // until this worker thread has finished.

        thread.Join();


        Console.WriteLine();
        Console.WriteLine("Parameterized thread has finished.");
    }


    // ==========================================
    // Worker Thread Method
    // ==========================================

    static void PrintMessage(object? message)
    {
        // The parameter is object? because
        // Thread.Start() accepts an object.
        //
        // The ? means the value is also allowed
        // to be null.


        // ------------------------------------------
        // Check the Type Safely
        // ------------------------------------------
        //
        // This checks whether message contains
        // a string.
        //
        // If it does, the string is stored
        // inside the variable called text.

        if (message is string text)
        {
            Console.WriteLine(text);
        }
        else
        {
            Console.WriteLine("No valid message was provided.");
        }
    }
}