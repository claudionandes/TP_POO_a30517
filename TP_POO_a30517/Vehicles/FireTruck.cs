
//-----------------------------------------------------------------
//    <copyright file="FireTruck.cs" company="IPCA">
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
    public class FireTruck : Vehicles
    {
        #region Private Properties
        private int tankCapacity;
        #endregion

        #region Public Properties
        public int TankCapacity
        {
            get => tankCapacity;
            set => tankCapacity = value > 0 ? value : 0;
        }
        #endregion

        #region Constructors
        public FireTruck(string vehicleRegist, DateOnly yearOfRegist, VehiclesType type, string brand, string vehicleModel, DateOnly inspDate, VehiclesStatus status, int tankCapacity)
            : base(vehicleRegist, yearOfRegist, type, brand, vehicleModel, inspDate, status)
        {
            TankCapacity = tankCapacity;
        }
        #endregion

        #region Public Methods
        public override string ReturnsValuesVehicles()
        {
            return base.ReturnsValuesVehicles() + "\n" +
                   $"Capacidade do Tanque: {TankCapacity} litros";
        }
        #endregion
    }
}
