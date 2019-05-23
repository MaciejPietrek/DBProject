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
    public partial class FormTenants : Form
    {
        public List<TenatntsData> Dataset { get; set; }

        public class TenatntsData
        {
            public int identyfikator_najemcy { get; set; }
            public string numer_telefonu { get; set; }
            public string imie { get; set; }
            public string nazwisko { get; set; }
            public string PESEL { get; set; }
        }

        public FormTenants()
        {
            InitializeComponent();
            using (var DBContext = new CommunitySystemEntities())
            {
                Dataset = (DBContext
                    .Najemcy
                    .Select(x => new TenatntsData
                    {
                        identyfikator_najemcy = x.id_najemcy,
                        numer_telefonu = x.nr_telefonu,
                        imie = x.imie,
                        nazwisko = x.nazwisko,
                        PESEL = x.PESEL
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
            var form = new FormRentals();
            form.dataGridView1.DataSource = form.Dataset.Where(x => marked.Contains(x.identyfikator_najemcy)).ToList();
            form.Show();
        }

        private void buttonD_Click(object sender, EventArgs e)
        {
            var list = new List<string>
            {
                Methods.GetMemberName(() => Dataset[0].identyfikator_najemcy),
                Methods.GetMemberName(() => Dataset[0].numer_telefonu),
                Methods.GetMemberName(() => Dataset[0].imie),
                Methods.GetMemberName(() => Dataset[0].nazwisko),
                Methods.GetMemberName(() => Dataset[0].PESEL)
            };

            var form = new FormSearch(list);

            form.button.MouseClick += new MouseEventHandler((sendere, ee) =>
            {
                var tmpDataset = Dataset;
                if (form.atCursorIsNotEmpty())
                {
                    tmpDataset = tmpDataset.Where(x => x.identyfikator_najemcy == form.getIntAtCursor()).ToList();
                }
                form.advanceCursor();
                if (form.atCursorIsNotEmpty())
                {
                    tmpDataset = tmpDataset.Where(x => x.numer_telefonu == form.getStringAtCursor()).ToList();
                }
                form.advanceCursor();
                if (form.atCursorIsNotEmpty())
                {
                    tmpDataset = tmpDataset.Where(x => x.imie == form.getStringAtCursor()).ToList();
                }
                form.advanceCursor();
                if (form.atCursorIsNotEmpty())
                {
                    tmpDataset = tmpDataset.Where(x => x.nazwisko == form.getStringAtCursor()).ToList();
                }
                form.advanceCursor();
                if (form.atCursorIsNotEmpty())
                {
                    tmpDataset = tmpDataset.Where(x => x.PESEL == form.getStringAtCursor()).ToList();
                }
                form.resetCursor();
                dataGridView1.DataSource = tmpDataset;
            });

            form.Show();
        }
    }
}
