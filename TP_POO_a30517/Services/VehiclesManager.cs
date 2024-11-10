
//-----------------------------------------------------------------
//    <copyright file="VehiclesManager.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>01-11-2024</date>
//    <author>Cláudio Fernandes</author>
//-----------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_POO_a30517.Data;
using TP_POO_a30517.Enums;
using TP_POO_a30517.Interfaces;
using TP_POO_a30517.Models;
using TP_POO_a30517.Relations;
using TP_POO_a30517.Vehicles;

namespace TP_POO_a30517.Services
{
    public class VehiclesManager : IVehiclesManager
    {
        #region Private Properties
        private List<Vehicle> vehicles;
        private EmergenciesDBContext context;
        #endregion

        #region Public Properties
        public VehiclesManager()
        {
            vehicles = new List<Vehicle>();
        }
        #endregion

        #region Constructor
        public VehiclesManager(EmergenciesDBContext context)
        {
            this.context = context;
        }
        #endregion

        #region Public Methods

        #region Create Vehicles
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
        public void UpdateVehicle(string vehicleRegist, Dictionary<string, object> updates)
        {
        }

        #endregion

        #region Delete Vehicle
        public void DeleteVehicle(string vehicleRegist)
        {
            using (var context = new EmergenciesDBContext())
            {
                
            }
        }

        #endregion

        #region Assign Vehicle To Incident
        public void AssignVehicleToIncident(int vehicleId, int incidentId)
        {
            // Verificar se o veículo existe, Verificar se o incidente existe, Verificar se a associação já existe, Criar nova associação
        }

        #endregion

        #region Remove Vehicle From Incident
        public void RemoveVehicleFromIncident(int vehicleId, int incidentId)
        {
            // Verificar se o veículo existe, Verificar se o incidente existe
        }
        #endregion

        #region List all Vehicles
        public List<Vehicle> ListAllVehicles()
        {
            return context.Vehicles.ToList();
        }
        #endregion

        #region List Vehicles by Type
        public List<Vehicle> ListVehiclesByType(VehiclesType type)
        {
            return context.Vehicles.Where(v => v.Type == type).ToList();
        }
        #endregion

        #endregion
    }
}

