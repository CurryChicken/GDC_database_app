using System;
using System.Data;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic.FileIO;
using ExcelDataReader;

namespace GDC_database_app
{
    public partial class DataMigrateExcel : Form
    {
        public DataMigrateExcel()
        {
            InitializeComponent();
        }

        private string fileaddress;
        private DataTable csvData;
        private DataTable xlsData;
        private void DataMigrateExcel_Load(object sender, EventArgs e)
        {

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
                                xlsData = dataset.Tables[0];

                                dataGridView1.DataSource = xlsData;
                            }
                        }
                        catch
                        {

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

                                dataGridView1.DataSource = csvData;
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
    }
}
