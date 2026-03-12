using System;
using System.Collections.Generic;

namespace OOP
{
    // Domain member kept for business logic (non-EF) if needed
    public class Member : ISearchable
    {
        public string MemberId { get; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime MemberSince { get; }

        private List<LibraryItem> borrowedItems;

        public IReadOnlyList<LibraryItem> BorrowedItems => borrowedItems.AsReadOnly();

        public Member(string memberId, string name, string email)
        {
            MemberId = memberId;
            Name = name;
            Email = email;
            MemberSince = DateTime.Now;
            borrowedItems = new List<LibraryItem>();
        }

        public void AddBorrowedItem(LibraryItem item)
        {
            if (!borrowedItems.Contains(item))
            {
                borrowedItems.Add(item);
            }
        }

        public void RemoveBorrowedItem(LibraryItem item)
        {
            borrowedItems.Remove(item);
        }

        public string GetMemberInfo()
        {
            return $"Medlems-ID: {MemberId}\n" +
                   $"Namn: {Name}\n" +
                   $"E-post: {Email}\n" +
                   $"Medlem sedan: {MemberSince:yyyy-MM-dd}\n" +
                   $"Antal lånade objekt: {borrowedItems.Count}";
        }

        public bool Matches(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return false;

            string term = searchTerm.ToLower();
            return Name.ToLower().Contains(term) ||
                   Email.ToLower().Contains(term) ||
                   MemberId.ToLower().Contains(term);
        }
    }

    // EF entity for Member persistence
    public class MemberEntity
    {
        public int Id { get; set; }
        public string MemberId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime MemberSince { get; set; }

        // Navigation property for EF; use EF entity types here
        public ICollection<LoanEntity> Loans { get; set; } = new List<LoanEntity>();
    }
}
