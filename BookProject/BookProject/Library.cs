using BookProject.Exceptions;
using BookProject.Models;

namespace BookProject
{
    /*
    Library class
    - Name
    - Books array
    - AddBook() - book obyekti qəbul edəcək və books array-ına əlavə edəcək
    - GetBookById() - id qebul edəcek və həmin id-li book obyektini tapıb geriyə qaytaracaq
    - RemoveBook() - id qebul edəcək və həmin id-li book obyektini tapıb siləcək.
    - GetBook() - string name qəbul edir. O adlı bütün kitabları geriyə qaytaracaq.
    - GetAllBooks() method bütün kitabları Console-a yazsın.
    */

    internal class Library
    {
        private string _name;
        private Book[] _books;

        // Properties
        public string Name { get; set; }
        public Book[] Books { get => _books; set { _books = value; } }

        // Constructor
        public Library(string name, Book[] books)
        {
            Name = name;
            Books = books;
        }

        // Methdods
        public void AddBook(Book book)
        {
            Array.Resize(ref _books, Books.Length + 1);
            Books[^1] = book;
        }

        public Book GetBookId(int id)
        {
            foreach (var book in _books)
            {
                if (book.Id == id) return book;
            }

            throw new BookNotFoundException();
        }

        public void RemoveBook(int id)
        {
            Book[] newArr = new Book[Books.Length-1];
            int index = 0;
            bool haveFound = false;

            foreach (var book in _books)
            {
                if (book.Id == id)
                {
                    haveFound = true;
                    continue;
                }
                newArr[index++] = book;
            }

            if (haveFound)
                throw new BookNotFoundException();
        }

        public Book[] SearchBookByName(string name)
        {
            Book[] foundBooks = [];

            foreach (Book book in Books)
            {
                if (book.Name.Contains(name))
                {
                    Array.Resize(ref foundBooks, foundBooks.Length + 1);
                    foundBooks[^1] = book;
                }
            }

            return foundBooks;
        }

        public void GetAllBooks()
        {
            foreach (Book book in Books) { Console.WriteLine(book); }
        }
    }
}
