using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Logic
{
    public class BookBinarySerializatorStorage : IBookStorage
    {
        #region properties
        /// <summary>
        /// Path to file.
        /// </summary>
        public string Path { get; }
        #endregion

        #region Ctors
        /// <summary>
        /// Ctor for BookBinarySerializatorStorage instance.
        /// </summary>
        /// <param name="path">Path to file.</param>
        public BookBinarySerializatorStorage(string path)
        {
            CheckPath(path);
            Path = path;
        }
        #endregion

        #region public methods
        /// <summary>
        /// Reads info about books from file.
        /// </summary>
        /// <returns>List of Book instances, read from the file.</returns>
        public IEnumerable<Book> ReadFromStorage()
        {
            List<Book> bookList = new List<Book>();

            IFormatter formatter = new BinaryFormatter();
            using (Stream s = File.Open(Path, FileMode.Open))
            {
                bookList = (List<Book>)formatter.Deserialize(s);
            }

            return bookList;
        }

        /// <summary>
        /// Writes books to file.
        /// </summary>
        /// <param name="bookList">List of Book to write to file.</param>
        public void WriteToStorage(IEnumerable<Book> bookList)
        {
            IFormatter formatter = new BinaryFormatter();
            using (Stream s = File.Open(Path, FileMode.Open))
            {
                formatter.Serialize(s, bookList);
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
