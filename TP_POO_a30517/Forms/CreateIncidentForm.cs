
//-----------------------------------------------------------------
//    <copyright file="CreateIncidentForm.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>24-11-2024</date>
//    <author>Cláudio Fernandes</author>
//-----------------------------------------------------------------

using TP_POO_a30517.Data;
using TP_POO_a30517.Enums;
using TP_POO_a30517.Incidents;
using TP_POO_a30517.Interfaces;

namespace TP_POO_a30517.Forms
{
    /// <summary>
    /// Form to create and manage incidents
    /// </summary>
    public partial class CreateIncidentForm : Form
    {
        #region Fields
        private readonly DataBaseConnection _databaseConnection;
        private readonly IIncidentManager _incidentManager;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the CreateIncidentForm class.
        /// </summary>
        /// <param name="incidentManager">Manager for handling incidents.</param>
        /// <param name="databaseConnection">Database connection.</param>
        public CreateIncidentForm(IIncidentManager incidentManager, DataBaseConnection databaseConnection)
        {
            InitializeComponent();
            _incidentManager = incidentManager;
            _databaseConnection = databaseConnection;
            InitializeForm();
        }
        #endregion

        #region Initialization Methods
        /// <summary>
        /// Initializes form components and sets up event handlers.
        /// </summary>
        private void InitializeForm()
        {
            ConfigureComboBoxes();
            ResetPanelsVisibility();
            comboBoxIncidentType.SelectedIndexChanged += comboBoxIncidentType_SelectedIndexChanged;
        }

        /// <summary>
        /// Configures the combo boxes with their respective data sources.
        /// </summary>
        private void ConfigureComboBoxes()
        {
            comboBoxSeverity.DataSource = Enum.GetValues(typeof(IncidentSeverityLevel));
            comboBoxIncidentType.DataSource = Enum.GetValues(typeof(IncidentType));
            comboBoxIncidentStatus.DataSource = Enum.GetValues(typeof(IncidentStatus));
            listBoxEquipment.DataSource = Enum.GetValues(typeof(EquipmentType));
            comboBoxTeam.DataSource = Enum.GetValues(typeof(TeamType));

            ClearComboBoxSelections();
        }

        /// <summary>
        /// Clears the selections in all combo boxes.
        /// </summary>
        private void ClearComboBoxSelections()
        {
            comboBoxSeverity.SelectedIndex = -1;
            comboBoxIncidentType.SelectedIndex = -1;
            comboBoxIncidentStatus.SelectedIndex = -1;
            listBoxEquipment.SelectedIndex = -1;
            comboBoxTeam.SelectedIndex = -1;
        }

        /// <summary>
        /// Resets the visibility of all incident type panels.
        /// </summary>
        private void ResetPanelsVisibility()
        {
            panelMedical.Visible = false;
            panelFire.Visible = false;
            panelCatastrophe.Visible = false;
        }

        #endregion

        #region Form Events
        /// <summary>
        /// Handles the event when the selected incident type changes.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event data.</param>
        private void comboBoxIncidentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetPanelsVisibility();

            if (comboBoxIncidentType.SelectedItem is IncidentType selectedType)
            {
                switch (selectedType)
                {
                    case IncidentType.Emergência_Médica:
                        panelMedical.Visible = true;
                        break;
                    case IncidentType.Incêndio:
                        panelFire.Visible = true;
                        break;
                    case IncidentType.Catástrofe:
                        panelCatastrophe.Visible = true;
                        break;
                }
            }
        }

        /// <summary>
        /// Handles the click event for the return button.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event data.</param>
        private void buttonReturnMain_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Handles the click event for the create incident button.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event data.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs(out Incident incident))
                return;

            try
            {
                _incidentManager.CreateIncident(incident);
                MessageBox.Show("Incidente criado com sucesso!");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao criar o incidente: {ex.Message}");
            }
        }

        #endregion

        #region Validation and Creation
        /// <summary>
        /// Validates all inputs and creates an Incident object if valid.
        /// </summary>
        /// <param name="incident">The created Incident object if validation succeeds.</param>
        /// <returns>True if inputs are valid, false otherwise.</returns>
        private bool ValidateInputs(out Incident incident)
        {
            incident = null;

            if (!ValidateCommonInputs(out var description, out var location, out var severity, out var type, out var status, out var equipmentUsed, out var teamType))
                return false;

            switch (type)
            {
                case IncidentType.Emergência_Médica:
                    return ValidateMedicalIncidentInputs(out incident, description, location, severity, status, equipmentUsed, teamType);
                case IncidentType.Incêndio:
                    return ValidateFireIncidentInputs(out incident, description, location, severity, status, equipmentUsed, teamType);
                case IncidentType.Catástrofe:
                    return ValidateCatastropheIncidentInputs(out incident, description, location, severity, status, equipmentUsed, teamType);
                default:
                    MessageBox.Show("Tipo de incidente inválido.");
                    return false;
            }
        }

        /// <summary>
        /// Validates common inputs for all incident types.
        /// </summary>
        /// <param name="description">The incident description.</param>
        /// <param name="location">The incident location.</param>
        /// <param name="severity">The incident severity level.</param>
        /// <param name="type">The incident type.</param>
        /// <param name="status">The incident status.</param>
        /// <param name="equipmentUsed">List of equipment used in the incident.</param>
        /// <param name="teamType">The team type assigned to the incident.</param>
        /// <returns>True if all common inputs are valid, false otherwise.</returns>
        private bool ValidateCommonInputs(out string description, out string location, out IncidentSeverityLevel severity, out IncidentType type, out IncidentStatus status, out List<EquipmentType> equipmentUsed, out TeamType teamType)
        {
            description = textBoxDescription.Text.Trim();
            location = textBoxLocation.Text.Trim();
            equipmentUsed = GetSelectedEquipment();

            if (string.IsNullOrWhiteSpace(description) || string.IsNullOrWhiteSpace(location) ||
                comboBoxSeverity.SelectedItem == null || comboBoxIncidentType.SelectedItem == null ||
                comboBoxIncidentStatus.SelectedItem == null || comboBoxTeam.SelectedItem == null ||
                !equipmentUsed.Any())
            {
                MessageBox.Show("Preencha todos os campos.");
                severity = default;
                type = default;
                status = default;
                teamType = default;
                return false;
            }

            severity = (IncidentSeverityLevel)comboBoxSeverity.SelectedItem;
            type = (IncidentType)comboBoxIncidentType.SelectedItem;
            status = (IncidentStatus)comboBoxIncidentStatus.SelectedItem;
            teamType = (TeamType)comboBoxTeam.SelectedItem;

            return true;
        }

        /// <summary>
        /// Validates inputs specific to medical incidents.
        /// </summary>
        /// <param name="incident">The created incident if validation succeeds.</param>
        /// <param name="description">The incident description.</param>
        /// <param name="location">The incident location.</param>
        /// <param name="severity">The incident severity level.</param>
        /// <param name="status">The incident status.</param>
        /// <param name="equipmentUsed">List of equipment used in the incident.</param>
        /// <param name="teamType">The team type assigned to the incident.</param>
        /// <returns>True if all medical incident inputs are valid, false otherwise.</returns>
        private bool ValidateMedicalIncidentInputs(out Incident incident, string description, string location, IncidentSeverityLevel severity, IncidentStatus status, List<EquipmentType> equipmentUsed, TeamType teamType)
        {
            incident = null;

            if (string.IsNullOrWhiteSpace(textBoxNamePatient.Text) ||
                string.IsNullOrWhiteSpace(textBoxAgePatient.Text) ||
                string.IsNullOrWhiteSpace(textBoxMedicalCondition.Text) ||
                !int.TryParse(textBoxAgePatient.Text, out var age))
            {
                MessageBox.Show("Preencha todos os campos de Emergência Médica.");
                return false;
            }

            incident = new MedicalIncident(description, DateTime.Now, location, severity, IncidentType.Emergência_Médica, status, equipmentUsed, teamType, textBoxNamePatient.Text.Trim(), age, textBoxMedicalCondition.Text.Trim());
            return true;
        }

        /// <summary>
        /// Validates inputs specific to fire incidents.
        /// </summary>
        /// <param name="incident">The created incident if validation succeeds.</param>
        /// <param name="description">The incident description.</param>
        /// <param name="location">The incident location.</param>
        /// <param name="severity">The incident severity level.</param>
        /// <param name="status">The incident status.</param>
        /// <param name="equipmentUsed">List of equipment used in the incident.</param>
        /// <param name="teamType">The team type assigned to the incident.</param>
        /// <returns>True if all fire incident inputs are valid, false otherwise.</returns>
        private bool ValidateFireIncidentInputs(out Incident incident, string description, string location, IncidentSeverityLevel severity, IncidentStatus status, List<EquipmentType> equipmentUsed, TeamType teamType)
        {
            incident = null;

            if (!double.TryParse(textBoxAffectedAreaFire.Text, out var affectedArea) ||
                !int.TryParse(textBoxPeopleAffectedFire.Text, out var peopleAffected))
            {
                MessageBox.Show("Preencha todos os campos de Incêndio.");
                return false;
            }

            incident = new FireIncident(description, DateTime.Now, location, severity, IncidentType.Incêndio, status, equipmentUsed, teamType, affectedArea, peopleAffected);
            return true;
        }

        /// <summary>
        /// Validates inputs specific to catastrophe incidents.
        /// </summary>
        /// <param name="incident">The created incident if validation succeeds.</param>
        /// <param name="description">The incident description.</param>
        /// <param name="location">The incident location.</param>
        /// <param name="severity">The incident severity level.</param>
        /// <param name="status">The incident status.</param>
        /// <param name="equipmentUsed">List of equipment used in the incident.</param>
        /// <param name="teamType">The team type assigned to the incident.</param>
        /// <returns>True if all catastrophe incident inputs are valid, false otherwise.</returns>
        private bool ValidateCatastropheIncidentInputs(out Incident incident, string description, string location, IncidentSeverityLevel severity, IncidentStatus status, List<EquipmentType> equipmentUsed, TeamType teamType)
        {
            incident = null;

            if (string.IsNullOrWhiteSpace(textBoxCatastropheType.Text) ||
                !double.TryParse(textBoxAffectedAreaCatastrophe.Text, out var affectedArea) ||
                !int.TryParse(textBoxPeopleAffectedCatastrophe.Text, out var peopleAffected) ||
                !double.TryParse(textBoxIntensityCatastrophe.Text, out var intensity))
            {
                MessageBox.Show("Preencha todos os campos de Catástrofe.");
                return false;
            }

            incident = new CatastropheIncident(description, DateTime.Now, location, severity, IncidentType.Catástrofe, status, equipmentUsed, teamType, textBoxCatastropheType.Text.Trim(), affectedArea, peopleAffected, intensity);
            return true;
        }

        #endregion

        #region Helper Methods
        /// <summary>
        /// Retrieves the list of selected equipment from the listbox.
        /// </summary>
        /// <returns>A list of selected EquipmentType items.</returns>
        private List<EquipmentType> GetSelectedEquipment()
        {
            return listBoxEquipment.SelectedItems.Cast<EquipmentType>().ToList();
        }

        /// <summary>
        /// Handles the KeyPress event for textboxes, allowing only numeric input.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">A KeyPressEventArgs that contains the event data.</param>
        private void Textbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        #endregion

    }
}