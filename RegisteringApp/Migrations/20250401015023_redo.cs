using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegisteringApp.Migrations
{
    /// <inheritdoc />
    public partial class redo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PublicID",
                table: "Clients",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "_ID",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ID", x => x.Id);
                    table.ForeignKey(
                        name: "FK__ID_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "PublicID" },
                values: new object[] { 1, "YourEmail@gmail.com", "FirstName", "LastName", 2 });

            migrationBuilder.InsertData(
                table: "_ID",
                columns: new[] { "Id", "ClientId", "LastName" },
                values: new object[] { 2, 1, "Client_LastName" });

            migrationBuilder.CreateIndex(
                name: "IX__ID_ClientId",
                table: "_ID",
                column: "ClientId",
                unique: true,
                filter: "[ClientId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "_ID");

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "PublicID",
                table: "Clients");
        }
    }
}
