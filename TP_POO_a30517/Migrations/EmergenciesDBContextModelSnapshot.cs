﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TP_POO_a30517.Data;

#nullable disable

namespace TP_POO_a30517.Migrations
{
    [DbContext(typeof(EmergenciesDBContext))]
    partial class EmergenciesDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TP_POO_a30517.Equipments.Equipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuantityAvailable")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Equipments", (string)null);
                });

            modelBuilder.Entity("TP_POO_a30517.Incidents.Incident", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EquipmentUsed")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Severity")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("TeamType")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Incidents", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("TP_POO_a30517.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("Birthdate")
                        .HasColumnType("date");

                    b.Property<string>("CitizenCard")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("TeamType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Persons", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("TP_POO_a30517.Relations.EquipmentIncident", b =>
                {
                    b.Property<int>("EquipmentId")
                        .HasColumnType("int");

                    b.Property<int>("IncidentId")
                        .HasColumnType("int");

                    b.HasKey("EquipmentId", "IncidentId");

                    b.HasIndex("IncidentId");

                    b.ToTable("EquipmentIncidents");
                });

            modelBuilder.Entity("TP_POO_a30517.Relations.TeamIncident", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AssignedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("IncidentId")
                        .HasColumnType("int");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IncidentId");

                    b.HasIndex("TeamId");

                    b.ToTable("TeamIncidents");
                });

            modelBuilder.Entity("TP_POO_a30517.Relations.TeamMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.HasIndex("TeamId");

                    b.ToTable("TeamMembers");
                });

            modelBuilder.Entity("TP_POO_a30517.Relations.VehicleEquipment", b =>
                {
                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.Property<int>("EquipmentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("AssignedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("VehicleId", "EquipmentId");

                    b.HasIndex("EquipmentId");

                    b.ToTable("VehicleEquipments");
                });

            modelBuilder.Entity("TP_POO_a30517.Relations.VehicleIncident", b =>
                {
                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.Property<int>("IncidentId")
                        .HasColumnType("int");

                    b.HasKey("VehicleId", "IncidentId");

                    b.HasIndex("IncidentId");

                    b.ToTable("VehicleIncidents");
                });

            modelBuilder.Entity("TP_POO_a30517.Teams.EmergencyTeamBase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("TeamType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Emergency_Team_Base", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("TP_POO_a30517.Vehicles.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("InspDate")
                        .HasColumnType("date");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("VehicleModel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehicleRegist")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("YearOfRegist")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.ToTable("Vehicles", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("TP_POO_a30517.Incidents.CatastropheIncident", b =>
                {
                    b.HasBaseType("TP_POO_a30517.Incidents.Incident");

                    b.Property<double>("AffectedAreaCatastrophe")
                        .HasColumnType("float");

                    b.Property<string>("CatastropheType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("IntensityCatastrophe")
                        .HasColumnType("float");

                    b.Property<int>("PeopleAffectedCatastrophe")
                        .HasColumnType("int");

                    b.ToTable("Catastrophe_Incidents", (string)null);
                });

            modelBuilder.Entity("TP_POO_a30517.Incidents.FireIncident", b =>
                {
                    b.HasBaseType("TP_POO_a30517.Incidents.Incident");

                    b.Property<double>("AffectedAreaFire")
                        .HasColumnType("float");

                    b.Property<int>("PeopleAffectedFire")
                        .HasColumnType("int");

                    b.ToTable("Fire_Incidents", (string)null);
                });

            modelBuilder.Entity("TP_POO_a30517.Incidents.MedicalIncident", b =>
                {
                    b.HasBaseType("TP_POO_a30517.Incidents.Incident");

                    b.Property<string>("MedicalCondition")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PatientAge")
                        .HasColumnType("int");

                    b.Property<string>("PatientName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Medical_Incidents", (string)null);
                });

            modelBuilder.Entity("TP_POO_a30517.Models.Doctor", b =>
                {
                    b.HasBaseType("TP_POO_a30517.Models.Person");

                    b.Property<int>("CardNumber")
                        .HasColumnType("int");

                    b.Property<int?>("INEMId")
                        .HasColumnType("int");

                    b.Property<string>("ProfessionalName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Specialty")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("INEMId");

                    b.ToTable("Doctors", (string)null);
                });

            modelBuilder.Entity("TP_POO_a30517.Models.EmergencyTechnician", b =>
                {
                    b.HasBaseType("TP_POO_a30517.Models.Person");

                    b.Property<int?>("INEMId")
                        .HasColumnType("int");

                    b.Property<string>("ProfessionalName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TechnicalNumber")
                        .HasColumnType("int");

                    b.HasIndex("INEMId");

                    b.ToTable("Emergency_Technicians", (string)null);
                });

            modelBuilder.Entity("TP_POO_a30517.Models.FireFighter", b =>
                {
                    b.HasBaseType("TP_POO_a30517.Models.Person");

                    b.Property<int?>("FireFightersId")
                        .HasColumnType("int");

                    b.Property<int>("MechanographicNumber")
                        .HasColumnType("int");

                    b.Property<string>("Specialization")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("YearsOfExperience")
                        .HasColumnType("int");

                    b.HasIndex("FireFightersId");

                    b.ToTable("FireFighters", (string)null);
                });

            modelBuilder.Entity("TP_POO_a30517.Models.Nurse", b =>
                {
                    b.HasBaseType("TP_POO_a30517.Models.Person");

                    b.Property<string>("AreaOfActivity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CardNumber")
                        .HasColumnType("int");

                    b.Property<int?>("INEMId")
                        .HasColumnType("int");

                    b.Property<string>("ProfessionalName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("INEMId");

                    b.ToTable("Nurses", (string)null);
                });

            modelBuilder.Entity("TP_POO_a30517.Teams.FireFighters", b =>
                {
                    b.HasBaseType("TP_POO_a30517.Teams.EmergencyTeamBase");

                    b.ToTable("FireFighters_Team", (string)null);
                });

            modelBuilder.Entity("TP_POO_a30517.Teams.INEM", b =>
                {
                    b.HasBaseType("TP_POO_a30517.Teams.EmergencyTeamBase");

                    b.ToTable("INEM_Team", (string)null);
                });

            modelBuilder.Entity("TP_POO_a30517.Vehicles.Ambulance", b =>
                {
                    b.HasBaseType("TP_POO_a30517.Vehicles.Vehicle");

                    b.Property<int>("CrewCapacity")
                        .HasColumnType("int");

                    b.Property<int>("MedicalEquipment")
                        .HasColumnType("int");

                    b.Property<int>("PatientCapacity")
                        .HasColumnType("int");

                    b.ToTable("Ambulances", (string)null);
                });

            modelBuilder.Entity("TP_POO_a30517.Vehicles.Boat", b =>
                {
                    b.HasBaseType("TP_POO_a30517.Vehicles.Vehicle");

                    b.Property<double>("Comprimento")
                        .HasColumnType("float");

                    b.Property<int>("Equipment")
                        .HasColumnType("int");

                    b.Property<int>("Motor")
                        .HasColumnType("int");

                    b.Property<int>("PassengerCapacity")
                        .HasColumnType("int");

                    b.ToTable("Boats", (string)null);
                });

            modelBuilder.Entity("TP_POO_a30517.Vehicles.FireTruck", b =>
                {
                    b.HasBaseType("TP_POO_a30517.Vehicles.Vehicle");

                    b.Property<int>("TankCapacity")
                        .HasColumnType("int");

                    b.ToTable("FireTrucks", (string)null);
                });

            modelBuilder.Entity("TP_POO_a30517.Vehicles.Heli", b =>
                {
                    b.HasBaseType("TP_POO_a30517.Vehicles.Vehicle");

                    b.Property<int>("CargoCapacity")
                        .HasColumnType("int");

                    b.Property<string>("FuelType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PassengerCapacity")
                        .HasColumnType("int");

                    b.ToTable("Helis", (string)null);
                });

            modelBuilder.Entity("TP_POO_a30517.Vehicles.LiftingMeans", b =>
                {
                    b.HasBaseType("TP_POO_a30517.Vehicles.Vehicle");

                    b.Property<int>("EquipmentType")
                        .HasColumnType("int");

                    b.Property<int>("LiftingCapacity")
                        .HasColumnType("int");

                    b.Property<int>("MaxHeight")
                        .HasColumnType("int");

                    b.ToTable("Lifting_Means", (string)null);
                });

            modelBuilder.Entity("TP_POO_a30517.Vehicles.LogisticalSupport", b =>
                {
                    b.HasBaseType("TP_POO_a30517.Vehicles.Vehicle");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<int>("Equipment")
                        .HasColumnType("int");

                    b.ToTable("Logistical_Supports", (string)null);
                });

            modelBuilder.Entity("TP_POO_a30517.Vehicles.MotorBike", b =>
                {
                    b.HasBaseType("TP_POO_a30517.Vehicles.Vehicle");

                    b.Property<int>("EngineCapacity")
                        .HasColumnType("int");

                    b.Property<bool>("MedicalBagSupport")
                        .HasColumnType("bit");

                    b.ToTable("MotorBikes", (string)null);
                });

            modelBuilder.Entity("TP_POO_a30517.Relations.EquipmentIncident", b =>
                {
                    b.HasOne("TP_POO_a30517.Equipments.Equipment", "Equipment")
                        .WithMany("EquipmentIncidents")
                        .HasForeignKey("EquipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TP_POO_a30517.Incidents.Incident", "Incident")
                        .WithMany("EquipmentIncidents")
                        .HasForeignKey("IncidentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipment");

                    b.Navigation("Incident");
                });

            modelBuilder.Entity("TP_POO_a30517.Relations.TeamIncident", b =>
                {
                    b.HasOne("TP_POO_a30517.Incidents.Incident", "Incident")
                        .WithMany("TeamIncidents")
                        .HasForeignKey("IncidentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TP_POO_a30517.Teams.EmergencyTeamBase", "Team")
                        .WithMany("TeamIncidents")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Incident");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("TP_POO_a30517.Relations.TeamMember", b =>
                {
                    b.HasOne("TP_POO_a30517.Models.Person", "Person")
                        .WithMany("TeamMemberships")
                        .HasForeignKey("PersonId")
                        .IsRequired()
                        .HasConstraintName("FK_TeamMember_Person");

                    b.HasOne("TP_POO_a30517.Teams.EmergencyTeamBase", "Team")
                        .WithMany("TeamMembers")
                        .HasForeignKey("TeamId")
                        .IsRequired()
                        .HasConstraintName("FK_TeamMember_EmergencyTeamBase");

                    b.Navigation("Person");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("TP_POO_a30517.Relations.VehicleEquipment", b =>
                {
                    b.HasOne("TP_POO_a30517.Equipments.Equipment", "Equipment")
                        .WithMany("VehicleEquipments")
                        .HasForeignKey("EquipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TP_POO_a30517.Vehicles.Vehicle", "Vehicle")
                        .WithMany("VehicleEquipments")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipment");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("TP_POO_a30517.Relations.VehicleIncident", b =>
                {
                    b.HasOne("TP_POO_a30517.Incidents.Incident", "Incident")
                        .WithMany("VehicleIncidents")
                        .HasForeignKey("IncidentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TP_POO_a30517.Vehicles.Vehicle", "Vehicle")
                        .WithMany("VehicleIncidents")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Incident");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("TP_POO_a30517.Incidents.CatastropheIncident", b =>
                {
                    b.HasOne("TP_POO_a30517.Incidents.Incident", null)
                        .WithOne()
                        .HasForeignKey("TP_POO_a30517.Incidents.CatastropheIncident", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TP_POO_a30517.Incidents.FireIncident", b =>
                {
                    b.HasOne("TP_POO_a30517.Incidents.Incident", null)
                        .WithOne()
                        .HasForeignKey("TP_POO_a30517.Incidents.FireIncident", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TP_POO_a30517.Incidents.MedicalIncident", b =>
                {
                    b.HasOne("TP_POO_a30517.Incidents.Incident", null)
                        .WithOne()
                        .HasForeignKey("TP_POO_a30517.Incidents.MedicalIncident", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TP_POO_a30517.Models.Doctor", b =>
                {
                    b.HasOne("TP_POO_a30517.Teams.INEM", null)
                        .WithMany("DoctorsList")
                        .HasForeignKey("INEMId");

                    b.HasOne("TP_POO_a30517.Models.Person", null)
                        .WithOne()
                        .HasForeignKey("TP_POO_a30517.Models.Doctor", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TP_POO_a30517.Models.EmergencyTechnician", b =>
                {
                    b.HasOne("TP_POO_a30517.Teams.INEM", null)
                        .WithMany("EmergencyTechniciansList")
                        .HasForeignKey("INEMId");

                    b.HasOne("TP_POO_a30517.Models.Person", null)
                        .WithOne()
                        .HasForeignKey("TP_POO_a30517.Models.EmergencyTechnician", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TP_POO_a30517.Models.FireFighter", b =>
                {
                    b.HasOne("TP_POO_a30517.Teams.FireFighters", null)
                        .WithMany("FireFightersList")
                        .HasForeignKey("FireFightersId");

                    b.HasOne("TP_POO_a30517.Models.Person", null)
                        .WithOne()
                        .HasForeignKey("TP_POO_a30517.Models.FireFighter", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TP_POO_a30517.Models.Nurse", b =>
                {
                    b.HasOne("TP_POO_a30517.Teams.INEM", null)
                        .WithMany("NursesList")
                        .HasForeignKey("INEMId");

                    b.HasOne("TP_POO_a30517.Models.Person", null)
                        .WithOne()
                        .HasForeignKey("TP_POO_a30517.Models.Nurse", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TP_POO_a30517.Teams.FireFighters", b =>
                {
                    b.HasOne("TP_POO_a30517.Teams.EmergencyTeamBase", null)
                        .WithOne()
                        .HasForeignKey("TP_POO_a30517.Teams.FireFighters", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TP_POO_a30517.Teams.INEM", b =>
                {
                    b.HasOne("TP_POO_a30517.Teams.EmergencyTeamBase", null)
                        .WithOne()
                        .HasForeignKey("TP_POO_a30517.Teams.INEM", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TP_POO_a30517.Vehicles.Ambulance", b =>
                {
                    b.HasOne("TP_POO_a30517.Vehicles.Vehicle", null)
                        .WithOne()
                        .HasForeignKey("TP_POO_a30517.Vehicles.Ambulance", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TP_POO_a30517.Vehicles.Boat", b =>
                {
                    b.HasOne("TP_POO_a30517.Vehicles.Vehicle", null)
                        .WithOne()
                        .HasForeignKey("TP_POO_a30517.Vehicles.Boat", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TP_POO_a30517.Vehicles.FireTruck", b =>
                {
                    b.HasOne("TP_POO_a30517.Vehicles.Vehicle", null)
                        .WithOne()
                        .HasForeignKey("TP_POO_a30517.Vehicles.FireTruck", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TP_POO_a30517.Vehicles.Heli", b =>
                {
                    b.HasOne("TP_POO_a30517.Vehicles.Vehicle", null)
                        .WithOne()
                        .HasForeignKey("TP_POO_a30517.Vehicles.Heli", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TP_POO_a30517.Vehicles.LiftingMeans", b =>
                {
                    b.HasOne("TP_POO_a30517.Vehicles.Vehicle", null)
                        .WithOne()
                        .HasForeignKey("TP_POO_a30517.Vehicles.LiftingMeans", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TP_POO_a30517.Vehicles.LogisticalSupport", b =>
                {
                    b.HasOne("TP_POO_a30517.Vehicles.Vehicle", null)
                        .WithOne()
                        .HasForeignKey("TP_POO_a30517.Vehicles.LogisticalSupport", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TP_POO_a30517.Vehicles.MotorBike", b =>
                {
                    b.HasOne("TP_POO_a30517.Vehicles.Vehicle", null)
                        .WithOne()
                        .HasForeignKey("TP_POO_a30517.Vehicles.MotorBike", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TP_POO_a30517.Equipments.Equipment", b =>
                {
                    b.Navigation("EquipmentIncidents");

                    b.Navigation("VehicleEquipments");
                });

            modelBuilder.Entity("TP_POO_a30517.Incidents.Incident", b =>
                {
                    b.Navigation("EquipmentIncidents");

                    b.Navigation("TeamIncidents");

                    b.Navigation("VehicleIncidents");
                });

            modelBuilder.Entity("TP_POO_a30517.Models.Person", b =>
                {
                    b.Navigation("TeamMemberships");
                });

            modelBuilder.Entity("TP_POO_a30517.Teams.EmergencyTeamBase", b =>
                {
                    b.Navigation("TeamIncidents");

                    b.Navigation("TeamMembers");
                });

            modelBuilder.Entity("TP_POO_a30517.Vehicles.Vehicle", b =>
                {
                    b.Navigation("VehicleEquipments");

                    b.Navigation("VehicleIncidents");
                });

            modelBuilder.Entity("TP_POO_a30517.Teams.FireFighters", b =>
                {
                    b.Navigation("FireFightersList");
                });

            modelBuilder.Entity("TP_POO_a30517.Teams.INEM", b =>
                {
                    b.Navigation("DoctorsList");

                    b.Navigation("EmergencyTechniciansList");

                    b.Navigation("NursesList");
                });
#pragma warning restore 612, 618
        }
    }
}
