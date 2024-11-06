
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
using TP_POO_a30517.Relations;

namespace TP_POO_a30517.Vehicles
{
    public abstract class Vehicle
    {
        #region Private Properties        
        private int id;
        private string vehicleRegist { get; set; }
        private DateOnly yearOfRegist { get; set; }
        private VehiclesType type { get; set; }
        private string brand { get; set; }
        private string vehicleModel { get; set; }
        private DateOnly inspDate { get; set; }
        private VehiclesStatus status { get; set; }
        #endregion

        #region Public Properties   
        public int Id
        {
            get => id;
            set => id = value;
        }
        public string VehicleRegist
        {
            get => vehicleRegist;
            set => vehicleRegist = !string.IsNullOrEmpty(value) ? value : throw new ArgumentException("Matrícula é obrigatória");
        }
        public DateOnly YearOfRegist
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

        public ICollection<VehicleIncident> VehicleIncidents { get; set; }
        public ICollection<VehicleEquipment> VehicleEquipments { get; set; } = new List<VehicleEquipment>();

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
        public Vehicle(string vehicleRegist, DateOnly yearOfRegist, VehiclesType type, string brand, string vehicleModel, DateOnly inspDate, VehiclesStatus status)
        {
            VehicleRegist = vehicleRegist;
            YearOfRegist = yearOfRegist;
            Type = type;
            Brand = brand;
            VehicleModel = vehicleModel;
            InspDate = inspDate;
            Status = status;
        }
        #endregion

        #region Public Methods    
        public virtual string ReturnsValuesVehicles()
        {
            return $"Matrícula: {VehicleRegist}\n" +
                   $"Ano: {YearOfRegist}\n" +
                   $"Tipo: {Type}\n" +
                   $"Marca: {brand}\n" +
                   $"Modelo: {VehicleModel}\n" +
                   $"Inspeção: {InspDate}\n" +
                   $"Estado: {Status}";
        }
        #endregion
    }
}
