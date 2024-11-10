
//-----------------------------------------------------------------
//    <copyright file="FireTruck.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>31-10-2024</date>
//    <author>Cláudio Fernandes</author>
//-----------------------------------------------------------------

using TP_POO_a30517.Enums;

namespace TP_POO_a30517.Vehicles
{
    /// <summary>
    /// Represents a fire truck used in emergency response operations.
    /// </summary>
    public class FireTruck : Vehicle
    {
        #region Private Properties
        private int tankCapacity;
        #endregion

        #region Public Properties
        public int TankCapacity
        {
            get => tankCapacity;
            set => tankCapacity = value > 0 ? value : throw new ArgumentException("Capacidade do tanque tem que ser maior que zero");
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the FireTruck class.
        /// </summary>
        /// <param name="vehicleRegist">The registration number of the vehicle.</param>
        /// <param name="yearOfRegist">The year of registration.</param>
        /// <param name="type">The type of the vehicle.</param>
        /// <param name="brand">The brand of the vehicle.</param>
        /// <param name="vehicleModel">The model of the vehicle.</param>
        /// <param name="inspDate">The inspection date.</param>
        /// <param name="status">The current status of the vehicle.</param>
        /// <param name="tankCapacity">The capacity of the water tank.</param>
        public FireTruck(string vehicleRegist, DateOnly yearOfRegist, VehiclesType type, string brand, string vehicleModel, DateOnly inspDate, VehiclesStatus status, int tankCapacity)
            : base(vehicleRegist, yearOfRegist, type, brand, vehicleModel, inspDate, status)
        {
            TankCapacity = tankCapacity;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Returns details about the fire truck in a formatted string.
        /// </summary>
        /// <returns>A string containing details about the fire truck.</returns>
        public override string ReturnsValuesVehicles()
        {
            return base.ReturnsValuesVehicles() + "\n" +
                   $"Capacidade do Tanque: {TankCapacity} litros";
        }
        #endregion
    }
}
