
//-----------------------------------------------------------------
//    <copyright file="EmergencyTeamBase.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>01-11-2024</date>
//    <author>Cláudio Fernandes</author>
//-----------------------------------------------------------------

using TP_POO_a30517.Enums;
using TP_POO_a30517.Models;
using TP_POO_a30517.Relations;

namespace TP_POO_a30517.Teams
{
    /// <summary>
    /// Represents the base class for emergency teams.
    /// </summary>
    public abstract class EmergencyTeamBase
    {
        #region Private Properties
        private int id { get; set; }
        private string name { get; set; }
        private TeamStatus status { get; set; }
        private List<TeamType> teamType { get; set; }
        #endregion

        #region Public Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public TeamStatus Status { get; set; }
        public TeamType TeamType { get; set; }
        public ICollection<TeamMember> TeamMembers { get; set; }
        public ICollection<TeamIncident> TeamIncidents { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the EmergencyTeamBase class.
        /// </summary>
        /// <param name="name">The name of the team</param>
        /// <param name="status">The status of the team</param>
        /// <param name="teamType">The type of the team</param>
        public EmergencyTeamBase(string name, TeamStatus status, TeamType teamType)
        {
            Name = name;
            Status = status;
            TeamType = teamType;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Returns details about the team in a formatted string.
        /// </summary>
        /// <returns>A string containing details about the team.</returns>
        public virtual string ReturnTeamDetails()
        {
            return $"ID: {Id}\n" +
                   $"Nome: {Name}\n" +
                   $"Estado: {Status}\n" +
                   $"Equipa: {TeamType}";
        }
        #endregion

    }
}
