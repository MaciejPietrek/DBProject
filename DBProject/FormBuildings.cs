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
    public partial class FormBuildings : Form
    {
        public List<BuildingsData> Dataset { get; set; }

        public class BuildingsData
        {
            public int identyfikator_budynku { get; set; }
            public string adres_budynku { get; set; }
        }

        public FormBuildings()
        {
            InitializeComponent();
            using (var DBContext = new CommunitySystemEntities())
            {
                Dataset = (DBContext
                    .Budynki
                    .Select(x => new BuildingsData { identyfikator_budynku = x.id_budynku, adres_budynku = x.adres_budynku })
                    .ToList());
            }
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.DataSource = Dataset;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void FormBuildings_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<int> marked = Methods.getIdFromColumnNO(0, dataGridView1.SelectedRows);
            var form = new FormSurveillances();
            form.dataGridView1.DataSource = form.Dataset.Where(x => marked.Contains(x.identyfikator_budynku)).ToList();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<int> marked = Methods.getIdFromColumnNO(0, dataGridView1.SelectedRows);
            var form = new FormFlats();
            form.dataGridView1.DataSource = form.Dataset.Where(x => marked.Contains(x.identyfikator_budynku)).ToList();
            form.Show();
        }

        /// <summary>
        /// search button click handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonD_Click(object sender, EventArgs e)
        {

        }
    }
}
