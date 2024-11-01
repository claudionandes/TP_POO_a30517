﻿
//-----------------------------------------------------------------
//    <copyright file="INEM.cs" company="IPCA">
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
using TP_POO_a30517.Models;

namespace TP_POO_a30517.Teams
{
    /// <summary>
    /// Class INEM
    /// </summary>
    public class INEM : EmergencyTeamBase
    {
        #region Public Properties        
        public Doctor TeamDoctor { get; set; }
        public Nurse TeamNurse { get; set; }
        public EmergencyTechnician TeamTechnician { get; set; }

        #endregion

        #region Constructors
        public INEM(string name, Doctor doctor, Nurse nurse, EmergencyTechnician technician, VehiclesType vehicleType, EquipmentType equipmentType, TeamStatus status)
            : base(name, status, vehicleType, equipmentType)
        {
            TeamDoctor = doctor;
            TeamNurse = nurse;
            TeamTechnician = technician;
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
                   $"Médico:\n{TeamDoctor.ReturnsValuesPerson()}\n\n" +
                   $"Enfermeiro:\n{TeamNurse.ReturnsValuesPerson()}\n\n" +
                   $"Técnico de Emergência:\n{TeamTechnician.ReturnsValuesPerson()}";

        }
        #endregion

        #region Private Methods             
        #endregion
    }
}
