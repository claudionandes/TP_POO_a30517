
//-----------------------------------------------------------------
//    <copyright file="EquipmentsManager.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>30-10-2024</date>
//    <author>Cláudio Fernandes</author>
//-----------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_POO_a30517.Data;
using TP_POO_a30517.Enums;
using TP_POO_a30517.Equipments;
using TP_POO_a30517.Interfaces;
using TP_POO_a30517.Relations;
using TP_POO_a30517.Vehicles;

namespace TP_POO_a30517.Services
{
    public class EquipmentsManager : IEquipmentsManager
    {
        #region Private Properties
        private EmergenciesDBContext context;
        #endregion

        #region Constructor
        public EquipmentsManager(EmergenciesDBContext context)
        {
            this.context = context;
        }
        #endregion

        #region Public Methods

        #region Add Equipment
        public void AddEquipment(Equipment equipment)
        {
                context.Equipments.Add(equipment);
                context.SaveChanges();
                Console.WriteLine("Equipamento inserido com sucesso");
        }
        #endregion

        #region Update Equipment
        public void UpdateEquipment(int id, Dictionary<string, object> updates)
        {
        }
        #endregion

        #region Delete Equipment
        public void DeleteEquipment(int id)
        {
            // Remover as relações com veículos, Remover as relações com incidentes
        }
        #endregion

        #region Associate Equipment with Incident
        public void AssociateEquipmentWithIncident(int equipmentId, int incidentId)
        {
            // Verificar se o equipamento existe, Verificar se o incidente existe, Verificar se a associação já existe
            // Criar nova associação, Atualizar a quantidade disponível do equipamento
        }

        #endregion

        #region Remove Equipment from Incident
        public void RemoveEquipmentFromIncident(int equipmentId, int incidentId)
        {
            // Verificar se o equipamento existe, Verificar se o incidente existe, Verificar se a associação existe
            // Remover a associação, Repor a quantidade disponível do equipamento
        }

        #endregion

        #region Associate Equipment to Vehicle
        public void AssignEquipmentToVehicle(int vehicleId, int equipmentId, int quantity)
        {
            // Verificar se o veículo existe, Verificar se o equipamento existe, Verificar se há quantidade suficiente disponível
            // Verificar se o equipamento já está associado ao veículo, Criar a nova associação, Adicionar a associação e atualizar a quantidade disponível
        }

        #endregion

        #region Remove Equipment from Vehicle
        public void RemoveEquipmentFromVehicle(int vehicleId, int equipmentId)
        {
            // Verificar se o veículo existe, Verificar se o equipamento existe, Verificar se a associação existe, Repor a quantidade disponível do equipamento
        }
        #endregion

        #region List All Equipments
        public List<Equipment> ListAllEquipments()
        {
            return context.Equipments.ToList();
        }
        #endregion

        #region List Equipments by Status
        public List<Equipment> ListEquipmentsByStatus(EquipmentStatus status)
        {
            return context.Equipments
                          .Where(e => e.Status == status)
                          .ToList();
        }
        #endregion

        #region List Equipments by Incident
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
