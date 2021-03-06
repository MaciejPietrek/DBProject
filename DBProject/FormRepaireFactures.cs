﻿using System;
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
    public partial class FormRepaireFactures : Form
    {
        public List<RepairFacturesData> Dataset { get; set; }

        public class RepairFacturesData
        {
            public int identyfikator_faktury { get; set; }
            public int identyfikator_naprawy { get; set; }
            public float cena { get; set; }
            public int numer_faktury { get; set; }
            public DateTime data_platnosci { get; set; }
        }

        public FormRepaireFactures()
        {
            InitializeComponent();
            using (var DBContext = new CommunitySystemEntities())
            {
                Dataset = (DBContext
                    .FakturyNapraw
                    .Select(x => new RepairFacturesData
                    {
                        identyfikator_faktury = x.id_faktury,
                        identyfikator_naprawy = x.id_naprawy ?? 0,
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

        private void buttonD_Click(object sender, EventArgs e)
        {
            var list = new List<string>
            {
                Methods.GetMemberName(() => Dataset[0].identyfikator_faktury),
                Methods.GetMemberName(() => Dataset[0].identyfikator_naprawy),
                Methods.GetMemberName(() => Dataset[0].cena),
                Methods.GetMemberName(() => Dataset[0].numer_faktury),
                Methods.GetMemberName(() => Dataset[0].data_platnosci)
            };

            var form = new FormSearch(list);

            form.button.MouseClick += new MouseEventHandler((sendere, ee) =>
            {
                var tmpDataset = Dataset;
                if (form.atCursorIsNotEmpty())
                {
                    tmpDataset = tmpDataset.Where(x => x.identyfikator_faktury == form.getIntAtCursor()).ToList();
                }
                form.advanceCursor();
                if (form.atCursorIsNotEmpty())
                {
                    tmpDataset = tmpDataset.Where(x => x.identyfikator_naprawy == form.getIntAtCursor()).ToList();
                }
                form.advanceCursor();
                if (form.atCursorIsNotEmpty())
                {
                    tmpDataset = tmpDataset.Where(x => x.cena == form.getIntAtCursor()).ToList();
                }
                form.advanceCursor();
                if (form.atCursorIsNotEmpty())
                {
                    tmpDataset = tmpDataset.Where(x => x.numer_faktury == form.getIntAtCursor()).ToList();
                }
                form.advanceCursor();
                if (form.atCursorIsNotEmpty())
                {
                    tmpDataset = tmpDataset.Where(x => x.data_platnosci == form.getDateTimeAtCursor()).ToList();
                }
                form.resetCursor();
                dataGridView1.DataSource = tmpDataset;
            });

            form.Show();
        }
    }
}
