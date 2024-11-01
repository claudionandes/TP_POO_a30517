
//-----------------------------------------------------------------
//    <copyright file="MotorBike.cs" company="IPCA">
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
using TP_POO_a30517.Vehicles;

namespace TP_POO_a30517.Vehicles
{
    public class MotorBike : Vehicles
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
        public MotorBike(string vehicleRegist, DateOnly yearOfRegist, VehiclesType type, string brand, string vehicleModel, DateOnly inspDate, VehiclesStatus status, int engineCapacity, bool medicalBagSupport)
            : base(vehicleRegist, yearOfRegist, type, brand, vehicleModel, inspDate, status)
        {
            this.EngineCapacity = engineCapacity;
            this.MedicalBagSupport = medicalBagSupport;
        }
        #endregion

        #region Public Methods
        public override string ReturnsValuesVehicles()
        {
            return base.ReturnsValuesVehicles() + "\n" +
                   $"Cilindrada do Motor: {EngineCapacity} cc\n" +
                   $"Suporte para Equipamento Médico: {(MedicalBagSupport ? "Sim" : "Não")}";
        }
        #endregion
    }
}
