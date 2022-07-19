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
    public partial class AdminLogin : Form
    {
        string ordb = "Data source=orcl;User Id=scott;Password=tiger;";
        OracleConnection conn;
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void AdminLogin_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select email from admin where adminname=:name and password=:pass ";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("name", textBox1.Text);
            cmd.Parameters.Add("pass", textBox2.Text);
            OracleDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Successful Login");
                this.Hide();
                ConnectionForm connectionForm = new ConnectionForm();
                connectionForm.Show();
            }
            else
            {
                MessageBox.Show("Wrong userName and Password");
            }
            dr.Close();
        }

        private void AdminLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminORUsers adminORUsers = new AdminORUsers();
            adminORUsers.Show();
        }
    }
}
