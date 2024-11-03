
//-----------------------------------------------------------------
//    <copyright file="EquipmentsManager.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>30-10-2024</date>
//    <author>Cláudio Fernandes</author>
//-----------------------------------------------------------------

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

namespace TP_POO_a30517.Services
{
    public class EquipmentsManager : IEquipmentsManager
    {
        #region Private Properties
       
        #endregion

        #region Constructor
        public EquipmentsManager() { }
        #endregion

        #region Public Methods

        #region Add Equipment
        public void AddEquipment(Equipment equipment)
        {
            using (var context = new EmergenciesDBContext())
            {
                context.Equipments.Add(equipment);
                context.SaveChanges();
                Console.WriteLine("Equipamento inserido com sucesso");
            }
        }
        #endregion

        #region Associate Equipment with Incident
        public void AssociateEquipmentWithIncident(int equipmentId, int incidentId)
        {
            using (var context = new EmergenciesDBContext())
            {
                var equipment = context.Equipments.FirstOrDefault(e => e.Id == equipmentId);
                var incident = context.Incidents.FirstOrDefault(i => i.Id == incidentId);

                if (equipment == null)
                {
                    throw new KeyNotFoundException($"Equipamento com ID {equipmentId} não encontrado");
                }

                if (incident == null)
                {
                    throw new KeyNotFoundException($"Incidente com ID {incidentId} não encontrado");
                }

                // Adiciona a associação
                var equipmentIncident = new EquipmentIncident
                {
                    EquipmentId = equipmentId,
                    IncidentId = incidentId
                };

                context.EquipmentIncidents.Add(equipmentIncident);

                // Atualiza a lista EquipmentUsed do incidente com o ID do equipamento
                if (incident.EquipmentUsed == null)
                {
                    incident.EquipmentUsed = new List<EquipmentType>();
                }

                // Adiciona o ID do equipamento à lista EquipmentUsed
                incident.EquipmentUsed.Add(equipment.Type);

                context.SaveChanges();
                Console.WriteLine("Equipamento associado ao incidente com sucesso");
            }
        }
        #endregion

        #region Remove Equipment from Incident
        public void RemoveEquipmentFromIncident(int equipmentId, int incidentId)
        {
            using (var context = new EmergenciesDBContext())
            {
                var association = context.EquipmentIncidents
                    .FirstOrDefault(ei => ei.EquipmentId == equipmentId && ei.IncidentId == incidentId);

                if (association != null)
                {
                    context.EquipmentIncidents.Remove(association);
                    context.SaveChanges();
                    Console.WriteLine("Associação de equipamento removida do incidente com sucesso");
                }
                else
                {
                    throw new KeyNotFoundException($"Associação entre equipamento {equipmentId} e incidente {incidentId} não encontrada");
                }
            }
        }
        #endregion

        #region Update Equipment
        public void UpdateEquipment(int id, Dictionary<string, object> updates)
        {
            using (var context = new EmergenciesDBContext())
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
        }
        #endregion

        #region Delete Equipment
        public void DeleteEquipment(int id)
        {
            using (var context = new EmergenciesDBContext())
            {
                var equipment = context.Equipments.FirstOrDefault(e => e.Id == id);
                if (equipment != null)
                {
                    context.Equipments.Remove(equipment);
                    context.SaveChanges();
                    Console.WriteLine("Equipamento eliminado com sucesso");
                }
                else
                {
                    throw new KeyNotFoundException($"Equipamento com ID {id} não encontrado");
                }
            }
        }
        #endregion

        #region List Available Equipments
        public List<Equipment> AvailableEquipments()
        {
            using (var context = new EmergenciesDBContext())
            {
                return context.Equipments
                              .Where(e => e.Status == EquipmentStatus.Disponível)
                              .ToList();
            }
        }
        #endregion

        #region List Equipments by Incident
        public List<Equipment> GetEquipmentsByIncident(int incidentId)
        {
            using (var context = new EmergenciesDBContext())
            {
                var equipmentIds = context.EquipmentIncidents
                                           .Where(ei => ei.IncidentId == incidentId)
                                           .Select(ei => ei.EquipmentId)
                                           .ToList();

                return context.Equipments
                              .Where(e => equipmentIds.Contains(e.Id))
                              .ToList();
            }
        }
        #endregion

        #endregion
    }
}
