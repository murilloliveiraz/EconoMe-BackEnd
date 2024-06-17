using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EconoMe.Api.Migrations
{
    /// <inheritdoc />
    public partial class CreatePaymentModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "payment",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    TransactionCategoryId = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "VARCHAR", nullable: false),
                    OriginalAmount = table.Column<double>(type: "double precision", nullable: false),
                    AmountPaid = table.Column<double>(type: "double precision", nullable: false),
                    Note = table.Column<string>(type: "VARCHAR", nullable: true),
                    RegistrationDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    InactivationDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    ReferenceDate = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_payment_transactioncategory_TransactionCategoryId",
                        column: x => x.TransactionCategoryId,
                        principalTable: "transactioncategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_payment_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_payment_TransactionCategoryId",
                table: "payment",
                column: "TransactionCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_payment_UserId",
                table: "payment",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "payment");
        }
    }
}
