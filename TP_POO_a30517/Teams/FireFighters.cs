
//-----------------------------------------------------------------
//    <copyright file="FireFighter.cs" company="IPCA">
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using TP_POO_a30517.Enums;
using TP_POO_a30517.Models;

namespace TP_POO_a30517.Teams
{
    public class FireFighters : EmergencyTeamBase
    {
        #region Public Properties        
        public FireFighter TeamFireFighter { get; set; }

        #endregion

        #region Constructors
        public FireFighters(string name, FireFighter fireFighter, VehiclesType vehicleType, EquipmentType equipmentType, TeamStatus status)
            : base(name, status, vehicleType, equipmentType)
        {
            TeamFireFighter = fireFighter;
        }
        #endregion

        #region Public Methods
        public override string ReturnTeamDetails()
        {
            return $"ID: {Id}\n" +
                   $"Nome: {Name}\n" +
                   $"Estado: {Status}\n" +
                   $"Tipo de Veículo: {VehicleType}\n" +
                   $"Tipo de Equipamento: {EquipmentType}\n\n" +
                   $"Bombeiro:\n{TeamFireFighter.ReturnsValuesPerson()}";

        }
        #endregion

        #region Private Methods             
        #endregion
    }
}
