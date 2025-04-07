using BookProject.Exceptions;
using BookProject.Models;

namespace BookProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            Menu
            1. Add book
            2. Get book by id
            3. Remove book
            0. Quit
            */

            Library lib = new Library("Murad Library", []);
            lib.AddBook(new Book("The Alchemist", "Paulo Coelho", 15.99f));
            lib.AddBook(new Book("Mein Kampf", "Hitler", 15.99f));

            string shortcut = "";

            while (shortcut != "0")
            {
                Console.WriteLine("=======================");
                Console.WriteLine("MENU");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Get Book by Id");
                Console.WriteLine("3. Search Books by Name");
                Console.WriteLine("4. Remove Book");
                Console.WriteLine("5. Show All Books");
                Console.WriteLine("0. Quit");

                shortcut = Console.ReadLine();
                Console.Clear();

                switch (shortcut)
                {
                    case "1":
                        {
                            try
                            {
                                Console.WriteLine("Enter book name:");
                                string bookName = Console.ReadLine();
                                Console.WriteLine("Enter author name:");
                                string authorName = Console.ReadLine();
                                Console.WriteLine("Enter price:");
                                float price = Convert.ToSingle(Console.ReadLine());

                                Book newBook = new Book(bookName, authorName, price);
                                lib.AddBook(newBook);
                            }
                            catch (FormatException ex) { Console.WriteLine(ex.Message); }
                            break;
                        }
                    case "2":
                        {
                            try
                            {
                                Console.WriteLine("Enter id:");
                                int id = int.Parse(Console.ReadLine());
                                Book searchedBook = lib.GetBookId(id);
                                searchedBook.ShowInfo();
                            }
                            catch (FormatException) { Console.WriteLine("Id needs to be positive integer!"); }
                            catch (BookNotFoundException) { Console.WriteLine("There is no book with this id!"); }
                            break;
                        }
                    case "3":
                        Console.WriteLine("Enter name:");
                        string searchedName = Console.ReadLine();
                        Book[] foundBooks = lib.SearchBookByName(searchedName);
                        foreach (Book book in foundBooks) 
                            Console.WriteLine(book);
                        break;
                    case "4":
                        {
                            try
                            {
                                Console.WriteLine("Enter id:");
                                int id = int.Parse(Console.ReadLine());
                                lib.RemoveBook(id);
                            }
                            catch (FormatException) { Console.WriteLine("Id needs to be positive integer!"); }
                            catch (BookNotFoundException) { Console.WriteLine("There is no book with this id!"); }
                            break;
                        }
                    case "5": Console.WriteLine(lib); break;
                    case "0": return;
                    default: Console.WriteLine("Invalid shortcut! Try again..."); break;
                }
            }
        }
    }
}
