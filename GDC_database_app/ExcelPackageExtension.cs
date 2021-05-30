using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GDC_database_app
{
    public static class ExcelPackageExtension
    {
        public static DataTable dataTable(this ExcelPackage package)
        {
            ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();
            DataTable table = new DataTable();
            try
            {
                foreach (var firstRowCell in worksheet.Cells[1, 1, 1, worksheet.Dimension.End.Column])
                {
                    table.Columns.Add(firstRowCell.Text);
                }
                for (var rowNumber = 2; rowNumber <= worksheet.Dimension.End.Row; rowNumber++)
                {
                    var row = worksheet.Cells[rowNumber, 1, rowNumber, worksheet.Dimension.End.Column];
                    var newRow = table.NewRow();
                    foreach (var cell in row)
                    {
                        newRow[cell.Start.Column - 1] = cell.Text;
                    }
                    table.Rows.Add(newRow);
                }
                return table;
            }
            catch (Exception ex1)
            {
                MessageBox.Show("Debug on DataMigrateExcel = " + ex1.ToString());
                return table;
            }
        }


    }
}
