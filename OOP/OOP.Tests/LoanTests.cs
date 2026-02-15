using System;
using System.Reflection;
using Xunit;
using OOP;

namespace OOP.Tests
{
    public class LoanTests
    {
        [Fact]
        public void IsOverdue_ShouldReturnFalse_WhenDueDateIsInFuture()
        {
            // Arrange
            var book = new Book("123", "Test", "Author", 2024);
            var member = new Member("M001", "Test Person", "test@test.com");
            var loan = new Loan(book, member, 14);

            // Act & Assert
            Assert.False(loan.IsOverdue);
        }

        [Fact]
        public void IsOverdue_ShouldReturnTrue_WhenDueDateHasPassed()
        {
            // Arrange
            var book = new Book("123", "Test", "Author", 2024);
            var member = new Member("M001", "Test Person", "test@test.com");
            // Skapa ett lån med 0 dagars löptid så att DueDate sätts till nu
            var loan = new Loan(book, member, 0);

            // Använd reflection för att sätta LoanDate och DueDate till förflutet
            var dueDateField = typeof(Loan).GetProperty("DueDate");
            var loanDateField = typeof(Loan).GetProperty("LoanDate");

            // Eftersom properties har private setter via backing field, använd reflection
            var backingDueDate = typeof(Loan).GetField("<DueDate>k__BackingField", BindingFlags.Instance | BindingFlags.NonPublic);
            var backingLoanDate = typeof(Loan).GetField("<LoanDate>k__BackingField", BindingFlags.Instance | BindingFlags.NonPublic);

            backingLoanDate.SetValue(loan, DateTime.Now.AddDays(-30));
            backingDueDate.SetValue(loan, DateTime.Now.AddDays(-16));

            // Act & Assert
            Assert.True(loan.IsOverdue);
        }

        [Fact]
        public void IsReturned_ShouldReturnTrue_WhenReturnDateIsSet()
        {
            // Arrange
            var book = new Book("123", "Test", "Author", 2024);
            var member = new Member("M001", "Test Person", "test@test.com");
            var loan = new Loan(book, member, 14);

            // Act
            loan.ReturnDate = DateTime.Now;

            // Assert
            Assert.True(loan.IsReturned);
        }

        [Fact]
        public void IsReturned_ShouldReturnFalse_WhenReturnDateIsNull()
        {
            // Arrange
            var book = new Book("123", "Test", "Author", 2024);
            var member = new Member("M001", "Test Person", "test@test.com");
            var loan = new Loan(book, member, 14);

            // Act & Assert
            Assert.False(loan.IsReturned);
        }
    }
}
