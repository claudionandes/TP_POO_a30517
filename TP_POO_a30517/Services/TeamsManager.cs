
//-----------------------------------------------------------------
//    <copyright file="TeamsManager.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>03-11-2024</date>
//    <author>Cláudio Fernandes</author>
//-----------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_POO_a30517.Data;
using TP_POO_a30517.Enums;
using TP_POO_a30517.Models;
using TP_POO_a30517.Relations;
using TP_POO_a30517.Teams;

namespace TP_POO_a30517.Services
{
    public class TeamsManager
    {
        #region Private Properties
        private EmergenciesDBContext context;
        #endregion

        #region Constructor
        public TeamsManager(EmergenciesDBContext context)
        {
            this.context = context;
        }
        #endregion

        #region Public Methods

        #region Add Team
        public void AddTeam(EmergencyTeamBase team)
        {
            try
            {
                context.Emergency_Team_Base.Add(team);
                context.SaveChanges();
                Console.WriteLine($"equipa '{team.Name}' adicionada com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao adicionar a equipa: {ex.Message}");
            }
        }
        #endregion

        #region Update Team
        public void UpdateTeam(EmergencyTeamBase updatedTeam)
        {
        }
        #endregion

        #region DeleteTeam
        public void DeleteTeam(int teamId)
        {
            // Verificar se a equipa está associada a algum incidente com estado 'Em_Espera' ou 'Em_Progresso', Remover os membros da equipa, se houver
        }
        #endregion

        #region Assign Team to Incident
        public void AssignTeamToIncident(int incidentId, List<int> teamIds)
        {
            // Verificar se a equipa já está associada ao incidente
        }
        #endregion

        #region Remove Team From Incident
        public void RemoveTeamFromIncident(int teamId, int incidentId)
        {
            // Procurar a associação entre a equipa e o incidente, Verificar o estado do incidente
            // Devolver erro quando incidente está em progresso ou em espera
        }
        #endregion

        #region Get All Teams
        public List<EmergencyTeamBase> GetAllTeams()
        {
            return context.Set<EmergencyTeamBase>().ToList();
        }
        #endregion

        #region List Teams by Type
        public List<EmergencyTeamBase> ListTeamsByType(TeamType teamType)
        {
            try
            {
                var teams = context.Emergency_Team_Base
                                   .Where(t => t.TeamType == teamType)
                                   .ToList();

                return teams;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao listar equipas pelo tipo: {ex.Message}");
                return null;
            }
        }
        #endregion

        #region List Teams By Type And Status
        public List<EmergencyTeamBase> ListTeamsByTypeAndStatus(TeamType teamType, TeamStatus status)
        {
            try
            {
                var teams = context.Emergency_Team_Base
                                   .Where(t => t.TeamType == teamType && t.Status == status)
                                   .ToList();

                return teams;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao listar equipas pelo tipo e estado: {ex.Message}");
                return null;
            }
        }
        #endregion

        #region List Teams By Type And Status of Person
        public List<EmergencyTeamBase> ListTeamsByTypeAndPersonStatus(TeamType teamType, PersonStatus personStatus)
        {
            try
            {
                // Filtrar equipas pelo tipo e estado da pessoa
                var teams = context.Emergency_Team_Base
                                   .Where(t => t.TeamType == teamType && t.TeamMembers
                                                                       .Any(tm => tm.Person.Status == personStatus))
                                   .ToList();
                return teams;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao listar equipas pelo tipo e estado da pessoa: {ex.Message}");
                return null;
            }
        }
        #endregion

        #endregion
    }
}
