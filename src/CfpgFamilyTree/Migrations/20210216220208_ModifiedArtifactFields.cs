using Microsoft.EntityFrameworkCore.Migrations;

namespace CfpgFamilyTree.Migrations
{
    public partial class ModifiedArtifactFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Artifacts",
                newName: "Title");

            migrationBuilder.AddColumn<string>(
                name: "LongDescription",
                table: "Artifacts",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShortDescription",
                table: "Artifacts",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LongDescription",
                table: "Artifacts");

            migrationBuilder.DropColumn(
                name: "ShortDescription",
                table: "Artifacts");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Artifacts",
                newName: "Description");
        }
    }
}
