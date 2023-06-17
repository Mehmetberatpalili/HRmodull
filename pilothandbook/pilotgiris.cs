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
using static System.Net.Mime.MediaTypeNames;


namespace pilothandbook
{
    public partial class pilotgiris : Form
    {
        SqlConnection baglanti;
        SqlCommand komut;
        SqlDataAdapter da;
        public pilotgiris()
        {
            InitializeComponent();
        }
        void Pilotpanel()
        {
            baglanti = new SqlConnection("server=MEHMETPALILI; Initial Catalog=pilothandbook;Integrated Security=SSPI");


        }
        public static string pilotgirisss;
        public static string pilotid;
        private void pilotgiris_Load(object sender, EventArgs e)
        {
            txtSifre.PasswordChar = '*'; // occ giriş şifre gizleme char olduğu için tek nokta

        }

        private void txtSifre_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (sender as TextBox); // seçtirdim
            txt.CharacterCasing = CharacterCasing.Upper; // yazılanın hep büyük olmasını sağlar.

        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            baglanti = new SqlConnection("server=MEHMETPALILI; Initial Catalog=pilothandbook;Integrated Security=SSPI");
            string kullanici_ad = txtAd.Text;
            string kullanici_sifre = txtSifre.Text;
            veritabani2 islemim = new veritabani2();
            islemim.girisYap(kullanici_ad, kullanici_sifre, this);
              
            string loggiris = "INSERT INTO log_kayitlari (log_kayit,log_tarih,log_kullanici) VALUES(@log_kayit,@log_tarih,@log_kullanici)";
            string kullaniciAdi = txtAd.Text;
            string logKayitMesaji = kullaniciAdi + " kullanıcısı PİLOT sistemine giriş yaptı.";
            komut = new SqlCommand(loggiris, baglanti);
            komut.Parameters.AddWithValue("@log_tarih", DateTime.Now);
            komut.Parameters.AddWithValue("@log_kullanici", txtAd.Text);
            komut.Parameters.AddWithValue("@log_kayit", logKayitMesaji);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
        
        }

        private void txtAd_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (sender as TextBox); // seçtirdim
            txt.CharacterCasing = CharacterCasing.Upper; // yazılanın hep büyük olmasını sağlar.

        }
        private void btnGiris_MouseLeave(object sender, EventArgs e)
        {
            btnGiris.BackColor = Color.Transparent;

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
