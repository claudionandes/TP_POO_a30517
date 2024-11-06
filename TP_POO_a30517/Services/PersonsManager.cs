
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
using TP_POO_a30517.Data;
using System.Numerics;
using TP_POO_a30517.Teams;
using TP_POO_a30517.Relations;

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

        #region Create Person
        public void AddPerson(Person person)
        {
            if (person == null)
            {
                throw new ArgumentNullException(nameof(person), "A pessoa não pode ser nula");
            }

            using (var context = new EmergenciesDBContext())
            {
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
        }
        #endregion

        #region Update Person
        public void UpdatePerson(int id, Dictionary<string, object> updates)
        {
            using (var context = new EmergenciesDBContext())
            {
                var personToUpdate = context.Set<Person>().Find(id);

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

                    context.SaveChanges();
                    Console.WriteLine("Dados atualizados com sucesso");
                }
                else
                {
                    throw new KeyNotFoundException($"Pessoa com ID {id} não encontrada.");
                }
            }
        }
        #endregion

        #region Delete Person
        public void DeletePerson(int personId)
        {
            using (var context = new EmergenciesDBContext())
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    var person = context.Set<Person>().Find(personId);
                    if (person == null)
                    {
                        throw new InvalidOperationException($"Pessoa com ID {personId} não encontrada");
                    }

                    // Remover associações com equipas
                    var teamMemberships = context.TeamMembers.Where(tm => tm.PersonId == personId).ToList();
                    foreach (var membership in teamMemberships)
                    {
                        // Verificar se a equipa está associada a incidentes
                        var teamIncidents = context.TeamIncidents.Where(ti => ti.TeamId == membership.TeamId).ToList();
                        foreach (var teamIncident in teamIncidents)
                        {
                            // Atualizar o incidente
                            var incident = teamIncident.Incident;
                            incident.Description += $" (Membro da equipa {person.Name} eliminado em {DateTime.Now})";
                            context.Incidents.Update(incident);
                        }
                        // Remover a associação da pessoa com a equipa
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

        #region Associate Person (Available) to Team
        public void AssociatePersonToTeam(int personId, int teamId)
        {
            using (var context = new EmergenciesDBContext())
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

                // Verificar se a pessoa está disponível
                if (person.Status != PersonStatus.Disponível)
                {
                    throw new InvalidOperationException($"A pessoa com ID {personId} não está disponível para ser associada à equipa.");
                }

                // Verificar se o TeamType da pessoa é compatível com o da equipa
                if (person.TeamType != team.TeamType)
                {
                    throw new InvalidOperationException($"A pessoa com ID {personId} não pode ser associada a uma equipa do tipo {team.TeamType}, porque o seu TeamType é {person.TeamType}");
                }

                // Verificar se a associação já existe
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
        }
        #endregion

        #region Dissociate Person From Team
        public void DissociatePersonFromTeam(int personId, int teamId)
        {
            using (var context = new EmergenciesDBContext())
            {
                // Procura a associação entre a pessoa e a equipa
                var teamMember = context.TeamMembers.FirstOrDefault(tm => tm.PersonId == personId && tm.TeamId == teamId);
                if (teamMember == null)
                {
                    throw new InvalidOperationException($"Associação entre a pessoa com ID {personId} e a equipa com ID {teamId} não encontrada");
                }

                // Remover a associação da tabela TeamMembers
                context.TeamMembers.Remove(teamMember);
                context.SaveChanges();

                Console.WriteLine($"Associação da pessoa com ID {personId} foi eliminada com sucesso da equipa com ID {teamId}");
            }
        }
        #endregion

        #region List Person by Status
        public void PersonsByStatus(PersonStatus status)
        {
            using (var context = new EmergenciesDBContext())
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
        }
        #endregion

        #region List All Persons
        public List<Person> GetAllPersons()
        {
            using (var context = new EmergenciesDBContext())
            {
                return context.Set<Person>().ToList();
            }
        }
        #endregion

        #endregion
    }
}
