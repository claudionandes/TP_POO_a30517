using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP_POO_a30517.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Emergency_Team_Base",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    TeamType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emergency_Team_Base", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Equipments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    QuantityAvailable = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Incidents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Severity = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    EquipmentUsed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeamType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthdate = table.Column<DateOnly>(type: "date", nullable: false),
                    CitizenCard = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    TeamType = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleRegist = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearOfRegist = table.Column<DateOnly>(type: "date", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleModel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InspDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FireFighters_Team",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FireFighters_Team", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FireFighters_Team_Emergency_Team_Base_Id",
                        column: x => x.Id,
                        principalTable: "Emergency_Team_Base",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "INEM_Team",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INEM_Team", x => x.Id);
                    table.ForeignKey(
                        name: "FK_INEM_Team_Emergency_Team_Base_Id",
                        column: x => x.Id,
                        principalTable: "Emergency_Team_Base",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Catastrophe_Incidents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CatastropheType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AffectedAreaCatastrophe = table.Column<double>(type: "float", nullable: false),
                    PeopleAffectedCatastrophe = table.Column<int>(type: "int", nullable: false),
                    IntensityCatastrophe = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catastrophe_Incidents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Catastrophe_Incidents_Incidents_Id",
                        column: x => x.Id,
                        principalTable: "Incidents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fire_Incidents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    AffectedAreaFire = table.Column<double>(type: "float", nullable: false),
                    PeopleAffectedFire = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fire_Incidents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fire_Incidents_Incidents_Id",
                        column: x => x.Id,
                        principalTable: "Incidents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medical_Incidents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    PatientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientAge = table.Column<int>(type: "int", nullable: false),
                    MedicalCondition = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medical_Incidents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medical_Incidents_Incidents_Id",
                        column: x => x.Id,
                        principalTable: "Incidents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Team_Members",
                columns: table => new
                {
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team_Members", x => new { x.TeamId, x.PersonId });
                    table.ForeignKey(
                        name: "FK_Team_Members_Emergency_Team_Base_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Emergency_Team_Base",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Team_Members_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ambulances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    PatientCapacity = table.Column<int>(type: "int", nullable: false),
                    CrewCapacity = table.Column<int>(type: "int", nullable: false),
                    MedicalEquipment = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ambulances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ambulances_Vehicles_Id",
                        column: x => x.Id,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Boats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    PassengerCapacity = table.Column<int>(type: "int", nullable: false),
                    Equipment = table.Column<int>(type: "int", nullable: false),
                    Comprimento = table.Column<double>(type: "float", nullable: false),
                    Motor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Boats_Vehicles_Id",
                        column: x => x.Id,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FireTrucks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    TankCapacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FireTrucks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FireTrucks_Vehicles_Id",
                        column: x => x.Id,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Helis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    PassengerCapacity = table.Column<int>(type: "int", nullable: false),
                    CargoCapacity = table.Column<int>(type: "int", nullable: false),
                    FuelType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Helis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Helis_Vehicles_Id",
                        column: x => x.Id,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lifting_Means",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    LiftingCapacity = table.Column<int>(type: "int", nullable: false),
                    MaxHeight = table.Column<int>(type: "int", nullable: false),
                    EquipmentType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lifting_Means", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lifting_Means_Vehicles_Id",
                        column: x => x.Id,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Logistical_Supports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Equipment = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logistical_Supports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Logistical_Supports_Vehicles_Id",
                        column: x => x.Id,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MotorBikes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    EngineCapacity = table.Column<int>(type: "int", nullable: false),
                    MedicalBagSupport = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotorBikes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MotorBikes_Vehicles_Id",
                        column: x => x.Id,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FireFighters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    YearsOfExperience = table.Column<int>(type: "int", nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MechanographicNumber = table.Column<int>(type: "int", nullable: false),
                    FireFightersId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FireFighters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FireFighters_FireFighters_Team_FireFightersId",
                        column: x => x.FireFightersId,
                        principalTable: "FireFighters_Team",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FireFighters_Persons_Id",
                        column: x => x.Id,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ProfessionalName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CardNumber = table.Column<int>(type: "int", nullable: false),
                    Specialty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    INEMId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_INEM_Team_INEMId",
                        column: x => x.INEMId,
                        principalTable: "INEM_Team",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Doctors_Persons_Id",
                        column: x => x.Id,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Emergency_Technicians",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ProfessionalName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TechnicalNumber = table.Column<int>(type: "int", nullable: false),
                    INEMId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emergency_Technicians", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Emergency_Technicians_INEM_Team_INEMId",
                        column: x => x.INEMId,
                        principalTable: "INEM_Team",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Emergency_Technicians_Persons_Id",
                        column: x => x.Id,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Nurses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ProfessionalName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CardNumber = table.Column<int>(type: "int", nullable: false),
                    AreaOfActivity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    INEMId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nurses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nurses_INEM_Team_INEMId",
                        column: x => x.INEMId,
                        principalTable: "INEM_Team",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Nurses_Persons_Id",
                        column: x => x.Id,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_INEMId",
                table: "Doctors",
                column: "INEMId");

            migrationBuilder.CreateIndex(
                name: "IX_Emergency_Technicians_INEMId",
                table: "Emergency_Technicians",
                column: "INEMId");

            migrationBuilder.CreateIndex(
                name: "IX_FireFighters_FireFightersId",
                table: "FireFighters",
                column: "FireFightersId");

            migrationBuilder.CreateIndex(
                name: "IX_Nurses_INEMId",
                table: "Nurses",
                column: "INEMId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_Members_PersonId",
                table: "Team_Members",
                column: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ambulances");

            migrationBuilder.DropTable(
                name: "Boats");

            migrationBuilder.DropTable(
                name: "Catastrophe_Incidents");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Emergency_Technicians");

            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DropTable(
                name: "Fire_Incidents");

            migrationBuilder.DropTable(
                name: "FireFighters");

            migrationBuilder.DropTable(
                name: "FireTrucks");

            migrationBuilder.DropTable(
                name: "Helis");

            migrationBuilder.DropTable(
                name: "Lifting_Means");

            migrationBuilder.DropTable(
                name: "Logistical_Supports");

            migrationBuilder.DropTable(
                name: "Medical_Incidents");

            migrationBuilder.DropTable(
                name: "MotorBikes");

            migrationBuilder.DropTable(
                name: "Nurses");

            migrationBuilder.DropTable(
                name: "Team_Members");

            migrationBuilder.DropTable(
                name: "FireFighters_Team");

            migrationBuilder.DropTable(
                name: "Incidents");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "INEM_Team");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Emergency_Team_Base");
        }
    }
}
