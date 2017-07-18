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
            this.name = name;
        }

        /// <summary>
        /// Compares given book's name with given name.
        /// </summary>
        /// <param name="book">Given book to compare.</param>
        /// <returns>True, if book's name and given name are equal, and false otherwise.</returns>
        public bool Find(Book book)
        {
            return book.Name == name;
        }
    }
}
