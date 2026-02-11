using System;

namespace OOP
{
    internal class Book
    {
        public string ISBN { get; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublishedYear { get; set; }
        public bool IsAvailable { get; set; }

        public Book(string isbn, string title, string author, int publishedYear)
        {
            ISBN = isbn;
            Title = title;
            Author = author;
            PublishedYear = publishedYear;
            IsAvailable = true;
        }

        public string GetInfo()
        {
            string availability = IsAvailable ? "Tillgänglig" : "Utlånad";
            return $"ISBN: {ISBN}\n" +
                   $"Titel: {Title}\n" +
                   $"Författare: {Author}\n" +
                   $"Utgivningsår: {PublishedYear}\n" +
                   $"Status: {availability}";
        }
    }
}
