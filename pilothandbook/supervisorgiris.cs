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

namespace pilothandbook
{
    public partial class supervisorgiris : Form
    {

        SqlConnection baglanti;
        SqlCommand komut;
        SqlDataAdapter da;
        public supervisorgiris()
        {
            InitializeComponent();
        }
        public static string occgiris;

        private void supervisorgiris_Load(object sender, EventArgs e)
        {
            txtParola.PasswordChar = '*'; // occ giriş şifre gizleme char olduğu için tek nokta
            // labele giriş yapan kişinin ismini yaz
        }

        private void txtAd_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (sender as TextBox); // seçtirdim
            txt.CharacterCasing = CharacterCasing.Upper; // yazılanın hep büyük olmasını sağlar.
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            baglanti = new SqlConnection("server=MEHMETPALILI; Initial Catalog=pilothandbook;Integrated Security=SSPI");
            string kullanici_ad = txtAdi.Text;
            string kullanici_sifre = txtParola.Text;
            veritabani3 fonksiyonum = new veritabani3();
            fonksiyonum.girisYap(kullanici_ad, kullanici_sifre, this);
            string loggiris = "INSERT INTO log_kayitlari (log_kayit,log_tarih,log_kullanici) VALUES(@log_kayit,@log_tarih,@log_kullanici)";
            string kullaniciAdi = txtAdi.Text;
            string logKayitMesaji = kullaniciAdi + " kullanıcısı SPR sistemine giriş yaptı.";
            komut = new SqlCommand(loggiris, baglanti);
            komut.Parameters.AddWithValue("@log_tarih", DateTime.Now);
            komut.Parameters.AddWithValue("@log_kullanici", txtAdi.Text);
            komut.Parameters.AddWithValue("@log_kayit", logKayitMesaji);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
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
                System.Windows.Forms.Application.Exit();
            }
        }
    }
}
