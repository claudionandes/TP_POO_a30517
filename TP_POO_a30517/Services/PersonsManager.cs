
//-----------------------------------------------------------------
//    <copyright file="PersonsManager.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>30-10-2024</date>
//    <author>Cláudio Fernandes</author>
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_POO_a30517.Models;
using TP_POO_a30517.Enums;
using TP_POO_a30517.Interfaces;
using DataValidationLibrary;

namespace TP_POO_a30517.Services
{
    public class PersonsManager : IPersonsManager
    {
        #region Private Properties
        private List<Person> persons;
        #endregion

        #region Public Properties
        public PersonsManager()
        {
            persons = new List<Person>();
        }
        #endregion

        #region Public Methods

        #region Add Person
        public void AddPerson(Person person)
        {
            if (person != null)
            {
                if (!Validator.ValidEmail(person.Email))
                {
                    throw new FormatException("E-mail inválido");
                }

                persons.Add(person);
                Console.WriteLine($"{person.Name} Inserida com sucesso na equipa: {person.TeamType}");
            }
            else
            {
                throw new ArgumentNullException(nameof(person), "A pessoa não pode ser nula");
            }
        }
        #endregion

        #region Update Person Status
        public void UpdatePersonStatus(int personId, PersonStatus newStatus)
        {
            var person = persons.FirstOrDefault(p => p.Id == personId);
            if (person != null)
            {
                person.Status = newStatus;
                Console.WriteLine($"{person.Name} Estado atualizado para: {newStatus}");
            }
            else
            {
                throw new KeyNotFoundException($"Pessoa com ID {personId} não encontrada");
            }
        }
        #endregion

        #region Update Person
        public void UpdatePerson(int id, Dictionary<string, object> updates)
        {
            var personToUpdate = persons.FirstOrDefault(p => p.Id == id);

            if (personToUpdate != null)
            {
                foreach (var update in updates)
                {
                    var propertyInfo = typeof(Person).GetProperty(update.Key);
                    if (propertyInfo != null && propertyInfo.CanWrite)
                    {
                        propertyInfo.SetValue(personToUpdate, update.Value);
                    }
                }
                Console.WriteLine("Dados atualizados com sucesso");
            }
            {
                throw new KeyNotFoundException($"Pessoa com ID {id} não encontrada.");
            }
        }
        #endregion

        #region Delete Person
        public void DeletePerson(int id)
        {
            var personDelete = persons.FirstOrDefault(p => p.Id == id);
            if (personDelete != null)
            {
                persons.Remove(personDelete);
                Console.WriteLine("Pessoa eliminada com sucesso");
            }
            else
            {
                throw new KeyNotFoundException($"Pessoa com ID {id} não encontrada");
            }
        }
        #endregion

        #region List Person by Status
        public void PersonsByStatus(PersonStatus status)
        {
            var filteredPersons = persons.Where(p => p.Status == status).ToList();

            if (filteredPersons.Any())
            {
                Console.WriteLine($"Pessoas com o estado '{status}':");
                foreach (var person in filteredPersons)
                {
                    Console.WriteLine(person.ReturnsValuesPerson());
                }
            }
            else
            {
                Console.WriteLine($"Nenhuma pessoa encontrada com o estado '{status}'");
            }
        }
        #endregion

        #endregion
    }
}
