using System;

namespace Logic.Finders
{
    public class FindByName : IFinder
    {
        private string name;

        /// <summary>
        /// Ctor for FindByName instance.
        /// </summary>
        /// <param name="name">Book name.</param>
        public FindByName(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException($"{nameof(name)} is null or empty.");
            this.name = name;
        }

        /// <summary>
        /// Compares given book's name with given name.
        /// </summary>
        /// <param name="book">Given book to compare.</param>
        /// <returns>True, if book's name and given name are equal, and false otherwise.</returns>
        public bool Find(Book book)
        {
            if (ReferenceEquals(book, null)) throw new ArgumentNullException($"{nameof(book)} is null.");
            return book.Name == name;
        }
    }
}
