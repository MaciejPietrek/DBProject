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
    public partial class FormRentals : Form
    {
        public List<RentalsData> Dataset { get; set; }

        public class RentalsData
        {
            public int identyfikator_wynajmnu { get; set; }
            public int identyfikator_mieszkania { get; set; }
            public DateTime data_rozpoczecia { get; set; }
            public DateTime data_zakończenia { get; set; }
            public int identyfikator_najemcy { get; set; }
            public float cena_miesieczna { get; set; }
        }

        public FormRentals()
        {
            InitializeComponent();
            using (var DBContext = new CommunitySystemEntities())
            {
                Dataset = (DBContext
                    .Wynajmy
                    .Select(x => new RentalsData
                    {
                        identyfikator_wynajmnu = x.id_wynajmu,
                        identyfikator_mieszkania = x.id_najemcy ?? 0,
                        data_rozpoczecia = x.data_rozpoczecia ?? new DateTime(),
                        data_zakończenia = x.data_zakonczenia ?? new DateTime(),
                        identyfikator_najemcy = x.id_najemcy ?? 0,
                        cena_miesieczna = x.cena_miesieczna ?? 0
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
            var form = new FormPayments();
            form.dataGridView1.DataSource = form.Dataset.Where(x => marked.Contains(x.identyfikator_wynajmnu)).ToList();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<int> marked = Methods.getIdFromColumnNO(0, dataGridView1.SelectedRows);
            var form = new FormRentalFactures();
            form.dataGridView1.DataSource = form.Dataset.Where(x => marked.Contains(x.identyfikator_wynajmnu)).ToList();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<int> marked = Methods.getIdFromColumnNO(1, dataGridView1.SelectedRows);
            var form = new FormFlats();
            form.dataGridView1.DataSource = form.Dataset.Where(x => marked.Contains(x.identyfikator_mieszkania)).ToList();
            form.Show();
        }
    }
}
