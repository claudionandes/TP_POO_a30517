
//-----------------------------------------------------------------
//    <copyright file="FireIncidentTests.cs" company="IPCA">
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
using Xunit;
using TP_POO_a30517.Enums;
using TP_POO_a30517.Equipments;
using TP_POO_a30517.Incidents;

namespace TP_POO_a30517.UnitTests
{
    public class FireIncidentTests
    {
        [Fact]
        public void Constructor_ShouldThrowException_WhenAffectedAreaIsNegative()
        {
            // Arrange
            var equipment = new List<Equipment>();

            // Act & Assert
            Assert.Throws<ArgumentException>(() =>
                new FireIncident("Incêndio Florestal", DateTime.Now, "Floresta", IncidentSeverityLevel.Crítico, IncidentType.Incêndio, IncidentStatus.Em_Progresso, equipment, TeamType.Bombeiros, -100, 5));
        }

        [Fact]
        public void Constructor_ShouldThrowException_WhenPeopleAffectedIsNegative()
        {
            // Arrange
            var equipment = new List<Equipment>();

            // Act & Assert
            Assert.Throws<ArgumentException>(() =>
                new FireIncident("Incêndio Urbano", DateTime.Now, "Cidade", IncidentSeverityLevel.Moderado, IncidentType.Catástrofe, IncidentStatus.Em_Espera, equipment, TeamType.INEM, 500, -10));
        }

        [Fact]
        public void ReturnsValuesIncident_ShouldIncludeAffectedAreaAndPeopleAffected()
        {
            // Arrange
            var equipment = new List<Equipment>();
            var fireIncident = new FireIncident("Incêndio Florestal", DateTime.Now, "Floresta", IncidentSeverityLevel.Grave, IncidentType.Incêndio, IncidentStatus.Em_Espera, equipment, TeamType.INEM_e_Bombeiros, 200, 30);

            // Act
            var result = fireIncident.ReturnsValuesIncident();

            // Assert
            Assert.Contains("Área Afetada: 200 m²", result);
            Assert.Contains("Pessoas Afetadas: 30", result);
        }
    }
}
