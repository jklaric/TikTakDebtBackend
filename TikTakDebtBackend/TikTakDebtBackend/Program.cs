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
                        Console.Clear();
                        var newHomework = Homework.CreateNewHomework();
                        homeworkList.Add(newHomework);
                        newHomework.Id = homeworkList.Count;
                        break;

                    case "2":
                        Console.Clear();
                        foreach (var homework in homeworkList)
                        {
                            var finishedHomework = new FinishedHomework(homework.Id, homework.Name, homework.InitialDay, homework.FinalDay,
                                homework.DaysExtended, homework.DaysLate, homework.GithubLink, homework.ReviewLink);
                            var i = 1;
                            Console.WriteLine(i + " - " + finishedHomework.Name + " from " + finishedHomework.InitialDay + " to " + finishedHomework.FinalDay + " finished on " + finishedHomework.DateFinished);
                            i++;
                        }
                        break;

                    case "3":
                        Console.Clear();
                        EditHomework(homeworkList);
                        Console.Clear();
                        break;

                    case "4":
                        DeleteHomework(homeworkList);
                        Console.Clear();
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
            var editInput = "";
            Console.WriteLine("Choose an action:");
            Console.WriteLine("0 - Exit Process");
            Console.WriteLine("1 - Edit Name");
            Console.WriteLine("2 - Edit Initial Day");
            Console.WriteLine("3 - Edit Final Day");
            Console.WriteLine("4 - Edit Days Extended");
            Console.WriteLine("5 - Edit Days Late");
            Console.WriteLine("6 - Edit Github Link");
            Console.WriteLine("7 - Edit review Link");

            var selectedAction = Console.ReadLine();
            while (!int.TryParse(selectedAction, out _) || !(int.Parse(selectedAction) >= 0 && int.Parse(selectedAction) <= 7))
            {
                Console.WriteLine("Please enter a valid number.");
                selectedAction = Console.ReadLine();
            }

            if (int.Parse(selectedAction) == 0)
            {
                return;
            }

            Console.WriteLine("Select homework:");
            foreach (var homework in homeworkList)
            {
                var i = 1;
                Console.WriteLine(i + " - " + homework.Name + " from " + homework.InitialDay + " to " + homework.FinalDay);
                i++;
            }

            var userInput = Console.ReadLine();
            while (!int.TryParse(userInput, out _) || !(int.Parse(userInput) > 0 && int.Parse(userInput) < homeworkList.Count))
            {
                Console.WriteLine("Please enter a valid number.");
                userInput = Console.ReadLine();
            }

            while (isRunning)
            {
                Console.Clear();
                switch (selectedAction)
                {
                    case "1":
                        Console.WriteLine("What do you want to rename the homework to?");
                        editInput = Console.ReadLine();
                        while (string.IsNullOrEmpty(editInput))
                        {
                            Console.Clear();
                            Console.WriteLine("Please enter a valid name.");
                            editInput = Console.ReadLine();
                        }
                        homeworkList[int.Parse(userInput) - 1].Name = editInput;
                        isRunning = false;
                        break;

                    case "2":
                        Console.WriteLine("What do you want the initial date changed to?");
                        editInput = Console.ReadLine();
                        while (!DateTime.TryParse(editInput, out _))
                        { 
                            Console.Clear();
                            Console.WriteLine("Please type the date in the format: YYYY-MM-DD hh:mm");
                            editInput = Console.ReadLine();
                        }
                        homeworkList[int.Parse(userInput) - 1].InitialDay = DateTime.Parse(editInput);
                        isRunning = false;
                        break;

                    case "3":
                        Console.WriteLine("What do you want the final date changed to?");
                        editInput = Console.ReadLine();
                        while (!DateTime.TryParse(editInput, out _))
                        {
                            Console.Clear();
                            Console.WriteLine("Please type the date in the format: YYYY-MM-DD hh:mm");
                            editInput = Console.ReadLine();
                        }
                        homeworkList[int.Parse(userInput) - 1].FinalDay = DateTime.Parse(editInput);
                        isRunning = false;
                        break;

                    case "4":
                        Console.WriteLine("What do you want to change the days extended to?");
                        editInput = Console.ReadLine();
                        while (!int.TryParse(editInput, out _))
                        {
                            Console.Clear();
                            Console.WriteLine("Please enter a valid number.");
                            editInput = Console.ReadLine();
                        }
                        homeworkList[int.Parse(userInput) - 1].DaysExtended = int.Parse(editInput);
                        isRunning = false;
                        break;

                    case "5":
                        Console.WriteLine("What do you want to change the days late to?");
                        editInput = Console.ReadLine();
                        while (!int.TryParse(editInput, out _))
                        {
                            Console.Clear();
                            Console.WriteLine("Please enter a valid number.");
                            editInput = Console.ReadLine();
                        }
                        homeworkList[int.Parse(userInput) - 1].DaysLate = int.Parse(editInput);
                        isRunning = false;
                        break;

                    case "6":
                        Console.WriteLine("What do you want to change the github link to?");
                        editInput = Console.ReadLine();
                        while (string.IsNullOrEmpty(editInput))
                        {
                            Console.Clear();
                            Console.WriteLine("Please enter a valid github link.");
                            editInput = Console.ReadLine();
                        }
                        homeworkList[int.Parse(userInput) - 1].GithubLink = editInput;
                        isRunning = false;
                        break;

                    case "7":
                        Console.WriteLine("What do you want to change the review link to?");
                        editInput = Console.ReadLine();
                        while (string.IsNullOrEmpty(editInput))
                        {
                            Console.Clear();
                            Console.WriteLine("Please enter a valid review link.");
                            editInput = Console.ReadLine();
                        }
                        homeworkList[int.Parse(userInput) - 1].ReviewLink = editInput;
                        isRunning = false;
                        break;

                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }


                return;
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
