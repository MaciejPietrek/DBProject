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
    public partial class FormPayments : Form
    {
        public List<PaymentsData> Dataset { get; set; }

        public class PaymentsData
        {
            public int identyfikator_platnosci { get; set; }
            public int identyfikator_wynajmnu { get; set; }
            public DateTime data_platnosci { get; set; }
            public float cena { get; set; }
            public string tytul { get; set; }
        }

        public FormPayments()
        {
            InitializeComponent();
            using (var DBContext = new CommunitySystemEntities())
            {
                Dataset = (DBContext
                    .Platnosci
                    .Select(x => new PaymentsData
                    {
                        identyfikator_platnosci = x.id_platnosci,
                        identyfikator_wynajmnu = x.id_wynajmu ?? 0,
                        data_platnosci = x.data_platnosci ?? new DateTime(),
                        cena = x.cena,
                        tytul = x.tytul
                    })
                    .ToList());
            }
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.DataSource = Dataset;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
