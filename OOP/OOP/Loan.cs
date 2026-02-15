using System;

namespace OOP
{
    public class Loan
    {
        public LibraryItem Item { get; }
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

        public Loan(LibraryItem item, Member member, int loanDurationDays = 14)
        {
            Item = item;
            Member = member;
            LoanDate = DateTime.Now;
            DueDate = LoanDate.AddDays(loanDurationDays);
            ReturnDate = null;
        }

        public void ReturnItem()
        {
            if (!IsReturned)
            {
                ReturnDate = DateTime.Now;
                Item.IsAvailable = true;
                Member.RemoveBorrowedItem(Item);
            }
        }

        public string GetLoanInfo()
        {
            string status = IsReturned ? $"Returnerad: {ReturnDate:yyyy-MM-dd}" :
                           IsOverdue ? "FÖRSENAD" : "Aktiv";
            
            return $"{Item.GetItemType()}: {Item.Title}\n" +
                   $"Medlem: {Member.Name}\n" +
                   $"Lånedatum: {LoanDate:yyyy-MM-dd}\n" +
                   $"Förfallodatum: {DueDate:yyyy-MM-dd}\n" +
                   $"Status: {status}";
        }
    }
}
