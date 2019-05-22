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
    public partial class FormSupervisor : Form
    {
        public List<SupervisorData> Dataset { get; set; }

        public class SupervisorData
        {
            public int identyfikator_budynku { get; set; }
            public string adres_budynku { get; set; }
        }

        public FormSupervisor()
        {
            InitializeComponent();
            using (var DBContext = new CommunitySystemEntities())
            {
                Dataset = (DBContext
                    .Budynki
                    .Select(x => new SupervisorData
                    {
                        identyfikator_budynku = x.id_budynku,
                        adres_budynku = x.adres_budynku
                    })
                    .ToList());
            }
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.DataSource = Dataset;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
