using System.Data;
using System.Data.OleDb;

namespace DataGuard.Utilities
{
    public class ExcelHelper
    {
        public static DataTable ReadAsTable(string xlsxFile, string sheetName = "Sheet1")
        {
            var connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0;HDR=No;IMEX=0\"", xlsxFile);
            var adapter = new OleDbDataAdapter($"SELECT * FROM [{sheetName}$]", connectionString);

            var ds = new DataSet();
            adapter.Fill(ds, sheetName);

            return ds.Tables[sheetName];
        }
    }
}