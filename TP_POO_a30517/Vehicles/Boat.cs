
//-----------------------------------------------------------------
//    <copyright file="Boat.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>01-11-2024</date>
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
