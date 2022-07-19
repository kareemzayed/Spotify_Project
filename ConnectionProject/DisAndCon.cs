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
    public partial class DisAndCon : Form
    {
        public DisAndCon()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Disconnected ds = new Disconnected();
            ds.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminORUsers adminORUsers = new AdminORUsers();
            adminORUsers.Show();
        }
    }
}
