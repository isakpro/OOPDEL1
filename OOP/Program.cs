using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Bibliotekssystem med Arv ===\n");

            // Skapa olika typer av biblioteksobjekt
            Book book1 = new Book("978-0-123456-78-9", "C# Programming", "Anders Andersson", 2020);
            Magazine magazine1 = new Magazine("MAG-001", "Computer Sweden", "IDG", 42, 2024);
            DVD dvd1 = new DVD("DVD-001", "The Matrix", "Lana Wachowski", 136, 1999);

            // Lista med alla biblioteksobjekt (polymorfism)
            List<LibraryItem> libraryItems = new List<LibraryItem> { book1, magazine1, dvd1 };

            Console.WriteLine("=== Alla objekt i biblioteket ===\n");
            foreach (LibraryItem item in libraryItems)
            {
                Console.WriteLine(item.GetInfo());
                Console.WriteLine();
            }

            // Skapa medlem
            Member member1 = new Member("M001", "Erik Johansson", "erik@example.com");
            
            Console.WriteLine("\n=== Medlem ===");
            Console.WriteLine(member1.GetMemberInfo());

            // Låna olika typer av objekt
            Console.WriteLine("\n\n=== Lånar en bok ===");
            book1.IsAvailable = false;
            member1.AddBorrowedItem(book1);
            Loan loan1 = new Loan(book1, member1, 14);
            Console.WriteLine(loan1.GetLoanInfo());

            Console.WriteLine("\n\n=== Lånar en tidskrift ===");
            magazine1.IsAvailable = false;
            member1.AddBorrowedItem(magazine1);
            Loan loan2 = new Loan(magazine1, member1, 7);
            Console.WriteLine(loan2.GetLoanInfo());

            Console.WriteLine("\n\n=== Lånar en DVD ===");
            dvd1.IsAvailable = false;
            member1.AddBorrowedItem(dvd1);
            Loan loan3 = new Loan(dvd1, member1, 3);
            Console.WriteLine(loan3.GetLoanInfo());

            // Visa uppdaterad medlemsinformation
            Console.WriteLine("\n\n=== Uppdaterad medlemsinformation ===");
            Console.WriteLine(member1.GetMemberInfo());

            // Returnera ett objekt
            Console.WriteLine("\n\n=== Returnerar boken ===");
            loan1.ReturnItem();
            Console.WriteLine(loan1.GetLoanInfo());

            Console.WriteLine("\n\n=== Uppdaterad bokinformation ===");
            Console.WriteLine(book1.GetInfo());

            Console.WriteLine("\n\n=== Uppdaterad medlemsinformation ===");
            Console.WriteLine(member1.GetMemberInfo());

            Console.WriteLine("\n\nTryck på valfri tangent för att avsluta...");
            Console.ReadKey();
        }
    }
}
