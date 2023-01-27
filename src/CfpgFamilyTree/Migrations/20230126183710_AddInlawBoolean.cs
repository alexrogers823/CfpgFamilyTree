using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CfpgFamilyTree.Migrations
{
    public partial class AddInlawBoolean : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsInlaw",
                table: "Members",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsInlaw",
                table: "Members");
        }
    }
}
