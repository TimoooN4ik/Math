using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Work
{
    public partial class ShowDB : Form
    {
        AppContext db;
        List<TC> tc;
        List<calc> calcs;
        List<FHC> fhc;
        public ShowDB()
        {
            InitializeComponent();

            db = new AppContext();

            comboBox1.Items.Add("Температурные поправки");
            comboBox1.Items.Add("Значение констант");
            comboBox1.Items.Add("Значения коэффициента модели");
            comboBox1.SelectedIndex = 1;
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text == "Температурные поправки")
            {
                tc = db.TCs.ToList();
                dataGridView1.DataSource = tc;
            }
            if(comboBox1.Text == "Значение констант")
            {
                calcs = db.calcs.ToList();
                dataGridView1.DataSource = calcs;
            }
            if(comboBox1.Text == "Значения коэффициента модели")
            {
                fhc = db.FHCs.ToList();
                dataGridView1.DataSource = fhc;
            }
        }
    }
}
