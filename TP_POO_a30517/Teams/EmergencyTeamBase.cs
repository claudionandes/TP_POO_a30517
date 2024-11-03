
//-----------------------------------------------------------------
//    <copyright file="EmergencyTeamBase.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>01-11-2024</date>
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
        protected EmergencyTeamBase(string name, TeamStatus status, TeamType teamType)
        {
            Name = name;
            Status = status;
            TeamType = teamType;
        }

        #endregion

        #region Public Methods
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
