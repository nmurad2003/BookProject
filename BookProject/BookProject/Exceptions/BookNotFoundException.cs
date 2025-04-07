namespace BookProject.Exceptions
{
    internal class BookNotFoundException : Exception
    {
        public BookNotFoundException(string message = "Book Not Found!") : base(message) { }
    }
}
