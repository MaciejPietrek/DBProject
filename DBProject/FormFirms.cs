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

        private void buttonD_Click(object sender, EventArgs e)
        {
            var list = new List<string>
            {
                Methods.GetMemberName(() => Dataset[0].identyfikator_firmy),
                Methods.GetMemberName(() => Dataset[0].NIP),
                Methods.GetMemberName(() => Dataset[0].nazwa_firmy)
            };

            var form = new FormSearch(list);

            form.button.MouseClick += new MouseEventHandler((sendere, ee) =>
            {
                var tmpDataset = Dataset;
                if (form.atCursorIsNotEmpty())
                {
                    var a = int.Parse(form.Fields[0].Item2.Text);
                    tmpDataset = tmpDataset.Where(x => x.identyfikator_firmy == form.getIntAtCursor()).ToList();
                }
                form.advanceCursor();
                if (form.atCursorIsNotEmpty())
                {
                    var a = form.Fields[1].Item2.Text;
                    tmpDataset = tmpDataset.Where(x => x.NIP == form.getStringAtCursor()).ToList();
                }
                form.advanceCursor();
                if (form.atCursorIsNotEmpty())
                {
                    var a = form.Fields[2].Item2.Text;
                    tmpDataset = tmpDataset.Where(x => x.nazwa_firmy == form.getStringAtCursor()).ToList();
                }
                form.resetCursor();
                dataGridView1.DataSource = tmpDataset;
            });

            form.Show();
        }
    }
}
