using System;
using System.Collections.Generic;
using System.Text;

namespace Library_Mid_Term_Project
{
    class Movie : Item
    {
        private string duration;
        //properties
        public string Duration { get; set;}

        public Movie(string mediaType, string title, string author, string description, bool checkedIn, DateTime dueDate, string duration) : base(mediaType, title, author, description, checkedIn, dueDate)
        {
            this.Duration = duration;
        }
    }
}
