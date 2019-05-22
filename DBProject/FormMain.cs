using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBProject
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new FormBuildings();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form = new FormCaretakers();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var form = new FormSurveillances();
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var form = new FormSupervisor();
            form.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var form = new FormPaymasters();
            form.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var form = new FormTenants();
            form.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var form = new FormFirms();
            form.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var form = new FormPayments();
            form.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var form = new FormRentalFactures();
            form.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            var form = new FormRepaireFactures();
            form.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            var form = new FormRepairs();
            form.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            var form = new FormFaults();
            form.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            var form = new FormFlats();
            form.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            var form = new FormRentals();
            form.Show();
        }
    }
}
