
//-----------------------------------------------------------------
//    <copyright file="Program.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>31-10-2024</date>
//    <author>Cl�udio Fernandes</author>
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
            //Nurse nurse = new Nurse("Teste Cl�udio Fernandes", new DateOnly(1992, 12, 29), "05158", "585958555", "teste@teste.pt", "Rua de Viena 500", "Portuguesa", Roles.Enfermeiro, TeamType.INEM, PersonStatus.Dispon�vel, "Teste Cl�udio", 51000, "Pneumologia");
            //Doctor doctor = new Doctor("Ant�nio Figueiredo Ramalho", new DateOnly(1990, 05, 29), "04512", "912345678", "Email@teste.pt", "Rua Porto, 100", "Portuguesa", Roles.M�dico, TeamType.Bombeiros, PersonStatus.Dispon�vel, "Ant�nio Ramalho", 10210, "Cardiologia");
            //FireFighter firefighter = new FireFighter("Anacleto das Dores", new DateOnly(1980, 04, 30), "029445", "923456789", "POO@teste.pt", "Rua Campos, 67", "Portuguesa", Roles.Bombeiro, TeamType.Bombeiros, PersonStatus.Dispon�vel, 5, "Resgate em Inc�ndios", 092205);
            //EmergencyTechnician technician = new EmergencyTechnician("Gil Fernandes", new DateOnly(1985, 10, 15), "01474", "924567890", "tec@teste.pt", "Rua Lisboa, 23", "Portuguesa", Roles.T�cnicoEmerg�ncia, TeamType.INEM, PersonStatus.Dispon�vel, "Gil F.", 020825);

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
            //    // Tratamento espec�fico para a exce��o de n�mero de c�dula j� existente
            //    Console.WriteLine(ex.Message);
            //}
            //catch (FormatException ex)
            //{
            //    // Tratamento espec�fico para e-mails inv�lidos
            //    Console.WriteLine(ex.Message);
            //}
            //catch (ArgumentNullException ex)
            //{
            //    // Tratamento para casos onde a pessoa � nula
            //    Console.WriteLine(ex.Message);
            //}
            //catch (Exception ex)
            //{
            //    // Tratamento para outras exce��es n�o espec�ficas
            //    Console.WriteLine("Ocorreu um erro inesperado: " + ex.Message);
            //}
            #endregion

            #region Update Person
            //var personsManager = new PersonsManager();
            //int ID = 2;
            //var updates = new Dictionary<string, object>
            //{
            //    { "Name", "Cl�udio Teste Fernandes" },
            //    { "Email", "EmailTeste_Novo@example.com" },
            //    { "Status", PersonStatus.Baixa_M�dica },
            //};

            //try
            //{
            //    personsManager.UpdatePerson(ID, updates);
            //}
            //catch (KeyNotFoundException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"{ex.Message}");
            //}
            #endregion

            #region Delete Person
            //try
            //{
            //    using (var context = new EmergenciesDBContext())
            //    {
            //        var personsManager = new PersonsManager();
            //        var people = context.Set<Person>().ToList();

            //        Console.WriteLine("Lista de Pessoas:");
            //        for (int i = 0; i < people.Count; i++)
            //        {
            //            Console.WriteLine($"ID: {people[i].Id} {people[i].Name}");
            //        }

            //        Console.Write("Insira o ID da pessoa a ser eliminada: ");
            //        int personIdToDelete;
            //        bool isValidId = int.TryParse(Console.ReadLine(), out personIdToDelete);

            //        if (!isValidId || !people.Any(p => p.Id == personIdToDelete))
            //        {
            //            Console.WriteLine("ID inv�lido");
            //        }
            //        else
            //        {
            //            personsManager.DeletePerson(personIdToDelete);
            //        }
            //    }
            //}
            //catch (InvalidOperationException ex)
            //{
            //    Console.WriteLine($"{ex.Message}");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"{ex.Message}");
            //}

            #endregion

            #region Associate Person (Available) to Team
            //try
            //{
            //    using (var context = new EmergenciesDBContext())
            //    {
            //        var personsManager = new PersonsManager();

            //        int personId = 9;
            //        int teamId = 4;

            //        personsManager.AssociatePersonToTeam(personId, teamId);
            //    }
            //}
            //catch (InvalidOperationException ex)
            //{
            //    Console.WriteLine($"{ex.Message}");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"{ex.Message}");
            //}
            #endregion

            #region Dissociate Person From Team
            //try
            //{
            //    using (var context = new EmergenciesDBContext())
            //    {
            //        var personsManager = new PersonsManager();

            //        int personId = 28;
            //        int teamId = 3;

            //        personsManager.DissociatePersonFromTeam(personId, teamId);
            //    }
            //}
            //catch (InvalidOperationException ex)
            //{
            //    Console.WriteLine($"{ex.Message}");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"{ex.Message}");
            //}
            #endregion

            #region List Person by Status
            //try
            //{
            //    using (var context = new EmergenciesDBContext())
            //    {
            //        var personsManager = new PersonsManager();

            //        Console.WriteLine("Digite o estado da pessoa (Dispon�vel, F�rias, Baixa_M�dica, Ausente, Outro):");
            //        string inputStatus = Console.ReadLine();

            //        // Converter a entrada do utilizador para o enum PersonStatus
            //        if (Enum.TryParse(inputStatus, true, out PersonStatus status))
            //        {
            //            personsManager.PersonsByStatus(status);
            //        }
            //        else
            //        {
            //            Console.WriteLine("Status inv�lido.");
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

            #region Add Equipment
        //EquipmentsManager equipmentsManager = new EquipmentsManager();

        //Equipment equipment = new Equipment("Desfibrilador", EquipmentType.Ferramentas, 10, EquipmentStatus.Dispon�vel);
        //try
        //{
        //    equipmentsManager.AddEquipment(equipment);
        //}
        //catch (Exception ex)
        //{
        //    Console.WriteLine($"{ex.Message}");
        //}
        #endregion

            #region Asociate Equipment to Incident
        //EquipmentsManager equipmentsManager = new EquipmentsManager();

        //int equipmentId = 20;
        //int incidentId = 1;

        //try
        //{
        //    // Associar o equipamento ao incidente
        //    equipmentsManager.AssociateEquipmentWithIncident(equipmentId, incidentId);
        //    Console.WriteLine($"Equipamento com ID {equipmentId} associado ao incidente com ID {incidentId} com sucesso.");
        //}
        //catch (KeyNotFoundException ex)
        //{
        //    Console.WriteLine(ex.Message);
        //}
        //catch (Exception ex)
        //{
        //    Console.WriteLine($"{ex.Message}");
        //}
        #endregion

            #region Update Equipment
        //EquipmentsManager equipmentsManager = new EquipmentsManager();
        //var updates = new Dictionary<string, object>
        //{
        //    { "name", "Desfibrilhador Avan�ado" },
        //    { "quantityavailable", 5 },
        //    { "status", EquipmentStatus.Em_Manuten��o }
        //};

        //try
        //{
        //    equipmentsManager.UpdateEquipment(24, updates);
        //}
        //catch (Exception ex)
        //{
        //    Console.WriteLine($"{ex.Message}");
        //}
        #endregion

            #region Delete Equipment
        //EquipmentsManager equipmentsManager = new EquipmentsManager();
        //try
        //{
        //    equipmentsManager.DeleteEquipment(1);
        //}
        //catch (Exception ex)
        //{
        //    Console.WriteLine($"Erro ao eliminar equipamento: {ex.Message}");
        //}
        #endregion

            #region Create Team

        //    try
        //    {
        //        using (var context = new EmergenciesDBContext())
        //        {
        //            TeamsManager teamsManager = new TeamsManager(context);

        //            //// Criar equipa
        //            //INEM inemTeam = new INEM("Equipa INEM 2", TeamStatus.Dispon�vel, TeamType.INEM);

        //            //// Criando e adicionando m�dicos
        //            //Doctor doctor1 = new Doctor(
        //            //    "Matilde Fernandes",
        //            //    new DateOnly(1980, 1, 1),
        //            //    "8885",
        //            //    "911222333",
        //            //    "matilde.fernandes@example.com",
        //            //    "Rua A, 123",
        //            //    "Portuguesa",
        //            //    Roles.M�dico,
        //            //    TeamType.INEM,
        //            //    PersonStatus.Dispon�vel,
        //            //    "Dra. Matilde Fernandes",
        //            //    12388,
        //            //    "Pneumologia"
        //            //);
        //            //inemTeam.DoctorsList.Add(doctor1);

        //            //Doctor doctor2 = new Doctor(
        //            //    "Maria Teresa Campos",
        //            //    new DateOnly(1985, 5, 15),
        //            //    "66554",
        //            //    "922333444",
        //            //    "maria.Campos@example.com",
        //            //    "Rua B, 22",
        //            //    "Portuguesa",
        //            //    Roles.M�dico,
        //            //    TeamType.INEM,
        //            //    PersonStatus.Dispon�vel,
        //            //    "Dra. Maria Campos",
        //            //    67890,
        //            //    "Cardiologia"
        //            //);
        //            //inemTeam.DoctorsList.Add(doctor2);

        //            //// Criando e adicionando enfermeiros
        //            //Nurse nurse1 = new Nurse(
        //            //    "Joana Pereira Dias",
        //            //    new DateOnly(1990, 3, 20),
        //            //    "4111",
        //            //    "933444555",
        //            //    "Joana.Dias@example.com",
        //            //    "Rua C, 789",
        //            //    "Portuguesa",
        //            //    Roles.Enfermeiro,
        //            //    TeamType.INEM,
        //            //    PersonStatus.Dispon�vel,
        //            //    "Enf. Joana Dias",
        //            //    11111,
        //            //    "Emerg�ncia"
        //            //);
        //            //inemTeam.NursesList.Add(nurse1);

        //            //// Criando e adicionando t�cnicos de emerg�ncia
        //            //EmergencyTechnician tech1 = new EmergencyTechnician(
        //            //    "Carlos Costa",
        //            //    new DateOnly(1988, 7, 10),
        //            //    "2145",
        //            //    "944555666",
        //            //    "Carlos.costa@example.com",
        //            //    "Rua D, 1011",
        //            //    "Portuguesa",
        //            //    Roles.T�cnicoEmerg�ncia,
        //            //    TeamType.INEM,
        //            //    PersonStatus.Dispon�vel,
        //            //    "T�c. Carlos Costa",
        //            //    33333
        //            //);
        //            //inemTeam.EmergencyTechniciansList.Add(tech1);

        //            //// Adicionando a equipa
        //            //teamsManager.AddTeam(inemTeam);

        //            // Criando a equipe de Bombeiros
        //            FireFighters fireFightersTeam = new FireFighters("Equipa Bombeiros 2", TeamStatus.Dispon�vel, TeamType.Bombeiros);

        //            // Criando e adicionando bombeiros
        //            FireFighter firefighter1 = new FireFighter(
        //                "Carlos Oliveira",
        //                new DateOnly(1982, 3, 15),
        //                "234567890",
        //                "955666777",
        //                "carlos.oliveira@example.com",
        //                "Rua E, 567",
        //                "Portuguesa",
        //                Roles.Bombeiro,
        //                TeamType.Bombeiros,
        //                PersonStatus.Dispon�vel,
        //                8,
        //                "Combate a Inc�ndios",
        //                10201
        //            );
        //            fireFightersTeam.FireFightersList.Add(firefighter1);

        //            FireFighter firefighter2 = new FireFighter(
        //                "Sofia Rodrigues",
        //                new DateOnly(1988, 7, 20),
        //                "345678901",
        //                "966777888",
        //                "sofia.rodrigues@example.com",
        //                "Rua F, 678",
        //                "Portuguesa",
        //                Roles.Bombeiro,
        //                TeamType.Bombeiros,
        //                PersonStatus.Dispon�vel,
        //                5,
        //                "Resgate e Salvamento",
        //                304520
        //            );
        //            fireFightersTeam.FireFightersList.Add(firefighter2);

        //            FireFighter firefighter3 = new FireFighter(
        //                "Andr� Santos",
        //                new DateOnly(1985, 11, 10),
        //                "456789012",
        //                "977888999",
        //                "andre.santos@example.com",
        //                "Rua G, 789",
        //                "Portuguesa",
        //                Roles.Bombeiro,
        //                TeamType.Bombeiros,
        //                PersonStatus.Dispon�vel,
        //                7,
        //                "Emerg�ncias M�dicas",
        //                807150
        //            );
        //            fireFightersTeam.FireFightersList.Add(firefighter3);

        //            // Adicionando a equipa
        //            teamsManager.AddTeam(fireFightersTeam);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Ocorreu um erro: {ex.Message}");
        //    }
        //}
        #endregion

         #region Create Incident
        //using (var context = new EmergenciesDBContext())
        //{
        //    var teamsManager = new TeamsManager(context);
        //    var incidentsManager = new IncidentsManager(context, teamsManager);

        //    try
        //    {
        //        // Criando um incidente m�dico
        //        //MedicalIncident medicalIncident = new MedicalIncident(
        //        //    "Paciente com problemas psicol�gicos",
        //        //    DateTime.Now,
        //        //    "Rua dos testes, 50",
        //        //    IncidentSeverityLevel.Leve,
        //        //    IncidentType.Emerg�ncia_M�dica,
        //        //    IncidentStatus.Em_Progresso,
        //        //    new List<EquipmentType> { EquipmentType.M�dico },
        //        //    TeamType.INEM,
        //        //    "Joaquina Azevedo",
        //        //    20,
        //        //    "Tentativa de Suic�dio"
        //        //);

        //        //incidentsManager.CreateIncident(medicalIncident, TeamType.INEM);

        //        // Criando um incidente de inc�ndio
        //        FireIncident fireIncident = new FireIncident(
        //            "Inc�ndio em F�brica",
        //            DateTime.Now,
        //            "Avenida Dos Postes, 800",
        //            IncidentSeverityLevel.Cr�tico,
        //            IncidentType.Inc�ndio,
        //            IncidentStatus.Em_Progresso,
        //            new List<EquipmentType> { EquipmentType.Capacetes, EquipmentType.Combate_Inc�ndio },
        //            TeamType.Bombeiros,
        //            150.5,
        //            150
        //        );

        //        incidentsManager.CreateIncident(fireIncident, TeamType.Bombeiros);

        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"{ex.Message}");
        //    }
        //}
        #endregion


    }
    }
}