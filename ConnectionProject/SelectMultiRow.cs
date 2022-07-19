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
    public partial class SelectMultiRow : Form
    {
        OracleConnection con;
        string ordb = "data source = orcl; user id =scott; password=tiger;";

        public SelectMultiRow()
        {
            InitializeComponent();
        }

        private void SelectMultiRow_Load(object sender, EventArgs e)
        {
            con = new OracleConnection(ordb);
            con.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = "GetMusicName";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("name", textBox1.Text);
            cmd.Parameters.Add("User", OracleDbType.RefCursor, ParameterDirection.Output);
            OracleDataReader dr = cmd.ExecuteReader();
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0]);
                comboBox2.Items.Add(dr["typeofuser"]);
                comboBox3.Items.Add(dr["gender"]);

            }
            dr.Close();
        }

        private void SelectMultiRow_FormClosing(object sender, FormClosingEventArgs e)
        {
            con.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Selection selection = new Selection();
            selection.Show();
        }
    }
}
