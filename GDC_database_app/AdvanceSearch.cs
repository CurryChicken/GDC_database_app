using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static GDC_database_app.ConString;

namespace GDC_database_app
{
    public partial class AdvanceSearch : Form
    {
        public AdvanceSearch()
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
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.ToString());
            }


            try
            {
                SqlCommand sqlCmdview1 = new SqlCommand("Select * from v_views", sqlConn);
                SqlDataReader sqlReader1 = sqlCmdview1.ExecuteReader();
                while (sqlReader1.Read())
                {
                    comboBoxViews.Items.Add(sqlReader1[0].ToString());
                }
                sqlReader1.Close();
            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.ToString());
            }
        }

        private void filldatagrid(int trigger = 0)
        {

            string sql = "SELECT TOP 1000 * FROM " + comboBoxTable.Text;
            
            if(trigger == 1){
            
                sql = textBox1.Text;
            }

            if(trigger == 2)
            {
                sql = "SELECT * FROM " + comboBoxViews.Text;
            } 
            SqlCommand sqlCmd = new SqlCommand(sql, sqlConn);
            try
            {
                DataSet ds1 = new DataSet();
                sqlDap = new SqlDataAdapter(sqlCmd);
                sqlDap.Fill(ds1);
                dataGridView1.DataSource = ds1.Tables[0];
                int rows = dataGridView1.RowCount;
                lblStatus.Text = rows + " Rows Returned";
            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.ToString());
                lblStatus.Text = "Command not recognised" ;
            }
        }



        private void textBox1_Enter(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter) {filldatagrid(1);}
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
        }

        private void comboBoxTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxTable.SelectedIndex > 0)
            {
                filldatagrid();
            }
        }

        private void comboBoxViews_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxViews.SelectedIndex > 0)
            {
                filldatagrid(2);
            }
        }
    }
}
