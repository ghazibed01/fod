using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fod.Migrations.GestionVisiteDB
{
    /// <inheritdoc />
    public partial class SecondMIGRATION : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personnel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Prenom = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Poste = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personnel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RaisonVisites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaisonVisites", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statuts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeVisites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeVisites", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeVisiteurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeVisiteurs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Visiteurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Prenom = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Telphone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Type_visiteur_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visiteurs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TypeVisiteur",
                        column: x => x.Type_visiteur_id,
                        principalTable: "TypeVisiteurs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Visites",
                columns: table => new
                {
                    Uid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    DateHeureDebut = table.Column<DateTime>(type: "datetime", nullable: true),
                    DateHeureFin = table.Column<DateTime>(type: "datetime", nullable: true),
                    Raison_visite_id = table.Column<int>(type: "int", nullable: true),
                    Type_visite_id = table.Column<int>(type: "int", nullable: true),
                    Statut_id = table.Column<int>(type: "int", nullable: true),
                    Personnel_id = table.Column<int>(type: "int", nullable: true),
                    Visiteur_id = table.Column<int>(type: "int", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Visites__C5B69A4A02F6D497", x => x.Uid);
                    table.ForeignKey(
                        name: "FK_Personnel",
                        column: x => x.Personnel_id,
                        principalTable: "Personnel",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RaisonVisite",
                        column: x => x.Raison_visite_id,
                        principalTable: "RaisonVisites",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Statut",
                        column: x => x.Statut_id,
                        principalTable: "Statuts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TypeVisite",
                        column: x => x.Type_visite_id,
                        principalTable: "TypeVisites",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Visiteur",
                        column: x => x.Visiteur_id,
                        principalTable: "Visiteurs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Visites_Personnel_id",
                table: "Visites",
                column: "Personnel_id");

            migrationBuilder.CreateIndex(
                name: "IX_Visites_Raison_visite_id",
                table: "Visites",
                column: "Raison_visite_id");

            migrationBuilder.CreateIndex(
                name: "IX_Visites_Statut_id",
                table: "Visites",
                column: "Statut_id");

            migrationBuilder.CreateIndex(
                name: "IX_Visites_Type_visite_id",
                table: "Visites",
                column: "Type_visite_id");

            migrationBuilder.CreateIndex(
                name: "IX_Visites_Visiteur_id",
                table: "Visites",
                column: "Visiteur_id");

            migrationBuilder.CreateIndex(
                name: "IX_Visiteurs_Type_visiteur_id",
                table: "Visiteurs",
                column: "Type_visiteur_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Visites");

            migrationBuilder.DropTable(
                name: "Personnel");

            migrationBuilder.DropTable(
                name: "RaisonVisites");

            migrationBuilder.DropTable(
                name: "Statuts");

            migrationBuilder.DropTable(
                name: "TypeVisites");

            migrationBuilder.DropTable(
                name: "Visiteurs");

            migrationBuilder.DropTable(
                name: "TypeVisiteurs");
        }
    }
}
