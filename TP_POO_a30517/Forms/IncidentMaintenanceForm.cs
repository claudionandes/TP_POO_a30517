//-----------------------------------------------------------------
//    <copyright file="IncidentMaintenanceForm.cs" company="IPCA">
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
    /// Form to maintenance incidents
    /// </summary>
    public partial class IncidentMaintenanceForm : Form
    {
        #region Fields
        private readonly DataBaseConnection _databaseConnection;
        private IIncidentManager _incidentManager;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="IncidentMaintenanceForm"/> class.
        /// </summary>
        /// <param name="incidentManager">The incident manager service.</param>
        /// <param name="databaseConnection">The database connection instance.</param>
        public IncidentMaintenanceForm(IIncidentManager incidentManager, DataBaseConnection databaseConnection)
        {
            InitializeComponent();
            _incidentManager = incidentManager ?? throw new ArgumentNullException(nameof(incidentManager));
            _databaseConnection = databaseConnection ?? throw new ArgumentNullException(nameof(databaseConnection));

            InitializeForm();
        }
        #endregion

        #region Initialization Methods
        /// <summary>
        /// Configures the form's initial values and settings.
        /// </summary>
        private void InitializeForm()
        {
            comboBoxManageIncident.DataSource = Enum.GetValues(typeof(IncidentType));
            comboBoxManageIncident.SelectedIndex = -1;

            comboBoxIncidentStatus.DataSource = Enum.GetValues(typeof(IncidentStatus));
            comboBoxIncidentStatus.SelectedIndex = -1;

            comboBoxManageIncident.SelectedIndexChanged += comboBoxManageIncident_SelectedIndexChanged;

            dataGridViewIncidents.Visible = false;
        }
        #endregion

        #region Event Handlers

        #region Button List Incidents
        /// <summary>
        /// Handles the Click event for the button to list all incidents.
        /// </summary>
        /// <param name="sender">The event source (button).</param>
        /// <param name="e">The event data.</param>
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                comboBoxManageIncident.SelectedIndex = -1;
                comboBoxIncidentStatus.SelectedIndex = -1;
                LoadIncidents(_incidentManager.GetAllIncidents());
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Erro ao listar incidentes: {ex.Message}");
            }
        }
        #endregion

        #region Button Create new Incident
        /// <summary>
        /// Handles the Click event for the button to create a new incident.
        /// </summary>
        /// <param name="sender">The event source (button).</param>
        /// <param name="e">The event data.</param>
        private void buttonCreateIncident_Click(object sender, EventArgs e)
        {
            var incidentForm = new CreateIncidentForm(_incidentManager, _databaseConnection);
            incidentForm.ShowDialog();
        }
        #endregion

        #region The incident type ComboBox 
        /// <summary>
        /// Handles the SelectedIndexChanged event for the incident type ComboBox.
        /// </summary>
        /// <param name="sender">The event source (ComboBox).</param>
        /// <param name="e">The event data.</param>
        private void comboBoxManageIncident_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                comboBoxIncidentStatus.SelectedIndex = -1;
                if (comboBoxManageIncident.SelectedItem == null)
                {
                    dataGridViewIncidents.Visible = false;
                    return;
                }

                IncidentType selectedType = (IncidentType)comboBoxManageIncident.SelectedItem;
                var incidents = GetIncidentsByType(selectedType);
                LoadIncidents(incidents);
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Erro ao carregar incidentes: {ex.Message}");
            }
        }
        #endregion

        #region Button to update incidents
        /// <summary>
        /// Handles the Click event for the button to update incidents.
        /// </summary>
        /// <param name="sender">The event source (button).</param>
        /// <param name="e">The event data.</param>
        private void buttonUpdateIncident_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewIncidents.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Selecione um incidente para atualizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!ValidateIncidentsLoaded()) return;

                foreach (DataGridViewRow row in dataGridViewIncidents.Rows)
                {
                    if (row.DataBoundItem is Incident incident)
                    {
                        _incidentManager.UpdateIncident(incident);
                    }
                }

                MessageBox.Show("Incidentes atualizados com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Erro ao atualizar os incidentes: {ex.Message}");
            }
        }
        #endregion

        #region Delete Incidente
        /// <summary>
        /// Handles the Click event for the button to delete an incident
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">The event arguments</param>
        private void buttonDeleteIncident_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewIncidents.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Selecione um incidente para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedRow = dataGridViewIncidents.SelectedRows[0];
                if (selectedRow.DataBoundItem is Incident incident)
                {
                    _incidentManager.DeleteIncident(incident.Id);
                    MessageBox.Show($"Incidente {incident.Id} eliminado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshIncidentList();
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Erro ao eliminar incidente: {ex.Message}");
            }
        }
        #endregion

        #region Filter By Status
        /// <summary>
        /// Handles the Click event for the button to filter incidents by status.
        /// </summary>
        /// <param name="sender">The event source (button).</param>
        /// <param name="e">The event data.</param>
        private void buttonFilterByStatus_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxIncidentStatus.SelectedItem == null)
                {
                    MessageBox.Show("Selecione um estado para filtrar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var status = (IncidentStatus)comboBoxIncidentStatus.SelectedItem;
                LoadIncidents(_incidentManager.FilterByStatus(status));
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Erro ao filtrar incidentes: {ex.Message}");
            }
        }
        #endregion

        #region Configure Columns of the DataGridView
        /// <summary>
        /// Configures the columns of the DataGridView for displaying incidents.
        /// </summary>
        private void ConfigureDataGridViewColumns()
        {
            foreach (DataGridViewColumn column in dataGridViewIncidents.Columns)
            {
                column.ReadOnly = column.Name switch
                {
                    "Id" or "Created" or "Severity" or "Type" or "Status" or "TeamIncidents" or "EquipmentIncidents" or "VehicleIncidents" => true,
                    _ => false
                };

                if (column.ReadOnly)
                {
                    column.DefaultCellStyle.BackColor = Color.LightGray;
                }
            }
        }
        #endregion

        #region Button Clean Filters
        /// <summary>
        /// Handles the Click event for the button to clean filters and reset the view.
        /// </summary>
        /// <param name="sender">The event source (button).</param>
        /// <param name="e">The event data.</param>
        private void buttonClean_Click(object sender, EventArgs e)
        {
            comboBoxManageIncident.SelectedIndex = -1;
            comboBoxIncidentStatus.SelectedIndex = -1;
            dataGridViewIncidents.Visible = false;
        }
        #endregion

        #region Button Close Form
        /// <summary>
        /// Closes the form and returns to the main screen.
        /// </summary>
        /// <param name="sender">The event source (button).</param>
        /// <param name="e">The event data.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #endregion

        #region Helper Methods
        /// <summary>
        /// Gets incidents filtered by a specific type.
        /// </summary>
        /// <param name="type">The incident type to filter by.</param>
        /// <returns>An enumerable collection of incidents.</returns>
        private IEnumerable<Incident> GetIncidentsByType(IncidentType type)
        {
            return type switch
            {
                IncidentType.Emergência_Médica => _incidentManager.GetAllMedicalIncident(),
                IncidentType.Incêndio => _incidentManager.GetAllFireIncident(),
                IncidentType.Catástrofe => _incidentManager.GetAllCatastropheIncident(),
                _ => Enumerable.Empty<Incident>(),
            };
        }

        /// <summary>
        /// Loads the provided incidents into the DataGridView.
        /// </summary>
        /// <param name="incidents">The collection of incidents to display.</param>
        private void LoadIncidents(IEnumerable<Incident> incidents)
        {
            if (incidents == null || !incidents.Any())
            {
                MessageBox.Show("Nenhum incidente encontrado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                dataGridViewIncidents.Visible = false;
                comboBoxManageIncident.SelectedIndex = -1;
                comboBoxIncidentStatus.SelectedIndex = -1;

                return;
            }

            dataGridViewIncidents.DataSource = incidents.ToList();
            dataGridViewIncidents.Visible = true;
            ConfigureDataGridViewColumns();
        }

        /// <summary>
        /// Validates if incidents are currently loaded into the DataGridView.
        /// </summary>
        /// <returns>True if incidents are loaded, otherwise false.</returns>
        private bool ValidateIncidentsLoaded()
        {
            if (dataGridViewIncidents.DataSource == null || dataGridViewIncidents.Rows.Count == 0)
            {
                MessageBox.Show("Nenhum incidente carregado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Refreshes the incident list in the DataGridView.
        /// </summary>
        private void RefreshIncidentList()
        {
            LoadIncidents(_incidentManager.GetAllIncidents());
        }

        /// <summary>
        /// Displays an error message to the user.
        /// </summary>
        /// <param name="message">The error message to display.</param>
        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion
    }
}
