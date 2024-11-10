
//-----------------------------------------------------------------
//    <copyright file="MedicalIncident.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>30-10-2024</date>
//    <author>Cláudio Fernandes</author>
//    <summary>
//     Defines the MedicalIncident class, a specialized type of Incident.
//    </summary>
//-----------------------------------------------------------------

using TP_POO_a30517.Enums;


namespace TP_POO_a30517.Incidents
{
    public class MedicalIncident : Incident
    {
        #region Private Properties
        private string patientName;
        private int patientAge;
        private string medicalCondition;
        #endregion

        #region Public Properties
        public string PatientName
        {
            get => patientName;
            set => patientName = value;
        }

        public int PatientAge
        {
            get => patientAge;
            set => patientAge = value > 0 ? value : 0;
        }

        public string MedicalCondition
        {
            get => medicalCondition;
            set => medicalCondition = value;
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the MedicalIncident class
        /// </summary>
        /// <param name="description"></param>
        /// <param name="created"></param>
        /// <param name="location"></param>
        /// <param name="severity"></param>
        /// <param name="type"></param>
        /// <param name="status"></param>
        /// <param name="equipmentUsed"></param>
        /// <param name="teamType"></param>
        /// <param name="patientName"></param>
        /// <param name="patientAge"></param>
        /// <param name="medicalCondition"></param>
        public MedicalIncident(string description, DateTime created,string location,IncidentSeverityLevel severity,IncidentType type,IncidentStatus status, List<EquipmentType> equipmentUsed,
                               TeamType teamType, string patientName, int patientAge, string medicalCondition)
            : base(description, created, location, severity, type, status, equipmentUsed, teamType)
        {
            PatientName = patientName;
            PatientAge = patientAge;
            MedicalCondition = medicalCondition;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Returns a string representation of the medical incident's details.
        /// </summary>
        /// <returns>A string with detailed information about the medical incident.</returns>
        public override string ReturnsValuesIncident()
        {
            return base.ReturnsValuesIncident() + "\n" +
                   $"Nome do Paciente: {PatientName}\n" +
                   $"Idade do Paciente: {PatientAge}\n" +
                   $"Condição Médica: {MedicalCondition}";
        }
        #endregion
    }
}
