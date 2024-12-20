
//-----------------------------------------------------------------
//    <copyright file="CreateTeamForm.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>15-12-2024</date>
//    <author>Cláudio Fernandes</author>
//-----------------------------------------------------------------

using TP_POO_a30517.Data;
using TP_POO_a30517.Enums;
using TP_POO_a30517.Interfaces;
using TP_POO_a30517.Teams;

namespace TP_POO_a30517.Forms
{
    /// <summary>
    /// Form to create and manage teams
    /// </summary>
    public partial class CreateTeamForm : Form
    {
        #region Fields
        /// <summary>
        /// Database connection instance.
        /// </summary>
        private readonly DataBaseConnection _databaseConnection;

        /// <summary>
        /// Manager instance for handling teams.
        /// </summary>
        private readonly ITeamsManager _teamsManager;

        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the CreateIncidentForm class.
        /// </summary>
        /// <param name="incidentManager">Manager for handling incidents.</param>
        /// <param name="databaseConnection">Database connection.</param>
        public CreateTeamForm(ITeamsManager teamsManager, DataBaseConnection databaseConnection)
        {
            InitializeComponent();
            _teamsManager = teamsManager;
            _databaseConnection = databaseConnection;

            InitializeForm();
        }
        #endregion

        #region Initialization Methods
        /// <summary>
        /// Initializes the form components.
        /// </summary>
        private void InitializeForm()
        {
            ConfigureComboBoxes();
        }

        /// <summary>
        /// Configures the combo boxes with enum values.
        /// </summary>
        private void ConfigureComboBoxes()
        {
            comboBoxTeamType.DataSource = Enum.GetValues(typeof(TeamType));
            comboBoxTeamStatus.DataSource = Enum.GetValues(typeof(TeamStatus));

            ClearComboBoxSelections();
        }

        /// <summary>
        /// Clears the selections in the combo boxes.
        /// </summary>
        private void ClearComboBoxSelections()
        {
            comboBoxTeamType.SelectedIndex = -1;
            comboBoxTeamStatus.SelectedIndex = -1;
        }
        #endregion

        #region Form Events
        /// <summary>
        /// Handles the click event for the Create Team button.
        /// This method validates the input fields and attempts to create a new team.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void buttonCreateTeam_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInputs(out EmergencyTeamBase team))
                {
                    return;
                }

                _teamsManager.AddTeam(team);
                MessageBox.Show("Equipa criada com sucesso!");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao criar a equipa: {ex.Message}");
            }
        }

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

        #region Validation and Creation
        /// <summary>
        /// Validates the input fields for creating a new team.
        /// This method checks if all required fields are filled out.
        /// </summary>
        /// <param name="team">Outputs the created team instance if valid.</param>
        /// <returns>True if the inputs are valid; otherwise, false.</returns>
        private bool ValidateInputs(out EmergencyTeamBase team)
        {
            team = null;

            string teamName = textBoxTeamName.Text.Trim();

            if (string.IsNullOrWhiteSpace(teamName) || comboBoxTeamType.SelectedItem == null || comboBoxTeamStatus.SelectedItem == null)
            {
                MessageBox.Show("Preencha todos os campos.");
                return false;
            }

            var teamType = (TeamType)comboBoxTeamType.SelectedItem;
            var teamStatus = (TeamStatus)comboBoxTeamStatus.SelectedItem;

            if (teamType == TeamType.Bombeiros)
            {
                team = new FireFighters(teamName, teamStatus, teamType);
            }
            else if (teamType == TeamType.INEM)
            {
                team = new INEM(teamName, teamStatus, teamType);
            }

            return team != null;
        }
        #endregion

    }
}
