
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
using TP_POO_a30517.Incidents;
using TP_POO_a30517.Equipments;
using Utils;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Data;
using System.Net;
using System.Xml.Linq;


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
            Nurse nurse = new Nurse("Joana Silva Ferreira", new DateOnly(1978, 10, 10), "1234555", "987654321", "teste@teste.pt", "Rua de Viena 40", "Portuguesa", Roles.Enfermeiro, TeamType.INEM, PersonStatus.Dispon�vel, "Joana Silva", "12345", "Pneumologia");
            Doctor doctor = new Doctor("Carlos Teixeira Pereira", new DateOnly(1990, 05, 29), "5820288", "912345678", "Email@teste.pt", "Rua Porto, 100", "Portuguesa", Roles.M�dico, TeamType.INEM_e_Bombeiros, PersonStatus.Dispon�vel, "Carlos Pereira", "11111", "Cardiologia");
            FireFighter firefighter = new FireFighter("Pedro Sousa", new DateOnly(1980, 04, 30), "456789123", "923456789", "POO@teste.pt", "Rua Campos, 67", "Portuguesa", Roles.Bombeiro, TeamType.Bombeiros, PersonStatus.Dispon�vel, 5, "Resgate em Inc�ndios");
            EmergencyTechnician technician = new EmergencyTechnician("Andr� Fernandes", new DateOnly(1985, 10, 15), "789456123", "924567890", "tec@teste.pt", "Rua Lisboa, 23", "Portuguesa", Roles.T�cnicoEmerg�ncia, TeamType.INEM,PersonStatus.Dispon�vel, "Andr� F.", "22222");
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
                INEM inemTeam = new INEM("INEM Equipa A", doctor, nurse, technician, VehiclesType.Ambul�ncia_de_Emerg�ncia_M�dica_AEM, EquipmentType.Desfibrilhador, TeamStatus.Alocado);
            #endregion

            #region Display INEM Team Details
            Console.WriteLine("Detalhes da equipa INEM A:");
            Console.WriteLine(inemTeam.ReturnTeamDetails());
            #endregion

            #region Add professionals to a list
            List<Person> members = new List<Person> { firefighter, doctor, nurse};
            #endregion

            #region Rescue Team Creation
            INEM_FireFighter inem_Fire = new INEM_FireFighter("INEM e Bombeiros Equipa A", members, TeamStatus.Dispon�vel,VehiclesType.Ambul�ncia_de_Socorro_ABSC, EquipmentType.Cadeira_Transporte);
            #endregion

            #region Display Rescue Team Details
            Console.WriteLine("\nDetalhes da equipa INEM e Bombeiros:");
            Console.WriteLine(inem_Fire.ReturnTeamDetails());
            #endregion

        }
    }
}