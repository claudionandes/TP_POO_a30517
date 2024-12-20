namespace TP_POO_a30517.Forms
{
    partial class CreateTeamForm
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
            textBoxTeamName = new TextBox();
            label1 = new Label();
            labelTypeTeam = new Label();
            comboBoxTeamType = new ComboBox();
            comboBoxTeamStatus = new ComboBox();
            labelStatusTeam = new Label();
            buttonCreateTeam = new Button();
            buttonClose = new Button();
            SuspendLayout();
            // 
            // textBoxTeamName
            // 
            textBoxTeamName.Location = new Point(207, 94);
            textBoxTeamName.Name = "textBoxTeamName";
            textBoxTeamName.Size = new Size(459, 27);
            textBoxTeamName.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(50, 94);
            label1.Name = "label1";
            label1.Size = new Size(121, 20);
            label1.TabIndex = 1;
            label1.Text = "Nome da Equipa";
            // 
            // labelTypeTeam
            // 
            labelTypeTeam.AutoSize = true;
            labelTypeTeam.Location = new Point(50, 176);
            labelTypeTeam.Name = "labelTypeTeam";
            labelTypeTeam.Size = new Size(110, 20);
            labelTypeTeam.TabIndex = 2;
            labelTypeTeam.Text = "Tipo de Equipa";
            // 
            // comboBoxTeamType
            // 
            comboBoxTeamType.FormattingEnabled = true;
            comboBoxTeamType.Location = new Point(207, 176);
            comboBoxTeamType.Name = "comboBoxTeamType";
            comboBoxTeamType.Size = new Size(142, 28);
            comboBoxTeamType.TabIndex = 3;
            // 
            // comboBoxTeamStatus
            // 
            comboBoxTeamStatus.FormattingEnabled = true;
            comboBoxTeamStatus.Location = new Point(207, 254);
            comboBoxTeamStatus.Name = "comboBoxTeamStatus";
            comboBoxTeamStatus.Size = new Size(142, 28);
            comboBoxTeamStatus.TabIndex = 5;
            // 
            // labelStatusTeam
            // 
            labelStatusTeam.AutoSize = true;
            labelStatusTeam.Location = new Point(50, 254);
            labelStatusTeam.Name = "labelStatusTeam";
            labelStatusTeam.Size = new Size(125, 20);
            labelStatusTeam.TabIndex = 4;
            labelStatusTeam.Text = "Estado da Equipa";
            // 
            // buttonCreateTeam
            // 
            buttonCreateTeam.Location = new Point(50, 336);
            buttonCreateTeam.Name = "buttonCreateTeam";
            buttonCreateTeam.Size = new Size(121, 29);
            buttonCreateTeam.TabIndex = 6;
            buttonCreateTeam.Text = "Criar";
            buttonCreateTeam.UseVisualStyleBackColor = true;
            buttonCreateTeam.Click += buttonCreateTeam_Click;
            // 
            // buttonClose
            // 
            buttonClose.Location = new Point(207, 336);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(121, 29);
            buttonClose.TabIndex = 7;
            buttonClose.Text = "Voltar";
            buttonClose.UseVisualStyleBackColor = true;
            buttonClose.Click += buttonClose_Click;
            // 
            // CreateTeamForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1453, 1012);
            Controls.Add(buttonClose);
            Controls.Add(buttonCreateTeam);
            Controls.Add(comboBoxTeamStatus);
            Controls.Add(labelStatusTeam);
            Controls.Add(comboBoxTeamType);
            Controls.Add(labelTypeTeam);
            Controls.Add(label1);
            Controls.Add(textBoxTeamName);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CreateTeamForm";
            Text = "Criação de Equipa";
            WindowState = FormWindowState.Maximized;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxTeamName;
        private Label label1;
        private Label labelTypeTeam;
        private ComboBox comboBoxTeamType;
        private ComboBox comboBoxTeamStatus;
        private Label labelStatusTeam;
        private Button buttonCreateTeam;
        private Button buttonClose;
    }
}