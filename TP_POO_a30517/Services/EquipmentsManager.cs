
//-----------------------------------------------------------------
//    <copyright file="EquipmentsManager.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>30-10-2024</date>
//    <author>Cláudio Fernandes</author>
//-----------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using TP_POO_a30517.Data;
using TP_POO_a30517.Enums;
using TP_POO_a30517.Equipments;
using TP_POO_a30517.Interfaces;
using TP_POO_a30517.Relations;
using TP_POO_a30517.Vehicles;

namespace TP_POO_a30517.Services
{
    /// <summary>
    /// Manages operations related to equipment in the emergency response system.
    /// </summary>
    public class EquipmentsManager : IEquipmentsManager
    {
        #region Private Properties
        private EmergenciesDBContext context;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the EquipmentsManager class
        /// </summary>
        /// <param name="context">The database context</param>
        public EquipmentsManager(EmergenciesDBContext context)
        {
            this.context = context;
        }
        #endregion

        #region Public Methods

        #region Add Equipment
        /// <summary>
        /// Adds a new equipment to the system
        /// </summary>
        /// <param name="equipment">The equipment to be added</param>
        public void AddEquipment(Equipment equipment)
        {
                context.Equipments.Add(equipment);
                context.SaveChanges();
                Console.WriteLine("Equipamento inserido com sucesso");
        }
        #endregion

        #region Update Equipment
        /// <summary>
        /// Updates an existing equipment's details.
        /// </summary>
        /// <param name="id">The ID of the equipment to update.</param>
        /// <param name="updates">A dictionary of properties to update.</param>
        public void UpdateEquipment(int id, Dictionary<string, object> updates)
        {
        }
        #endregion

        #region Delete Equipment
        /// <summary>
        /// Deletes an equipment from the system.
        /// </summary>
        /// <param name="id">The ID of the equipment to delete.</param>
        public void DeleteEquipment(int id)
        {
            // Remover as relações com veículos, Remover as relações com incidentes
        }
        #endregion

        #region Associate Equipment with Incident
        /// <summary>
        /// Associates a piece of equipment with a specific incident.
        /// </summary>
        /// <param name="equipmentId">The ID of the equipment.</param>
        /// <param name="incidentId">The ID of the incident.</param>
        public void AssociateEquipmentWithIncident(int equipmentId, int incidentId)
        {
            // Verificar se o equipamento existe, Verificar se o incidente existe, Verificar se a associação já existe
            // Criar nova associação, Atualizar a quantidade disponível do equipamento
        }

        #endregion

        #region Remove Equipment from Incident
        /// <summary>
        /// Associates a piece of equipment with a specific incident.
        /// </summary>
        /// <param name="equipmentId">The ID of the equipment.</param>
        /// <param name="incidentId">The ID of the incident.</param>
        public void RemoveEquipmentFromIncident(int equipmentId, int incidentId)
        {
            // Verificar se o equipamento existe, Verificar se o incidente existe, Verificar se a associação existe
            // Remover a associação, Repor a quantidade disponível do equipamento
        }

        #endregion

        #region Associate Equipment to Vehicle
        /// <summary>
        /// Assigns a piece of equipment to a specific vehicle.
        /// </summary>
        /// <param name="vehicleId">The ID of the vehicle.</param>
        /// <param name="equipmentId">The ID of the equipment.</param>
        /// <param name="quantity">The quantity to assign.</param>
        public void AssignEquipmentToVehicle(int vehicleId, int equipmentId, int quantity)
        {
            // Verificar se o veículo existe, Verificar se o equipamento existe, Verificar se há quantidade suficiente disponível
            // Verificar se o equipamento já está associado ao veículo, Criar a nova associação, Adicionar a associação e atualizar a quantidade disponível
        }

        #endregion

        #region Remove Equipment from Vehicle
        /// <summary>
        /// Removes a piece of equipment from a specific vehicle.
        /// </summary>
        /// <param name="vehicleId">The ID of the vehicle.</param>
        /// <param name="equipmentId">The ID of the equipment.</param>
        public void RemoveEquipmentFromVehicle(int vehicleId, int equipmentId)
        {
            // Verificar se o veículo existe, Verificar se o equipamento existe, Verificar se a associação existe, Repor a quantidade disponível do equipamento
        }
        #endregion

        #region List All Equipments
        /// <summary>
        /// Lists all equipments in the system.
        /// </summary>
        /// <returns>A list of all equipment</returns>
        public List<Equipment> ListAllEquipments()
        {
            return context.Equipments.ToList();
        }
        #endregion

        #region List Equipments by Status
        /// <summary>
        /// Lists equipments filtered by their status.
        /// </summary>
        /// <param name="status">The Status of the equipment</param>
        /// <returns>A list of equipment with the specified status</returns>
        public List<Equipment> ListEquipmentsByStatus(EquipmentStatus status)
        {
            return context.Equipments
                          .Where(e => e.Status == status)
                          .ToList();
        }
        #endregion

        #region List Equipments by Incident
        /// <summary>
        /// Retrieves all equipments associated with a specific incident.
        /// </summary>
        /// <param name="incidentId">The ID of the incident</param>
        /// <returns>A list of equipment associated with the specified incident</returns>
        public List<Equipment> GetEquipmentsByIncident(int incidentId)
        {
            var equipmentIds = context.EquipmentIncidents
                                       .Where(ei => ei.IncidentId == incidentId)
                                       .Select(ei => ei.EquipmentId)
                                       .ToList();

            return context.Equipments
                          .Where(e => equipmentIds.Contains(e.Id))
                          .ToList();
        }
        #endregion

        #region List Equipments by Vehicle
        /// <summary>
        /// Lists all equipments assigned to a specific vehicle
        /// </summary>
        /// <param name="vehicleId">The ID of the vehicle</param>
        public void ListEquipmentsForVehicle(int vehicleId)
        {
            var vehicle = context.Vehicles
                              .Include(v => v.VehicleEquipments)
                              .ThenInclude(ve => ve.Equipment)
                              .FirstOrDefault(v => v.Id == vehicleId);

            if (vehicle != null)
            {
                Console.WriteLine($"Equipamentos para o veículo {vehicle.VehicleRegist}:");
                foreach (var ve in vehicle.VehicleEquipments)
                {
                    Console.WriteLine($"{ve.Equipment.Name}");
                }
            }
        }
        #endregion

        #endregion
    }
}
