using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class change_table_schema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "kavehnegar");

            migrationBuilder.RenameTable(
                name: "MyEntities",
                newName: "MyEntities",
                newSchema: "kavehnegar");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "MyEntities",
                schema: "kavehnegar",
                newName: "MyEntities");
        }
    }
}
