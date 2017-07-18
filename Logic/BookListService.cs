using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class BookListService : IEnumerable<Book>
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
            bookList = new List<Book>();
        }

        /// <summary>
        /// Ctor with parameters.
        /// </summary>
        /// <param name="bookList">List of Book instances.</param>
        public BookListService(List<Book> bookList)
        {
            this.bookList = bookList;
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
            if (bookList.Contains(book)) throw new ArgumentException($"{nameof(book)} exists.");
            bookList.Add(book);
        }

        /// <summary>
        /// Removes book from the collection.
        /// </summary>
        /// <param name="book">Book instance.</param>
        public void RemoveBook(Book book)
        {
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
            foreach (var b in bookList)
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
        public void SortBooksByTag(IComparer comparer)
        {
            Book temp = null;
            Book[] arr = bookList.ToArray();
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length-1; j++)
                {
                    if(comparer.Compare(arr[j], arr[j + 1]) > 0)
                    {
                        temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
            bookList.Clear();
            for (int i = 0; i < arr.Length; i++)
            {
                this.AddBook(arr[i]);
            }
        }
        #endregion

        #region deal with storage
        /// <summary>
        /// Saves list of books to storage.
        /// </summary>
        /// <param name="storage">Storage to saving.</param>
        public void SaveToStorage(IBookStorage storage) 
        {
            storage.WriteToStorage(bookList);
        }

        /// <summary>
        /// Loads list of books from storage.
        /// </summary>
        /// <param name="storage">Storage to loading.</param>
        public void LoadFromStorage(IBookStorage storage) 
        {
            List<Book> bookList = storage.ReadFromStorage();
            foreach (Book b in bookList)
            {
                this.AddBook(b);
            }
        }
        #endregion

        #region enumerators
        /// <summary>
        /// Enumerator to iterate over the list.
        /// </summary>
        /// <returns>IEnumerator object.</returns>
        public IEnumerator<Book> GetEnumerator()
        {
            foreach(var book in bookList)
            {
                yield return book;
            }
        }

        /// <summary>
        /// Enumerator to iterate over the list.
        /// </summary>
        /// <returns>IEnumerator object.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion

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


    }
}
