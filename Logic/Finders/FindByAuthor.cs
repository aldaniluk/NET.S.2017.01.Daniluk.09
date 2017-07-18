using System;

namespace Logic.Finders
{
    public class FindByAuthor : IFinder
    {
        private string author;

        /// <summary>
        /// Ctor for FindByAuthor instance.
        /// </summary>
        /// <param name="author">Book author.</param>
        public FindByAuthor(string author)
        {
            this.author = author;
        }

        /// <summary>
        /// Compares given book's author with given author.
        /// </summary>
        /// <param name="book">Given book to compare.</param>
        /// <returns>True, if book's author and given author are equal, and false otherwise.</returns>
        public bool Find(Book book)
        {
            return book.Author == author;
        }
    }
}
