
//-----------------------------------------------------------------
//    <copyright file="INEM.cs" company="IPCA">
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

namespace TP_POO_a30517.Teams
{
    /// <summary>
    /// Class INEM
    /// </summary>
    public class INEM
    {
        #region Private Properties
        /// <summary>
        /// Properties
        /// </summary>
        private static int nextId = 1;
        private int id { get; set; }
        private string name { get; set; }
        private TeamStatus status { get; set; } = TeamStatus.Disponível;
        
        #endregion

        #region Public Properties        
        /// <summary>
        /// Public - Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id
        {
            get => id;
            set => id = value;
        }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name
        {
            get => name;
            set => name = value;
        }
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public TeamStatus Status
        {
            get => status;
            set => status = value;
        }
        /// <summary>
        /// Gets or sets the team doctor.
        /// </summary>
        /// <value>
        /// The team doctor.
        /// </value>
        public Doctor TeamDoctor { get; set; }
        /// <summary>
        /// Gets or sets the team nurse.
        /// </summary>
        /// <value>
        /// The team nurse.
        /// </value>
        public Nurse TeamNurse { get; set; }
        /// <summary>
        /// Gets or sets the team technician.
        /// </summary>
        /// <value>
        /// The team technician.
        /// </value>
        public EmergencyTechnician TeamTechnician { get; set; }
        #endregion

        #region Constructors
        public INEM(string name, Doctor doctor, Nurse nurse, EmergencyTechnician technician, TeamStatus status)
        {
            Id = GenerateId();
            Name = name;
            TeamDoctor = doctor;
            TeamNurse = nurse;
            TeamTechnician = technician;
            Status = status;
        }
        #endregion

        #region Public Methods
        public string TeamDetails()
        {
            return $"ID: {Id}\n" +
                   $"Name: {Name}\n" +
                   $"Status: {Status}\n\n" +
                   $"Doctor:\n{TeamDoctor.ReturnsValues()}\n\n" +
                   $"Nurse:\n{TeamNurse.ReturnsValues()}\n\n" +
                   $"Emergency Technician:\n{TeamTechnician.ReturnsValues()}";
        }
        #endregion

        #region Private Methods             
        /// <summary>
        /// Generates the identifier.
        /// </summary>
        /// <returns></returns>
        private static int GenerateId()
        {
            return nextId++;
        }
        #endregion
    }
}
