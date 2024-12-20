
//-----------------------------------------------------------------
//    <copyright file="MedicalIncidentsTests.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>17-12-2024</date>
//    <author>Cláudio Fernandes</author>
//-----------------------------------------------------------------

using TP_POO_a30517.Enums;
using TP_POO_a30517.Incidents;
using Xunit;

namespace TP_POO_a30517.UnitTests
{
    /// <summary>
    /// Test class for MedicalIncident operations
    /// </summary>
    public class MedicalIncidentsTests
    {
        #region MedicalIncident Creation Tests
        /// <summary>
        /// Tests if a MedicalIncident is initialized with correct properties
        /// </summary>
        [Fact]
        public void MedicalIncident_InitializePropertiesCorrectly()
        {
            // Arrange
            string description = "Paciente com dores no peito";
            DateTime created = DateTime.Now;
            string location = "Rua Principal, 4485";
            IncidentSeverityLevel severity = IncidentSeverityLevel.Crítico;
            IncidentType type = IncidentType.Emergência_Médica;
            IncidentStatus status = IncidentStatus.Em_Progresso;
            var equipmentUsed = new List<EquipmentType> { EquipmentType.Médico, EquipmentType.Monitores };
            TeamType teamType = TeamType.INEM;
            string patientName = "João Silva";
            int patientAge = 45;
            string medicalCondition = "Possível ataque cardíaco";

            // Act
            var medicalIncident = new MedicalIncident(description, created, location, severity, type, status, equipmentUsed, 
                teamType, patientName, patientAge, medicalCondition);

            // Assert
            Assert.Equal(description, medicalIncident.Description);
            Assert.Equal(created, medicalIncident.Created);
            Assert.Equal(location, medicalIncident.Location);
            Assert.Equal(severity, medicalIncident.Severity);
            Assert.Equal(type, medicalIncident.Type);
            Assert.Equal(status, medicalIncident.Status);
            Assert.Equal(equipmentUsed, medicalIncident.EquipmentUsed);
            Assert.Equal(teamType, medicalIncident.TeamType);
            Assert.Equal(patientName, medicalIncident.PatientName);
            Assert.Equal(patientAge, medicalIncident.PatientAge);
            Assert.Equal(medicalCondition, medicalIncident.MedicalCondition);
        }

        /// <summary>
        /// Tests if patient age is set to zero when an invalid age is provided
        /// </summary>
        [Fact]
        public void MedicalIncident_PatientAgeToZero()
        {
            // Arrange
            string description = "Paciente com dores no peito";
            DateTime created = DateTime.Now;
            string location = "Rua Principal, 123";
            IncidentSeverityLevel severity = IncidentSeverityLevel.Moderado;
            IncidentType type = IncidentType.Emergência_Médica;
            IncidentStatus status = IncidentStatus.Em_Progresso;
            var equipmentUsed = new List<EquipmentType> { EquipmentType.Médico };
            TeamType teamType = TeamType.INEM;
            string patientName = "João Silva";
            int invalidAge = -5;
            string medicalCondition = "Possível ataque cardíaco";

            // Act
            var medicalIncident = new MedicalIncident(description, created, location, severity, type, status, equipmentUsed, teamType, patientName, invalidAge, medicalCondition);

            // Assert
            Assert.Equal(0, medicalIncident.PatientAge);
        }
        #endregion

        #region MedicalIncident Method Tests
        /// <summary>
        /// Tests if the ReturnsValuesIncident method returns the correct string representation
        /// </summary>
        [Fact]
        public void ReturnsValuesIncident()
        {
            // Arrange
            string description = "Paciente com dores no peito";
            DateTime created = DateTime.Now;
            string location = "Rua Principal, 4485";
            IncidentSeverityLevel severity = IncidentSeverityLevel.Crítico;
            IncidentType type = IncidentType.Emergência_Médica;
            IncidentStatus status = IncidentStatus.Em_Progresso;
            var equipmentUsed = new List<EquipmentType> { EquipmentType.Acessórios, EquipmentType.Ferramentas };
            TeamType teamType = TeamType.INEM;
            string patientName = "João Silva";
            int patientAge = 45;
            string medicalCondition = "Possível ataque cardíaco";

            var medicalIncident = new MedicalIncident(description, created, location, severity, type, status, equipmentUsed, teamType, patientName, patientAge, medicalCondition);

            // Act
            string result = medicalIncident.ReturnsValuesIncident();

            // Assert
            Assert.Contains("Nome do Paciente: João Silva", result);
            Assert.Contains("Idade do Paciente: 45", result);
            Assert.Contains("Condição Médica: Possível ataque cardíaco", result);
        }
        #endregion
    }
}
