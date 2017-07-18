using System;

namespace Logic.Finders
{
    public class FindByAuthorAndYear : IFinder
    {
        private string author;
        private int year;

        /// <summary>
        /// Ctor for FindByAuthorAndYear instance.
        /// </summary>
        /// <param name="author">Book author.</param>
        /// <param name="year">Book year to publishing.</param>
        public FindByAuthorAndYear(string author, int year)
        {
            if (string.IsNullOrEmpty(author)) throw new ArgumentNullException($"{nameof(author)} is null or empty.");
            this.author = author;
            this.year = year;
        }

        /// <summary>
        /// Compares given book's author and year with given author and year.
        /// </summary>
        /// <param name="book">Given book to compare.</param>
        /// <returns>True, if book's author and year and given author and year are equal, and false otherwise.</returns>
        public bool Find(Book book)
        {
            if (ReferenceEquals(book, null)) throw new ArgumentNullException($"{nameof(book)} is null.");
            return book.Author == author && book.Year == year;
        }
    }
}
