
//-----------------------------------------------------------------
//    <copyright file="MotorBike.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>31-10-2024</date>
//    <author>Cláudio Fernandes</author>
//-----------------------------------------------------------------

using TP_POO_a30517.Enums;

namespace TP_POO_a30517.Vehicles
{
    /// <summary>
    /// Represents a motorcycle used in emergency response operations.
    /// </summary>
    public class MotorBike : Vehicle
    {
        #region Private Properties
        private int engineCapacity;
        private bool medicalBagSupport;
        #endregion

        #region Public Properties
        public int EngineCapacity
        {
            get => engineCapacity;
            set => engineCapacity = value;
        }

        public bool MedicalBagSupport
        {
            get => medicalBagSupport;
            set => medicalBagSupport = value;
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the MotorBike class.
        /// </summary>
        /// <param name="vehicleRegist">The registration number of the vehicle.</param>
        /// <param name="yearOfRegist">The year of registration.</param>
        /// <param name="type">The type of the vehicle.</param>
        /// <param name="brand">The brand of the vehicle.</param>
        /// <param name="vehicleModel">The model of the vehicle.</param>
        /// <param name="inspDate">The inspection date.</param>
        /// <param name="status">The current status of the vehicle.</param>
        /// <param name="engineCapacity">The engine capacity of the motorcycle.</param>
        /// <param name="medicalBagSupport">Indicates if it supports carrying a medical bag.</param>
        public MotorBike(string vehicleRegist, DateOnly yearOfRegist, VehiclesType type, string brand, string vehicleModel, DateOnly inspDate, VehiclesStatus status, int engineCapacity, bool medicalBagSupport)
            : base(vehicleRegist, yearOfRegist, type, brand, vehicleModel, inspDate, status)
        {
            EngineCapacity = engineCapacity;
            MedicalBagSupport = medicalBagSupport;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Returns details about the motorcycle in a formatted string.
        /// </summary>
        /// <returns>A string containing details about the motorcycle.</returns>
        public override string ReturnsValuesVehicles()
        {
            return base.ReturnsValuesVehicles() + "\n" +
                   $"Cilindrada do Motor: {EngineCapacity} cc\n" +
                   $"Suporte para Equipamento Médico: {(MedicalBagSupport ? "Sim" : "Não")}";
        }
        #endregion
    }
}
