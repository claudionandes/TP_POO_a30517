
//-----------------------------------------------------------------
//    <copyright file="VehiclesManager.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>01-11-2024</date>
//    <author>Cláudio Fernandes</author>
//-----------------------------------------------------------------

using TP_POO_a30517.Data;
using TP_POO_a30517.Enums;
using TP_POO_a30517.Interfaces;
using TP_POO_a30517.Models;
using TP_POO_a30517.Relations;
using TP_POO_a30517.Vehicles;

namespace TP_POO_a30517.Services
{
    /// <summary>
    /// Manages operations related to vehicles in the emergency response system.
    /// </summary>
    public class VehiclesManager : IVehiclesManager
    {
        #region Private Properties
        private EmergenciesDBContext context;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the VehiclesManager class
        /// </summary>
        /// <param name="context"></param>
        public VehiclesManager(EmergenciesDBContext context)
        {
            this.context = context;
        }
        #endregion

        #region Public Methods

        #region Create Vehicles
        /// <summary>
        /// Creates a new vehicle in the system.
        /// </summary>
        /// <param name="vehicle">The vehicle to be created.</param>
        public void CreateVehicle(Vehicle vehicle)
        {
            bool vehicleExists = context.Vehicles.Any(v => v.VehicleRegist == vehicle.VehicleRegist);

            if (vehicleExists)
            {
                throw new InvalidOperationException($"Já existe um veículo com a matrícula {vehicle.VehicleRegist}");
            }

            context.Vehicles.Add(vehicle);
            context.SaveChanges();
            Console.WriteLine("Veículo criado com sucesso");
        }
        #endregion

        #region Update Vehicle
        /// <summary>
        /// Updates an existing vehicle's details.
        /// </summary>
        /// <param name="vehicleRegist">The registration number of the vehicle to update.</param>
        /// <param name="updates">A dictionary containing properties to update.</param>
        public void UpdateVehicle(string vehicleRegist, Dictionary<string, object> updates)
        {
        }

        #endregion

        #region Delete Vehicle
        /// <summary>
        /// Deletes a vehicle from the system.
        /// </summary>
        /// <param name="vehicleRegist">The registration number of the vehicle to delete.</param>
        public void DeleteVehicle(string vehicleRegist)
        {
            using (var context = new EmergenciesDBContext())
            {
                
            }
        }

        #endregion

        #region Assign Vehicle To Incident
        /// <summary>
        /// Assigns a vehicle to a specific incident.
        /// </summary>
        /// <param name="vehicleId">The ID of the vehicle.</param>
        /// <param name="incidentId">The ID of the incident.</param>
        public void AssignVehicleToIncident(int vehicleId, int incidentId)
        {
            // Verificar se o veículo existe, Verificar se o incidente existe, Verificar se a associação já existe, Criar nova associação
        }

        #endregion

        #region Remove Vehicle From Incident
        /// <summary>
        /// Removes a vehicle from a specific incident.
        /// </summary>
        /// <param name="vehicleId">The ID of the vehicle.</param>
        /// <param name="incidentId">The ID of the incident.</param>
        public void RemoveVehicleFromIncident(int vehicleId, int incidentId)
        {
            // Verificar se o veículo existe, Verificar se o incidente existe
        }
        #endregion

        #region List all Vehicles
        /// <summary>
        /// Retrieves all vehicles in the system.
        /// </summary>
        /// <returns>A list of Vehicle objects.</returns>
        public List<Vehicle> ListAllVehicles()
        {
            return context.Vehicles.ToList();
        }
        #endregion

        #region List Vehicles by Type
        /// <summary>
        /// Retrieves vehicles filtered by their type.
        /// </summary>
        /// <param name="type">The type of vehicles to filter by.</param>
        /// <returns>A list of Vehicle objects that match the specified type.</returns>
        public List<Vehicle> ListVehiclesByType(VehiclesType type)
        {
            return context.Vehicles.Where(v => v.Type == type).ToList();
        }
        #endregion

        #endregion
    }
}

