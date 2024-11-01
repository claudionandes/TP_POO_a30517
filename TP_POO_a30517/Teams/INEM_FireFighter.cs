
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
    public class INEM_FireFighter : EmergencyTeamBase
    {
        #region Private Properties        
        /// <summary>
        /// The properties for the rescue team
        /// </summary>
        private List<Person> members;
        #endregion

        #region Public Properties        
        /// <summary>
        /// Gets or sets for the rescue team.
        /// </summary>
        public List<Person> Members
        {
            get => members;
            set => members = value ?? new List<Person>();
        }
        #endregion

        #region Constructors        
        /// <summary>
        /// Initializes a new instance of the <see cref="INEM_FireFighter"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="members">The members.</param>
        /// <param name="status">The status.</param>
        /// <param name="vehicleType">The type of vehicle.</param>
        /// <param name="equipmentType">The type of equipment.</param>
        public INEM_FireFighter(string name, List<Person> members, TeamStatus status, VehiclesType vehicleType, EquipmentType equipmentType)
            : base(name, status, vehicleType, equipmentType)
        {
            Members = members ?? new List<Person>();
        }
        #endregion

        #region Public Methods
        public override string ReturnTeamDetails()
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

        #endregion
    }
}
