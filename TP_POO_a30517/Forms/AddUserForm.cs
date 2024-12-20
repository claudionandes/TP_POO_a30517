
//-----------------------------------------------------------------
//    <copyright file="AddUserForm.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>11-12-2024</date>
//    <author>Cláudio Fernandes</author>
//-----------------------------------------------------------------

using TP_POO_a30517.Data;
using TP_POO_a30517.Interfaces;


namespace TP_POO_a30517.Forms
{
    /// <summary>
    /// Form for adding a new user to the system
    /// </summary>
    public partial class AddUserForm : Form
    {
        #region Fields
        private readonly IAddUser _addUser;
        private readonly DataBaseConnection _databaseConnection;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the AddUserForm class
        /// </summary>
        /// <param name="addUser">Interface for adding users</param>
        /// <param name="databaseConnection">Database connection object</param>
        public AddUserForm(IAddUser addUser, DataBaseConnection databaseConnection)
        {
            InitializeComponent();
            _addUser = addUser;
            _databaseConnection = databaseConnection;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Handles the click event of the Create User button
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">Event arguments</param>
        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            {
                var username = txtUsername.Text?.Trim();
                var password = txtPassword.Text?.Trim();

                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("Os campos de Username e password são obrigatórios.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    _addUser.AddUsers(username, password);
                    MessageBox.Show("Utilizador criado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Handles the click event of the Cancel button
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">Event arguments</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
    }
}