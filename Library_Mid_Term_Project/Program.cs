using System;
using System.Collections.Generic;
using System.IO;

namespace Library_Mid_Term_Project
{
    class Program
    {
        static void Main(string[] args)
        {

            ValidatorClass validation = new ValidatorClass();
            LibraryApp session = new LibraryApp();
            session.StartLibrary();

        }
    }
}