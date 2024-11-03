
//-----------------------------------------------------------------
//    <copyright file="ITeamsManager.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>03-11-2024</date>
//    <author>Cláudio Fernandes</author>
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_POO_a30517.Enums;
using TP_POO_a30517.Teams;

namespace TP_POO_a30517.Interfaces
{
    public interface ITeamsManager
    {
        public void AddTeam(EmergencyTeamBase team);
        public void UpdateTeam(int teamId, Dictionary<string, object> updates);
        public void DeleteTeam(int teamId);
        public List<EmergencyTeamBase> GetTeamsByType(TeamType teamType);
        public List<EmergencyTeamBase> GetAvailableTeamsByType(TeamType teamType);
        public List<INEM> GetAvailableINEMTeams();
    }
}
