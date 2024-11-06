
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
using TP_POO_a30517.Data;
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
            using (var context = new EmergenciesDBContext())
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
        }
        #endregion

        #region Update Vehicle
        public void UpdateVehicle(string vehicleRegist, Dictionary<string, object> updates)
        {
            using (var context = new EmergenciesDBContext())
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
        }


        #endregion

        #region Delete Vehicle
        public void DeleteVehicle(string vehicleRegist)
        {
            using (var context = new EmergenciesDBContext())
            {
                var vehicleDelete = context.Vehicles.FirstOrDefault(v => v.VehicleRegist == vehicleRegist);

                if (vehicleDelete != null)
                {
                    context.Vehicles.Remove(vehicleDelete);
                    context.SaveChanges();
                    Console.WriteLine("Veículo eliminado com sucesso");
                }
                else
                {
                    throw new KeyNotFoundException($"Veículo com a matrícula {vehicleRegist} não encontrado");
                }
            }
        }
        #endregion

        #region List Vehicles by Type
        public List<Vehicle> ListVehiclesByType(VehiclesType type)
        {
            using (var context = new EmergenciesDBContext())
            {
                return context.Vehicles.Where(v => v.Type == type).ToList();
            }
        }
        #endregion

        #region List all Vehicles
        public List<Vehicle> ListAllVehicles()
        {
            using (var context = new EmergenciesDBContext())
            {
                return context.Vehicles.ToList();
            }
        }
        #endregion

        #endregion
    }
}

