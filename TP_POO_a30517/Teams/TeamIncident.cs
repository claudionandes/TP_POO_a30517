
//-----------------------------------------------------------------
//    <copyright file="TeamIncident.cs" company="IPCA">
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
using TP_POO_a30517.Incidents;
using TP_POO_a30517.Models;

namespace TP_POO_a30517.Teams
{
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
