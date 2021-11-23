using System.Data.OleDb;
using System.Data;
using System.IO;



namespace DEMOMVC.Models
{
    public class ExcelProcess
    {
        public DataTable ReadDataFromExcelFile(string filepath, bool removeRow0)
        {
            string conectionString = "";
            string fileExtention = filepath.Substring(filepath.Length - 4).ToLower();
            if (fileExtention.IndexOf("xlsx") < 0)
            {
                conectionString = "Provider = Microsoft.Jet.OLEDB.4.0;Data Source=" + filepath + ";Extended Properties=Excel 8.0";

            }
            else
            {
                conectionString = "Provider = Microsoft.ACE.OLEDB.12.0;Data Source=" + filepath + ";Extended Properties=\"Excel 12.0 Xml;HDR=NO\"";
            }
            OleDbConnection oledbcon = new OleDbConnection(conectionString);
            DataTable data = null;
            try
            {
                oledbcon.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM [sheet1$]", oledbcon);
                OleDbDataAdapter oleda = new OleDbDataAdapter();
                oleda.SelectCommand = cmd;
                DataSet ds = new DataSet();
                oleda.Fill(ds);
                data = ds.Tables[0];
            }
            catch
            {

            }
            finally
            {
                oledbcon.Close();
            }
            return data;
        }
    }
}