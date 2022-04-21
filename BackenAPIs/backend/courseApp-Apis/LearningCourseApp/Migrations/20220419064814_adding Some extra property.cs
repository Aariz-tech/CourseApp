using Microsoft.EntityFrameworkCore.Migrations;

namespace LearningCourseApp.Migrations
{
    public partial class addingSomeextraproperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_CourseInformation_CourseInformationId",
                table: "Courses");

            migrationBuilder.DropTable(
                name: "CourseInformation");

            migrationBuilder.DropIndex(
                name: "IX_Courses_CourseInformationId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CourseInformationId",
                table: "Courses");

            migrationBuilder.AddColumn<string>(
                name: "DocumentUrl",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VideoUrl",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocumentUrl",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "VideoUrl",
                table: "Courses");

            migrationBuilder.AddColumn<int>(
                name: "CourseInformationId",
                table: "Courses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CourseInformation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseInformation", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CourseInformationId",
                table: "Courses",
                column: "CourseInformationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_CourseInformation_CourseInformationId",
                table: "Courses",
                column: "CourseInformationId",
                principalTable: "CourseInformation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
