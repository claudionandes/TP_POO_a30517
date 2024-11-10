
//-----------------------------------------------------------------
//    <copyright file="EquipmentIncident.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>03-11-2024</date>
//    <author>Cláudio Fernandes</author>
//-----------------------------------------------------------------

using TP_POO_a30517.Equipments;
using TP_POO_a30517.Incidents;

namespace TP_POO_a30517.Relations
{
    /// <summary>
    /// Represents the association between equipment and incidents.
    /// </summary>
    public class EquipmentIncident
    {
        public int EquipmentId { get; set; }
        public Equipment Equipment { get; set; }

        public int IncidentId { get; set; }
        public Incident Incident { get; set; }
    }
}
