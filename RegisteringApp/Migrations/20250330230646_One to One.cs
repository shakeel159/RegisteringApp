using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegisteringApp.Migrations
{
    /// <inheritdoc />
    public partial class OnetoOne : Migration
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
                    ClientId = table.Column<int>(type: "int", nullable: true),
                    ItemId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ID", x => x.Id);
                    table.ForeignKey(
                        name: "FK__ID_Clients_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "PublicID" },
                values: new object[] { 1, "YourEmail@gmail.com", "FirstName", "LastName", 2 });

            migrationBuilder.InsertData(
                table: "_ID",
                columns: new[] { "Id", "ClientId", "ItemId", "LastName" },
                values: new object[] { 2, 1, null, "LastName" });

            migrationBuilder.CreateIndex(
                name: "IX__ID_ItemId",
                table: "_ID",
                column: "ItemId",
                unique: true,
                filter: "[ItemId] IS NOT NULL");
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
