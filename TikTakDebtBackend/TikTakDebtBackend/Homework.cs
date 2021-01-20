using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace TikTakDebtBackend
{
    class Homework
    {
        public Homework(int id, string name, DateTime initialDay, DateTime finalDay, int daysExtended, int daysLate, string githubLink, string reviewLink)
        {
            ID = id;
            Name = name;
            InitialDay = initialDay;
            FinalDay = finalDay;
            DaysExtended = daysExtended;
            DaysLate = daysLate;
            GithubLink = githubLink;
            ReviewLink = reviewLink;
        }

        public int ID { get; set; }

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
                Console.WriteLine("What is the name of the new homework?");
                newHomeworkName = Console.ReadLine();

                Console.WriteLine("When was the Homework given?");
                newHomeworkInitialDay = Console.ReadLine();

                Console.WriteLine("When is the deadline?");
                newHomeWorkFinalDay = Console.ReadLine();

                Console.WriteLine("How many days was the deadline extended?");
                newHomeworkDaysExtended = Console.ReadLine();

                Console.WriteLine("How many days after the deadline was the homework delivered?");
                newHomeworkDaysLate = Console.ReadLine();

                Console.WriteLine("What is the link to the homework?");
                newHomeworkGithubLink = Console.ReadLine();

                Console.WriteLine("What  is the link to the review?");
                newHomeworkReviewLink = Console.ReadLine();

                isRunning = false;
            }

            return new Homework(0, newHomeworkName, DateTime.Parse(newHomeworkInitialDay), DateTime.Parse(newHomeWorkFinalDay),
                int.Parse(newHomeworkDaysExtended), int.Parse(newHomeworkDaysLate), newHomeworkGithubLink, newHomeworkReviewLink);
        }
    }
}
