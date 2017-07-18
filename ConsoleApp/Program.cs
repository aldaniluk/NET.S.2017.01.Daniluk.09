using System;
using Logic;
using Logic.Comparers;
using Logic.Finders;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Book b1 = new Book("Crane's Cry", "Bykau Vasil", 1960, 55);
            Book b2 = new Book("CLR via C#, Fourth Edition", "Richter Jeffrey", 2012, 896);
            Book b3 = new Book("Martin Eden", "London Jack", 1909, 329);
            Book b4 = new Book("Harry Potter and the Philosopher's Stone", "Rowling Joanne", 1997, 336);
            Book b5 = new Book("Alice's Adventures in Wonderland", "Carroll Lewis", 1865, 80);
            Book b6 = new Book("The Alpine Ballad", "Bykau Vasil", 1964, 124);
            Book b7 = new Book("The Alpine Ballad", "Bykau Vasil", 1964, 124);

            Console.WriteLine(Book.Compare(b1, b2, new PagesComparer())); //-1
            Console.WriteLine(Book.Compare(b1, b2, new YearComparer())); //1
            Console.WriteLine(Book.Compare(b1, b2, new AuthorComparer())); //1
            Console.WriteLine(Book.Compare(b1, b2, new NameComparer())); //-1

            Console.WriteLine(b5.Equals(b7)); //false
            Console.WriteLine(b6.Equals(b6)); //true
            Console.WriteLine(b6.Equals(b7)); //true

            Console.WriteLine("SERVICE: add book, remove book");
            BookListService service = new BookListService();
            service.AddBook(b1); //added
            service.AddBook(b2); //added
            service.AddBook(b3); //added
            service.AddBook(b4); //added
            service.AddBook(b6); //added
            //service.AddBook(b7); //exception; the same book b6 exists
            service.RemoveBook(b1); //removed
            //service.RemoveBook(b5); //exception; the book does not exist
            Console.WriteLine(service);

            Console.WriteLine("FIND BOOK by author, name, author and year");
            Console.WriteLine(service.FindBookByTag(new FindByName("Martin Eden")));
            Console.WriteLine(service.FindBookByTag(new FindByAuthor("Jack London")));
            Console.WriteLine(service.FindBookByTag(new FindByAuthorAndYear("Vasil Bykau", 1964)));

            Console.WriteLine("SORTS by name, author, year, quantity of pages");
            service.SortBooksByTag(new NameComparer());
            Console.WriteLine(service);
            service.SortBooksByTag(new AuthorComparer());
            Console.WriteLine(service);
            service.SortBooksByTag(new YearComparer());
            Console.WriteLine(service);
            service.SortBooksByTag(new PagesComparer());
            Console.WriteLine(service);

            Console.WriteLine("Write to file");
            BookBinaryFileStorage binaryStorage = new BookBinaryFileStorage(@"..\..\Books.txt");
            service.SaveToStorage(binaryStorage);

            Console.WriteLine("Read from file");
            BookListService newService = new BookListService();
            newService.LoadFromStorage(binaryStorage);
            Console.WriteLine(newService);


        }
    }
}
