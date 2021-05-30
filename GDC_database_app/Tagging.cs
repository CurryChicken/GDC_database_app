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
    public partial class Tagging : Form
    {
        public Tagging()
        {
            InitializeComponent();
            EstablishConnection();
            FillCombobox();
        }

        SqlConnection sqlConn;
        
        SqlDataAdapter sqlDap;
        private string selectedno;
        private List<string> multiselectedno = new List<string>();  


        private void FillCombobox()
        {
            try
            {
                SqlCommand sqlCmdview1 = new SqlCommand("Select * from v_JobPhases", sqlConn);
                SqlDataReader sqlReader1 = sqlCmdview1.ExecuteReader();
                comboBoxPhase.Items.Insert(0, string.Empty);
                while (sqlReader1.Read())
                {
                    comboBoxPhase.Items.Add(sqlReader1[0].ToString());
                }
                sqlReader1.Close();
                SqlCommand sqlCmdview2 = new SqlCommand("Select * FROM v_market_sector", sqlConn);
                SqlDataReader sqlReader2 = sqlCmdview2.ExecuteReader();
                comboBoxSector.Items.Insert(0, string.Empty);
                while (sqlReader2.Read())
                {
                    comboBoxSector.Items.Add(sqlReader2[0].ToString());
                }
                sqlReader2.Close();
                SqlCommand sqlCmdview3 = new SqlCommand("Select * FROM v_subsector", sqlConn);
                SqlDataReader sqlReader3 = sqlCmdview3.ExecuteReader();
                comboBoxSubSector.Items.Insert(0, string.Empty);
                while (sqlReader3.Read())
                {
                    comboBoxSubSector.Items.Add(sqlReader3[0].ToString());
                }

                sqlReader3.Close();
                SqlCommand sqlCmdview4 = new SqlCommand("Select * FROM v_OtherTags", sqlConn);
                SqlDataReader sqlReader4 = sqlCmdview4.ExecuteReader();
                while (sqlReader4.Read())
                {
                    comboBoxOther.Items.Add(sqlReader4[0].ToString());
                }
                comboBoxOther.Items.Insert(0, string.Empty);
                sqlReader4.Close();
            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.ToString());
            }
        }

        private void ClearCombobox()
        {
            try
            {
                comboBoxOther.Items.Clear();
                comboBoxPhase.Items.Clear();
                comboBoxSector.Items.Clear();
                comboBoxSubSector.Items.Clear();
            }
            catch(Exception ex1)
            {
                MessageBox.Show(ex1.ToString());
            }
        }

        private void insert_into_job_tags(string jobno, string tag)
        {
            try { 
                    SqlCommand sqlCmd = new SqlCommand("[dbo].[sp_insert_into_tbl_job_tags]", sqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@jobno", SqlDbType.VarChar).Value = jobno;
                    sqlCmd.Parameters.AddWithValue("@tagname", SqlDbType.VarChar).Value = tag;
                    sqlCmd.ExecuteNonQuery();
                }
            catch(Exception ex1)
            {
                MessageBox.Show(ex1.ToString());

            }
        }

        private void EstablishConnection()
        {
            sqlConn = new SqlConnection(ConString.GetConString());
            sqlConn.Open();
        }

        private void activateGridview1(SqlCommand sqlCmd)
        {
            try
            {
                DataSet ds1 = new DataSet();
                sqlDap = new SqlDataAdapter(sqlCmd);
                sqlDap.Fill(ds1);
                dataGridView1.DataSource = ds1.Tables[0];
                //int rows = dataGridView1.RowCount;
                //showReturnedRows(rows);
            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.ToString());
            }
        }

        private void activateGridview2(SqlCommand sqlCmd)
        {
            try
            {
                DataSet ds1 = new DataSet();
                sqlDap = new SqlDataAdapter(sqlCmd);
                sqlDap.Fill(ds1);
                dataGridView2.DataSource = ds1.Tables[0];
                //int rows = dataGridView1.RowCount;
                //showReturnedRows(rows);
            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.ToString());
            }
        }

        private void txtSearch_Enter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { 
            string txt = txtSearch.Text.ToString();        
            try
            {
                    SqlCommand sqlCmd = new SqlCommand("[dbo].[sp_search_job_no_description_name]", sqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@search_term", SqlDbType.VarChar).Value = txt;
                    
                    activateGridview1(sqlCmd);
            }
            catch(Exception ex1)
            {
                MessageBox.Show(ex1.ToString());
            }
            }
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string[] sarray;
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                string selectno = row.Cells[0].Value.ToString();
                txtBoxJobNo.Text = selectedno = textBoxSearchTags.Text = selectno;
                SqlCommand sqlCmd = new SqlCommand("[dbo].[sp_search_job_tags]", sqlConn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Job_no", SqlDbType.VarChar).Value = selectno;
                activateGridview2(sqlCmd);
                try
                {

                    multiselectedno.Add(selectno);                 
                    txtBoxMultiSelect.Text = string.Join(Environment.NewLine, multiselectedno.ToArray());
                    sarray = multiselectedno.ToArray();
                    MessageBox.Show(multiselectedno.Count().ToString());
                }
                catch (Exception ex1)
                {
                    MessageBox.Show(ex1.ToString());
                }
            }
        }

        private void textBoxSearchTags_Enter(object sender, KeyEventArgs e)
        {
            string txt = textBoxSearchTags.Text;
            if (e.KeyCode == Keys.Enter)
            {
                SqlCommand sqlCmd = new SqlCommand("[dbo].[sp_search_job_tags]", sqlConn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Job_no", SqlDbType.VarChar).Value = txt;

                activateGridview2(sqlCmd);
            }
        }

  

        private void btnInsertTag_Click(object sender, EventArgs e)
        {
            foreach (string s in multiselectedno) { 
                    insert_into_job_tags(s,txtBoxSelectTag.Text);
                }
            MessageBox.Show(multiselectedno.Count.ToString() + " Tags has been inserted");
            lblInsertStatus.Text = multiselectedno.Count.ToString() + " Tags has been inserted";
            multiselectedno.Clear();
            txtBoxMultiSelect.Clear();
            txtBoxJobNo.Clear();
        }

        private void comboBoxPhase_SelectedIndexChanged(object sender, EventArgs e)
        {
           txtBoxSelectTag.Text = comboBoxPhase.SelectedItem.ToString();
        }

        private void comboBoxSector_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBoxSelectTag.Text = comboBoxSector.SelectedItem.ToString();
        }

        private void comboBoxSubSector_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBoxSelectTag.Text = comboBoxSubSector.SelectedItem.ToString();
        }

        private void comboBoxOther_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBoxSelectTag.Text = comboBoxOther.SelectedItem.ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            multiselectedno.Clear();
            txtBoxMultiSelect.Clear();
            txtBoxJobNo.Clear();
        }

        private void btnCreateTag_Click(object sender, EventArgs e)
        {
            
            if(txtBoxTagname.Text != null) { 
                string tagname = txtBoxTagname.Text;
                string description;
                if(txtBoxDescription.Text == null)
                {
                    description = "";
                }
                try 
                { 
                    description = txtBoxDescription.Text;
                    SqlCommand sqlCmd = new SqlCommand("[dbo].[sp_insert_into_tbl_tags]", sqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@tags", SqlDbType.VarChar).Value = tagname;
                    sqlCmd.Parameters.AddWithValue("@description", SqlDbType.VarChar).Value = description;
                    sqlCmd.ExecuteNonQuery();
                    lblInsertStatus2.Text = "Tags Insert sucussfully";

                    //refill other combo box
                    ClearCombobox();FillCombobox();

                 }
                catch(Exception ex1)
                {
                    MessageBox.Show(ex1.ToString());
                }
            }
            else
            {
                lblInsertStatus2.Text = "Fields are empty";
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //on click event on grid 2
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
