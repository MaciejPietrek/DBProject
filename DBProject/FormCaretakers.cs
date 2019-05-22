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
    public partial class FormCaretakers : Form
    {
        public List<CaretakersData> Dataset { get; set; }

        public class CaretakersData
        {
            public int identyfikator_dozorcy { get; set; }
            public string numer_telefonu { get; set; }
            public string imie { get; set; }
            public string nazwisko { get; set; }
            public string PESEL { get; set; }
        }

        public FormCaretakers()
        {
            InitializeComponent();
            using (var DBContext = new CommunitySystemEntities())
            {
                Dataset = (DBContext
                    .Dozorcy
                    .Select(x => new CaretakersData
                    {
                        identyfikator_dozorcy = x.id_dozorcy,
                        numer_telefonu = x.nr_telefonu,
                        imie = x.Imie,
                        nazwisko = x.Nazwisko,
                        PESEL = x.PESEL
                    })
                    .ToList());
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.DataSource = Dataset;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void FormCaretakers_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<int> marked = Methods.getIdFromColumnNO(0, dataGridView1.SelectedRows);
            var form = new FormSurveillances();
            form.dataGridView1.DataSource = form.Dataset.Where(x => marked.Contains(x.identyfikator_dozorcy)).ToList();
            form.Show();
        }
    }
}
