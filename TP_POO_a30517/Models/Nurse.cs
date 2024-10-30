
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
        /// <summary>
        /// Additional properties
        /// </summary>
        private string professionalName;
        private string cardNumber;
        private string areaOfActivity;
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
        /// Gets or sets the card number.
        /// </summary>
        /// <value>
        /// The card number.
        /// </value>
        /// <exception cref="System.ArgumentException">Card number is mandatory</exception>
        public string CardNumber
        { 
            get => cardNumber;
            set => cardNumber = value ?? throw new ArgumentException("Card number is mandatory");
        }
        /// <summary>
        /// Gets or sets the area of activity.
        /// </summary>
        /// <value>
        /// The area of activity.
        /// </value>
        public string AreaOfActivity
        {
            get => areaOfActivity;
            set => areaOfActivity = value ?? "General";
        }
        #endregion

        #region Construtors                
        /// <summary>
        /// Initializes a new instance of the <see cref="Nurse"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="birthdate">The birthdate.</param>
        /// <param name="citizenCard">The citizen card.</param>
        /// <param name="phone">The phone.</param>
        /// <param name="address">The address.</param>
        /// <param name="professionalName">Name of the professional.</param>
        /// <param name="cardNumber">The card number.</param>
        /// <param name="areaOfActivity">The area of activity.</param>
        /// <param name="role">The role.</param>
        public Nurse (string name, DateTime birthdate, string citizenCard, string phone, string email, string address, string nationality, Roles role, string professionalName, string cardNumber, string areaOfActivity)
            :base (name, birthdate, citizenCard, phone, email, address, nationality, role)
        {
            ProfessionalName= professionalName;
            CardNumber= cardNumber;
            AreaOfActivity= areaOfActivity;
        }
        #endregion

        #region Public Methods        
        /// <summary>
        /// Returnses the values.
        /// </summary>
        /// <returns>Details of all "Nurse" properties</returns>
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
                   $"Card Number: {CardNumber}\n" +
                   $"Area Of Activity: {AreaOfActivity}";
        }
        #endregion
    }
}
