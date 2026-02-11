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
            Console.WriteLine("=== Bibliotekssystem ===\n");

            // Skapa böcker
            Book book1 = new Book("978-0-123456-78-9", "C# Programming", "Anders Andersson", 2020);
            Book book2 = new Book("978-0-987654-32-1", "OOP Principles", "Lisa Svensson", 2019);

            Console.WriteLine("Böcker i systemet:");
            Console.WriteLine(book1.GetInfo());
            Console.WriteLine("\n" + book2.GetInfo());

            // Skapa medlem
            Member member1 = new Member("M001", "Erik Johansson", "erik@example.com");
            
            Console.WriteLine("\n\nMedlem:");
            Console.WriteLine(member1.GetMemberInfo());

            // Skapa lån
            Console.WriteLine("\n\n=== Lånar en bok ===");
            book1.IsAvailable = false;
            member1.AddBorrowedBook(book1);
            Loan loan1 = new Loan(book1, member1, 14);
            
            Console.WriteLine(loan1.GetLoanInfo());

            Console.WriteLine("\n\nUppdaterad medlemsinformation:");
            Console.WriteLine(member1.GetMemberInfo());

            // Returnera bok
            Console.WriteLine("\n\n=== Returnerar boken ===");
            loan1.ReturnBook();
            Console.WriteLine(loan1.GetLoanInfo());

            Console.WriteLine("\n\nUppdaterad bokinformation:");
            Console.WriteLine(book1.GetInfo());

            Console.WriteLine("\n\nTryck på valfri tangent för att avsluta...");
            Console.ReadKey();
        }
    }
}
