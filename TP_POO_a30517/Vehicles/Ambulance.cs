
//-----------------------------------------------------------------
//    <copyright file="Ambulance.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>31-10-2024</date>
//    <author>Cláudio Fernandes</author>
//-----------------------------------------------------------------

using TP_POO_a30517.Enums;

namespace TP_POO_a30517.Vehicles
{
    /// <summary>
    /// Represents an ambulance vehicle in the emergency response system.
    /// </summary>
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
        /// Initializes a new instance of the Ambulance class.
        /// </summary>
        /// <param name="vehicleRegist">The registration number of the vehicle.</param>
        /// <param name="yearOfRegist">The year of registration.</param>
        /// <param name="type">The type of the vehicle.</param>
        /// <param name="brand">The brand of the vehicle.</param>
        /// <param name="vehicleModel">The model of the vehicle.</param>
        /// <param name="inspDate">The inspection date.</param>
        /// <param name="status">The current status of the vehicle.</param>
        /// <param name="patientCapacity">The capacity for patients.</param>
        /// <param name="crewCapacity">The capacity for crew members.</param>
        /// <param name="medicalEquipment">The type of medical equipment available.</param>
        public Ambulance(string vehicleRegist, DateOnly yearOfRegist, VehiclesType type,string brand, string vehicleModel, DateOnly inspDate, VehiclesStatus status,
                         int patientCapacity, int crewCapacity, EquipmentType medicalEquipment)
            : base(vehicleRegist, yearOfRegist, type, brand, vehicleModel, inspDate, status)
        {
            PatientCapacity = patientCapacity;
            CrewCapacity = crewCapacity;
            MedicalEquipment = medicalEquipment;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Returns details about the ambulance in a formatted string.
        /// </summary>
        /// <returns>A string containing details about the ambulance.</returns>
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
