using System;

namespace OOP
{
    internal class Magazine : LibraryItem, ISearchable
    {
        public string Publisher { get; set; }
        public int IssueNumber { get; set; }

        public Magazine(string id, string title, string publisher, int issueNumber, int publishedYear)
            : base(id, title, publishedYear)
        {
            Publisher = publisher;
            IssueNumber = issueNumber;
        }

        public override string GetInfo()
        {
            string availability = IsAvailable ? "Tillgänglig" : "Utlånad";
            return $"Typ: Tidskrift\n" +
                   $"ID: {Id}\n" +
                   $"Titel: {Title}\n" +
                   $"Utgivare: {Publisher}\n" +
                   $"Nummer: {IssueNumber}\n" +
                   $"Utgivningsår: {PublishedYear}\n" +
                   $"Status: {availability}";
        }

        public bool Matches(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return false;

            string term = searchTerm.ToLower();
            return Title.ToLower().Contains(term) ||
                   Publisher.ToLower().Contains(term) ||
                   Id.ToLower().Contains(term);
        }
    }
}
