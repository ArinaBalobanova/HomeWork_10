using System;

namespace Лабораторная_12.Classes
{
    public class BookComparer
    {
        public static int CompareByTitle(Book a, Book b)
        {
            return string.Compare(a.Title, b.Title);
        }
        public static int CompareByAuthor(Book a, Book b)
        {
            return string.Compare(a.Author, b.Author);
        }
        public static int CompareByPublisher(Book a, Book b)
        {
            return string.Compare(a.Publisher, b.Publisher);
        }

    }
}
