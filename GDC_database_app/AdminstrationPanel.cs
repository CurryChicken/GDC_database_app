using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GDC_database_app
{
    public partial class AdminstrationPanel : Form
    {
        public AdminstrationPanel()
        {
            InitializeComponent();
            establishCon();
            fillcombobox();
        }

        private SqlConnection sqlConn;
        private SqlDataAdapter sqlDap;
        
       
        private void establishCon()
        {
            sqlConn = new SqlConnection(ConString.GetConString());
            sqlConn.Open();
            lblStatus.Text = "Connection Establish";
        }

        private void fillcombobox()
        {
            try
            {
                SqlCommand sqlCmdview1 = new SqlCommand("Select * from V_tableview", sqlConn);
                SqlDataReader sqlReader1 = sqlCmdview1.ExecuteReader();
                while (sqlReader1.Read())
                {
                    comboBoxTable.Items.Add(sqlReader1[0].ToString());
                }
                sqlReader1.Close();
            }
            catch(Exception ex1)
            {
                MessageBox.Show(ex1.ToString());
            }

        }

        private void clearalltextbox()
        {
            textBox1.Clear();textBox2.Clear();comboBox2.SelectedIndex = -1;textBox4.Clear();textBox5.Clear();comboBox1.SelectedIndex = -1; 
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int address = 0;
                int rowindex = e.RowIndex;
                DataGridViewRow row = dataGridView1.Rows[rowindex];
                string selectedno = row.Cells[address].Value.ToString();
                textBoxID.Text = selectedno;
                Searchidtofill(rowindex);
            }
        }

        private void Searchidtofill(int rowint)
        {
            if (comboBoxTable.Text != "tbl_job" && comboBoxTable.Text != "tbl_client" && textBoxID.Text != null)
            {
                DataGridViewRow row = dataGridView1.Rows[rowint];
                
                if (comboBoxTable.Text == "tbl_job_file")
                {
                    textBox1.Text = row.Cells[1].Value.ToString();
                    textBox2.Text = row.Cells[2].Value.ToString();
                }

                if (comboBoxTable.Text == "tbl_job_tags")
                {
                    textBox1.Text = row.Cells[1].Value.ToString();
                    textBox2.Text = row.Cells[2].Value.ToString();
                    comboBox1.Text = row.Cells[3].Value.ToString();
                }

                if (comboBoxTable.Text == "tbl_tags")
                {
                    textBox1.Text = row.Cells[1].Value.ToString();
                    textBox2.Text = row.Cells[2].Value.ToString();
                }

                if (comboBoxTable.Text == "tbl_user")
                {
                    textBox1.Text = row.Cells[1].Value.ToString();
                    textBox2.Text = row.Cells[2].Value.ToString();
                    comboBox1.Text = row.Cells[3].Value.ToString();


                }



            }
        }


        private void filldatagrid()
        {
            
                string sql = "SELECT * FROM " + comboBoxTable.Text;
                SqlCommand sqlCmd = new SqlCommand(sql, sqlConn);
                try
                {
                    DataSet ds1 = new DataSet();
                    sqlDap = new SqlDataAdapter(sqlCmd);
                    sqlDap.Fill(ds1);               
                    dataGridView1.DataSource = ds1.Tables[0];
                    int rows = dataGridView1.RowCount;
                    lblStatus.Text = rows + " Rows Returned";
                    prompt_change_table();
                
                }
                catch (Exception ex1)
                {
                    MessageBox.Show(ex1.ToString());
                }

        
            if (comboBoxTable.Text == "tbl_job")
         
            {
                lblStatus.Text = "tbl_job is editted in WorkflowMax";
            }

            if (comboBoxTable.Text == "tbl_client")
            {
                lblStatus.Text = "edit tbl_client on database";
            }
       


        }

        private void prompt_change_table()
        {
            if(tabControl1.SelectedIndex == 0) //on create of table other than jobs table
            {
                textBoxID2.Text = "Auto Generated";
                textBoxID2.Enabled = false;
                prompt_control_handler();
                
            }
            else
            {
                textBoxID2.Enabled = true;
                prompt_control_handler();
            }

          
        }

        private void prompt_control_handler()
        {
            string name = comboBoxTable.Text;
            int len = dataGridView1.Columns.Count;
            if(name == "tbl_client")
            {
                lbltitle3.Text = lbltitle6.Text = "Not in use";
                lbltitle2.Text = lbltitle4.Text = "Not in use";
                lbltitle1.Text = lbltitle5.Text = "Not in use";
                clearalltextbox();
            }
            if(name == "tbl_job_file")
            {
                lbltitle1.Text = lbltitle5.Text = "fileaddress";
                lbltitle2.Text = lbltitle4.Text = "jobno";
                lbltitle3.Text = "Not in use";
                clearalltextbox();
            }
            if(name == "tbl_job_tags")
            {
                lbltitle1.Text = lbltitle5.Text = "job_job_no";
                lbltitle2.Text = lbltitle4.Text = "Not in use";
                lbltitle3.Text = lbltitle6.Text = "Tag Name";
                comboBox2.Items.Clear();
                comboBox2.ResetText();
                comboBox1.Items.Clear();
                comboBox1.ResetText();
                SqlCommand sqlCmdview1 = new SqlCommand("Select Distinct tags from tbl_tags", sqlConn);
                SqlDataReader sqlReader1 = sqlCmdview1.ExecuteReader();
                while (sqlReader1.Read())
                {
                    comboBox1.Items.Add(sqlReader1[0].ToString());
                    comboBox2.Items.Add(sqlReader1[0].ToString());

                }
                sqlReader1.Close();
                clearalltextbox();
            }
            if(name == "tbl_tags")
            {
                lbltitle1.Text = lbltitle5.Text = "tags";
                lbltitle2.Text = lbltitle4.Text = "description";
                lbltitle3.Text = lbltitle6.Text = "Not in use";
                clearalltextbox();
            }
            if(name == "tbl_user")
            {
                lbltitle1.Text = lbltitle5.Text = "username";
                lbltitle2.Text = lbltitle4.Text = "password";
                lbltitle3.Text = lbltitle6.Text = "Role";
                comboBox2.Items.Clear();
                comboBox2.ResetText();
                comboBox1.Items.Clear();
                comboBox1.ResetText();
                SqlCommand sqlCmdview1 = new SqlCommand("Select Distinct Role from tbl_user", sqlConn);
                SqlDataReader sqlReader1 = sqlCmdview1.ExecuteReader();
                while (sqlReader1.Read())
                {
                    comboBox1.Items.Add(sqlReader1[0].ToString());

                    comboBox2.Items.Add(sqlReader1[0].ToString());
                }
                sqlReader1.Close();
                clearalltextbox();
            }
        }

        private void prompt_control_create_handler()
        {
            string name = comboBoxTable.Text;
            string sp_inserts = "";
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;

            if (name == "tbl_job_file")
            {
                sp_inserts = "[dbo].[sp_insert_into_tbl_job_file]";
                sqlCmd.Parameters.AddWithValue("@fileaddress", SqlDbType.VarChar).Value = textBox5.Text;
                sqlCmd.Parameters.AddWithValue("@jobno", SqlDbType.VarChar).Value = textBox4.Text;
                
            }
            if (name == "tbl_job_tags")
            {
                sp_inserts = "[dbo].[sp_insert_into_tbl_job_tags]";
                sqlCmd.Parameters.AddWithValue("@jobno", SqlDbType.VarChar).Value = textBox5.Text;
                sqlCmd.Parameters.AddWithValue("@tagname", SqlDbType.VarChar).Value = comboBox2.Text;
            }
            if (name == "tbl_tags")
            {
                sp_inserts = "[dbo].[sp_insert_into_tbl_tags]";
                sqlCmd.Parameters.AddWithValue("@tags", SqlDbType.VarChar).Value = textBox5.Text;
                sqlCmd.Parameters.AddWithValue("@description", SqlDbType.VarChar).Value = textBox4.Text;
            }
            if (name == "tbl_user")
            {
                sp_inserts = "[dbo].[sp_insert_into_tbl_user]";
                sqlCmd.Parameters.AddWithValue("@Username", SqlDbType.VarChar).Value = textBox5.Text;
                sqlCmd.Parameters.AddWithValue("@upassword", SqlDbType.VarChar).Value = textBox4.Text;
                sqlCmd.Parameters.AddWithValue("@Role", SqlDbType.VarChar).Value = comboBox2.Text;              
            }
            try
            {
                sqlCmd.CommandText = sp_inserts;
                sqlCmd.Connection = sqlConn;
                sqlCmd.ExecuteNonQuery();
                MessageBox.Show(name + " has sucessfully created a new entry = " + textBox5.Text);
                filldatagrid();
            }
            catch(Exception ex1)
            {
                MessageBox.Show("Table not applicable");
                MessageBox.Show(ex1.ToString());
            }

        }


        private void comboBoxTable_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            filldatagrid();
        }

        private void textBoxFilter_Enter(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter && comboBoxTable.SelectedIndex != -1) { 
            try {
                    DataSet ds1 = new DataSet();
                    string colname = dataGridView1.CurrentCell.OwningColumn.Name;
                    if(comboBoxTable.Text == "tbl_job_tag") { 
                        colname = dataGridView1.Columns[1].Name;
                    }
                    if (comboBoxTable.Text == "tbl_job_file")
                    {
                        colname = dataGridView1.Columns[2].Name;
                    }
                    string sql =  "SELECT * FROM " + comboBoxTable.Text + " WHERE "  + colname + " = '" + textBoxFilter.Text + "'" ;
                    SqlCommand sqlcmd = new SqlCommand(sql,sqlConn);
                    sqlDap = new SqlDataAdapter(sqlcmd);       
                    sqlDap.Fill(ds1);
                    dataGridView1.DataSource = ds1.Tables[0];

                }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
                }

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            prompt_control_create_handler();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand sqlCmd = new SqlCommand("[dbo].[sp_updatetables]",sqlConn);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@tblname", SqlDbType.VarChar).Value = comboBoxTable.Text;
            sqlCmd.Parameters.AddWithValue("@rowid", SqlDbType.VarChar).Value = textBoxID.Text;
            if(textBox1.Text != null) { sqlCmd.Parameters.AddWithValue("@1stcol", SqlDbType.VarChar).Value = textBox1.Text;}
            if(textBox2.Text != null) { sqlCmd.Parameters.AddWithValue("@2ndcol", SqlDbType.VarChar).Value = textBox2.Text; }
            if(comboBox1.Text != null) { sqlCmd.Parameters.AddWithValue("@3rdcol", SqlDbType.VarChar).Value = comboBox1.Text;}

            try 
            {
                sqlCmd.ExecuteNonQuery();
                MessageBox.Show(comboBox1.Text + " has sucessfully updated entry = " + textBoxID.Text);
                filldatagrid();
            }

            catch (Exception ex1)
            {
                MessageBox.Show("Debug: " + ex1.ToString());
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlCommand sqlCmd = new SqlCommand("[dbo].[sp_delete_table_row]",sqlConn);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@tblname", SqlDbType.VarChar).Value = comboBoxTable.Text;
            sqlCmd.Parameters.AddWithValue("@rowid", SqlDbType.VarChar).Value = textBoxID.Text;
            var confirmResult = MessageBox.Show("Are you sure in deleting from " + comboBox1.Text + " with ID number = " + textBoxID.Text, "Cofirm Delete", MessageBoxButtons.OKCancel);

            if(confirmResult == DialogResult.OK) { 
            try
            {
                sqlCmd.ExecuteNonQuery();
                MessageBox.Show(comboBox1.Text + " has sucessfully deleted entry = " + textBoxID.Text);
                filldatagrid();

            }
            catch(Exception ex1)
            {
                MessageBox.Show("Debug: " + ex1.ToString());
            }
                }

            else
            {
                MessageBox.Show("Delete command cancelled");
            }


        }


    }
}
