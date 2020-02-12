using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Library_Mid_Term_Project
{
    class LibraryApp
    {
        // read in the text file to a list... somewhere... probably at the top, just once. 
        // Maybe inside of StartLibrary() or PrintMainMenu(). 
        // We'll READ the file when prepare to display a list of all the Books/Items, but again, just once, near the top of the program. We don't need to read the file all over the place
        // We'll WRITE to the file when a user checks in, or checks out a Book/Item

        List<Item> libraryList = new List<Item>(); //<= GONNA NEED THIS ASAP
        private object authorlist;
        ValidatorClass session = new ValidatorClass();



        public void StartLibrary()
        {
            GetItems(libraryList);
            PrintMainMenu();
        }

        private void PrintMainMenu()
        {
            Console.WriteLine();
            bool validChoice = true;
            while (validChoice)
            {
                Console.WriteLine("Welcome to the Libarary!");
                Console.WriteLine("1. Show Library Collection\n2. Search for Item\n3. Check out item\n4. Check in item\n5. Exit");
                int userSelection = session.GetValidInput(session.GetUserInput("Please choose from an option above: "), 1, 5);
                Console.Clear();
                validChoice = false;

                switch (userSelection)
                {
                    case 1:
                        ListItems();
                        break;
                    case 2:
                        SearchForItem();
                        break;
                    case 3:
                        CheckOutItem();
                        break;
                    case 4:
                        CheckInItem();
                        break;
                    case 5:
                        ExitProgram();
                        break;
                    default:
                        validChoice = true;
                        Console.WriteLine("Please make a valid selection (1 - 4).");
                        break;
                }
            }
        }

        //Fields of abstract class string mediaType, string title, string author, string description, bool checkedIn, DateTime dueDat
        public List<Item> GetItems(List<Item> items)
        {
            StreamReader reader = new StreamReader("../../../ItemsInventory.txt");

            string line = reader.ReadLine();
            while (line != null)
            {
                string[] itemInfo = line.Split("|");
                if (itemInfo[0] == "Book")
                {
                    items.Add(new Book(itemInfo[0], itemInfo[1], itemInfo[2], itemInfo[3], bool.Parse(itemInfo[4]), DateTime.Parse(itemInfo[5]), int.Parse(itemInfo[6])));
                    line = reader.ReadLine();
                }

                //Adding if's for additional media types

                if (itemInfo[0] == "Movie")
                {
                    items.Add(new Movie(itemInfo[0], itemInfo[1], itemInfo[2], itemInfo[3], bool.Parse(itemInfo[4]), DateTime.Parse(itemInfo[5]), (itemInfo[6])));
                    line = reader.ReadLine();
                }

                if (itemInfo[0] == "Magazine")
                {
                    items.Add(new Magazine(itemInfo[0], itemInfo[1], itemInfo[2], itemInfo[3], bool.Parse(itemInfo[4]), DateTime.Parse(itemInfo[5]), int.Parse(itemInfo[6])));
                    line = reader.ReadLine();
                }

                if (itemInfo[0] == "CD")
                {
                    items.Add(new CD(itemInfo[0], itemInfo[1], itemInfo[2], (itemInfo[3]), bool.Parse(itemInfo[4]), DateTime.Parse(itemInfo[5]), (itemInfo[6])));
                    line = reader.ReadLine();
                }

            }
            reader.Close();

            return items;
        }

        public void ItemListToText(List<Item> items)
        {
            StreamWriter writer = new StreamWriter("../../../ItemsInventory.txt");

            // looks at the libraryList declared aaaaaallllll the way at the top, and iterates through them.
            // properties like CheckedIn or DueDate will be modified in the CheckIn/CheckOut method, and this method will write those changes ontop of the old .txt file
            // In other words: Run this method only AFTER the user has made changes

            for (int i = 0; i < libraryList.Count; i++)
            {
                //book
                if (items[i] is Book)
                {
                    //unboxing magic
                    Item item = items[i];
                    Book book = (Book)item;

                    writer.WriteLine($"{book.MediaType}|{book.Title}|{book.Author}|{book.Description}|{book.CheckedIn}|{book.DueDate}|{book.NumberOfPages}");
                }
                //CD
                else if (items[i] is CD)
                {
                    Item item = items[i];
                    CD cd = (CD)item;
                    writer.WriteLine($"{cd.MediaType}|{cd.Title}|{cd.Author}|{cd.Description}|{cd.CheckedIn}|{cd.DueDate}|{cd.Length}");
                }
                //magazine
                else if (items[i] is Magazine)
                {
                    Item item = items[i];
                    Magazine mag = (Magazine)item;
                    writer.WriteLine($"{mag.MediaType}|{mag.Title}|{mag.Author}|{mag.Description}|{mag.CheckedIn}|{mag.DueDate}|{mag.NumberOfPages}");
                }
                //movie 
                else if (items[i] is Movie)
                {
                    Item item = items[i];
                    Movie movie = (Movie)item;
                    writer.WriteLine($"{movie.MediaType}|{movie.Title}|{movie.Author}|{movie.Description}|{movie.CheckedIn}|{movie.DueDate}|{movie.Duration}");

                }

                //ADD OTHER IF ELSE FOR MOVIES,CDs, ETC.

            }
            writer.Close();
        }

        private void ListItems() //will need a 'List<Item> libraryList' parameter
        {
            int i = 1;
            Console.Clear();
            foreach (Item item in libraryList)
            {
                //go back and format this or, inside of the Item (or children) class, setup a DisplayItem(); method

                if (item is Book && !item.CheckedIn)
                {
                    Book b = (Book)item;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"{i} - TITLE: {item.Title}");

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"    AUTHOR: {item.Author}\n    NUMBER OF PAGES: {b.NumberOfPages}\n    DESCRIPTION: {item.Description}");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"     DUE DATE: {item.DueDate}");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("=============================================================================================================");
                }

                else if (item is Book && item.CheckedIn)
                {
                    Book b = (Book)item;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"{i} - TITLE: {item.Title}");

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"    AUTHOR: {item.Author}\n    NUMBER OF PAGES: {b.NumberOfPages}");
                    Console.WriteLine($"    Description: {item.Description}");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"    Available for CheckOut");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("=============================================================================================================");
                }

                if (item is Magazine && !item.CheckedIn)
                {
                    Magazine b = (Magazine)item;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"{i} - TITLE: {item.Title}");

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"    AUTHOR: {item.Author}\n    NUMBER OF PAGES: {b.NumberOfPages}\n    DESCRIPTION: {item.Description}");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"      DUE DATE: {item.DueDate}");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("=============================================================================================================");
                }

                else if (item is Magazine && item.CheckedIn)
                {
                    Magazine b = (Magazine)item;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"{i} - TITLE: {item.Title}");
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine($"    AUTHOR: {item.Author}\n    NUMBER OF PAGES: {b.NumberOfPages}");
                    Console.WriteLine($"    Description: {item.Description}");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"    Available for CheckOut");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("=============================================================================================================");
                }


                if (item is CD && !item.CheckedIn)
                {
                    CD b = (CD)item;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"{i} - TITLE: {item.Title}");

                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine($"    AUTHOR: {item.Author}\n    CD Length: {b.Length}\n    DESCRIPTION: {item.Description}");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"      DUE DATE: {item.DueDate}");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("=============================================================================================================");
                }

                else if (item is CD && item.CheckedIn)
                {
                    CD b = (CD)item;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"{i} - TITLE: {item.Title}");

                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine($"    AUTHOR: {item.Author}\n    CD Length: {b.Length}");
                    Console.WriteLine($"    Description: {item.Description}");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"    Available for CheckOut");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("=============================================================================================================");
                }

                if (item is Movie && !item.CheckedIn)
                {
                    Movie b = (Movie)item;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"{i} - TITLE: {item.Title}");

                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine($"    AUTHOR: {item.Author}\n    Movie Length: {b.Duration}\n    DESCRIPTION: {item.Description}");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"      DUE DATE: {item.DueDate}");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("=============================================================================================================");
                }

                else if (item is Movie && item.CheckedIn)
                {
                    Movie b = (Movie)item;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"{i} - TITLE: {item.Title}");

                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine($"    AUTHOR: {item.Author}\n    Movie Length: {b.Duration}");
                    Console.WriteLine($"    Description: {item.Description}");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"    Available for CheckOut");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("=============================================================================================================");
                }
                i++;
            }
            UserContinue();
        }

        //should allow user to see a list item based on a search for author or title
        private void SearchForItem() //will need a 'List<Item> libraryList' parameter
        {
            ValidatorClass session = new ValidatorClass();
            Console.WriteLine("Search by:\n     1. Author\n     2: Title\n     3. Return to Main Menu");
            int userInput = this.session.GetValidInput(this.session.GetUserInput("User Option: "), 1, 3);

            switch (userInput)
            {
                case 1:
                    string userAuthor = session.GetUserInput("Enter the name of the author: ");
                    session.SearchByAuthor(libraryList, userAuthor);
                    UserContinue();
                    break;
                case 2:
                    string userTitle = session.GetUserInput("Enter the name of the title: ");
                    session.SearchByTitle(libraryList, userTitle);
                    UserContinue();
                    break;

                case 3:
                    PrintMainMenu();
                    break;
            }
        }

        private void CheckOutItem() //will need a 'List<Item> libraryList' parameter
        {
            ValidatorClass session = new ValidatorClass();

            // probably print the list of items that checked in
            Console.WriteLine("\nHere's the list of currently available items:");
            int count = 1;
            Dictionary<int, string> tempDict = new Dictionary<int, string>();

            foreach (Item item in libraryList)
            {
                if (item.CheckedIn == true)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"{count}: {item.Title}");
                    Console.ResetColor();
                    tempDict.Add(count, item.Title);
                    count++;
                }
                
            }
            // asks user to select between 1 - i, where i is the current # of 'checked in' items in the list

            int choice = session.GetValidInput("\nWhich item would you like to check out?", 1, count - 1);
            bool gotValue = tempDict.TryGetValue(choice, out string title);
            foreach (var item in libraryList)
            {
                if (item.Title == title)
                {
                    item.CheckedIn = false;
                    SetItemDueDate(item);
                }
            }

            UserContinue();
        }

        private void CheckInItem() //will need a 'List<Item> libraryList' parameter
        {
            ValidatorClass session = new ValidatorClass();
            //do stuff

            // probably print the list of items that checked in
            Console.WriteLine("\nHere's the list of currently checked out items:");
            int count = 1;
            Dictionary<int, string> tempDict = new Dictionary<int, string>();

            foreach (Item item in libraryList)
            {
                if (item.CheckedIn == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{count}: {item.Title}");
                    Console.ResetColor();
                    tempDict.Add(count, item.Title);
                    count++;

                }

            }
            int choice = session.GetValidInput("\nWhich item would you like to check out?", 1, count - 1);
            bool gotValue = tempDict.TryGetValue(choice, out string title);
            foreach (var item in libraryList)
            {
                if (item.Title == title)
                {
                    item.CheckedIn = true;
                    SetItemDueDate(item);
                }
            }

            UserContinue();
        }
        private void UserContinue()

        {
            bool userContinue = true;
            while (userContinue)
            {
                Console.WriteLine();
                string userSelection = session.GetUserInput("Would you like to continue? (y/n): ");
                userContinue = false;

                switch (userSelection)
                {
                    case "y":
                        PrintMainMenu();
                        break;
                    case "n":
                        Console.WriteLine("Goodbye!");
                        ExitProgram();
                        break;
                    default:
                        Console.WriteLine("Please make a valid selection (y or n): ");
                        userContinue = true;
                        break;
                }
            }
        }

        private void ExitProgram()
        {
            ItemListToText(libraryList);
            Environment.Exit(0);

        }

        private void SetItemDueDate(Item item)
        {
            var now = DateTime.Now;
            var newDate = now.AddDays(14);
            item.DueDate = newDate;
        }
    }
}