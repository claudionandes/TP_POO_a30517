
//-----------------------------------------------------------------
//    <copyright file="VehicleEquipment.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>06-11-2024</date>
//    <author>Cláudio Fernandes</author>
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_POO_a30517.Equipments;
using TP_POO_a30517.Vehicles;

namespace TP_POO_a30517.Relations
{
    public class VehicleEquipment
    {
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }

        public int EquipmentId { get; set; }
        public Equipment Equipment { get; set; }

        public DateTime AssignedDate { get; set; }
        public int Quantity { get; set; }
    }
}
