# OOPDEL1

Ett bibliotekssystem utvecklat i C# (.NET 8) som demonstrerar objektorienterade programmeringskoncept, Entity Framework Core med SQL Server samt enhetstestning.

## 📚 Översikt

Projektet är ett bibliotekshanteringssystem som hanterar böcker, tidskrifter, DVD:er, medlemmar och lån. Systemet är uppdelat i tre projekt:

- **OOP** – Klassbibliotek med domänmodeller, EF Core-entiteter, repositories och tjänster
- **OOP.Tests** – Enhetstester med xUnit (inkl. InMemory-databas)
- **OOP.Web** – Blazor Server-webbapplikation

## 🎯 Funktioner

- **Hantering av olika mediatyper:**
  - Böcker med ISBN, titel, författare och publiceringsår
  - Tidskrifter med ID, titel, utgivare, utgåvenummer och år
  - DVD:er med ID, titel, regissör, speltid och publiceringsår

- **Medlemshantering:**
  - Registrera medlemmar med ID, namn och e-post
  - Håll koll på lånade objekt per medlem

- **Lånesystem:**
  - Låna ut och returnera biblioteksobjekt
  - Spåra låneperioder och förseningar
  - Kontrollera tillgänglighet

- **Sökfunktionalitet:**
  - Sök efter objekt baserat på titel, författare, ISBN m.m.
  - Implementerat via `ISearchable`-gränssnittet

- **Statistik:**
  - Totalt antal objekt/böcker, utlånade/tillgängliga
  - Mest aktiv låntagare

- **Databaslagring med Entity Framework Core:**
  - `LibraryContext` med `DbSet` för `Books`, `Members` och `Loans`
  - Repository-mönster (`IBookRepository`, `IMemberRepository`, `ILoanRepository`)
  - `LibraryService` med `BorrowAsync` / `ReturnAsync`
  - Migrations för att skapa och uppdatera databasen

## 🏗️ Projektstruktur

```
OOPDEL1/
├── OOP/
│   ├── OOP/                         # Domänmodeller & logik
│   │   ├── LibraryItem.cs           # Abstrakt basklass
│   │   ├── Book.cs                  # Bok (ärver LibraryItem)
│   │   ├── Magazine.cs              # Tidskrift
│   │   ├── DVD.cs                   # DVD
│   │   ├── Member.cs                # Medlem (domän + MemberEntity för EF)
│   │   ├── Loan.cs                  # Lån (domänklass)
│   │   ├── LoanEntity.cs            # Lån (EF-entitet)
│   │   ├── Library.cs               # Biblioteksklass med sök & statistik
│   │   ├── ISearchable.cs           # Gränssnitt för sökfunktionalitet
│   │   ├── Entities/
│   │   │   └── LibraryContext.cs     # EF Core DbContext
│   │   ├── Repositories/
│   │   │   ├── IBookRepository.cs
│   │   │   ├── BookRepositoryImpl.cs
│   │   │   ├── IMemberRepository.cs
│   │   │   ├── MemberRepository.cs
│   │   │   ├── ILoanRepository.cs
│   │   │   └── LoanRepository.cs
│   │   └── Services/
│   │       └── LibraryService.cs     # Låne-/returlogik mot databasen
│   ├── Migrations/                   # EF Core Migrations
│   │   ├── 20260312184017_InitialCreate.cs
│   │   └── LibraryContextModelSnapshot.cs
│   ├── Program.cs                    # Konsoldemonstration
│   ├── OOP.csproj
│   ├── OOP.Tests/                    # Enhetstester (xUnit)
│   │   ├── BookTests.cs
│   │   ├── SearchTests.cs
│   │   ├── LoanTests.cs
│   │   ├── LibraryStatisticsTests.cs
│   │   ├── BookRepositoryTests.cs
│   │   ├── MemberRepositoryTests.cs
│   │   ├── LoanRepositoryTests.cs
│   │   ├── LibraryServiceTests.cs
│   │   └── OOP.Tests.csproj
│   ├── OOP.Web/                      # Blazor Server-webbapp
│   │   ├── Program.cs
│   │   ├── Pages/
│   │   └── OOP.Web.csproj
│   └── OOP.sln                       # Solution-fil
├── LICENSE
└── README.md
```

## 🔧 Teknisk implementation

### Kärnklasser

#### `LibraryItem` (Abstrakt basklass)
Basklass för alla biblioteksobjekt med gemensamma egenskaper:
- `Id`: Primärnyckel (EF Core)
- `ExternalId`: Extern identifierare (t.ex. ISBN)
- `Title`: Titel på objektet
- `PublishedYear`: Publiceringsår
- `IsAvailable`: Tillgänglighetsstatus
- `GetInfo()`: Abstrakt metod för att visa objektinformation
- `GetItemType()`: Virtuell metod för att hämta objekttyp

#### `ISearchable` (Gränssnitt)
Definierar sökfunktionalitet:
- `Matches(string searchTerm)`: Kontrollerar om objektet matchar en sökterm

#### `LibraryContext` (EF Core DbContext)
Hanterar databasåtkomst med tre tabeller:
- `Books` – Böcker
- `Members` – Medlemmar (`MemberEntity`)
- `Loans` – Lån (`LoanEntity`) med främmande nycklar till Books och Members

#### Repository-mönster
- `IBookRepository` / `BookRepository` – CRUD + sökning för böcker
- `IMemberRepository` / `MemberRepository` – CRUD för medlemmar
- `ILoanRepository` / `LoanRepository` – Aktiva lån, skapa och uppdatera lån

#### `LibraryService`
Affärslogik för utlåning och retur via databasen:
- `BorrowAsync(bookId, memberId, loanDays)` – Skapar lån och markerar bok som otillgänglig
- `ReturnAsync(loanId)` – Sätter returdatum och markerar bok som tillgänglig

### OOP-koncept som demonstreras

- **Arv**: `Book`, `Magazine` och `DVD` ärver från `LibraryItem`
- **Abstraktion**: `LibraryItem` är en abstrakt klass med abstrakta metoder
- **Polymorfism**: Olika implementationer av `GetInfo()` för varje mediatyp
- **Inkapsling**: Properties med lämpliga åtkomstmodifierare
- **Gränssnitt**: `ISearchable` och repository-interfaces

## 🚀 Kom igång

### Förutsättningar

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- SQL Server LocalDB (ingår i Visual Studio) eller annan SQL Server-instans
- Visual Studio 2022 eller senare (rekommenderas)

### Installation

1. Klona repositoryt:
```bash
git clone https://github.com/isakpro/OOPDEL1.git
```

2. Öppna solution-filen:
```bash
cd OOPDEL1/OOP
```

3. Återställ beroenden och bygg:
```bash
dotnet restore
dotnet build
```

### Databas med Entity Framework Migrations

Skapa och uppdatera databasen med EF Core Migrations:

```bash
cd OOP  # mappen med OOP.csproj
dotnet ef database update
```

Om du behöver skapa en ny migration efter ändringar i entiteterna:

```bash
dotnet ef migrations add <MigrationsNamn>
dotnet ef database update
```

> Databasen skapas som standard på `(localdb)\mssqllocaldb` med namnet `LibraryDb`.

### Köra konsolapplikationen

```bash
dotnet run --project OOP.csproj
```

Eller tryck `F5` i Visual Studio.

### Köra webbapplikationen (Blazor Server)

```bash
dotnet run --project OOP.Web/OOP.Web.csproj
```

### Köra tester

```bash
dotnet test
```

Eller i Visual Studio: Test → Run All Tests

## 📖 Användningsexempel

Konsolprogrammet (`Program.cs`) demonstrerar följande:

```csharp
// Skapa biblioteksobjekt
Book book1 = new Book("978-0-123456-78-9", "C# Programming", "Anders Andersson", 2020);
Magazine magazine1 = new Magazine("MAG-001", "Computer Sweden", "IDG", 42, 2024);
DVD dvd1 = new DVD("DVD-001", "The Matrix", "Lana Wachowski", 136, 1999);

// Skapa medlem
Member member1 = new Member("M001", "Erik Johansson", "erik@example.com");

// Låna och returnera objekt
Loan loan1 = new Loan(book1, member1, 14);
loan1.ReturnItem();
```

Databasbaserad utlåning via `LibraryService`:

```csharp
var service = new LibraryService(context);
var loan = await service.BorrowAsync(bookId: 1, memberId: 1, loanDays: 14);
await service.ReturnAsync(loan.Id);
```

## 🧪 Testning

Projektet innehåller enhetstester för:

| Testfil | Testar |
|---|---|
| `BookTests.cs` | Skapande och egenskaper för böcker |
| `SearchTests.cs` | Sökfunktionalitet i olika mediatyper |
| `LoanTests.cs` | Lån, retur och förseningar |
| `LibraryStatisticsTests.cs` | Statistik, sortering och mest aktiv låntagare |
| `BookRepositoryTests.cs` | CRUD och sökning mot InMemory-databas |
| `MemberRepositoryTests.cs` | CRUD för medlemmar mot InMemory-databas |
| `LoanRepositoryTests.cs` | Lånhantering mot InMemory-databas |
| `LibraryServiceTests.cs` | BorrowAsync/ReturnAsync mot InMemory-databas |

## 📦 NuGet-paket

| Paket | Version | Syfte |
|---|---|---|
| Microsoft.EntityFrameworkCore | 8.0.25 | ORM-ramverk |
| Microsoft.EntityFrameworkCore.SqlServer | 8.0.25 | SQL Server-provider |
| Microsoft.EntityFrameworkCore.Design | 8.0.25 | Migrations-verktyg |
| Microsoft.EntityFrameworkCore.InMemory | 8.0.25 | InMemory-databas för tester |
| xunit | 2.5.3 | Testramverk |
| Microsoft.NET.Test.Sdk | 18.3.0 | Testrunner |

## 📚 Lärandemål

Detta projekt täcker följande koncept:
- ✅ Arv och klasshierarkier
- ✅ Abstrakta klasser och metoder
- ✅ Gränssnitt (interfaces)
- ✅ Polymorfism
- ✅ Inkapsling
- ✅ Repository-mönster
- ✅ Entity Framework Core med SQL Server
- ✅ EF Core Migrations
- ✅ Asynkron programmering (async/await)
- ✅ Enhetstestning med xUnit och InMemory-databas
- ✅ Blazor Server-webbapplikation

## 📝 Licens

Detta projekt är licensierat under MIT-licensen – se [LICENSE](LICENSE) för detaljer.

## 👤 Författare

**isakpro**
- GitHub: [@isakpro](https://github.com/isakpro)
