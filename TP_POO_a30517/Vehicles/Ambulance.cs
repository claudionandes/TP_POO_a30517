
//-----------------------------------------------------------------
//    <copyright file="Ambulance.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>31-10-2024</date>
//    <author>Cláudio Fernandes</author>
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_POO_a30517.Enums;
using TP_POO_a30517.Vehicles;

namespace TP_POO_a30517.Vehicles
{
    public class Ambulance : Vehicle
    {
        #region Private Properties
        private int patientCapacity { get; set; }
        private int crewCapacity { get; set; }
        private EquipmentType medicalEquipment { get; set; }
        #endregion

        #region Public Properties
        public int PatientCapacity
        {
            get => patientCapacity;
            set => patientCapacity = value > 0 ? value : throw new ArgumentException("Número da Capacidade de Pacientes tem que ser maior que zero");
        }

        public int CrewCapacity
        {
            get => crewCapacity;
            set => crewCapacity = value > 0 ? value : throw new ArgumentException("Número da Capacidade da tripulação tem que ser maior que zero");
        }

        public EquipmentType MedicalEquipment
        {
            get => medicalEquipment;
            set => medicalEquipment = value;
        }
        #endregion

        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="vehicleRegist"></param>
        /// <param name="yearofRegist"></param>
        /// <param name="type"></param>
        /// <param name="brand"></param>
        /// <param name="vehicleModel"></param>
        /// <param name="inspDate"></param>
        /// <param name="status"></param>
        /// <param name="patientCapacity"></param>
        /// <param name="crewCapacity"></param>
        /// <param name="medicalEquipment"></param>
        public Ambulance(string vehicleRegist, DateOnly yearofRegist, VehiclesType type,string brand, string vehicleModel, DateOnly inspDate, VehiclesStatus status,
                         int patientCapacity, int crewCapacity, EquipmentType medicalEquipment)
            : base(vehicleRegist, yearofRegist, type, brand, vehicleModel, inspDate, status)
        {
            this.PatientCapacity = patientCapacity;
            this.CrewCapacity = crewCapacity;
            this.MedicalEquipment = medicalEquipment;
        }
        #endregion

        #region Public Methods
        public override string ReturnsValuesVehicles()
        {
            return base.ReturnsValuesVehicles() + "\n" +
                   $"Capacidade de Pacientes: {PatientCapacity}\n" +
                   $"Capacidade de Tripulação: {CrewCapacity}\n" +
                   $"Equipamento Médico: {MedicalEquipment}";
        }
        #endregion
    }
}
