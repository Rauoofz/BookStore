using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.Migrations
{
    public partial class initDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryCode = table.Column<string>(nullable: true),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "nationalities",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nationalities", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "authors",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Path = table.Column<string>(nullable: true),
                    Nationality_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_authors", x => x.ID);
                    table.ForeignKey(
                        name: "FK_authors_nationalities_Nationality_ID",
                        column: x => x.Nationality_ID,
                        principalTable: "nationalities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "books",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookTitle = table.Column<string>(nullable: true),
                    Year = table.Column<DateTime>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Path = table.Column<string>(nullable: true),
                    Stock = table.Column<int>(nullable: false),
                    Author_ID = table.Column<int>(nullable: false),
                    Category_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_books", x => x.ID);
                    table.ForeignKey(
                        name: "FK_books_authors_Author_ID",
                        column: x => x.Author_ID,
                        principalTable: "authors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_books_categories_Category_ID",
                        column: x => x.Category_ID,
                        principalTable: "categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_authors_Nationality_ID",
                table: "authors",
                column: "Nationality_ID");

            migrationBuilder.CreateIndex(
                name: "IX_books_Author_ID",
                table: "books",
                column: "Author_ID");

            migrationBuilder.CreateIndex(
                name: "IX_books_Category_ID",
                table: "books",
                column: "Category_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "books");

            migrationBuilder.DropTable(
                name: "authors");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "nationalities");
        }
    }
}
