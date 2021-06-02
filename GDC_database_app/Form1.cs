using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using static GDC_database_app.ConString;

namespace GDC_database_app
{
    public partial class Form1 : Form
    {

        public Form1(int user_type = 0, string user_name = "Guest", int loggedin = 0)
        {
            InitializeComponent();
            ConnectCheck();
            usr_type = user_type;
            usr_name = user_name;
            loggedin1 = loggedin;
            Usercheck(usr_type);



        }

        public int usr_type;
        public string usr_name;
        public int loggedin1;


        public void Usercheck(int usr_type)
        {
            if (usr_type == 0)
            {
                lblWelcome.Text = "Welcome Guest";
            }          
            if(usr_type == 1)
            {
                lblWelcome.Text = "Welcome User " + usr_name;
                btnLogin.Text = "Logout";
            }
            if (usr_type == 2)
            {
                lblWelcome.Text = "Welcome Adminstrator " + usr_name;
                btnLogin.Text = "Logout";
            }
            if (usr_type == 3)
            {
                lblWelcome.Text = "Welcome Super Adminstrator " + usr_name;
                btnLogin.Text = "Logout";
            }
        }


        private void ConnectCheck()
        {
            string constring = ConString.GetConString();
            SqlConnection SqlCon = new SqlConnection(constring);
            SqlCommand sqlcmd;
            SqlDataReader dataReader;
            String sql = "";
            try
            {
                SqlCon.Open();
                lblConStatus.Text = "Connection Establish";
            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.ToString());
                lblConStatus.Text = "Connection Not Establish";
                lblDbStatus.Text = "Database Unknown";
            }

            try
            {
                sql = "SELECT TOP 1 Job_Job_No FROM tbl_job";
                sqlcmd = new SqlCommand(sql, SqlCon);
                dataReader = sqlcmd.ExecuteReader();
                if (dataReader.HasRows)
                {
                    lblDbStatus.Text = "Database Online";
                    SqlCon.Close();
                    dataReader.Close();
                }

                else
                {
                    lblDbStatus.Text = "Database Offline";
                }
                
            }
            catch
            {
                lblDbStatus.Text = "Error Occurred";
            }


        }

        private void btnQuickSearch_Click(object sender, EventArgs e)
        {
            Form formQS = new QuickSearch();
            formQS.Show();         
        }

        private void btnManCon_Click(object sender, EventArgs e)
        {


            Form FormDM = new DataMigrateExcel();
            FormDM.Show();
        }

        private void btnMainExit_Click(object sender, EventArgs e)
        {
            
            this.Close();
            try
            {
                Application.Exit();
                
            }
            catch(Exception ex1)
            {
               Environment.Exit(1);
                MessageBox.Show(ex1.ToString());
            }
        }

        private void btnAdnMenu_Click(object sender, EventArgs e)
        {
            Form FormAM = new AdminstrationPanel();
            FormAM.Show();
        }

        private void btnContact_Click(object sender, EventArgs e)
        {

        }

        private void btnTagging_Click(object sender, EventArgs e)
        {
            Form FormTg = new Tagging();
            FormTg.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(loggedin1 == 0) { 
            Form FormLogin = new LoginForm();
            FormLogin.Show();
            this.Close();
                }
            if(loggedin1 == 1)
            {
                Form FormLogin = new LoginForm();
                //btnLogin.Text = "Login";
                this.Close();
                FormLogin.Show();
            }
        }


        private void btnAdvanceSearch_Click(object sender, EventArgs e)
        {
            Form FormAS = new AdvanceSearch();
            FormAS.Show();

        }
    }



    
}
