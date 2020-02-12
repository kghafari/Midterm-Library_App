using System;
using System.Collections.Generic;
using System.Text;

namespace Library_Mid_Term_Project
{
    public abstract class Item
    {
        private string mediaType;
        private string title;
        private string author;
        private string description;
        private bool checkedIn;
        private DateTime dueDate;

        public string MediaType
        {
            get { return mediaType; }
            set { mediaType = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Author
        {
            get { return author; }
            set { author = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public bool CheckedIn
        {
            get { return checkedIn; }
            set { checkedIn = value; }
        }
        public DateTime DueDate
        {
            get { return dueDate; }
            set { dueDate = value; }
        }

        public virtual int ReturnNumberOfPages()
        {
            int numberOfPages = 0;
            return numberOfPages;
        }

        public virtual string ReturnDuration()
        {
            string duration = "";
            return duration;
        }

        public virtual string ReturnRunTime()
        {
            string runTime = "";
            return runTime;
        }
        public Item()
        {

        }
        public Item(string mediaType, string title, string author, string description, bool checkedIn, DateTime dueDate)
        {
            this.mediaType = mediaType;
            this.title = title;
            this.author = author;
            this.description = description;
            this.checkedIn = checkedIn;
            this.dueDate = dueDate;
        }
    }
}


