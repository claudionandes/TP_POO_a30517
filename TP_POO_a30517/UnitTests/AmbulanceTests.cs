
//-----------------------------------------------------------------
//    <copyright file="AmbulanceTests.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>17-12-2024</date>
//    <author>Cláudio Fernandes</author>
//-----------------------------------------------------------------

using TP_POO_a30517.Enums;
using TP_POO_a30517.Vehicles;
using Xunit;

namespace TP_POO_a30517.UnitTests
{
    /// <summary>
    /// Test class for Ambulance operations
    /// </summary>
    public class AmbulanceTests
    {
        #region Ambulance Creation Tests
        /// <summary>
        /// Tests if a valid ambulance can be created with correct properties
        /// </summary>
        [Fact]
        public void CreateAmbulance_CreateValidAmbulance()
        {
            // Arrange
            string vehicleRegist = "AB-12-CD";
            DateOnly yearOfRegist = new DateOnly(2023, 1, 1);
            VehiclesType type = VehiclesType.Ambulância_de_Socorro_ABSC;
            string brand = "Mercedes";
            string vehicleModel = "Sprinter";
            DateOnly inspDate = new DateOnly(2024, 1, 1);
            VehiclesStatus status = VehiclesStatus.Disponível;
            int patientCapacity = 2;
            int crewCapacity = 3;
            EquipmentType medicalEquipment = EquipmentType.Proteção_Respiratória;

            // Act
            var ambulance = new Ambulance(vehicleRegist, yearOfRegist, type, brand, vehicleModel, inspDate, status, patientCapacity, crewCapacity, medicalEquipment);

            // Assert
            Assert.Equal(vehicleRegist, ambulance.VehicleRegist);
            Assert.Equal(yearOfRegist, ambulance.YearOfRegist);
            Assert.Equal(type, ambulance.Type);
            Assert.Equal(brand, ambulance.Brand);
            Assert.Equal(vehicleModel, ambulance.VehicleModel);
            Assert.Equal(inspDate, ambulance.InspDate);
            Assert.Equal(status, ambulance.Status);
            Assert.Equal(patientCapacity, ambulance.PatientCapacity);
            Assert.Equal(crewCapacity, ambulance.CrewCapacity);
            Assert.Equal(medicalEquipment, ambulance.MedicalEquipment);
        }

        /// <summary>
        /// Tests if an exception is thrown when creating an ambulance with invalid patient capacity
        /// </summary>
        [Fact]
        public void CreateAmbulance_WithInvalidPatientCapacity()
        {
            // Arrange
            int invalidPatientCapacity = 0;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Ambulance("AB-12-CD", new DateOnly(2023, 1, 1), VehiclesType.Ambulância_de_Socorro_ABSC, "Mercedes", "Sprinter", new DateOnly(2024, 1, 1), VehiclesStatus.Disponível, invalidPatientCapacity, 3, EquipmentType.Monitores));
        }

        /// <summary>
        /// Tests if an exception is thrown when creating an ambulance with invalid crew capacity
        /// </summary>
        [Fact]
        public void CreateAmbulance_WithInvalidCrewCapacity()
        {
            // Arrange
            int invalidCrewCapacity = 0;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Ambulance("AB-12-CD", new DateOnly(2023, 1, 1), VehiclesType.Ambulância_de_Transporte_de_Doentes_ABTD, "Mercedes", "Sprinter", new DateOnly(2024, 1, 1), VehiclesStatus.Disponível, 2, invalidCrewCapacity, EquipmentType.Ferramentas));
        }
        #endregion

        #region Ambulance Method Tests
        /// <summary>
        /// Tests if the ReturnsValuesVehicles method returns the correct string representation
        /// </summary>
        [Fact]
        public void ReturnsValuesVehicles_ReturnCorrectString()
        {
            // Arrange
            var ambulance = new Ambulance("AB-12-CD", new DateOnly(2023, 1, 1), VehiclesType.Ambulância_de_Socorro_ABSC, "Mercedes", "Sprinter", new DateOnly(2024, 1, 1), VehiclesStatus.Disponível, 2, 3, EquipmentType.Ferramentas);

            // Act
            var result = ambulance.ReturnsValuesVehicles();

            // Assert
            Assert.Contains("Capacidade de Pacientes: 2", result);
            Assert.Contains("Capacidade de Tripulação: 3", result);
            Assert.Contains("Equipamento Médico: Ferramentas", result);
        }
        #endregion
    }
}
