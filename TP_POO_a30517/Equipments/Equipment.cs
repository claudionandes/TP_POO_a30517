
//-----------------------------------------------------------------
//    <copyright file="Equipment.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>30-10-2024</date>
//    <author>Cláudio Fernandes</author>
//    <summary>
//     Defines the Equipment class for managing emergency equipment.
//    </summary>
//-----------------------------------------------------------------


using TP_POO_a30517.Enums;
using TP_POO_a30517.Relations;

namespace TP_POO_a30517.Equipments
{
    /// <summary>
    /// Represents a piece of emergency equipment.
    /// </summary>
    public class Equipment
    {
        #region Private Properties   
        private int id;
        private string name;
        private EquipmentType type;
        private int quantityAvailable;
        private EquipmentStatus status;
        #endregion

        #region Public Properties        
        public int Id
        {
            get => id;
            set => id = value;
        }

        public string Name
        {
            get => name;
            set => name = !string.IsNullOrEmpty(value) ? value : throw new ArgumentException("Nome não pode estar vazio");
        }

        public EquipmentType Type
        {
            get => type; 
            set => type = value;
        }

        public int QuantityAvailable
        {
            get => quantityAvailable;
            set => quantityAvailable = value >= 0 ? value : throw new ArgumentException("Quantidade tem que ser igual ou superior a zero");
        }

        public EquipmentStatus Status
        {
            get => status;
            set => status = value;
        }

        public ICollection<EquipmentIncident> EquipmentIncidents { get; set; }
        public ICollection<VehicleEquipment> VehicleEquipments { get; set; } = new List<VehicleEquipment>();

        #endregion

        #region Construtors  
        /// <summary>
        /// Initializes a new instance of the Equipment class.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="quantityAvailable"></param>
        /// <param name="status"></param>
        public Equipment (string name, EquipmentType type, int quantityAvailable, EquipmentStatus status)
        {
            Name = name;
            Type = type;
            QuantityAvailable = quantityAvailable;
            Status = status;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Returns a string representation of the equipment's details.
        /// </summary>
        public string ReturnsValuesEquipment()
        {
            return $"ID: {Id}\n" +
                   $"Nome: {Name}\n" +
                   $"Tipo: {Type}\n" +
                   $"Stock: {QuantityAvailable}\n" +
                   $"Estado: {Status}\n";
        }
        #endregion
    }
}
