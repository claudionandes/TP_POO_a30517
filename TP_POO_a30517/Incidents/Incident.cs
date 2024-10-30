﻿
//-----------------------------------------------------------------
//    <copyright file="Incident.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>30-10-2024</date>
//    <author>Cláudio Fernandes</author>
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using TP_POO_a30517.Enums;
using TP_POO_a30517.Equipments;
using TP_POO_a30517.Models;
using TP_POO_a30517.Teams;

namespace TP_POO_a30517.Incidents
{
    /// <summary>
    /// Public class Incident
    /// </summary>
    public abstract class Incident
    {
        #region Private Properties        
        private int id;
        private string description;
        private DateTime created;
        private string location;
        private IncidentSeverityLevel severity;
        private IncidentType type;
        private IncidentStatus status;
        private List<Equipment> equipmentUsed;
        private RescueTeam rescueTeam;
        #endregion

        #region Public Properties        
        /// <summary>
        /// Gets or sets the properties for the incident.
        /// </summary>
        public int Id
        {
            get => id; 
            set => id = value;
        }
        public string Description
        {
            get => description;
            set => description = value;
        }
        public DateTime Created
        {
            get => created;
            set => created = value;
        }
        public string Location
        {
            get => location; 
            set => location = value;
        }
        public IncidentSeverityLevel Severity
        {
            get => severity; 
            set => severity = value;
        }

        public IncidentType Type
        {
            get => type; 
            set => type = value;
        }
        public IncidentStatus Status
        {
            get => status; 
            set => status = value;
        }

        public List<Equipment> EquipmentUsed
        {
            get => equipmentUsed; 
            set => equipmentUsed = value;
        }
        public RescueTeam RescueTeam
        {
            get => rescueTeam;
            set => rescueTeam = value;
        }
        #endregion

        #region Construtors        
        /// <summary>
        /// Initializes a new instance of the <see cref="Incident"/> class.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <param name="created">The created.</param>
        /// <param name="location">The location.</param>
        /// <param name="severity">The severity.</param>
        /// <param name="type">The type.</param>
        /// <param name="status">The status.</param>
        /// <param name="equipmentUsed">The equipment used.</param>
        /// <param name="rescueTeam">The rescue team.</param>
        public Incident (string description, DateTime created, string location, IncidentSeverityLevel severity, IncidentType type, IncidentStatus status, List<Equipment> equipmentUsed, RescueTeam rescueTeam)
        {
            this.Description = description;
            this.Created = created;
            this.Location = location;
            this.Severity = severity;
            this.Type = type;
            this.Status = status;
            this.EquipmentUsed = equipmentUsed;
            this.RescueTeam = rescueTeam;
        }
        #endregion

        #region Public Methods
        public virtual string ReturnsValues()
        {
            return $"ID: {Id}\n" +
                   $"Description: {Description}\n" +
                   $"Created: {Created}\n" +
                   $"Location: {Location}\n" +
                   $"Severity: {Severity}\n" +
                   $"Type: {Type}\n" +
                   $"Status: {Status}\n" +
                   $"Equipment Used: {string.Join(", ", EquipmentUsed.Select(e => e.Name))}\n" +
                   $"Rescue Team: {RescueTeam}";
        }
        #endregion
    }
}