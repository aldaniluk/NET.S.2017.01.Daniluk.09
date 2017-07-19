using System;
using System.Collections.Generic;

namespace Logic
{
    public interface IFinder
    {
        /// <summary>
        /// Checks book for a given criteria.
        /// </summary>
        /// <param name="book">Book to check.</param>
        /// <returns>True, if book is appropriate, and false otherwise.</returns>
        bool Find(Book book);
    }
}
