
//-----------------------------------------------------------------
//    <copyright file="FireIncident.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>30-10-2024</date>
//    <author>Cláudio Fernandes</author>
//    <summary>
//     Defines the FireIncident class, a specialized type of Incident.
//    </summary>
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
    /// Represents a fire incident, derived from the base Incident class.
    /// </summary>
    public class FireIncident : Incident
    {
        #region Private Properties
        private double affectedAreaFire;
        private int peopleAffectedFire;
        #endregion

        #region Public Properties>
        public double AffectedAreaFire
        {
            get => affectedAreaFire;
            set => affectedAreaFire = value > 0 ? value : 0;
        }

        public int PeopleAffectedFire
        {
            get => peopleAffectedFire;
            set => peopleAffectedFire = value >= 0 ? value : 0;
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the FireIncident class
        /// </summary>
        /// <param name="description"></param>
        /// <param name="created"></param>
        /// <param name="location"></param>
        /// <param name="severity"></param>
        /// <param name="type"></param>
        /// <param name="status"></param>
        /// <param name="equipmentUsed"></param>
        /// <param name="teamType"></param>
        /// <param name="affectedAreaFire"></param>
        /// <param name="peopleAffectedFire"></param>
        /// <exception cref="ArgumentException"></exception>
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
                   $"Área Afetada: {AffectedAreaFire} m²\n" +
                   $"Pessoas Afetadas: {PeopleAffectedFire}";
        }
        #endregion
    }
}
