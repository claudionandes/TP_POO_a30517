
//-----------------------------------------------------------------
//    <copyright file="Program.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>31-10-2024</date>
//    <author>Cláudio Fernandes</author>
//-----------------------------------------------------------------

using TP_POO_a30517.Enums;
using TP_POO_a30517.Models;
using TP_POO_a30517.Teams;
using TP_POO_a30517.Incidents;
using TP_POO_a30517.Equipments;
using Utils;


namespace TP_POO_a30517
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //ApplicationConfiguration.Initialize();
            //Application.Run(new Form1());
            #region Person
            Nurse nurse = new Nurse("Joana Silva Ferreira", new DateOnly(1978, 10, 10), "1234555", "987654321", "teste@teste.pt", "Rua de Viena 40", "Portuguesa", Roles.Enfermeiro, "Joana Silva", "12345", "Pneumologia");
            Doctor doctor = new Doctor("Carlos Teixeira Pereira", new DateOnly(1990, 05, 29), "5820288", "912345678", "Email@teste.pt", "Rua Porto, 100", "Portuguesa", Roles.Médico, "Carlos Pereira", "11111", "Cardiologia");
            FireFighter firefighter = new FireFighter("Pedro Sousa", new DateOnly(1980, 04, 30), "456789123", "923456789", "POO@teste.pt", "Rua Campos, 67", "Portuguesa", Roles.Bombeiro, 5, "Resgate em Incêndios");
            EmergencyTechnician technician = new EmergencyTechnician("André Fernandes", new DateOnly(1985, 10, 15), "789456123", "924567890", "tec@teste.pt", "Rua Lisboa, 23", "Portuguesa", Roles.TécnicoEmergência, "André F.", "22222");
            #endregion

            #region Professional Details
            //Console.WriteLine("Professional Details:");
            //Console.WriteLine(nurse.ReturnsValuesPerson());
            //Console.WriteLine();
            //Console.WriteLine(doctor.ReturnsValuesPerson());
            //Console.WriteLine();
            //Console.WriteLine(firefighter.ReturnsValuesPerson());
            #endregion

            #region INEM Team Creation
            INEM inemTeam = new INEM("INEM Team A", doctor, nurse, technician, VehiclesType.Ambulância_de_Emergência_Médica_AEM, EquipmentType.Desfibrilhador, TeamStatus.Alocado);
            #endregion

            #region Display INEM Team Details
            Console.WriteLine("INEM Team Details:");
            Console.WriteLine(inemTeam.TeamDetailsINEM());
            #endregion

            #region Add professionals to a list
            List<Person> members = new List<Person> { firefighter, doctor, nurse};
            #endregion

            #region Rescue Team Creation
            RescueTeam rescueTeam = new RescueTeam("Rescue Team A", members, TeamStatus.Disponível,VehiclesType.Ambulância_de_Socorro, EquipmentType.Cadeira_Transporte);
            #endregion

            #region Display Rescue Team Details
            Console.WriteLine("\nRescue Team Details:");
            Console.WriteLine(rescueTeam.TeamDetailsRescueTeam());
            #endregion

        }
    }
}