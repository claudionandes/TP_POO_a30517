using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP_POO_a30517.Migrations
{
    /// <inheritdoc />
    public partial class AddTeamIncident : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Team_Members",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TeamIncidents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    IncidentId = table.Column<int>(type: "int", nullable: false),
                    AssignedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamIncidents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamIncidents_Emergency_Team_Base_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Emergency_Team_Base",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamIncidents_Incidents_IncidentId",
                        column: x => x.IncidentId,
                        principalTable: "Incidents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeamIncidents_IncidentId",
                table: "TeamIncidents",
                column: "IncidentId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamIncidents_TeamId",
                table: "TeamIncidents",
                column: "TeamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeamIncidents");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Team_Members");
        }
    }
}
