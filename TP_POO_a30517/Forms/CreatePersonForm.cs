
//-----------------------------------------------------------------
//    <copyright file="CreatePersonForm.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>12-12-2024</date>
//    <author>Cláudio Fernandes</author>
//-----------------------------------------------------------------

using TP_POO_a30517.Data;
using TP_POO_a30517.Enums;
using TP_POO_a30517.Interfaces;
using TP_POO_a30517.Models;

namespace TP_POO_a30517.Forms
{
    /// <summary>
    /// Form for creating a new person profile
    /// </summary>
    public partial class CreatePersonForm : Form
    {
        #region Fields
        private readonly DataBaseConnection _databaseConnection;
        private readonly IPersonsManager _personsManager;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the CreatePersonForm class.
        /// </summary>
        /// <param name="personsManager">Manager for handling persons.</param>
        /// <param name="databaseConnection">Database connection.</param>
        public CreatePersonForm(IPersonsManager personsManager, DataBaseConnection databaseConnection)
        {
            InitializeComponent();
            _personsManager = personsManager;
            _databaseConnection = databaseConnection;
            InitializeForm();
        }
        #endregion

        #region Form Initialization
        /// <summary>
        /// Initializes form components and sets up data sources.
        /// </summary>
        private void InitializeForm()
        {
            HideAllRolePanels();

            comboBoxRoles.SelectedIndexChanged -= ComboBoxRoles_SelectedIndexChanged;

            comboBoxRoles.DataSource = Enum.GetValues(typeof(Roles));
            comboBoxTeamType.DataSource = Enum.GetValues(typeof(TeamType));
            comboBoxStatus.DataSource = Enum.GetValues(typeof(PersonStatus));

            comboBoxRoles.SelectedIndex = -1;
            comboBoxTeamType.SelectedIndex = -1;
            comboBoxStatus.SelectedIndex = -1;

            comboBoxRoles.SelectedIndexChanged += ComboBoxRoles_SelectedIndexChanged;
        }

        /// <summary>
        /// Hides all role-specific panels.
        /// </summary>
        private void HideAllRolePanels()
        {
            panelDoctor.Visible = false;
            panelNurse.Visible = false;
            panelEmergencyTechnician.Visible = false;
            panelFireFighter.Visible = false;
        }

        #endregion

        #region Event Handlers
        /// <summary>
        /// Handles the event when the selected role changes.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event data.</param>
        private void ComboBoxRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxRoles.SelectedItem == null) return;

            HideAllRolePanels();

            switch ((Roles)comboBoxRoles.SelectedItem)
            {
                case Roles.Médico:
                    panelDoctor.Visible = true;
                    break;
                case Roles.Enfermeiro:
                    panelNurse.Visible = true;
                    break;
                case Roles.TécnicoEmergência:
                    panelEmergencyTechnician.Visible = true;
                    break;
                case Roles.Bombeiro:
                    panelFireFighter.Visible = true;
                    break;
            }
        }

        /// <summary>
        /// Handles the click event for the save button.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event data.</param>
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!ValidateBasicFields()) return;

            try
            {
                Roles selectedRole = (Roles)comboBoxRoles.SelectedItem;
                Person newPerson = CreatePersonBasedOnRole(selectedRole);
                _personsManager.AddPerson(newPerson);

                MessageBox.Show("Profissional criado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao criar o profissional: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        /// Handles the key press event for textboxes, allowing only numbers.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Key press event data.</param>
        private void Textbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        #endregion

        #region Validation
        /// <summary>
        /// Validates the basic fields of the form.
        /// </summary>
        /// <returns>True if all basic fields are valid, false otherwise.</returns>
        private bool ValidateBasicFields()
        {
            if (!AreFieldsValid(textBoxName, textBoxCitizenCard, textBoxPhone, textBoxEmail,
                textBoxAddress, textBoxNationality, comboBoxRoles, comboBoxTeamType,
                comboBoxStatus, datePickerBirthdate))
            {
                MessageBox.Show("Preencha todos os campos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            Roles role = (Roles)comboBoxRoles.SelectedItem;
            return role switch
            {
                Roles.Médico => ValidateDoctorFields(),
                Roles.Enfermeiro => ValidateNurseFields(),
                Roles.TécnicoEmergência => ValidateTechnicianFields(),
                Roles.Bombeiro => ValidateFireFighterFields(),
                _ => true
            };
        }

        /// <summary>
        /// Validates the fields specific to the Doctor role.
        /// </summary>
        /// <returns>True if all Doctor fields are valid, false otherwise.</returns>
        private bool ValidateDoctorFields()
        {
            if (!AreFieldsValid(textBoxProfessionalNameDoctor, textBoxCardNumberDoctor, textBoxSpecialty) ||
                !int.TryParse(textBoxCardNumberDoctor.Text, out _))
            {
                MessageBox.Show("Preencha todos os campos do Médico.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Validates the fields specific to the Nurse role.
        /// </summary>
        /// <returns>True if all Nurse fields are valid, false otherwise.</returns>
        private bool ValidateNurseFields()
        {
            if (!AreFieldsValid(textBoxProfessionalNameNurse, textBoxCardNumberNurse, textBoxAreaOfActivity) ||
                !int.TryParse(textBoxCardNumberNurse.Text, out _))
            {
                MessageBox.Show("Preencha todos os campos do Enfermeiro.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Validates the fields specific to the Emergency Technician role.
        /// </summary>
        /// <returns>True if all Emergency Technician fields are valid, false otherwise.</returns>
        private bool ValidateTechnicianFields()
        {
            if (!AreFieldsValid(textBoxProfessionalNameTechnician, textBoxTechnicalNumber) ||
                !int.TryParse(textBoxTechnicalNumber.Text, out _))
            {
                MessageBox.Show("Preencha todos os campos do Técnico de Emergência.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Validates the fields specific to the Firefighter role.
        /// </summary>
        /// <returns>True if all Firefighter fields are valid, false otherwise.</returns>
        private bool ValidateFireFighterFields()
        {
            if (!AreFieldsValid(textBoxYearsOfExperience, textBoxSpecialization, textBoxMechanographicNumber) ||
                !int.TryParse(textBoxYearsOfExperience.Text, out _) ||
                !int.TryParse(textBoxMechanographicNumber.Text, out _))
            {
                MessageBox.Show("Preencha todos os campos do Bombeiro.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Checks if all provided controls have valid values.
        /// </summary>
        /// <param name="controls">Array of controls to validate.</param>
        /// <returns>True if all controls are valid, false otherwise.</returns>
        private bool AreFieldsValid(params Control[] controls)
        {
            foreach (var control in controls)
            {
                if (control is TextBox textBox && string.IsNullOrWhiteSpace(textBox.Text))
                    return false;

                if (control is ComboBox comboBox && comboBox.SelectedItem == null)
                    return false;

                if (control is DateTimePicker dateTimePicker && dateTimePicker.Value == null)
                    return false;
            }
            return true;
        }

        #endregion

        #region Person Creation
        /// <summary>
        /// Creates a Person object based on the selected role and form inputs.
        /// </summary>
        /// <param name="role">The selected role for the person.</param>
        /// <returns>A new Person object of the appropriate derived class.</returns>
        private Person CreatePersonBasedOnRole(Roles role)
        {
            string name = textBoxName.Text.Trim();
            string citizenCard = textBoxCitizenCard.Text.Trim();
            string phone = textBoxPhone.Text.Trim();
            string email = textBoxEmail.Text.Trim();
            string address = textBoxAddress.Text.Trim();
            string nationality = textBoxNationality.Text.Trim();
            DateOnly birthdate = DateOnly.FromDateTime(datePickerBirthdate.Value.Date);
            TeamType teamType = (TeamType)comboBoxTeamType.SelectedItem;
            PersonStatus status = (PersonStatus)comboBoxStatus.SelectedItem;

            return role switch
            {
                Roles.Médico => new Doctor(
                    name, birthdate, citizenCard, phone, email, address, nationality, role,
                    teamType, status,
                    textBoxProfessionalNameDoctor.Text.Trim(),
                    int.Parse(textBoxCardNumberDoctor.Text.Trim()),
                    textBoxSpecialty.Text.Trim()),

                Roles.Enfermeiro => new Nurse(
                    name, birthdate, citizenCard, phone, email, address, nationality, role,
                    teamType, status,
                    textBoxProfessionalNameNurse.Text.Trim(),
                    int.Parse(textBoxCardNumberNurse.Text.Trim()),
                    textBoxAreaOfActivity.Text.Trim()),

                Roles.TécnicoEmergência => new EmergencyTechnician(
                    name, birthdate, citizenCard, phone, email, address, nationality, role,
                    teamType, status,
                    textBoxProfessionalNameTechnician.Text.Trim(),
                    int.Parse(textBoxTechnicalNumber.Text.Trim())),

                Roles.Bombeiro => new FireFighter(
                    name, birthdate, citizenCard, phone, email, address, nationality, role,
                    teamType, status,
                    int.Parse(textBoxYearsOfExperience.Text.Trim()),
                    textBoxSpecialization.Text.Trim(),
                    int.Parse(textBoxMechanographicNumber.Text.Trim())),

                _ => throw new ArgumentException("Cargo inválido.")
            };
        }

        #endregion

    }
}

