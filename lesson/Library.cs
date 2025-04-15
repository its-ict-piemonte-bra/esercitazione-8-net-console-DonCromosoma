
using System.Diagnostics.Contracts;

namespace lesson
{

   
    /// <summary>
    /// Rappresenta a single book
    /// </summary>
    internal class Book 
    {
        /// <summary>
        /// The book full name, including the edition
        /// </summary>
        public string Name;
        /// <summary>
        /// The author full name
        /// </summary>
        public string Author;
        /// <summary>
        /// The year of publication of the book.
        /// </summary>
        public int PublicationYear;
        /// <summary>
        /// A brief synopsis of the book
        /// </summary>
        public string Synopsis;
        /// <summary>
        /// The genres of the book
        /// </summary>
        public string[] Genres;

        /// <summary>
        /// Creates a new istance of a book
        /// </summary>
        /// <param name="Name">The book full name, including the edition</param>
        /// <param name="Author">The author full name</param>
        /// <param name="PublicationYear">The year of publication of the book.</param>
        /// <param name="Synopsis">A brief synopsis of the book</param>
        public Book(string Name, string Author, int PublicationYear, string Synopsis, string[] Genres) 
        {

            // Quando prendiamo dei parametri in una qualsiasi funzione/metodo, vale il
            // principio della programmazione paranoica (dobbiamo controllare tutti i parametri
            // in ingresso e lanciare eccezioni qualora non siano validi).

            if (Name == null || Name == "")
            {
                throw new ArgumentNullException("Il nome del libro non può essere vuoto");
            }
            else if (Author == null || Author == "")
            {
                throw new ArgumentNullException("Il nome dell'autore non può essere vuoto");
            }
            else if (Synopsis == null || Synopsis == "")
            {
                throw new ArgumentNullException("La sinossi non può essere vuota");
            }
            else if (Synopsis.Length > 200) 
            {
                throw new ArgumentException("La sinossi è troppo lunga (max 200 caratteri)");
            }
            else if(Genres == null) 
            {
                throw new ArgumentException("Devi inserire il genere del libro");
            }

            // passate tutte le guardie, è tutto ok
            this.Name = Name;
            this.Author = Author;
            this.PublicationYear = PublicationYear;
            this.Synopsis = Synopsis;
            this.Genres = Genres;
        }
    }

    /// <summary>
    /// This class allows to handle a library. 
    /// This includes common operations uch as booking and
    /// stocking book inventory.
    /// </summary>
    internal class Library
    {
        
        Book[] books;


        public Library() 
        {
            this.books = new Book[0];
        }






        /// <summary>
        /// Create a new istance of Library,
        /// with the specified book inventory.
        /// </summary>
        /// <param name="books">The book to add to the library</param>
        /// <exception cref="ArgumentNullException">If a null book array is passed</exception>
        public Library(Book[] books) 
        {
            //Metodo costruttore (in overload): questo secondo costruttore ha le stesse caratteristiche e prorpietà del primo, e può
            //sostituirlo qualora ce ne fosse la necessità.
            //(ad esempio per inizializzare direttamente i libri in inventario).
            //
            //Essendo basato su parametri, essi vanno controllati e in caso
            //di errore, occorre lanciare delle eccezioni.
            if (books == null) 
            {
                throw new ArgumentNullException("Non si può passare un array nullo di oggetti Book");
            }
            this.books = books;

        }





        /// <summary>
        /// Returns the book in the library
        /// </summary>
        /// <returns>
        /// The book count
        /// </returns>
        public int BookCount() 
        {
            //metodo di istanza(è presente il tris)
            //
            //Il this rappresenta "l'oggetto su cui è stato richiamato il metodo"
            //
            //Ad esempio se io facessi
            //
            //var prova new Library();
            //Console.WriteLine(prova.BookCount());
            //
            //Il "this" si riferirebbe a "prova"
            //
            //questo metodo in particolare si chiama
            //anche "metodo accessorio"
            return this.books.Length;
        }



        /// <summary>
        /// Returns the number of books of a particular author
        /// </summary>
        /// <param name="author">The author to search books for</param>
        /// <returns>The count of the books made by tha author</returns>
        public int BooksOfAuthor(string author)
        {
            
            if (author == null || author == "") 
            {
                throw new ArgumentNullException("Non si può passare un Autore di valore nullo");
            }

            
            int count= 0;

            for (int i = 0; i < this.books.Length; i++) 
            {
                if (author== this.books[i].Author) 
                {
                    count++;
                }
            }

            return count;
        }


        /// <summary>
        /// Returns the number of books of a particular author
        /// </summary>
        /// <param name="libraries">The libraries </param>
        /// <param name="author">The author to search books for</param>
        /// <returns>The count of the books made by tha author</returns>
        public static int BooksOfAuthor(Library[] libraries, string author)
        {

            if (libraries== null)
            {
                throw new ArgumentNullException("Non si può passare un Autore di valore nullo");
            }
            else if (author == null || author == "")
            {
                throw new ArgumentNullException("Non si può passare un Autore di valore nullo");
            }


            int count = 0;

            foreach (Library currentLibrary in libraries) 
            {
                count+= currentLibrary.BooksOfAuthor(author);
            }

            return count;
        }


        public int BooksPublishedBetween(int yearFrom, int yearTo) 
        {
            int count = 0;



            if (yearFrom == null || yearTo == null) 
            {
                throw new ArgumentNullException("Non si può procedere con valori NULLI");
            }
            if (yearTo < yearFrom) 
            {
                int temp= yearTo;
                yearTo = yearFrom;
                yearFrom = temp;
            }

            foreach (Book currentBook in this.books) 
            {
                if (currentBook.PublicationYear >= yearFrom && currentBook.PublicationYear <= yearTo) 
                {
                    count++;
                }
            }

            return count;
        }



        public static int BooksPublishedBetween(Library[] libraries ,int yearFrom, int yearTo)
        {
            int count = 0;


            if (libraries == null)
            {
                throw new ArgumentNullException("Non si può passare una Libreria di valore nullo");
            }

            if (yearTo < yearFrom)
            {
                int temp = yearTo;
                yearTo = yearFrom;
                yearFrom = temp;
            }

            foreach (Library currentLibrary in libraries)
            {
                    count+= currentLibrary.BooksPublishedBetween(yearFrom, yearTo);
            }

            return count;
        }


        /// <summary>
        /// Returns the number of books of a particular genre
        /// </summary>
        /// <param name="genre">The book genre</param>
        /// <returns>The count of books of a particular genre</returns>
        public int BooksOfGenre(string genre)
        {
            int count = 0;
            if (genre == null)
            {
                throw new ArgumentNullException("Impossibile procedere senza il genere del libro");
            }

            foreach (Book currentbooks in this.books)
            {
                foreach (string currentGenres in currentbooks.Genres ) 
                {
                    if (currentGenres == genre) 
                    {
                        count++;
                        break;
                    }   
                }
            }

            return count;
        }

        /// <summary>
        /// Returns the number of books of a particular genre, in the provided libraries
        /// </summary>
        /// <param name="libraries">The libraries in which to search</param>
        /// <param name="genre">The book genre</param>
        /// <returns>The count of books of a particular genre</returns>
        public static int BooksOfGenre(Library[] libraries, string genre)
        {
            int count = 0;
            if (libraries== null) 
            {
                throw new ArgumentNullException("Impossibile procedere con una libreria vuota");
            }
            else if (genre == null)
            {
                throw new ArgumentNullException("Impossibile procedere senza il genere del libro");
            }

            foreach (Library currentLibrary in libraries)
            {
                count += currentLibrary.BooksOfGenre(genre);
            }
            return count;
        }


        /// <summary>
        /// Stampo i libri
        /// </summary>
        /// <returns>Ritorno la stampa dei libri</returns>
        public override string ToString()
        {
            string temp = "";

            // Libro[0]
            // - "Signore degli Anelli", "J.R.R Tolkien" (1954)
            //   Sinossi:
            //   hgfdgfidgfiajifajh
            // Libro[1]
            // - "Dracula", "Bram Stoker" (1897)
            //   Sinossi:
            //   bakjsbdkjasdbkjb

            for (int i = 0; i < this.books.Length; i++) 
            {
                temp += ($"\nLibro[{i}]\n")+
                 ($" - \"{this.books[i].Name}\", \"{this.books[i].Author}\" ({this.books[i].PublicationYear})\n")+
                 ($"   Sinossi:\n   {this.books[i].Synopsis}");
            }
            return temp;
        }


    }
}
