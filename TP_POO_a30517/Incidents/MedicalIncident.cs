
//-----------------------------------------------------------------
//    <copyright file="MedicalIncident.cs" company="IPCA">
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
using TP_POO_a30517.Incidents;
using TP_POO_a30517.Teams;

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
        /// <summary>
        /// Gets or sets the patient's name.
        /// </summary>
        public string PatientName
        {
            get => patientName;
            set => patientName = value;
        }

        /// <summary>
        /// Gets or sets the patient's age.
        /// </summary>
        public int PatientAge
        {
            get => patientAge;
            set => patientAge = value > 0 ? value : 0;
        }

        /// <summary>
        /// Gets or sets the patient's medical condition.
        /// </summary>
        public string MedicalCondition
        {
            get => medicalCondition;
            set => medicalCondition = value;
        }
        #endregion

        #region Constructors
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
        /// Returns detailed information about the medical incident.
        /// </summary>
        /// <returns>Details of all properties specific to a Medical Incident</returns>
        public override string ReturnsValuesIncident()
        {
            return base.ReturnsValuesIncident() + "\n" +
                   $"ID: {Id}\n" +
                   $"Nome do Paciente: {PatientName}\n" +
                   $"Idade do Paciente: {PatientAge}\n" +
                   $"Condição Médica: {MedicalCondition}";
        }
        #endregion
    }
}
