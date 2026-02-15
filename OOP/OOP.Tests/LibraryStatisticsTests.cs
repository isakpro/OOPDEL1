using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using OOP;

namespace OOP.Tests
{
    public class LibraryStatisticsTests
    {
        private Library CreateLibraryWithBooks()
        {
            var library = new Library();
            library.AddItem(new Book("1", "C-programmering", "Dennis Ritchie", 1978));
            library.AddItem(new Book("2", "Algoritmer", "Thomas Cormen", 2009));
            library.AddItem(new Book("3", "Bröderna Lejonhjärta", "Astrid Lindgren", 1973));
            return library;
        }

        [Fact]
        public void GetTotalBooks_ShouldReturnCorrectCount()
        {
            // Arrange
            var library = CreateLibraryWithBooks();

            // Act
            var count = library.GetTotalBookCount();

            // Assert
            Assert.Equal(3, count);
        }

        [Fact]
        public void GetBorrowedBooksCount_ShouldReturnCorrectCount()
        {
            // Arrange
            var library = CreateLibraryWithBooks();
            // Markera en bok som utlånad
            library.Items[0].IsAvailable = false;

            // Act
            var count = library.GetBorrowedBookCount();

            // Assert
            Assert.Equal(1, count);
        }

        [Fact]
        public void GetMostActiveBorrower_ShouldReturnMemberWithMostLoans()
        {
            // Arrange
            var library = new Library();
            var book1 = new Book("1", "Bok1", "Författare1", 2020);
            var book2 = new Book("2", "Bok2", "Författare2", 2021);
            library.AddItem(book1);
            library.AddItem(book2);

            var member1 = new Member("M001", "Anna", "anna@test.com");
            var member2 = new Member("M002", "Erik", "erik@test.com");
            library.AddMember(member1);
            library.AddMember(member2);

            // Ge member2 fler lån
            member2.AddBorrowedItem(book1);
            member2.AddBorrowedItem(book2);
            member1.AddBorrowedItem(book1);

            // Act
            var mostActive = library.GetMostActiveBorrower();

            // Assert
            Assert.NotNull(mostActive);
            Assert.Equal("Erik", mostActive.Name);
        }

        [Fact]
        public void SortBooksByTitle_ShouldReturnAlphabeticalOrder()
        {
            // Arrange
            var library = CreateLibraryWithBooks();

            // Act
            var sorted = library.GetBooksSortedByTitle();

            // Assert
            Assert.Equal("Algoritmer", sorted[0].Title);
            Assert.Equal("Bröderna Lejonhjärta", sorted[1].Title);
            Assert.Equal("C-programmering", sorted[2].Title);
        }
    }
}
