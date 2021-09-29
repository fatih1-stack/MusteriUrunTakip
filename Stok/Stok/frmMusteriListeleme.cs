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
    public partial class frmMusteriListeleme : Form
    {
        public frmMusteriListeleme()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-DP2R8D6;Initial Catalog=StokTakip;Integrated Security=True");
        DataSet dataSet = new DataSet();
        private void frmMusteriListeleme_Load(object sender, EventArgs e)
        {
            KayitGöster();

        }

        private void KayitGöster()
        {
            baglanti.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select * from musteriler", baglanti);
            sqlDataAdapter.Fill(dataSet, "musteriler");
            dataGridView1.DataSource = dataSet.Tables["musteriler"];
            baglanti.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTc.Text = dataGridView1.CurrentRow.Cells["tc"].Value.ToString();
            txtAdSoyad.Text = dataGridView1.CurrentRow.Cells["adsoyad"].Value.ToString();
            txtTelefon.Text = dataGridView1.CurrentRow.Cells["telefon"].Value.ToString();
            txtAdres.Text = dataGridView1.CurrentRow.Cells["adres"].Value.ToString();
            txtEmail.Text = dataGridView1.CurrentRow.Cells["email"].Value.ToString();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update musteriler set adsoyad=@adsoyad, telefon=@telefon, adres=@adres, email=@email where tc=@tc",baglanti);
            komut.Parameters.AddWithValue("@tc", txtTc.Text);
            komut.Parameters.AddWithValue("@adsoyad", txtAdSoyad.Text);
            komut.Parameters.AddWithValue("@telefon", txtTelefon.Text);
            komut.Parameters.AddWithValue("@adres", txtAdres.Text);
            komut.Parameters.AddWithValue("@email", txtEmail.Text);


            komut.ExecuteNonQuery();
            baglanti.Close();
            dataSet.Tables["musteriler"].Clear();
            KayitGöster();
            MessageBox.Show("Müşteri Kaydı Güncellendi");

            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from musteriler where tc='"+dataGridView1.CurrentRow.Cells["tc"].Value.ToString() + "'",baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            dataSet.Tables["musteriler"].Clear();
            KayitGöster();
            MessageBox.Show("Müşteri Silindi!");
        }

        private void txtTcAra_TextChanged(object sender, EventArgs e)
        {
            DataTable tablo = new DataTable();
            baglanti.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from musteriler where tc like '%"+txtTcAra.Text+"%' ",baglanti);

            dataAdapter.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
