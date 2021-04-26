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
    public partial class QuickSearch : Form
    {
        public QuickSearch()
        {
            InitializeComponent();
            lblReturnStatus.Text = "Welcome...";
            todaydate();
            establishCon();
            fillCombobox();
        }

        private int[] _Countarray = {0,0,0,0}; //   
        private string _DateNow;
        private string _DateBefore;
        private string _format = "dd-MMM-yyyy";
        private string _LongQuery = "SELECT * FROM tbl_job WHERE ";
        private int _countCom = 0;
        private SqlConnection sqlConn;
        private SqlDataAdapter sqlDap;
        

        private void establishCon()
        {
            sqlConn = new SqlConnection(ConString.GetConString());
            sqlConn.Open();
        }

        
        private void todaydate()
        {
            string datenow = DateTime.Now.ToString(_format);            
            lblCurrent.Text += datenow;
            textBoxEnd.Text = datenow;            
        }

        private void fillCombobox()
        {
            SqlCommand sqlCmdview1 = new SqlCommand("Select * from v_Categories", sqlConn);
            try
            {
                SqlDataReader sqlReader1 = sqlCmdview1.ExecuteReader();
                while (sqlReader1.Read())
                {
                    comboBoxCategory.Items.Add(sqlReader1[0].ToString());
                }
                comboBoxCategory.Items.Insert(0, string.Empty);
                sqlReader1.Close();
                SqlCommand sqlCmdview2 = new SqlCommand("Select * FROM v_state", sqlConn);
                SqlDataReader sqlReader2 = sqlCmdview2.ExecuteReader();
                while (sqlReader2.Read())
                {
                    comboBoxState.Items.Add(sqlReader2[0].ToString());
                }
                comboBoxState.Items.Insert(0, string.Empty);
                sqlReader2.Close();
                SqlCommand sqlCmdview3 = new SqlCommand("Select * FROM v_Market_Sector", sqlConn);
                SqlDataReader sqlReader3 = sqlCmdview3.ExecuteReader();
                while (sqlReader3.Read())
                {
                    comboBoxSector.Items.Add(sqlReader3[0].ToString());
                }
                comboBoxSector.Items.Insert(0, string.Empty);
                sqlReader3.Close();
                SqlCommand sqlCmdview4 = new SqlCommand("Select * FROM v_SubSector", sqlConn);
                SqlDataReader sqlReader4 = sqlCmdview4.ExecuteReader();
                while (sqlReader4.Read())
                {
                    comboBoxSubSector.Items.Add(sqlReader4[0].ToString());
                }
                comboBoxSector.Items.Insert(0, string.Empty);
                sqlReader4.Close();
                SqlCommand sqlCmdview5 = new SqlCommand("Select * FROM v_JobPhases", sqlConn);
                SqlDataReader sqlReader5 = sqlCmdview5.ExecuteReader();
                while (sqlReader5.Read())
                {
                    comboBoxPhase.Items.Add(sqlReader5[0].ToString());
                }
                comboBoxPhase.Items.Insert(0, string.Empty);
                sqlReader5.Close();
                SqlCommand sqlCmdview6 = new SqlCommand("Select * FROM v_column_date", sqlConn);
                SqlDataReader sqlReader6 = sqlCmdview6.ExecuteReader();
                while (sqlReader6.Read())
                {
                    comboBoxDate.Items.Add(sqlReader6[0].ToString());
                }
                sqlReader6.Close();

            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.ToString());
            }       
        }

        private void refreshcom()
        {
            textBoxComp.Text = _LongQuery;
        }

        private void showReturnedRows(int num)
        {
            lblReturnStatus.Text = "Number of returned rows : " + num.ToString();
        }

        /*
        private void DateStoredProc(DateTime start, DateTime end)
        {
            try
            {
                SqlCommand sqlCmd = new SqlCommand("[dbo].[sp_search_by_date]", sqlConn);
                DataSet ds1 = new DataSet();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@input", SqlDbType.Int).Value = comboBoxDate.SelectedIndex + 1;
                sqlCmd.Parameters.AddWithValue("@startdate", SqlDbType.Date).Value = start;
                sqlCmd.Parameters.AddWithValue("@enddate", SqlDbType.Date).Value = end;
               activateGridview(sqlCmd);

            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.ToString());
            }

        }*/

        private void DateStoredDsqlProc(DateTime start, DateTime end)
        {
            try
            {
                SqlCommand sqlCmd = new SqlCommand("[dbo].[sp_search_by_date_dsql]", sqlConn);
                DataSet ds1 = new DataSet();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@colname", SqlDbType.VarChar).Value = comboBoxDate.SelectedItem.ToString();
                sqlCmd.Parameters.AddWithValue("@startdate", SqlDbType.Date).Value = start;
                sqlCmd.Parameters.AddWithValue("@enddate", SqlDbType.Date).Value = end;
                activateGridview(sqlCmd);

            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.ToString());
            }
        }

        private void JobnoStoredProc(string Jobno)
        {
            try
            {
                SqlCommand sqlCmd = new SqlCommand("[dbo].[sp_search_by_jobno]", sqlConn);             
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@jobno", SqlDbType.VarChar).Value = Jobno;
                activateGridview(sqlCmd);
            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.ToString());
            }
        }

        private void StaffStoredProc(string StaffName)
        {
            try
            {
                SqlCommand sqlCmd = new SqlCommand("[dbo].[sp_search_by_staff]", sqlConn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@staffname", SqlDbType.VarChar).Value = StaffName;
                activateGridview(sqlCmd);
            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.ToString());
            }
        }

        private void JobNameStoredProc(string JobName)
        {
            try
            {
                SqlCommand sqlCmd = new SqlCommand("[dbo].[sp_search_by_address]", sqlConn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@jobname", SqlDbType.VarChar).Value = JobName;
                activateGridview(sqlCmd);
            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.ToString());
            }
        }

        private void StateStoredProc()
        {
            try
            {
                SqlCommand sqlCmd = new SqlCommand("[dbo].[sp_search_by_state]", sqlConn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@state", SqlDbType.VarChar).Value = comboBoxState.SelectedItem;
                activateGridview(sqlCmd);
               
            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.ToString());
            }
        }

        private void CategoryStoredProc()
        {
            try
            {
                SqlCommand sqlCmd = new SqlCommand("[dbo].[sp_search_by_category]", sqlConn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@category", SqlDbType.VarChar).Value = comboBoxCategory.SelectedItem;
                activateGridview(sqlCmd);
            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.ToString());
            }
        }

        private void StateCategoryStoredProc()
        {
            try
            {
                SqlCommand sqlCmd = new SqlCommand("[dbo].[sp_search_by_state_category]", sqlConn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@category", SqlDbType.VarChar).Value = comboBoxCategory.SelectedItem;
                sqlCmd.Parameters.AddWithValue("@state", SqlDbType.VarChar).Value = comboBoxState.SelectedItem;
                activateGridview(sqlCmd);
            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.ToString());
            }
        }

        private void MarketSubsectorStoredProc()
        {
            try
            {
                SqlCommand sqlCmd = new SqlCommand("[dbo].[sp_search_by_market]", sqlConn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@marketsector", SqlDbType.VarChar).Value = comboBoxSector.SelectedItem;
                sqlCmd.Parameters.AddWithValue("@subsector", SqlDbType.VarChar).Value = comboBoxSubSector.SelectedItem;
                activateGridview(sqlCmd);
            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.ToString());
            }
        }

        private void MarketSectorStoredProc()
        {
            try
            {
                SqlCommand sqlCmd = new SqlCommand("[dbo].[sp_search_by_sector]", sqlConn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@sector", SqlDbType.VarChar).Value = comboBoxSector.SelectedItem;
                activateGridview(sqlCmd);
            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.ToString());
            }
        }

        private void SubSectorStoredProc()
        {
            try
            {
                SqlCommand sqlCmd = new SqlCommand("[dbo].[sp_search_by_sub_sector]", sqlConn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@sub_sector", SqlDbType.VarChar).Value = comboBoxSubSector.SelectedItem;
                activateGridview(sqlCmd);
            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.ToString());
            }
        }

        private void ClientStoredProc()
        {
            try
            {
                SqlCommand sqlCmd = new SqlCommand("[dbo].[sp_search_by_client]", sqlConn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@client", SqlDbType.VarChar).Value = textBoxClient.Text;
                activateGridview(sqlCmd);
            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.ToString());
            }
        }

        private void DescriptionStoredProc()
        {
            try
            {
                SqlCommand sqlCmd = new SqlCommand("[dbo].[sp_search_by_description]", sqlConn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@jobdescription", SqlDbType.VarChar).Value = textBoxDescription.Text;
                activateGridview(sqlCmd);
            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.ToString());
            }
        }

        private void PhaseStoredProc()
        {
            try
            {
                SqlCommand sqlCmd = new SqlCommand("[dbo].[sp_search_by_phase]", sqlConn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@phase", SqlDbType.VarChar).Value = comboBoxPhase.SelectedItem;
                activateGridview(sqlCmd);
            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.ToString());
            }
        }

        private void activateGridview(SqlCommand sqlCmd)
        {
            try { 
            DataSet ds1 = new DataSet();
            sqlDap = new SqlDataAdapter(sqlCmd);
            sqlDap.Fill(ds1);
            dataGridView1.DataSource = ds1.Tables[0];
            int rows = dataGridView1.RowCount;
            showReturnedRows(rows);
                }
            catch(Exception ex1)
            {
                MessageBox.Show(ex1.ToString());
            }
        }

        private void btnWeek_Click(object sender, EventArgs e)
        {
            DateTime d7 = DateTime.Now;
            d7 = d7.AddDays(-7);
            string d7str = d7.ToString(_format);
            _DateBefore = d7str;
            textBoxStart.Text = d7str;
            //MessageBox.Show(d7str);
        }

        private void btnMonth_Click(object sender, EventArgs e)
        {
            DateTime d30 = DateTime.Now;
            d30 = d30.AddDays(-30);
            string d30str = d30.ToString(_format);
            _DateBefore = d30str;
            textBoxStart.Text = d30str;
            //MessageBox.Show(d30str);
        }

        private void btnYear1_Click(object sender, EventArgs e)
        {
            DateTime d365 = DateTime.Now;
            d365 = d365.AddDays(-365);
            string d365str = d365.ToString(_format);
            _DateBefore = d365str;
            textBoxStart.Text = d365str;
            //MessageBox.Show(d365str);
        }

        private void btnYear3_Click(object sender, EventArgs e)
        {
            DateTime d1095 = DateTime.Now;
            d1095 = d1095.AddDays(-1095);
            string d1095str = d1095.ToString(_format);
            _DateBefore = d1095str;
            textBoxStart.Text = d1095str;
            //MessageBox.Show(d1095str);
        }

        private void btnDateSearch_Click(object sender, EventArgs e)
        {
            try { 
                DateTime dateTimeStart = Convert.ToDateTime(textBoxStart.Text);
                DateTime dateTimeEnd = Convert.ToDateTime(textBoxEnd.Text);
                if (dateTimeStart < dateTimeEnd)
                {
                    //MessageBox.Show("Debug: Start < End");
                    try { 
                        DateStoredDsqlProc(dateTimeStart, dateTimeEnd);
                        //DateStoredProc(dateTimeStart, dateTimeEnd)
                        }
                    catch(Exception ex2)
                    {
                        MessageBox.Show(ex2.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Error: Start date is after the end date");
                }
                }
            catch(Exception ex1)
                {
                MessageBox.Show("Error has occurred: " + ex1.ToString());
                }          
        }
   
        private void btnJobnoSearch_Click(object sender, EventArgs e)
        {
            JobnoStoredProc(textBoxJobno.Text);
        }

        private void btnStatusSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if(comboBoxCategory.SelectedItem != null && comboBoxState.SelectedItem != null)
                {
                    //MessageBox.Show("1" + comboBoxCategory.SelectedItem.ToString() + comboBoxState.SelectedItem.ToString() );
                    StateCategoryStoredProc();
                }
                else { 
                if(comboBoxCategory.SelectedItem != null)
                {
                        //MessageBox.Show("2" + comboBoxCategory.SelectedItem.ToString());
                        CategoryStoredProc();
                }
                    else
                    {
                        if(comboBoxState.SelectedItem != null)
                        {
                            //MessageBox.Show("3" + comboBoxState.SelectedItem.ToString());
                            StateStoredProc();
                        }
                        else
                        {
                            MessageBox.Show("Nothing was selected");
                        }
                    }
                }
            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.ToString());
            }

        }


        private void btnStaffSearch_Click(object sender, EventArgs e)
        {
            try
            {
                StaffStoredProc(textBoxStaff.Text);
            }
            catch (Exception ex1)
            {

                MessageBox.Show("An error has occured: " + ex1.ToString());
            }
        }

        private void btnComSearch_Click(object sender, EventArgs e)
        {
            SqlCommand ComsqlCmd = new SqlCommand(_LongQuery,sqlConn);
            activateGridview(ComsqlCmd);
        }

        private void btnSectorSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxSector.SelectedItem != null && comboBoxSubSector.SelectedItem != null)
                {
                    MarketSubsectorStoredProc();
                }
                else
                {
                    if (comboBoxSector.SelectedItem != null)
                    {
                        MarketSectorStoredProc();
                    }
                    else
                    {
                        if (comboBoxSubSector.SelectedItem != null)
                        {
                            SubSectorStoredProc();
                        }
                        else
                        {
                        }
                    }
                }
            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.ToString());
            }
        }

        private void btnClientSearch_Click(object sender, EventArgs e)
        {
            try
            {
                ClientStoredProc();
            }
            catch (Exception ex1)
            {

                MessageBox.Show("An error has occured: " + ex1.ToString());
            }
        }

        private void btnAddressSearch_Click(object sender, EventArgs e)
        {
            try
            {
                JobNameStoredProc(textBoxJobName.Text);
            }
            catch (Exception ex1)
            {

                MessageBox.Show("An error has occured: " + ex1.ToString());
            }
        }

        private void btnDescriptionSearch_Click(object sender, EventArgs e)
        {
            try
            {
                DescriptionStoredProc();
            }
            catch (Exception ex1)
            {

                MessageBox.Show("An error has occured: " + ex1.ToString());
            }
        }

        private void btnPhaseSearch_Click(object sender, EventArgs e)
        {
            try
            {
                PhaseStoredProc();
            }
            catch (Exception ex1)
            {
                MessageBox.Show("An error has occured: " + ex1.ToString());
            }
        }

        private void btnStatusAdd_Click(object sender, EventArgs e)
        {
            int address1 = 2;
            if (_Countarray[address1] < 1)
            {
                if (textBoxStart.Text != null && textBoxEnd.Text != null && comboBoxDate.SelectedItem != null)
                {

                }
                else
                {
                    //if(tex)
                }
            }
            else
            {
                btnDateAdd.Text = "Clear";
                _Countarray[address1] += 1;
                refreshcom();
            }
            if (_Countarray[address1] > 1)
            {
                _Countarray[address1] = 0;
                btnDateAdd.Text = "Add";
                textBoxStart.Clear();
                refreshcom();
            }
        }
        private void btnDateAdd_Click(object sender, EventArgs e)
        {
            int address1 = 0;
            if (_Countarray[address1] < 1)
            {
                if (textBoxStart.Text != null && textBoxEnd.Text != null && comboBoxDate.SelectedItem != null)
                {
                    if (_countCom > 0)
                    {
                        _LongQuery = _LongQuery + "AND";
                    }
                    _LongQuery = _LongQuery + comboBoxDate.SelectedItem.ToString() + " BETWEEN '" + textBoxStart.Text + "' AND '" + textBoxEnd.Text + "'";
                    MessageBox.Show(_LongQuery);
                    _Countarray[address1] += 1;
                    refreshcom();
                    _countCom += 1;
                }
                else
                {
                    MessageBox.Show("Date entry fields are empty");
                }
            }
            else
            {
                btnDateAdd.Text = "Clear";
                _Countarray[address1] += 1;
                refreshcom();
            }
            if (_Countarray[address1] > 1)
            {
                _Countarray[address1] = 0;
                btnDateAdd.Text = "Add";
                textBoxStart.Clear();
                refreshcom();
            }
        }

        private void btnSectorAdd_Click(object sender, EventArgs e)
        {
            int address1 = 1;
            if (_Countarray[address1] < 1)
            {
                if (comboBoxSector.SelectedItem != null && comboBoxSubSector.SelectedItem != null)
                {
                    if (_countCom > 0)
                    {
                        _LongQuery = _LongQuery + "AND";
                    
                    
                    }
                   
                    _Countarray[address1] += 1;
                    refreshcom();
                    _countCom += 1;//compound count layer
                }
                else
                {
                   if(comboBoxSubSector.SelectedItem != null)
                    {
                        if (_countCom > 0)
                        {
                            _LongQuery = _LongQuery + "AND";


                        }
                    }
                   else
                    {
                        if(comboBoxSector.SelectedItem != null)
                        {
                            if (_countCom > 0)
                            {
                                _LongQuery = _LongQuery + "AND";


                            }
                        }
                        else
                        {

                        }
                    }
                }
            }
            //btn press count layer
            else
            {
                btnDateAdd.Text = "Clear";
                _Countarray[address1] += 1;
                refreshcom();
            }
            if (_Countarray[address1] > 1)
            {
                _Countarray[address1] = 0;
                btnDateAdd.Text = "Add";
                textBoxStart.Clear();
                refreshcom();
            }
        }
    }
}
