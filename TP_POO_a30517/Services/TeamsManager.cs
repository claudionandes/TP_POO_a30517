
//-----------------------------------------------------------------
//    <copyright file="TeamsManager.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>03-11-2024</date>
//    <author>Cláudio Fernandes</author>
//-----------------------------------------------------------------

using TP_POO_a30517.Data;
using TP_POO_a30517.Enums;
using TP_POO_a30517.Models;
using TP_POO_a30517.Relations;
using TP_POO_a30517.Teams;

namespace TP_POO_a30517.Services
{
    /// <summary>
    /// Manages operations related to emergency teams in the emergency response system.
    /// </summary>
    public class TeamsManager
    {
        #region Private Properties
        private EmergenciesDBContext context;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the TeamsManager class
        /// </summary>
        /// <param name="context">The database context</param>
        public TeamsManager(EmergenciesDBContext context)
        {
            this.context = context;
        }
        #endregion

        #region Public Methods

        #region Add Team
        public void AddTeam(EmergencyTeamBase team)
        /// <summary>
        /// Adds a new team to the system.
        /// </summary>
        /// <param name="team">The team to be added.</param>
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
        /// <summary>
        /// Updates an existing team's details.
        /// </summary>
        /// <param name="updatedTeam">The updated team information.</param>
        public void UpdateTeam(EmergencyTeamBase updatedTeam)
        {
        }
        #endregion

        #region DeleteTeam
        /// <summary>
        /// Deletes a team from the system.
        /// </summary>
        /// <param name="teamId">The ID of the team to be deleted.</param>
        public void DeleteTeam(int teamId)
        {
            // Verificar se a equipa está associada a algum incidente com estado 'Em_Espera' ou 'Em_Progresso', Remover os membros da equipa, se houver
        }
        #endregion

        #region Assign Team to Incident
        /// <summary>
        /// Assigns a team to a specific incident.
        /// </summary>
        /// <param name="incidentId">The ID of the incident.</param>
        /// <param name="teamIds">A list of team IDs to assign.</param>
        public void AssignTeamToIncident(int incidentId, List<int> teamIds)
        {
            // Verificar se a equipa já está associada ao incidente
        }
        #endregion

        #region Remove Team From Incident
        /// <summary>
        /// Removes a team from a specific incident.
        /// </summary>
        /// <param name="teamId">The ID of the team.</param>
        /// <param name="incidentId">The ID of the incident.</param>
        public void RemoveTeamFromIncident(int teamId, int incidentId)
        {
            // Procurar a associação entre a equipa e o incidente, Verificar o estado do incidente
            // Devolver erro quando incidente está em progresso ou em espera
        }
        #endregion

        #region Get All Teams
        /// <summary>
        /// Retrieves all teams in the system.
        /// </summary>
        public List<EmergencyTeamBase> GetAllTeams()
        {
            return context.Set<EmergencyTeamBase>().ToList();
        }
        #endregion

        #region List Teams by Type
        /// <summary>
        /// Lists teams filtered by their type.
        /// </summary>
        /// <param name="teamType">The type of teams to filter by.</param>
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
        /// <summary>
        /// Lists teams filtered by their type and status.
        /// </summary>
        /// <param name="teamType">The type of teams to filter by</param>
        /// <param name="status">The status of the teams to filter by</param>
        /// <returns>A list of EmergencyTeamBase objects that match the criteria.</returns>
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
        /// <summary>
        /// Lists teams filtered by their type and the status of their members.
        /// </summary>
        /// <param name="teamType">The type of teams to filter by</param>
        /// <param name="personStatus">The status of the team members to filter by</param>
        /// <returns>A list of EmergencyTeamBase objects that match the criteria.</returns>
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
