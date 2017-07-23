using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Logic
{
    public class BookXmlFileStorage : IBookStorage
    {
        #region properties
        /// <summary>
        /// Path to file.
        /// </summary>
        public string Path { get; }
        #endregion

        #region Ctors
        /// <summary>
        /// Ctor for BookXmlFileStorage instance.
        /// </summary>
        /// <param name="path">Path to file.</param>
        public BookXmlFileStorage(string path)
        {
            CheckPath(path);
            Path = path;
        }
        #endregion

        #region public methods Read and Write
        /// <summary>
        /// Reads info about books from file.
        /// </summary>
        /// <returns>List of Book instances, read from the file.</returns>
        public IEnumerable<Book> ReadFromStorage()
        {
            List<Book> bookList = new List<Book>();

            XmlSerializer xs = new XmlSerializer(bookList.GetType());
            using (Stream s = File.Open(Path, FileMode.Open))
            {
                bookList = (List<Book>)xs.Deserialize(s);
            }

            return bookList;
        }

        /// <summary>
        /// Writes books to file.
        /// </summary>
        /// <param name="bookList">List of Book to write to file.</param>
        public void WriteToStorage(IEnumerable<Book> bookList)
        {
            if (ReferenceEquals(bookList, null)) throw new ArgumentNullException($"{nameof(bookList)} is null.");

            XmlSerializer xs = new XmlSerializer(typeof(List<Book>));

            using (Stream s = File.Open(Path, FileMode.Open))
            {
                xs.Serialize(s, bookList);   
            }
                
        }
        #endregion

        #region private methods
        private void CheckPath(string path)
        {
            if (string.IsNullOrEmpty(path)) throw new ArgumentNullException($"{nameof(path)} is null.");
            if (!File.Exists(path)) throw new ArgumentNullException($"{nameof(path)} does not exist.");
        }
        #endregion
    }
}
