using Microsoft.EntityFrameworkCore.Migrations;

namespace CfpgFamilyTree.Migrations
{
    public partial class AddedBioParagraphs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BioParagraph1",
                table: "Members",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BioParagraph2",
                table: "Members",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BioParagraph3",
                table: "Members",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BioParagraph4",
                table: "Members",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BioParagraph5",
                table: "Members",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BioParagraph6",
                table: "Members",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BioParagraph7",
                table: "Members",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BioParagraph1",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "BioParagraph2",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "BioParagraph3",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "BioParagraph4",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "BioParagraph5",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "BioParagraph6",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "BioParagraph7",
                table: "Members");
        }
    }
}
