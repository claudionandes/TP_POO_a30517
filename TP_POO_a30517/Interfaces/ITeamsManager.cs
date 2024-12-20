
//-----------------------------------------------------------------
//    <copyright file="ITeamsManager.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>03-11-2024</date>
//    <author>Cláudio Fernandes</author>
//    <summary>
//     Defines the ITeamsManager interface for managing emergency teams.
//    </summary>
//-----------------------------------------------------------------

using TP_POO_a30517.Enums;
using TP_POO_a30517.Teams;

namespace TP_POO_a30517.Interfaces
{
    /// <summary>
    /// Defines methods for managing emergency teams in the emergency response system.
    /// </summary>
    public interface ITeamsManager
    {
        #region Methods
        public void AddTeam(EmergencyTeamBase team);
        public void UpdateTeam(EmergencyTeamBase updatedTeam);
        public void DeleteTeam(int teamId);
        public void AssignTeamToIncident(int incidentId, List<int> teamIds);
        public void RemoveTeamFromIncident(int teamId, int incidentId);
        public List<EmergencyTeamBase> GetAllTeams();
        public List<FireFighters> GetAllFireFighters();
        public List<INEM> GetAllINEM();
        public List<EmergencyTeamBase> ListTeamsByTypeAndStatus(TeamType teamType, TeamStatus status);
        public List<EmergencyTeamBase> ListTeamsByTypeAndPersonStatus(TeamType teamType, PersonStatus personStatus);
        #endregion
    }
}
