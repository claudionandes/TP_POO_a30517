
//-----------------------------------------------------------------
//    <copyright file="IncidentsManager.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>30-10-2024</date>
//    <author>Cláudio Fernandes</author>
//-----------------------------------------------------------------

using Microsoft.Extensions.Logging;
using TP_POO_a30517.Data;
using TP_POO_a30517.Enums;
using TP_POO_a30517.Equipments;
using TP_POO_a30517.Incidents;
using TP_POO_a30517.Interfaces;
using TP_POO_a30517.Relations;

namespace TP_POO_a30517.Services
{
    /// <summary>
    /// Manages operations related to incidents in the emergency response system.
    /// </summary>
    public class IncidentsManager : IIncidentManager
    {
        #region Private Properties
        private EmergenciesDBContext context;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the IncidentsManager class
        /// </summary>
        /// <param name="context"></param>
        public IncidentsManager(EmergenciesDBContext context)
        {
            this.context = context;
        }
        #endregion

        #region Public Methods

        #region Create Incident
        /// <summary>
        /// Creates a new incident in the system.
        /// </summary>
        /// <param name="incident">The incident to be created.</param>
        public void CreateIncident(Incident incident)
        {
            try
            {
                context.Incidents.Add(incident);
                context.SaveChanges();
                Console.WriteLine($"Incidente {incident.Id} criado com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao criar o incidente: {ex.Message}");
            }
        }
        #endregion

        #region Update Incident
        /// <summary>
        /// Updates an existing incident in the system.
        /// </summary>
        /// <param name="incident">The incident with updated information.</param>
        public void UpdateIncident(Incident incident)
        {
            try
            {
                var existingIncident = context.Incidents.FirstOrDefault(i => i.Id == incident.Id);

                if (existingIncident != null)
                {
                    existingIncident.Description = incident.Description;
                    existingIncident.Location = incident.Location;
                    existingIncident.Severity = incident.Severity;
                    existingIncident.Status = incident.Status;
                    existingIncident.TeamType = incident.TeamType;
                    existingIncident.EquipmentUsed = incident.EquipmentUsed;

                    context.SaveChanges();
                    Console.WriteLine($"Incidente {incident.Id} atualizado com sucesso");
                }
                else
                {
                    Console.WriteLine($"Incidente {incident.Id} não encontrado");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar o incidente: {ex.Message}");
            }
        }
        #endregion

        #region Update Medical Incident
        public void UpdateMedicalIncident(MedicalIncident incident) 
        {
            try
            {
                var existingIncident = context.Medical_Incidents.FirstOrDefault(i => i.Id == incident.Id);

                if (existingIncident != null)
                {
                    existingIncident.Description = incident.Description;
                    existingIncident.Location = incident.Location;
                    existingIncident.Severity = incident.Severity;
                    existingIncident.Status = incident.Status;
                    existingIncident.TeamType = incident.TeamType;
                    existingIncident.EquipmentUsed = incident.EquipmentUsed;
                    existingIncident.PatientName = incident.PatientName;
                    existingIncident.PatientAge = incident.PatientAge;
                    existingIncident.MedicalCondition = incident.MedicalCondition;

                    context.SaveChanges();
                    Console.WriteLine($"Emergência médica {incident.Id} atualizada com sucesso");
                }
                else
                {
                    Console.WriteLine($"Emergência médica {incident.Id} não encontrada");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar a emergência médica: {ex.Message}");
            }
        }
        #endregion

        #region Update Fire Incident
        public void UpdateFireIncident(FireIncident incident)
        {
            try
            {
                var existingIncident = context.Fire_Incidents.FirstOrDefault(i => i.Id == incident.Id);

                if (existingIncident != null)
                {
                    existingIncident.Description = incident.Description;
                    existingIncident.Location = incident.Location;
                    existingIncident.Severity = incident.Severity;
                    existingIncident.Status = incident.Status;
                    existingIncident.TeamType = incident.TeamType;
                    existingIncident.EquipmentUsed = incident.EquipmentUsed;
                    existingIncident.AffectedAreaFire = incident.AffectedAreaFire;
                    existingIncident.PeopleAffectedFire = incident.PeopleAffectedFire;

                    context.SaveChanges();
                    Console.WriteLine($"Incidente de Incêndio {incident.Id} atualizado com sucesso");
                }
                else
                {
                    Console.WriteLine($"Incidente de Incêndio {incident.Id} não encontrado");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar o Incidente de Incêndio: {ex.Message}");
            }
        }
        #endregion

        #region Update Catastrophe Incident
        public void UpdateCatastropheIncident(CatastropheIncident incident)
        {
            try
            {
                var existingIncident = context.Catastrophe_Incidents.FirstOrDefault(i => i.Id == incident.Id);

                if (existingIncident != null)
                {
                    existingIncident.Description = incident.Description;
                    existingIncident.Location = incident.Location;
                    existingIncident.Severity = incident.Severity;
                    existingIncident.Status = incident.Status;
                    existingIncident.TeamType = incident.TeamType;
                    existingIncident.EquipmentUsed = incident.EquipmentUsed;
                    existingIncident.CatastropheType = incident.CatastropheType;
                    existingIncident.AffectedAreaCatastrophe = incident.AffectedAreaCatastrophe;
                    existingIncident.PeopleAffectedCatastrophe = incident.PeopleAffectedCatastrophe;
                    existingIncident.IntensityCatastrophe = incident.IntensityCatastrophe;

                    context.SaveChanges();
                    Console.WriteLine($"Incidente Catástrofe {incident.Id} atualizado com sucesso");
                }
                else
                {
                    Console.WriteLine($"Incidente Catástrofe {incident.Id} não encontrado");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar o Incidente Catástrofe: {ex.Message}");
            }
        }
        #endregion

        #region Delete Incident
        /// <summary>
        /// Deletes an incident from the system.
        /// </summary>
        /// <param name="incidentId">The ID of the incident to be deleted.</param>
        public void DeleteIncident(int incidentId)
        {
            try
            {
                var incident = context.Incidents.FirstOrDefault(i => i.Id == incidentId);

                if (incident != null)
                {
                    // Remover as associações de Equipamentos, Equipas e Veículos do incidente
                    var equipmentsManager = new EquipmentsManager(context);

                    // Obter todos os equipamentos associados a este incidente
                    var equipmentIncidents = context.EquipmentIncidents
                                                     .Where(ei => ei.IncidentId == incidentId)
                                                     .ToList();

                    // Para cada equipamento associado, removê-lo do incidente
                    foreach (var equipmentIncident in equipmentIncidents)
                    {
                        // Chamar o método para remover o equipamento específico
                        equipmentsManager.RemoveEquipmentFromIncident(equipmentIncident.EquipmentId, incidentId);
                    }

                    // Remover as equipas associadas ao incidente
                    var teamsManager = new TeamsManager(context);
                    var teamIncidents = context.TeamIncidents
                                               .Where(ti => ti.IncidentId == incidentId)
                                               .ToList();

                    // Para cada equipa associada, removê-la do incidente
                    foreach (var teamIncident in teamIncidents)
                    {
                        teamsManager.RemoveTeamFromIncident(teamIncident.TeamId, incidentId);
                    }

                    // Remover os veículos associados ao incidente
                    var vehiclesManager = new VehiclesManager(context);
                    var vehicleIncidents = context.VehicleIncidents
                                                  .Where(vi => vi.IncidentId == incidentId)
                                                  .ToList();

                    // Para cada veículo associado, removê-lo do incidente
                    foreach (var vehicleIncident in vehicleIncidents)
                    {
                        vehiclesManager.RemoveVehicleFromIncident(vehicleIncident.VehicleId, incidentId);
                    }

                    // Agora remover o incidente
                    context.Incidents.Remove(incident);
                    context.SaveChanges();
                    Console.WriteLine($"Incidente {incidentId} removido com sucesso.");
                }
                else
                {
                    Console.WriteLine($"Incidente {incidentId} não encontrado.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao deletar o incidente: {ex.Message}");
            }
        }

        #endregion

        #region Filter by Status Incident
        /// <summary>
        /// Filters incidents by their status.
        /// </summary>
        /// <param name="status">The status to filter incidents by.</param>
        /// <returns>A list of incidents with the specified status.</returns>
        public List<Incident> FilterByStatus(IncidentStatus status)
        {
            return context.Incidents.Where(i => i.Status == status).ToList();
        }
        #endregion

        #region Get All Incidents
        /// <summary>
        /// Retrieves all incidents from the system.
        /// </summary>
        /// <returns>A list of all incidents.</returns>
        public List<Incident> GetAllIncidents()
        {
            return context.Incidents.ToList();
        }
        #endregion

        #region Get All Catastrophe Incident
        /// <summary>
        /// Retrieves all catastrophe incidents from the system.
        /// </summary>
        /// <returns>A list of all catastrophe incidents.</returns>
        public List<CatastropheIncident> GetAllCatastropheIncident()
        {
            return context.Catastrophe_Incidents.ToList();
        }
        #endregion

        #region Get All Fire Incident
        /// <summary>
        /// Retrieves all fire incidents from the system.
        /// </summary>
        /// <returns>A list of all fire incidents.</returns>
        public List<FireIncident> GetAllFireIncident()
        {
            return context.Fire_Incidents.ToList();
        }
        #endregion

        #region Get All Medical Incident
        /// <summary>
        /// Retrieves all medical incidents from the system.
        /// </summary>
        /// <returns>A list of all medical incidents.</returns>
        public List<MedicalIncident> GetAllMedicalIncident()
        {
            return context.Medical_Incidents.ToList();
        }
        #endregion

        #endregion

    }
}
