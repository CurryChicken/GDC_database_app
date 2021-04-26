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

        public Form1()
        {
            InitializeComponent();
            ConnectCheck();
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
            Form FormDM = new DataMigration();
            FormDM.Show();
        }

        private void btnMainExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }



    
}
