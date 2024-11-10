
//-----------------------------------------------------------------
//    <copyright file="~Bombeiro.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>30-10-2024</date>
//    <author>Cláudio Fernandes</author>
//    <summary>
//     Represents a firefighter in the emergency response system.
//    </summary>
//-----------------------------------------------------------------

using TP_POO_a30517.Enums;

namespace TP_POO_a30517.Models
{
    /// <summary>
    /// Represents a firefighter, derived from the Person class.
    /// </summary>
    public class FireFighter : Person
    {
        #region Private Properties             
        private int yearsOfExperience;
        private string specialization;
        private int mechanographicNumber;
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

        public int MechanographicNumber
        {
            get => mechanographicNumber;
            set => mechanographicNumber = value > 0 ? value : throw new ArgumentException("Número Mecanográfico é obrigatório");
        }
        #endregion

        #region Construtors       
        /// <summary>
        /// Initializes a new instance of the FireFighter class
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
        /// <param name="yearsOfExperience"></param>
        /// <param name="specialization"></param>
        /// <param name="mechanographicNumber"></param>
        public FireFighter (string name, DateOnly birthdate, string citizenCard, string phone, string email, string address, string nationality, Roles role, TeamType teamType, PersonStatus status, int yearsOfExperience, string specialization, int mechanographicNumber)
            :base (name, birthdate, citizenCard, phone, email, address, nationality, role, teamType, status)
        {
            YearsOfExperience = yearsOfExperience;
            Specialization = specialization;
            MechanographicNumber = mechanographicNumber;
        }
        #endregion

        #region Public Methods        
        /// <summary>
        /// Returns detailed information about the firefighter.
        /// </summary>
        /// <returns>A string representation of the firefighter's details.</returns>
        public override string ReturnsValuesPerson()
        {
            return base.ReturnsValuesPerson() + "\n" +
                   $"Anos de Experiência: {YearsOfExperience} years\n" +
                   $"Especialização: {Specialization}\n" +
                   $"Número Mecanográfico: {MechanographicNumber}\n";
        }
        #endregion
    }
}

