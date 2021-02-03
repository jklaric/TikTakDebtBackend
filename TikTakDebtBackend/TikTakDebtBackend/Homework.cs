using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace TikTakDebtBackend
{
    public class Homework
    {
        public Homework(int id, string name, DateTime initialDay, DateTime finalDay, int daysExtended, int daysLate, string githubLink, string reviewLink)
        {
            Id = id;
            Name = name;
            InitialDay = initialDay;
            FinalDay = finalDay;
            DaysExtended = daysExtended;
            DaysLate = daysLate;
            GithubLink = githubLink;
            ReviewLink = reviewLink;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime InitialDay { get; set; }

        public DateTime FinalDay { get; set; }

        public int DaysExtended { get; set; }

        public int DaysLate { get; set; }

        public string GithubLink { get; set; }

        public string ReviewLink { get; set; }

        public static Homework CreateNewHomework()
        {
            var isRunning = true;
            var newHomeworkName = "";
            var newHomeworkInitialDay = "";
            var newHomeWorkFinalDay = "";
            var newHomeworkDaysExtended = "";
            var newHomeworkDaysLate = "";
            var newHomeworkGithubLink = "";
            var newHomeworkReviewLink = "";

            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("What is the name of the new homework?");
                newHomeworkName = Console.ReadLine();
                while (string.IsNullOrEmpty(newHomeworkName))
                {
                    Console.Clear();
                    Console.WriteLine("Please enter a valid name.");
                    newHomeworkName = Console.ReadLine();
                }

                Console.Clear();
                Console.WriteLine("When was the Homework given?");
                newHomeworkInitialDay = Console.ReadLine();
                while (!DateTime.TryParse(newHomeworkInitialDay, out _))
                {
                    Console.Clear();
                    Console.WriteLine("Please type the date in the format: YYYY-MM-DD hh:mm");
                    newHomeworkInitialDay = Console.ReadLine();
                }

                Console.Clear();
                Console.WriteLine("When is the deadline?");
                newHomeWorkFinalDay = Console.ReadLine();
                while (!DateTime.TryParse(newHomeWorkFinalDay, out _))
                {
                    Console.Clear();
                    Console.WriteLine("Please type the date in the format: YYYY-MM-DD hh:mm");
                    newHomeWorkFinalDay = Console.ReadLine();
                }

                Console.Clear();
                Console.WriteLine("How many days was the deadline extended?");
                newHomeworkDaysExtended = Console.ReadLine();
                while (!int.TryParse(newHomeworkDaysExtended, out _))
                {
                    Console.Clear();
                    Console.WriteLine("Please enter a valid number.");
                    newHomeworkDaysExtended = Console.ReadLine();
                }

                Console.Clear();
                Console.WriteLine("How many days after the deadline was the homework delivered?");
                newHomeworkDaysLate = Console.ReadLine();
                while (!int.TryParse(newHomeworkDaysLate, out _))
                {
                    Console.Clear();
                    Console.WriteLine("Please enter a valid number.");
                    newHomeworkDaysLate = Console.ReadLine();
                }

                Console.Clear();
                Console.WriteLine("What is the link to the homework?");
                newHomeworkGithubLink = Console.ReadLine();
                while (string.IsNullOrEmpty(newHomeworkGithubLink))
                {
                    Console.Clear();
                    Console.WriteLine("Please enter a valid link.");
                    newHomeworkGithubLink = Console.ReadLine();
                }

                Console.Clear();
                Console.WriteLine("What  is the link to the review?");
                newHomeworkReviewLink = Console.ReadLine();
                while (string.IsNullOrEmpty(newHomeworkReviewLink))
                {
                    Console.Clear();
                    Console.WriteLine("Please enter a valid review link.");
                    newHomeworkReviewLink = Console.ReadLine();
                }

                isRunning = false;
            }

            Console.Clear();
            return new Homework(0, newHomeworkName, DateTime.Parse(newHomeworkInitialDay), DateTime.Parse(newHomeWorkFinalDay),
                int.Parse(newHomeworkDaysExtended), int.Parse(newHomeworkDaysLate), newHomeworkGithubLink, newHomeworkReviewLink);
        }
    }
}
