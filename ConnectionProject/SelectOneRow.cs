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
    public partial class SelectOneRow : Form
    {
        string ordb = "Data Source=orcl;User id=scott ;password=tiger;";
        OracleConnection conn;
        public SelectOneRow()
        {
            InitializeComponent();
        }

        private void SelectOneRow_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select username from users";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0]);
            }
            dr.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "OneRow";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("name", comboBox1.SelectedItem.ToString());
            cmd.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
            cmd.ExecuteNonQuery();
            try
            {
                comboBox2.Items.Clear();
                MessageBox.Show("done");
                comboBox2.Items.Add(Convert.ToInt32(cmd.Parameters["id"].Value.ToString()));
            }
            catch
            {
                MessageBox.Show(comboBox1.SelectedItem.ToString());
            }


        }

        private void SelectOneRow_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Selection selection = new Selection();
            selection.Show();
        }
    }
}
