using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrowingTogether.Migrations
{
    /// <inheritdoc />
    public partial class AddPreview : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PreviewImage",
                table: "Boards",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PreviewImage",
                table: "Boards");
        }
    }
}
