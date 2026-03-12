using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OOP
{
    public class LibraryService
    {
        private readonly LibraryContext _context;

        public LibraryService(LibraryContext context)
        {
            _context = context;
        }

        public async Task<LoanEntity> BorrowAsync(int bookId, int memberId, int loanDays = 14)
        {
            var book = await _context.Books.FindAsync(bookId);
            var member = await _context.Members.FindAsync(memberId);

            if (book == null) throw new InvalidOperationException("Book not found");
            if (member == null) throw new InvalidOperationException("Member not found");
            if (!book.IsAvailable) throw new InvalidOperationException("Book not available");

            var loan = new LoanEntity
            {
                BookId = bookId,
                MemberId = memberId,
                LoanDate = DateTime.Now,
                DueDate = DateTime.Now.AddDays(loanDays)
            };

            book.IsAvailable = false;
            _context.Loans.Add(loan);
            _context.Books.Update(book);
            await _context.SaveChangesAsync();

            return loan;
        }

        public async Task ReturnAsync(int loanId)
        {
            var loan = await _context.Loans.FindAsync(loanId);
            if (loan == null) throw new InvalidOperationException("Loan not found");

            if (loan.ReturnDate == null)
            {
                loan.ReturnDate = DateTime.Now;
                var book = await _context.Books.FindAsync(loan.BookId);
                if (book != null)
                {
                    book.IsAvailable = true;
                    _context.Books.Update(book);
                }
                _context.Loans.Update(loan);
                await _context.SaveChangesAsync();
            }
        }
    }
}
