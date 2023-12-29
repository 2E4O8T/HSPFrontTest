using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HSPFrontTest.Migrations
{
    public partial class initinit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MedecinId",
                table: "Rendezvous",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Medecin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specialite = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medecin", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rendezvous_MedecinId",
                table: "Rendezvous",
                column: "MedecinId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rendezvous_Medecin_MedecinId",
                table: "Rendezvous",
                column: "MedecinId",
                principalTable: "Medecin",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rendezvous_Medecin_MedecinId",
                table: "Rendezvous");

            migrationBuilder.DropTable(
                name: "Medecin");

            migrationBuilder.DropIndex(
                name: "IX_Rendezvous_MedecinId",
                table: "Rendezvous");

            migrationBuilder.DropColumn(
                name: "MedecinId",
                table: "Rendezvous");
        }
    }
}
