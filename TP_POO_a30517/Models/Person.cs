
//-----------------------------------------------------------------
//    <copyright file="Person.cs" company="IPCA">
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
using TP_POO_a30517.Enums;
using Utils;

namespace TP_POO_a30517.Models
{
    /// <summary>
    /// Abstract class Person
    /// </summary>
    public abstract class Person: IComparable
    {
        #region Private Properties        
        /// <summary>
        /// Private - Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        private static int nextId = 1;
        private int id { get; set; }
        private string name { get; set; }
        private DateOnly birthdate { get; set; }
        private readonly CalculateAge ageCalculator = new CalculateAge();
        private string citizenCard { get; set; }
        private string phone { get; set; }
        private string email { get; set; }
        private string address { get; set; }
        private string nationality { get; set; }
        private Roles role;
        #endregion

        #region Public Properties        
        /// <summary>
        /// Public - Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
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
        /// <summary>
        /// Gets or sets the role.
        /// </summary>
        /// <value>
        /// The role.
        /// </value>
        public Roles Role
        {
            get => role;
            set => role = value;
        }

        #endregion

        #region Constructors                        
        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="birthdate">The birthdate.</param>
        /// <param name="Age">The age.</param>
        /// <param name="citizenCard">The citizen card.</param>
        /// <param name="phone">The phone.</param>
        /// <param name="email">The email.</param>
        /// <param name="address">The address.</param>
        /// <param name="nationality">The nationality.</param>
        /// <param name="role">The role.</param>
        public Person(string name, DateOnly birthdate, string citizenCard, string phone, string email, string address, string nationality, Roles role)
        {
            Id = GenerateId();
            this.Name = name;
            this.Birthdate = birthdate;
            
            this.CitizenCard = citizenCard;
            this.Phone = phone; 
            this.Email = email;
            this.Address = address;
            this.Nationality = nationality;
            this.Role = role;
        }
        #endregion

        #region Public Methods        
        /// <summary>
        /// Compares to ID or Name.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">Object must be of type Person</exception>
        public int CompareTo(object? other)
        {
            if (!(other is Person))
            {
                throw new ArgumentException("Object must be of type Person");
            }
            return this.Id.CompareTo(((Person)other).Id);
        }

        public int CompareToName(object? other)
        {
            if (!(other is Person))
            {
                throw new ArgumentException("Object must be of type Person");
            }
            return string.Compare(Name, (other as Person)?.Name, StringComparison.Ordinal);
        }
        /// <summary>
        /// Returnses the values.
        /// </summary>
        /// <returns></returns>
        public virtual string ReturnsValues()
        {
            return $"ID: {Id}\n" +
                   $"Name: {Name}\n" +
                   $"Birthdate: {Birthdate}\n" +
                   $"Age: {Age}\n" +
                   $"Citizen Card: {CitizenCard}\n" +
                   $"Phone: {Phone}\n" +
                   $"Email: {Email}\n" +
                   $"Address: {Address}\n" +
                   $"Nationality: {Nationality}\n" +
                   $"Role: {Role}";
        }
        #endregion

        #region Private Methods             
        /// <summary>
        /// Generates the identifier.
        /// </summary>
        /// <returns></returns>
        private static int GenerateId()
        {
            return nextId++;
        }
        #endregion

        
    }
}
