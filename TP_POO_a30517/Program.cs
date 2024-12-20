
//-----------------------------------------------------------------
//    <copyright file="Program.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>31-10-2024</date>
//    <author>Cláudio Fernandes</author>
//-----------------------------------------------------------------


using Microsoft.Extensions.DependencyInjection;
using TP_POO_a30517.DependencyInjectionDI;
using Serilog;
using Microsoft.Extensions.Logging;

namespace TP_POO_a30517
{
    /// <summary>
    /// Main program class
    /// </summary>
    internal static class Program
    {
        #region Main Method
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ConfigureLogger();
            ConfigureApplication();
            RunApplication();
        }

        #endregion

        #region Configuration Methods

        /// <summary>
        /// Configures the Serilog logger
        /// </summary>
        private static void ConfigureLogger()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File(@"C:\Users\ferna\source\repos\TP_POO_a30517\TP_POO_a30517\Logs\log.txt",
                    rollingInterval: RollingInterval.Day)
            .CreateLogger();
        }

        /// <summary>
        /// Configures the application settings
        /// </summary>
        private static void ConfigureApplication()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
        }

        /// <summary>
        /// Runs the application
        /// </summary>
        private static void RunApplication()
        {
            var services = new ServiceCollection();
            DependencyInjection.ConfServ(services);

            var serviceProvider = services.BuildServiceProvider();

            var logger = serviceProvider.GetRequiredService<ILoggerFactory>().CreateLogger("ApplicationLogger");
            logger.LogInformation("Aplicação iniciada com sucesso.");

            var loginForm = serviceProvider.GetRequiredService<Authenticate>();
            Application.Run(loginForm);

            Log.CloseAndFlush();
        }
        #endregion
    }
}