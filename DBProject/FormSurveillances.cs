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
    public partial class FormSurveillances : Form
    {
        public List<SurveillancesData> Dataset { get; set; }

        public class SurveillancesData
        {
            public int identyfikator_dozorcy { get; set; }
            public int identyfikator_budynku { get; set; }
            public DateTime data_rozpoczecia { get; set; }
            public DateTime data_zakonczenia { get; set; }
        }

        public FormSurveillances()
        {
            InitializeComponent();
            using (var DBContext = new CommunitySystemEntities())
            {
                Dataset = (DBContext
                    .Dozorowania
                    .Select(x => new SurveillancesData
                    {
                        identyfikator_dozorcy = x.id_dozorcy,
                        identyfikator_budynku = x.id_budynku,
                        data_rozpoczecia = x.data_rozpoczecia ?? new DateTime(),
                        data_zakonczenia = x.data_zakonczenia ?? new DateTime()
                    })
                    .ToList());
            }
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.DataSource = Dataset;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void FormSurveillances_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<int> marked = new List<int>();
            foreach (DataGridViewRow x in dataGridView1.SelectedRows)
            {
                marked.Add((int)x.Cells[1].Value);
            }
            var form = new FormBuildings();
            form.dataGridView1.DataSource = form.Dataset.Where(x => marked.Contains(x.identyfikator_budynku)).ToList();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<int> marked = new List<int>();
            foreach (DataGridViewRow x in dataGridView1.SelectedRows)
            {
                marked.Add((int)x.Cells[0].Value);
            }
            var form = new FormCaretakers();
            form.dataGridView1.DataSource = form.Dataset.Where(x => marked.Contains(x.identyfikator_dozorcy)).ToList();
            form.Show();
        }

        private void buttonD_Click(object sender, EventArgs e)
        {
            var list = new List<string>
            {
                Methods.GetMemberName(() => Dataset[0].identyfikator_dozorcy),
                Methods.GetMemberName(() => Dataset[0].identyfikator_budynku),
                Methods.GetMemberName(() => Dataset[0].data_rozpoczecia),
                Methods.GetMemberName(() => Dataset[0].data_zakonczenia)
            };

            var form = new FormSearch(list);

            form.button.MouseClick += new MouseEventHandler((sendere, ee) =>
            {
                var tmpDataset = Dataset;
                if (form.atCursorIsNotEmpty())
                {
                    tmpDataset = tmpDataset.Where(x => x.identyfikator_dozorcy == form.getIntAtCursor()).ToList();
                }
                form.advanceCursor();
                if (form.atCursorIsNotEmpty())
                {
                    tmpDataset = tmpDataset.Where(x => x.identyfikator_budynku == form.getIntAtCursor()).ToList();
                }
                form.advanceCursor();
                if (form.atCursorIsNotEmpty())
                {
                    tmpDataset = tmpDataset.Where(x => x.data_rozpoczecia == form.getDateTimeAtCursor()).ToList();
                }
                form.advanceCursor();
                if (form.atCursorIsNotEmpty())
                {
                    tmpDataset = tmpDataset.Where(x => x.data_zakonczenia == form.getDateTimeAtCursor()).ToList();
                }
                form.resetCursor();
                dataGridView1.DataSource = tmpDataset;
            });

            form.Show();
        }
    }
}
