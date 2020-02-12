using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library_Mid_Term_Project
{
    class ValidatorClass
    {
        public string GetUserInput(string response)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(response);
            string userInput = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.ResetColor();
            return userInput;
        }


        public int GetValidInput(string input, int min, int max)

        {
            ValidatorClass session = new ValidatorClass();
            try
            {
                int selection = int.Parse(input);
                if (selection >= min && selection <= max)

                {
                    return selection;
                }
                else
                {
                    return GetValidInput(session.GetUserInput($"Please enter an option between {min} - {max}: "), min, max);
                }
            }
            catch (FormatException)
            {
                return GetValidInput(session.GetUserInput($"Please enter an option of {min} - {max}: "), min, max);
            }
        }

        public int GetValidNumber(string input, int max)

        {
            while (true)
            {
                int option;
                //decided to use a try catch here because to make sure input it a number and to change what our max,
                //it is listed above in this class. 
                try
                {
                    Console.Write(input);
                    option = int.Parse(Console.ReadLine());
                    if (option >= 0 && option <= max)
                    {
                        option = -1;
                    }
                    return option;
                }
                catch
                {

                }
            }
        }

        

        public void SearchByTitle(List<Item> items, string userInput)
        {
            foreach(var item in items)
            {
                if (item.Title.Contains(userInput))
                {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine();
                        Console.WriteLine($"TITLE: {item.Title}");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"AUTHOR: {item.Author}\nDESCRIPTION: {item.Description}");
                        Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
        public void SearchByAuthor(List<Item> items, string userInput)
        {
            foreach (var item in items)
            {
                if (item.Author.Contains(userInput))
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine();
                    Console.WriteLine($"TITLE: {item.Title}");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"AUTHOR: {item.Author}\nDESCRIPTION: {item.Description}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }

    }
}