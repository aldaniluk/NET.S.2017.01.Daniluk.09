using Logic.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class BookListService
    {
        #region private fields
        private List<Book> bookList;
        #endregion

        #region ctors
        /// <summary>
        /// Ctor without parameters.
        /// </summary>
        public BookListService()
        {
            ILogService logger = new NLogService();
            bookList = new List<Book>();
            logger.InfoWriteToLog(DateTime.Now, "creating BookListService instance", "BookListService instance was created.");
        }

        /// <summary>
        /// Ctor with parameters.
        /// </summary>
        /// <param name="bookList">List of Book instances.</param>
        public BookListService(IEnumerable<Book> bookList)
        {
            ILogService logger = new NLogService();
            if (ReferenceEquals(bookList, null)) throw new ArgumentException($"{nameof(bookList)} is null.");

            foreach (Book b in bookList)
            {
                this.AddBook(b);
            }
            logger.InfoWriteToLog(DateTime.Now, "creating BookListService instance", "BookListService instance was created.");
        }
        #endregion

        #region public methods

        #region manipulation with list (add, remove, find, sort)
        /// <summary>
        /// Adds book to the collection.
        /// </summary>
        /// <param name="book">Book instance.</param>
        public void AddBook(Book book)
        {
            if (ReferenceEquals(book, null)) throw new ArgumentException($"{nameof(book)} is null.");
            if (bookList.Contains(book)) throw new ArgumentException($"{nameof(book)} exists.");
            bookList.Add(book);
        }

        /// <summary>
        /// Removes book from the collection.
        /// </summary>
        /// <param name="book">Book instance.</param>
        public void RemoveBook(Book book)
        {
            if (ReferenceEquals(book, null)) throw new ArgumentException($"{nameof(book)} is null.");
            if (!bookList.Contains(book)) throw new ArgumentException($"{nameof(book)} does not exist.");
            bookList.Remove(book);
        }

        /// <summary>
        /// Finds book by given criteria.
        /// </summary>
        /// <param name="finder">Criteria for finding.</param>
        /// <returns>Book, if it found, and null otherwise.</returns>
        public Book FindBookByTag(IFinder finder) 
        {
            if (ReferenceEquals(finder, null)) throw new ArgumentException($"{nameof(finder)} is null.");
            foreach (Book b in bookList)
            {
                if (finder.Find(b))
                    return b;
            }
            return null;
        }

        /// <summary>
        /// Sorts list of books by given criteria.
        /// </summary>
        /// <param name="comparer">Criteria for sorting.</param>
        public void SortBooksByTag(IComparer<Book> comparer)
        {
            if (ReferenceEquals(comparer, null)) throw new ArgumentException($"{nameof(comparer)} is null.");
            this.bookList.Sort(comparer);
        }
        #endregion

        #region deal with storage
        /// <summary>
        /// Saves list of books to storage.
        /// </summary>
        /// <param name="storage">Storage to saving.</param>
        public void SaveToStorage(IBookStorage storage) 
        {
            if (ReferenceEquals(storage, null)) throw new ArgumentException($"{nameof(storage)} is null.");
            storage.WriteToStorage(bookList);
        }

        /// <summary>
        /// Loads list of books from storage.
        /// </summary>
        /// <param name="storage">Storage to loading.</param>
        public void LoadFromStorage(IBookStorage storage) 
        {
            if (ReferenceEquals(storage, null)) throw new ArgumentException($"{nameof(storage)} is null.");

            IEnumerable<Book> bookList = storage.ReadFromStorage();
            foreach (Book b in bookList)
            {
                this.AddBook(b);
            }
        }
        #endregion

        #region tostring
        /// <summary>
        /// Returns string representation of an object.
        /// </summary>
        /// <returns>String representation of an object.</returns>
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append("---Books---\n");
            foreach(Book b in bookList)
            {
                str.Append(b);
                str.Append('\n');
            }
            str.Append("-----------");
            return str.ToString();
        }
        #endregion

        #endregion


    }
}
