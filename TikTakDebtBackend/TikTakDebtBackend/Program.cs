using System;
using System.Collections.Generic;

namespace TikTakDebtBackend
{
    class Program
    {
        static void Main(string[] args)
        {
            var isRunning = true;
            var homeworkList = new List<Homework>();
            var userInput = "";

            while (isRunning)
            {
                Console.WriteLine("Choose an action:");
                Console.WriteLine("1 - Create a new homework tracker");
                Console.WriteLine("2 - Print all homework trackers");
                Console.WriteLine("3 - Edit a homework tracker");
                Console.WriteLine("4 - Delete a homework tracker");
                Console.WriteLine("0 - Exit program");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "0":
                        while (isRunning)
                        {
                            Console.WriteLine("Do you really want to quit?");
                            userInput = Console.ReadLine();

                            if (userInput == "yes")
                            {
                                Console.Clear();
                                Environment.Exit(0);
                            }
                            else if (userInput == "no")
                            {
                                Console.Clear();
                                isRunning = false;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Type yes or no.");
                            }
                        }
                        isRunning = true;
                        break;

                    case "1":
                        var newHomework = Homework.CreateNewHomework();
                        homeworkList.Add(newHomework);
                        newHomework.ID = homeworkList.Count;
                        break;

                    case "2":
                        foreach (var homework in homeworkList)
                        {
                            var i = 1;
                            Console.WriteLine(i + " - " + homework.Name + " from " + homework.InitialDay + " to " + homework.FinalDay);
                            i++;
                        }
                        break;

                    case "3":
                        Console.WriteLine("Select homework:");
                        foreach (var homework in homeworkList)
                        {
                            var i = 1;
                            Console.WriteLine(i + " - " + homework.Name + " from " + homework.InitialDay + " to " + homework.FinalDay);
                            i++;
                        }

                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Enter one of the valid numbers.");
                        break;
                }
            }
        }
    }
}
