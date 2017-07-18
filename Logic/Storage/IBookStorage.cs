using System;
using System.Collections.Generic;

namespace Logic
{
    public interface IBookStorage
    {
        List<Book> ReadFromStorage();
        void WriteToStorage(List<Book> bookList);
    }
}
