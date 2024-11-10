
//-----------------------------------------------------------------
//    <copyright file="EmergenciesDBContext.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>02-11-2024</date>
//    <author>Cláudio Fernandes</author>
//    <summary>
//     Represents the database context for managing emergencies and related entities.
//    </summary>
//-----------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using TP_POO_a30517.Equipments;
using TP_POO_a30517.Incidents;
using TP_POO_a30517.Models;
using TP_POO_a30517.Relations;
using TP_POO_a30517.Teams;
using TP_POO_a30517.Vehicles;

namespace TP_POO_a30517.Data
{
    /// <summary>
    /// Database context for managing emergency-related entities.
    /// </summary>
    public class EmergenciesDBContext : DbContext
    {
        #region DbSet Properties
        /// <summary>
        /// DbSet properties representing tables in the database
        /// </summary>
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Incident> Incidents { get; set; }
        public DbSet<CatastropheIncident> Catastrophe_Incidents { get; set; }
        public DbSet<FireIncident> Fire_Incidents { get; set; }
        public DbSet<MedicalIncident> Medical_Incidents { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Nurse> Nurses { get; set; }
        public DbSet<FireFighter> FireFighters { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<EmergencyTechnician> Emergency_Technicians { get; set; }
        public DbSet<FireFighters> FireFighters_Team { get; set; }
        public DbSet<EmergencyTeamBase> Emergency_Team_Base { get; set; }
        public DbSet<INEM> INEM_Team { get; set; }
        public DbSet<TeamIncident> TeamIncidents { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<Ambulance> Ambulances { get; set; }
        public DbSet<Boat> Boats { get; set; }
        public DbSet<FireTruck> FireTrucks { get; set; }
        public DbSet<Heli> Helis { get; set; }
        public DbSet<LiftingMeans> Lifting_Means { get; set; }
        public DbSet<LogisticalSupport> Logistical_Supports { get; set; }
        public DbSet<MotorBike> MotorBikes { get; set; }

        public DbSet<EquipmentIncident> EquipmentIncidents { get; set; }

        public DbSet<VehicleIncident> VehicleIncidents { get; set; }

        public DbSet<VehicleEquipment> VehicleEquipments { get; set; }
        #endregion


        #region Model Builder
        /// <summary>
        /// Configures the model and its relationships
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Equipment>()
                .ToTable("Equipments")
                .HasKey(e => e.Id);

            modelBuilder.Entity<EquipmentIncident>()
                .HasKey(ei => new { ei.EquipmentId, ei.IncidentId });

            modelBuilder.Entity<EquipmentIncident>()
                .HasOne(ei => ei.Equipment)
                .WithMany(e => e.EquipmentIncidents)
                .HasForeignKey(ei => ei.EquipmentId);

            modelBuilder.Entity<EquipmentIncident>()
                .HasOne(ei => ei.Incident)
                .WithMany(i => i.EquipmentIncidents)
                .HasForeignKey(ei => ei.IncidentId);

            modelBuilder.Entity<Incident>()
                .ToTable("Incidents")
                .HasKey(i => i.Id);

            modelBuilder.Entity<CatastropheIncident>()
                .ToTable("Catastrophe_Incidents")
                .HasBaseType<Incident>();

            modelBuilder.Entity<FireIncident>()
                .ToTable("Fire_Incidents")
                .HasBaseType<Incident>();

            modelBuilder.Entity<MedicalIncident>()
                .ToTable("Medical_Incidents")
                .HasBaseType<Incident>();

            modelBuilder.Entity<Person>()
                .ToTable("Persons")
                .HasKey(p => p.Id);

            modelBuilder.Entity<Nurse>()
                .ToTable("Nurses")
                .HasBaseType<Person>();

            modelBuilder.Entity<FireFighter>()
                .ToTable("FireFighters")
                .HasBaseType<Person>();

            modelBuilder.Entity<Doctor>()
                .ToTable("Doctors")
                .HasBaseType<Person>();

            modelBuilder.Entity<EmergencyTechnician>()
                .ToTable("Emergency_Technicians")
                .HasBaseType<Person>();

            modelBuilder.Entity<EmergencyTeamBase>()
                .ToTable("Emergency_Team_Base")
                .HasKey(e => e.Id);

            modelBuilder.Entity<FireFighters>()
                .ToTable("FireFighters_Team")
                .HasBaseType<EmergencyTeamBase>();

            modelBuilder.Entity<INEM>()
                .ToTable("INEM_Team")
                .HasBaseType<EmergencyTeamBase>();

            modelBuilder.Entity<TeamMember>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).UseIdentityColumn();

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.TeamMembers)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TeamMember_EmergencyTeamBase");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.TeamMemberships)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TeamMember_Person");
            });

            modelBuilder.Entity<TeamIncident>()
                   .HasOne(ti => ti.Team)
                   .WithMany(t => t.TeamIncidents)
                   .HasForeignKey(ti => ti.TeamId);

            modelBuilder.Entity<TeamIncident>()
                .HasOne(ti => ti.Incident)
                .WithMany(i => i.TeamIncidents)
                .HasForeignKey(ti => ti.IncidentId);

            modelBuilder.Entity<Vehicle>()
                .ToTable("Vehicles")
                .HasKey(v => v.Id);

            modelBuilder.Entity<Ambulance>()
                .ToTable("Ambulances")
                .HasBaseType<Vehicle>();

            modelBuilder.Entity<Boat>()
                .ToTable("Boats")
                .HasBaseType<Vehicle>();

            modelBuilder.Entity<FireTruck>()
                .ToTable("FireTrucks")
                .HasBaseType<Vehicle>();

            modelBuilder.Entity<Heli>()
                .ToTable("Helis")
                .HasBaseType<Vehicle>();

            modelBuilder.Entity<LiftingMeans>()
                .ToTable("Lifting_Means")
                .HasBaseType<Vehicle>();

            modelBuilder.Entity<LogisticalSupport>()
                .ToTable("Logistical_Supports")
                .HasBaseType<Vehicle>();

            modelBuilder.Entity<MotorBike>()
                .ToTable("MotorBikes")
                .HasBaseType<Vehicle>();

            modelBuilder.Entity<VehicleIncident>()
                .HasKey(vi => new { vi.VehicleId, vi.IncidentId });

            modelBuilder.Entity<VehicleIncident>()
                .HasOne(vi => vi.Vehicle)
                .WithMany(v => v.VehicleIncidents)
                .HasForeignKey(vi => vi.VehicleId);

            modelBuilder.Entity<VehicleIncident>()
                .HasOne(vi => vi.Incident)
                .WithMany(i => i.VehicleIncidents)
                .HasForeignKey(vi => vi.IncidentId);

            modelBuilder.Entity<VehicleEquipment>()
                .HasKey(ve => new { ve.VehicleId, ve.EquipmentId });

            modelBuilder.Entity<VehicleEquipment>()
                .HasOne(ve => ve.Vehicle)
                .WithMany(v => v.VehicleEquipments)
                .HasForeignKey(ve => ve.VehicleId);

            modelBuilder.Entity<VehicleEquipment>()
                .HasOne(ve => ve.Equipment)
                .WithMany(e => e.VehicleEquipments)
                .HasForeignKey(ve => ve.EquipmentId);
        }
        #endregion


        #region Database Connection
        /// <summary>
        /// Configures the database connection settings
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=CLAUDIO\\SQLEXPRESS;Database=TP_POO_Emergency_DB;Trusted_Connection=True;Encrypt=False");
        }
        #endregion
    }
}
