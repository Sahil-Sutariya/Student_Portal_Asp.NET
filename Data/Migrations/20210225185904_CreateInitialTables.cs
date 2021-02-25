using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentPortalFinal.Data.Migrations
{
    public partial class CreateInitialTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "student",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    studentGrade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "fees",
                columns: table => new
                {
                    FeesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(nullable: false),
                    TotalAmount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fees", x => x.FeesId);
                    table.ForeignKey(
                        name: "FK_Students_FeesId",
                        column: x => x.StudentId,
                        principalTable: "student",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "studentinfo",
                columns: table => new
                {
                    AdminId = table.Column<int>(nullable: false),
                    courseName = table.Column<string>(nullable: true),
                    proffessorName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentinfo", x => x.AdminId);
                    table.ForeignKey(
                        name: "FK_Students_StudentId",
                        column: x => x.AdminId,
                        principalTable: "student",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_fees_StudentId",
                table: "fees",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "fees");

            migrationBuilder.DropTable(
                name: "studentinfo");

            migrationBuilder.DropTable(
                name: "student");
        }
    }
}
