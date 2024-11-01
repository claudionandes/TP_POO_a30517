﻿
//-----------------------------------------------------------------
//    <copyright file="EmergencyTechnician.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>30-10-2024</date>
//    <author>Cláudio Fernandes</author>
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TP_POO_a30517.Enums;

namespace TP_POO_a30517.Models
{
    public class EmergencyTechnician : Person
    {
        #region Private Properties
        /// <summary>
        /// Additional properties
        /// </summary>
        private string professionalName;
        private string technicalNumber;
        #endregion

        #region Public Properties        

        public string ProfessionalName
        {
            get => professionalName;
            set => professionalName = value;
        }

        public string TechnicalNumber
        {
            get => technicalNumber;
            set => technicalNumber = value ?? throw new ArgumentException("Número Mecanográfico é obrigatório");
        }
        #endregion

        #region Construtors                                        
        public EmergencyTechnician(string name, DateOnly birthdate, string citizenCard, string phone, string email, string address, string nationality, Roles role, TeamType teamType, PersonStatus status, string professionalName, string technicalNumber)
            : base(name, birthdate, citizenCard, phone, email, address, nationality, role, teamType, status)
        {
            ProfessionalName = professionalName;
            TechnicalNumber = technicalNumber;
        }
        #endregion

        #region Public Methods        

        public override string ReturnsValuesPerson()
        {
            return base.ReturnsValuesPerson() + "\n" +
                   $"Nome Profissional: {ProfessionalName}\n" +
                   $"Número Mecanográfico: {TechnicalNumber}";
        }
        #endregion
    }
}
