
//-----------------------------------------------------------------
//    <copyright file="VehicleIncident.cs" company="IPCA">
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
using TP_POO_a30517.Vehicles;

namespace TP_POO_a30517.Relations
{
    public class VehicleIncident
    {
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }

        public int IncidentId { get; set; }
        public Incident Incident { get; set; }
    }
}
