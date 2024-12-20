
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
using TP_POO_a30517.Incidents;
using Utils;
using Microsoft.EntityFrameworkCore;

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

            bool citizenCardExists = context.Set<Person>().Any(p => p.CitizenCard == person.CitizenCard);
            if (citizenCardExists)
            {
                throw new InvalidOperationException($"O número de cartão de cidadão '{person.CitizenCard}' já está registado para outra pessoa");
            }

            if (!Validator.ValidEmail(person.Email))
            {
                throw new InvalidOperationException("E-mail inválido");
            }

            if (!Validator.ValidPhoneNumber(person.Phone))
            {
                throw new InvalidOperationException("Contacto inválido");
            }

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
        public void UpdatePerson(Person person)
        {
            try
            {
                var existingPerson = context.Persons.FirstOrDefault(i => i.Id == person.Id);

                if (existingPerson != null)
                {
                    existingPerson.Name = person.Name;
                    existingPerson.Birthdate = person.Birthdate;
                    existingPerson.CitizenCard = person.CitizenCard;
                    existingPerson.Phone = person.Phone;
                    existingPerson.Email = person.Email;
                    existingPerson.Address = person.Address;
                    existingPerson.Nationality = person.Nationality;
                    existingPerson.Role = person.Role;
                    existingPerson.TeamType = person.TeamType;
                    existingPerson.Status = person.Status;

                    context.SaveChanges();
                    Console.WriteLine($"Profissional {person.Id} atualizado com sucesso");
                }
                else
                {
                    Console.WriteLine($"Profissional {person.Id} não encontrado");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar o Profissional: {ex.Message}");
            }
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
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    var person = context.Set<Person>().Find(personId);
                    if (person == null)
                    {
                        throw new InvalidOperationException($"Pessoa com ID {personId} não encontrada");
                    }

                    var teamMemberships = context.TeamMembers.Where(tm => tm.PersonId == personId).ToList();
                    foreach (var membership in teamMemberships)
                    {
                        var teamIncidents = context.TeamIncidents.Where(ti => ti.TeamId == membership.TeamId).ToList();
                        foreach (var teamIncident in teamIncidents)
                        {
                            var incident = teamIncident.Incident;
                            incident.Description += $" (Membro da equipa {person.Name} eliminado em {DateTime.Now})";
                            context.Incidents.Update(incident);
                        }
                        context.TeamMembers.Remove(membership);
                    }

                    context.Set<Person>().Remove(person);

                    context.SaveChanges();
                    transaction.Commit();

                    Console.WriteLine($"Pessoa com ID {personId} foi eliminada com sucesso");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine($"Erro ao eliminar pessoa: {ex.Message}");
                    throw;
                }
            }
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
            var person = context.Set<Person>().Find(personId);
            var team = context.Set<EmergencyTeamBase>().Find(teamId);

            if (person == null)
            {
                throw new InvalidOperationException($"Pessoa com ID {personId} não encontrada");
            }

            if (team == null)
            {
                throw new InvalidOperationException($"Equipa com ID {teamId} não encontrada");
            }

            if (person.Status != PersonStatus.Disponível)
            {
                throw new InvalidOperationException($"A pessoa com ID {personId} não está disponível para ser associada à equipa.");
            }

            if (person.TeamType != team.TeamType)
            {
                throw new InvalidOperationException($"A pessoa com ID {personId} não pode ser associada a uma equipa do tipo {team.TeamType}, porque o seu TeamType é {person.TeamType}");
            }

            bool associationExists = context.TeamMembers.Any(tm => tm.PersonId == personId && tm.TeamId == teamId);
            if (associationExists)
            {
                throw new InvalidOperationException($"A pessoa já está associada a esta equipa");
            }

            var teamMember = new TeamMember
            {
                PersonId = personId,
                TeamId = teamId
            };

            context.TeamMembers.Add(teamMember);
            context.SaveChanges();

            Console.WriteLine($"Pessoa com ID {personId} associada com sucesso à equipa com ID {teamId}");
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
            var teamMember = context.TeamMembers.FirstOrDefault(tm => tm.PersonId == personId && tm.TeamId == teamId);
            if (teamMember == null)
            {
                throw new InvalidOperationException($"Associação entre a pessoa com ID {personId} e a equipa com ID {teamId} não encontrada");
            }

            context.TeamMembers.Remove(teamMember);
            context.SaveChanges();

            Console.WriteLine($"Associação da pessoa com ID {personId} foi eliminada com sucesso da equipa com ID {teamId}");
        }
        #endregion

        #region List Person by Status
        /// <summary>
        /// Lists persons filtered by their status.
        /// </summary>
        /// <param name="status">The status to filter persons by.</param>
        public List<Person> PersonsByStatus(PersonStatus status)
        {
            return context.Persons.Where(p => p.Status == status).ToList();
        }
        #endregion

        #region List All Persons
        /// <summary>
        /// Retrieves all persons from the system.
        /// </summary>
        /// <returns>A list of all persons.</returns>
        public List<Person> GetAllPersons()
        {
            return context.Persons
                .Include(p => p.TeamMemberships)
                .ToList();
        }
        #endregion

        #region List All Doctors
        /// <summary>
        /// Retrieves all doctors from the system.
        /// </summary>
        /// <returns>A list of all doctors.</returns>
        public List<Doctor> GetAllDoctor()
        {
            return context.Doctors.ToList();
        }
        #endregion

        #region List All Emergency Technicians
        /// <summary>
        /// Retrieves all emergency technicians from the system.
        /// </summary>
        /// <returns>A list of all emergency technicians.</returns>
        public List<EmergencyTechnician> GetAllEmergencyTechnician()
        {
            return context.Emergency_Technicians.ToList();
        }
        #endregion

        #region List All FireFighters
        /// <summary>
        /// Retrieves all firefighters from the system.
        /// </summary>
        /// <returns>A list of all firefighters.</returns>
        public List<FireFighter> GetAllFireFighter()
        {
            return context.FireFighters.ToList();
        }
        #endregion

        #region List All Nurses
        /// <summary>
        /// Retrieves all nurses from the system.
        /// </summary>
        /// <returns>A list of all nurses.</returns>
        public List<Nurse> GetAllNurse()
        {
            return context.Nurses.ToList();
        }
        #endregion

        #endregion
    }
}
