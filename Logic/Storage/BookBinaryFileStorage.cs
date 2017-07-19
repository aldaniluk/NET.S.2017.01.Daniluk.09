using System;
using System.Collections.Generic;
using System.IO;

namespace Logic
{
    public class BookBinaryFileStorage : IBookStorage
    {
        #region properties
        /// <summary>
        /// Path to file.
        /// </summary>
        public string Path { get; }
        #endregion

        #region Ctors
        /// <summary>
        /// Ctor for BookBinaryFileStorage instance.
        /// </summary>
        /// <param name="path">Path to file.</param>
        public BookBinaryFileStorage(string path)
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
            string name, author;
            int year, pages;

            using (BinaryReader reader = new BinaryReader(File.Open(Path, FileMode.Open)))
            {
                while (reader.PeekChar() > -1)
                {
                    name = reader.ReadString();
                    author = reader.ReadString();
                    year = reader.ReadInt32();
                    pages = reader.ReadInt32();

                    bookList.Add(new Book(name, author, year, pages));
                }
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

            using (BinaryWriter writer = new BinaryWriter(File.Open(Path, FileMode.OpenOrCreate)))
            {
                foreach (Book b in bookList)
                {
                    writer.Write(b.Name);
                    writer.Write(b.Author);
                    writer.Write(b.Year);
                    writer.Write(b.Pages);
                }
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
