using System;
using System.Collections.Generic;

namespace Logic
{
    public interface IBookStorage
    {
        /// <summary>
        /// Reads info from storage.
        /// </summary>
        /// <returns>Collection of objects.</returns>
        IEnumerable<Book> ReadFromStorage();

        /// <summary>
        /// Writes info to storage.
        /// </summary>
        /// <param name="bookList">Collection of objects.</param>
        void WriteToStorage(IEnumerable<Book> bookList);
    }
}
