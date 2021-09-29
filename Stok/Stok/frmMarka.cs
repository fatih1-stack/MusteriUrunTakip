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
    public partial class frmMarka : Form
    {
        public frmMarka()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-DP2R8D6;Initial Catalog=StokTakip;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e) { 
                    baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into markabilgiler(kategori,marka)  values('"+comboBox1.Text+"','" + textBox1.Text + "')",baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            textBox1.Text = "";
            comboBox1.Text = "";
            MessageBox.Show("Marka Eklendi!!");

    }
        private void KategoriGetir()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from kategoribilgiler", baglanti);
        SqlDataReader reader = komut.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader["kategori"].ToString());
            }
    baglanti.Close();
        }

        private void frmMarka_Load(object sender, EventArgs e)
        {
            KategoriGetir();
        }
    }
}
