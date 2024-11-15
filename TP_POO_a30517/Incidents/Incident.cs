
//-----------------------------------------------------------------
//    <copyright file="Incident.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>30-10-2024</date>
//    <author>Cláudio Fernandes</author>
//    <summary>
//     Defines the abstract Incident class, which serves as a base for specific incident types.
//    </summary>
//-----------------------------------------------------------------

using TP_POO_a30517.Enums;
using TP_POO_a30517.Interfaces;
using TP_POO_a30517.Relations;

namespace TP_POO_a30517.Incidents
{
    /// <summary>
    /// Represents an abstract base class for all types of incidents.
    /// </summary>
    public abstract class Incident : IEmergency
    {
        #region Private Properties        
        private int id;
        private string description;
        private DateTime created;
        private string location;
        private IncidentSeverityLevel severity;
        private IncidentType type;
        private IncidentStatus status;
        private List<EquipmentType> equipmentUsed;
        private TeamType teamType;
        #endregion

        #region Public Properties        
        public int Id
        {
            get => id; 
            set => id = value;
        }
        public string Description
        {
            get => description;
            set => description = value;
        }
        public DateTime Created
        {
            get => created;
            set => created = value;
        }
        public string Location
        {
            get => location; 
            set => location = value;
        }
        public IncidentSeverityLevel Severity
        {
            get => severity; 
            set => severity = value;
        }

        public IncidentType Type
        {
            get => type; 
            set => type = value;
        }
        public IncidentStatus Status
        {
            get => status; 
            set => status = value;
        }

        public List<EquipmentType> EquipmentUsed
        {
            get => equipmentUsed;
            set => equipmentUsed = value;
        }


        public TeamType TeamType
        {
            get => teamType;
            set => teamType = value;
        }

        public ICollection<TeamIncident> TeamIncidents { get; set; }

        public ICollection<EquipmentIncident> EquipmentIncidents { get; set; }

        public ICollection<VehicleIncident> VehicleIncidents { get; set; }
        #endregion

        #region Construtors        
        /// <summary>
        /// Initializes a new instance of the Incident class
        /// </summary>
        /// <param name="description"></param>
        /// <param name="created"></param>
        /// <param name="location"></param>
        /// <param name="severity"></param>
        /// <param name="type"></param>
        /// <param name="status"></param>
        /// <param name="equipmentUsed"></param>
        /// <param name="teamType"></param>
        public Incident (string description, DateTime created, string location, IncidentSeverityLevel severity, IncidentType type, IncidentStatus status, List<EquipmentType> equipmentUsed, TeamType teamType)
        {
            Description = description;
            Created = created;
            Location = location;
            Severity = severity;
            Type = type;
            Status = status;
            EquipmentUsed = equipmentUsed;
            TeamType = teamType;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Returns a string representation of the incident's details.
        /// </summary>
        /// <returns>Details of all "Incident" properties</returns>
        public virtual string ReturnsValuesIncident()
        {
            return $"ID: {Id}\n" +
                   $"Descrição: {Description}\n" +
                   $"Criação: {Created}\n" +
                   $"Localização: {Location}\n" +
                   $"Gravidade: {Severity}\n" +
                   $"Tipo: {Type}\n" +
                   $"Estado: {Status}\n" +
                   $"Equipamento utilizado: {EquipmentList(EquipmentUsed)}\n" +
                   $"Equipa de Emergência: {TeamType}";
        }

        /// <summary>
        /// Starts the emergency response for this incident
        /// </summary>
        public void StartEmergency()
        {
            Status = IncidentStatus.Em_Progresso;
            Console.WriteLine("Emergência ID {Id} iniciada");
        }

        /// <summary>
        /// Concludes the emergency response for this incident
        /// </summary>
        public void ConcludeEmergency()
        {
            Status = IncidentStatus.Terminado;
            Console.WriteLine("Emergência ID {Id} terminada");
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Formats the list of equipment types into a string representation.
        /// </summary>
        /// <param name="equipmentList">The list of equipment types used in the incident.</param>
        /// <returns>
        /// A string representation of the equipment list. Returns "Nenhum equipamento utilizado" if the list is null or empty.
        /// Otherwise, returns a comma-separated list of equipment types.
        /// </returns>
        private string EquipmentList(List<EquipmentType> equipmentList)
        {
            return equipmentList == null || equipmentList.Count == 0
                ? "Nenhum equipamento utilizado"
                : string.Join(", ", equipmentList.Select(e => e.ToString()));
        }
        #endregion

    }
}
