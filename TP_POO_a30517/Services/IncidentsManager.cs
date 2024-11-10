
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
using TP_POO_a30517.Equipments;
using TP_POO_a30517.Incidents;
using TP_POO_a30517.Interfaces;
using TP_POO_a30517.Relations;

namespace TP_POO_a30517.Services
{
    public class IncidentsManager : IIncidentManager
    {
        #region Private Properties
        private EmergenciesDBContext context;
        #endregion

        #region Constructor
        public IncidentsManager(EmergenciesDBContext context)
        {
            this.context = context;
        }
        #endregion

        #region Public Methods

        #region Create Incident
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
        public void UpdateIncident(Incident incident)
        {
        }
        #endregion

        #region Delete Incident
        public void DeleteIncident(int incidentId)
        {
            // Remover as associações de Equipamentos, Equipas e Veículos do incidente
            // Obter todos os equipamentos associados a este incidente
            // Para cada equipamento associado, Chamar o método para remover o equipamento específico
            // Fazer o mesmo para as equipas e veículos
        }

        #endregion

        #region Filter by Status Incident
        public List<Incident> FilterByStatus(IncidentStatus status)
        {
            return context.Incidents.Where(i => i.Status == status).ToList();
        }
        #endregion

        #region Get All Incidents
        public List<Incident> GetAllIncidents()
        {
            return context.Incidents.ToList();
        }
        #endregion

        #endregion

    }
}
