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
    public partial class FormFaults : Form
    {
        public List<FaultsData> Dataset { get; set; }

        public class FaultsData
        {
            public int identyfikator_usterki { get; set; }
            public int identyfikator_mieszkania { get; set; }
            public string opis { get; set; }
            public string stan { get; set; }
        }

        public FormFaults()
        {
            InitializeComponent();
            using (var DBContext = new CommunitySystemEntities())
            {
                Dataset = (DBContext
                    .Usterki
                    .Select(x => new FaultsData
                    {
                        identyfikator_usterki = x.id_usterki,
                        identyfikator_mieszkania = x.id_mieszkania ?? 0,
                        opis = x.opis,
                        stan = x.stan
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
            var form = new FormRepairs();
            form.dataGridView1.DataSource = form.Dataset.Where(x => marked.Contains(x.identyfikator_usterki)).ToList();
            form.Show();
        }
    }
}
