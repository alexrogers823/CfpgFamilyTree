using Microsoft.EntityFrameworkCore.Migrations;

namespace CfpgFamilyTree.Migrations
{
    public partial class RefinedMemberData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDay",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "BirthMonth",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "BirthYear",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "DeathDay",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "DeathMonth",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "DeathYear",
                table: "Members");

            migrationBuilder.AddColumn<string>(
                name: "PrimaryParent",
                table: "Members",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecondaryParent",
                table: "Members",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Spouse",
                table: "Members",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrimaryParent",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "SecondaryParent",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "Spouse",
                table: "Members");

            migrationBuilder.AddColumn<int>(
                name: "BirthDay",
                table: "Members",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BirthMonth",
                table: "Members",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BirthYear",
                table: "Members",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DeathDay",
                table: "Members",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeathMonth",
                table: "Members",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeathYear",
                table: "Members",
                type: "integer",
                nullable: true);
        }
    }
}
