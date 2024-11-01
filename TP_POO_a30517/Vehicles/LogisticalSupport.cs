
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
        public LogisticalSupport(string vehicleRegist, DateOnly yearOfRegist, VehiclesType type, string brand, string vehicleModel, DateOnly inspDate, VehiclesStatus status, int capacity, EquipmentType equipment)
            : base(vehicleRegist, yearOfRegist, type, brand, vehicleModel, inspDate, status)
        {
            Capacity = capacity;
            Equipment = equipment;
        }
        #endregion

        #region Public Methods
        public override string ReturnsValuesVehicles()
        {
            return base.ReturnsValuesVehicles() + "\n" +
                   $"Capacidade: {Capacity} kg\n" +
                   $"Equipamento: {Equipment}";
        }
        #endregion
    }
}
