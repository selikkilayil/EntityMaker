using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityMaker
{
    class CGeneratorSqlServer : IGenerator
    {
        public SqlConnection cn;
        public delegate void StatusMessage(string message);
        public StatusMessage LogHandler;
        public string template;

        public CGeneratorSqlServer(string tplate)
        {
            template = tplate;
            cn = new SqlConnection();
        }

        public Tuple<bool,string> Initilize(string constr)
        {
            try
            {
                cn.Close();
                cn.ConnectionString = constr;
                cn.Open();
            }
            catch (Exception e)
            {
                return new Tuple<bool, string>(false,e.Message);
            }
            return new Tuple<bool, string>(true, "Success");

        }

      



        public Tuple<bool,string> Generate(string tableName)
        {
            try
            {
                bool iOpened = false;
                if (cn.State == ConnectionState.Closed) { iOpened = true; cn.Open(); }

                SqlCommand cmd = new SqlCommand("Select top 1 * from " + tableName + " ", cn);
                //MySqlCommand cmd = new MySqlCommand("CALL RSP_GetItineraryResRemarks(180000944);", cn);

                SqlDataReader r = cmd.ExecuteReader();
                r.Read();
                Dictionary<string, string> Fields = GetFields(r);
                r.Close();

                string[] members = new string[Fields.Count];
                string[] loaders = new string[Fields.Count];

                int i = 0;
                foreach (KeyValuePair<String, String> entry in Fields)
                {
                    members[i] = "\t\tpublic [TYPE] [NAME];";
                    loaders[i] = "\t\t\tif(r[\"[NAME]\"].GetType().ToString() != \"System.DBNull\") [NAME] = ([TYPE])r[\"[NAME]\"];";

                    members[i] = members[i].Replace("[TYPE]", entry.Value).Replace("[NAME]", entry.Key);
                    loaders[i] = loaders[i].Replace("[TYPE]", entry.Value).Replace("[NAME]", entry.Key);
                    i++;
                }

                string tmp = template.Replace("Template", tableName);
                tmp = tmp.Replace("//public members", "\r\n" + string.Join("\r\n", members));
                tmp = tmp.Replace("//load members", "\r\n" + string.Join("\r\n", loaders));

                if (iOpened) cn.Close();

                string path = "D:\\Bus\\" + tableName + ".cs";
                //if (File.Exists(path)) File.Delete(path);


                //File.WriteAllText(path, tmp);


                return new Tuple<bool, string>(true, tmp);
            }
            catch (Exception ex)
            {
                return new Tuple<bool, string>(false, ex.Message);
            }
           

         
        }

        private Dictionary<string, string> GetFields(SqlDataReader r)
        {
            DataTable schemaTable = r.GetSchemaTable();
            Dictionary<string, string> Field = new Dictionary<string, string>();

            foreach (DataRow row in schemaTable.Rows)
            {
                string column = row["ColumnName"].ToString();
                string type = row["DataType"].ToString();
                Field.Add(column, type);
            }

            return Field;

        }


    }

    
}
