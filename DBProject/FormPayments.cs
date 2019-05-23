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

        private void buttonD_Click(object sender, EventArgs e)
        {
            var list = new List<string>
            {
                Methods.GetMemberName(() => Dataset[0].identyfikator_platnosci),
                Methods.GetMemberName(() => Dataset[0].identyfikator_wynajmnu),
                Methods.GetMemberName(() => Dataset[0].data_platnosci),
                Methods.GetMemberName(() => Dataset[0].cena),
                Methods.GetMemberName(() => Dataset[0].tytul)
            };

            var form = new FormSearch(list);

            form.button.MouseClick += new MouseEventHandler((sendere, ee) =>
            {
                var tmpDataset = Dataset;
                if (form.atCursorIsNotEmpty())
                {
                    tmpDataset = tmpDataset.Where(x => x.identyfikator_platnosci == form.getIntAtCursor()).ToList();
                }
                form.advanceCursor();
                if (form.atCursorIsNotEmpty())
                {
                    tmpDataset = tmpDataset.Where(x => x.identyfikator_wynajmnu == form.getIntAtCursor()).ToList();
                }
                form.advanceCursor();
                if (form.atCursorIsNotEmpty())
                {
                    tmpDataset = tmpDataset.Where(x => x.data_platnosci == form.getDateTimeAtCursor()).ToList();
                }
                form.advanceCursor();
                if (form.atCursorIsNotEmpty())
                {
                    tmpDataset = tmpDataset.Where(x => x.cena == form.getFloatAtCursor()).ToList();
                }
                form.advanceCursor();
                if (form.atCursorIsNotEmpty())
                {
                    tmpDataset = tmpDataset.Where(x => x.tytul == form.getStringAtCursor()).ToList();
                }
                form.resetCursor();
                dataGridView1.DataSource = tmpDataset;
            });

            form.Show();
        }
    }
}
