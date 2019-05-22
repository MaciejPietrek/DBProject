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
    public partial class FormFirms : Form
    {
        public List<FirmsData> Dataset { get; set; }

        public class FirmsData
        {
            public int identyfikator_firmy { get; set; }
            public string NIP { get; set; }
            public string numer_telefonu { get; set; }
            public string nazwa_firmy { get; set; }
        }

        public FormFirms()
        {
            InitializeComponent();
            using (var DBContext = new CommunitySystemEntities())
            {
                Dataset = (DBContext
                    .Firmy
                    .Select(x => new FirmsData
                    {
                        identyfikator_firmy = x.id_firmy,
                        NIP = x.NIP,
                        numer_telefonu = x.nr_telefonu,
                        nazwa_firmy = x.nazwa_firmy
                    })
                    .ToList());
            }
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.DataSource = Dataset;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
