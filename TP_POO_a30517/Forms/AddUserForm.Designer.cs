namespace TP_POO_a30517.Forms
{
    partial class AddUserForm
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
            labelPassword = new Label();
            labelUsername = new Label();
            btnCancel = new Button();
            btnCreateUser = new Button();
            txtPassword = new TextBox();
            txtUsername = new TextBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Location = new Point(338, 192);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(70, 20);
            labelPassword.TabIndex = 23;
            labelPassword.Text = "Password";
            // 
            // labelUsername
            // 
            labelUsername.AutoSize = true;
            labelUsername.Location = new Point(338, 127);
            labelUsername.Name = "labelUsername";
            labelUsername.Size = new Size(75, 20);
            labelUsername.TabIndex = 22;
            labelUsername.Text = "Username";
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(622, 295);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 29;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnCreateUser
            // 
            btnCreateUser.Location = new Point(338, 295);
            btnCreateUser.Name = "btnCreateUser";
            btnCreateUser.Size = new Size(94, 29);
            btnCreateUser.TabIndex = 28;
            btnCreateUser.Text = "Criar";
            btnCreateUser.UseVisualStyleBackColor = true;
            btnCreateUser.Click += btnCreateUser_Click;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(471, 192);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(245, 27);
            txtPassword.TabIndex = 27;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(471, 127);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(245, 27);
            txtUsername.TabIndex = 26;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Right;
            pictureBox1.Image = Properties.Resources._360_F_216473351_FCLq1pZQOBFrgcyPBphKvBd8Z5wjD1dI;
            pictureBox1.Location = new Point(1116, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(396, 769);
            pictureBox1.TabIndex = 30;
            pictureBox1.TabStop = false;
            // 
            // AddUserForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SteelBlue;
            ClientSize = new Size(1512, 769);
            Controls.Add(pictureBox1);
            Controls.Add(btnCancel);
            Controls.Add(btnCreateUser);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(labelPassword);
            Controls.Add(labelUsername);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddUserForm";
            Text = "Novo Utilizador";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelPassword;
        private Label labelUsername;
        private Button btnCancel;
        private Button btnCreateUser;
        private TextBox txtPassword;
        private TextBox txtUsername;
        private PictureBox pictureBox1;
    }
}