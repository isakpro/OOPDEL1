using System;
using System.Collections.Generic;

namespace OOP
{
    public class Book : LibraryItem, ISearchable
    {
        // Navigation property for EF
        public ICollection<LoanEntity> Loans { get; set; } = new List<LoanEntity>();
        public string ISBN { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;

        public Book()
            : base(string.Empty, string.Empty, 0)
        {
        }

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

        public bool Matches(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return false;

            string term = searchTerm.ToLowerInvariant();
            return Title.ToLowerInvariant().Contains(term) ||
                   Author.ToLowerInvariant().Contains(term) ||
                   ISBN.ToLowerInvariant().Contains(term);
        }
    }
}
