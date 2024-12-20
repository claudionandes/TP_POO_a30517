namespace TP_POO_a30517.Forms
{
    partial class PersonMaintenanceForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            buttonFilterByStatusPersons = new Button();
            comboBoxPersonStatus = new ComboBox();
            buttonCleanPerson = new Button();
            buttonDeletePerson = new Button();
            buttonUpdatePerson = new Button();
            comboBoxManagePerson = new ComboBox();
            ButtonListPersons = new Button();
            dataGridViewPersons = new DataGridView();
            buttonClose = new Button();
            buttonCreatePerson = new Button();
            pictureBox1 = new PictureBox();
            buttonAssociatePersonToTeam = new Button();
            buttonDissociatePersonFromTeam = new Button();
            comboBoxPersons = new ComboBox();
            comboBoxTeams = new ComboBox();
            comboBoxDissociateTeam = new ComboBox();
            comboBoxDissociatePerson = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPersons).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // buttonFilterByStatusPersons
            // 
            buttonFilterByStatusPersons.Location = new Point(23, 371);
            buttonFilterByStatusPersons.Name = "buttonFilterByStatusPersons";
            buttonFilterByStatusPersons.Size = new Size(166, 29);
            buttonFilterByStatusPersons.TabIndex = 21;
            buttonFilterByStatusPersons.Text = "Listar Por Estado";
            buttonFilterByStatusPersons.UseVisualStyleBackColor = true;
            buttonFilterByStatusPersons.Click += buttonFilterByStatusPersons_Click;
            // 
            // comboBoxPersonStatus
            // 
            comboBoxPersonStatus.FormattingEnabled = true;
            comboBoxPersonStatus.Location = new Point(207, 371);
            comboBoxPersonStatus.Name = "comboBoxPersonStatus";
            comboBoxPersonStatus.Size = new Size(151, 28);
            comboBoxPersonStatus.TabIndex = 20;
            // 
            // buttonCleanPerson
            // 
            buttonCleanPerson.Location = new Point(387, 348);
            buttonCleanPerson.Name = "buttonCleanPerson";
            buttonCleanPerson.Size = new Size(94, 28);
            buttonCleanPerson.TabIndex = 19;
            buttonCleanPerson.Text = "Limpar";
            buttonCleanPerson.UseVisualStyleBackColor = true;
            buttonCleanPerson.Click += buttonCleanPerson_Click;
            // 
            // buttonDeletePerson
            // 
            buttonDeletePerson.Location = new Point(23, 125);
            buttonDeletePerson.Name = "buttonDeletePerson";
            buttonDeletePerson.Size = new Size(166, 29);
            buttonDeletePerson.TabIndex = 18;
            buttonDeletePerson.Text = "Eliminar";
            buttonDeletePerson.UseVisualStyleBackColor = true;
            buttonDeletePerson.Click += buttonDeletePerson_Click;
            // 
            // buttonUpdatePerson
            // 
            buttonUpdatePerson.Location = new Point(23, 69);
            buttonUpdatePerson.Name = "buttonUpdatePerson";
            buttonUpdatePerson.Size = new Size(166, 29);
            buttonUpdatePerson.TabIndex = 17;
            buttonUpdatePerson.Text = "Atualizar";
            buttonUpdatePerson.UseVisualStyleBackColor = true;
            buttonUpdatePerson.Click += buttonUpdatePerson_Click;
            // 
            // comboBoxManagePerson
            // 
            comboBoxManagePerson.FormattingEnabled = true;
            comboBoxManagePerson.Location = new Point(207, 322);
            comboBoxManagePerson.Name = "comboBoxManagePerson";
            comboBoxManagePerson.Size = new Size(151, 28);
            comboBoxManagePerson.TabIndex = 16;
            comboBoxManagePerson.SelectedIndexChanged += comboBoxManagePerson_SelectedIndexChanged;
            // 
            // ButtonListPersons
            // 
            ButtonListPersons.Location = new Point(23, 322);
            ButtonListPersons.Name = "ButtonListPersons";
            ButtonListPersons.Size = new Size(166, 29);
            ButtonListPersons.TabIndex = 15;
            ButtonListPersons.Text = "Listar Profissionais";
            ButtonListPersons.UseVisualStyleBackColor = true;
            ButtonListPersons.Click += ButtonListPersons_Click;
            // 
            // dataGridViewPersons
            // 
            dataGridViewPersons.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPersons.Location = new Point(23, 428);
            dataGridViewPersons.Name = "dataGridViewPersons";
            dataGridViewPersons.RowHeadersWidth = 51;
            dataGridViewPersons.Size = new Size(1670, 529);
            dataGridViewPersons.TabIndex = 14;
            // 
            // buttonClose
            // 
            buttonClose.Location = new Point(23, 984);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(94, 29);
            buttonClose.TabIndex = 13;
            buttonClose.Text = "Voltar";
            buttonClose.UseVisualStyleBackColor = true;
            buttonClose.Click += buttonClose_Click;
            // 
            // buttonCreatePerson
            // 
            buttonCreatePerson.Location = new Point(23, 12);
            buttonCreatePerson.Name = "buttonCreatePerson";
            buttonCreatePerson.Size = new Size(166, 29);
            buttonCreatePerson.TabIndex = 12;
            buttonCreatePerson.Text = "Criar";
            buttonCreatePerson.UseVisualStyleBackColor = true;
            buttonCreatePerson.Click += buttonCreatePerson_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.teams1;
            pictureBox1.Location = new Point(1340, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(353, 317);
            pictureBox1.TabIndex = 22;
            pictureBox1.TabStop = false;
            // 
            // buttonAssociatePersonToTeam
            // 
            buttonAssociatePersonToTeam.Location = new Point(23, 185);
            buttonAssociatePersonToTeam.Name = "buttonAssociatePersonToTeam";
            buttonAssociatePersonToTeam.Size = new Size(166, 29);
            buttonAssociatePersonToTeam.TabIndex = 23;
            buttonAssociatePersonToTeam.Text = "Associar Equipa";
            buttonAssociatePersonToTeam.UseVisualStyleBackColor = true;
            buttonAssociatePersonToTeam.Click += buttonAssociatePersonToTeam_Click;
            // 
            // buttonDissociatePersonFromTeam
            // 
            buttonDissociatePersonFromTeam.Location = new Point(23, 242);
            buttonDissociatePersonFromTeam.Name = "buttonDissociatePersonFromTeam";
            buttonDissociatePersonFromTeam.Size = new Size(166, 29);
            buttonDissociatePersonFromTeam.TabIndex = 24;
            buttonDissociatePersonFromTeam.Text = "Eliminar associação";
            buttonDissociatePersonFromTeam.UseVisualStyleBackColor = true;
            buttonDissociatePersonFromTeam.Click += buttonDissociatePersonFromTeam_Click;
            // 
            // comboBoxPersons
            // 
            comboBoxPersons.FormattingEnabled = true;
            comboBoxPersons.Location = new Point(243, 185);
            comboBoxPersons.Name = "comboBoxPersons";
            comboBoxPersons.Size = new Size(396, 28);
            comboBoxPersons.TabIndex = 25;
            // 
            // comboBoxTeams
            // 
            comboBoxTeams.FormattingEnabled = true;
            comboBoxTeams.Location = new Point(674, 185);
            comboBoxTeams.Name = "comboBoxTeams";
            comboBoxTeams.Size = new Size(151, 28);
            comboBoxTeams.TabIndex = 26;
            // 
            // comboBoxDissociateTeam
            // 
            comboBoxDissociateTeam.FormattingEnabled = true;
            comboBoxDissociateTeam.Location = new Point(674, 242);
            comboBoxDissociateTeam.Name = "comboBoxDissociateTeam";
            comboBoxDissociateTeam.Size = new Size(151, 28);
            comboBoxDissociateTeam.TabIndex = 28;
            // 
            // comboBoxDissociatePerson
            // 
            comboBoxDissociatePerson.FormattingEnabled = true;
            comboBoxDissociatePerson.Location = new Point(243, 242);
            comboBoxDissociatePerson.Name = "comboBoxDissociatePerson";
            comboBoxDissociatePerson.Size = new Size(396, 28);
            comboBoxDissociatePerson.TabIndex = 27;
            // 
            // PersonMaintenanceForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1705, 1036);
            Controls.Add(comboBoxDissociateTeam);
            Controls.Add(comboBoxDissociatePerson);
            Controls.Add(comboBoxTeams);
            Controls.Add(comboBoxPersons);
            Controls.Add(buttonDissociatePersonFromTeam);
            Controls.Add(buttonAssociatePersonToTeam);
            Controls.Add(pictureBox1);
            Controls.Add(buttonFilterByStatusPersons);
            Controls.Add(comboBoxPersonStatus);
            Controls.Add(buttonCleanPerson);
            Controls.Add(buttonDeletePerson);
            Controls.Add(buttonUpdatePerson);
            Controls.Add(comboBoxManagePerson);
            Controls.Add(ButtonListPersons);
            Controls.Add(dataGridViewPersons);
            Controls.Add(buttonClose);
            Controls.Add(buttonCreatePerson);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PersonMaintenanceForm";
            Text = "Manutenção de Profissionais";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)dataGridViewPersons).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button buttonFilterByStatusPersons;
        private ComboBox comboBoxPersonStatus;
        private Button buttonCleanPerson;
        private Button buttonDeletePerson;
        private Button buttonUpdatePerson;
        private ComboBox comboBoxManagePerson;
        private Button ButtonListPersons;
        private DataGridView dataGridViewPersons;
        private Button buttonClose;
        private Button buttonCreatePerson;
        private PictureBox pictureBox1;
        private Button buttonAssociatePersonToTeam;
        private Button buttonDissociatePersonFromTeam;
        private ComboBox comboBoxPersons;
        private ComboBox comboBoxTeams;
        private ComboBox comboBoxDissociateTeam;
        private ComboBox comboBoxDissociatePerson;
    }
}