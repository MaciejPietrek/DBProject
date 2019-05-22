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
    public partial class FormRepairs : Form
    {
        public List<RepairesData> Dataset { get; set; }

        public class RepairesData
        {
            public int identyfikator_naprawy { get; set; }
            public int identyfikator_usterki { get; set; }
            public int identyfikator_firmy { get; set; }
            public string stan { get; set; }
            public DateTime data_zlecenia { get; set; }
            public DateTime data_rozpoczecia { get; set; }
            public DateTime data_zakonczenia { get; set; }
        }

        public FormRepairs()
        {
            InitializeComponent();
            using (var DBContext = new CommunitySystemEntities())
            {
                Dataset = (DBContext
                    .Naprawy
                    .Select(x => new RepairesData
                    {
                        identyfikator_naprawy = x.id_naprawy,
                        identyfikator_usterki = x.id_usterki ?? 0,
                        identyfikator_firmy = x.id_firmy ?? 0,
                        stan = x.stan,
                        data_zlecenia = x.data_zlecenia ?? new DateTime(),
                        data_rozpoczecia = x.data_rozpoczecia ?? new DateTime(),
                        data_zakonczenia = x.data_ukonczenia ?? new DateTime()
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
            var form = new FormRepaireFactures();
            form.dataGridView1.DataSource = form.Dataset.Where(x => marked.Contains(x.identyfikator_naprawy)).ToList();
            form.Show();
        }
    }
}
