using System;

namespace Лабораторная_12.Classes
{
    public class Book
    {
        public string Title { get; }
        public string Author { get; }
        public string Publisher { get; }

        public Book(string title, string author, string publisher)
        {
            Title = title;
            Author = author;
            Publisher = publisher;
        }

        public override string ToString()
        {
            return $"Title: {Title}, Author: {Author}, Publisher: {Publisher}";
        }
    }
}
