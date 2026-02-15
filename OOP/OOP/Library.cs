using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP
{
    public class Library
    {
        private List<LibraryItem> items;
        private List<Member> members;

        public IReadOnlyList<LibraryItem> Items => items.AsReadOnly();
        public IReadOnlyList<Member> Members => members.AsReadOnly();

        public Library()
        {
            items = new List<LibraryItem>();
            members = new List<Member>();
        }

        public void AddItem(LibraryItem item)
        {
            if (item != null && !items.Contains(item))
            {
                items.Add(item);
            }
        }

        public void AddMember(Member member)
        {
            if (member != null && !members.Contains(member))
            {
                members.Add(member);
            }
        }


        public List<Book> SearchBooks(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return new List<Book>();

            return items
                .OfType<Book>()
                .Where(book => book.Matches(searchTerm))
                .ToList();
        }

        public List<T> Search<T>(string searchTerm) where T : ISearchable
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return new List<T>();

            return items
                .OfType<T>()
                .Where(item => item.Matches(searchTerm))
                .ToList();
        }


        public List<Book> GetBooksSortedByTitle()
        {
            return items
                .OfType<Book>()
                .OrderBy(book => book.Title)
                .ToList();
        }


        public List<Book> GetBooksSortedByYear()
        {
            return items
                .OfType<Book>()
                .OrderBy(book => book.PublishedYear)
                .ToList();
        }

        public List<Book> GetBooksSortedByAuthor()
        {
            return items
                .OfType<Book>()
                .OrderBy(book => book.Author)
                .ToList();
        }


        public int GetTotalBookCount()
        {
            return items.OfType<Book>().Count();
        }

        public int GetBorrowedBookCount()
        {
            return items
                .OfType<Book>()
                .Count(book => !book.IsAvailable);
        }


        public Member GetMostActiveBorrower()
        {
            if (members.Count == 0)
                return null;

            return members
                .OrderByDescending(member => member.BorrowedItems.Count)
                .FirstOrDefault();
        }


        public int GetTotalItemCount()
        {
            return items.Count;
        }

        public int GetBorrowedItemCount()
        {
            return items.Count(item => !item.IsAvailable);
        }

        public int GetAvailableItemCount()
        {
            return items.Count(item => item.IsAvailable);
        }


        public string GetStatistics()
        {
            var mostActive = GetMostActiveBorrower();
            string mostActiveName = mostActive != null ? $"{mostActive.Name} ({mostActive.BorrowedItems.Count} lån)" : "Ingen";

            return $"=== BIBLIOTEKSSTATISTIK ===\n" +
                   $"Totalt antal objekt: {GetTotalItemCount()}\n" +
                   $"Totalt antal böcker: {GetTotalBookCount()}\n" +
                   $"Utlånade böcker: {GetBorrowedBookCount()}\n" +
                   $"Tillgängliga böcker: {GetTotalBookCount() - GetBorrowedBookCount()}\n" +
                   $"Totalt utlånade objekt: {GetBorrowedItemCount()}\n" +
                   $"Totalt tillgängliga objekt: {GetAvailableItemCount()}\n" +
                   $"Antal medlemmar: {members.Count}\n" +
                   $"Mest aktiv låntagare: {mostActiveName}";
        }
    }
}
