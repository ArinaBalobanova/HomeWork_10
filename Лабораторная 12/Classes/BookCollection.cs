using System;


namespace Лабораторная_12.Classes
{
    public delegate int ComparisonDelegate(Book a, Book b);
    public class BookCollection
    {
        private Book[] books;
        public BookCollection(Book[] books)
        {
            this.books = books;
        }
        public void Sort(ComparisonDelegate comparison)
        {
            Array.Sort(books, new Comparison<Book>((a, b) => comparison(a, b)));
        }
        public void Display()
        {
            foreach (Book book in books)
            {
                Console.WriteLine(book);
            }
        }
    }
}
