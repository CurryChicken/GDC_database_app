using System;
using System.Data;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic.FileIO;
using ExcelDataReader;
using System.Data.SqlClient;
using static GDC_database_app.ConString;
using System.Collections.Generic;

namespace GDC_database_app
{
    public partial class DataMigrateExcel : Form
    {
        public DataMigrateExcel()
        {
            InitializeComponent();
            establishCon();
            fillcombobox();
        }

        private string fileaddress;
        private DataTable csvData;
        private DataTable xlsData;
        private DataTable OneData;
        private SqlConnection sqlConn;
        private string selectedtable;
        private List<string> collist;

        private void DataMigrateExcel_Load(object sender, EventArgs e)
        {
            groupBox3.Enabled = groupBox4.Enabled = false;

        }

        private void establishCon()
        {
            sqlConn = new SqlConnection(ConString.GetConString());
            sqlConn.Open();
            lblStatus.Text = "Connection Establish";
            lblStatus1.Text = "";
        }

        private void fillcombobox()
        {
            try
            {
                SqlCommand sqlCmdview = new SqlCommand("Select * from V_tableview",sqlConn);
                SqlDataReader sqlreader = sqlCmdview.ExecuteReader();
                while (sqlreader.Read())
                {
                    comboBoxTable.Items.Add(sqlreader[0].ToString());
                }
                sqlreader.Close();
            }
            catch(Exception ex1)
            {
                MessageBox.Show(ex1.ToString());
            }
        }

        private void Loaddatabletotable()
        {
            try {    
            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(sqlConn))
            {
                    truncate_table();
                    bulkCopy.DestinationTableName = selectedtable;
                    collist = new List<string>();
                    SqlCommand colcmd = new SqlCommand("select COLUMN_NAME from information_schema.columns where table_name = '" + comboBoxTable.Text + "'",sqlConn);
                    SqlDataReader sqlreader = colcmd.ExecuteReader();
                    while (sqlreader.Read())
                    {
                        collist.Add(sqlreader[0].ToString());
                    }
                    sqlreader.Close();

                    
                      for(int i = 0; i < OneData.Columns.Count; i++)
                        {
                            OneData.Columns[i].ColumnName = OneData.Columns[i].ColumnName.Replace(" ","_");
                            OneData.Columns[i].ColumnName = OneData.Columns[i].ColumnName.Replace("[","");
                            OneData.Columns[i].ColumnName = OneData.Columns[i].ColumnName.Replace("]","");
                            OneData.Columns[i].ColumnName = OneData.Columns[i].ColumnName.Replace(".", "");
                            OneData.Columns[i].ColumnName = OneData.Columns[i].ColumnName.Replace("!", "");
                        foreach (string col in collist)
                           {

                                    if (OneData.Columns[i].ColumnName.Equals(col))
                                        {
                                             textBox1.Text +=  OneData.Columns[i].ColumnName + " Matches Source table column." + Environment.NewLine;
                                        }
                           }       
                    }
                    //  MessageBox.Show("Debug: Column matching started");
                    //foreach (DataColumn c in OneData.Columns)
                    //{
                    //    MessageBox.Show("Debug: Column matching started");
                    //    bulkCopy.ColumnMappings.Add(c.ColumnName, c.ColumnName); //(source,destination)
                        
                    //}
                    //MessageBox.Show("Debug: Column matching complete");

                    try
                    {
                        if (OneData.Columns.Count == collist.Count && OneData.Rows.Count > 0)
                        {
                            bulkCopy.BulkCopyTimeout = 100;bulkCopy.BatchSize = 1000;bulkCopy.NotifyAfter = 1000;
                            textBox1.Text += "Copying to the database ... " + Environment.NewLine;
                            bulkCopy.WriteToServer(OneData);
                            textBox1.Text += "Copying to the database completed ..." + Environment.NewLine;
                            groupBox4.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("Datatables are empty");
                        }

                    }
                    catch (Exception ex1)
                    {
                        MessageBox.Show(ex1.ToString());
                    }

                }

            }
            catch(Exception ex1)
            {
                MessageBox.Show(ex1.ToString());
            }
        }

        private void truncate_table()
        {
            SqlCommand sqlcmd = new SqlCommand("[dbo].[sp_truncate_table]",sqlConn);
            sqlcmd.Parameters.AddWithValue("@table_name", SqlDbType.VarChar).Value = comboBoxTable.Text;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.BeginExecuteNonQuery();
            textBox1.Text += "Truncating table = " + comboBoxTable.Text + " ... " + Environment.NewLine;

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFile = new OpenFileDialog())
            {
                openFile.InitialDirectory = "c:\\";
                openFile.Filter = "CSV files (*.csv)|*.csv|Excel Files|*.xls;*.xlsx";
                openFile.FilterIndex = 1;

                if(openFile.ShowDialog() == DialogResult.OK)
                {
                    txtBoxAddress.Text = fileaddress = openFile.FileName;
                    if (openFile.FileName.Contains(".xls") == true || openFile.FileName.Contains(".xlsx") == true)
                    {
                        try
                        {
                            using (FileStream excel = new FileStream(fileaddress, FileMode.Open, FileAccess.Read))
                            {
                                IExcelDataReader dataReader = ExcelReaderFactory.CreateReader(excel);
                                var config = new ExcelDataSetConfiguration
                                {
                                    ConfigureDataTable = _ => new ExcelDataTableConfiguration
                                    {
                                        UseHeaderRow = true
                                        //call header row here using ReadHeaderRow
                                        
                                    }
                                };
                                var dataset = dataReader.AsDataSet(config);

                                xlsData = new DataTable();
                                OneData = xlsData = dataset.Tables[0];

                                dataGridView1.DataSource = xlsData;
                                lblStatus.Text = "Data table load Successful";
                                groupBox3.Enabled = true;
                            }
                        }
                        catch(Exception ex1)
                        {
                            MessageBox.Show(ex1.ToString());
                        }

                    }
                    if (openFile.FileName.Contains(".csv") == true)
                    {

                        try { 
                            using (TextFieldParser csvReader = new TextFieldParser(fileaddress))
                            {
                                csvData = new DataTable();
                                csvReader.SetDelimiters(new string[] { "," });
                                csvReader.HasFieldsEnclosedInQuotes = true;
                                string[] colFields = csvReader.ReadFields();

                                foreach (string column in colFields)
                                {
                                    DataColumn datecolumn = new DataColumn(column);
                                    datecolumn.AllowDBNull = true;
                                    csvData.Columns.Add(datecolumn);
                                }

                                while (!csvReader.EndOfData)
                                {
                                    string[] fieldData = csvReader.ReadFields();
                                    //Making empty value as null
                                    for (int i = 0; i < fieldData.Length; i++)
                                    {
                                        if (fieldData[i] == "")
                                        {
                                            fieldData[i] = null;
                                        }
                                    }

                                    csvData.Rows.Add(fieldData);
                                }

                                dataGridView1.DataSource = OneData = csvData;
                                lblStatus.Text = "Data table load Successful";
                                groupBox3.Enabled = true;
                            }
                        }
                        catch (Exception ex1)
                        {
                            MessageBox.Show("Debug on DataMigrateExcel: " + ex1.ToString());
                            string strace = ex1.StackTrace;
                            
                        }

                       }
                    }
                


            }
            //create debug handler
        }

        private void comboBoxTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTable.SelectedIndex > 0)
            {
                selectedtable = comboBoxTable.Text;
            }
        }

        private void btnTableLoad_Click(object sender, EventArgs e)
        {
            Loaddatabletotable();
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
