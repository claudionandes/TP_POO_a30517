
//-----------------------------------------------------------------
//    <copyright file="FireIncident.cs" company="IPCA">
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
        private double affectedArea;
        private int peopleAffected;
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or sets the affected area of the fire.
        /// </summary>
        public double AffectedArea
        {
            get => affectedArea;
            set => affectedArea = value > 0 ? value : 0;
        }

        /// <summary>
        /// Gets or sets the number of people affected by the fire.
        /// </summary>
        public int PeopleAffected
        {
            get => peopleAffected;
            set => peopleAffected = value >= 0 ? value : 0;
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="FireIncident"/> class.
        /// </summary>
        /// <param name="description">The description of the incident.</param>
        /// <param name="created">The date of creation.</param>
        /// <param name="location">The location of the incident.</param>
        /// <param name="severity">The severity level.</param>
        /// <param name="type">The type of the incident.</param>
        /// <param name="status">The current status.</param>
        /// <param name="equipmentUsed">The list of equipment used.</param>
        /// <param name="rescueTeam">The assigned rescue team.</param>
        /// <param name="affectedArea">The area affected by the fire.</param>
        /// <param name="peopleAffected">The number of people affected by the fire.</param>
        public FireIncident(string description, DateTime created, string location, IncidentSeverityLevel severity, IncidentType type,
                            IncidentStatus status, List<Equipment> equipmentUsed, TeamType teamType,
                            double affectedArea, int peopleAffected)
            : base(description, created, location, severity, type, status, equipmentUsed, teamType)
        {
            AffectedArea = affectedArea > 0 ? affectedArea : throw new ArgumentException("A área afetada deve ser positiva");
            PeopleAffected = peopleAffected;
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
                   $"Área Afetada: {AffectedArea} m²\n" +
                   $"Pessoas Afetadas: {PeopleAffected}";
        }
        #endregion
    }
}
