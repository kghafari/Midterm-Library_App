using System;
using System.Collections.Generic;
using System.Text;

namespace Library_Mid_Term_Project
{
    class Magazine : Item
    {
        private int numberOfPages;
        //properties
        public int NumberOfPages { get; set; }

        public Magazine(string mediaType, string title, string author, string description, bool checkedIn, DateTime dueDate, int numberOfPages) : base(mediaType, title, author, description, checkedIn, dueDate)
        {
            this.NumberOfPages = numberOfPages;
        }
    }
}
