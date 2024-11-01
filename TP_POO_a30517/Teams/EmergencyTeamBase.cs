
//-----------------------------------------------------------------
//    <copyright file="EmergencyTeamBase.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>01-11-2024</date>
//    <author>Cláudio Fernandes</author>
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_POO_a30517.Enums;

namespace TP_POO_a30517.Teams
{
    public abstract class EmergencyTeamBase
    {
        #region Private Properties
        private static int nextId = 1;
        private int id { get; set; }
        private string name { get; set; }
        private TeamStatus status { get; set; }
        private VehiclesType vehicleType { get; set; }
        private EquipmentType equipmentType { get; set; }
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
            set => name = value ?? "Não especificado";
        }
        public TeamStatus Status
        {
            get => status;
            set => status = value;
        }
        public VehiclesType VehicleType
        {
            get => vehicleType;
            set => vehicleType = value;
        }
        public EquipmentType EquipmentType
        {
            get => equipmentType;
            set => equipmentType = value;
        }
        #endregion

        #region Constructors
        protected EmergencyTeamBase(string name, TeamStatus status, VehiclesType vehicleType, EquipmentType equipmentType)
        {
            id = GenerateId();
            Name = name;
            Status = status;
            VehicleType = vehicleType;
            EquipmentType = equipmentType;
        }

        #endregion

        #region Public Methods
        public abstract string ReturnTeamDetails();
        #endregion

        #region Private Methods             
        private static int GenerateId()
        {
            return nextId++;
        }
        #endregion
    }
}
