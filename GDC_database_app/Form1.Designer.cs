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
            this.btnTagging = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnAdnMenu = new System.Windows.Forms.Button();
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
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(658, 108);
            this.panel1.TabIndex = 0;
            // 
            // lblDbStatus
            // 
            this.lblDbStatus.AutoSize = true;
            this.lblDbStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDbStatus.Location = new System.Drawing.Point(452, 77);
            this.lblDbStatus.Name = "lblDbStatus";
            this.lblDbStatus.Size = new System.Drawing.Size(113, 28);
            this.lblDbStatus.TabIndex = 2;
            this.lblDbStatus.Text = "lblDbStatus";
            // 
            // lblConStatus
            // 
            this.lblConStatus.AutoSize = true;
            this.lblConStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblConStatus.Location = new System.Drawing.Point(450, 48);
            this.lblConStatus.Name = "lblConStatus";
            this.lblConStatus.Size = new System.Drawing.Size(122, 28);
            this.lblConStatus.TabIndex = 2;
            this.lblConStatus.Text = "lblConStatus";
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblWelcome.Location = new System.Drawing.Point(9, 77);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(115, 28);
            this.lblWelcome.TabIndex = 1;
            this.lblWelcome.Text = "lblWelcome";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(9, 6);
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
            this.groupBox1.Location = new System.Drawing.Point(11, 114);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(648, 158);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(17, 113);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(611, 32);
            this.button2.TabIndex = 2;
            this.button2.Text = "Location Search";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 72);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(612, 35);
            this.button1.TabIndex = 1;
            this.button1.Text = "Advance Search";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnQuickSearch
            // 
            this.btnQuickSearch.Location = new System.Drawing.Point(16, 30);
            this.btnQuickSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnQuickSearch.Name = "btnQuickSearch";
            this.btnQuickSearch.Size = new System.Drawing.Size(612, 36);
            this.btnQuickSearch.TabIndex = 0;
            this.btnQuickSearch.Text = "Quick Search";
            this.btnQuickSearch.UseVisualStyleBackColor = true;
            this.btnQuickSearch.Click += new System.EventHandler(this.btnQuickSearch_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnTagging);
            this.groupBox2.Controls.Add(this.btnLogin);
            this.groupBox2.Controls.Add(this.btnAdnMenu);
            this.groupBox2.Location = new System.Drawing.Point(11, 277);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(649, 184);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Database Adminstration";
            // 
            // btnTagging
            // 
            this.btnTagging.Location = new System.Drawing.Point(17, 124);
            this.btnTagging.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTagging.Name = "btnTagging";
            this.btnTagging.Size = new System.Drawing.Size(611, 34);
            this.btnTagging.TabIndex = 2;
            this.btnTagging.Text = "Tagging";
            this.btnTagging.UseVisualStyleBackColor = true;
            this.btnTagging.Click += new System.EventHandler(this.btnTagging_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(16, 78);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(611, 34);
            this.btnLogin.TabIndex = 1;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnAdnMenu
            // 
            this.btnAdnMenu.Location = new System.Drawing.Point(17, 34);
            this.btnAdnMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAdnMenu.Name = "btnAdnMenu";
            this.btnAdnMenu.Size = new System.Drawing.Size(610, 34);
            this.btnAdnMenu.TabIndex = 0;
            this.btnAdnMenu.Text = "Manage";
            this.btnAdnMenu.UseVisualStyleBackColor = true;
            this.btnAdnMenu.Click += new System.EventHandler(this.btnAdnMenu_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnManCon);
            this.groupBox3.Location = new System.Drawing.Point(11, 469);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(648, 85);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Database Migration";
            // 
            // btnManCon
            // 
            this.btnManCon.Location = new System.Drawing.Point(17, 33);
            this.btnManCon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnManCon.Name = "btnManCon";
            this.btnManCon.Size = new System.Drawing.Size(611, 35);
            this.btnManCon.TabIndex = 0;
            this.btnManCon.Text = "Manage Connection";
            this.btnManCon.UseVisualStyleBackColor = true;
            this.btnManCon.Click += new System.EventHandler(this.btnManCon_Click);
            // 
            // btnContact
            // 
            this.btnContact.Location = new System.Drawing.Point(27, 598);
            this.btnContact.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnContact.Name = "btnContact";
            this.btnContact.Size = new System.Drawing.Size(159, 35);
            this.btnContact.TabIndex = 5;
            this.btnContact.Text = "Contact Me";
            this.btnContact.UseVisualStyleBackColor = true;
            this.btnContact.Click += new System.EventHandler(this.btnContact_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(260, 597);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(149, 35);
            this.button3.TabIndex = 6;
            this.button3.Text = "About this app";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // btnMainExit
            // 
            this.btnMainExit.Location = new System.Drawing.Point(483, 596);
            this.btnMainExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMainExit.Name = "btnMainExit";
            this.btnMainExit.Size = new System.Drawing.Size(154, 35);
            this.btnMainExit.TabIndex = 7;
            this.btnMainExit.Text = "Exit";
            this.btnMainExit.UseVisualStyleBackColor = true;
            this.btnMainExit.Click += new System.EventHandler(this.btnMainExit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 656);
            this.Controls.Add(this.btnMainExit);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnContact);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
        private System.Windows.Forms.Button btnTagging;
    }
}

