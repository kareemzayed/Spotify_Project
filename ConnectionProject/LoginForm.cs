using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
namespace ConnectionProject
{
    public partial class LoginForm : Form
    {
        string ordb = "Data source=orcl;User Id=scott;Password=tiger;";
        OracleConnection conn;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select email from newusers where username=:name and password=:pass";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("name",textBox1.Text);
            cmd.Parameters.Add("pass",textBox2.Text);
            OracleDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Successful Login");
                this.Hide();
                DisAndCon disAndCon = new DisAndCon();
                disAndCon.Show();
            }
            else
            {
                MessageBox.Show("Wrong userName and Password");
            }
            dr.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminORUsers adminORUsers = new AdminORUsers();
            adminORUsers.Show();
        }
    }
}
