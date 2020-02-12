using System;
using System.Collections.Generic;
using System.Text;

namespace Library_Mid_Term_Project
{
    class CD : Item
    {
        private string length;
        //properties
        public string Length { get; set; }

        public CD(string mediaType, string title, string author, string description, bool checkedIn, DateTime dueDate, string Length) : base(mediaType, title, author, description, checkedIn, dueDate)
        {
            this.Length = Length;
        }
    }
}
