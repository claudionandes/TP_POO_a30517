
//-----------------------------------------------------------------
//    <copyright file="FireFighter.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>01-11-2024</date>
//    <author>Cláudio Fernandes</author>
//-----------------------------------------------------------------

using TP_POO_a30517.Enums;
using TP_POO_a30517.Models;

namespace TP_POO_a30517.Teams
{
    /// <summary>
    /// Represents a firefighting team in the emergency response system.
    /// </summary>
    public class FireFighters : EmergencyTeamBase
    {
        #region Public Properties     
        public List<FireFighter> FireFightersList { get; set; }

        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the FireFighters class.
        /// </summary>
        /// <param name="name">The name of the firefighting team.</param>
        /// <param name="status">The current status of the team.</param>
        /// <param name="teamType">The type of the team (e.g., firefighting).</param>
        public FireFighters(string name, TeamStatus status, TeamType teamType)
            : base(name, status, teamType)
        {
            FireFightersList = new List<FireFighter>();
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Returns a string representation of the firefighting team's details.
        /// </summary>
        /// <returns>A formatted string containing team details.</returns>
        public override string ReturnTeamDetails()
        {
            var firefightersDetails = string.Join(", ", FireFightersList);
            return $"Nome: {Name}\n" +
                   $"Estado: {Status}\n" +
                   $"Equipa: {TeamType}\n" +
                   $"Lista Equipa: {firefightersDetails}";
        }
        #endregion
    }
}
