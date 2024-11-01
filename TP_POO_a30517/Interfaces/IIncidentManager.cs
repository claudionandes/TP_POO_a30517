
//-----------------------------------------------------------------
//    <copyright file="IIncidentManager.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>01-11-2024</date>
//    <author>Cláudio Fernandes</author>
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_POO_a30517.Enums;
using TP_POO_a30517.Incidents;

namespace TP_POO_a30517.Interfaces
{
    public interface IIncidentManager
    {
        void CreateIncident(Incident incident);
        void UpdateIncident(int id, Incident updatedIncident);
        List<Incident> FilterByStatus(IncidentStatus status);
    }
}
