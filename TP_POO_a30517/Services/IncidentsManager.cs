
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
using TP_POO_a30517.Relations;

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

                // Adiciona o incidente ao contexto
                _context.Incidents.Add(incident);
                _context.SaveChanges(); // Salva o incidente primeiro para obter o ID

                // Agora, permita que o usuário selecione o tipo de veículo
                Console.WriteLine("Selecione o tipo de veículo:");

                // Supondo que você tenha uma enumeração VehicleType
                var vehicleTypes = Enum.GetValues(typeof(VehiclesType)).Cast<VehiclesType>().ToList();

                for (int i = 0; i < vehicleTypes.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {vehicleTypes[i]}");
                }

                Console.Write("Escolha o número do tipo de veículo: ");
                if (int.TryParse(Console.ReadLine(), out int vehicleTypeChoice) && vehicleTypeChoice > 0 && vehicleTypeChoice <= vehicleTypes.Count)
                {
                    var selectedVehicleType = vehicleTypes[vehicleTypeChoice - 1];

                    // Filtra os veículos disponíveis pelo tipo selecionado
                    var availableVehicles = _context.Vehicles
                        .Where(v => v.Type == selectedVehicleType) // Filtra por tipo
                        .ToList();

                    if (!availableVehicles.Any())
                    {
                        Console.WriteLine("Nenhum veículo disponível para o tipo selecionado.");
                        return;
                    }

                    Console.WriteLine("Selecione os veículos disponíveis:");
                    for (int i = 0; i < availableVehicles.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. Marca: {availableVehicles[i].Brand}, Modelo: {availableVehicles[i].VehicleModel}, Matrícula: {availableVehicles[i].VehicleRegist}");
                    }

                    Console.Write("Escolha os números dos veículos (separados por vírgula): ");
                    var vehicleChoices = Console.ReadLine().Split(',').Select(v => v.Trim()).ToList();

                    foreach (var vehicleChoice in vehicleChoices)
                    {
                        if (int.TryParse(vehicleChoice, out int vehicleIndex) && vehicleIndex > 0 && vehicleIndex <= availableVehicles.Count)
                        {
                            var selectedVehicle = availableVehicles[vehicleIndex - 1];

                            // Associa o veículo ao incidente
                            AssociateVehicleWithIncident(selectedVehicle.Id, incident.Id);
                        }
                        else
                        {
                            Console.WriteLine($"Escolha inválida para veículo: {vehicleChoice}");
                        }
                    }

                    Console.WriteLine("Incidente criado e equipa atribuída com sucesso");
                }
                else
                {
                    Console.WriteLine("Escolha inválida. Incidente não foi criado.");
                }
            }
            else
            {
                Console.WriteLine("Escolha inválida. Incidente não foi criado.");
            }
        }
        #endregion

        #region Associate Vehicle With Incident
        public void AssociateVehicleWithIncident(int vehicleId, int incidentId)
        {
            using (var context = new EmergenciesDBContext())
            {
                var vehicle = context.Vehicles.FirstOrDefault(v => v.Id == vehicleId);
                var incident = context.Incidents.FirstOrDefault(i => i.Id == incidentId);

                if (vehicle == null)
                {
                    throw new KeyNotFoundException($"Veículo com ID {vehicleId} não encontrado");
                }

                if (incident == null)
                {
                    throw new KeyNotFoundException($"Incidente com ID {incidentId} não encontrado");
                }

                var vehicleIncident = new VehicleIncident
                {
                    VehicleId = vehicleId,
                    IncidentId = incidentId
                };

                context.VehicleIncidents.Add(vehicleIncident);
                context.SaveChanges();
                Console.WriteLine("Veículo associado ao incidente com sucesso");
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
