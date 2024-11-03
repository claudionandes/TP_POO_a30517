
//-----------------------------------------------------------------
//    <copyright file="Incident.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>30-10-2024</date>
//    <author>Cláudio Fernandes</author>
//-----------------------------------------------------------------

using TP_POO_a30517.Enums;
using TP_POO_a30517.Interfaces;
using TP_POO_a30517.Teams;

namespace TP_POO_a30517.Incidents
{
    /// <summary>
    /// Public class Incident
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
        /// <summary>
        /// Gets or sets the properties for the incident.
        /// </summary>
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
        #endregion

        #region Construtors        
        /// <summary>
        /// Initializes a new instance of the <see cref="Incident"/> class.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <param name="created">The created.</param>
        /// <param name="location">The location.</param>
        /// <param name="severity">The severity.</param>
        /// <param name="type">The type.</param>
        /// <param name="status">The status.</param>
        /// <param name="equipmentUsed">The equipment used.</param>
        /// <param name="teamType">The team Type.</param>
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
        /// Returnses the values.
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

        public void StartEmergency()
        {
            Status = IncidentStatus.Em_Progresso;
            Console.WriteLine("Emergência ID {Id} iniciada");
        }

        public void ConcludeEmergency()
        {
            Status = IncidentStatus.Terminado;
            Console.WriteLine("Emergência ID {Id} terminada");
        }
        #endregion

        #region Private Methods
        private string EquipmentList(List<EquipmentType> equipmentList)
        {
            return equipmentList == null || equipmentList.Count == 0
                ? "Nenhum equipamento utilizado"
                : string.Join(", ", equipmentList.Select(e => e.ToString()));
        }
        #endregion

    }
}
