
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
        /// <summary>
        /// Gets or sets the name of the professional.
        /// </summary>
        /// <value>
        /// The name of the professional.
        /// </value>
        public string ProfessionalName
        {
            get => professionalName;
            set => professionalName = value;
        }
        /// <summary>
        /// Gets or sets the technical number.
        /// </summary>
        /// <value>
        /// The technical number.
        /// </value>
        /// <exception cref="System.ArgumentException">Technical number is mandatory</exception>
        public string TechnicalNumber
        {
            get => technicalNumber;
            set => technicalNumber = value ?? throw new ArgumentException("Technical number is mandatory");
        }
        #endregion

        #region Construtors                                
        /// <summary>
        /// Initializes a new instance of the <see cref="EmergencyTechnician"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="birthdate">The birthdate.</param>
        /// <param name="citizenCard">The citizen card.</param>
        /// <param name="phone">The phone.</param>
        /// <param name="email">The email.</param>
        /// <param name="address">The address.</param>
        /// <param name="nationality">The nationality.</param>
        /// <param name="role">The role.</param>
        /// <param name="professionalName">Name of the professional.</param>
        /// <param name="technicalNumber">The technical number.</param>
        public EmergencyTechnician(string name, DateTime birthdate, string citizenCard, string phone, string email, string address, string nationality, Roles role, string professionalName, string technicalNumber)
            : base(name, birthdate, citizenCard, phone, email, address, nationality, role)
        {
            ProfessionalName = professionalName;
            TechnicalNumber = technicalNumber;
        }
        #endregion

        #region Public Methods        
        /// <summary>
        /// Returnses the values.
        /// </summary>
        /// <returns>Details of all "EmergencyTechnician" properties</returns>
        public override string ReturnsValues()
        {
            return $"ID: {Id}\n" +
                   $"Name: {Name}\n" +
                   $"Birthdate: {Birthdate.ToShortDateString()}\n" +
                   $"Age: {Age}\n" +
                   $"Citizen Card: {CitizenCard}\n" +
                   $"Phone: {Phone}\n" +
                   $"Email: {Email}\n" +
                   $"Address: {Address}\n" +
                   $"Nationality: {Nationality}\n" +
                   $"Role: {Role}\n" +
                   $"Professional Name: {ProfessionalName}\n" +
                   $"Technical Number: {TechnicalNumber}";
        }
        #endregion
    }
}
