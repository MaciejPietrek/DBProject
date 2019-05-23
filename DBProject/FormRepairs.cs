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

        private void buttonD_Click(object sender, EventArgs e)
        {
            var list = new List<string>
            {
                Methods.GetMemberName(() => Dataset[0].identyfikator_naprawy),
                Methods.GetMemberName(() => Dataset[0].identyfikator_usterki),
                Methods.GetMemberName(() => Dataset[0].identyfikator_firmy),
                Methods.GetMemberName(() => Dataset[0].stan),
                Methods.GetMemberName(() => Dataset[0].data_zlecenia),
                Methods.GetMemberName(() => Dataset[0].data_rozpoczecia),
                Methods.GetMemberName(() => Dataset[0].data_zakonczenia)
            };

            var form = new FormSearch(list);

            form.button.MouseClick += new MouseEventHandler((sendere, ee) =>
            {
                var tmpDataset = Dataset;
                if (form.atCursorIsNotEmpty())
                {
                    tmpDataset = tmpDataset.Where(x => x.identyfikator_naprawy == form.getIntAtCursor()).ToList();
                }
                form.advanceCursor();
                if (form.atCursorIsNotEmpty())
                {
                    tmpDataset = tmpDataset.Where(x => x.identyfikator_usterki == form.getIntAtCursor()).ToList();
                }
                form.advanceCursor();
                if (form.atCursorIsNotEmpty())
                {
                    tmpDataset = tmpDataset.Where(x => x.identyfikator_firmy == form.getIntAtCursor()).ToList();
                }
                form.advanceCursor();
                if (form.atCursorIsNotEmpty())
                {
                    tmpDataset = tmpDataset.Where(x => x.stan == form.getStringAtCursor()).ToList();
                }
                form.advanceCursor();
                if (form.atCursorIsNotEmpty())
                {
                    tmpDataset = tmpDataset.Where(x => x.data_zlecenia == form.getDateTimeAtCursor()).ToList();
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
