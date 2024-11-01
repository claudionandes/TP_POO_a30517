
//-----------------------------------------------------------------
//    <copyright file="RescueTeam.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>30-10-2024</date>
//    <author>Cláudio Fernandes</author>
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_POO_a30517.Models;
using TP_POO_a30517.Enums;

namespace TP_POO_a30517.Teams
{
    /// <summary>
    /// Public class RescueTeam
    /// </summary>
    public class RescueTeam
    {
        #region Private Properties        
        /// <summary>
        /// The properties for the rescue team
        /// </summary>
        private static int nextId = 1;
        private int id;
        private string name;
        private List<Person> members;
        private TeamStatus status;
        private VehiclesType vehicleType;
        private EquipmentType equipmentType;
        #endregion

        #region Public Properties        
        /// <summary>
        /// Gets or sets for the rescue team.
        /// </summary>
        public int Id
        {
            get => id;
            set => id = value;
        }
        public string Name
        {
            get => name;
            set => name = value ?? "Não especificado";
        }
        public List<Person> Members
        {
            get => members;
            set => members = value ?? new List<Person>();
        }
        public TeamStatus Status
        {
            get => status;
            set => status = value;
        }

        public VehiclesType VehicleType
        {
            get => vehicleType;
            set => vehicleType = value;
        }

        public EquipmentType EquipmentType
        {
            get => equipmentType;
            set => equipmentType = value;
        }
        #endregion

        #region Constructors        
        /// <summary>
        /// Initializes a new instance of the <see cref="RescueTeam"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="members">The members.</param>
        /// <param name="status">The status.</param>
        /// <param name="vehicleType">The type of vehicle.</param>
        /// <param name="equipmentType">The type of equipment.</param>
        public RescueTeam(string name, List<Person> members, TeamStatus status, VehiclesType vehicleType, EquipmentType equipmentType)
        {
            Id = GenerateId();
            Name = name;
            Members = members ?? new List<Person>();
            Status = status;
            VehicleType = vehicleType;
            EquipmentType = equipmentType;
        }
        #endregion

        #region Public Methods
        public string TeamDetailsRescueTeam()
        {
            return $"ID: {Id}\n" +
                   $"Nome: {Name}\n" +
                   $"Membros: {string.Join(", ", Members.Select(m => m.Name))}\n" +
                   $"Estado: {Status}\n" +
                   $"Tipo de Veículo: {VehicleType}\n" +
                   $"Tipo de Equipamento: {EquipmentType}\n";
        }
        #endregion

        #region Private Methods             
        /// <summary>
        /// Generates the identifier.
        /// </summary>
        /// <returns></returns>
        private static int GenerateId()
        {
            return nextId++;
        }
        #endregion
    }
}
