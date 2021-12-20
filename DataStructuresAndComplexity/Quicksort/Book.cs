using System;

namespace Quicksort
{
    public class Book : IComparable<Book>
    {
        public string ISBN { get; set; }

        public Book(string isbn)
        {
            ISBN = isbn;
        }

        public int CompareTo(Book other)
        {
            return ISBN.CompareTo(other.ISBN);
        }

        public override string ToString()
        {
            return ISBN;
        }
    }
}
