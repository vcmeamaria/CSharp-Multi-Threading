// ==========================================
// Snippet 07 - Race Condition
// ==========================================
//
// This example demonstrates a race condition.
//
// A race condition can happen when multiple
// threads access and modify the same shared
// data at the same time.
//
// We will deliberately create an unsafe
// counter so we can see the problem.
// ==========================================

using System;
using System.Threading;

public static class Snippet07RaceCondition
{
    // ------------------------------------------
    // Shared Data
    // ------------------------------------------
    //
    // Both worker threads will access and
    // modify this SAME counter variable.
    //
    // This shared access is what creates
    // the possibility of a race condition.

    static int counter = 0;


    public static void Run()
    {
        Console.WriteLine("==========================================");
        Console.WriteLine("             RACE CONDITION");
        Console.WriteLine("==========================================");
        Console.WriteLine();


        // Reset the counter each time this example
        // is selected from our console menu.
        //
        // This lets us run the example repeatedly
        // without keeping the previous result.

        counter = 0;


        // ------------------------------------------
        // Create Two Threads
        // ------------------------------------------
        //
        // Both threads will run the SAME method.
        //
        // This means both threads will try to
        // increment the SAME counter variable.

        Thread t1 = new Thread(IncrementCounter);
        Thread t2 = new Thread(IncrementCounter);


        // ------------------------------------------
        // Start Both Threads
        // ------------------------------------------

        t1.Start();
        t2.Start();


        // ------------------------------------------
        // Wait for Both Threads
        // ------------------------------------------
        //
        // We need both worker threads to finish
        // before we display the final counter.

        t1.Join();
        t2.Join();


        // ------------------------------------------
        // Display the Result
        // ------------------------------------------
        //
        // Each thread performs 100,000 increments.
        //
        // Therefore, we EXPECT:
        //
        // 100,000 + 100,000 = 200,000
        //
        // However, because counter++ is not
        // protected, the result may be lower.

        Console.WriteLine($"Expected Counter: 200000");
        Console.WriteLine($"Actual Counter:   {counter}");


        Console.WriteLine();

        if (counter == 200000)
        {
            Console.WriteLine(
                "This run happened to produce the expected result."
            );

            Console.WriteLine(
                "Run the example again - race conditions are unpredictable!"
            );
        }
        else
        {
            Console.WriteLine(
                "Race condition detected: some increments were lost."
            );
        }
    }


    // ==========================================
    // Worker Thread Method
    // ==========================================

    static void IncrementCounter()
    {
        // Each worker thread runs this loop
        // 100,000 times.

        for (int i = 0; i < 100000; i++)
        {
            // --------------------------------------
            // UNSAFE SHARED OPERATION
            // --------------------------------------
            //
            // counter++ looks like one simple action,
            // but multiple threads can interfere
            // with each other while performing it.
            //
            // There is NO lock here.
            //
            // That is intentional for this example.

            counter++;
        }
    }
}