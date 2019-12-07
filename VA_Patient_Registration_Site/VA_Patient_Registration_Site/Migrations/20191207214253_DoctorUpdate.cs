using Microsoft.EntityFrameworkCore.Migrations;

namespace VA_Patient_Registration_Site.Migrations
{
    public partial class DoctorUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PassCode",
                table: "Doctor",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PassCode",
                table: "Doctor");
        }
    }
}
