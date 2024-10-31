
//-----------------------------------------------------------------
//    <copyright file="Vehicles.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>30-10-2024</date>
//    <author>Cláudio Fernandes</author>
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_POO_a30517.Enums;

namespace TP_POO_a30517.Equipments
{
    public abstract class Vehicles
    {
        #region Private Properties        
        private string vehicleRegist { get; set; }
        private DateOnly yearOfRegist { get; set; }
        private VehiclesType type { get; set; }
        private string brand { get; set; }
        private DateOnly inspDate { get; set; }
        private VehiclesStatus status { get; set; }
        #endregion
    }
}
