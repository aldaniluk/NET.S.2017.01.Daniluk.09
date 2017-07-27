using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Logic
{
    [Serializable]
    [DataContract]
    public class Book : IEquatable<Book>, IComparable, IComparable<Book>
    {
        #region properties
        [DataMember]
        /// <summary>
        /// Book name.
        /// </summary>
        public string Name { get; /*private set;*/ }

        [DataMember]
        /// <summary>
        /// Book author.
        /// </summary>
        public string Author { get; /*private set;*/ }

        [DataMember]
        /// <summary>
        /// Year of publishing.
        /// </summary>
        public int Year { get; /*private set;*/ }

        [DataMember]
        /// <summary>
        /// Number of pages.
        /// </summary>
        public int Pages { get; /*private set;*/ }
        #endregion

        #region private static fields
        private static int MaxQuantityOfPages = 1000;
        private static int MinQuantityOfPages = 5;
        private static int EarliestYearOfPublishing = 1500;
        #endregion

        #region ctors
        public Book()
        {

        }
        /// <summary>
        /// Ctor for Book instance.
        /// </summary>
        /// <param name="name">Book name.</param>
        /// <param name="author">Book author.</param>
        /// <param name="year">Year of publishing.</param>
        /// <param name="pages">Number of pages.</param>
        public Book(string name, string author, int year, int pages)
        {
            if (CheckName(name)) Name = name;
            if (CheckAuthor(author)) Author = author;
            if (CheckYear(year)) Year = year;
            if (CheckPages(pages)) Pages = pages;
        }
        #endregion

        #region public static methods
        /// <summary>
        /// Compares two books by given criteria.
        /// </summary>
        /// <param name="lhs">One book to compare.</param>
        /// <param name="rhs">Another book to compare.</param>
        /// <param name="comparer">Criteria for comparison.</param>
        /// <returns>-1, if left book is less; 1, if greater; 0, if they are equal.</returns>
        public static int Compare(Book lhs, Book rhs, IComparer<Book> comparer)
        {
            if (ReferenceEquals(comparer, null)) throw new ArgumentNullException($"{nameof(comparer)} is null.");
            return comparer.Compare(lhs, rhs);
        }
        #endregion

        #region public instance methods
        /// <summary>
        /// Compares two books for equality.
        /// </summary>
        /// <param name="other">Book for comparison.</param>
        /// <returns>True, if books are equal, and false otherwise.</returns>
        public bool Equals(Book other)
        {
            if (ReferenceEquals(other, null)) return false;
            return this.Name == other.Name && this.Author == other.Author && this.Year == other.Year && this.Pages == other.Pages;
        }

        /// <summary>
        /// Compares two books for equality.
        /// </summary>
        /// <param name="obj">Object for comparison.</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null)) return false;
            if (typeof(Book) == obj.GetType()) return false;
            return this.Equals(obj as Book);
        }

        /// <summary>
        /// Calculates int number as a characteristic of an object.
        /// </summary>
        /// <returns>Int number.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return Pages * 3 + Year * 5 + Author.Length * 7 + Name.Length * 11;
            }
        }

        /// <summary>
        /// Compares two books by authors.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns>-1, if object is less than parameter book; 1, if greater; 0, if they are equal.</returns>
        int IComparable.CompareTo(object obj)
        {
            if (ReferenceEquals(obj, null)) throw new ArgumentNullException($"{nameof(obj)} is null.");
            return this.CompareTo(obj as Book);
        }

        /// <summary>
        /// Compares two books by authors.
        /// </summary>
        /// <param name="obj">Book to compare.</param>
        /// <returns>-1, if book is less than parameter book; 1, if greater; 0, if they are equal.</returns>
        public int CompareTo(Book book)
        {
            if (ReferenceEquals(book, null)) throw new ArgumentNullException($"{nameof(book)} is null.");
            return this.Author.CompareTo(book.Author);
        }

        /// <summary>
        /// Returns string representation of an object.
        /// </summary>
        /// <returns>String representation of an object.</returns>
        public override string ToString() => $"\"{Name}\", {Author}, {Year}, {Pages} pages";
        #endregion

        #region private methods
        private bool CheckName(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} is null or empty.");
            return true;
        }

        private bool CheckAuthor(string author)
        {
            if (string.IsNullOrEmpty(author)) throw new ArgumentException($"{nameof(author)} is null or empty.");
            return true;
        }

        private bool CheckYear(int year)
        {
            if (year > DateTime.Today.Year || year < EarliestYearOfPublishing) throw new ArgumentException($"{nameof(year)} is unsuitable.");
            return true;
        }

        private bool CheckPages(int pages)
        {
            if (pages <= MinQuantityOfPages || pages > MaxQuantityOfPages) throw new ArgumentException($"{nameof(pages)} is unsuitable.");
            return true;
        }
        #endregion

    }
}
