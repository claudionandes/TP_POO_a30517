
//-----------------------------------------------------------------
//    <copyright file="LogisticalSupport.cs" company="IPCA">
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

namespace TP_POO_a30517.Vehicles
{
    /// <summary>
    /// Represents a logistical support vehicle used in emergency response operations.
    /// </summary>
    public class LogisticalSupport : Vehicle
    {
        #region Private Properties
        private int capacity;
        private EquipmentType equipment;
        #endregion

        #region Public Properties
        public int Capacity
        {
            get => capacity;
            set => capacity = value > 0 ? value : 0;
        }

        public EquipmentType Equipment
        {
            get => equipment;
            set => equipment = value;
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the LogisticalSupport class.
        /// </summary>
        /// <param name="vehicleRegist">The registration number of the vehicle.</param>
        /// <param name="yearOfRegist">The year of registration.</param>
        /// <param name="type">The type of the vehicle.</param>
        /// <param name="brand">The brand of the vehicle.</param>
        /// <param name="vehicleModel">The model of the vehicle.</param>
        /// <param name="inspDate">The inspection date.</param>
        /// <param name="status">The current status of the vehicle.</param>
        /// <param name="capacity">The maximum capacity for carrying supplies.</param>
        /// <param name="equipment">The type of equipment available on the vehicle.</param>
        public LogisticalSupport(string vehicleRegist, DateOnly yearOfRegist, VehiclesType type, string brand, string vehicleModel, DateOnly inspDate, VehiclesStatus status, int capacity, EquipmentType equipment)
            : base(vehicleRegist, yearOfRegist, type, brand, vehicleModel, inspDate, status)
        {
            Capacity = capacity;
            Equipment = equipment;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Returns details about the logistical support vehicle in a formatted string.
        /// </summary>
        /// <returns>A string containing details about the logistical support vehicle.</returns>
        public override string ReturnsValuesVehicles()
        {
            return base.ReturnsValuesVehicles() + "\n" +
                   $"Capacidade: {Capacity} kg\n" +
                   $"Equipamento: {Equipment}";
        }
        #endregion
    }
}
