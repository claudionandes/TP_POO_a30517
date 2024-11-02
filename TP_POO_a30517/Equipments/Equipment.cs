
//-----------------------------------------------------------------
//    <copyright file="Equipment.cs" company="IPCA">
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TP_POO_a30517.Enums;

namespace TP_POO_a30517.Equipments
{
    /// <summary>
    /// Public class Equipment
    /// </summary>
    public class Equipment
    {
        #region Private Properties   
        private static int currentId = 1;
        private int id;
        private string name;
        private EquipmentType type;
        private int quantityAvailable;
        private EquipmentStatus status;
        #endregion

        #region Public Properties        
        public int Id
        {
            get => id;
            set => id = value;
        }

        public string Name
        {
            get => name;
            set => name = !string.IsNullOrEmpty(value) ? value : throw new ArgumentException("Nome não pode estar vazio");
        }

        public EquipmentType Type
        {
            get => type; 
            set => type = value;
        }

        public int QuantityAvailable
        {
            get => quantityAvailable;
            set => quantityAvailable = value >= 0 ? value : throw new ArgumentException("Quantidade tem que ser igual ou superior a zero");
        }

        public EquipmentStatus Status
        {
            get => status;
            set => status = value;
        }
        #endregion

        #region Construtors        
        public Equipment (string name, EquipmentType type, int quantityAvailable, EquipmentStatus status)
        {
            this.Name = name;
            this.Type = type;
            this.QuantityAvailable = quantityAvailable;
            this.Status = status;
        }
        #endregion

        #region Public Methods
        public string ReturnsValuesEquipment()
        {
            return $"ID: {Id}\n" +
                   $"Nome: {Name}\n" +
                   $"Tipo: {Type}\n" +
                   $"Stock: {QuantityAvailable}\n" +
                   $"Estado: {Status}\n";
        }
        #endregion
    }
}
