using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebUI.Migrations
{
    /// <inheritdoc />
    public partial class ChangeStudentTableColumnName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Telefon",
                table: "Students",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "Soyad",
                table: "Students",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "Ad",
                table: "Students",
                newName: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Students",
                newName: "Telefon");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Students",
                newName: "Soyad");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Students",
                newName: "Ad");
        }
    }
}
