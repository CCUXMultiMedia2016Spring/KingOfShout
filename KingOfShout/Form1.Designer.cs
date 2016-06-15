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
            this.Panel_NameRegister.SuspendLayout();
            this.Panel_Menu.SuspendLayout();
            this.Panel_IPaddress.SuspendLayout();
            this.SuspendLayout();
            // 
            // Start_Button
            // 
            this.Start_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Start_Button.Font = new System.Drawing.Font("SketchFlow Print", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Start_Button.Location = new System.Drawing.Point(3, 122);
            this.Start_Button.Name = "Start_Button";
            this.Start_Button.Size = new System.Drawing.Size(200, 68);
            this.Start_Button.TabIndex = 0;
            this.Start_Button.Text = "Start";
            this.Start_Button.UseVisualStyleBackColor = true;
            this.Start_Button.Click += new System.EventHandler(this.Start_Button_Click);
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Tekton Pro Ext", 71.99999F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.Location = new System.Drawing.Point(34, 36);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(753, 118);
            this.Title.TabIndex = 1;
            this.Title.Text = "King Of Shout";
            // 
            // Label_YourName
            // 
            this.Label_YourName.AutoSize = true;
            this.Label_YourName.Font = new System.Drawing.Font("Trajan Pro", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_YourName.Location = new System.Drawing.Point(25, 11);
            this.Label_YourName.Name = "Label_YourName";
            this.Label_YourName.Size = new System.Drawing.Size(154, 27);
            this.Label_YourName.TabIndex = 2;
            this.Label_YourName.Text = "Your Name :";
            // 
            // textBox_UserName
            // 
            this.textBox_UserName.Location = new System.Drawing.Point(28, 61);
            this.textBox_UserName.MaxLength = 15;
            this.textBox_UserName.Name = "textBox_UserName";
            this.textBox_UserName.Size = new System.Drawing.Size(149, 22);
            this.textBox_UserName.TabIndex = 3;
            this.textBox_UserName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Panel_NameRegister
            // 
            this.Panel_NameRegister.Controls.Add(this.Register_Button);
            this.Panel_NameRegister.Controls.Add(this.Label_YourName);
            this.Panel_NameRegister.Controls.Add(this.textBox_UserName);
            this.Panel_NameRegister.Location = new System.Drawing.Point(78, 181);
            this.Panel_NameRegister.Name = "Panel_NameRegister";
            this.Panel_NameRegister.Size = new System.Drawing.Size(200, 193);
            this.Panel_NameRegister.TabIndex = 4;
            // 
            // Register_Button
            // 
            this.Register_Button.Font = new System.Drawing.Font("SketchFlow Print", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.Register_Button.Location = new System.Drawing.Point(3, 122);
            this.Register_Button.Name = "Register_Button";
            this.Register_Button.Size = new System.Drawing.Size(194, 68);
            this.Register_Button.TabIndex = 4;
            this.Register_Button.Text = "Register";
            this.Register_Button.UseVisualStyleBackColor = true;
            this.Register_Button.Click += new System.EventHandler(this.Register_Button_Click);
            // 
            // Panel_Menu
            // 
            this.Panel_Menu.Controls.Add(this.Start_Button);
            this.Panel_Menu.Location = new System.Drawing.Point(536, 181);
            this.Panel_Menu.Name = "Panel_Menu";
            this.Panel_Menu.Size = new System.Drawing.Size(206, 193);
            this.Panel_Menu.TabIndex = 5;
            // 
            // Panel_IPaddress
            // 
            this.Panel_IPaddress.Controls.Add(this.Label_IPalert);
            this.Panel_IPaddress.Controls.Add(this.IP_Button);
            this.Panel_IPaddress.Controls.Add(this.Label_ServerAddress);
            this.Panel_IPaddress.Controls.Add(this.textBox_IPaddress);
            this.Panel_IPaddress.Location = new System.Drawing.Point(307, 181);
            this.Panel_IPaddress.Name = "Panel_IPaddress";
            this.Panel_IPaddress.Size = new System.Drawing.Size(200, 193);
            this.Panel_IPaddress.TabIndex = 6;
            // 
            // Label_IPalert
            // 
            this.Label_IPalert.AutoSize = true;
            this.Label_IPalert.Font = new System.Drawing.Font("Tekton Pro", 9.749999F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_IPalert.ForeColor = System.Drawing.Color.Firebrick;
            this.Label_IPalert.Location = new System.Drawing.Point(65, 98);
            this.Label_IPalert.Name = "Label_IPalert";
            this.Label_IPalert.Size = new System.Drawing.Size(0, 16);
            this.Label_IPalert.TabIndex = 6;
            this.Label_IPalert.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // IP_Button
            // 
            this.IP_Button.Font = new System.Drawing.Font("SketchFlow Print", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.IP_Button.Location = new System.Drawing.Point(3, 122);
            this.IP_Button.Name = "IP_Button";
            this.IP_Button.Size = new System.Drawing.Size(194, 68);
            this.IP_Button.TabIndex = 5;
            this.IP_Button.Text = "Connect";
            this.IP_Button.UseVisualStyleBackColor = true;
            this.IP_Button.Click += new System.EventHandler(this.IP_Button_Click);
            // 
            // Label_ServerAddress
            // 
            this.Label_ServerAddress.AutoSize = true;
            this.Label_ServerAddress.Font = new System.Drawing.Font("Trajan Pro", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_ServerAddress.Location = new System.Drawing.Point(8, 11);
            this.Label_ServerAddress.Name = "Label_ServerAddress";
            this.Label_ServerAddress.Size = new System.Drawing.Size(185, 27);
            this.Label_ServerAddress.TabIndex = 2;
            this.Label_ServerAddress.Text = "ServerAddress";
            // 
            // textBox_IPaddress
            // 
            this.textBox_IPaddress.Location = new System.Drawing.Point(26, 61);
            this.textBox_IPaddress.Name = "textBox_IPaddress";
            this.textBox_IPaddress.Size = new System.Drawing.Size(149, 22);
            this.textBox_IPaddress.TabIndex = 3;
            // 
            // ConnectionWorker
            // 
            this.ConnectionWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ConnectionWorker_DoWork);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(813, 392);
            this.Controls.Add(this.Panel_IPaddress);
            this.Controls.Add(this.Panel_Menu);
            this.Controls.Add(this.Panel_NameRegister);
            this.Controls.Add(this.Title);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Panel_NameRegister.ResumeLayout(false);
            this.Panel_NameRegister.PerformLayout();
            this.Panel_Menu.ResumeLayout(false);
            this.Panel_IPaddress.ResumeLayout(false);
            this.Panel_IPaddress.PerformLayout();
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
    }
}

