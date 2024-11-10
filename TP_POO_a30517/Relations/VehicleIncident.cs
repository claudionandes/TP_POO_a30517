
//-----------------------------------------------------------------
//    <copyright file="VehicleIncident.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>03-11-2024</date>
//    <author>Cláudio Fernandes</author>
//-----------------------------------------------------------------

using TP_POO_a30517.Incidents;
using TP_POO_a30517.Vehicles;

namespace TP_POO_a30517.Relations
{
    /// <summary>
    /// Represents the association between a vehicle and an incident.
    /// </summary>
    public class VehicleIncident
    {
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }

        public int IncidentId { get; set; }
        public Incident Incident { get; set; }
    }
}
