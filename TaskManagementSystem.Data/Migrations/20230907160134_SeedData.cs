using Microsoft.EntityFrameworkCore.Migrations;
using TaskManagementSystem.Core.Models;

#nullable disable

namespace TaskManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var newQuotes = new List<Quote>
            {
                new Quote
                {
                    QuoteType = QuoteType.Auto,
                    Description = "Auto insurance quote 9",
                    DueDate = new DateTime(2023, 10, 1),
                    Premium = 300.00m,
                    Sales = 20
                },
                new Quote
                {
                    QuoteType = QuoteType.Home,
                    Description = "Home insurance quote 9",
                    DueDate = new DateTime(2023, 10, 5),
                    Premium = 450.00m,
                    Sales = 21
                },
                new Quote
                {
                    QuoteType = QuoteType.Auto,
                    Description = "Auto insurance quote 10",
                    DueDate = new DateTime(2023, 10, 2),
                    Premium = 320.00m,
                    Sales = 22
                },
                new Quote
                {
                    QuoteType = QuoteType.Home,
                    Description = "Home insurance quote 10",
                    DueDate = new DateTime(2023, 10, 6),
                    Premium = 460.00m,
                    Sales = 23
                },
                new Quote
                {
                    QuoteType = QuoteType.Auto,
                    Description = "Auto insurance quote 11",
                    DueDate = new DateTime(2023, 10, 3),
                    Premium = 340.00m,
                    Sales = 24
                },
                new Quote
                {
                    QuoteType = QuoteType.Home,
                    Description = "Home insurance quote 11",
                    DueDate = new DateTime(2023, 10, 7),
                    Premium = 480.00m,
                    Sales = 25
                },
                new Quote
                {
                    QuoteType = QuoteType.Auto,
                    Description = "Auto insurance quote 12",
                    DueDate = new DateTime(2023, 10, 4),
                    Premium = 360.00m,
                    Sales = 26
                },
                new Quote
                {
                    QuoteType = QuoteType.Home,
                    Description = "Home insurance quote 12",
                    DueDate = new DateTime(2023, 10, 8),
                    Premium = 500.00m,
                    Sales = 27
                },
                new Quote
                {
                    QuoteType = QuoteType.Auto,
                    Description = "Auto insurance quote 13",
                    DueDate = new DateTime(2023, 10, 5),
                    Premium = 380.00m,
                    Sales = 28
                },
                new Quote
                {
                    QuoteType = QuoteType.Home,
                    Description = "Home insurance quote 13",
                    DueDate = new DateTime(2023, 10, 9),
                    Premium = 520.00m,
                    Sales = 29
                }
            };
            foreach (var quote in newQuotes)
            {
                migrationBuilder.InsertData(
                    table: "Quotes",
                    columns: new[] { "QuoteType", "Description", "DueDate", "Premium", "Sales" },
                    values: new object[] { quote.QuoteType.ToString(), quote.Description, quote.DueDate, quote.Premium, quote.Sales });
            }

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
