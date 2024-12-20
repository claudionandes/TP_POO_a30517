namespace TP_POO_a30517.Forms
{
    partial class CreateIncidentForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateIncidentForm));
            textBoxDescription = new TextBox();
            label1 = new Label();
            label2 = new Label();
            textBoxLocation = new TextBox();
            comboBoxSeverity = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            comboBoxIncidentType = new ComboBox();
            label5 = new Label();
            comboBoxTeam = new ComboBox();
            buttonCreateIncident = new Button();
            label6 = new Label();
            comboBoxIncidentStatus = new ComboBox();
            label7 = new Label();
            labelNamePatient = new Label();
            textBoxNamePatient = new TextBox();
            labelAgePatient = new Label();
            labelMedicalCondition = new Label();
            textBoxMedicalCondition = new TextBox();
            labelAffectedAreaFire = new Label();
            labelPeopleAffectedFire = new Label();
            textBoxAffectedAreaFire = new TextBox();
            textBoxPeopleAffectedFire = new TextBox();
            labelAffectedAreaCatastrophe = new Label();
            labelCatastropheType = new Label();
            textBoxCatastropheType = new TextBox();
            labelIntensityCatastrophe = new Label();
            labelPeopleAffectedCatastrophe = new Label();
            textBoxIntensityCatastrophe = new TextBox();
            textBoxPeopleAffectedCatastrophe = new TextBox();
            textBoxAffectedAreaCatastrophe = new TextBox();
            printPreviewDialog1 = new PrintPreviewDialog();
            panelMedical = new Panel();
            textBoxAgePatient = new TextBox();
            panelFire = new Panel();
            panelCatastrophe = new Panel();
            listBoxEquipment = new ListBox();
            notifyIcon1 = new NotifyIcon(components);
            buttonReturnMain = new Button();
            pictureBox1 = new PictureBox();
            panelMedical.SuspendLayout();
            panelFire.SuspendLayout();
            panelCatastrophe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // textBoxDescription
            // 
            textBoxDescription.Location = new Point(298, 30);
            textBoxDescription.Name = "textBoxDescription";
            textBoxDescription.Size = new Size(693, 27);
            textBoxDescription.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(70, 30);
            label1.Name = "label1";
            label1.Size = new Size(74, 20);
            label1.TabIndex = 1;
            label1.Text = "Descrição";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(70, 90);
            label2.Name = "label2";
            label2.Size = new Size(87, 20);
            label2.TabIndex = 2;
            label2.Text = "Localização";
            // 
            // textBoxLocation
            // 
            textBoxLocation.Location = new Point(298, 90);
            textBoxLocation.Name = "textBoxLocation";
            textBoxLocation.Size = new Size(693, 27);
            textBoxLocation.TabIndex = 3;
            // 
            // comboBoxSeverity
            // 
            comboBoxSeverity.FormattingEnabled = true;
            comboBoxSeverity.Location = new Point(298, 150);
            comboBoxSeverity.Name = "comboBoxSeverity";
            comboBoxSeverity.Size = new Size(165, 28);
            comboBoxSeverity.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(70, 150);
            label3.Name = "label3";
            label3.Size = new Size(83, 20);
            label3.TabIndex = 5;
            label3.Text = "Severidade";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(70, 394);
            label4.Name = "label4";
            label4.Size = new Size(39, 20);
            label4.TabIndex = 6;
            label4.Text = "Tipo";
            // 
            // comboBoxIncidentType
            // 
            comboBoxIncidentType.FormattingEnabled = true;
            comboBoxIncidentType.Location = new Point(298, 394);
            comboBoxIncidentType.Name = "comboBoxIncidentType";
            comboBoxIncidentType.Size = new Size(165, 28);
            comboBoxIncidentType.TabIndex = 7;
            comboBoxIncidentType.SelectedIndexChanged += comboBoxIncidentType_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(70, 347);
            label5.Name = "label5";
            label5.Size = new Size(55, 20);
            label5.TabIndex = 8;
            label5.Text = "Equipa";
            // 
            // comboBoxTeam
            // 
            comboBoxTeam.FormattingEnabled = true;
            comboBoxTeam.Location = new Point(298, 347);
            comboBoxTeam.Name = "comboBoxTeam";
            comboBoxTeam.Size = new Size(165, 28);
            comboBoxTeam.TabIndex = 9;
            // 
            // buttonCreateIncident
            // 
            buttonCreateIncident.Location = new Point(70, 937);
            buttonCreateIncident.Name = "buttonCreateIncident";
            buttonCreateIncident.Size = new Size(220, 29);
            buttonCreateIncident.TabIndex = 10;
            buttonCreateIncident.Text = "Criar Ocorrência";
            buttonCreateIncident.UseVisualStyleBackColor = true;
            buttonCreateIncident.Click += button1_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(70, 204);
            label6.Name = "label6";
            label6.Size = new Size(54, 20);
            label6.TabIndex = 11;
            label6.Text = "Estado";
            // 
            // comboBoxIncidentStatus
            // 
            comboBoxIncidentStatus.FormattingEnabled = true;
            comboBoxIncidentStatus.Location = new Point(298, 204);
            comboBoxIncidentStatus.Name = "comboBoxIncidentStatus";
            comboBoxIncidentStatus.Size = new Size(165, 28);
            comboBoxIncidentStatus.TabIndex = 12;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(70, 262);
            label7.Name = "label7";
            label7.Size = new Size(98, 20);
            label7.TabIndex = 13;
            label7.Text = "Equipamento";
            // 
            // labelNamePatient
            // 
            labelNamePatient.AutoSize = true;
            labelNamePatient.Location = new Point(19, 10);
            labelNamePatient.Name = "labelNamePatient";
            labelNamePatient.Size = new Size(109, 20);
            labelNamePatient.TabIndex = 15;
            labelNamePatient.Text = "Nome Paciente";
            // 
            // textBoxNamePatient
            // 
            textBoxNamePatient.Location = new Point(249, 10);
            textBoxNamePatient.Name = "textBoxNamePatient";
            textBoxNamePatient.Size = new Size(693, 27);
            textBoxNamePatient.TabIndex = 16;
            // 
            // labelAgePatient
            // 
            labelAgePatient.AutoSize = true;
            labelAgePatient.Location = new Point(19, 64);
            labelAgePatient.Name = "labelAgePatient";
            labelAgePatient.Size = new Size(106, 20);
            labelAgePatient.TabIndex = 17;
            labelAgePatient.Text = "Idade Paciente";
            // 
            // labelMedicalCondition
            // 
            labelMedicalCondition.AutoSize = true;
            labelMedicalCondition.Location = new Point(19, 111);
            labelMedicalCondition.Name = "labelMedicalCondition";
            labelMedicalCondition.Size = new Size(119, 20);
            labelMedicalCondition.TabIndex = 19;
            labelMedicalCondition.Text = "Situação Médica";
            // 
            // textBoxMedicalCondition
            // 
            textBoxMedicalCondition.Location = new Point(249, 104);
            textBoxMedicalCondition.Name = "textBoxMedicalCondition";
            textBoxMedicalCondition.Size = new Size(693, 27);
            textBoxMedicalCondition.TabIndex = 20;
            // 
            // labelAffectedAreaFire
            // 
            labelAffectedAreaFire.AutoSize = true;
            labelAffectedAreaFire.Location = new Point(18, 13);
            labelAffectedAreaFire.Name = "labelAffectedAreaFire";
            labelAffectedAreaFire.Size = new Size(97, 20);
            labelAffectedAreaFire.TabIndex = 21;
            labelAffectedAreaFire.Text = "Área Afetada";
            // 
            // labelPeopleAffectedFire
            // 
            labelPeopleAffectedFire.AutoSize = true;
            labelPeopleAffectedFire.Location = new Point(19, 54);
            labelPeopleAffectedFire.Name = "labelPeopleAffectedFire";
            labelPeopleAffectedFire.Size = new Size(122, 20);
            labelPeopleAffectedFire.TabIndex = 22;
            labelPeopleAffectedFire.Text = "Pessoas Afetadas";
            // 
            // textBoxAffectedAreaFire
            // 
            textBoxAffectedAreaFire.Location = new Point(249, 10);
            textBoxAffectedAreaFire.Name = "textBoxAffectedAreaFire";
            textBoxAffectedAreaFire.Size = new Size(165, 27);
            textBoxAffectedAreaFire.TabIndex = 23;
            textBoxAffectedAreaFire.KeyPress += Textbox_KeyPress;
            // 
            // textBoxPeopleAffectedFire
            // 
            textBoxPeopleAffectedFire.Location = new Point(249, 47);
            textBoxPeopleAffectedFire.Name = "textBoxPeopleAffectedFire";
            textBoxPeopleAffectedFire.Size = new Size(165, 27);
            textBoxPeopleAffectedFire.TabIndex = 24;
            textBoxPeopleAffectedFire.KeyPress += Textbox_KeyPress;
            // 
            // labelAffectedAreaCatastrophe
            // 
            labelAffectedAreaCatastrophe.AutoSize = true;
            labelAffectedAreaCatastrophe.Location = new Point(18, 74);
            labelAffectedAreaCatastrophe.Name = "labelAffectedAreaCatastrophe";
            labelAffectedAreaCatastrophe.Size = new Size(97, 20);
            labelAffectedAreaCatastrophe.TabIndex = 25;
            labelAffectedAreaCatastrophe.Text = "Área Afetada";
            // 
            // labelCatastropheType
            // 
            labelCatastropheType.AutoSize = true;
            labelCatastropheType.Location = new Point(18, 22);
            labelCatastropheType.Name = "labelCatastropheType";
            labelCatastropheType.Size = new Size(132, 20);
            labelCatastropheType.TabIndex = 26;
            labelCatastropheType.Text = "Tipo de Catástrofe";
            // 
            // textBoxCatastropheType
            // 
            textBoxCatastropheType.Location = new Point(314, 19);
            textBoxCatastropheType.Name = "textBoxCatastropheType";
            textBoxCatastropheType.Size = new Size(220, 27);
            textBoxCatastropheType.TabIndex = 27;
            // 
            // labelIntensityCatastrophe
            // 
            labelIntensityCatastrophe.AutoSize = true;
            labelIntensityCatastrophe.Location = new Point(18, 169);
            labelIntensityCatastrophe.Name = "labelIntensityCatastrophe";
            labelIntensityCatastrophe.Size = new Size(86, 20);
            labelIntensityCatastrophe.TabIndex = 28;
            labelIntensityCatastrophe.Text = "Intensidade";
            // 
            // labelPeopleAffectedCatastrophe
            // 
            labelPeopleAffectedCatastrophe.AutoSize = true;
            labelPeopleAffectedCatastrophe.Location = new Point(18, 122);
            labelPeopleAffectedCatastrophe.Name = "labelPeopleAffectedCatastrophe";
            labelPeopleAffectedCatastrophe.Size = new Size(122, 20);
            labelPeopleAffectedCatastrophe.TabIndex = 29;
            labelPeopleAffectedCatastrophe.Text = "Pessoas Afetadas";
            // 
            // textBoxIntensityCatastrophe
            // 
            textBoxIntensityCatastrophe.Location = new Point(314, 169);
            textBoxIntensityCatastrophe.Name = "textBoxIntensityCatastrophe";
            textBoxIntensityCatastrophe.Size = new Size(220, 27);
            textBoxIntensityCatastrophe.TabIndex = 30;
            textBoxIntensityCatastrophe.KeyPress += Textbox_KeyPress;
            // 
            // textBoxPeopleAffectedCatastrophe
            // 
            textBoxPeopleAffectedCatastrophe.Location = new Point(314, 122);
            textBoxPeopleAffectedCatastrophe.Name = "textBoxPeopleAffectedCatastrophe";
            textBoxPeopleAffectedCatastrophe.Size = new Size(220, 27);
            textBoxPeopleAffectedCatastrophe.TabIndex = 31;
            textBoxPeopleAffectedCatastrophe.KeyPress += Textbox_KeyPress;
            // 
            // textBoxAffectedAreaCatastrophe
            // 
            textBoxAffectedAreaCatastrophe.Location = new Point(314, 74);
            textBoxAffectedAreaCatastrophe.Name = "textBoxAffectedAreaCatastrophe";
            textBoxAffectedAreaCatastrophe.Size = new Size(220, 27);
            textBoxAffectedAreaCatastrophe.TabIndex = 32;
            textBoxAffectedAreaCatastrophe.KeyPress += Textbox_KeyPress;
            // 
            // printPreviewDialog1
            // 
            printPreviewDialog1.AutoScrollMargin = new Size(0, 0);
            printPreviewDialog1.AutoScrollMinSize = new Size(0, 0);
            printPreviewDialog1.ClientSize = new Size(400, 300);
            printPreviewDialog1.Enabled = true;
            printPreviewDialog1.Icon = (Icon)resources.GetObject("printPreviewDialog1.Icon");
            printPreviewDialog1.Name = "printPreviewDialog1";
            printPreviewDialog1.Visible = false;
            // 
            // panelMedical
            // 
            panelMedical.Controls.Add(textBoxAgePatient);
            panelMedical.Controls.Add(labelNamePatient);
            panelMedical.Controls.Add(textBoxNamePatient);
            panelMedical.Controls.Add(labelAgePatient);
            panelMedical.Controls.Add(labelMedicalCondition);
            panelMedical.Controls.Add(textBoxMedicalCondition);
            panelMedical.Location = new Point(49, 437);
            panelMedical.Name = "panelMedical";
            panelMedical.Size = new Size(964, 149);
            panelMedical.TabIndex = 33;
            panelMedical.Visible = false;
            // 
            // textBoxAgePatient
            // 
            textBoxAgePatient.Location = new Point(249, 64);
            textBoxAgePatient.Name = "textBoxAgePatient";
            textBoxAgePatient.Size = new Size(165, 27);
            textBoxAgePatient.TabIndex = 25;
            textBoxAgePatient.KeyPress += Textbox_KeyPress;
            // 
            // panelFire
            // 
            panelFire.Controls.Add(labelAffectedAreaFire);
            panelFire.Controls.Add(labelPeopleAffectedFire);
            panelFire.Controls.Add(textBoxAffectedAreaFire);
            panelFire.Controls.Add(textBoxPeopleAffectedFire);
            panelFire.Location = new Point(49, 601);
            panelFire.Name = "panelFire";
            panelFire.Size = new Size(721, 88);
            panelFire.TabIndex = 34;
            panelFire.Visible = false;
            // 
            // panelCatastrophe
            // 
            panelCatastrophe.Controls.Add(labelCatastropheType);
            panelCatastrophe.Controls.Add(labelAffectedAreaCatastrophe);
            panelCatastrophe.Controls.Add(labelPeopleAffectedCatastrophe);
            panelCatastrophe.Controls.Add(labelIntensityCatastrophe);
            panelCatastrophe.Controls.Add(textBoxIntensityCatastrophe);
            panelCatastrophe.Controls.Add(textBoxPeopleAffectedCatastrophe);
            panelCatastrophe.Controls.Add(textBoxAffectedAreaCatastrophe);
            panelCatastrophe.Controls.Add(textBoxCatastropheType);
            panelCatastrophe.Location = new Point(49, 716);
            panelCatastrophe.Name = "panelCatastrophe";
            panelCatastrophe.Size = new Size(721, 215);
            panelCatastrophe.TabIndex = 34;
            panelCatastrophe.Visible = false;
            // 
            // listBoxEquipment
            // 
            listBoxEquipment.FormattingEnabled = true;
            listBoxEquipment.Location = new Point(298, 262);
            listBoxEquipment.Name = "listBoxEquipment";
            listBoxEquipment.SelectionMode = SelectionMode.MultiSimple;
            listBoxEquipment.Size = new Size(165, 64);
            listBoxEquipment.TabIndex = 35;
            // 
            // notifyIcon1
            // 
            notifyIcon1.Text = "notifyIcon1";
            notifyIcon1.Visible = true;
            // 
            // buttonReturnMain
            // 
            buttonReturnMain.Location = new Point(363, 937);
            buttonReturnMain.Name = "buttonReturnMain";
            buttonReturnMain.Size = new Size(220, 29);
            buttonReturnMain.TabIndex = 36;
            buttonReturnMain.Text = "Voltar";
            buttonReturnMain.UseVisualStyleBackColor = true;
            buttonReturnMain.Click += buttonReturnMain_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox1.Image = Properties.Resources.IncidentReport;
            pictureBox1.Location = new Point(1027, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(461, 410);
            pictureBox1.TabIndex = 37;
            pictureBox1.TabStop = false;
            // 
            // CreateIncidentForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1491, 1009);
            Controls.Add(pictureBox1);
            Controls.Add(buttonReturnMain);
            Controls.Add(listBoxEquipment);
            Controls.Add(panelFire);
            Controls.Add(panelCatastrophe);
            Controls.Add(panelMedical);
            Controls.Add(label7);
            Controls.Add(comboBoxIncidentStatus);
            Controls.Add(label6);
            Controls.Add(buttonCreateIncident);
            Controls.Add(comboBoxTeam);
            Controls.Add(label5);
            Controls.Add(comboBoxIncidentType);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(comboBoxSeverity);
            Controls.Add(textBoxLocation);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBoxDescription);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CreateIncidentForm";
            Text = "Registo de Ocorrência";
            WindowState = FormWindowState.Maximized;
            panelMedical.ResumeLayout(false);
            panelMedical.PerformLayout();
            panelFire.ResumeLayout(false);
            panelFire.PerformLayout();
            panelCatastrophe.ResumeLayout(false);
            panelCatastrophe.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxDescription;
        private Label label1;
        private Label label2;
        private TextBox textBoxLocation;
        private ComboBox comboBoxSeverity;
        private Label label3;
        private Label label4;
        private ComboBox comboBoxIncidentType;
        private Label label5;
        private ComboBox comboBoxTeam;
        private Button buttonCreateIncident;
        private Label label6;
        private ComboBox comboBoxIncidentStatus;
        private Label label7;
        private Label labelNamePatient;
        private TextBox textBoxNamePatient;
        private Label labelAgePatient;
        private Label labelMedicalCondition;
        private TextBox textBoxMedicalCondition;
        private Label labelAffectedAreaFire;
        private Label labelPeopleAffectedFire;
        private TextBox textBoxAffectedAreaFire;
        private TextBox textBoxPeopleAffectedFire;
        private Label labelAffectedAreaCatastrophe;
        private Label labelCatastropheType;
        private TextBox textBoxCatastropheType;
        private Label labelIntensityCatastrophe;
        private Label labelPeopleAffectedCatastrophe;
        private TextBox textBoxIntensityCatastrophe;
        private TextBox textBoxPeopleAffectedCatastrophe;
        private TextBox textBoxAffectedAreaCatastrophe;
        private PrintPreviewDialog printPreviewDialog1;
        private Panel panelMedical;
        private Panel panelFire;
        private Panel panelCatastrophe;
        private ListBox listBoxEquipment;
        private NotifyIcon notifyIcon1;
        private Button buttonReturnMain;
        private TextBox textBoxAgePatient;
        private PictureBox pictureBox1;
    }
}