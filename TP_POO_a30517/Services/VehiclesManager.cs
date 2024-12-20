
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
            var vehicle = context.Vehicles.FirstOrDefault(v => v.VehicleRegist == vehicleRegist);

            if (vehicle != null)
            {
                foreach (var update in updates)
                {
                    // Obter a propriedade do veículo base
                    var propertyInfo = typeof(Vehicle).GetProperty(update.Key);

                    if (propertyInfo != null && propertyInfo.CanWrite)
                    {
                        propertyInfo.SetValue(vehicle, update.Value);
                    }
                    else
                    {
                        var vehicleType = vehicle.GetType();
                        var subclassProperty = vehicleType.GetProperty(update.Key);

                        if (subclassProperty != null && subclassProperty.CanWrite)
                        {
                            subclassProperty.SetValue(vehicle, update.Value);
                        }
                    }
                }
                context.SaveChanges();
                Console.WriteLine("Veículo atualizado com sucesso");
            }
            else
            {
                throw new KeyNotFoundException($"Veículo com a matrícula {vehicleRegist} não encontrado");
            }
        }

        #endregion

        #region Delete Vehicle
        /// <summary>
        /// Deletes a vehicle from the system.
        /// </summary>
        /// <param name="vehicleRegist">The registration number of the vehicle to delete.</param>
        public void DeleteVehicle(string vehicleRegist)
        {
            // Procurar o veículo pela matrícula
            var vehicleDelete = context.Vehicles.FirstOrDefault(v => v.VehicleRegist == vehicleRegist);

            if (vehicleDelete != null)
            {
                // Remover relações com incidentes
                var relatedIncidents = context.VehicleIncidents.Where(vi => vi.VehicleId == vehicleDelete.Id).ToList();
                if (relatedIncidents.Any())
                {
                    context.VehicleIncidents.RemoveRange(relatedIncidents);
                }

                // Remover relações com equipamentos
                var relatedEquipments = context.VehicleEquipments.Where(ve => ve.VehicleId == vehicleDelete.Id).ToList();
                if (relatedEquipments.Any())
                {
                    context.VehicleEquipments.RemoveRange(relatedEquipments);
                }

                // Remover o veículo
                context.Vehicles.Remove(vehicleDelete);
                context.SaveChanges();
                Console.WriteLine("Veículo eliminado com sucesso.");
            }
            else
            {
                throw new KeyNotFoundException($"Veículo com a matrícula {vehicleRegist} não encontrado.");
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
            // Verificar se o veículo existe
            var vehicle = context.Vehicles.FirstOrDefault(v => v.Id == vehicleId);
            if (vehicle == null)
            {
                throw new KeyNotFoundException($"Veículo com ID {vehicleId} não encontrado");
            }

            // Verificar se o incidente existe
            var incident = context.Incidents.FirstOrDefault(i => i.Id == incidentId);
            if (incident == null)
            {
                throw new KeyNotFoundException($"Incidente com ID {incidentId} não encontrado");
            }

            // Verificar se a associação já existe
            var existingRelation = context.Set<VehicleIncident>()
                .FirstOrDefault(vi => vi.VehicleId == vehicleId && vi.IncidentId == incidentId);

            if (existingRelation != null)
            {
                Console.WriteLine($"O veículo ID {vehicleId} já está associado ao incidente ID {incidentId}");
                return;
            }

            // Criar nova associação
            var vehicleIncident = new VehicleIncident
            {
                VehicleId = vehicleId,
                IncidentId = incidentId
            };

            context.Set<VehicleIncident>().Add(vehicleIncident);
            context.SaveChanges();

            Console.WriteLine($"Veículo ID {vehicleId} associado ao incidente ID {incidentId} com sucesso");
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
            // Verificar se o veículo existe
            var vehicle = context.Vehicles.FirstOrDefault(v => v.Id == vehicleId);
            if (vehicle == null)
            {
                throw new KeyNotFoundException($"Veículo com ID {vehicleId} não encontrado");
            }

            // Verificar se o incidente existe
            var incident = context.Incidents.FirstOrDefault(i => i.Id == incidentId);
            if (incident == null)
            {
                throw new KeyNotFoundException($"Incidente com ID {incidentId} não encontrado");
            }

            // Procurar a associação existente
            var existingRelation = context.Set<VehicleIncident>()
                .FirstOrDefault(vi => vi.VehicleId == vehicleId && vi.IncidentId == incidentId);

            if (existingRelation == null)
            {
                Console.WriteLine($"O veículo ID {vehicleId} não está associado ao incidente ID {incidentId}");
                return;
            }

            context.Set<VehicleIncident>().Remove(existingRelation);
            context.SaveChanges();

            Console.WriteLine($"Associação entre veículo ID {vehicleId} e incidente ID {incidentId} removida com sucesso");
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

