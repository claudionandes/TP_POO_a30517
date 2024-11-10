
//-----------------------------------------------------------------
//    <copyright file="LiftingMeans.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>31-10-2024</date>
//    <author>Cláudio Fernandes</author>
//-----------------------------------------------------------------

using TP_POO_a30517.Enums;

namespace TP_POO_a30517.Vehicles
{
    /// <summary>
    /// Represents a lifting means vehicle used in emergency response operations.
    /// </summary>
    public class LiftingMeans : Vehicle
    {
        #region Private Properties
        private int liftingCapacity;
        private int maxHeight;
        private EquipmentType equipmentType;
        #endregion

        #region Public Properties
        public int LiftingCapacity
        {
            get => liftingCapacity;
            set => liftingCapacity = value > 0 ? value : 0;
        }

        public int MaxHeight
        {
            get => maxHeight;
            set => maxHeight = value > 0 ? value : 0;
        }

        public EquipmentType EquipmentType
        {
            get => equipmentType;
            set => equipmentType = value;
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the LiftingMeans class.
        /// </summary>
        /// <param name="vehicleRegist">The registration number of the vehicle.</param>
        /// <param name="yearOfRegist">The year of registration.</param>
        /// <param name="type">The type of the vehicle.</param>
        /// <param name="brand">The brand of the vehicle.</param>
        /// <param name="vehicleModel">The model of the vehicle.</param>
        /// <param name="inspDate">The inspection date.</param>
        /// <param name="status">The current status of the vehicle.</param>
        /// <param name="liftingCapacity">The maximum lifting capacity.</param>
        /// <param name="maxHeight">The maximum height for lifting.</param>
        /// <param name="equipmentType">The type of equipment associated with the vehicle.</param>
        public LiftingMeans(string vehicleRegist, DateOnly yearOfRegist, VehiclesType type, string brand, string vehicleModel, DateOnly inspDate, VehiclesStatus status,
                            int liftingCapacity, int maxHeight, EquipmentType equipmentType)
            : base(vehicleRegist, yearOfRegist, type, brand, vehicleModel, inspDate, status)
        {
            LiftingCapacity = liftingCapacity;
            MaxHeight = maxHeight;
            EquipmentType = equipmentType;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Returns details about the lifting means in a formatted string.
        /// </summary>
        /// <returns>A string containing details about the lifting means.</returns>
        public override string ReturnsValuesVehicles()
        {
            return base.ReturnsValuesVehicles() + "\n" +
                   $"Capacidade de Elevação: {LiftingCapacity} kg\n" +
                   $"Altura Máxima de Elevação: {MaxHeight} m\n" +
                   $"Tipo de Equipamento: {EquipmentType}";
        }
        #endregion
    }
}
