
//-----------------------------------------------------------------
//    <copyright file="EquipmentIncident.cs" company="IPCA">
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
using TP_POO_a30517.Equipments;
using TP_POO_a30517.Incidents;

namespace TP_POO_a30517.Relations
{
    public class EquipmentIncident
    {
        public int EquipmentId { get; set; }
        public Equipment Equipment { get; set; }

        public int IncidentId { get; set; }
        public Incident Incident { get; set; }
    }
}
