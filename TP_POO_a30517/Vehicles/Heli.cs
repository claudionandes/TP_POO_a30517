
//-----------------------------------------------------------------
//    <copyright file="Heli.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>31-10-2024</date>
//    <author>Cláudio Fernandes</author>
//-----------------------------------------------------------------

using TP_POO_a30517.Enums;

namespace TP_POO_a30517.Vehicles
{
    /// <summary>
    /// Represents a helicopter used in emergency response operations.
    /// </summary>
    public class Heli : Vehicle
    {
        #region Private Properties
        private int passengerCapacity;
        private int cargoCapacity;
        private string fuelType;
        #endregion

        #region Public Properties
        public int PassengerCapacity
        {
            get => passengerCapacity;
            set => passengerCapacity = value > 0 ? value : 0;
        }

        public int CargoCapacity
        {
            get => cargoCapacity;
            set => cargoCapacity = value > 0 ? value : 0;
        }

        public string FuelType
        {
            get => fuelType;
            set => fuelType = value ?? "Desconhecido";
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the Heli class.
        /// </summary>
        /// <param name="vehicleRegist">The registration number of the vehicle.</param>
        /// <param name="yearOfRegist">The year of registration.</param>
        /// <param name="type">The type of the vehicle.</param>
        /// <param name="brand">The brand of the vehicle.</param>
        /// <param name="vehicleModel">The model of the vehicle.</param>
        /// <param name="inspDate">The inspection date.</param>
        /// <param name="status">The current status of the vehicle.</param>
        /// <param name="passengerCapacity">The capacity for passengers.</param>
        /// <param name="cargoCapacity">The capacity for cargo.</param>
        /// <param name="fuelType">The type of fuel used.</param>
        public Heli(string vehicleRegist, DateOnly yearOfRegist, VehiclesType type, string brand,string vehicleModel, DateOnly inspDate, VehiclesStatus status,
                    int passengerCapacity, int cargoCapacity, string fuelType)
            : base(vehicleRegist, yearOfRegist, type, brand, vehicleModel, inspDate, status)
        {
            PassengerCapacity = passengerCapacity;
            CargoCapacity = cargoCapacity;
            FuelType = fuelType;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Returns details about the helicopter in a formatted string.
        /// </summary>
        /// <returns>A string containing details about the helicopter.</returns>
        public override string ReturnsValuesVehicles()
        {
            return base.ReturnsValuesVehicles() + "\n" +
                   $"Capacidade de Passageiros: {PassengerCapacity}\n" +
                   $"Capacidade de Carga: {CargoCapacity}\n" +
                   $"Tipo de Combustível: {FuelType}";
        }
        #endregion
    }
}
