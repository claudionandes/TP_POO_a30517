
//-----------------------------------------------------------------
//    <copyright file="Boat.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>01-11-2024</date>
//    <author>Cláudio Fernandes</author>
//-----------------------------------------------------------------

using TP_POO_a30517.Enums;

namespace TP_POO_a30517.Vehicles
{
    /// <summary>
    /// Represents a boat used in the emergency response system.
    /// </summary>
    public class Boat : Vehicle
    {
        #region Private Properties
        private int passengerCapacity;
        private EquipmentType equipment;
        private double comprimento;
        private int motor;
        #endregion

        #region Public Properties
        public int PassengerCapacity
        {
            get => passengerCapacity;
            set => passengerCapacity = value > 0 ? value : throw new ArgumentException("Número da Capacidade de passageiros tem que ser maior que zero");
        }

        public EquipmentType Equipment
        {
            get => equipment;
            set => equipment = value;
        }

        public double Comprimento
        {
            get => comprimento;
            set => comprimento = value;
        }

        public int Motor
        {
            get => motor;
            set => motor =value;
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the Boat class.
        /// </summary>
        /// <param name="vehicleRegist">The registration number of the vehicle.</param>
        /// <param name="yearOfRegist">The year of registration.</param>
        /// <param name="type">The type of the vehicle.</param>
        /// <param name="brand">The brand of the vehicle.</param>
        /// <param name="vehicleModel">The model of the vehicle.</param>
        /// <param name="inspDate">The inspection date.</param>
        /// <param name="status">The current status of the vehicle.</param>
        /// <param name="passengerCapacity">The capacity for passengers.</param>
        /// <param name="equipment">The type of equipment available.</param>
        /// <param name="comprimento">The length of the boat.</param>
        /// <param name="motor">The power of the motor.</param>
        public Boat(string vehicleRegist, DateOnly yearOfRegist, VehiclesType type, string brand, string vehicleModel, DateOnly inspDate, VehiclesStatus status,
                    int passengerCapacity, EquipmentType equipment, double comprimento, int motor)
            : base(vehicleRegist, yearOfRegist, type, brand, vehicleModel, inspDate, status)
        {
            PassengerCapacity = passengerCapacity;
            Equipment = equipment;
            Comprimento = comprimento;
            Motor = motor;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Returns details about the boat in a formatted string.
        /// </summary>
        /// <returns>A string containing details about the boat.</returns>
        public override string ReturnsValuesVehicles()
        {
            return base.ReturnsValuesVehicles() + "\n" +
                   $"Capacidade de Passageiros: {PassengerCapacity}\n" +
                   $"Equipamento: {Equipment}\n" +
                   $"Comprimento: {Comprimento} m\n" +
                   $"Motor: {Motor} Hp";
        }
        #endregion
    }
}
