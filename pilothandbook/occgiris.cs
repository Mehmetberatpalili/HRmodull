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

namespace pilothandbook
{
    public partial class occgiris : Form
    {
        SqlConnection baglanti;
        SqlCommand komut;
        SqlDataAdapter da;
        public occgiris()
        {
            InitializeComponent();
        }
        void Pilotpanel()
        {
            baglanti = new SqlConnection("server=MEHMETPALILI; Initial Catalog=pilothandbook;Integrated Security=SSPI");
            baglanti.Open();
            da = new SqlDataAdapter("SELECT * FROM pilot_table", baglanti);
            DataTable tablo1 = new DataTable();
            da.Fill(tablo1);
            
            baglanti.Close();

        }
        public static string gonderilecekAdminAdSoyad;
        private void textbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void sifreunuttum_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult sonuc;
            sonuc = MessageBox.Show("Çıkmak İstediğinizden Emin misiniz ?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (sonuc == DialogResult.No)
            {

            }
            if (sonuc == DialogResult.Yes)
            {
                this.Close();
                Application.Exit();
            }

        }

        private void btnGiris_MouseHover(object sender, EventArgs e)
        {

            btnGiris.BackColor = Color.Black;
            btnGiris.ForeColor = Color.White;

        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            baglanti = new SqlConnection("server=MEHMETPALILI; Initial Catalog=pilothandbook;Integrated Security=SSPI");
            string kullanici_ad = txtAd.Text;
            string kullanici_sifre = txtSifre.Text;
            veritabani islemim = new veritabani();
            islemim.girisYap(kullanici_ad, kullanici_sifre, this);
            string loggiris = "INSERT INTO log_kayitlari (log_kayit,log_tarih,log_kullanici) VALUES(@log_kayit,@log_tarih,@log_kullanici)";
            string kullaniciAdi = txtAd.Text;
            string logKayitMesaji = kullaniciAdi + " kullanıcısı OCC sistemine giriş yaptı.";
            komut = new SqlCommand(loggiris, baglanti);
            komut.Parameters.AddWithValue("@log_tarih", DateTime.Now);
            komut.Parameters.AddWithValue("@log_kullanici", txtAd.Text);
            komut.Parameters.AddWithValue("@log_kayit", logKayitMesaji);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        private void btnGiris_MouseLeave(object sender, EventArgs e)
        {
            btnGiris.BackColor = Color.Transparent;

        }

        private void txtAd_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (sender as TextBox); // seçtirdim
            txt.CharacterCasing = CharacterCasing.Upper; // yazılanın hep büyük olmasını sağlar.

        }

        private void txtSifre_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (sender as TextBox); // seçtirdim
            txt.CharacterCasing = CharacterCasing.Upper; // yazılanın hep büyük olmasını sağlar
        }

        private void occgiris_Load(object sender, EventArgs e)
        {
            txtSifre.PasswordChar = '*'; // occ giriş şifre gizleme char olduğu için tek nokta
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
