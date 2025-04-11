using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GroupApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingBannerPropurtyToCourse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Banner",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Banner",
                table: "Courses");
        }
    }
}
