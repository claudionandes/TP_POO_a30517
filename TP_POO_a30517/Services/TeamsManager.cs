
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
        /// <summary>
        /// Adiciona uma nova equipa à base de dados.
        /// </summary>
        public void AddTeam(EmergencyTeamBase team)
        {
            if (team == null)
            {
                throw new ArgumentNullException(nameof(team), "A equipa não pode ser nula");
            }

            // Validação geral para CitizenCard
            var allTeamMembers = new List<Person>();

            // Validação para INEM
            if (team is INEM inemTeam)
            {
                allTeamMembers.AddRange(inemTeam.DoctorsList);
                allTeamMembers.AddRange(inemTeam.NursesList);
                allTeamMembers.AddRange(inemTeam.EmergencyTechniciansList);

                foreach (var doctor in inemTeam.DoctorsList)
                {
                    if (context.Set<Doctor>().Any(d => d.CardNumber == doctor.CardNumber))
                    {
                        throw new InvalidOperationException($"Já existe um médico com o número de cédula {doctor.CardNumber}");
                    }
                }

                foreach (var nurse in inemTeam.NursesList)
                {
                    if (context.Set<Nurse>().Any(n => n.CardNumber == nurse.CardNumber))
                    {
                        throw new InvalidOperationException($"Já existe um enfermeiro com o número de cédula {nurse.CardNumber}");
                    }
                }

                foreach (var technician in inemTeam.EmergencyTechniciansList)
                {
                    if (context.Set<EmergencyTechnician>().Any(t => t.TechnicalNumber == technician.TechnicalNumber))
                    {
                        throw new InvalidOperationException($"Já existe um técnico de emergência com o número técnico {technician.TechnicalNumber}");
                    }
                }
            }

            // Validação para FireFighters
            if (team is FireFighters fireFightersTeam)
            {
                allTeamMembers.AddRange(fireFightersTeam.FireFightersList);

                foreach (var firefighter in fireFightersTeam.FireFightersList)
                {
                    if (context.Set<FireFighter>().Any(f => f.MechanographicNumber == firefighter.MechanographicNumber))
                    {
                        throw new InvalidOperationException($"Já existe um bombeiro com o número mecanográfico {firefighter.MechanographicNumber}");
                    }
                }
            }

            // Verificação do CitizenCard para todos os membros da equipe
            foreach (var member in allTeamMembers)
            {
                if (context.Set<Person>().Any(p => p.CitizenCard == member.CitizenCard))
                {
                    throw new InvalidOperationException($"Já existe uma pessoa com o número de cartão de cidadão {member.CitizenCard}");
                }
            }

            context.Set<EmergencyTeamBase>().Add(team);
            context.SaveChanges();
            Console.WriteLine($"Equipa {team.Name} adicionada com sucesso");
        }
        #endregion

        #region Update Team
        /// <summary>
        /// Atualiza os detalhes de uma equipa.
        /// </summary>
        public void UpdateTeam(int teamId, Dictionary<string, object> updates)
        {
            var teamToUpdate = context.Set<EmergencyTeamBase>().Find(teamId);

            if (teamToUpdate != null)
            {
                foreach (var update in updates)
                {
                    var property = typeof(EmergencyTeamBase).GetProperty(update.Key);
                    if (property != null && property.CanWrite)
                    {
                        property.SetValue(teamToUpdate, update.Value);
                    }
                }
                context.SaveChanges();
                Console.WriteLine($"Equipa {teamToUpdate.Name} atualizada com sucesso");
            }
            else
            {
                throw new KeyNotFoundException($"Equipa com ID {teamId} não encontrada");
            }
        }
        #endregion

        #region Delete Team
        /// <summary>
        /// Elimina uma equipa da base de dados.
        /// </summary>
        public void DeleteTeam(int teamId)
        {
            var teamToDelete = context.Set<EmergencyTeamBase>().Find(teamId);

            if (teamToDelete != null)
            {
                context.Set<EmergencyTeamBase>().Remove(teamToDelete);
                context.SaveChanges();
                Console.WriteLine($"Equipa {teamToDelete.Name} eliminada com sucesso");
            }
            else
            {
                throw new KeyNotFoundException($"Equipa com ID {teamId} não encontrada");
            }
        }
        #endregion

        #region Create Team with Professionals
        /// <summary>
        /// Cria uma nova equipa e associa os profissionais disponíveis.
        /// </summary>
        public void CreateTeamWithProfessionals(string teamName, TeamType teamType)
        {

        }
        #endregion

        #region Get Available Professionals
        private List<Person> GetAvailableProfessionals(TeamType teamType)
        {
            return context.Persons
                .Where(p => p.TeamType == teamType && p.Status == PersonStatus.Disponível)
                .ToList();
        }
        #endregion

        #region Get All Teams
        public List<EmergencyTeamBase> GetAllTeams()
        {
            return context.Set<EmergencyTeamBase>().ToList();
        }
        #endregion

        #region List Teams by Type
        /// <summary>
        /// Lista as equipas de um determinado tipo.
        /// </summary>
        public List<EmergencyTeamBase> GetTeamsByType(TeamType teamType)
        {
            return context.Set<EmergencyTeamBase>()
                          .Where(t => t.TeamType == teamType)
                          .ToList();
        }
        #endregion

        #region List Teams by Type with Status "Disponível"
        /// <summary>
        /// Lista as equipas de um determinado tipo com o estado Disponível.
        /// </summary>
        public List<EmergencyTeamBase> GetAvailableTeamsByType(TeamType teamType)
        {
            return context.Set<EmergencyTeamBase>()
                          .Where(t => t.TeamType == teamType && t.Status == TeamStatus.Disponível)
                          .ToList();
        }
        #endregion

        #region Get Available INEM Teams
        /// <summary>
        /// Obtém uma lista de equipas disponíveis para cada tipo.
        /// </summary>
        public List<INEM> GetAvailableINEMTeams()
        {
            return context.Set<INEM>()
                          .Where(t => t.Status == TeamStatus.Disponível)
                          .ToList();
        }
        #endregion

        #endregion
    }
}
