
//-----------------------------------------------------------------
//    <copyright file="Vehicles.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>30-10-2024</date>
//    <author>Cláudio Fernandes</author>
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TP_POO_a30517.Enums;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TP_POO_a30517.Vehicles
{
    public abstract class Vehicle
    {
        #region Private Properties        
        private string vehicleRegist { get; set; }
        private DateOnly yearOfRegist { get; set; }
        private VehiclesType type { get; set; }
        private string brand { get; set; }
        private string vehicleModel { get; set; }
        private DateOnly inspDate { get; set; }
        private VehiclesStatus status { get; set; }
        #endregion

        #region Public Properties   
        public string VehicleRegist
        {
            get => vehicleRegist;
            set => vehicleRegist = value;
        }
        public DateOnly YearofRegist
        {
            get => yearOfRegist;
            set => yearOfRegist = value;
        }
        public VehiclesType Type
        {
            get => type; 
            set => type = value;
        }
        public string Brand
        {
            get => brand; 
            set => brand = value;
        }
        public string VehicleModel
        {
            get => vehicleModel; 
            set => vehicleModel = value;
        }
        public DateOnly InspDate
        {
            get => inspDate; 
            set => inspDate = value;
        }
        public VehiclesStatus Status
        {
            get => status; 
            set => status = value;
        }
        #endregion

        #region Constructors  
        /// <summary>
        /// Initializes a new instance of the <see cref="Vehicle"/> class.
        /// </summary>
        /// <param name="vehicleRegist"></param>
        /// <param name="yearofRegist"></param>
        /// <param name="type"></param>
        /// <param name="brand"></param>
        /// <param name="vehicleModel"></param>
        /// <param name="inspDate"></param>
        /// <param name="status"></param>
        public Vehicle(string vehicleRegist, DateOnly yearofRegist, VehiclesType type, string brand, string vehicleModel, DateOnly inspDate, VehiclesStatus status)
        {
            this.VehicleRegist = vehicleRegist;
            DateOnly YearofRegist = yearofRegist;
            VehiclesType Type = type;
            this.Brand = brand;
            this.VehicleModel = vehicleModel;
            DateOnly InspDate = inspDate;
            this.Status = status;
        }
        #endregion

        #region Public Methods    
        public virtual string ReturnsValuesVehicles()
        {
            return $"Matrícula: {VehicleRegist}\n" +
                   $"Ano: {YearofRegist}\n" +
                   $"Tipo: {Type}\n" +
                   $"Marca: {brand}\n" +
                   $"Modelo: {VehicleModel}\n" +
                   $"Inspeção: {InspDate}\n" +
                   $"Estado: {Status}";
        }
        #endregion
    }
}
