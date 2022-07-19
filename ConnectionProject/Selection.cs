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
    public partial class Selection : Form
    {
        public Selection()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            connection co = new connection();
            co.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            SelectOneRow row = new SelectOneRow();
            row.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            SelectMultiRow multiRow = new SelectMultiRow();
            multiRow.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            ConnectionForm connectionForm = new ConnectionForm();
            connectionForm.Show();
        }
    }
}
