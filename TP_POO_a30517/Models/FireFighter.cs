
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
        /// <summary>
        /// Gets or sets the years of experience .
        /// </summary>
        /// <value>
        /// The years of experience.
        /// </value>
        /// <exception cref="System.ArgumentException">Years of experience cannot be negative</exception>
        public int YearsOfExperience
        {
            get => yearsOfExperience;
            set
            {
                if (value >= 0)
                    yearsOfExperience = value;
                else
                    throw new ArgumentException("Years of experience cannot be negative");
            }
        }
        /// <summary>
        /// Gets or sets the specialization.
        /// </summary>
        /// <value>
        /// The specialization.
        /// </value>
        public string Specialization
        {
            get => specialization;
            set => specialization = value ?? "Not specified";
        }
        #endregion

        #region Construtors                        
        /// <summary>
        /// Initializes a new instance of the <see cref="FireFighter"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="birthdate">The birthdate.</param>
        /// <param name="Age">The age.</param>
        /// <param name="citizenCard">The citizen card.</param>
        /// <param name="phone">The phone.</param>
        /// <param name="email">The email.</param>
        /// <param name="address">The address.</param>
        /// <param name="nationality">The nationality.</param>
        /// <param name="role">The role.</param>
        /// <param name="yearsOfExperience">The years of experience.</param>
        /// <param name="specialization">The specialization.</param>
        public FireFighter (string name, DateOnly birthdate, string citizenCard, string phone, string email, string address, string nationality, Roles role, int yearsOfExperience, string specialization)
            :base (name, birthdate, citizenCard, phone, email, address, nationality, role)
        {
            YearsOfExperience = yearsOfExperience;
            Specialization = specialization;
        }
        #endregion

        #region Public Methods        
        /// <summary>
        /// Returnses the values.
        /// </summary>
        /// <returns>Details of all "FireFighter" properties</returns>
        public override string ReturnsValues()
        {
            return $"ID: {Id}\n" +
                   $"Name: {Name}\n" +
                   $"Birthdate: {Birthdate}\n" +
                   $"Age: {Age}\n" +
                   $"Citizen Card: {CitizenCard}\n" +
                   $"Phone: {Phone}\n" +
                   $"Email: {Email}\n" +
                   $"Address: {Address}\n" +
                   $"Nationality: {Nationality}\n" +
                   $"Years Of Experience: {YearsOfExperience} years\n" +
                   $"Specialization: {Specialization}\n" +
                   $"Role: {Role}";
        }
        #endregion
    }
}

