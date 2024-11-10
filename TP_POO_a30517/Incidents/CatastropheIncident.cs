
//-----------------------------------------------------------------
//    <copyright file="CatastropheIncident.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>02-11-2024</date>
//    <author>Cláudio Fernandes</author>
//    <summary>
//     Defines the CatastropheIncident class, a specialized type of Incident.
//    </summary>
//-----------------------------------------------------------------

using TP_POO_a30517.Enums;

namespace TP_POO_a30517.Incidents
{
    /// <summary>
    /// Represents a catastrophe incident, derived from the base Incident class.
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
        public string CatastropheType
        {
            get => catastropheType;
            set => catastropheType = value ?? throw new ArgumentException("O tipo de catástrofe é obrigatório");
        }

        public double AffectedAreaCatastrophe
        {
            get => affectedAreaCatastrophe;
            set => affectedAreaCatastrophe = value;
        }

        public int PeopleAffectedCatastrophe
        {
            get => peopleAffectedCatastrophe;
            set => peopleAffectedCatastrophe = value;
        }

        public double IntensityCatastrophe
        {
            get => intensityCatastrophe;
            set => intensityCatastrophe = value;
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the CatastropheIncident class.
        /// </summary>
        /// <param name="description"></param>
        /// <param name="created"></param>
        /// <param name="location"></param>
        /// <param name="severity"></param>
        /// <param name="type"></param>
        /// <param name="status"></param>
        /// <param name="equipmentUsed"></param>
        /// <param name="teamType"></param>
        /// <param name="catastropheType"></param>
        /// <param name="affectedAreaCatastrophe"></param>
        /// <param name="peopleAffectedCatastrophe"></param>
        /// <param name="intensityCatastrophe"></param>
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
                   $"Tipo de Catástrofe: {CatastropheType}\n" +
                   $"Área Afetada: {AffectedAreaCatastrophe} m²\n" +
                   $"Pessoas Afetadas: {PeopleAffectedCatastrophe}\n" +
                   $"Intensidade: {IntensityCatastrophe}";
        }
        #endregion
    }
}
