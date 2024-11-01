
//-----------------------------------------------------------------
//    <copyright file="Heli.cs" company="IPCA">
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
    public class Heli : Vehicles
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
