
//-----------------------------------------------------------------
//    <copyright file="Nurse.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>30-10-2024</date>
//    <author>Cláudio Fernandes</author>
//    <summary>
//     Represents a nurse in the emergency response system.
//    </summary>
//-----------------------------------------------------------------

using TP_POO_a30517.Enums;

namespace TP_POO_a30517.Models
{
    /// <summary>
    /// Represents a nurse, derived from the Person class.
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
        /// <summary>
        /// Initializes a new instance of the Nurse class
        /// </summary>
        /// <param name="name"></param>
        /// <param name="birthdate"></param>
        /// <param name="citizenCard"></param>
        /// <param name="phone"></param>
        /// <param name="email"></param>
        /// <param name="address"></param>
        /// <param name="nationality"></param>
        /// <param name="role"></param>
        /// <param name="teamType"></param>
        /// <param name="status"></param>
        /// <param name="professionalName"></param>
        /// <param name="cardNumber"></param>
        /// <param name="areaOfActivity"></param>
        public Nurse (string name, DateOnly birthdate,string citizenCard, string phone, string email, string address, string nationality, Roles role, TeamType teamType, PersonStatus status, string professionalName, int cardNumber, string areaOfActivity)
            :base (name, birthdate, citizenCard, phone, email, address, nationality, role, teamType, status)
        {
            ProfessionalName= professionalName;
            CardNumber= cardNumber;
            AreaOfActivity= areaOfActivity;
        }
        #endregion

        #region Public Methods        
        /// <summary>
        /// Returns detailed information about the nurse.
        /// </summary>
        /// <returns>A string representation of the nurse's details.</returns>
        public override string ReturnsValuesPerson()
        {
            return base.ReturnsValuesPerson() + "\n" +
                   $"Nome Profissional: {ProfessionalName}\n" +
                   $"Número de Cédula: {CardNumber}\n" +
                   $"Área de Atividade: {AreaOfActivity}\n";
        }
        #endregion
    }
}
