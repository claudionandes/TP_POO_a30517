
//-----------------------------------------------------------------
//    <copyright file="Person.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>30-10-2024</date>
//    <author>Cláudio Fernandes</author>
//    <summary>
//     Abstract class representing a person in the emergency response system.
//    </summary>
//-----------------------------------------------------------------

using TP_POO_a30517.Enums;
using TP_POO_a30517.Relations;
using Utils;

namespace TP_POO_a30517.Models
{
    /// <summary>
    /// Abstract class representing a person.
    /// </summary>
    public abstract class Person: IComparable
    {
        #region Private Properties        
        private int id { get; set; }
        private string name { get; set; }
        private DateOnly birthdate { get; set; }
        private readonly CalculateAge ageCalculator = new CalculateAge();
        private string citizenCard { get; set; }
        private string phone { get; set; }
        private string email { get; set; }
        private string address { get; set; }
        private string nationality { get; set; }
        private Roles role { get; set; }
        private TeamType teamType { get; set; }
        private PersonStatus status { get; set; }
        #endregion

        #region Public Properties        
        public int Id
        {
            get => id;
            set => id = value;
        }
        public string Name
        {
            get => name;
            set => name = value;
        }
        public DateOnly Birthdate
        {
            get => birthdate;
            set => birthdate = value;
        }

        public int Age => ageCalculator.Age(Birthdate);
        public string CitizenCard
        {
            get => citizenCard;
            set => citizenCard = value;
        }
        public string Phone
        {
            get => phone;
            set => phone = value;
        }
        public string Email
        {
            get => email;
            set => email = value;
        }
        public string Address
        {
            get => address;
            set => address = value;
        }
        public string Nationality
        {
            get => nationality;
            set => nationality = value;
        }
        public Roles Role
        {
            get => role;
            set => role = value;
        }

        public TeamType TeamType
        {
            get => teamType;
            set => teamType = value;
        }

        public PersonStatus Status
        {
            get => status;
            set => status = value;
        }

        public ICollection<TeamMember> TeamMemberships { get; set; }
        #endregion

        #region Constructors                                
        /// <summary>
        /// Initializes a new instance of the Person class
        /// </summary>
        /// <param name="name"></param>
        /// <param name="birthdate"></param>
        /// <param name="citizenCard"></param>
        /// <param name="phone"></param>
        /// <param name="email"></param>
        /// <param name="address"></param>
        /// <param name="nationality"></param>
        /// <param name="role"></param>
        /// <param name="teamType"></param>
        /// <param name="status"></param>
        public Person(string name, DateOnly birthdate, string citizenCard, string phone, string email, string address, string nationality, Roles role, TeamType teamType, PersonStatus status)
        {
            Name = name;
            Birthdate = birthdate;
            CitizenCard = citizenCard;
            Phone = phone; 
            Email = email;
            Address = address;
            Nationality = nationality;
            Role = role;
            TeamType = teamType;
            Status = status;
        }
        #endregion

        #region Public Methods        
        /// <summary>
        /// Compares this instance with another object.
        /// </summary>
        /// <param name="other">The other object to compare with</param>
        /// <returns>An integer that indicates the relative order of the objects being compared</returns>
        /// <exception cref="System.ArgumentException">Thrown when the object is not of type Person</exception>
        public int CompareTo(object? other)
        {
            if (!(other is Person))
            {
                throw new ArgumentException("Object must be of type Person");
            }
            return this.Id.CompareTo(((Person)other).Id);
        }

        /// <summary>
        /// Compares this instance with another object by name
        /// </summary>
        /// <param name="other">The other object to compare with</param>
        /// <returns>An integer that indicates the relative order of the objects being compared</returns>
        /// <exception cref="ArgumentException">Thrown when the object is not of type Person</exception>
        public int CompareToName(object? other)
        {
            if (!(other is Person))
            {
                throw new ArgumentException("Object must be of type Person");
            }
            return string.Compare(Name, (other as Person)?.Name, StringComparison.Ordinal);
        }

        /// <summary>
        /// Returns detailed information about this person
        /// </summary>
        /// <returns>/// <summary>
        /// Returns detailed information about this person
        /// </summary>
        /// <returns></returns>
        public virtual string ReturnsValuesPerson()
        {
            return $"ID: {Id}\n" +
                   $"Nome: {Name}\n" +
                   $"Data de Nascimento: {Birthdate}\n" +
                   $"Idade: {Age}\n" +
                   $"Cartão de Cidadão: {CitizenCard}\n" +
                   $"Telemóvel: {Phone}\n" +
                   $"Email: {Email}\n" +
                   $"Morada: {Address}\n" +
                   $"Nacionalidade: {Nationality}\n" +
                   $"Cargo: {Role}\n" +
                   $"Equipa: {TeamType}\n" +
                   $"Estado: {Status}";
        }
        #endregion
        
    }
}
