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
    public partial class FormFlats : Form
    {
        public List<FlatsData> Dataset { get; set; }

        public class FlatsData
        {
            public int identyfikator_mieszkania { get; set; }
            public int identyfikator_budynku { get; set; }
            public int numer { get; set; }
            public float metraz { get; set; }
            public string opis { get; set; }
        }

        public FormFlats()
        {
            InitializeComponent();
            using (var DBContext = new CommunitySystemEntities())
            {
                Dataset = (DBContext
                    .Mieszkania
                    .Select(x => new FlatsData
                    {
                        identyfikator_mieszkania = x.id_mieszkania,
                        identyfikator_budynku = x.id_budynku ?? 0,
                        numer = x.numer,
                        metraz = x.metraz ?? 0,
                        opis = x.opis
                    })
                    .ToList());
            }
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.DataSource = Dataset;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<int> marked = Methods.getIdFromColumnNO(0, dataGridView1.SelectedRows);
            var form = new FormRentals();
            form.dataGridView1.DataSource = form.Dataset.Where(x => marked.Contains(x.identyfikator_mieszkania)).ToList();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<int> marked = Methods.getIdFromColumnNO(0, dataGridView1.SelectedRows);
            var form = new FormFaults();
            form.dataGridView1.DataSource = form.Dataset.Where(x => marked.Contains(x.identyfikator_mieszkania)).ToList();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<int> marked = Methods.getIdFromColumnNO(1, dataGridView1.SelectedRows);
            var form = new FormBuildings();
            form.dataGridView1.DataSource = form.Dataset.Where(x => marked.Distinct().Contains(x.identyfikator_budynku)).ToList();
            form.Show();
        }
    }
}
