
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
using TP_POO_a30517.Models;

namespace TP_POO_a30517.Models
{
    /// <summary>
    /// Public class Medico
    /// </summary>
    public class Doctor : Person
    {
        #region Private Properties        
        /// <summary>
        /// Additional properties
        /// </summary>
        private string professionalName;
        private string cardNumber;
        private string specialty;
        #endregion

        #region Public Properties           
        /// <summary>
        /// Gets or sets the professional number.
        /// </summary>
        /// <value>
        /// The professional number.
        /// </value>
        public string ProfessionalName
        {
            get => professionalName;
            set => professionalName = value;
        }
        /// <summary>
        /// Gets or sets the card number.
        /// </summary>
        /// <value>
        /// The card number.
        /// </value>
        /// <exception cref="System.ArgumentException">Card number is mandatory</exception>
        public string CardNumber
        {
            get => cardNumber; 
            set => cardNumber = value ?? throw new ArgumentException ("Card number is mandatory");
        }
        /// <summary>
        /// Gets or sets the specialty.
        /// </summary>
        /// <value>
        /// The specialty.
        /// </value>
        public string Specialty
        {
            get => specialty;
            set => specialty = value ?? "General Practitioner";
        }
        #endregion

        #region Construtors                        
        /// <summary>
        /// Initializes a new instance of the <see cref="Doctor"/> class.
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
        /// <param name="professionalName">Name of the professional.</param>
        /// <param name="cardNumber">The card number.</param>
        /// <param name="specialty">The specialty.</param>
        public Doctor (string name, DateOnly birthdate,string citizenCard, string phone, string email, string address, string nationality, Roles role, string professionalName, string cardNumber, string specialty)
            : base(name, birthdate, citizenCard, phone, email, address, nationality, role)
        {
            ProfessionalName = professionalName;
            CardNumber = cardNumber;
            Specialty = specialty;
        }
        #endregion

        #region Public Methods        
        /// <summary>
        /// Returnses the values.
        /// </summary>
        /// <returns>Details of all "Doctor" properties</returns>
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
                   $"Role: {Role}\n" +
                   $"Professional Name: {ProfessionalName}\n" +
                   $"Card Number: {CardNumber}\n" +
                   $"Specialty: {Specialty}";
        }
        #endregion
    }
}
