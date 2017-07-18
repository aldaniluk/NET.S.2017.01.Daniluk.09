using System;

namespace Logic
{
    public interface IComparer
    {
        int Compare(Book lhs, Book rhs);
    }
}
