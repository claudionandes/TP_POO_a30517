
//-----------------------------------------------------------------
//    <copyright file=""EquipmentTests.cs company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>17-12-2024</date>
//    <author>Cláudio Fernandes</author>
//-----------------------------------------------------------------

using TP_POO_a30517.Enums;
using TP_POO_a30517.Equipments;
using Xunit;

namespace TP_POO_a30517.UnitTests
{
    /// <summary>
    /// Test class for Equipment operations
    /// </summary>
    public class EquipmentTests
    {
        #region Equipment Creation Tests
        /// <summary>
        /// Tests if a valid equipment can be created with correct properties
        /// </summary>
        [Fact]
        public void CreateEquipment_CreateValidEquipment()
        {
            // Arrange
            string name = "Desfibrilador";
            EquipmentType type = EquipmentType.Ferramentas;
            int quantityAvailable = 5;
            EquipmentStatus status = EquipmentStatus.Disponível;

            // Act
            var equipment = new Equipment(name, type, quantityAvailable, status);

            // Assert
            Assert.Equal(name, equipment.Name);
            Assert.Equal(type, equipment.Type);
            Assert.Equal(quantityAvailable, equipment.QuantityAvailable);
            Assert.Equal(status, equipment.Status);
        }

        /// <summary>
        /// Tests if an exception is thrown when creating equipment with an empty name
        /// </summary>
        [Fact]
        public void CreateEquipment_WithEmptyName()
        {
            // Arrange
            string emptyName = "";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Equipment(emptyName, EquipmentType.Monitores, 5, EquipmentStatus.Sem_Stock));
        }

        /// <summary>
        /// Tests if an exception is thrown when creating equipment with a negative quantity
        /// </summary>
        [Fact]
        public void CreateEquipment_WithNegativeQuantity()
        {
            // Arrange
            int negativeQuantity = -1;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Equipment("Monitores", EquipmentType.Mantas, negativeQuantity, EquipmentStatus.Indisponível));
        }
        #endregion

        #region Equipment Method Tests
        /// <summary>
        /// Tests if the ReturnsValuesEquipment method returns the correct string representation
        /// </summary>
        [Fact]
        public void ReturnsValuesEquipment_ReturnCorrectString()
        {
            // Arrange
            var equipment = new Equipment("Capacetes", EquipmentType.Capacetes, 5, EquipmentStatus.Disponível);
            equipment.Id = 1;

            // Act
            var result = equipment.ReturnsValuesEquipment();

            // Assert
            Assert.Contains("ID: 1", result);
            Assert.Contains("Nome: Capacetes", result);
            Assert.Contains("Tipo: Capacetes", result);
            Assert.Contains("Stock: 5", result);
            Assert.Contains("Estado: Disponível", result);
        }
        #endregion
    }
}
