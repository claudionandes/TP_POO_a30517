
//-----------------------------------------------------------------
//    <copyright file="VehiclesManager.cs" company="IPCA">
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
using TP_POO_a30517.Interfaces;
using TP_POO_a30517.Models;
using TP_POO_a30517.Vehicles;

namespace TP_POO_a30517.Services
{
    public class VehiclesManager : IVehiclesManager
    {
        #region Private Properties
        private List<Vehicle> vehicles;
        #endregion

        #region Public Properties
        public VehiclesManager()
        {
            vehicles = new List<Vehicle>();
        }
        #endregion

        #region Public Methods

        #region Create Vehicles
        public void CreateVehicle(Vehicle vehicle)
        {
            vehicles.Add(vehicle);
            Console.WriteLine("Veículo criado com sucesso");
        }
        #endregion

        #region Update Vehicle
        public void UpdateVehicle(string vehicleRegist, Dictionary<string, object> updates)
        {
            var vehicle = vehicles.FirstOrDefault(v => v.VehicleRegist == vehicleRegist);

            if (vehicle != null)
            {
                foreach (var update in updates)
                {
                    var propertyInfo = typeof(Vehicle).GetProperty(update.Key);
                    if (propertyInfo != null && propertyInfo.CanWrite)
                    {
                        propertyInfo.SetValue(vehicle, update.Value);
                    }
                }
                Console.WriteLine("Veículo atualizado com sucesso");
            }
            else
            {
                throw new KeyNotFoundException($"Veículo com a matrícula {vehicleRegist} não encontrado");
            }
        }
        #endregion

        #region Delete Vehicle
        public void DeleteVehicle(string vehicleRegist)
        {
            var vehicleDelete = vehicles.FirstOrDefault(v => v.VehicleRegist == vehicleRegist);

            if (vehicleDelete != null)
            {
                vehicles.Remove(vehicleDelete);
                Console.WriteLine("Veículo eliminado com sucesso");
            }
            else
            {
                throw new KeyNotFoundException($"Veículo com a matrícula {vehicleRegist} não encontrado");
            }
        }
        #endregion

        #region List Vehicles by Type
        public List<Vehicle> ListVehiclesByType(VehiclesType type)
        {
            return vehicles.Where(v => v.Type == type).ToList();
        }
        #endregion

        #region List all Vehicles
        public List<Vehicle> ListAllVehicles()
        {
            return vehicles;
        }
        #endregion

        #endregion
    }
}
