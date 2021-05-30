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

        
        private string[] _Countarray = {"SELECT * FROM tbl_job WHERE ","","","","",""}; //[sqlstart,condition,and,condition]   
        private string _DateNow;
        private string _DateBefore;
        private string _format = "dd-MMM-yyyy";
        private SqlConnection sqlConn;
        private SqlDataAdapter sqlDap;
        

        private void establishCon()
        {
            sqlConn = new SqlConnection(ConString.GetConString());
            sqlConn.Open();
        }

        private void clearall()
        {
            int x = _Countarray.Length;
            for (int i = 0; x > i; i++)
            {
                _Countarray[i] = "";
            }
            _Countarray[0] = "SELECT * FROM tbl_job WHERE ";


            //textbox...
            textBoxClient.Text = textBoxComp.Text = textBoxDescription.Text = textBoxStart.Text = textBoxJobName.Text = textBoxJobno.Text = textBoxStaff.Text = "";
            //combobox...
            comboBoxCategory.SelectedIndex = comboBoxDate.SelectedIndex = comboBoxPhase.SelectedIndex = comboBoxSector.SelectedIndex = comboBoxState.SelectedIndex = comboBoxSubSector.SelectedIndex = comboBoxAllTag.SelectedIndex = comboBoxCustomTag.SelectedIndex = 0;

            //MessageBox.Show("All inputs are cleared");
        }
        
        private void todaydate()
        {
            string datenow = DateTime.Now.ToString(_format);            
            lblCurrent.Text += datenow;
            textBoxEnd.Text = datenow;            
        }

        private void fillCombobox()
        {
            
            try
            {
                SqlCommand sqlCmdview1 = new SqlCommand("Select * from v_Categories", sqlConn);
                SqlDataReader sqlReader1 = sqlCmdview1.ExecuteReader();
                comboBoxCategory.Items.Insert(0, string.Empty);
                while (sqlReader1.Read())
                {
                    comboBoxCategory.Items.Add(sqlReader1[0].ToString());
                } 
                sqlReader1.Close();
                SqlCommand sqlCmdview2 = new SqlCommand("Select * FROM v_state", sqlConn);
                SqlDataReader sqlReader2 = sqlCmdview2.ExecuteReader();
                comboBoxState.Items.Insert(0, string.Empty);
                while (sqlReader2.Read())
                {
                    comboBoxState.Items.Add(sqlReader2[0].ToString());
                }
                sqlReader2.Close();
                SqlCommand sqlCmdview3 = new SqlCommand("Select * FROM v_Market_Sector", sqlConn);
                SqlDataReader sqlReader3 = sqlCmdview3.ExecuteReader();
                comboBoxSector.Items.Insert(0, string.Empty);
                while (sqlReader3.Read())
                {
                    comboBoxSector.Items.Add(sqlReader3[0].ToString());
                }
                
                sqlReader3.Close();
                SqlCommand sqlCmdview4 = new SqlCommand("Select * FROM v_SubSector", sqlConn);
                SqlDataReader sqlReader4 = sqlCmdview4.ExecuteReader();
                while (sqlReader4.Read())
                {
                    comboBoxSubSector.Items.Add(sqlReader4[0].ToString());
                }
                comboBoxSubSector.Items.Insert(0, string.Empty);
                sqlReader4.Close();
                SqlCommand sqlCmdview5 = new SqlCommand("Select * FROM v_JobPhases", sqlConn);
                SqlDataReader sqlReader5 = sqlCmdview5.ExecuteReader();
                comboBoxPhase.Items.Insert(0, string.Empty);
                while (sqlReader5.Read())
                {
                    comboBoxPhase.Items.Add(sqlReader5[0].ToString());
                }
                sqlReader5.Close();

                SqlCommand sqlCmdview6 = new SqlCommand("Select * FROM v_column_date", sqlConn);
                SqlDataReader sqlReader6 = sqlCmdview6.ExecuteReader();
                comboBoxDate.Items.Insert(0, string.Empty);
                while (sqlReader6.Read())
                {
                    comboBoxDate.Items.Add(sqlReader6[0].ToString());
                }
                sqlReader6.Close();
                SqlCommand sqlCmdview7 = new SqlCommand("Select tags FROM tbl_tags", sqlConn);
                SqlDataReader sqlReader7 = sqlCmdview7.ExecuteReader();
                comboBoxAllTag.Items.Insert(0, string.Empty);
                while (sqlReader7.Read())
                {
                    comboBoxAllTag.Items.Add(sqlReader7[0].ToString());
                }
                sqlReader7.Close();
                SqlCommand sqlCmdview8 = new SqlCommand("Select tags FROM v_OtherTags", sqlConn);
                SqlDataReader sqlReader8 = sqlCmdview8.ExecuteReader();
                comboBoxCustomTag.Items.Insert(0, string.Empty);
                while (sqlReader8.Read())
                {
                    comboBoxCustomTag.Items.Add(sqlReader8[0].ToString());
                }
                sqlReader8.Close();

                comboBoxCategory.SelectedIndex = comboBoxDate.SelectedIndex = comboBoxSector.SelectedIndex = comboBoxSubSector.SelectedIndex = comboBoxState.SelectedIndex = 0;

                
            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.ToString());
            }       
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
            if (textBoxStart.TextLength > 6 & textBoxEnd.TextLength > 6) {
                if(comboBoxDate.SelectedIndex > 0) { 
            try { 
                DateTime dateTimeStart = Convert.ToDateTime(textBoxStart.Text);
                DateTime dateTimeEnd = Convert.ToDateTime(textBoxEnd.Text);
                if (dateTimeStart < dateTimeEnd)
                {
                    try { 
                        DateStoredDsqlProc(dateTimeStart, dateTimeEnd);
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
                else
                {
                    MessageBox.Show("Date type not entered");
                }
            }
            else
            {
                MessageBox.Show("Start or end date is not entered");
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
                if(comboBoxCategory.SelectedItem.ToString() != "" & comboBoxState.SelectedItem.ToString() != "")
                {
                    //MessageBox.Show("1" + comboBoxCategory.SelectedItem.ToString() + comboBoxState.SelectedItem.ToString() );
                    StateCategoryStoredProc();
                }
                else { 
                if(comboBoxCategory.SelectedItem.ToString() != "")
                {
                        //MessageBox.Show("2" + comboBoxCategory.SelectedItem.ToString());
                        CategoryStoredProc();
                }
                    else
                    {
                        if(comboBoxState.SelectedItem.ToString() != "")
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

            SqlCommand ComsqlCmd = new SqlCommand(textBoxComp.Text,sqlConn);
            activateGridview(ComsqlCmd);


        }

        private void btnSectorSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxSector.SelectedItem.ToString() != "" && comboBoxSubSector.SelectedItem.ToString() != "")
                {
                    MarketSubsectorStoredProc();
                }
                else
                {
                    if (comboBoxSector.SelectedItem.ToString() != "")
                    {
                        MarketSectorStoredProc();
                    }
                    else
                    {
                        if (comboBoxSubSector.SelectedItem.ToString() != "")
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

        private void statushandler(int chose)
        {
            int address1 = 5;
            string sqlsend = "";
            

            if (chose == 1)
            {
                sqlsend = sqlsend + "Category_Category = '" + comboBoxCategory.SelectedItem.ToString() + "'";
                compoundstringhandler(sqlsend,address1);
            }
            if (chose == 2)
            {
                sqlsend = sqlsend + "State_State = '" + comboBoxState.SelectedItem.ToString() + "'";
                compoundstringhandler(sqlsend,address1);
            }
            if (chose == 3)
            {
                sqlsend = sqlsend + "Category_Category = '" + comboBoxCategory.SelectedItem.ToString() + "' AND State_State = '" + comboBoxState.SelectedItem.ToString() + "'";
                compoundstringhandler(sqlsend,address1);
            }

           
        }

        private void btnStatusAdd_Click(object sender, EventArgs e)
        {
            if (comboBoxCategory.SelectedIndex != 0 && comboBoxState.SelectedIndex != 0)
            {
                statushandler(3);
            }
            else
            {
                if (comboBoxState.SelectedIndex != 0)
                {
                    statushandler(2);
                }
                else
                {
                    if (comboBoxCategory.SelectedIndex != 0)
                    {
                        statushandler(1);
                    }
                    else
                    {
                        MessageBox.Show("Date entry fields are empty");
                    }
                }
            }

        }

        
        private void btnDateAdd_Click(object sender, EventArgs e)
        {
            string sqlsend = "";
            int address1 = 1;
            try { 
            if (textBoxStart.TextLength > 6 & textBoxEnd.TextLength > 6)
                
            {
                if(comboBoxDate.SelectedIndex != 0 & comboBoxDate.Text != null) 
                { 
                    sqlsend = comboBoxDate.SelectedItem.ToString() + " BETWEEN '" + textBoxStart.Text + "' AND '" + textBoxEnd.Text + "'";
                    compoundstringhandler(sqlsend,address1);
                }
                else
                {
                    MessageBox.Show("Date type is not selected");
                }

            }
                else
                {
                    MessageBox.Show("Date entry fields are empty");
                } 
            } catch(Exception ex1) { MessageBox.Show("Debug: " + ex1.ToString()); }
            
            
        }

        private void sectorhandler(int chose)
        {
            int address1 = 3;
            string sqlsend = "";

            if (chose == 1)
            {
                sqlsend = sqlsend + "Job_Market_Sector_1 = '" + comboBoxSector.SelectedItem.ToString() + "'";
                compoundstringhandler(sqlsend,address1);
            }
            if(chose == 2)
            {
                sqlsend = sqlsend + "Job_Sub_Market_Sector = '" + comboBoxSubSector.SelectedItem.ToString() + "'";
                compoundstringhandler(sqlsend,address1);
            }
            if(chose == 3)
            {
                sqlsend = sqlsend + "Job_Market_Sector_1 = '" + comboBoxSector.SelectedItem.ToString() + "' AND Job_Sub_Market_Sector = '" + comboBoxSubSector.SelectedItem.ToString() + "'";
                compoundstringhandler(sqlsend,address1);
            }
        }

        private void taghandler(int chose)
        {
            try { 
            string sqlsend = "Select * From tbl_job j, tbl_job_tags jt, tbl_tags t " +
                             "WHERE jt.uuid = t.uuid AND j.Job_Job_No = jt.job_job_no AND ";


            if (chose == 1)
            {
                sqlsend = sqlsend + "tags = '" + comboBoxSector.SelectedItem.ToString() + "'";
                
            }
            if (chose == 2)
            {
                sqlsend = sqlsend + "tags = '" + comboBoxAllTag.SelectedItem.ToString() + "'";
                
            }

                SqlCommand cmd1 = new SqlCommand(sqlsend, sqlConn);
                activateGridview(cmd1);
            }
            catch(Exception ex1)
            {
                MessageBox.Show(ex1.ToString());
            }

        }

        private void btnSectorAdd_Click(object sender, EventArgs e)
        {
           
                if (comboBoxSector.SelectedIndex > 0 && comboBoxSubSector.SelectedIndex > 0)
                {
                    sectorhandler(3);
                }
                else
                {
                   if(comboBoxSubSector.SelectedIndex > 0)
                    {
                        sectorhandler(2);   
                    }
                   else
                    {
                        if(comboBoxSector.SelectedIndex > 0)
                        {
                           sectorhandler(1);
                        }
                        else
                        {
                        MessageBox.Show("Date entry fields are empty");
                        }
                    }
                }
         
            
        }


        private void compoundstringhandler(string input,int address)
        {
            string read = "";
            bool numfront = false;
            int x = _Countarray.Length;
            for(int i = 1; x > i; i++)
            {
                if(_Countarray[i] != "")
                {
                    numfront = true;
                }
            }
            if(numfront == false ) 
            { 
                _Countarray[address] = input;
            }
            else
            {
                _Countarray[address] = input;
                _Countarray[address - 1] = " AND ";
                _Countarray[0] = "SELECT * FROM tbl_job WHERE ";
            }
            

            for (int i = 0; x > i; i++)
            {
                 read = read + _Countarray[i];
            }

            textBoxComp.Text = read;

        }

        

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }


        private void btnTagSearch_Click(object sender, EventArgs e)
        {
            if (comboBoxAllTag.SelectedIndex != 0 & comboBoxCustomTag.SelectedIndex != 0)
            {
                taghandler(2);
            }
            else
            {
                if (comboBoxAllTag.SelectedIndex != 0)
                {
                    taghandler(2);
                }
                else
                {
                    if (comboBoxCustomTag.SelectedIndex != 0)
                    {
                        taghandler(1);
                    }
                    else
                    {
                        MessageBox.Show("Date entry fields are empty");
                    }
                }
            }
        }

        private void QuickSearch_Load(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearall();
        }

        private void btnHowuse_Click(object sender, EventArgs e)
        {

        }
    }
}
