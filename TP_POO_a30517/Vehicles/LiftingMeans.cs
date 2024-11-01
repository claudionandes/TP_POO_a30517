
//-----------------------------------------------------------------
//    <copyright file="LiftingMeans.cs" company="IPCA">
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
