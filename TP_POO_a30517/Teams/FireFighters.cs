
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
    public class FireFighters : EmergencyTeamBase
    {
        #region Public Properties     
        public List<FireFighter> FireFightersList { get; set; }

        #endregion

        #region Constructors
        public FireFighters(string name, TeamStatus status, TeamType teamType)
            : base(name, status, teamType)
        {
            FireFightersList = new List<FireFighter>();
        }
        #endregion

        #region Public Methods
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
