
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
using System.Data;
using TP_POO_a30517.Services;
using TP_POO_a30517.Vehicles;
using TP_POO_a30517.Equipments;
using TP_POO_a30517.Data;
using TP_POO_a30517.Interfaces;
using TP_POO_a30517.Incidents;
using ConsoleTables;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Numerics;

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
            #region Create Person
            //PersonsManager personsManager = new PersonsManager();
            //Nurse nurse = new Nurse("Teste Cláudio Fernandes", new DateOnly(1992, 12, 29), "05158", "585958555", "teste@teste.pt", "Rua de Viena 500", "Portuguesa", Roles.Enfermeiro, TeamType.INEM, PersonStatus.Disponível, "Teste Cláudio", 51000, "Pneumologia");
            //Doctor doctor = new Doctor("António Figueiredo Ramalho", new DateOnly(1990, 05, 29), "04512", "912345678", "Email@teste.pt", "Rua Porto, 100", "Portuguesa", Roles.Médico, TeamType.Bombeiros, PersonStatus.Disponível, "António Ramalho", 10210, "Cardiologia");
            //FireFighter firefighter = new FireFighter("Anacleto das Dores", new DateOnly(1980, 04, 30), "029445", "923456789", "POO@teste.pt", "Rua Campos, 67", "Portuguesa", Roles.Bombeiro, TeamType.Bombeiros, PersonStatus.Disponível, 5, "Resgate em Incêndios", 092205);
            //EmergencyTechnician technician = new EmergencyTechnician("Gil Fernandes", new DateOnly(1985, 10, 15), "01474", "924567890", "tec@teste.pt", "Rua Lisboa, 23", "Portuguesa", Roles.TécnicoEmergência, TeamType.INEM, PersonStatus.Disponível, "Gil F.", 020825);

            //// Adicionar profissionais ao manager
            //try
            //{
            //    personsManager.AddPerson(nurse);
            //    personsManager.AddPerson(doctor);
            //    personsManager.AddPerson(firefighter);
            //    personsManager.AddPerson(technician);
            //}
            //catch (InvalidOperationException ex)
            //{
            //    // Tratamento específico para a exceção de número de cédula já existente
            //    Console.WriteLine(ex.Message);
            //}
            //catch (FormatException ex)
            //{
            //    // Tratamento específico para e-mails inválidos
            //    Console.WriteLine(ex.Message);
            //}
            //catch (ArgumentNullException ex)
            //{
            //    // Tratamento para casos onde a pessoa é nula
            //    Console.WriteLine(ex.Message);
            //}
            //catch (Exception ex)
            //{
            //    // Tratamento para outras exceções não específicas
            //    Console.WriteLine("Ocorreu um erro inesperado: " + ex.Message);
            //}
            #endregion

            #region List Person by Status
            //try
            //{
            //    using (var context = new EmergenciesDBContext())
            //    {
            //        var personsManager = new PersonsManager();

            //        Console.WriteLine("Digite o estado da pessoa (Disponível, Férias, Baixa_Médica, Ausente, Outro):");
            //        string inputStatus = Console.ReadLine();

            //        // Converter a entrada do utilizador para o enum PersonStatus
            //        if (Enum.TryParse(inputStatus, true, out PersonStatus status))
            //        {
            //            personsManager.PersonsByStatus(status);
            //        }
            //        else
            //        {
            //            Console.WriteLine("Status inválido.");
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"Erro: {ex.Message}");
            //}
            #endregion

            #region List All Person
            //try
            //{
            //    using (var context = new EmergenciesDBContext())
            //    {
            //        var personsManager = new PersonsManager();
            //        List<Person> persons = personsManager.GetAllPersons();

            //        var table = new ConsoleTable("ID", "Nome", "Estado");
            //        foreach (var person in persons)
            //        {
            //            table.AddRow(person.Id, person.Name, person.Status);
            //        }
            //        table.Write();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"Erro: {ex.Message}");
            //}
            #endregion

            #region Create Vehicle
            //try
            //{
            //    VehiclesManager vehiclesManager = new VehiclesManager();
            //    LogisticalSupport vpmt = new LogisticalSupport("MT-888-BB", new DateOnly(2022, 06, 15), VehiclesType.Veículo_de_Protecção_Multirriscos_Táctico_VPMT, "Mercedes", "Unimog",
            //        new DateOnly(2023, 06, 15), VehiclesStatus.Disponível, 2500, EquipmentType.Ferramentas);
            //    vehiclesManager.CreateVehicle(vpmt);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"{ex.Message}");
            //}
            #endregion

            #region Create Equipment
            //EquipmentsManager equipmentsManager = new EquipmentsManager();

            //Equipment equipment = new Equipment("Desfibrilador", EquipmentType.Ferramentas, 10, EquipmentStatus.Disponível);
            //try
            //{
            //    equipmentsManager.AddEquipment(equipment);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"{ex.Message}");
            //}
            #endregion

        }
    }
}