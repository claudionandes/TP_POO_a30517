
//-----------------------------------------------------------------
//    <copyright file="FireIncident.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>30-10-2024</date>
//    <author>Cláudio Fernandes</author>
//-----------------------------------------------------------------

using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_POO_a30517.Enums;
using TP_POO_a30517.Equipments;
using TP_POO_a30517.Teams;

namespace TP_POO_a30517.Incidents
{
    /// <summary>
    /// Public class FireIncident derived from Incident
    /// </summary>
    public class FireIncident : Incident
    {
        #region Private Properties
        private double affectedAreaFire;
        private int peopleAffectedFire;
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or sets the affected area of the fire.
        /// </summary>
        public double AffectedAreaFire
        {
            get => affectedAreaFire;
            set => affectedAreaFire = value > 0 ? value : 0;
        }

        /// <summary>
        /// Gets or sets the number of people affected by the fire.
        /// </summary>
        public int PeopleAffectedFire
        {
            get => peopleAffectedFire;
            set => peopleAffectedFire = value >= 0 ? value : 0;
        }
        #endregion

        #region Constructors
        public FireIncident(string description, DateTime created, string location, IncidentSeverityLevel severity, IncidentType type,
                            IncidentStatus status, List<EquipmentType> equipmentUsed, TeamType teamType,
                            double affectedAreaFire, int peopleAffectedFire)
            : base(description, created, location, severity, type, status, equipmentUsed, teamType)
        {
            AffectedAreaFire = affectedAreaFire > 0 ? affectedAreaFire : throw new ArgumentException("A área afetada deve ser maior que zero");
            PeopleAffectedFire = peopleAffectedFire;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Returns details specific to FireIncident properties.
        /// </summary>
        /// <returns>A string with detailed information about the fire incident.</returns>
        public override string ReturnsValuesIncident()
        {
            return base.ReturnsValuesIncident() + "\n" +
                   $"ID: {Id}\n" +
                   $"Área Afetada: {AffectedAreaFire} m²\n" +
                   $"Pessoas Afetadas: {PeopleAffectedFire}";
        }
        #endregion
    }
}
