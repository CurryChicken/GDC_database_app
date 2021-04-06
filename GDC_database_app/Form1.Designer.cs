namespace GDC_database_app
{
    partial class Form1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblDbStatus = new System.Windows.Forms.Label();
            this.lblConStatus = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnQuickSearch = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAdnMenu = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnManCon = new System.Windows.Forms.Button();
            this.btnContact = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnMainExit = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblDbStatus);
            this.panel1.Controls.Add(this.lblConStatus);
            this.panel1.Controls.Add(this.lblWelcome);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(661, 135);
            this.panel1.TabIndex = 0;
            // 
            // lblDbStatus
            // 
            this.lblDbStatus.AutoSize = true;
            this.lblDbStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDbStatus.Location = new System.Drawing.Point(530, 96);
            this.lblDbStatus.Name = "lblDbStatus";
            this.lblDbStatus.Size = new System.Drawing.Size(113, 28);
            this.lblDbStatus.TabIndex = 2;
            this.lblDbStatus.Text = "lblDbStatus";
            // 
            // lblConStatus
            // 
            this.lblConStatus.AutoSize = true;
            this.lblConStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblConStatus.Location = new System.Drawing.Point(522, 60);
            this.lblConStatus.Name = "lblConStatus";
            this.lblConStatus.Size = new System.Drawing.Size(122, 28);
            this.lblConStatus.TabIndex = 2;
            this.lblConStatus.Text = "lblConStatus";
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblWelcome.Location = new System.Drawing.Point(10, 96);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(115, 28);
            this.lblWelcome.TabIndex = 1;
            this.lblWelcome.Text = "lblWelcome";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(10, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "GDC Jobs Database";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btnQuickSearch);
            this.groupBox1.Location = new System.Drawing.Point(12, 142);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(633, 198);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(19, 139);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(592, 36);
            this.button2.TabIndex = 2;
            this.button2.Text = "Location Search";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(18, 90);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(593, 33);
            this.button1.TabIndex = 1;
            this.button1.Text = "Advance Search";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnQuickSearch
            // 
            this.btnQuickSearch.Location = new System.Drawing.Point(18, 40);
            this.btnQuickSearch.Name = "btnQuickSearch";
            this.btnQuickSearch.Size = new System.Drawing.Size(593, 34);
            this.btnQuickSearch.TabIndex = 0;
            this.btnQuickSearch.Text = "Quick Search";
            this.btnQuickSearch.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnLogin);
            this.groupBox2.Controls.Add(this.btnAdnMenu);
            this.groupBox2.Location = new System.Drawing.Point(12, 346);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(634, 173);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Database Adminstration";
            // 
            // btnAdnMenu
            // 
            this.btnAdnMenu.Enabled = false;
            this.btnAdnMenu.Location = new System.Drawing.Point(19, 40);
            this.btnAdnMenu.Name = "btnAdnMenu";
            this.btnAdnMenu.Size = new System.Drawing.Size(591, 43);
            this.btnAdnMenu.TabIndex = 0;
            this.btnAdnMenu.Text = "Manage";
            this.btnAdnMenu.UseVisualStyleBackColor = true;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(18, 104);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(592, 42);
            this.btnLogin.TabIndex = 1;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnManCon);
            this.groupBox3.Location = new System.Drawing.Point(12, 525);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(633, 106);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Database Migration";
            // 
            // btnManCon
            // 
            this.btnManCon.Location = new System.Drawing.Point(19, 41);
            this.btnManCon.Name = "btnManCon";
            this.btnManCon.Size = new System.Drawing.Size(592, 44);
            this.btnManCon.TabIndex = 0;
            this.btnManCon.Text = "Manage Connection";
            this.btnManCon.UseVisualStyleBackColor = true;
            // 
            // btnContact
            // 
            this.btnContact.Location = new System.Drawing.Point(28, 660);
            this.btnContact.Name = "btnContact";
            this.btnContact.Size = new System.Drawing.Size(144, 44);
            this.btnContact.TabIndex = 5;
            this.btnContact.Text = "Contact Me";
            this.btnContact.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(234, 659);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(171, 44);
            this.button3.TabIndex = 6;
            this.button3.Text = "About this app";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // btnMainExit
            // 
            this.btnMainExit.Location = new System.Drawing.Point(460, 658);
            this.btnMainExit.Name = "btnMainExit";
            this.btnMainExit.Size = new System.Drawing.Size(162, 44);
            this.btnMainExit.TabIndex = 7;
            this.btnMainExit.Text = "Exit";
            this.btnMainExit.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 726);
            this.Controls.Add(this.btnMainExit);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnContact);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "GDC Database";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblDbStatus;
        private System.Windows.Forms.Label lblConStatus;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnQuickSearch;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAdnMenu;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnManCon;
        private System.Windows.Forms.Button btnContact;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnMainExit;
    }
}

