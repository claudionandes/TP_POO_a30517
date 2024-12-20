
//-----------------------------------------------------------------
//    <copyright file="Authenticate.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>24-11-2024</date>
//    <author>Cláudio Fernandes</author>
//-----------------------------------------------------------------

using TP_POO_a30517.Data;
using TP_POO_a30517.Forms;
using TP_POO_a30517.Interfaces;

namespace TP_POO_a30517
{
    /// <summary>
    /// Represents the authentication form for user login
    /// </summary>
    public partial class Authenticate : Form
    {
        #region Fields
        private readonly DataBaseConnection _databaseConnection;
        private readonly IAuthenticate _authManager;
        private readonly IAddUser _addUser;
        private readonly IIncidentManager _incidentManager;
        private readonly IPersonsManager _personsManager;
        private readonly ITeamsManager _teamsManager;
        #endregion

        #region Constructor
        //private readonly IAuthServ _authService;
        /// <summary>
        /// Initializes a new instance of the <see cref="Authenticate"/> class.
        /// </summary>
        public Authenticate(IAuthenticate authManager, DataBaseConnection databaseConnection, IAddUser addUser, IIncidentManager incidentManager, IPersonsManager personsManager, ITeamsManager teamsManager)
        {
            _databaseConnection = databaseConnection ?? throw new ArgumentNullException(nameof(databaseConnection));
            _authManager = authManager;
            _addUser = addUser;
            _incidentManager = incidentManager ?? throw new ArgumentNullException(nameof(incidentManager));
            _personsManager = personsManager ?? throw new ArgumentNullException(nameof(personsManager));
            _teamsManager = teamsManager ?? throw new ArgumentNullException(nameof(teamsManager));
            InitializeComponent();
        }
        #endregion

        #region Event Handlers
        /// <summary>
        /// Handles the click event of the login button.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            var username = txtUsername.Text.Trim();
            var password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Preencha todos os campos.");
                return;
            }

            #region Authentication Process
            try
            {
                var user = _authManager.Authenticate(username, password);

                if (user != null)
                {

                    Hide();
                    MainForm mainForm = new MainForm(_incidentManager, _personsManager, _teamsManager, _databaseConnection);
                    mainForm.Show();
                }
                else
                {
                    MessageBox.Show("Username ou Password inválidos.");
                }
                txtUsername.Clear();
                txtPassword.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro: {ex.Message}");
            }
            #endregion
        }
        #endregion

        private void groupBox1_Resize(object sender, EventArgs e)
        {
            groupBoxLogin.Left = (this.ClientSize.Width - groupBoxLogin.Width) / 2;
            groupBoxLogin.Top = (this.ClientSize.Height - groupBoxLogin.Height) / 2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddUserForm addUserForm = new AddUserForm(_addUser, _databaseConnection);
            addUserForm.Show();
        }

        private void buttonSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}