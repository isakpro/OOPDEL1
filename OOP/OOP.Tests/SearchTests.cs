using System;
using Xunit;
using OOP;

namespace OOP.Tests
{
    public class SearchTests
    {
        [Theory]
        [InlineData("Tolkien", true)]
        [InlineData("tolkien", true)]
        [InlineData("Rowling", false)]
        public void Book_Matches_ShouldFindByAuthor(string searchTerm, bool expected)
        {
            // Arrange
            var book = new Book("123", "Sagan om ringen", "J.R.R. Tolkien", 1954);

            // Act
            var result = book.Matches(searchTerm);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("Sagan", true)]
        [InlineData("sagan om ringen", true)]
        [InlineData("Harry Potter", false)]
        public void Book_Matches_ShouldFindByTitle(string searchTerm, bool expected)
        {
            // Arrange
            var book = new Book("123", "Sagan om ringen", "J.R.R. Tolkien", 1954);

            // Act
            var result = book.Matches(searchTerm);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Book_Matches_ShouldReturnFalse_WhenSearchTermIsEmpty()
        {
            // Arrange
            var book = new Book("123", "Sagan om ringen", "J.R.R. Tolkien", 1954);

            // Act & Assert
            Assert.False(book.Matches(""));
            Assert.False(book.Matches(null));
        }
    }
}
