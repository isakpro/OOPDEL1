using System;

namespace OOP
{
    internal class Book : LibraryItem
    {
        public string ISBN { get; }
        public string Author { get; set; }

        public Book(string isbn, string title, string author, int publishedYear)
            : base(isbn, title, publishedYear)
        {
            ISBN = isbn;
            Author = author;
        }

        public override string GetInfo()
        {
            string availability = IsAvailable ? "Tillgänglig" : "Utlånad";
            return $"Typ: Bok\n" +
                   $"ISBN: {ISBN}\n" +
                   $"Titel: {Title}\n" +
                   $"Författare: {Author}\n" +
                   $"Utgivningsår: {PublishedYear}\n" +
                   $"Status: {availability}";
        }
    }
}
