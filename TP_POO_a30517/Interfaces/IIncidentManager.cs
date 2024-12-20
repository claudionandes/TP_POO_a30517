﻿
//-----------------------------------------------------------------
//    <copyright file="IIncidentManager.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>01-11-2024</date>
//    <author>Cláudio Fernandes</author>
//    <summary>
//     Defines the IIncidentManager interface for managing incidents.
//    </summary>
//-----------------------------------------------------------------

using TP_POO_a30517.Enums;
using TP_POO_a30517.Incidents;

namespace TP_POO_a30517.Interfaces
{
    /// <summary>
    /// Defines methods for managing incidents in the emergency response system.
    /// </summary>
    public interface IIncidentManager
    {
        #region Methods
        public void CreateIncident(Incident incident);
        public void UpdateIncident(Incident incident);
        public void UpdateMedicalIncident(MedicalIncident incident);
        public void UpdateFireIncident(FireIncident incident);
        public void UpdateCatastropheIncident(CatastropheIncident incident);
        public void DeleteIncident(int incidentId);
        public List<Incident> FilterByStatus(IncidentStatus status);
        public List<Incident> GetAllIncidents();
        public List<CatastropheIncident> GetAllCatastropheIncident();
        public List<FireIncident> GetAllFireIncident();
        public List<MedicalIncident> GetAllMedicalIncident();
        #endregion
    }
}
