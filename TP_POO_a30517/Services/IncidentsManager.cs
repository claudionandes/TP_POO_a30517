
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
using TP_POO_a30517.Enums;
using TP_POO_a30517.Incidents;
using TP_POO_a30517.Interfaces;

namespace TP_POO_a30517.Services
{
    public class IncidentsManager : IIncidentManager
    {
        #region Private Properties
        private List<Incident> incidents;
        #endregion

        #region Constructor
        public IncidentsManager()
        {
            incidents = new List<Incident>();
        }
        #endregion

        #region Public Methods

        #region Create Incident
        public void CreateIncident(Incident incident)
        {
            if (incident != null)
            {
                incidents.Add(incident);
                Console.WriteLine("Incidente criado com sucesso");
            }
            else
            {
                throw new ArgumentNullException(nameof(incident), "Incidente não pode ser nulo");
            }
        }
        #endregion

        #region Update Incident
        public void UpdateIncident(int id, Incident updatedIncident)
        {
            var incident = incidents.FirstOrDefault(i => i.Id == id);
            if (incident != null && updatedIncident != null)
            {
                incidents[incidents.IndexOf(incident)] = updatedIncident;
                Console.WriteLine("Incidente atualizado com sucesso");
            }
            else
            {
                throw new InvalidOperationException("Incidente não encontrado ou atualizado");
            }
        }
        #endregion

        #region Filter by status
        public List<Incident> FilterByStatus(IncidentStatus status)
        {
            return incidents.Where(i => i.Status == status).ToList();
        }
        #endregion

        #endregion
    }
}
