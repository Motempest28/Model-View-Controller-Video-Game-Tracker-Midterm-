using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Midterm.Migrations
{
    /// <inheritdoc />
    public partial class RatingToDouble : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Rating",
                table: "VideoGame",
                type: "float",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Rating",
                table: "VideoGame",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);
        }
    }
}
