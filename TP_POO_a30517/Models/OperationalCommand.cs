
//-----------------------------------------------------------------
//    <copyright file="OperationalCommand.cs" company="IPCA">
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
using TP_POO_a30517.Equipments;
using TP_POO_a30517.Incidents;
using TP_POO_a30517.Vehicles;
using TP_POO_a30517.Services;
using TP_POO_a30517.Teams;

namespace TP_POO_a30517.Models
{
    public class OperationalCommand
    {
        #region Private Properties
        private readonly VehiclesManager _vehicleManager;
        private readonly IncidentsManager _incidentManager;
        private readonly EquipmentsManager _equipmentManager;
        private readonly PersonsManager _personManager;
        private readonly TeamsManager _teamManager;
        #endregion

        #region Constructor
        public OperationalCommand(VehiclesManager vehicleManager, IncidentsManager incidentManager, EquipmentsManager equipmentManager, PersonsManager personManager,
                                  TeamsManager teamManager)
        {
            _vehicleManager = vehicleManager;
            _incidentManager = incidentManager;
            _equipmentManager = equipmentManager;
            _personManager = personManager;
            _teamManager = teamManager;
        }
        #endregion


        #region List Methods

        #region List All Vehicles
        public void ListVehicles()
        {
            var vehicles = _vehicleManager.ListAllVehicles();
            foreach (var vehicle in vehicles)
            {
                Console.WriteLine($"ID: {vehicle.Id}, Modelo: {vehicle.VehicleModel}, Tipo: {vehicle.Type}, Marca: {vehicle.Brand}");
            }
        }
        #endregion

        #region List All Incidents
        public void ListAllIncidents()
        {
            var incidents = _incidentManager.GetAllIncidents();

            if (incidents != null && incidents.Any())
            {
                foreach (var incident in incidents)
                {
                    Console.WriteLine($"ID: {incident.Id}, Descrição: {incident.Description}, Status: {incident.Status}");
                }
            }
            else
            {
                Console.WriteLine("Nenhum incidente encontrado.");
            }
        }
        #endregion

        #region List All Equipments
        public void ListAllEquipments()
        {
            var equipments = _equipmentManager.ListAllEquipments();

            if (equipments != null && equipments.Any())
            {
                foreach (var equipment in equipments)
                {
                    Console.WriteLine($"ID: {equipment.Id}, Tipo: {equipment.Type}, Descrição: {equipment.Name}, Status: {equipment.Status}");
                }
            }
            else
            {
                Console.WriteLine("Nenhum equipamento encontrado.");
            }
        }
        #endregion

        #region List All Persons
        public void ListAllPersons()
        {
            var persons = _personManager.GetAllPersons();

            if (persons != null && persons.Any())
            {
                foreach (var person in persons)
                {
                    Console.WriteLine($"ID: {person.Id}, Nome: {person.Name}, Função: {person.Role}, Status: {person.Status}");
                }
            }
            else
            {
                Console.WriteLine("Nenhuma pessoa encontrada.");
            }
        }
        #endregion

        #region List All Teams
        public void ListAllTeams()
        {
            var teams = _teamManager.GetAllTeams();

            if (teams != null && teams.Any())
            {
                foreach (var team in teams)
                {
                    Console.WriteLine($"ID: {team.Id}, Nome da Equipa: {team.Name}, Tipo: {team.TeamType}");
                }
            }
            else
            {
                Console.WriteLine("Nenhuma equipe encontrada.");
            }
        }
        #endregion

        #endregion

        #region Create Methods

        // Criar incidente
        public void CreateIncident(Incident incident, TeamType teamType)
        {
            _incidentManager.CreateIncident(incident, teamType);
        }

        // Criar veículo
        public void CreateVehicle(Vehicle vehicle)
        {
            _vehicleManager.CreateVehicle(vehicle);
        }

        // Criar equipamento
        public void CreateEquipment(Equipment equipment)
        {
            _equipmentManager.AddEquipment(equipment);
        }

        // Criar pessoa
        public void CreatePerson(Person person)
        {
            _personManager.AddPerson(person);
        }

        // Criar equipa
        public void CreateTeam(EmergencyTeamBase team)
        {
            _teamManager.AddTeam(team);
        }



        #endregion

        #region Start Emergency
        
        #endregion

        #region Conclude Emergency

        #endregion
    }
}
