namespace lesson
{
    public class Program
    {
        /// <summary>
        /// The main entrypoint of your application.
        /// </summary>
        /// <param name="args">The arguments passed to the program</param>
        public static void Main(string[] args)
        {

            Book[] books = new Book[]
            {
                new Book("Signore degli Anelli", "J.R.R. Tolkien", 1954, "Sinossi 1"),
                new Book("Dracula", "Bram Stoker", 1897, "Sinossi 2")
            };

            Library library = new Library(books);
            Library library2 = new Library(books);
            Library[] libraries = {library, library2};

            Console.WriteLine(library.ToString());

            Console.WriteLine(library.BooksOfAuthor("Bram Stoker"));
            Console.WriteLine(Library.BooksOfAuthor(libraries, "Bram Stoker"));

            Console.WriteLine(library.BooksPublishedBetween(1895, 1955));
            Console.WriteLine(Library.BooksPublishedBetween(libraries,1895, 1955));


        }
    }
}
