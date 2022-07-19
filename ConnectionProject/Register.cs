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
    public partial class Register : Form
    {
        string ordb = "Data source=orcl;User Id=scott;Password=tiger;";
        OracleConnection conn;
        public Register()
        {
            InitializeComponent();
        }

        private void Register_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleCommand cm = new OracleCommand();
            cm.Connection = conn;
            cm.CommandText = "insert into newusers values(:id,:name,:email,:pass,:gender)";
            cm.Parameters.Add(":id", textBox4.Text);
            cm.Parameters.Add(":name", textBox1.Text);
            cm.Parameters.Add(":email", textBox2.Text);
            cm.Parameters.Add(":pass", textBox3.Text);
            cm.Parameters.Add(":gender", textBox5.Text);
            int r = cm.ExecuteNonQuery();
            if (r != -1)
            {
                MessageBox.Show("Successfully Registered");
                this.Hide();
                LoginForm login = new LoginForm();
                login.Show();
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenue mainMenue = new MainMenue();
            mainMenue.Show();
        }
    }
}
