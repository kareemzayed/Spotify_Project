using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConnectionProject
{
    public partial class ConnectionForm : Form
    {
        public ConnectionForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                this.Hide();
                Selection s = new Selection();
                s.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Disconnected ds = new Disconnected();
            ds.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminORUsers adminORUsers = new AdminORUsers();
            adminORUsers.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            CrystalForm2 crystalForm2 = new CrystalForm2();
            crystalForm2.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
