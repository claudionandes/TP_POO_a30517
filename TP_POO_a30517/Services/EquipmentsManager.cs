
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
            var equipmentToUpdate = context.Equipments.FirstOrDefault(e => e.Id == id);
            if (equipmentToUpdate != null)
            {
                foreach (var update in updates)
                {
                    switch (update.Key.ToLower())
                    {
                        case "name":
                            equipmentToUpdate.Name = update.Value as string;
                            break;
                        case "type":
                            equipmentToUpdate.Type = (EquipmentType)update.Value;
                            break;
                        case "quantityavailable":
                            equipmentToUpdate.QuantityAvailable = Convert.ToInt32(update.Value);
                            break;
                        case "status":
                            equipmentToUpdate.Status = (EquipmentStatus)update.Value;
                            break;
                        default:
                            Console.WriteLine($"Atributo desconhecido: {update.Key}");
                            break;
                    }
                }

                context.SaveChanges();
                Console.WriteLine("Equipamento atualizado com sucesso");
            }
            else
            {
                throw new KeyNotFoundException($"Equipamento com ID {id} não encontrado");
            }
        }
        #endregion

        #region Delete Equipment
        /// <summary>
        /// Deletes an equipment from the system.
        /// </summary>
        /// <param name="id">The ID of the equipment to delete.</param>
        public void DeleteEquipment(int id)
        {
            var equipment = context.Equipments.FirstOrDefault(e => e.Id == id);

            if (equipment != null)
            {
                // Remover as relações com veículos
                var vehicleEquipments = context.Set<VehicleEquipment>().Where(ve => ve.EquipmentId == id).ToList();
                if (vehicleEquipments.Any())
                {
                    context.Set<VehicleEquipment>().RemoveRange(vehicleEquipments);
                }

                // Remover as relações com incidentes
                var equipmentIncidents = context.Set<EquipmentIncident>().Where(ei => ei.EquipmentId == id).ToList();
                if (equipmentIncidents.Any())
                {
                    context.Set<EquipmentIncident>().RemoveRange(equipmentIncidents);
                }

                context.Equipments.Remove(equipment);
                context.SaveChanges();

                Console.WriteLine("Equipamento eliminado com sucesso");
            }
            else
            {
                throw new KeyNotFoundException($"Equipamento com ID {id} não encontrado");
            }
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
            // Verificar se o equipamento existe
            var equipment = context.Equipments.FirstOrDefault(e => e.Id == equipmentId);
            if (equipment == null)
            {
                throw new KeyNotFoundException($"Equipamento com ID {equipmentId} não encontrado");
            }

            // Verificar se o incidente existe
            var incident = context.Incidents.FirstOrDefault(i => i.Id == incidentId);
            if (incident == null)
            {
                throw new KeyNotFoundException($"Incidente com ID {incidentId} não encontrado");
            }

            // Verificar se a associação já existe
            var existingRelation = context.EquipmentIncidents
                .FirstOrDefault(ei => ei.EquipmentId == equipmentId && ei.IncidentId == incidentId);

            if (existingRelation != null)
            {
                Console.WriteLine($"O equipamento ID {equipmentId} já está associado ao incidente ID {incidentId}");
                return;
            }

            // Criar nova associação
            var equipmentIncident = new EquipmentIncident
            {
                EquipmentId = equipmentId,
                IncidentId = incidentId
            };

            context.EquipmentIncidents.Add(equipmentIncident);

            // Atualizar a quantidade disponível do equipamento
            if (equipment.QuantityAvailable > 0)
            {
                equipment.QuantityAvailable -= 1;
            }
            else
            {
                Console.WriteLine($"Equipamento ID {equipmentId} está indisponível");
                return;
            }

            context.SaveChanges();
            Console.WriteLine($"Equipamento ID {equipmentId} associado ao incidente ID {incidentId} com sucesso");
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
            // Verificar se o equipamento existe
            var equipment = context.Equipments.FirstOrDefault(e => e.Id == equipmentId);
            if (equipment == null)
            {
                throw new KeyNotFoundException($"Equipamento com ID {equipmentId} não encontrado");
            }

            // Verificar se o incidente existe
            var incident = context.Incidents.FirstOrDefault(i => i.Id == incidentId);
            if (incident == null)
            {
                throw new KeyNotFoundException($"Incidente com ID {incidentId} não encontrado");
            }

            // Verificar se a associação existe
            var equipmentIncident = context.EquipmentIncidents
                .FirstOrDefault(ei => ei.EquipmentId == equipmentId && ei.IncidentId == incidentId);

            if (equipmentIncident == null)
            {
                Console.WriteLine($"O equipamento ID {equipmentId} não está associado ao incidente ID {incidentId}");
                return;
            }

            // Remover a associação
            context.EquipmentIncidents.Remove(equipmentIncident);

            // Repor a quantidade disponível do equipamento
            equipment.QuantityAvailable += 1;

            context.SaveChanges();
            Console.WriteLine($"Equipamento ID {equipmentId} desassociado do incidente ID {incidentId} com sucesso");
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
            // Verificar se o veículo existe
            var vehicle = context.Vehicles.FirstOrDefault(v => v.Id == vehicleId);
            if (vehicle == null)
            {
                throw new KeyNotFoundException($"Veículo com ID {vehicleId} não encontrado");
            }

            // Verificar se o equipamento existe
            var equipment = context.Equipments.FirstOrDefault(e => e.Id == equipmentId);
            if (equipment == null)
            {
                throw new KeyNotFoundException($"Equipamento com ID {equipmentId} não encontrado");
            }

            // Verificar se há quantidade suficiente disponível
            if (equipment.QuantityAvailable < quantity)
            {
                throw new InvalidOperationException($"Quantidade insuficiente de {equipment.Name}. Disponível: {equipment.QuantityAvailable}, Requerido: {quantity}");
            }

            // Verificar se o equipamento já está associado ao veículo
            var existingAssociation = context.VehicleEquipments
                .FirstOrDefault(ve => ve.VehicleId == vehicleId && ve.EquipmentId == equipmentId);

            if (existingAssociation != null)
            {
                throw new InvalidOperationException($"O equipamento ID {equipmentId} já está associado ao veículo ID {vehicleId}");
            }

            // Criar a nova associação
            var vehicleEquipment = new VehicleEquipment
            {
                VehicleId = vehicleId,
                EquipmentId = equipmentId,
                Quantity = quantity
            };

            // Adicionar a associação e atualizar a quantidade disponível
            context.VehicleEquipments.Add(vehicleEquipment);
            equipment.QuantityAvailable -= quantity;

            context.SaveChanges();
            Console.WriteLine($"Equipamento ID {equipmentId} associado ao veículo ID {vehicleId} com sucesso.");
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
            // Verificar se o veículo existe
            var vehicle = context.Vehicles.FirstOrDefault(v => v.Id == vehicleId);
            if (vehicle == null)
            {
                throw new KeyNotFoundException($"Veículo com ID {vehicleId} não encontrado");
            }

            // Verificar se o equipamento existe
            var equipment = context.Equipments.FirstOrDefault(e => e.Id == equipmentId);
            if (equipment == null)
            {
                throw new KeyNotFoundException($"Equipamento com ID {equipmentId} não encontrado");
            }

            // Verificar se a associação existe
            var vehicleEquipment = context.VehicleEquipments
                .FirstOrDefault(ve => ve.VehicleId == vehicleId && ve.EquipmentId == equipmentId);

            if (vehicleEquipment == null)
            {
                throw new InvalidOperationException($"A associação entre o equipamento ID {equipmentId} e o veículo ID {vehicleId} não foi encontrada");
            }

            // Repor a quantidade disponível do equipamento
            equipment.QuantityAvailable += vehicleEquipment.Quantity;

            // Remover a associação
            context.VehicleEquipments.Remove(vehicleEquipment);

            context.SaveChanges();
            Console.WriteLine($"Associação do equipamento ID {equipmentId} com o veículo ID {vehicleId} removida com sucesso");
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
