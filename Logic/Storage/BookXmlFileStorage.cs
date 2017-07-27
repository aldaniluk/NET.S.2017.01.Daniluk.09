using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Logic
{
    public class BookXmlFileStorage : IBookStorage // TOOOOOOODOOOOOOOOO
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
            string name = null, author = null;
            int year = 0, pages = 0;
            using (XmlReader reader = XmlReader.Create(Path))
            {
                reader.ReadToFollowing("Book");
                string element = "";
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        element = reader.Name;

                        if (element == "Book") bookList.Add(new Book(name, author, year, pages));
                    }
                    else if (reader.NodeType == XmlNodeType.Text)
                    {
                        switch (element)
                        {
                            case "Name":
                                name = reader.Value;
                                break;
                            case "Author":
                                author = reader.Value;
                                break;
                            case "Year":
                                year = int.Parse(reader.Value);
                                break;
                            case "Pages":
                                pages = int.Parse(reader.Value);
                                break;
                        }
                    }
                }
                bookList.Add(new Book(name, author, year, pages));
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
            using (XmlWriter writer = XmlWriter.Create(Path))
            {
                writer.WriteStartElement("Books");

                foreach (Book b in bookList)
                {
                    writer.WriteStartElement("Book");
                    writer.WriteElementString("Name", b.Name);
                    writer.WriteElementString("Author", b.Author);
                    writer.WriteElementString("Year", b.Year.ToString());
                    writer.WriteElementString("Pages", b.Pages.ToString());
                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
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
