
//-----------------------------------------------------------------
//    <copyright file="IncidentsManager.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>30-10-2024</date>
//    <author>Cláudio Fernandes</author>
//-----------------------------------------------------------------

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
                Console.WriteLine($"Incidente {incident.Id} criado com sucesso");
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
        }
        #endregion

        #region Delete Incident
        /// <summary>
        /// Deletes an incident from the system.
        /// </summary>
        /// <param name="incidentId">The ID of the incident to be deleted.</param>
        public void DeleteIncident(int incidentId)
        {
            // Remover as associações de Equipamentos, Equipas e Veículos do incidente
            // Obter todos os equipamentos associados a este incidente
            // Para cada equipamento associado, Chamar o método para remover o equipamento específico
            // Fazer o mesmo para as equipas e veículos
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

        #endregion

    }
}
