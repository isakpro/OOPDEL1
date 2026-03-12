using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using OOP;
using OOP.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Configure DbContext using configuration (SQL Server by default)
var connectionString = builder.Configuration.GetConnectionString("LibraryDb")
                       ?? "Server=(localdb)\\mssqllocaldb;Database=LibraryDb;Trusted_Connection=True;";
builder.Services.AddDbContext<LibraryContext>(options =>
    options.UseSqlServer(connectionString));

// Repositories
builder.Services.AddScoped<OOP.Repositories.IBookRepository, OOP.Repositories.BookRepository>();
builder.Services.AddScoped<OOP.Repositories.IMemberRepository, OOP.Repositories.MemberRepository>();
builder.Services.AddScoped<OOP.Repositories.ILoanRepository, OOP.Repositories.LoanRepository>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();
app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
