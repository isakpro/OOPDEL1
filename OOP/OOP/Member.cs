using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP
{
    internal class Member
    {
        public string MemberId { get; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime MemberSince { get; }
        
        private List<Book> borrowedBooks;

        public IReadOnlyList<Book> BorrowedBooks => borrowedBooks.AsReadOnly();

        public Member(string memberId, string name, string email)
        {
            MemberId = memberId;
            Name = name;
            Email = email;
            MemberSince = DateTime.Now;
            borrowedBooks = new List<Book>();
        }

        public void AddBorrowedBook(Book book)
        {
            if (!borrowedBooks.Contains(book))
            {
                borrowedBooks.Add(book);
            }
        }

        public void RemoveBorrowedBook(Book book)
        {
            borrowedBooks.Remove(book);
        }

        public string GetMemberInfo()
        {
            return $"Medlems-ID: {MemberId}\n" +
                   $"Namn: {Name}\n" +
                   $"E-post: {Email}\n" +
                   $"Medlem sedan: {MemberSince:yyyy-MM-dd}\n" +
                   $"Antal lånade böcker: {borrowedBooks.Count}";
        }
    }
}
