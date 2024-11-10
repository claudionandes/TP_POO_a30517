
//-----------------------------------------------------------------
//    <copyright file="Vehicles.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>30-10-2024</date>
//    <author>Cláudio Fernandes</author>
//-----------------------------------------------------------------

using TP_POO_a30517.Enums;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TP_POO_a30517.Relations;

namespace TP_POO_a30517.Vehicles
{
    /// <summary>
    /// Represents the base class for all vehicles in the emergency response system.
    /// </summary>
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
        /// Initializes a new instance of the Vehicle class.
        /// </summary>
        /// <param name="vehicleRegist">The registration number of the vehicle.</param>
        /// <param name="yearOfRegist">The year of registration.</param>
        /// <param name="type">The type of the vehicle.</param>
        /// <param name="brand">The brand of the vehicle.</param>
        /// <param name="vehicleModel">The model of the vehicle.</param>
        /// <param name="inspDate">The inspection date.</param>
        /// <param name="status">The current status of the vehicle.</param>
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
        /// <summary>
        /// Returns details about the vehicle in a formatted string.
        /// </summary>
        /// <returns>A string containing details about the vehicle.</returns>
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
