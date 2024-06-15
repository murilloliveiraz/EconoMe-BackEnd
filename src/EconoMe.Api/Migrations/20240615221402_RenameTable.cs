using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EconoMe.Api.Migrations
{
    /// <inheritdoc />
    public partial class RenameTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionCategory_user_UserId",
                table: "TransactionCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TransactionCategory",
                table: "TransactionCategory");

            migrationBuilder.RenameTable(
                name: "TransactionCategory",
                newName: "transactioncategory");

            migrationBuilder.RenameIndex(
                name: "IX_TransactionCategory_UserId",
                table: "transactioncategory",
                newName: "IX_transactioncategory_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_transactioncategory",
                table: "transactioncategory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_transactioncategory_user_UserId",
                table: "transactioncategory",
                column: "UserId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_transactioncategory_user_UserId",
                table: "transactioncategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_transactioncategory",
                table: "transactioncategory");

            migrationBuilder.RenameTable(
                name: "transactioncategory",
                newName: "TransactionCategory");

            migrationBuilder.RenameIndex(
                name: "IX_transactioncategory_UserId",
                table: "TransactionCategory",
                newName: "IX_TransactionCategory_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransactionCategory",
                table: "TransactionCategory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionCategory_user_UserId",
                table: "TransactionCategory",
                column: "UserId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
