using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stok
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-DP2R8D6;Initial Catalog=StokTakip;Integrated Security=True");
        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnMusteriEkle_Click(object sender, EventArgs e)
        {
            frmMusteriEkle frmMusteriEkle = new frmMusteriEkle();
            frmMusteriEkle.ShowDialog();
        }

        private void btnMusteriListele_Click(object sender, EventArgs e)
        {
            frmMusteriListeleme listele = new frmMusteriListeleme();
            listele.ShowDialog();
        
        }

        private void btnUrunEkle_Click(object sender, EventArgs e)
        {
            frmUrunEkle ekle = new frmUrunEkle();
            ekle.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmKategori frmKategori = new frmKategori();
            frmKategori.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmMarka frmMarka = new frmMarka();
            frmMarka.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
      
        }
     
    }
}
