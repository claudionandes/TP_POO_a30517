
//-----------------------------------------------------------------
//    <copyright file="RescueTeam.cs" company="IPCA">
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

namespace TP_POO_a30517.Teams
{
    /// <summary>
    /// Public class RescueTeam
    /// </summary>
    public class RescueTeam
    {
        #region Private Properties        
        /// <summary>
        /// The properties for the rescue team
        /// </summary>
        private static int nextId = 1;
        private int id;
        private string name;
        private List<Person> members;
        private TeamStatus status;
        #endregion

        #region Public Properties        
        /// <summary>
        /// Gets or sets for the rescue team.
        /// </summary>
        public int Id
        {
            get => id; 
            set => id = value;
        }
        public string Name
        {
            get => name;
            set => name = value ?? "Not specified";
        }
        public List<Person> Members
        {
            get => members;
            set => members = value ?? new List<Person>();
        }
        public TeamStatus Status
        {
            get => status; 
            set => status = value;
        }
        #endregion

        #region Construtors        
        /// <summary>
        /// Initializes a new instance of the <see cref="RescueTeam"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="members">The members.</param>
        /// <param name="status">The status.</param>
        public RescueTeam (string name, List<Person> members, TeamStatus status)
        {
            Id = GenerateId();
            Name = name;
            Members = members ?? new List<Person>();
            Status = status;
        }
        #endregion

        #region Public Methods
        public virtual string ReturnsValues()
            {
            return $"ID: {Id}\n" +
                   $"Name: {Name}\n" +
                   $"Members: {string.Join(", ", Members.Select(m => m.Name))}\n" +
                   $"Status: {Status}\n";
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
