using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HSPFrontTest.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Rendezvous_MedecinId",
                table: "Rendezvous",
                column: "MedecinId");

            migrationBuilder.CreateIndex(
                name: "IX_Rendezvous_PatientId",
                table: "Rendezvous",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rendezvous_Medecin_MedecinId",
                table: "Rendezvous",
                column: "MedecinId",
                principalTable: "Medecin",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rendezvous_Patient_PatientId",
                table: "Rendezvous",
                column: "PatientId",
                principalTable: "Patient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rendezvous_Medecin_MedecinId",
                table: "Rendezvous");

            migrationBuilder.DropForeignKey(
                name: "FK_Rendezvous_Patient_PatientId",
                table: "Rendezvous");

            migrationBuilder.DropIndex(
                name: "IX_Rendezvous_MedecinId",
                table: "Rendezvous");

            migrationBuilder.DropIndex(
                name: "IX_Rendezvous_PatientId",
                table: "Rendezvous");
        }
    }
}
