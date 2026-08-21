// ==========================================
// C# Multi-Threading
// ==========================================
//
// This project contains a collection of
// multi-threading examples.
//
// Each example is stored inside the
// Snippets folder and can be selected
// from this console menu.
//
// The examples will be added one at a time
// as we work through the learning material.
// ==========================================

using System;

class Program
{
    static void Main()
    {
        bool running = true;

        while (running)
        {
            Console.Clear();

            Console.WriteLine("==========================================");
            Console.WriteLine("          C# MULTI-THREADING");
            Console.WriteLine("==========================================");
            Console.WriteLine();

            Console.WriteLine(" 1. Current Thread Information");
            Console.WriteLine(" 2. Creating a Thread");
            Console.WriteLine(" 3. Thread with Parameters");
            Console.WriteLine(" 4. Foreground vs Background Thread");
            Console.WriteLine(" 5. Thread Life Cycle");
            Console.WriteLine(" 6. Using Thread.Join()");
            Console.WriteLine(" 7. Race Condition");
            Console.WriteLine(" 8. Fix Race Condition with lock");
            Console.WriteLine(" 9. Using Monitor");
            Console.WriteLine("10. Using Monitor.TryEnter()");
            Console.WriteLine("11. Deadlock");
            Console.WriteLine("12. Avoiding Deadlocks");
            Console.WriteLine("13. Synchronization Attribute");
            Console.WriteLine("14. Mutex");
            Console.WriteLine("15. Thread Pool");
            Console.WriteLine("16. Task-Based Multi-Threading");
            Console.WriteLine("17. TaskScheduler");
            Console.WriteLine("18. Limiting Concurrency with TaskScheduler");
            Console.WriteLine("19. Running Tests in Parallel");
            Console.WriteLine("20. Thread-Safe Logging");
            Console.WriteLine("21. Interlocked Atomic Operations");
            Console.WriteLine("22. Multi-Threaded File Processor");

            Console.WriteLine();
            Console.WriteLine(" 0. Exit");

            Console.WriteLine();
            Console.Write("Choose an example: ");

            string? choice = Console.ReadLine();

            Console.Clear();

            switch (choice)
            {
                case "1":
                    Snippet01CurrentThreadInformation.Run();
                    break;

                case "2":
                    Snippet02CreatingAThread.Run();
                    break;

                case "3":
                    Snippet03ThreadWithParameters.Run();
                    break;

                case "4":
                    Snippet04BackgroundThread.Run();
                    break;

                case "5":
                    Snippet05ThreadLifeCycle.Run();
                    break;

                case "6":
                    Snippet06ThreadJoin.Run();
                    break;

                case "7":
                    Snippet07RaceCondition.Run();
                    break;

                case "8":
                    ShowComingSoon("Fix Race Condition with lock");
                    break;

                case "9":
                    ShowComingSoon("Using Monitor");
                    break;

                case "10":
                    ShowComingSoon("Using Monitor.TryEnter()");
                    break;

                case "11":
                    ShowComingSoon("Deadlock");
                    break;

                case "12":
                    ShowComingSoon("Avoiding Deadlocks");
                    break;

                case "13":
                    ShowComingSoon("Synchronization Attribute");
                    break;

                case "14":
                    ShowComingSoon("Mutex");
                    break;

                case "15":
                    ShowComingSoon("Thread Pool");
                    break;

                case "16":
                    ShowComingSoon("Task-Based Multi-Threading");
                    break;

                case "17":
                    ShowComingSoon("TaskScheduler");
                    break;

                case "18":
                    ShowComingSoon("Limiting Concurrency with TaskScheduler");
                    break;

                case "19":
                    ShowComingSoon("Running Tests in Parallel");
                    break;

                case "20":
                    ShowComingSoon("Thread-Safe Logging");
                    break;

                case "21":
                    ShowComingSoon("Interlocked Atomic Operations");
                    break;

                case "22":
                    ShowComingSoon("Multi-Threaded File Processor");
                    break;

                case "0":
                    running = false;

                    Console.WriteLine("==========================================");
                    Console.WriteLine("                 GOODBYE!");
                    Console.WriteLine("==========================================");
                    break;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }

            if (running)
            {
                Console.WriteLine();
                Console.WriteLine("Press Enter to return to the menu...");
                Console.ReadLine();
            }
        }
    }


    // ==========================================
    // Temporary Snippet Message
    // ==========================================
    //
    // Until an example has been added to the
    // Snippets folder, this method lets the menu
    // option exist without causing an error.

    static void ShowComingSoon(string exampleName)
    {
        Console.WriteLine("==========================================");
        Console.WriteLine(exampleName.ToUpper());
        Console.WriteLine("==========================================");
        Console.WriteLine();

        Console.WriteLine("This example has not been added yet.");
    }
}