
//-----------------------------------------------------------------
//    <copyright file="INEM.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>30-10-2024</date>
//    <author>Cláudio Fernandes</author>
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_POO_a30517.Enums;
using TP_POO_a30517.Models;

namespace TP_POO_a30517.Teams
{
    /// <summary>
    /// Class INEM
    /// </summary>
    public class INEM
    {
        #region Private Properties
        private static int nextId = 1;
        private int id { get; set; }
        private string name { get; set; }
        private TeamStatus status { get; set; } = TeamStatus.Disponível;
        private VehiclesType vehicleType { get; set; }
        private EquipmentType equipmentType { get; set; }
        #endregion

        #region Public Properties        
        public int Id
        {
            get => id;
            set => id = value;
        }
        public string Name
        {
            get => name;
            set => name = value;
        }
        public TeamStatus Status
        {
            get => status;
            set => status = value;
        }
        public Doctor TeamDoctor { get; set; }
        public Nurse TeamNurse { get; set; }
        public EmergencyTechnician TeamTechnician { get; set; }

        public VehiclesType VehicleType
        {
            get => vehicleType;
            set => vehicleType = value;
        }

        public EquipmentType EquipmentType
        {
            get => equipmentType;
            set => equipmentType = value;
        }
        #endregion

        #region Constructors
        public INEM(string name, Doctor doctor, Nurse nurse, EmergencyTechnician technician, VehiclesType vehicleType, EquipmentType equipmentType, TeamStatus status)
        {
            Id = GenerateId();
            Name = name;
            TeamDoctor = doctor;
            TeamNurse = nurse;
            TeamTechnician = technician;
            VehicleType = vehicleType;
            EquipmentType = equipmentType;
            Status = status;
        }
        #endregion

        #region Public Methods
        public string TeamDetailsINEM()
        {
            return $"ID: {Id}\n" +
                   $"Name: {Name}\n" +
                   $"Estado: {Status}\n" +
                   $"Tipo de Véiculo: {VehicleType}\n" +
                   $"Tipo de Equipamento: {EquipmentType}\n\n" +
                   $"Médico:\n{TeamDoctor.ReturnsValuesPerson()}\n\n" +
                   $"Enfermeiro:\n{TeamNurse.ReturnsValuesPerson()}\n\n" +
                   $"Técnico de Emergência:\n{TeamTechnician.ReturnsValuesPerson()}";
        }
        #endregion

        #region Private Methods             
        private static int GenerateId()
        {
            return nextId++;
        }
        #endregion
    }
}
