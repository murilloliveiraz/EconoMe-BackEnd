using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EconoMe.Api.Migrations
{
    /// <inheritdoc />
    public partial class receivableTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "receivable",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AmountReceived = table.Column<double>(type: "double precision", nullable: false),
                    ReceiptDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    TransactionCategoryId = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "VARCHAR", nullable: false),
                    OriginalAmount = table.Column<double>(type: "double precision", nullable: false),
                    Note = table.Column<string>(type: "VARCHAR", nullable: true),
                    RegistrationDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    InactivationDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    ReferenceDate = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_receivable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_receivable_transactioncategory_TransactionCategoryId",
                        column: x => x.TransactionCategoryId,
                        principalTable: "transactioncategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_receivable_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_receivable_TransactionCategoryId",
                table: "receivable",
                column: "TransactionCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_receivable_UserId",
                table: "receivable",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "receivable");
        }
    }
}
