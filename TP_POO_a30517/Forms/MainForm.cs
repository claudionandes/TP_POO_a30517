
//-----------------------------------------------------------------
//    <copyright file="MainForm.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>24-11-2024</date>
//    <author>Cláudio Fernandes</author>
//-----------------------------------------------------------------

using TP_POO_a30517.Data;
using TP_POO_a30517.Interfaces;

namespace TP_POO_a30517.Forms
{
    /// <summary>
    /// Main form of the application
    /// </summary>
    public partial class MainForm : Form
    {
        #region Fields
        private readonly IIncidentManager _incidentManager;
        private readonly IPersonsManager _personsManager;
        private readonly ITeamsManager _teamsManager;
        private readonly DataBaseConnection _databaseConnection;
        #endregion

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="incidentManager"></param>
        /// <param name="databaseConnection"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public MainForm(IIncidentManager incidentManager, IPersonsManager personsManager, ITeamsManager teamsManager, DataBaseConnection databaseConnection)
        {
            InitializeComponent();

            _incidentManager = incidentManager ?? throw new ArgumentNullException(nameof(incidentManager));
            _personsManager = personsManager ?? throw new ArgumentNullException(nameof(personsManager));
            _teamsManager = teamsManager ?? throw new ArgumentNullException(nameof(teamsManager));
            _databaseConnection = databaseConnection ?? throw new ArgumentNullException(nameof(databaseConnection));
        }
        #endregion

        #region Event Handlers
        /// <summary>
        /// Handles the Click event for creating a new incident
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">The event arguments</param>
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            var createIncidentForm = new CreateIncidentForm(_incidentManager, _databaseConnection);
            createIncidentForm.ShowDialog();
        }

        /// <summary>
        /// Handles the Click event for maintaining incidents
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">The event arguments</param>
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            var maintenanceIncidentForm = new IncidentMaintenanceForm(_incidentManager, _databaseConnection);
            maintenanceIncidentForm.ShowDialog();
        }

        /// <summary>
        /// Opens the Create Person form when the corresponding menu item is clicked
        /// </summary>
        /// <param name="sender">The object that triggered the event</param>
        /// <param name="e">Event arguments</param>
        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            var createPersonForm = new CreatePersonForm(_personsManager, _databaseConnection);
            createPersonForm.ShowDialog();
        }

        /// <summary>
        /// Opens the Person Maintenance form when the maintenance menu item is clicked
        /// </summary>
        /// <param name="sender">The object that triggered the event</param>
        /// <param name="e">Event arguments</param>
        private void manutençãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var maintenancePersonForm = new PersonMaintenanceForm(_personsManager, _teamsManager, _databaseConnection);
            maintenancePersonForm.ShowDialog();
        }

        /// <summary>
        /// Opens the Create Team form when the new record menu item is clicked
        /// </summary>
        /// <param name="sender">The object that triggered the event</param>
        /// <param name="e">Event arguments</param>
        private void novoRegistoToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var createTeamForm = new CreateTeamForm(_teamsManager, _databaseConnection);
            createTeamForm.ShowDialog();
        }

        /// <summary>
        /// Handles the Click event for exiting the application
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">The event arguments</param>
        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

    }
}
