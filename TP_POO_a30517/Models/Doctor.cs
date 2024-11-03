
//-----------------------------------------------------------------
//    <copyright file="Medico.cs" company="IPCA">
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

namespace TP_POO_a30517.Models
{
    /// <summary>
    /// Public class Medico
    /// </summary>
    public class Doctor : Person
    {
        #region Private Properties    
        private string professionalName;
        private int cardNumber;
        private string specialty;
        #endregion

        #region Public Properties  
        public string ProfessionalName
        {
            get => professionalName;
            set => professionalName = value;
        }
        public int CardNumber
        {
            get => cardNumber; 
            set => cardNumber = value > 0 ? value : throw new ArgumentException ("Número de Cédula é obrigatório");
        }
        public string Specialty
        {
            get => specialty;
            set => specialty = value ?? "Medicina Geral e Familiar";
        }

        #endregion

        #region Construtors                        
        public Doctor (string name, DateOnly birthdate,string citizenCard, string phone, string email, string address, string nationality, Roles role, TeamType teamType, PersonStatus status, string professionalName, int cardNumber, string specialty)
            : base(name, birthdate, citizenCard, phone, email, address, nationality, role, teamType, status)
        {
            ProfessionalName = professionalName;
            CardNumber = cardNumber;
            Specialty = specialty;
        }
        #endregion

        #region Public Methods        
        public override string ReturnsValuesPerson()
        {
            return base.ReturnsValuesPerson() + "\n" +
                   $"ID: {Id}\n" +
                   $"Nome Profissional: {ProfessionalName}\n" +
                   $"Número de Cédula: {CardNumber}\n" +
                   $"Especialidade: {Specialty}";
        }
        #endregion
    }
}
