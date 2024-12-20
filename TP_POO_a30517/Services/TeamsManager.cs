
//-----------------------------------------------------------------
//    <copyright file="TeamsManager.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>03-11-2024</date>
//    <author>Cláudio Fernandes</author>
//-----------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using TP_POO_a30517.Data;
using TP_POO_a30517.Enums;
using TP_POO_a30517.Interfaces;
using TP_POO_a30517.Relations;
using TP_POO_a30517.Teams;

namespace TP_POO_a30517.Services
{
    /// <summary>
    /// Manages operations related to emergency teams in the emergency response system.
    /// </summary>
    public class TeamsManager : ITeamsManager
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
                Console.WriteLine($"Equipa '{team.Name}' criada com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao criar a equipa: {ex.Message}");
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
            try
            {
                var existingTeam = context.Emergency_Team_Base
                                          .Include(t => t.TeamMembers)
                                          .FirstOrDefault(t => t.Id == updatedTeam.Id);

                if (existingTeam != null)
                {
                    existingTeam.Name = updatedTeam.Name;
                    existingTeam.Status = updatedTeam.Status;
                    existingTeam.TeamType = updatedTeam.TeamType;

                    context.SaveChanges();
                    Console.WriteLine($"Equipa '{updatedTeam.Name}' atualizada com sucesso");
                }
                else
                {
                    Console.WriteLine($"Equipa com ID {updatedTeam.Id} não encontrada");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar a equipa: {ex.Message}");
            }
        }
        #endregion

        #region DeleteTeam
        /// <summary>
        /// Deletes a team from the system.
        /// </summary>
        /// <param name="teamId">The ID of the team to be deleted.</param>
        public void DeleteTeam(int teamId)
        {
            try
            {
                var team = context.Emergency_Team_Base
                                  .Include(t => t.TeamMembers)
                                  .Include(t => t.TeamIncidents)
                                  .FirstOrDefault(t => t.Id == teamId);

                if (team == null)
                {
                    Console.WriteLine($"equipa com ID {teamId} não encontrada.");
                    return;
                }

                // Verificar se a equipa está associada a algum incidente com estado 'Em_Espera' ou 'Em_Progresso'
                var incident = context.TeamIncidents
                                      .Where(ti => ti.TeamId == teamId)
                                      .Select(ti => ti.Incident)
                                      .FirstOrDefault();

                if (incident != null && (incident.Status == IncidentStatus.Em_Espera || incident.Status == IncidentStatus.Em_Progresso))
                {
                    Console.WriteLine($"A equipa '{team.Name}' está associada a um incidente com estado '{incident.Status}' e não pode ser removida");
                    return;
                }

                // Remover os membros da equipa, se houver
                context.TeamMembers.RemoveRange(team.TeamMembers);

                context.Emergency_Team_Base.Remove(team);
                context.SaveChanges();
                Console.WriteLine($"equipa com ID {teamId} removida com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao remover a equipa: {ex.Message}");
            }
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
            try
            {
                var incident = context.Incidents.FirstOrDefault(i => i.Id == incidentId);

                if (incident == null)
                {
                    Console.WriteLine($"Incidente com ID {incidentId} não encontrado");
                    return;
                }

                foreach (var teamId in teamIds)
                {
                    var team = context.Emergency_Team_Base.FirstOrDefault(t => t.Id == teamId);

                    if (team == null)
                    {
                        Console.WriteLine($"Equipa com ID {teamId} não encontrada. Associação ignorada");
                        continue;
                    }

                    var existingAssociation = context.TeamIncidents
                                                      .FirstOrDefault(ti => ti.TeamId == teamId && ti.IncidentId == incidentId);

                    if (existingAssociation != null)
                    {
                        Console.WriteLine($"Equipa '{team.Name}' já está associada ao incidente");
                        continue;
                    }

                    var teamIncident = new TeamIncident
                    {
                        TeamId = teamId,
                        IncidentId = incidentId,
                        AssignedDate = DateTime.Now
                    };

                    context.TeamIncidents.Add(teamIncident);
                }

                context.SaveChanges();
                Console.WriteLine($"Equipas associadas ao incidente com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao associar equipas ao incidente: {ex.Message}");
            }
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
            try
            {
                var teamIncident = context.TeamIncidents
                                          .FirstOrDefault(ti => ti.TeamId == teamId && ti.IncidentId == incidentId);

                if (teamIncident == null)
                {
                    Console.WriteLine($"A associação entre a equipa ID {teamId} e o incidente ID {incidentId} não foi encontrada");
                    return;
                }

                var incident = context.Incidents.FirstOrDefault(i => i.Id == incidentId);
                if (incident != null && (incident.Status == IncidentStatus.Em_Espera || incident.Status == IncidentStatus.Em_Progresso))
                {
                    Console.WriteLine($"Não é possível remover a associação, o incidente está em progresso ou em espera.");
                    return;
                }

                context.TeamIncidents.Remove(teamIncident);
                context.SaveChanges();
                Console.WriteLine($"A equipa ID {teamId} foi removida do incidente ID {incidentId} com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao remover a associação da equipa ao incidente: {ex.Message}");
            }
        }
        #endregion

        #region Get All Teams
        /// <summary>
        /// Retrieves all emergency teams from the database.
        /// This method queries the Emergency_Team_Base table 
        /// and returns a list of all teams available.
        /// </summary>
        /// <returns>A list of EmergencyTeamBase instances representing all emergency teams.</returns>

        public List<EmergencyTeamBase> GetAllTeams()
        {
            return context.Emergency_Team_Base.ToList();
        }
        #endregion

        #region Get All FireFighters
        /// <summary>
        /// Retrieves all firefighter teams from the database.
        /// This method queries the FireFighters_Team table 
        /// and returns a list of all firefighter teams available.
        /// </summary>
        /// <returns>A list of FireFighters instances representing all firefighter teams.</returns>

        public List<FireFighters> GetAllFireFighters()
        {
            return context.FireFighters_Team.ToList();
        }
        #endregion

        #region Get All INEM
        /// <summary>
        /// Retrieves all INEM teams from the database.
        /// This method queries the INEM_Team table 
        /// and returns a list of all INEM teams available.
        /// </summary>
        /// <returns>A list of INEM instances representing all INEM teams.</returns>

        public List<INEM> GetAllINEM()
        {
            return context.INEM_Team.ToList();
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
            return context.Emergency_Team_Base.Where(t => t.TeamType == teamType && t.Status == status).ToList();
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
            return context.Emergency_Team_Base.Where(t => t.TeamType == teamType && t.TeamMembers.Any(tm => tm.Person.Status == personStatus)).ToList();
        }
        #endregion

        #endregion
    }
}
