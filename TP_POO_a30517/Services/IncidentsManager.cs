
//-----------------------------------------------------------------
//    <copyright file="IncidentsManager.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>30-10-2024</date>
//    <author>Cláudio Fernandes</author>
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_POO_a30517.Data;
using TP_POO_a30517.Enums;
using TP_POO_a30517.Incidents;
using TP_POO_a30517.Interfaces;

namespace TP_POO_a30517.Services
{
    public class IncidentsManager : IIncidentManager
    {
        #region Private Properties
        private readonly EmergenciesDBContext _context;
        private readonly TeamsManager _teamsManager;
        #endregion

        #region Constructor
        public IncidentsManager(EmergenciesDBContext context, TeamsManager teamsManager)
        {
            _context = context;
            _teamsManager = teamsManager;
        }
        #endregion

        #region Public Methods

        #region Create Incident
        public void CreateIncident(Incident incident, TeamType teamType)
        {
            if (incident == null)
                throw new ArgumentNullException(nameof(incident), "Incidente não pode ser nulo");

            var availableTeams = _teamsManager.GetAvailableTeamsByType(teamType);

            if (availableTeams == null || !availableTeams.Any())
            {
                Console.WriteLine("Nenhuma equipa disponível para o tipo selecionado.");
                return;
            }

            Console.WriteLine("Selecione uma equipa disponível:");
            for (int i = 0; i < availableTeams.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {availableTeams[i].Name}");
            }

            Console.Write("Escolha o número da equipa: ");
            if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= availableTeams.Count)
            {
                var selectedTeam = availableTeams[choice - 1];
                incident.TeamType = teamType;

                _context.Incidents.Add(incident);
                _context.SaveChanges();

                Console.WriteLine("Incidente criado e equipa atribuída com sucesso");
            }
            else
            {
                Console.WriteLine("Escolha inválida. Incidente não foi criado.");
            }
        }

        #endregion

        #region Update Incident
        public void UpdateIncident(int id, Incident updatedIncident)
        {
            var incident = _context.Incidents.Find(id);
            if (incident != null && updatedIncident != null)
            {
                _context.Entry(incident).CurrentValues.SetValues(updatedIncident);
                _context.SaveChanges();
                Console.WriteLine("Incidente atualizado com sucesso");
            }
            else
            {
                throw new InvalidOperationException("Incidente não encontrado ou atualizado");
            }
        }
        #endregion

        #region Filter by Status Incident
        public List<Incident> FilterByStatus(IncidentStatus status)
        {
            return _context.Incidents.Where(i => i.Status == status).ToList();
        }
        #endregion

        #region Assing Team
        public void AssignTeamToIncident(Incident incident, TeamType teamType)
        {
        }
        #endregion

        #endregion

    }
}
