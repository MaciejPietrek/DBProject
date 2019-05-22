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
    public partial class FormRentalFactures : Form
    {
        public List<RentalFacturesData> Dataset { get; set; }

        public class RentalFacturesData
        {
            public int identyfikator_faktury { get; set; }
            public int identyfikator_wynajmnu { get; set; }
            public float cena { get; set; }
            public int numer_faktury { get; set; }
            public DateTime data_platnosci { get; set; }
        }

        public FormRentalFactures()
        {
            InitializeComponent();
            using (var DBContext = new CommunitySystemEntities())
            {
                Dataset = (DBContext
                    .FakturyWynajem
                    .Select(x => new RentalFacturesData
                    {
                        identyfikator_faktury = x.id_faktury,
                        identyfikator_wynajmnu = x.id_wynajem ?? 0,
                        cena = x.cena,
                        numer_faktury = x.numer_faktury,
                        data_platnosci = x.data_platnosci ?? new DateTime(),
                    })
                    .ToList());
            }
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.DataSource = Dataset;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
