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
using static GDC_database_app.ConString;

namespace GDC_database_app
{


    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            ConnectCheck();
            //('Elmertest','password1','Administrator-1')
        }

        private SqlConnection sqlConn;
        
        public string username = "Guest";
        public int role = 0;
        public string rolename = "Guest";
        public int logined = 0;

        private void ConnectCheck()
        {
            string constring = ConString.GetConString();
            sqlConn = new SqlConnection(constring);

            SqlCommand sqlcmd;
            SqlDataReader dataReader;
            String sql = "";
            try
            {
                sqlConn.Open();
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
                sqlcmd = new SqlCommand(sql, sqlConn);
                dataReader = sqlcmd.ExecuteReader();
                while (dataReader.Read())
                {
                    if(dataReader[0].ToString() != null) { 
                    lblStatus.Text = "";
                    lblDbStatus.Text = "Database Online";
                        }
                    
                }
                dataReader.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                lblDbStatus.Text = "Error Occurred";
            }


        }

        private int UserAuthenticate()
        {
            try 
            {
                SqlDataReader sqlReader;
                SqlCommand sqlCmd = new SqlCommand("[dbo].[sp_userauth]",sqlConn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                if(txtBoxPassword.TextLength > 0 && txtBoxUsername.TextLength > 0 )
                { 
                    sqlCmd.Parameters.AddWithValue("@username", SqlDbType.VarChar).Value = txtBoxUsername.Text;
                    sqlCmd.Parameters.AddWithValue("@userpass", SqlDbType.VarChar).Value = txtBoxPassword.Text;
                    sqlReader = sqlCmd.ExecuteReader();
                    if (sqlReader.HasRows == true)
                    {
                        while (sqlReader.Read())
                        {

                            if (sqlReader["username"].ToString().Equals(txtBoxUsername.Text) == true && sqlReader[0].ToString().Equals(txtBoxUsername.Text) == true)
                            {
                                lblStatus.Text = "Login Successful, Hello " + sqlReader[0];
                                username = sqlReader["username"].ToString();
                                rolename = sqlReader["Role"].ToString();
                                sqlReader.Close();
                                
                                return 1;
                            }
                            else
                            {
                                lblStatus.Text = "Username or password is not recognised";
                                sqlReader.Close();
                                return 0;
                            }
                        }
                    }
                    else 
                    {
                        lblStatus.Text = "Username or password is not recognised";
                        sqlReader.Close();
                        return 0;
                    }
                }
                else
                {
                    lblStatus.Text = "Fields are empty, please enter credentials";
                    return 0;
                }
                
            }
            catch (Exception ex1)
            {
                lblStatus.Text = "Username or password is not recognised";
                MessageBox.Show(ex1.ToString());
                return 0;
            }
            return 0;
        }


        private int rolehandler(string rolename)
        {
            if(rolename == "Guest")
            {
                return 0;
            }else if(rolename == "User")
            {
                return 1;
            }
            else if (rolename == "Administrator")
            {
                return 2;
            }
            else if (rolename == "Administrator-1")
            {
                return 3;
            }
            return 0;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            loginhandler();
        }



        private void loginhandler()
        {
            if (logined == 0)
            {
                logined = UserAuthenticate();
            }
            if (logined == 1)
            {

                Form1 form1 = new Form1(rolehandler(rolename), username, 1);

                if (form1 == null)
                {
                    form1.Show();
                }
                else
                {
                    form1.Visible = true;
                }
                this.Hide();
            }
        }

        private void txtBoxPassword_Enter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { loginhandler(); }
        }

        private void txtBoxUsername_Enter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { loginhandler(); }
        }
    }
}
