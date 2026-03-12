using Microsoft.EntityFrameworkCore;

namespace OOP
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book> Books { get; set; } = null!;
        public DbSet<MemberEntity> Members { get; set; } = null!;
        public DbSet<LoanEntity> Loans { get; set; } = null!;

        public LibraryContext()
        {
        }

        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                // Use LocalDB SQL Server by default; update connection string via options in production
                options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=LibraryDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.ISBN).IsRequired();
                b.Property(x => x.Title).IsRequired();
                b.Property(x => x.Author).IsRequired();
            });

            modelBuilder.Entity<MemberEntity>(m =>
            {
                m.HasKey(x => x.Id);
                m.Property(x => x.Name).IsRequired();
                m.Property(x => x.Email).IsRequired();
            });

            modelBuilder.Entity<LoanEntity>(l =>
            {
                l.HasKey(x => x.Id);
                l.HasOne(x => x.Book).WithMany(b => b.Loans).HasForeignKey(x => x.BookId);
                l.HasOne(x => x.Member).WithMany(m => m.Loans).HasForeignKey(x => x.MemberId);
            });
        }
    }
}
