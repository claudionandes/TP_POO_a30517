
//-----------------------------------------------------------------
//    <copyright file="DependencyInjection.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>11-12-2024</date>
//    <author>Cláudio Fernandes</author>
//-----------------------------------------------------------------

using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using TP_POO_a30517.Data;
using TP_POO_a30517.Interfaces;
using TP_POO_a30517.Services;
using TP_POO_a30517.LoginUser;
using Serilog;

namespace TP_POO_a30517.DependencyInjectionDI
{
    /// <summary>
    /// Configures dependency injection for the application
    /// </summary>
    public class DependencyInjection
    {
        /// <summary>
        /// Configures services for dependency injection
        /// </summary>
        /// <param name="services">The IServiceCollection to configure</param>
        public static void ConfServ(IServiceCollection services)
        {
            #region Logging
            services.AddLogging(builder =>
            {
                builder.AddSerilog();
            });
            #endregion

            #region Database Configuration
            services.AddDbContext<EmergenciesDBContext>(options => options.UseSqlServer("Server=CLAUDIO\\SQLEXPRESS;Database=TP_POO_Emergency_DB;Trusted_Connection=True;Encrypt=False"));
            #endregion

            #region Singleton Services
            services.AddSingleton<DataBaseConnection>(DataBaseConnection.Instance);
            #endregion

            #region Scoped Services
            services.AddScoped<IAuthenticate, AuthManager>();
            services.AddScoped<IAddUser, AddUser>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<IPersonsManager, PersonsManager>();
            services.AddScoped<IIncidentManager, IncidentsManager>();
            services.AddScoped<IEquipmentsManager, EquipmentsManager>();
            services.AddScoped<IVehiclesManager, VehiclesManager>();
            services.AddScoped<ITeamsManager, TeamsManager>();
            #endregion

            services.AddTransient<Authenticate>();
        }
    }
}
