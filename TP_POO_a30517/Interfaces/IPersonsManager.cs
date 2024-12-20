
//-----------------------------------------------------------------
//    <copyright file="IPersonsManager.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date></date>
//    <author>Cláudio Fernandes</author>
//    <summary>
//     Defines the IPersonsManager interface for managing personnel in the emergency response system.
//    </summary>
//-----------------------------------------------------------------

using TP_POO_a30517.Enums;
using TP_POO_a30517.Models;

namespace TP_POO_a30517.Interfaces
{
    /// <summary>
    /// Defines methods for managing personnel in the emergency response system.
    /// </summary>
    public interface IPersonsManager
    {
        #region Methods
        void AddPerson(Person person);
        public void UpdatePerson(Person person);
        public void AssociatePersonToTeam(int personId, int teamId);
        public void DissociatePersonFromTeam(int personId, int teamId);
        void DeletePerson(int id);
        public List<Person> PersonsByStatus(PersonStatus status);
        public List<Person> GetAllPersons();
        public List<Doctor> GetAllDoctor();
        public List<EmergencyTechnician> GetAllEmergencyTechnician();
        public List<FireFighter> GetAllFireFighter();
        public List<Nurse> GetAllNurse();
        #endregion
    }
}
