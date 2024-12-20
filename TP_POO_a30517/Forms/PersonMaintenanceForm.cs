
//-----------------------------------------------------------------
//    <copyright file="PersonMaintenanceForm.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>15-12-2024</date>
//    <author>Cláudio Fernandes</author>
//-----------------------------------------------------------------

using TP_POO_a30517.Data;
using TP_POO_a30517.Enums;
using TP_POO_a30517.Interfaces;
using TP_POO_a30517.Models;
using TP_POO_a30517.Teams;

namespace TP_POO_a30517.Forms
{
    /// <summary>
    /// Represents the main form for person maintenance operations.
    /// This form handles the creation, modification, and management of person records.
    /// </summary>
    public partial class PersonMaintenanceForm : Form
    {
        #region Fields
        /// <summary>
        /// Manages the database connection for the form.
        /// </summary>
        private readonly DataBaseConnection _databaseConnection;

        /// <summary>
        /// Manages operations related to persons.
        /// </summary>
        private IPersonsManager _personsManager;

        /// <summary>
        /// Manages operations related to teams.
        /// </summary>
        private ITeamsManager _teamsManager;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the PersonMaintenanceForm.
        /// </summary>
        /// <param name="personsManager">The manager for person-related operations.</param>
        /// <param name="teamsManager">The manager for team-related operations.</param>
        /// <param name="databaseConnection">The database connection to be used.</param>
        /// <exception cref="ArgumentNullException">Thrown when any of the parameters is null.</exception>
        public PersonMaintenanceForm(IPersonsManager personsManager, ITeamsManager teamsManager, DataBaseConnection databaseConnection)
        {
            InitializeComponent();
            _personsManager = personsManager ?? throw new ArgumentNullException(nameof(personsManager));
            _teamsManager = teamsManager ?? throw new ArgumentNullException(nameof(teamsManager));
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
            comboBoxManagePerson.DataSource = Enum.GetValues(typeof(Roles));
            comboBoxManagePerson.SelectedIndex = -1;

            comboBoxPersonStatus.DataSource = Enum.GetValues(typeof(PersonStatus));
            comboBoxPersonStatus.SelectedIndex = -1;

            comboBoxPersons.DataSource = _personsManager.GetAllPersons();
            comboBoxPersons.DisplayMember = "Name";
            comboBoxPersons.SelectedIndex = -1;

            comboBoxTeams.DataSource = _teamsManager.GetAllTeams();
            comboBoxTeams.DisplayMember = "Name";
            comboBoxTeams.SelectedIndex = -1;

            comboBoxDissociatePerson.DataSource = _personsManager.GetAllPersons();
            comboBoxDissociatePerson.DisplayMember = "Name";
            comboBoxDissociatePerson.SelectedIndex = -1;

            comboBoxDissociateTeam.DataSource = _teamsManager.GetAllTeams();
            comboBoxDissociateTeam.DisplayMember = "Name";
            comboBoxDissociateTeam.SelectedIndex = -1;

            comboBoxManagePerson.SelectedIndexChanged += comboBoxManagePerson_SelectedIndexChanged;

            dataGridViewPersons.Visible = false;
        }
        #endregion

        #region Event Handlers

        #region Button List Persons
        /// <summary>
        /// Handles the Click event for the button to list all Persons.
        /// </summary>
        /// <param name="sender">The event source (button).</param>
        /// <param name="e">The event data.</param>
        private void ButtonListPersons_Click(object sender, EventArgs e)
        {
            try
            {
                comboBoxManagePerson.SelectedIndex = -1;
                comboBoxPersonStatus.SelectedIndex = -1;
                LoadPersons(_personsManager.GetAllPersons());
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Erro ao listar Profissionais: {ex.Message}");
            }
        }
        #endregion

        #region Button Create new Person
        /// <summary>
        /// Handles the Click event for the button to create a new Person.
        /// </summary>
        /// <param name="sender">The event source (button).</param>
        /// <param name="e">The event data.</param>
        private void buttonCreatePerson_Click(object sender, EventArgs e)
        {
            var personForm = new CreatePersonForm(_personsManager, _databaseConnection);
            personForm.ShowDialog();
        }
        #endregion

        #region The role type ComboBox 
        /// <summary>
        /// Handles the SelectedIndexChanged event for the role type ComboBox.
        /// </summary>
        /// <param name="sender">The event source (ComboBox).</param>
        /// <param name="e">The event data.</param>
        private void comboBoxManagePerson_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxManagePerson.SelectedItem == null)
                {
                    comboBoxManagePerson.SelectedIndex = -1;
                    comboBoxPersonStatus.SelectedIndex = -1;
                    dataGridViewPersons.Visible = false;
                    return;
                }

                Roles selectedType = (Roles)comboBoxManagePerson.SelectedItem;
                var persons = GetPersonsByType(selectedType);
                LoadPersons(persons);
                comboBoxPersonStatus.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Erro ao carregar Profissionais: {ex.Message}");
            }
        }
        #endregion

        #region Button to update incidents
        /// <summary>
        /// Handles the Click event for the button to update incidents.
        /// </summary>
        /// <param name="sender">The event source (button).</param>
        /// <param name="e">The event data.</param>
        private void buttonUpdatePerson_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewPersons.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Selecione um Profissional para atualizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!ValidatePersonsLoaded()) return;

                foreach (DataGridViewRow row in dataGridViewPersons.Rows)
                {
                    if (row.DataBoundItem is Person person)
                    {
                        _personsManager.UpdatePerson(person);
                    }
                }

                MessageBox.Show("Profissionais atualizados com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Erro ao atualizar os Profissionais: {ex.Message}");
            }
        }
        #endregion

        #region Delete Person
        /// <summary>
        /// Handles the Click event for the button to delete a Person
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">The event arguments</param>
        private void buttonDeletePerson_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewPersons.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Selecione um Profissional para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedRow = dataGridViewPersons.SelectedRows[0];
                if (selectedRow.DataBoundItem is Person person)
                {
                    _personsManager.DeletePerson(person.Id);
                    MessageBox.Show($"Profissional {person.Id} eliminado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshPersonList();
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Erro ao eliminar Profissional: {ex.Message}");
            }
        }
        #endregion

        #region Filter By Status
        /// <summary>
        /// Handles the Click event for the button to filter persons by status.
        /// </summary>
        /// <param name="sender">The event source (button).</param>
        /// <param name="e">The event data.</param>
        private void buttonFilterByStatusPersons_Click(object sender, EventArgs e)
        {
            try
            {

                if (comboBoxPersonStatus.SelectedItem == null)
                {
                    MessageBox.Show("Selecione um estado para filtrar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var status = (PersonStatus)comboBoxPersonStatus.SelectedItem;
                LoadPersons(_personsManager.PersonsByStatus(status));
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Erro ao filtrar Profissionais: {ex.Message}");
            }
        }
        #endregion

        #region Associate Person To Team
        /// <summary>
        /// Handles the click event for associating a person to a team.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An EventArgs that contains the event data.</param>
        private void buttonAssociatePersonToTeam_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxPersons.SelectedItem is not Person selectedPerson ||
                    comboBoxTeams.SelectedItem is not EmergencyTeamBase selectedTeam)
                {
                    MessageBox.Show("Selecione um Profissional e uma equipa.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CleanFilters();
                    return;
                }

                _personsManager.AssociatePersonToTeam(selectedPerson.Id, selectedTeam.Id);
                MessageBox.Show("Profissional associado à equipa!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CleanFilters();
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Erro ao associar Profissional à equipa: {ex.Message}");
                CleanFilters();
            }
        }
        #endregion

        #region Dissociate Person To Team
        /// <summary>
        /// Handles the click event for dissociating a person from a team.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An EventArgs that contains the event data.</param>
        private void buttonDissociatePersonFromTeam_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxDissociatePerson.SelectedItem is not Person selectedPerson ||
                    comboBoxDissociateTeam.SelectedItem is not EmergencyTeamBase selectedTeam)
                {
                    MessageBox.Show("Selecione um Profissional e uma equipa.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CleanFilters();
                    return;
                }

                _personsManager.DissociatePersonFromTeam(selectedPerson.Id, selectedTeam.Id);
                MessageBox.Show("Associação do Profissional eliminada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Erro ao eliminar associação do Profissional à equipa: {ex.Message}");
                CleanFilters();
            }
        }
        #endregion

        #region Configure Columns of the DataGridView
        /// <summary>
        /// Configures the columns of the DataGridView for displaying persons.
        /// </summary>
        private void ConfigureDataGridViewColumns()
        {
            foreach (DataGridViewColumn column in dataGridViewPersons.Columns)
            {
                column.ReadOnly = column.Name switch
                {
                    "Id" or "Age" or "Role" or "TeamType" or "Status" or "TeamMembershipsDisplay" => true,
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
        private void buttonCleanPerson_Click(object sender, EventArgs e)
        {
            comboBoxManagePerson.SelectedIndex = -1;
            comboBoxPersonStatus.SelectedIndex = -1;
            dataGridViewPersons.Visible = false;
        }
        #endregion

        #region Button Close Form
        /// <summary>
        /// Closes the form and returns to the main screen.
        /// </summary>
        /// <param name="sender">The event source (button).</param>
        /// <param name="e">The event data.</param>
        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #endregion

        #region Helper Methods
        /// <summary>
        /// Gets persons filtered by a specific type.
        /// </summary>
        /// <param name="type">The person type to filter by.</param>
        /// <returns>An enumerable collection of persons.</returns>
        private IEnumerable<Person> GetPersonsByType(Roles type)
        {
            return type switch
            {
                Roles.Médico => _personsManager.GetAllDoctor(),
                Roles.TécnicoEmergência => _personsManager.GetAllEmergencyTechnician(),
                Roles.Bombeiro => _personsManager.GetAllFireFighter(),
                Roles.Enfermeiro => _personsManager.GetAllNurse(),
                _ => Enumerable.Empty<Person>(),
            };
        }

        /// <summary>
        /// Loads the provided persons into the DataGridView.
        /// </summary>
        /// <param name="incidents">The collection of persons to display.</param>
        private void LoadPersons(IEnumerable<Person> persons)
        {
            if (persons == null || !persons.Any())
            {
                MessageBox.Show("Nenhum Profissional encontrado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboBoxManagePerson.SelectedIndex = -1;
                comboBoxPersonStatus.SelectedIndex = -1;
                dataGridViewPersons.Visible = false;
                return;
            }

            dataGridViewPersons.DataSource = persons.ToList();
            dataGridViewPersons.Visible = true;
            dataGridViewPersons.Columns["TeamMemberships"].Visible = false;

            
            ConfigureDataGridViewColumns();
        }

        /// <summary>
        /// Validates if persons are currently loaded into the DataGridView.
        /// </summary>
        /// <returns>True if persons are loaded, otherwise false.</returns>
        private bool ValidatePersonsLoaded()
        {
            if (dataGridViewPersons.DataSource == null || dataGridViewPersons.Rows.Count == 0)
            {
                MessageBox.Show("Nenhum Profissional carregado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Refreshes the person list in the DataGridView.
        /// </summary>
        private void RefreshPersonList()
        {
            LoadPersons(_personsManager.GetAllPersons());
        }

        /// <summary>
        /// Displays an error message to the user.
        /// </summary>
        /// <param name="message">The error message to display.</param>
        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Resets all combo box selections to their default state.
        /// This method clears the selected items in the person and team combo boxes
        /// for both association and dissociation operations.
        /// </summary>
        private void CleanFilters()
        {
            comboBoxPersons.SelectedIndex = -1;
            comboBoxTeams.SelectedIndex = -1;
            comboBoxDissociatePerson.SelectedIndex = -1;
            comboBoxDissociateTeam.SelectedIndex = -1;
        }
        #endregion
    }
}
