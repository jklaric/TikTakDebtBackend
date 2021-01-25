using System;
using System.Collections.Generic;
using System.Text;

namespace TikTakDebtBackend
{
    public class FinishedHomework : Homework
    {
        public FinishedHomework(int id, string name, DateTime initialDay, DateTime finalDay, int daysExtended, int daysLate,
            string githubLink, string reviewLink) : base(id, name, initialDay, finalDay, daysExtended, daysLate, githubLink, reviewLink)
        {
            DateFinished = finalDay.AddDays(daysExtended + daysLate);
        }
        public DateTime DateFinished { get; set; }
    }
}