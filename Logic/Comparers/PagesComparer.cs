﻿using System;
using System.Collections.Generic;

namespace Logic.Comparers
{
    public class PagesComparer : IComparer<Book>
    {
        /// <summary>
        /// In the order of increasing books' quantity of pages.
        /// </summary>
        /// <param name="lhs">One book to compare.</param>
        /// <param name="rhs">Another book to compare.</param>
        /// <returns>-1, if left book is less; 1, if greater; 0, if they are equal.</returns>
        public int Compare(Book lhs, Book rhs)
        {
            if (ReferenceEquals(lhs, null)) throw new ArgumentException($"{nameof(lhs)} is null.");
            if (ReferenceEquals(rhs, null)) throw new ArgumentException($"{nameof(rhs)} is null.");

            return lhs.Pages.CompareTo(rhs.Pages);
        }
    }
}
