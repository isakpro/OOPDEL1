# OOPDEL1

Ett konsolbaserat bibliotekssystem utvecklat i C# som demonstrerar objektorienterade programmeringskoncept som arv, abstraktion, polymorfism och gränssnitt.

## 📚 Översikt

Detta projekt är ett bibliotekshanteringssystem som låter användare hantera olika typer av mediaobjekt (böcker, tidskrifter och DVD:er), medlemmar och lån. Systemet demonstrerar kärnkoncept inom objektorienterad programmering (OOP).

## 🎯 Funktioner

- **Hantering av olika mediatyper:**
  - Böcker med ISBN, titel, författare och publiceringsår
  - Tidskrifter med ID, titel, utgivare, utgåvenummer och år
  - DVD:er med ID, titel, regissör, speltid och publiceringsår

- **Medlemshantering:**
  - Registrera medlemmar med ID, namn och e-post
  - Håll koll på lånade objekt per medlem

- **Lånesystem:**
  - Låna ut biblioteksobjekt till medlemmar
  - Spåra låneperioder
  - Returnera lånade objekt
  - Kontrollera tillgänglighet för objekt

- **Sökfunktionalitet:**
  - Sök efter objekt baserat på olika kriterier
  - Implementerat via `ISearchable`-gränssnittet

## 🏗️ Projektstruktur

```
OOPDEL1/
├── OOP/
│   ├── OOP/                    # Källkodsmapp
│   │   ├── LibraryItem.cs     # Abstrakt basklass för alla biblioteksobjekt
│   │   ├── ISearchable.cs     # Gränssnitt för sökfunktionalitet
│   │   └── ...                # Ytterligare klassimplementationer
│   ├── OOP.Tests/             # Enhetstester med xUnit
│   │   └── SearchTests.cs     # Tester för sökfunktionalitet
│   ├── Program.cs             # Huvudprogrammet med demonstrationer
│   ├── OOP.csproj             # Projektfil
│   └── OOP.sln                # Solution-fil
├── LICENSE                     # MIT-licens
└── README.md                   # Denna fil
```

## 🔧 Teknisk implementation

### Kärnklasser

#### `LibraryItem` (Abstrakt basklass)
Basklass för alla biblioteksobjekt med gemensamma egenskaper:
- `Id`: Unik identifierare
- `Title`: Titel på objektet
- `PublishedYear`: Publiceringsår
- `IsAvailable`: Tillgänglighetsstatus
- `GetInfo()`: Abstrakt metod för att visa objektinformation
- `GetItemType()`: Virtuell metod för att hämta objekttyp

#### `ISearchable` (Gränssnitt)
Definierar sökfunktionalitet:
- `Matches(string searchTerm)`: Kontrollerar om objektet matchar en sökterm

### OOP-koncept som demonstreras

- **Arv**: `Book`, `Magazine` och `DVD` ärver från `LibraryItem`
- **Abstraktion**: `LibraryItem` är en abstrakt klass med abstrakta metoder
- **Polymorfism**: Olika implementationer av `GetInfo()` för varje mediatyp
- **Inkapsling**: Properties med lämpliga åtkomstmodifierare
- **Gränssnitt**: `ISearchable` för flexibel sökfunktionalitet

## 🚀 Kom igång

### Förutsättningar

- .NET Framework 4.x eller senare
- Visual Studio 2019 eller senare (rekommenderas)
- C# 7.0 eller senare

### Installation

1. Klona repositoryt:
```bash
git clone https://github.com/isakpro/OOPDEL1.git
```

2. Öppna solution-filen:
```bash
cd OOPDEL1/OOP
# Öppna OOP.sln i Visual Studio
```

3. Bygg projektet:
   - Tryck `Ctrl+Shift+B` i Visual Studio
   - Eller via menyn: Build → Build Solution

### Köra applikationen

1. Tryck `F5` i Visual Studio för att köra i debug-läge
2. Eller tryck `Ctrl+F5` för att köra utan debugging

### Köra tester

Projektet innehåller enhetstester med xUnit:

```bash
dotnet test
```

Eller i Visual Studio:
- Test → Run All Tests

## 📖 Användningsexempel

Programmet demonstrerar följande scenario:

```csharp
// Skapa biblioteksobjekt
Book book1 = new Book("978-0-123456-78-9", "C# Programming", "Anders Andersson", 2020);
Magazine magazine1 = new Magazine("MAG-001", "Computer Sweden", "IDG", 42, 2024);
DVD dvd1 = new DVD("DVD-001", "The Matrix", "Lana Wachowski", 136, 1999);

// Skapa medlem
Member member1 = new Member("M001", "Erik Johansson", "erik@example.com");

// Låna objekt
Loan loan1 = new Loan(book1, member1, 14);

// Returnera objekt
loan1.ReturnItem();
```

## 🧪 Testning

Projektet innehåller enhetstester för:
- Sökfunktionalitet i olika mediatyper
- Matchning av titlar och författare
- Hantering av tomma söktermer

Exempel på test:
```csharp
[Theory]
[InlineData("Tolkien", true)]
[InlineData("tolkien", true)]
[InlineData("Rowling", false)]
public void Book_Matches_ShouldFindByAuthor(string searchTerm, bool expected)
{
    var book = new Book("123", "Sagan om ringen", "J.R.R. Tolkien", 1954);
    var result = book.Matches(searchTerm);
    Assert.Equal(expected, result);
}
```

## 📝 Licens

Detta projekt är licensierat under MIT-licensen - se [LICENSE](LICENSE) filen för detaljer.

## 👤 Författare

**isakpro**
- GitHub: [@isakpro](https://github.com/isakpro)

## 🤝 Bidra

Bidrag, issues och feature requests är välkomna!

1. Forka projektet
2. Skapa en feature branch (`git checkout -b feature/AmazingFeature`)
3. Commita dina ändringar (`git commit -m 'Add some AmazingFeature'`)
4. Pusha till branchen (`git push origin feature/AmazingFeature`)
5. Öppna en Pull Request

## 📚 Lärandemål

Detta projekt täcker följande OOP-koncept:
- ✅ Arv och klasshierarkier
- ✅ Abstrakta klasser och metoder
- ✅ Gränssnitt (interfaces)
- ✅ Polymorfism
- ✅ Inkapsling
- ✅ Properties och accessors
- ✅ Enhetstestning med xUnit
