using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace TikTakDebtBackend
{
    class Program
    {
        static void Main(string[] args)
        {
            var isRunning = true;
            var homeworkList = new List<Homework>();
            var userInput = "";

            var placeholderHomework = new Homework(1, "placeholder", DateTime.Parse("12. 12. 1212"),
                DateTime.Parse("12. 12. 1213"), 5, 8, "asd", "asdd");
            homeworkList.Add(placeholderHomework);

            while (isRunning)
            {
                Console.WriteLine("Choose an action:");
                Console.WriteLine("1 - Create a new homework");
                Console.WriteLine("2 - Print homework list");
                Console.WriteLine("3 - Edit a homework");
                Console.WriteLine("4 - Delete a homework");
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
                            Console.WriteLine(i + " - " + homework.Name + " from " + homework.InitialDay + " to " +
                                              homework.FinalDay);
                            i++;
                        }

                        break;

                    case "3":
                        EditHomework(homeworkList);
                        break;

                    case "4":
                        DeleteHomework(homeworkList);
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Enter one of the valid numbers.");
                        break;
                }
            }
        }

        static void EditHomework(List<Homework> homeworkList)
        {
            var isRunning = true;
            var selectedAction = "";
            var isValidInput = false;

            Console.WriteLine("Choose an action:");
            Console.WriteLine("0 - Exit Process");
            Console.WriteLine("1 - Edit Name");
            Console.WriteLine("2 - Edit Initial Day");
            Console.WriteLine("3 - Edit Final Day");
            Console.WriteLine("4 - Edit Days Extended");
            Console.WriteLine("5 - Edit Days Late");
            Console.WriteLine("6 - Edit Github Link");
            Console.WriteLine("7 - Edit review Link");

            while (isRunning)
            {
                selectedAction = Console.ReadLine();

                for (int i = 0; i <= 7; i++)
                {
                    if (int.Parse(selectedAction) == 0)
                    {
                        return;
                    }
                    else if (int.Parse(selectedAction) == i)
                    {
                        isValidInput = true;
                    }
                }

                if (!isValidInput)
                {
                    Console.WriteLine("Please enter a valid number.");
                }
                else
                {
                    isRunning = false;
                }
            }

            Console.WriteLine("Select homework:");
            foreach (var homework in homeworkList)
            {
                var i = 1;
                Console.WriteLine(i + " - " + homework.Name + " from " + homework.InitialDay + " to " +
                                  homework.FinalDay);
                i++;
            }

            for (int i = 0; i < homeworkList.Count; i++)
            {
                var userInput = Console.ReadLine();

                if (int.Parse(userInput) == i + 1)
                {
                    switch (selectedAction)
                    {
                        case "1":
                            Console.WriteLine("What do you want to rename the homework to?");
                            homeworkList[i].Name = Console.ReadLine();
                            break;
                        case "2":
                            Console.WriteLine("What do you want the initial date changed to?");
                            homeworkList[i].InitialDay = DateTime.Parse(Console.ReadLine());
                            break;
                        case "3":
                            Console.WriteLine("What do you want the final date changed to?");
                            homeworkList[i].FinalDay = DateTime.Parse(Console.ReadLine());
                            break;
                        case "4":
                            Console.WriteLine("What do you want to change the days extended to?");
                            homeworkList[i].DaysExtended = int.Parse(Console.ReadLine());
                            break;
                        case "5":
                            Console.WriteLine("What do you want to change the days late to?");
                            homeworkList[i].DaysLate = int.Parse(Console.ReadLine());
                            break;
                        case "6":
                            Console.WriteLine("What do you want to change the github link to?");
                            homeworkList[i].GithubLink = Console.ReadLine();
                            break;
                        case "7":
                            Console.WriteLine("What do you want to change the review link to?");
                            homeworkList[i].ReviewLink = Console.ReadLine();
                            break;
                    }
                }
            }
        }
        static void DeleteHomework(List<Homework> homeworkList)
        {
            Console.WriteLine("Select homework to delete:");
            foreach (var homework in homeworkList)
            {
                var i = 1;
                Console.WriteLine(i + " - " + homework.Name + " from " + homework.InitialDay + " to " +
                                  homework.FinalDay);
                i++;
            }

            for (int i = 0; i < homeworkList.Count; i++)
            {
                var userInput = Console.ReadLine();

                if (int.Parse(userInput) == i + 1)
                {
                    homeworkList.Remove(homeworkList[i]);
                }
            }
        }
    }
}
