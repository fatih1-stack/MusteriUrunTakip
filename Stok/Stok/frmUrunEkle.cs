using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Stok
{
    public partial class frmUrunEkle : Form
    {
        public frmUrunEkle()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-DP2R8D6;Initial Catalog=StokTakip;Integrated Security=True");
        private void KategoriGetir()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from kategoribilgiler", baglanti);
            SqlDataReader reader = komut.ExecuteReader();
            while (reader.Read())
            {
                comboKategori.Items.Add(reader["kategori"].ToString());
            }
            baglanti.Close();
        }
        private void frmUrunEkle_Load(object sender, EventArgs e)
        {
            KategoriGetir();
        }

        private void comboKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboMarka.Items.Clear();
            comboMarka.Text = "";

            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from markabilgiler where kategori= '"+comboKategori.SelectedItem+"'",baglanti);
            SqlDataReader reader = komut.ExecuteReader();

            while(reader.Read())
            {
                comboMarka.Items.Add(reader["marka"].ToString());
            }
            baglanti.Close();
        }

        private void btnYeniEkle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into urun(barkodno, kategori, marka, urunadi, miktari, alisfiyati, satisfiyati, tarih) values(@barkodno, @kategori, @marka, @urunadi, @miktari, @alisfiyati, @satisfiyati, @tarih)", baglanti);
            komut.Parameters.AddWithValue("@barkodno", txtBarkodNo.Text);
            komut.Parameters.AddWithValue("@kategori", comboKategori.Text);
            komut.Parameters.AddWithValue("@marka", comboMarka.Text);
            komut.Parameters.AddWithValue("@urunadi", txtUrunAdi.Text);
            komut.Parameters.AddWithValue("@miktari", int.Parse(txtMiktari.Text));
            komut.Parameters.AddWithValue("@alisfiyati", double.Parse (txtAlisFiyati.Text));
            komut.Parameters.AddWithValue("@satisfiyati", double.Parse(txtSatisFiyati.Text));
            komut.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Ürün Eklendi!");
            comboMarka.Items.Clear();
            foreach (Control item in groupBox1.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }

                if (item is ComboBox)
                {
                    item.Text = "";
                }
            }
        }

       
    }
}
