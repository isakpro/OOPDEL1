using System;

namespace OOP
{
    internal class Loan
    {
        public Book Book { get; }
        public Member Member { get; }
        public DateTime LoanDate { get; }
        public DateTime DueDate { get; }
        public DateTime? ReturnDate { get; set; }

        public bool IsOverdue
        {
            get
            {
                if (IsReturned)
                {
                    return false;
                }
                return DateTime.Now > DueDate;
            }
        }

        public bool IsReturned => ReturnDate.HasValue;

        public Loan(Book book, Member member, int loanDurationDays = 14)
        {
            Book = book;
            Member = member;
            LoanDate = DateTime.Now;
            DueDate = LoanDate.AddDays(loanDurationDays);
            ReturnDate = null;
        }

        public void ReturnBook()
        {
            if (!IsReturned)
            {
                ReturnDate = DateTime.Now;
                Book.IsAvailable = true;
                Member.RemoveBorrowedBook(Book);
            }
        }

        public string GetLoanInfo()
        {
            string status = IsReturned ? $"Returnerad: {ReturnDate:yyyy-MM-dd}" :
                           IsOverdue ? "FÖRSENAD" : "Aktiv";
            
            return $"Bok: {Book.Title}\n" +
                   $"Medlem: {Member.Name}\n" +
                   $"Lånedatum: {LoanDate:yyyy-MM-dd}\n" +
                   $"Förfallodatum: {DueDate:yyyy-MM-dd}\n" +
                   $"Status: {status}";
        }
    }
}
