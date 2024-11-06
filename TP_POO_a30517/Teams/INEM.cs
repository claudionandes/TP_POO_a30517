
//-----------------------------------------------------------------
//    <copyright file="INEM.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>30-10-2024</date>
//    <author>Cláudio Fernandes</author>
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TP_POO_a30517.Enums;
using TP_POO_a30517.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace TP_POO_a30517.Teams
{
    /// <summary>
    /// Class INEM
    /// </summary>
    public class INEM : EmergencyTeamBase
    {
        #region Public Properties    
        public List<Doctor> DoctorsList { get; set; }
        public List<Nurse> NursesList { get; set; }
        public List<EmergencyTechnician> EmergencyTechniciansList { get; set; }
        #endregion

        #region Constructors
        public INEM(string name, TeamStatus status, TeamType teamType)
            : base(name, status, teamType)
        {
            DoctorsList = new List<Doctor>();
            NursesList = new List<Nurse>();
            EmergencyTechniciansList = new List<EmergencyTechnician>();
        }
        #endregion

        #region Public Methods
        public override string ReturnTeamDetails()
        {
            var doctorsDetails = string.Join(", ", DoctorsList);
            var nursesDetails = string.Join(", ", NursesList);
            var emergencyTechniciansDetails = string.Join(", ", EmergencyTechniciansList);
            return $"Nome: {Name}\n" +
                   $"Estado: {Status}\n\n" +
                   $"Equipa: {TeamType}\n\n" +
                   $"Médico:\n{doctorsDetails}\n" +
                   $"Enfermeiro:\n{nursesDetails}\n" +
                   $"Técnico de Emergência:\n{emergencyTechniciansDetails}";
        }
            #endregion

        }
}
