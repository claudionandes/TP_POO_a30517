
//-----------------------------------------------------------------
//    <copyright file="CatastropheIncident.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>02-11-2024</date>
//    <author>Cláudio Fernandes</author>
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_POO_a30517.Enums;

namespace TP_POO_a30517.Incidents
{
    /// <summary>
    /// Public class CatastropheIncident derived from Incident
    /// </summary>
    public class CatastropheIncident : Incident
    {
        #region Private Properties
        private string catastropheType;
        private double affectedAreaCatastrophe;
        private int peopleAffectedCatastrophe;
        private double intensityCatastrophe; // e.g., Richter scale for earthquakes
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or sets the type of catastrophe (e.g., Earthquake, Flood, Tsunami).
        /// </summary>
        public string CatastropheType
        {
            get => catastropheType;
            set => catastropheType = value ?? throw new ArgumentException("O tipo de catástrofe é obrigatório");
        }

        /// <summary>
        /// Gets or sets the affected area of the catastrophe.
        /// </summary>
        public double AffectedAreaCatastrophe
        {
            get => affectedAreaCatastrophe;
            set => affectedAreaCatastrophe = value;
        }

        /// <summary>
        /// Gets or sets the number of people affected by the catastrophe.
        /// </summary>
        public int PeopleAffectedCatastrophe
        {
            get => peopleAffectedCatastrophe;
            set => peopleAffectedCatastrophe = value;
        }

        /// <summary>
        /// Gets or sets the intensity of the catastrophe (if applicable).
        /// </summary>
        public double IntensityCatastrophe
        {
            get => intensityCatastrophe;
            set => intensityCatastrophe = value;
        }
        #endregion

        #region Constructors
        public CatastropheIncident(string description, DateTime created, string location, IncidentSeverityLevel severity,
                                   IncidentType type, IncidentStatus status, List<EquipmentType> equipmentUsed, TeamType teamType,
                                   string catastropheType, double affectedAreaCatastrophe, int peopleAffectedCatastrophe, double intensityCatastrophe)
            : base(description, created, location, severity, type, status, equipmentUsed, teamType)
        {
            CatastropheType = catastropheType;
            AffectedAreaCatastrophe = affectedAreaCatastrophe;
            PeopleAffectedCatastrophe = peopleAffectedCatastrophe;
            IntensityCatastrophe = intensityCatastrophe;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Returns details specific to CatastropheIncident properties.
        /// </summary>
        /// <returns>A string with detailed information about the catastrophe incident.</returns>
        public override string ReturnsValuesIncident()
        {
            return base.ReturnsValuesIncident() + "\n" +
                   $"ID: {Id}\n" +
                   $"Tipo de Catástrofe: {CatastropheType}\n" +
                   $"Área Afetada: {AffectedAreaCatastrophe} m²\n" +
                   $"Pessoas Afetadas: {PeopleAffectedCatastrophe}\n" +
                   $"Intensidade: {IntensityCatastrophe}";
        }
        #endregion
    }
}
