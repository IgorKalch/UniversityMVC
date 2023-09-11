using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityDataLayer.Migrations
{
    /// <inheritdoc />
    public partial class CreatedByIdToEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Students",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Groups",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Courses",
                type: "nvarchar(450)",
                nullable: true);          

            migrationBuilder.CreateIndex(
                name: "IX_Student_CreatedById",
                table: "Students",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Group_CreatedById",
                table: "Groups",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Course_CreatedById",
                table: "Courses",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_AspNetUsers_CreatedById",
                table: "Courses",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Group_AspNetUsers_CreatedById",
                table: "Groups",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_AspNetUsers_CreatedById",
                table: "Students",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_AspNetUsers_CreatedById",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Group_AspNetUsers_CreatedById",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_AspNetUsers_CreatedById",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Student_CreatedById",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Group_CreatedById",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Course_CreatedById",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Courses");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);
        }
    }
}
