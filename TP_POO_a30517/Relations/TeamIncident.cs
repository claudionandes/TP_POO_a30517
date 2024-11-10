
//-----------------------------------------------------------------
//    <copyright file="TeamIncident.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>03-11-2024</date>
//    <author>Cláudio Fernandes</author>
//-----------------------------------------------------------------

using TP_POO_a30517.Incidents;
using TP_POO_a30517.Teams;

namespace TP_POO_a30517.Relations
{
    /// <summary>
    /// Represents the association between a team and an incident.
    /// </summary>
    public class TeamIncident
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public EmergencyTeamBase Team { get; set; }

        public int IncidentId { get; set; }
        public Incident Incident { get; set; }

        public DateTime AssignedDate { get; set; }
    }
}
