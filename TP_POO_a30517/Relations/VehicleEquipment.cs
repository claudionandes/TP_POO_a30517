
//-----------------------------------------------------------------
//    <copyright file="VehicleEquipment.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>06-11-2024</date>
//    <author>Cláudio Fernandes</author>
//-----------------------------------------------------------------

using TP_POO_a30517.Equipments;
using TP_POO_a30517.Vehicles;

namespace TP_POO_a30517.Relations
{
    /// <summary>
    /// Represents the association between a vehicle and its equipment.
    /// </summary>
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
