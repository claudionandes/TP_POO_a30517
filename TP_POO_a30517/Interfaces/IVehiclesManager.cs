
//-----------------------------------------------------------------
//    <copyright file="IVehiclesManager.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>01-11-2024</date>
//    <author>Cláudio Fernandes</author>
//    <summary>
//     Defines the IVehiclesManager interface for managing emergency vehicles.
//    </summary>
//-----------------------------------------------------------------

using TP_POO_a30517.Enums;
using TP_POO_a30517.Vehicles;

namespace TP_POO_a30517.Interfaces
{
    /// <summary>
    /// Defines methods for managing emergency vehicles in the emergency response system.
    /// </summary>
    public interface IVehiclesManager
    {
        #region Methods
        void CreateVehicle(Vehicle vehicle);
        void UpdateVehicle(string vehicleRegist, Dictionary<string, object> updates);
        void DeleteVehicle(string vehicleRegist);
        public void AssignVehicleToIncident(int vehicleId, int incidentId);
        public void RemoveVehicleFromIncident(int vehicleId, int incidentId);
        List<Vehicle> ListVehiclesByType(VehiclesType type);
        List<Vehicle> ListAllVehicles();
        #endregion
    }
}
