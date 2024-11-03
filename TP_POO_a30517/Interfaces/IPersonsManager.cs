
//-----------------------------------------------------------------
//    <copyright file="IPersonsManager.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date></date>
//    <author>Cláudio Fernandes</author>
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_POO_a30517.Enums;
using TP_POO_a30517.Models;

namespace TP_POO_a30517.Interfaces
{
    public interface IPersonsManager
    {
        void AddPerson(Person person);
        void UpdatePerson(int id, Dictionary<string, object> updates);
        public void AssociatePersonToTeam(int personId, int teamId);
        void DeletePerson(int id);
        void PersonsByStatus(PersonStatus status);
    }
}
