
//-----------------------------------------------------------------
//    <copyright file="Enfermeiro.cs" company="IPCA">
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
using TP_POO_a30517.Models;
using TP_POO_a30517.Enums;

namespace TP_POO_a30517.Models
{
    /// <summary>
    /// Public class Enfermeiro
    /// </summary>
    public class Nurse :Person
    {
        #region Private Properties
        private string professionalName;
        private int cardNumber;
        private string areaOfActivity;
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
            set => cardNumber = value > 0 ? value : throw new ArgumentException("Número de cédula é obrigatório");
        }
        public string AreaOfActivity
        {
            get => areaOfActivity;
            set => areaOfActivity = value ?? "Geral";
        }
        #endregion

        #region Construtors                        
        public Nurse (string name, DateOnly birthdate,string citizenCard, string phone, string email, string address, string nationality, Roles role, TeamType teamType, PersonStatus status, string professionalName, int cardNumber, string areaOfActivity)
            :base (name, birthdate, citizenCard, phone, email, address, nationality, role, teamType, status)
        {
            ProfessionalName= professionalName;
            CardNumber= cardNumber;
            AreaOfActivity= areaOfActivity;
        }
        #endregion

        #region Public Methods        
        public override string ReturnsValuesPerson()
        {
            return base.ReturnsValuesPerson() + "\n" +
                   $"ID: {Id}\n" +
                   $"Nome Profissional: {ProfessionalName}\n" +
                   $"Número de Cédula: {CardNumber}\n" +
                   $"Área de Atividade: {AreaOfActivity}";
        }
        #endregion
    }
}
