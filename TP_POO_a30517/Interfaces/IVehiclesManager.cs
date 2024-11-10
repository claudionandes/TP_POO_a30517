
//-----------------------------------------------------------------
//    <copyright file="IVehiclesManager.cs" company="IPCA">
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
using TP_POO_a30517.Vehicles;

namespace TP_POO_a30517.Interfaces
{
    public interface IVehiclesManager
    {
        void CreateVehicle(Vehicle vehicle);
        void UpdateVehicle(string vehicleRegist, Dictionary<string, object> updates);
        void DeleteVehicle(string vehicleRegist);
        public void AssignVehicleToIncident(int vehicleId, int incidentId);
        public void RemoveVehicleFromIncident(int vehicleId, int incidentId);
        List<Vehicle> ListVehiclesByType(VehiclesType type);
        List<Vehicle> ListAllVehicles();
    }
}
