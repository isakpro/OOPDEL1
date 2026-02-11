using System;

namespace OOP
{
    internal class Magazine : LibraryItem
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
    }
}
