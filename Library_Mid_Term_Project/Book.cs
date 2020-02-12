using System;
using System.Collections.Generic;
using System.Text;

namespace Library_Mid_Term_Project
{
    class Book : Item
    {
        private int numberOfPages;


        public int NumberOfPages
        {
            get { return numberOfPages; }
            set { numberOfPages = value; }
        }
        public Book()
        {

        }

        public Book(string mediaType, string title, string author, string description, bool checkedIn, DateTime dueDate, int numberOfPages) : base(mediaType, title, author, description, checkedIn, dueDate)
        {
            this.numberOfPages = numberOfPages;
        }
    }
}
