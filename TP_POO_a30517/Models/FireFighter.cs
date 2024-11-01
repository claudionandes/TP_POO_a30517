
//-----------------------------------------------------------------
//    <copyright file="~Bombeiro.cs" company="IPCA">
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

namespace TP_POO_a30517.Models
{
    /// <summary>
    /// Public class Bombeiro
    /// </summary>
    public class FireFighter : Person
    {
        #region Private Properties             
        /// <summary>
        /// Additional properties
        /// </summary>
        private int yearsOfExperience;
        private string specialization;
        #endregion

        #region Public Properties        
        public int YearsOfExperience
        {
            get => yearsOfExperience;
            set
            {
                if (value >= 0)
                    yearsOfExperience = value;
                else
                    throw new ArgumentException("Número de anos de experiência não pode ser negativo");
            }
        }

        public string Specialization
        {
            get => specialization;
            set => specialization = value ?? "Não especificado";
        }
        #endregion

        #region Construtors                        
        public FireFighter (string name, DateOnly birthdate, string citizenCard, string phone, string email, string address, string nationality, Roles role, TeamType teamType, PersonStatus status, int yearsOfExperience, string specialization)
            :base (name, birthdate, citizenCard, phone, email, address, nationality, role, teamType, status)
        {
            YearsOfExperience = yearsOfExperience;
            Specialization = specialization;
        }
        #endregion

        #region Public Methods        

        public override string ReturnsValuesPerson()
        {
            return base.ReturnsValuesPerson() + "\n" +
                   $"Anos de Experiência: {YearsOfExperience} years\n" +
                   $"Especialização: {Specialization}\n" +
                   $"Cargo: {Role}";
        }
        #endregion
    }
}

