
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
        /// <summary>
        /// The identifier
        /// </summary>
        private int id;
        private string name;
        private EquipmentType type;
        private int quantityAvailable;
        private EquipmentStatus status;
        #endregion

        #region Public Properties        
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id
        {
            get => id;
            set => id = value;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public EquipmentType Type
        {
            get => type; 
            set => type = value;
        }

        public int QuantityAvailable
        {
            get => quantityAvailable; 
            set => quantityAvailable = value;
        }

        public EquipmentStatus Status
        {
            get => status;
            set => status = value;
        }
        #endregion

        #region Construtors        
        /// <summary>
        /// Initializes a new instance of the <see cref="Equipment"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="type">The type.</param>
        /// <param name="quantityAvailable">The quantity available.</param>
        /// <param name="status">The status.</param>
        public Equipment (string name, EquipmentType type, int quantityAvailable, EquipmentStatus status)
        {
            this.Name = name;
            this.Type = type;
            this.QuantityAvailable = quantityAvailable;
            this.Status = status;
        }
        #endregion
    }
}
