
//-----------------------------------------------------------------
//    <copyright file="DoctorTests.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>17-12-2024</date>
//    <author>Cláudio Fernandes</author>
//-----------------------------------------------------------------

using TP_POO_a30517.Enums;
using TP_POO_a30517.Models;
using Xunit;

namespace TP_POO_a30517.UnitTests
{
    // <summary>
    /// Test class for Doctor operations
    /// </summary>
    public class DoctorTests
    {
        #region Doctor Creation Tests
        /// <summary>
        /// Tests if a valid doctor can be created with correct properties
        /// </summary>
        [Fact]
        public void CreateDoctor_CreateValidDoctor()
        {
            // Arrange
            string name = "John Doe";
            DateOnly birthdate = new DateOnly(1980, 1, 1);
            string citizenCard = "123456789";
            string phone = "987654321";
            string email = "john.doe@example.com";
            string address = "Rua dos Testes";
            string nationality = "Portugal";
            Roles role = Roles.Médico;
            TeamType teamType = TeamType.INEM;
            PersonStatus status = PersonStatus.Disponível;
            string professionalName = "Dr. John Doe";
            int cardNumber = 12345;
            string specialty = "Cariologia";

            // Act
            var doctor = new Doctor(name, birthdate, citizenCard, phone, email, address, nationality, role, teamType, status, professionalName, cardNumber, specialty);

            // Assert
            Assert.Equal(name, doctor.Name);
            Assert.Equal(birthdate, doctor.Birthdate);
            Assert.Equal(citizenCard, doctor.CitizenCard);
            Assert.Equal(phone, doctor.Phone);
            Assert.Equal(email, doctor.Email);
            Assert.Equal(address, doctor.Address);
            Assert.Equal(nationality, doctor.Nationality);
            Assert.Equal(role, doctor.Role);
            Assert.Equal(teamType, doctor.TeamType);
            Assert.Equal(status, doctor.Status);
            Assert.Equal(professionalName, doctor.ProfessionalName);
            Assert.Equal(cardNumber, doctor.CardNumber);
            Assert.Equal(specialty, doctor.Specialty);
        }

        /// <summary>
        /// Tests if an exception is thrown when creating a doctor with an invalid card number
        /// </summary>
        [Fact]
        public void CreateDoctor_WithInvalidCardNumber()
        {
            // Arrange
            int invalidCardNumber = 0;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Doctor("John Doe", new DateOnly(1980, 1, 1), "123456789", "987654321", "john.doe@example.com", "123 Main St", "Portuguese", Roles.Médico, TeamType.INEM, PersonStatus.Disponível, "Dr. John Doe", invalidCardNumber, "Cardiology"));
        }

        /// <summary>
        /// Tests if a default specialty is assigned when creating a doctor with a null specialty
        /// </summary>
        [Fact]
        public void CreateDoctor_WithNullSpecialty()
        {
            // Arrange & Act
            var doctor = new Doctor("John Doe", new DateOnly(1980, 1, 1), "123456789", "987654321", "john.doe@example.com", "123 Main St", "Portuguese", Roles.Médico, TeamType.INEM, PersonStatus.Disponível, "Dr. John Doe", 12345, null);

            // Assert
            Assert.Equal("Medicina Geral e Familiar", doctor.Specialty);
        }
        #endregion
    }
}
