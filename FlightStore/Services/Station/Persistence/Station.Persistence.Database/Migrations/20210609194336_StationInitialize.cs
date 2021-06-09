using Microsoft.EntityFrameworkCore.Migrations;

namespace Station.Persistence.Database.Migrations
{
    public partial class StationInitialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Station");

            migrationBuilder.CreateTable(
                name: "Stations",
                schema: "Station",
                columns: table => new
                {
                    StationNodeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stations", x => x.StationNodeId);
                });

            migrationBuilder.InsertData(
                schema: "Station",
                table: "Stations",
                columns: new[] { "StationNodeId", "Code", "Name" },
                values: new object[,]
                {
                    { 1, "AXM", "Armenia" },
                    { 2, "BAQ", "Barranquilla" },
                    { 3, "BOG", "Bogota" },
                    { 4, "BGA", "Bucaramanga" },
                    { 5, "CLO", "Cali" },
                    { 6, "CUC", "Cucuta" },
                    { 7, "CTG", "Cartagena" },
                    { 8, "LET", "Leticia" },
                    { 9, "MDE", "Medellin" },
                    { 10, "PEI", "Pereira" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stations_StationNodeId",
                schema: "Station",
                table: "Stations",
                column: "StationNodeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stations",
                schema: "Station");
        }
    }
}
