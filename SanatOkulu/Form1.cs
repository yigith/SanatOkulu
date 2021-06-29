
using SanatOkulu.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SanatOkulu
{
    public partial class Form1 : Form
    {
        SanatOkuluContext db = new SanatOkuluContext();

        public Form1()
        {
            InitializeComponent();
            SanatcileriYukle();
        }

        private void SanatcileriYukle()
        {
            cboSanatci.DataSource = db.Sanatcilar.OrderBy(x => x.Ad).ToList();
            cboSanatci.ValueMember = "Id";
            cboSanatci.DisplayMember = "Ad";
        }

        private void pboYeniSanatci_Click(object sender, EventArgs e)
        {
            var frm = new SanatciForm(db);
            if (DialogResult.OK == frm.ShowDialog())
            {
                SanatcileriYukle();
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            string ad = txtAd.Text.Trim();

            if (ad == "")
            {
                MessageBox.Show("Lütfen eserini adını belirtiniz.");
                return;
            }

            if (cboSanatci.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen bir sanatçı seçiniz.");
                return;
            }
        }
    }
}
