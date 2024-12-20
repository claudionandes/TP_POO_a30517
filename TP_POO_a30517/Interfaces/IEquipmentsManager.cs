
//-----------------------------------------------------------------
//    <copyright file="IEquipmentsManager.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>01-11-2024</date>
//    <author>Cláudio Fernandes</author>
//    <summary>
//     Defines the IEquipmentsManager interface for managing emergency equipment.
//    </summary>
//-----------------------------------------------------------------

using TP_POO_a30517.Enums;
using TP_POO_a30517.Equipments;

namespace TP_POO_a30517.Interfaces
{
    /// <summary>
    /// Defines methods for managing emergency equipment.
    /// </summary>
    public interface IEquipmentsManager
    {
        #region Methods
        void AddEquipment(Equipment equipment);
        void UpdateEquipment(int id, Dictionary<string, object> updates);
        void DeleteEquipment(int id);
        public void AssociateEquipmentWithIncident(int equipmentId, int incidentId);
        public void RemoveEquipmentFromIncident(int equipmentId, int incidentId);
        public void AssignEquipmentToVehicle(int vehicleId, int equipmentId, int quantity);
        public void RemoveEquipmentFromVehicle(int vehicleId, int equipmentId);
        public List<Equipment> ListAllEquipments();
        public List<Equipment> ListEquipmentsByStatus(EquipmentStatus status);
        public List<Equipment> GetEquipmentsByIncident(int incidentId);
        public void ListEquipmentsForVehicle(int vehicleId);
        #endregion
    }
}
