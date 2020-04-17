using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityMaker
{
    public partial class DBConnectionForm : Form
    {
        public string dbName = "";
        public string dbserver = "";
        public string dbPort = "";
        public string dbUsername = "";
        public string dbPassword = "";

        public DBConnectionForm()
        {
            InitializeComponent();
        }

        private void btnSqlConnect_Click(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                Properties.Settings.Default.DataBase = textDb.Text;
                Properties.Settings.Default.Server   = textServer.Text;
                Properties.Settings.Default.Port     = Convert.ToInt32(textPort.Text);
                Properties.Settings.Default.Username= textUsername.Text;
                Properties.Settings.Default.password = textPassword.Text;
                Properties.Settings.Default.Save();
            }

           dbName    = textDb.Text;
           dbserver  = textServer.Text;
           dbPort    = textPort.Text;
           dbUsername = textUsername.Text;
           dbPassword = textPassword.Text;
           this.DialogResult = DialogResult.OK;
           this.Close();
        }

        private void DBConnectionForm_Load(object sender, EventArgs e)
        {
            if(Properties.Settings.Default.isSave)
            {
                textDb.Text         =       Properties.Settings.Default.DataBase;
                textServer.Text     =   Properties.Settings.Default.Server;
                textPort.Text       =     Properties.Settings.Default.Port.ToString();
                textUsername.Text   = Properties.Settings.Default.Username;
                textPassword.Text   = Properties.Settings.Default.password;
            }
        }
    }
}
