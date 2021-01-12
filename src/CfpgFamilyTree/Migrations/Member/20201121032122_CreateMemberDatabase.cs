using Microsoft.EntityFrameworkCore.Migrations;

namespace CfpgFamilyTree.Migrations.Member
{
    public partial class CreateMemberDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreferredName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Suffix = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfilePhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDay = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    BirthMonth = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    BirthYear = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    DeathDay = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    DeathMonth = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    DeathYear = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    IsAlive = table.Column<bool>(type: "bit", nullable: false),
                    HasSpouse = table.Column<bool>(type: "bit", nullable: false),
                    PrimaryParent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondaryParent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActiveUser = table.Column<bool>(type: "bit", nullable: false),
                    Spouse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Members");
        }
    }
}
