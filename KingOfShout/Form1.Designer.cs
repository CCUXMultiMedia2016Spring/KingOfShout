namespace KingOfShout
{
    partial class Form1
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
            this.Start_Button = new System.Windows.Forms.Button();
            this.Title = new System.Windows.Forms.Label();
            this.Label_YourName = new System.Windows.Forms.Label();
            this.textBox_UserName = new System.Windows.Forms.TextBox();
            this.Panel_NameRegister = new System.Windows.Forms.Panel();
            this.Register_Button = new System.Windows.Forms.Button();
            this.Panel_Menu = new System.Windows.Forms.Panel();
            this.Panel_IPaddress = new System.Windows.Forms.Panel();
            this.Label_IPalert = new System.Windows.Forms.Label();
            this.IP_Button = new System.Windows.Forms.Button();
            this.Label_ServerAddress = new System.Windows.Forms.Label();
            this.textBox_IPaddress = new System.Windows.Forms.TextBox();
            this.ConnectionWorker = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.Button_attack_debug = new System.Windows.Forms.Panel();
            this.Button_Attack = new System.Windows.Forms.Button();
            this.Textbox_debug = new System.Windows.Forms.TextBox();
            this.Panel_NameRegister.SuspendLayout();
            this.Panel_Menu.SuspendLayout();
            this.Panel_IPaddress.SuspendLayout();
            this.Button_attack_debug.SuspendLayout();
            this.SuspendLayout();
            // 
            // Start_Button
            // 
            this.Start_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Start_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Start_Button.Location = new System.Drawing.Point(4, 152);
            this.Start_Button.Margin = new System.Windows.Forms.Padding(4);
            this.Start_Button.Name = "Start_Button";
            this.Start_Button.Size = new System.Drawing.Size(267, 85);
            this.Start_Button.TabIndex = 0;
            this.Start_Button.Text = "Start";
            this.Start_Button.UseVisualStyleBackColor = true;
            this.Start_Button.Click += new System.EventHandler(this.Start_Button_Click);
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 71.99999F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.Location = new System.Drawing.Point(45, 45);
            this.Title.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(815, 135);
            this.Title.TabIndex = 1;
            this.Title.Text = "King Of Shout";
            // 
            // Label_YourName
            // 
            this.Label_YourName.AutoSize = true;
            this.Label_YourName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_YourName.Location = new System.Drawing.Point(33, 14);
            this.Label_YourName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_YourName.Name = "Label_YourName";
            this.Label_YourName.Size = new System.Drawing.Size(176, 31);
            this.Label_YourName.TabIndex = 2;
            this.Label_YourName.Text = "Your Name :";
            // 
            // textBox_UserName
            // 
            this.textBox_UserName.Location = new System.Drawing.Point(37, 76);
            this.textBox_UserName.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_UserName.MaxLength = 15;
            this.textBox_UserName.Name = "textBox_UserName";
            this.textBox_UserName.Size = new System.Drawing.Size(197, 25);
            this.textBox_UserName.TabIndex = 3;
            this.textBox_UserName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Panel_NameRegister
            // 
            this.Panel_NameRegister.Controls.Add(this.Register_Button);
            this.Panel_NameRegister.Controls.Add(this.Label_YourName);
            this.Panel_NameRegister.Controls.Add(this.textBox_UserName);
            this.Panel_NameRegister.Location = new System.Drawing.Point(104, 226);
            this.Panel_NameRegister.Margin = new System.Windows.Forms.Padding(4);
            this.Panel_NameRegister.Name = "Panel_NameRegister";
            this.Panel_NameRegister.Size = new System.Drawing.Size(267, 241);
            this.Panel_NameRegister.TabIndex = 4;
            // 
            // Register_Button
            // 
            this.Register_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.Register_Button.Location = new System.Drawing.Point(4, 152);
            this.Register_Button.Margin = new System.Windows.Forms.Padding(4);
            this.Register_Button.Name = "Register_Button";
            this.Register_Button.Size = new System.Drawing.Size(259, 85);
            this.Register_Button.TabIndex = 4;
            this.Register_Button.Text = "Register";
            this.Register_Button.UseVisualStyleBackColor = true;
            this.Register_Button.Click += new System.EventHandler(this.Register_Button_Click);
            // 
            // Panel_Menu
            // 
            this.Panel_Menu.Controls.Add(this.Start_Button);
            this.Panel_Menu.Location = new System.Drawing.Point(715, 226);
            this.Panel_Menu.Margin = new System.Windows.Forms.Padding(4);
            this.Panel_Menu.Name = "Panel_Menu";
            this.Panel_Menu.Size = new System.Drawing.Size(275, 241);
            this.Panel_Menu.TabIndex = 5;
            // 
            // Panel_IPaddress
            // 
            this.Panel_IPaddress.Controls.Add(this.Label_IPalert);
            this.Panel_IPaddress.Controls.Add(this.IP_Button);
            this.Panel_IPaddress.Controls.Add(this.Label_ServerAddress);
            this.Panel_IPaddress.Controls.Add(this.textBox_IPaddress);
            this.Panel_IPaddress.Location = new System.Drawing.Point(409, 226);
            this.Panel_IPaddress.Margin = new System.Windows.Forms.Padding(4);
            this.Panel_IPaddress.Name = "Panel_IPaddress";
            this.Panel_IPaddress.Size = new System.Drawing.Size(267, 241);
            this.Panel_IPaddress.TabIndex = 6;
            // 
            // Label_IPalert
            // 
            this.Label_IPalert.AutoSize = true;
            this.Label_IPalert.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_IPalert.ForeColor = System.Drawing.Color.Firebrick;
            this.Label_IPalert.Location = new System.Drawing.Point(87, 122);
            this.Label_IPalert.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_IPalert.Name = "Label_IPalert";
            this.Label_IPalert.Size = new System.Drawing.Size(0, 20);
            this.Label_IPalert.TabIndex = 6;
            this.Label_IPalert.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // IP_Button
            // 
            this.IP_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.IP_Button.Location = new System.Drawing.Point(4, 152);
            this.IP_Button.Margin = new System.Windows.Forms.Padding(4);
            this.IP_Button.Name = "IP_Button";
            this.IP_Button.Size = new System.Drawing.Size(259, 85);
            this.IP_Button.TabIndex = 5;
            this.IP_Button.Text = "Connect";
            this.IP_Button.UseVisualStyleBackColor = true;
            this.IP_Button.Click += new System.EventHandler(this.IP_Button_Click);
            // 
            // Label_ServerAddress
            // 
            this.Label_ServerAddress.AutoSize = true;
            this.Label_ServerAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_ServerAddress.Location = new System.Drawing.Point(11, 14);
            this.Label_ServerAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_ServerAddress.Name = "Label_ServerAddress";
            this.Label_ServerAddress.Size = new System.Drawing.Size(207, 31);
            this.Label_ServerAddress.TabIndex = 2;
            this.Label_ServerAddress.Text = "ServerAddress";
            // 
            // textBox_IPaddress
            // 
            this.textBox_IPaddress.Location = new System.Drawing.Point(35, 76);
            this.textBox_IPaddress.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_IPaddress.Name = "textBox_IPaddress";
            this.textBox_IPaddress.Size = new System.Drawing.Size(197, 25);
            this.textBox_IPaddress.TabIndex = 3;
            // 
            // ConnectionWorker
            // 
            this.ConnectionWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ConnectionWorker_DoWork);
            // 
            // Button_attack_debug
            // 
            this.Button_attack_debug.Controls.Add(this.Button_Attack);
            this.Button_attack_debug.Location = new System.Drawing.Point(296, 171);
            this.Button_attack_debug.Name = "Button_attack_debug";
            this.Button_attack_debug.Size = new System.Drawing.Size(200, 100);
            this.Button_attack_debug.TabIndex = 7;
            // 
            // Button_Attack
            // 
            this.Button_Attack.Location = new System.Drawing.Point(15, 31);
            this.Button_Attack.Name = "Button_Attack";
            this.Button_Attack.Size = new System.Drawing.Size(141, 40);
            this.Button_Attack.TabIndex = 0;
            this.Button_Attack.Text = "Attack";
            this.Button_Attack.UseVisualStyleBackColor = true;
            this.Button_Attack.Click += new System.EventHandler(this.Button_Attack_Click);
            // 
            // Textbox_debug
            // 
            this.Textbox_debug.Location = new System.Drawing.Point(891, 171);
            this.Textbox_debug.Name = "Textbox_debug";
            this.Textbox_debug.Size = new System.Drawing.Size(100, 25);
            this.Textbox_debug.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(1084, 490);
            this.Controls.Add(this.Textbox_debug);
            this.Controls.Add(this.Button_attack_debug);
            this.Controls.Add(this.Panel_IPaddress);
            this.Controls.Add(this.Panel_Menu);
            this.Controls.Add(this.Panel_NameRegister);
            this.Controls.Add(this.Title);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Panel_NameRegister.ResumeLayout(false);
            this.Panel_NameRegister.PerformLayout();
            this.Panel_Menu.ResumeLayout(false);
            this.Panel_IPaddress.ResumeLayout(false);
            this.Panel_IPaddress.PerformLayout();
            this.Button_attack_debug.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Start_Button;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Label Label_YourName;
        private System.Windows.Forms.TextBox textBox_UserName;
        private System.Windows.Forms.Panel Panel_NameRegister;
        private System.Windows.Forms.Panel Panel_Menu;
        private System.Windows.Forms.Panel Panel_IPaddress;
        private System.Windows.Forms.Label Label_ServerAddress;
        private System.Windows.Forms.TextBox textBox_IPaddress;
        private System.Windows.Forms.Button Register_Button;
        private System.Windows.Forms.Button IP_Button;
        private System.Windows.Forms.Label Label_IPalert;
        private System.ComponentModel.BackgroundWorker ConnectionWorker;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel Button_attack_debug;
        private System.Windows.Forms.Button Button_Attack;
        private System.Windows.Forms.TextBox Textbox_debug;
    }
}

