namespace TP_POO_a30517
{
    partial class Authenticate
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            groupBoxLogin = new GroupBox();
            button1 = new Button();
            buttonSair = new Button();
            labelPassword = new Label();
            labelUsername = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            buttonLogin = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBoxLogin.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.login;
            pictureBox1.Location = new Point(78, 36);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(423, 208);
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // groupBoxLogin
            // 
            groupBoxLogin.Anchor = AnchorStyles.Top;
            groupBoxLogin.Controls.Add(button1);
            groupBoxLogin.Controls.Add(buttonSair);
            groupBoxLogin.Controls.Add(labelPassword);
            groupBoxLogin.Controls.Add(labelUsername);
            groupBoxLogin.Controls.Add(txtUsername);
            groupBoxLogin.Controls.Add(txtPassword);
            groupBoxLogin.Controls.Add(buttonLogin);
            groupBoxLogin.Controls.Add(pictureBox1);
            groupBoxLogin.Location = new Point(19, 12);
            groupBoxLogin.Name = "groupBoxLogin";
            groupBoxLogin.Size = new Size(615, 540);
            groupBoxLogin.TabIndex = 6;
            groupBoxLogin.TabStop = false;
            groupBoxLogin.Resize += groupBox1_Resize;
            // 
            // button1
            // 
            button1.Location = new Point(305, 402);
            button1.Name = "button1";
            button1.Size = new Size(196, 47);
            button1.TabIndex = 24;
            button1.Text = "Novo Utilizador";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // buttonSair
            // 
            buttonSair.Location = new Point(78, 476);
            buttonSair.Name = "buttonSair";
            buttonSair.Size = new Size(195, 44);
            buttonSair.TabIndex = 23;
            buttonSair.Text = "Sair";
            buttonSair.UseVisualStyleBackColor = true;
            buttonSair.Click += buttonSair_Click;
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Location = new Point(127, 331);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(70, 20);
            labelPassword.TabIndex = 19;
            labelPassword.Text = "Password";
            // 
            // labelUsername
            // 
            labelUsername.AutoSize = true;
            labelUsername.Location = new Point(127, 266);
            labelUsername.Name = "labelUsername";
            labelUsername.Size = new Size(75, 20);
            labelUsername.TabIndex = 18;
            labelUsername.Text = "Username";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(258, 266);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(205, 27);
            txtUsername.TabIndex = 20;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(258, 331);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(205, 27);
            txtPassword.TabIndex = 21;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // buttonLogin
            // 
            buttonLogin.Location = new Point(78, 402);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(196, 47);
            buttonLogin.TabIndex = 22;
            buttonLogin.Text = "Login";
            buttonLogin.UseVisualStyleBackColor = true;
            buttonLogin.Click += buttonLogin_Click;
            // 
            // Authenticate
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SteelBlue;
            ClientSize = new Size(938, 623);
            Controls.Add(groupBoxLogin);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Authenticate";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBoxLogin.ResumeLayout(false);
            groupBoxLogin.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private PictureBox pictureBox1;
        private GroupBox groupBoxLogin;
        private Button buttonSair;
        private Label labelPassword;
        private Label labelUsername;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button buttonLogin;
        private Button button1;
    }
}
