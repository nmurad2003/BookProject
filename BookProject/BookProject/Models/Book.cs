namespace BookProject.Models
{
    /*
    Book class
    - Id
    - Name
    - AuthorName
    - Price
    - ShowInfo()
    - ToString() - methodu override edilsin kitabın məlumatlarını geri döndürsün.
    */

    internal class Book
    {
        // Fields
        private static int _id = 0;
        private string _name;
        private string _authorName;
        private float _price;

        // Properties
        public int Id { get; }
        public string Name
        {
            get => _name;
            set
            {
                if (value == "" || value.Length < 3)
                    throw new FormatException("Invalid book name!");
                else _name = value;
            }
        }
        public string AuthorName
        {
            get => _authorName;
            set
            {
                if (value == "" || value.Length < 3)
                    throw new FormatException("Invalid author name!");
                else _authorName = value;
            }
        }
        public float Price
        {
            get => _price; set
            {
                if (value <= 0)
                    throw new FormatException("Price cannot be negative or zero!");
                _price = value;
            }
        }

        // Constructor
        public Book(string name, string authorName, float price)
        {
            Id = ++_id;
            Name = name;
            AuthorName = authorName;
            Price = price;
        }

        // Methods
        public override string ToString()
        {
            return $"{Id}. {Name} by {AuthorName} | {Price}$";
        }
        public void ShowInfo()
        {
            Console.WriteLine(this);
        }
    }
}
