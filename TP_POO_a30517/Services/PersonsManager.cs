
//-----------------------------------------------------------------
//    <copyright file="PersonsManager.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>30-10-2024</date>
//    <author>Cláudio Fernandes</author>
//-----------------------------------------------------------------

using TP_POO_a30517.Models;
using TP_POO_a30517.Enums;
using TP_POO_a30517.Interfaces;
using DataValidationLibrary;
using TP_POO_a30517.Data;
using TP_POO_a30517.Teams;
using TP_POO_a30517.Relations;

namespace TP_POO_a30517.Services
{
    /// <summary>
    /// Manages operations related to persons in the emergency response system.
    /// </summary>
    public class PersonsManager : IPersonsManager
    {
        #region Private Properties
        private EmergenciesDBContext context;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the PersonsManager class
        /// </summary>
        /// <param name="context"></param>
        public PersonsManager(EmergenciesDBContext context)
        {
            this.context = context;
        }
        #endregion

        #region Public Methods

        #region Create Person
        /// <summary>
        /// Adds a new person to the system.
        /// </summary>
        /// <param name="person">The person to be added.</param>
        public void AddPerson(Person person)
        {
            if (person == null)
            {
                throw new ArgumentNullException(nameof(person), "A pessoa não pode ser nula");
            }
                // Verificação geral para CitizenCard
                bool citizenCardExists = context.Set<Person>().Any(p => p.CitizenCard == person.CitizenCard);
                if (citizenCardExists)
                {
                    throw new InvalidOperationException($"O número de cartão de cidadão '{person.CitizenCard}' já está registado para outra pessoa");
                }

                // Verificações específicas para cada tipo de pessoa
                if (person is Doctor doctor)
                {
                    bool cardNumberExists = context.Set<Doctor>().Any(d => d.CardNumber == doctor.CardNumber);
                    if (cardNumberExists)
                    {
                        throw new InvalidOperationException($"O número de cédula '{doctor.CardNumber}' já está registado para outro médico");
                    }
                    context.Set<Doctor>().Add(doctor);
                }
                else if (person is Nurse nurse)
                {
                    bool cardNumberExists = context.Set<Nurse>().Any(n => n.CardNumber == nurse.CardNumber);
                    if (cardNumberExists)
                    {
                        throw new InvalidOperationException($"O número de cédula '{nurse.CardNumber}' já está registado para outro enfermeiro");
                    }
                    context.Set<Nurse>().Add(nurse);
                }
                else if (person is EmergencyTechnician technician)
                {
                    bool technicalNumberExists = context.Set<EmergencyTechnician>().Any(t => t.TechnicalNumber == technician.TechnicalNumber);
                    if (technicalNumberExists)
                    {
                        throw new InvalidOperationException($"O número técnico '{technician.TechnicalNumber}' já está registado para outro técnico de emergência");
                    }
                    context.Set<EmergencyTechnician>().Add(technician);
                }
                else if (person is FireFighter firefighter)
                {
                    bool mechanographicNumberExists = context.Set<FireFighter>().Any(f => f.MechanographicNumber == firefighter.MechanographicNumber);
                    if (mechanographicNumberExists)
                    {
                        throw new InvalidOperationException($"O número mecanográfico '{firefighter.MechanographicNumber}' já está registado para outro bombeiro");
                    }
                    context.Set<FireFighter>().Add(firefighter);
                }
                else
                {
                    context.Set<Person>().Add(person);
                }

                if (!Validator.ValidEmail(person.Email))
                {
                    throw new FormatException("E-mail inválido");
                }

                if (!Validator.ValidPhoneNumber(person.Phone))
                {
                    throw new FormatException("Contacto inválido");
                }

                context.SaveChanges();
                Console.WriteLine($"{person.Name} inserido com sucesso");
        }
        #endregion

        #region Update Person
        /// <summary>
        /// Updates an existing person's details.
        /// </summary>
        /// <param name="id">The ID of the person to update.</param>
        /// <param name="updates">A dictionary of properties to update.</param>
        public void UpdatePerson(int id, Dictionary<string, object> updates)
        {
            
        }
        #endregion

        #region Delete Person
        /// <summary>
        /// Updates an existing person's details.
        /// </summary>
        /// <param name="id">The ID of the person to update.</param>
        /// <param name="updates">A dictionary of properties to update.</param>
        public void DeletePerson(int personId)
        {
           
        }
        #endregion

        #region Associate Person to Team
        /// <summary>
        /// Associates a person with a specific team.
        /// </summary>
        /// <param name="personId">The ID of the person.</param>
        /// <param name="teamId">The ID of the team.</param>
        public void AssociatePersonToTeam(int personId, int teamId)
        {
            
        }
        #endregion

        #region Dissociate Person From Team
        /// <summary>
        /// Dissociates a person from a specific team.
        /// </summary>
        /// <param name="personId">The ID of the person.</param>
        /// <param name="teamId">The ID of the team.</param>
        public void DissociatePersonFromTeam(int personId, int teamId)
        {
            
        }
        #endregion

        #region List Person by Status
        /// <summary>
        /// Lists persons filtered by their status.
        /// </summary>
        /// <param name="status">The status to filter persons by.</param>
        public void PersonsByStatus(PersonStatus status)
        {
            var filteredPersons = context.Set<Person>()
                .Where(p => p.Status == status)
                .ToList();

            if (filteredPersons.Count == 0)
            {
                Console.WriteLine($"Nenhuma pessoa encontrada com o estado '{status}'");
            }
            else
            {
                Console.WriteLine($"Pessoas com o status '{status}':");
                filteredPersons.ForEach(p => Console.WriteLine(p.ReturnsValuesPerson()));
            }
        }
        #endregion

        #region List All Persons
        /// <summary>
        /// Retrieves all persons from the system.
        /// </summary>
        public List<Person> GetAllPersons()
        {
            return context.Set<Person>().ToList();
        }
        #endregion

        #endregion
    }
}
