using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandBox
{
    class Program
    {
        static void Main()
        {
			// Book list, only titles

			List<string> bookTitles = new List<string>();
			string[] titles = { "Magik", "Królestwo", "Morfina", "Czarne oceany", "Nocne zwierzęta", "Lód", "Dukla", "Taksim", "Ajol", "Trociny", "Zima", "Portrecista psów", "Roztopy", "Odwrócone światło", "Wampir", "Przejęcie" };
			bookTitles.AddRange(titles);

			Console.WriteLine("All books: \n");
			foreach (string b in bookTitles)
				Console.WriteLine(b);
			Console.WriteLine("Book index: {0}", bookTitles.BinarySearch("Morfina"));


			// List of books

			List<Book> books = new List<Book>()
			{
				new Book() { BookId = 1, BookTitle = "Magik", BookAuthor = "Magdalena Parys", BookPages = 618 },
				new Book() { BookId = 2, BookTitle = "Czarne oceany", BookAuthor = "Jacek Dukaj", BookPages = 486 },
				new Book() { BookId = 3, BookTitle = "Morfina", BookAuthor = "Szczepan Twardoch", BookPages = 579 },
				new Book() { BookId = 4, BookTitle = "Wampir", BookAuthor = "Wojciech Chmielarz", BookPages = 321 },
				new Book() { BookId = 5, BookTitle = "Król", BookAuthor = "Szczepan Twardoch", BookPages = 429 },
				new Book() { BookId = 6, BookTitle = "Królestwo", BookAuthor = "Jo Nesbo", BookPages = 488 }
			};

			// Query 01 
			var krol = books.Where(b => b.BookTitle.Contains("Król"))
							.Select(b => b.BookTitle);

			Console.WriteLine("Books containing 'Król' in the title:");
            foreach (var res in krol)
            {
				Console.WriteLine(res);
			}

			// Query 02 
			var pages = from b in books
						where b.BookPages > 480
						orderby b.BookPages
						select b.BookTitle;

			Console.WriteLine("Books that have over 480 pages:");
			
			foreach (var res in pages)
			{
				Console.WriteLine(res);
			}

			// Query 03

			var author = from a in books
						 where a.BookAuthor.Contains("Szczepan")
						 select new { bookTitle = a.BookTitle };

			Console.WriteLine("Books written by Szczepan");
			author.ToList().ForEach(a => Console.WriteLine(a.bookTitle));




			Console.ReadKey();
		}

        public class Book
        {
			public int BookId;
			public string BookTitle;
			public string BookAuthor;
			public int BookPages;
        }
    }
}
