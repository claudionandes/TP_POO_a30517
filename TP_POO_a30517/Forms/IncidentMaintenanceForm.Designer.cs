namespace TP_POO_a30517.Forms
{
    partial class IncidentMaintenanceForm
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
            buttonCreateIncident = new Button();
            pictureBox1 = new PictureBox();
            button1 = new Button();
            dataGridViewIncidents = new DataGridView();
            ButtonListIncidents = new Button();
            comboBoxManageIncident = new ComboBox();
            buttonUpdateIncident = new Button();
            buttonDeleteIncident = new Button();
            buttonClean = new Button();
            comboBoxIncidentStatus = new ComboBox();
            buttonFilterByStatus = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewIncidents).BeginInit();
            SuspendLayout();
            // 
            // buttonCreateIncident
            // 
            buttonCreateIncident.Location = new Point(42, 65);
            buttonCreateIncident.Name = "buttonCreateIncident";
            buttonCreateIncident.Size = new Size(94, 29);
            buttonCreateIncident.TabIndex = 0;
            buttonCreateIncident.Text = "Criar";
            buttonCreateIncident.UseVisualStyleBackColor = true;
            buttonCreateIncident.Click += buttonCreateIncident_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Incident;
            pictureBox1.Location = new Point(1343, 22);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(382, 310);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // button1
            // 
            button1.Location = new Point(42, 931);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 2;
            button1.Text = "Voltar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dataGridViewIncidents
            // 
            dataGridViewIncidents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewIncidents.Location = new Point(33, 378);
            dataGridViewIncidents.Name = "dataGridViewIncidents";
            dataGridViewIncidents.RowHeadersWidth = 51;
            dataGridViewIncidents.Size = new Size(1692, 529);
            dataGridViewIncidents.TabIndex = 3;
            // 
            // ButtonListIncidents
            // 
            ButtonListIncidents.Location = new Point(42, 250);
            ButtonListIncidents.Name = "ButtonListIncidents";
            ButtonListIncidents.Size = new Size(166, 29);
            ButtonListIncidents.TabIndex = 4;
            ButtonListIncidents.Text = "Listar Ocorrências";
            ButtonListIncidents.UseVisualStyleBackColor = true;
            ButtonListIncidents.Click += button2_Click;
            // 
            // comboBoxManageIncident
            // 
            comboBoxManageIncident.FormattingEnabled = true;
            comboBoxManageIncident.Location = new Point(226, 250);
            comboBoxManageIncident.Name = "comboBoxManageIncident";
            comboBoxManageIncident.Size = new Size(151, 28);
            comboBoxManageIncident.TabIndex = 6;
            comboBoxManageIncident.SelectedIndexChanged += comboBoxManageIncident_SelectedIndexChanged;
            // 
            // buttonUpdateIncident
            // 
            buttonUpdateIncident.Location = new Point(42, 122);
            buttonUpdateIncident.Name = "buttonUpdateIncident";
            buttonUpdateIncident.Size = new Size(94, 29);
            buttonUpdateIncident.TabIndex = 7;
            buttonUpdateIncident.Text = "Atualizar";
            buttonUpdateIncident.UseVisualStyleBackColor = true;
            buttonUpdateIncident.Click += buttonUpdateIncident_Click;
            // 
            // buttonDeleteIncident
            // 
            buttonDeleteIncident.Location = new Point(42, 178);
            buttonDeleteIncident.Name = "buttonDeleteIncident";
            buttonDeleteIncident.Size = new Size(94, 29);
            buttonDeleteIncident.TabIndex = 8;
            buttonDeleteIncident.Text = "Eliminar";
            buttonDeleteIncident.UseVisualStyleBackColor = true;
            buttonDeleteIncident.Click += buttonDeleteIncident_Click;
            // 
            // buttonClean
            // 
            buttonClean.Location = new Point(406, 276);
            buttonClean.Name = "buttonClean";
            buttonClean.Size = new Size(94, 28);
            buttonClean.TabIndex = 9;
            buttonClean.Text = "Limpar";
            buttonClean.UseVisualStyleBackColor = true;
            buttonClean.Click += buttonClean_Click;
            // 
            // comboBoxIncidentStatus
            // 
            comboBoxIncidentStatus.FormattingEnabled = true;
            comboBoxIncidentStatus.Location = new Point(226, 299);
            comboBoxIncidentStatus.Name = "comboBoxIncidentStatus";
            comboBoxIncidentStatus.Size = new Size(151, 28);
            comboBoxIncidentStatus.TabIndex = 10;
            // 
            // buttonFilterByStatus
            // 
            buttonFilterByStatus.Location = new Point(42, 299);
            buttonFilterByStatus.Name = "buttonFilterByStatus";
            buttonFilterByStatus.Size = new Size(166, 29);
            buttonFilterByStatus.TabIndex = 11;
            buttonFilterByStatus.Text = "Listar Por Estado";
            buttonFilterByStatus.UseVisualStyleBackColor = true;
            buttonFilterByStatus.Click += buttonFilterByStatus_Click;
            // 
            // IncidentMaintenanceForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1737, 988);
            Controls.Add(buttonFilterByStatus);
            Controls.Add(comboBoxIncidentStatus);
            Controls.Add(buttonClean);
            Controls.Add(buttonDeleteIncident);
            Controls.Add(buttonUpdateIncident);
            Controls.Add(comboBoxManageIncident);
            Controls.Add(ButtonListIncidents);
            Controls.Add(dataGridViewIncidents);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Controls.Add(buttonCreateIncident);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "IncidentMaintenanceForm";
            Text = "Manutenção de Ocorrências";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewIncidents).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button buttonCreateIncident;
        private PictureBox pictureBox1;
        private Button button1;
        private DataGridView dataGridViewIncidents;
        private Button ButtonListIncidents;
        private ComboBox comboBoxManageIncident;
        private Button buttonUpdateIncident;
        private Button buttonDeleteIncident;
        private Button buttonClean;
        private ComboBox comboBoxIncidentStatus;
        private Button buttonFilterByStatus;
    }
}