using System;

namespace Logic
{
    public interface IComparer<Book>
    {
        int Compare(Book lhs, Book rhs);
    }
}
