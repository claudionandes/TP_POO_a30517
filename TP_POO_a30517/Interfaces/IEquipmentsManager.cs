
//-----------------------------------------------------------------
//    <copyright file="IEquipmentsManager.cs" company="IPCA">
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
using TP_POO_a30517.Equipments;
using TP_POO_a30517.Teams;

namespace TP_POO_a30517.Interfaces
{
    public interface IEquipmentsManager
    {
        void AddEquipment(Equipment equipment);
        void UpdateEquipment(int id, Dictionary<string, object> updates);
        void DeleteEquipment(int id);
        List<Equipment> AvailableEquipments();
        
    }
}
