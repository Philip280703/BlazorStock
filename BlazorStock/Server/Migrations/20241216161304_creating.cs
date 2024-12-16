using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorStock.Server.Migrations
{
    /// <inheritdoc />
    public partial class creating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StockEF",
                columns: table => new
                {
                    StockID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TickerSymbol = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CurrentPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Market = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sector = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DividendYield = table.Column<decimal>(type: "decimal(18,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockEF", x => x.StockID);
                });

            migrationBuilder.CreateTable(
                name: "UserEF",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEF", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "PortfolioEF",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalValue = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioEF", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PortfolioEF_UserEF_UserID",
                        column: x => x.UserID,
                        principalTable: "UserEF",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoldingEF",
                columns: table => new
                {
                    HoldingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PortfolioID = table.Column<int>(type: "int", nullable: false),
                    StockID = table.Column<int>(type: "int", nullable: false),
                    TickerSymbol = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Shares = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    PurchasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrentPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoldingEF", x => x.HoldingID);
                    table.ForeignKey(
                        name: "FK_HoldingEF_PortfolioEF_PortfolioID",
                        column: x => x.PortfolioID,
                        principalTable: "PortfolioEF",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HoldingEF_StockEF_StockID",
                        column: x => x.StockID,
                        principalTable: "StockEF",
                        principalColumn: "StockID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransactionEF",
                columns: table => new
                {
                    TransactionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoldingID = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Shares = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    PricePerShare = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fees = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionEF", x => x.TransactionID);
                    table.ForeignKey(
                        name: "FK_TransactionEF_HoldingEF_HoldingID",
                        column: x => x.HoldingID,
                        principalTable: "HoldingEF",
                        principalColumn: "HoldingID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HoldingEF_PortfolioID",
                table: "HoldingEF",
                column: "PortfolioID");

            migrationBuilder.CreateIndex(
                name: "IX_HoldingEF_StockID",
                table: "HoldingEF",
                column: "StockID");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioEF_UserID",
                table: "PortfolioEF",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionEF_HoldingID",
                table: "TransactionEF",
                column: "HoldingID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransactionEF");

            migrationBuilder.DropTable(
                name: "HoldingEF");

            migrationBuilder.DropTable(
                name: "PortfolioEF");

            migrationBuilder.DropTable(
                name: "StockEF");

            migrationBuilder.DropTable(
                name: "UserEF");
        }
    }
}
