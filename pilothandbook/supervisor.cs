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
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Drawing.Imaging;

using System.Data.SqlTypes;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Collections;

namespace pilothandbook
{
    public partial class supervisor : Form
    {

        SqlConnection baglanti;
        SqlCommand komut;
        SqlDataAdapter da;
        public supervisor()
        {
            InitializeComponent();

        }

        public static string occgiris;
        public static string occid;


        void Pilotpanel()
        {
            baglanti = new SqlConnection("server=MEHMETPALILI; Initial Catalog=pilothandbook;Integrated Security=SSPI");
            baglanti.Open();
            da = new SqlDataAdapter("SELECT * FROM pilot_table", baglanti);
            DataTable tablo1 = new DataTable();
            da.Fill(tablo1);
            dataGridView1.DataSource = tablo1;
            baglanti.Close();

        }
        void Occpanel()
        {
            baglanti = new SqlConnection("server=MEHMETPALILI; Initial Catalog=pilothandbook;Integrated Security=SSPI");
            baglanti.Open();
            da = new SqlDataAdapter("SELECT * FROM occ_bilgi", baglanti);
            DataTable tablo4 = new DataTable();
            da.Fill(tablo4);
            dataGridView3.DataSource = tablo4;
            baglanti.Close();

        }
        void Kayitlar()
        {
            baglanti = new SqlConnection("server=MEHMETPALILI; Initial Catalog=pilothandbook;Integrated Security=SSPI");
            baglanti.Open();
            da = new SqlDataAdapter("select * from log_kayitlari order by log_id desc", baglanti);
            DataTable tablo3 = new DataTable();
            da.Fill(tablo3);
            dataGridView2.DataSource = tablo3;
            baglanti.Close();

        }
        void derskayit()
        {
            baglanti = new SqlConnection("server=MEHMETPALILI; Initial Catalog=pilothandbook;Integrated Security=SSPI");
            baglanti.Open();
            da = new SqlDataAdapter("SELECT * FROM egitim_tablo", baglanti);
            DataTable tablo12 = new DataTable();
            da.Fill(tablo12);
            dataGridView6.DataSource = tablo12;
            baglanti.Close();

        }
        void Duyuruuu()
        {
            baglanti = new SqlConnection("server=MEHMETPALILI; Initial Catalog=pilothandbook;Integrated Security=SSPI");
            baglanti.Open();
            da = new SqlDataAdapter("SELECT * FROM duyuru_table", baglanti);
            DataTable tablo10 = new DataTable();
            da.Fill(tablo10);
            dataGridView4.DataSource = tablo10;
            baglanti.Close();

        }
        void Egitim()
        {
            baglanti = new SqlConnection("server=MEHMETPALILI; Initial Catalog=pilothandbook;Integrated Security=SSPI");
            baglanti.Open();
            da = new SqlDataAdapter("SELECT * FROM egitim_tablo WHERE gün > GETDATE()", baglanti);
            DataTable tablo11 = new DataTable();
            da.Fill(tablo11);
            dataGridView6.DataSource = tablo11;
            baglanti.Close();

        }
        void Egitimm()
        {
            baglanti = new SqlConnection("server=MEHMETPALILI; Initial Catalog=pilothandbook;Integrated Security=SSPI");
            baglanti.Open();
            da = new SqlDataAdapter("SELECT * FROM egitim_tablo", baglanti);
            DataTable tablo12 = new DataTable();
            da.Fill(tablo12);
            dataGridView5.DataSource = tablo12;
            baglanti.Close();
        }
        void gecmisders()
        {
            baglanti = new SqlConnection("server=MEHMETPALILI; Initial Catalog=pilothandbook;Integrated Security=SSPI");
            baglanti.Open();
            da = new SqlDataAdapter("SELECT * FROM egitim_tablo WHERE gün < GETDATE()", baglanti);
            DataTable tablo12 = new DataTable();
            da.Fill(tablo12);
            dataGridView7.DataSource = tablo12;
            baglanti.Close();
        }
        void gelicekders()
        {
            baglanti = new SqlConnection("server=MEHMETPALILI; Initial Catalog=pilothandbook;Integrated Security=SSPI");
            baglanti.Open();
            da = new SqlDataAdapter("SELECT * FROM egitim_tablo WHERE gün > GETDATE()", baglanti);
            DataTable tablo12 = new DataTable();
            da.Fill(tablo12);
            dataGridView8.DataSource = tablo12;
            baglanti.Close();
        }



        private void supervisor_Load(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("server=MEHMETPALILI; Initial Catalog=pilothandbook;Integrated Security=SSPI");

            try
            {

                baglanti.Open();


                string sqlSorgusu = "SELECT pilot_id, pilot_ad, pilot_soyisim FROM pilot_table";


                SqlCommand komut = new SqlCommand(sqlSorgusu, baglanti);


                SqlDataReader reader = komut.ExecuteReader();


                comboBox2.Items.Clear();

                // Verileri ComboBox a ekledim
                while (reader.Read())
                {
                    int pilotID = reader.GetInt32(0);
                    string ad = reader.GetString(1);
                    string soyad = reader.GetString(2);
                    string tamAd = ad + " " + soyad;
                    comboBox2.Items.Add(tamAd);
                }


                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }


            label1.Text = supervisorgiris.occgiris;
            /*  groupBox1.Visible = false; // Grup kutusunu gizle
              groupBox2.Visible = false; // Grup kutusunu gizle
              groupBox3.Visible = false; // Grup kutusunu gizle
              groupBox4.Visible = false;*/
            label3.Text = supervisor.occid;
            Pilotpanel();
            Kayitlar();
            Occpanel();
            Duyuruuu();
            derskayit();
            Egitimm();
            gecmisders();
            gelicekders();


        }

        private void button1_Click(object sender, EventArgs e)
        {

            groupBox1.Visible = true;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;

            button1.BackColor = Color.DarkBlue;
            button2.BackColor = Color.Transparent;
            button3.BackColor = Color.Transparent;
            button5.BackColor = Color.Transparent;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = true;
            groupBox3.Visible = false;
            groupBox4.Visible = false;

            button1.BackColor = Color.Transparent;
            button2.BackColor = Color.DarkBlue;
            button3.BackColor = Color.Transparent;
            button5.BackColor = Color.Transparent;


        }

        private void button3_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = true;
            groupBox4.Visible = false;

            button1.BackColor = Color.Transparent;
            button2.BackColor = Color.Transparent;
            button3.BackColor = Color.DarkBlue;
            button5.BackColor = Color.Transparent;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = true;

            button1.BackColor = Color.Transparent;
            button2.BackColor = Color.Transparent;
            button3.BackColor = Color.Transparent;
            button5.BackColor = Color.DarkBlue;

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Kayitlar();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult sonuc;
            sonuc = MessageBox.Show("Hesap kapatılıyor emin misiniz ?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (sonuc == DialogResult.No)
            {

            }
            if (sonuc == DialogResult.Yes)
            {
                this.Close();
                Application.Exit();
                baglanti = new SqlConnection("server=MEHMETPALILI; Initial Catalog=pilothandbook;Integrated Security=SSPI");
                string logcikis = "INSERT INTO log_kayitlari (log_kayit,log_tarih,log_kullanici) VALUES(@log_kayit,@log_tarih,@log_kullanici)";
                komut = new SqlCommand(logcikis, baglanti);
                komut.Parameters.AddWithValue("@log_kayit", "SUPERVİSOR sisteminden çıkış");
                komut.Parameters.AddWithValue("@log_tarih", DateTime.Now);
                komut.Parameters.AddWithValue("@log_kullanici", label1.Text);
                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = true;
            groupBox5.Visible = false;

            

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void occad_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            byte[] imageBytes = null;
            if (pictureBox1.Image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    pictureBox1.Image.Save(ms, ImageFormat.Jpeg);
                    imageBytes = ms.ToArray();
                }
            }

            string sorgu = "INSERT INTO occ_bilgi(occad,occsoyad,occdoğumtarihi,occtelefon,occevadresi,maaş, occ_foto) VALUES(@occad,@occsoyad,@occdoğumtarihi,@occtelefon,@occevadresi,@maaş,@occ_foto)";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@occad", occad.Text);
            komut.Parameters.AddWithValue("@occsoyad", occsoyad.Text);
            komut.Parameters.AddWithValue("@occdoğumtarihi", dateTimePicker1.Value);
            komut.Parameters.AddWithValue("@occtelefon", occnumara.Text);
            komut.Parameters.AddWithValue("@occevadresi", adresocc.Text);
            komut.Parameters.AddWithValue("@maaş", comboBox1.SelectedItem.ToString());
            komut.Parameters.AddWithValue("@occ_foto", (object)imageBytes ?? DBNull.Value);

            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();


            string logkayit = "INSERT INTO log_kayitlari (log_kayit,log_tarih,log_kullanici) VALUES(@log_kayit,@log_tarih,@log_kullanici)";
            komut = new SqlCommand(logkayit, baglanti);
            komut.Parameters.AddWithValue("@log_kayit", "Yeni Occ eklendi edildi.");
            komut.Parameters.AddWithValue("@log_tarih", DateTime.Now);
            komut.Parameters.AddWithValue("@log_kullanici", label1.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            Occpanel();

        }

        private void button10_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Resim Dosyası | *.png; *.jpg; *.jpeg; *.bmp";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                Bitmap selectedImage = new Bitmap(fileDialog.FileName);
                Bitmap resizedImage = new Bitmap(selectedImage, new Size(109, 137));
                pictureBox1.Image = resizedImage;
            }

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            occad.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString();
            textBox1.Text = dataGridView3.CurrentRow.Cells[0].Value.ToString();
            occsoyad.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString();
            comboBox1.Text = dataGridView3.CurrentRow.Cells[6].Value.ToString();
            dateTimePicker1.Text = dataGridView3.CurrentRow.Cells[3].Value.ToString();
            occnumara.Text = dataGridView3.CurrentRow.Cells[4].Value.ToString();
            adresocc.Text = dataGridView3.CurrentRow.Cells[5].Value.ToString();

            if (dataGridView3.CurrentRow.Cells["occ_foto"].Value != DBNull.Value)
            {
                byte[] imageBytes = (byte[])dataGridView3.CurrentRow.Cells["occ_foto"].Value;
                if (imageBytes != null)
                {
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        System.Drawing.Image image = System.Drawing.Image.FromStream(ms);
                        pictureBox1.Image = image;
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                        pictureBox1.Size = new Size(109, 137);
                    }
                }
            }
            else
            {
                pictureBox1.Image = null;
            }



        }

        private void button8_Click(object sender, EventArgs e)
        {
            byte[] imageBytes = null;

            if (pictureBox1.Image != null)
            {
                MemoryStream ms = new MemoryStream();
                pictureBox1.Image.Save(ms, ImageFormat.Jpeg);
                imageBytes = ms.ToArray();
            }

            string sorgu = "UPDATE occ_bilgi SET occad=@occad,occsoyad=@occsoyad,occdoğumtarihi=@occdoğumtarihi,occtelefon=@occtelefon,occevadresi=@occevadresi,maaş=@maaş";

            if (imageBytes != null)
            {
                sorgu += ",occ_foto=@occ_foto";
            }

            sorgu += " WHERE occ_id=@occ_id";

            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@occ_id", Convert.ToInt32(textBox1.Text));
            komut.Parameters.AddWithValue("@occad", occad.Text);
            komut.Parameters.AddWithValue("@occsoyad", occsoyad.Text);
            komut.Parameters.AddWithValue("@occdoğumtarihi", dateTimePicker1.Value);
            komut.Parameters.AddWithValue("@occtelefon", occnumara.Text);
            komut.Parameters.AddWithValue("@occevadresi", adresocc.Text);
            komut.Parameters.AddWithValue("@maaş", comboBox1.SelectedItem.ToString());

            if (imageBytes != null)
            {
                komut.Parameters.AddWithValue("@occ_foto", imageBytes);
            }

            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            Occpanel();



            string loggüncel = "INSERT INTO log_kayitlari (log_kayit,log_tarih,log_kullanici) VALUES(@log_kayit,@log_tarih,@log_kullanici)";
            komut = new SqlCommand(loggüncel, baglanti);
            komut.Parameters.AddWithValue("@log_kayit", "güncelleme yapıldı.");
            komut.Parameters.AddWithValue("@log_tarih", DateTime.Now);
            komut.Parameters.AddWithValue("@log_kullanici", label1.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();

        }

        private void button9_Click(object sender, EventArgs e)
        {
            string sorgu = "Delete FROM occ_bilgi WHERE occ_id=@occ_id";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@occ_id", Convert.ToInt32(textBox1.Text));
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            Occpanel();
            string logsil = "INSERT INTO log_kayitlari (log_kayit,log_tarih,log_kullanici) VALUES(@log_kayit,@log_tarih,@log_kullanici)";
            string kullaniciAdii = $"{occad.Text} {occsoyad.Text}";
            string logKayitMesaji = $"{kullaniciAdii} : kullanıcısı silindi";
            komut = new SqlCommand(logsil, baglanti);
            komut.Parameters.AddWithValue("@log_tarih", DateTime.Now);
            komut.Parameters.AddWithValue("@log_kullanici", label1.Text);
            komut.Parameters.AddWithValue("@log_kayit", logKayitMesaji);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string duyuruMetni = textBox2.Text;

            string sorgu = "INSERT INTO duyuru_table (duyuru) VALUES (@duyuru)";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@duyuru", duyuruMetni);

            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("Duyuru gönderiliyor emin misiniz ?", "DUYURU", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            string logkayit = "INSERT INTO log_kayitlari (log_kayit,log_tarih,log_kullanici) VALUES(@log_kayit,@log_tarih,@log_kullanici)";
            komut = new SqlCommand(logkayit, baglanti);
            komut.Parameters.AddWithValue("@log_kayit", "Yeni duyuru yapıldı.");
            komut.Parameters.AddWithValue("@log_tarih", DateTime.Now);
            komut.Parameters.AddWithValue("@log_kullanici", label1.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            Duyuruuu();



        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView4.CurrentRow.Cells[1].Value.ToString();


        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int secilenIndex = comboBox2.SelectedIndex;


            SqlConnection baglanti = new SqlConnection("server=MEHMETPALILI; Initial Catalog=pilothandbook;Integrated Security=SSPI");

            try
            {

                baglanti.Open();


                string sqlSorgusu = "SELECT pilot_id FROM pilot_table";


                SqlCommand komut = new SqlCommand(sqlSorgusu, baglanti);


                SqlDataReader reader = komut.ExecuteReader();

                // Seçilen indekse göre ilgili pilot ID si alınır
                int secilenPilotID = -1;
                int count = 0;
                while (reader.Read())
                {
                    if (count == secilenIndex)
                    {
                        secilenPilotID = reader.GetInt32(0);
                        break;
                    }
                    count++;
                }

                // Pilot ID sini TextBox7 ye ata
                textBox7.Text = secilenPilotID.ToString();

                // Veritabanı bağlantısını kapat
                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string sorgu = "INSERT INTO egitim_tablo(egitimad,egitmenadi,pilotadi,gün,konu,pilot_id) VALUES(@egitimad,@egitmenadi,@pilotadi,@gün,@konu,@pilot_id)";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@egitimad", textBox3.Text);
            komut.Parameters.AddWithValue("@egitmenadi", textBox4.Text);
            komut.Parameters.AddWithValue("@gün", dateTimePicker2.Value);
            komut.Parameters.AddWithValue("@pilotadi", comboBox2.SelectedItem.ToString());
            komut.Parameters.AddWithValue("@konu", textBox5.Text);
            komut.Parameters.AddWithValue("@pilot_id", textBox7.Text);

            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            derskayit();
            gelicekders();
            gecmisders();

            string logkayit = "INSERT INTO log_kayitlari (log_kayit,log_tarih,log_kullanici) VALUES(@log_kayit,@log_tarih,@log_kullanici)";
            komut = new SqlCommand(logkayit, baglanti);
            komut.Parameters.AddWithValue("@log_kayit", "Yeni ders kayıt edildi.");
            komut.Parameters.AddWithValue("@log_tarih", DateTime.Now);
            komut.Parameters.AddWithValue("@log_kullanici", label1.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox3.Text = dataGridView6.CurrentRow.Cells[1].Value.ToString();
            textBox6.Text = dataGridView6.CurrentRow.Cells[0].Value.ToString();
            textBox4.Text = dataGridView6.CurrentRow.Cells[2].Value.ToString();
            comboBox2.Text = dataGridView6.CurrentRow.Cells[3].Value.ToString();
            dateTimePicker2.Text = dataGridView6.CurrentRow.Cells[4].Value.ToString();
            textBox5.Text = dataGridView6.CurrentRow.Cells[5].Value.ToString();


        }

        private void button14_Click(object sender, EventArgs e)
        {
            string sorgu = "Delete FROM egitim_tablo WHERE egitim_id=@egitim_id";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@egitim_id", Convert.ToInt32(textBox6.Text));
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            derskayit();
            gelicekders();
            gecmisders();
            string logsil = "INSERT INTO log_kayitlari (log_kayit,log_tarih,log_kullanici) VALUES(@log_kayit,@log_tarih,@log_kullanici)";
            string kullaniciAdii = $"{textBox3.Text} {textBox4.Text}";
            string logKayitMesaji = $"{kullaniciAdii} : Ders kayıtı silindi";
            komut = new SqlCommand(logsil, baglanti);
            komut.Parameters.AddWithValue("@log_tarih", DateTime.Now);
            komut.Parameters.AddWithValue("@log_kullanici", label1.Text);
            komut.Parameters.AddWithValue("@log_kayit", logKayitMesaji);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            string sorgu = "UPDATE  egitim_tablo SET egitimad=@egitimad,egitmenadi=@egitmenadi,pilotadi=@pilotadi,gün=@gün,konu=@konu WHERE egitim_id=@egitim_id";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@egitim_id", Convert.ToInt32(textBox6.Text));
            komut.Parameters.AddWithValue("@egitimad", textBox3.Text);
            komut.Parameters.AddWithValue("@egitmenadi", textBox4.Text);
            komut.Parameters.AddWithValue("@gün", dateTimePicker2.Value);
            komut.Parameters.AddWithValue("@pilotadi", comboBox2.SelectedItem.ToString());
            komut.Parameters.AddWithValue("@konu", textBox5.Text);


            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            derskayit();
            gelicekders();
            gecmisders();

            string logkayit = "INSERT INTO log_kayitlari (log_kayit,log_tarih,log_kullanici) VALUES(@log_kayit,@log_tarih,@log_kullanici)";
            komut = new SqlCommand(logkayit, baglanti);
            komut.Parameters.AddWithValue("@log_kayit", "Ders kayıtı güncellendi.");
            komut.Parameters.AddWithValue("@log_tarih", DateTime.Now);
            komut.Parameters.AddWithValue("@log_kullanici", label1.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {
            // Yeni bir PDF belgesi oluşturun
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);

            // PDF dosyasına yazmak için PdfWriter örneğini alın
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream("LOGKAYITLARI.pdf", FileMode.Create));

            // Belgeyi açın
            doc.Open();

            // Başlık paragrafını oluşturun
            Paragraph title = new Paragraph("LOG VERİLERİ", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 15));
            title.Alignment = Element.ALIGN_CENTER;
            title.SpacingAfter = 20f;
            doc.Add(title);

            // Tabloyu PDF'ye aktar
            PdfPTable table = new PdfPTable(dataGridView2.Columns.Count);

            // Sütun başlıklarını ekleyin
            for (int i = 0; i < dataGridView2.Columns.Count; i++)
            {
                table.AddCell(new Phrase(dataGridView2.Columns[i].HeaderText));
            }

            // Verileri ekleyin
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView2.Columns.Count; j++)
                {
                    if (dataGridView2[j, i].Value != null)
                    {
                        table.AddCell(new Phrase(dataGridView2[j, i].Value.ToString()));
                    }
                }
            }

            // Tabloyu belgeye ekleyin
            doc.Add(table);

            // Belgeyi kapatın
            doc.Close();
            MessageBox.Show("PDF OLUŞTURULDU ", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            string logbelge = "INSERT INTO log_kayitlari (log_kayit,log_tarih,log_kullanici) VALUES(@log_kayit,@log_tarih,@log_kullanici)";
            komut = new SqlCommand(logbelge, baglanti);
            komut.Parameters.AddWithValue("@log_kayit", "LOG KAYITLARI pdf kaydedildi.");
            komut.Parameters.AddWithValue("@log_tarih", DateTime.Now);
            komut.Parameters.AddWithValue("@log_kullanici", label1.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);

            // Belgeyi oluşturmak için bir PdfWriter örneği alın.
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("pilotdersbilgi.pdf", FileMode.Create));

            // Belgeyi açın.
            doc.Open();
            Paragraph title = new Paragraph("DERS BILGI DOKUMU", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 15));
            title.Alignment = Element.ALIGN_CENTER;
            title.SpacingAfter = 120f;
            doc.Add(title);


            string[] texts = { textBox3.Text, textBox4.Text, comboBox2.Text, dateTimePicker2.Text, textBox7.Text, textBox6.Text, textBox5.Text };

            // Her bir metnin etiketini ve metnini içeren Paragraph nesneleri oluşturun.
            Paragraph para1 = new Paragraph("Eğitim Adı: " + texts[0]);
            para1.SpacingAfter = 5f;
            Paragraph para2 = new Paragraph("Hoca Adı: " + texts[1]);
            para2.SpacingAfter = 5f;
            Paragraph para3 = new Paragraph("Pilot AdSoyad: " + texts[2]);
            para3.SpacingAfter = 5f;
            Paragraph para4 = new Paragraph("Tarih: " + texts[3]);
            para4.SpacingAfter = 5f;
            Paragraph para5 = new Paragraph("Pilot Id: " + texts[4]);
            para5.SpacingAfter = 5f;
            Paragraph para6 = new Paragraph("Ders ID " + texts[5]);
            para6.SpacingAfter = 5f;
            Paragraph para7 = new Paragraph("Konu(Not): " + texts[6]);
            para7.SpacingAfter = 5f;

            para1.Alignment = Element.ALIGN_LEFT;
            para2.Alignment = Element.ALIGN_LEFT;
            para3.Alignment = Element.ALIGN_LEFT;
            para4.Alignment = Element.ALIGN_LEFT;
            para5.Alignment = Element.ALIGN_LEFT;
            para6.Alignment = Element.ALIGN_LEFT;
            para7.Alignment = Element.ALIGN_LEFT;

            PdfContentByte cb = wri.DirectContent;
            Paragraph para10 = new Paragraph("Sadece Supervisor talep edilir!", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10));
            para10.Alignment = Element.ALIGN_CENTER;
            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(@"C:\Users\Mmber\OneDrive\Masaüstü\bitirme projesi\pilothandbook\img\imza2.jpg");
            img.ScaleToFit(120f, 120f); //resmin boyutu
            img.SetAbsolutePosition(doc.PageSize.Width - 225f, doc.PageSize.Height - 550f);
            img.SpacingAfter = 10f;

            doc.Add(para1);
            doc.Add(para2);
            doc.Add(para3);
            doc.Add(para4);
            doc.Add(para5);
            doc.Add(para6);
            doc.Add(para7);
            doc.Add(img);
            doc.Add(para10);


            doc.Close();
            MessageBox.Show("PDF OLUŞTURULDU ", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            string logbelge = "INSERT INTO log_kayitlari (log_kayit,log_tarih,log_kullanici) VALUES(@log_kayit,@log_tarih,@log_kullanici)";
            komut = new SqlCommand(logbelge, baglanti);
            komut.Parameters.AddWithValue("@log_kayit", "Eğitim sistemi pdf kaydedildi.");
            komut.Parameters.AddWithValue("@log_tarih", DateTime.Now);
            komut.Parameters.AddWithValue("@log_kullanici", label1.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();

        }

        private void groupBox10_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView7_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView8_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void OtherButton_Click(object sender, EventArgs e)
        {
            button1.BackColor = SystemColors.Control; // Önceki arka plan rengine dönme
        }
    }
}
