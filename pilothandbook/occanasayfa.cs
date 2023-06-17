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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace pilothandbook
{
    public partial class occanasayfa : Form
    {
        SqlConnection baglanti;
        SqlCommand komut;
        SqlDataAdapter da;
        //önemli 
        public occanasayfa()
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
            dataGridView1.DataSource = tablo1;
            baglanti.Close();

        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
        void Oturum()
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void occanasayfa_Load(object sender, EventArgs e)
        {
            Pilotpanel(); //datagriedview. görünmesini sağlar tabloyu
            label1.Text = occgiris.gonderilecekAdminAdSoyad; // labele giriş yapan kişinin ismini yaz

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
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
                string logcikis = "INSERT INTO log_kayitlari (log_kayit,log_tarih,log_kullanici) VALUES(@log_kayit,@log_tarih,@log_kullanici)";
                komut = new SqlCommand(logcikis, baglanti);
                komut.Parameters.AddWithValue("@log_kayit", "OCC sisteminden çıkış");
                komut.Parameters.AddWithValue("@log_tarih", DateTime.Now);
                komut.Parameters.AddWithValue("@log_kullanici", label1.Text);
                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();
            }



        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void label8_Click(object sender, EventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sorgu = "INSERT INTO pilot_table(pilot_ad,pilot_soyisim,pilot_base,pilot_tip,pilot_saat,pilot_bas,pilot_rütbe,pilot_adres,pilot_tibbi,pilot_occnot,pilot_pilotnot) VALUES(@pilot_ad,@pilot_soyisim,@pilot_base,@pilot_tip,@pilot_saat,@pilot_bas,@pilot_rütbe,@pilot_adres,@pilot_tibbi,@pilot_occnot,@pilot_pilotnot)";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@pilot_ad", pilotad.Text);
            komut.Parameters.AddWithValue("@pilot_soyisim", pilotsoy.Text);
            if (checkBox1.Checked)
            {
                komut.Parameters.AddWithValue("@pilot_base", checkBox1.Text);
            }
            if (checkBox2.Checked)
            {
                komut.Parameters.AddWithValue("@pilot_base", checkBox2.Text);
            }
            if (checkBox3.Checked)
            {
                komut.Parameters.AddWithValue("@pilot_base", checkBox3.Text);
            }
            if (radioButton1.Checked)
            {
                komut.Parameters.AddWithValue("@pilot_tip", radioButton1.Text);
            }
            if (radioButton2.Checked)
            {
                komut.Parameters.AddWithValue("@pilot_tip", radioButton2.Text);
            }
            komut.Parameters.AddWithValue("@pilot_saat", comboBox1.SelectedItem.ToString());
            komut.Parameters.AddWithValue("@pilot_bas", dateTimePicker1.Value);
            komut.Parameters.AddWithValue("@pilot_rütbe", comboBox2.SelectedItem.ToString());
            komut.Parameters.AddWithValue("@pilot_adres", textBox4.Text);
            komut.Parameters.AddWithValue("@pilot_tibbi", textBox7.Text);
            komut.Parameters.AddWithValue("@pilot_occnot", textBox3.Text);
            komut.Parameters.AddWithValue("@pilot_pilotnot", textBox6.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            Pilotpanel();

            string logkayit = "INSERT INTO log_kayitlari (log_kayit,log_tarih,log_kullanici) VALUES(@log_kayit,@log_tarih,@log_kullanici)";
            komut = new SqlCommand(logkayit, baglanti);
            komut.Parameters.AddWithValue("@log_kayit", "Yeni pilot kayıt edildi.");
            komut.Parameters.AddWithValue("@log_tarih", DateTime.Now);
            komut.Parameters.AddWithValue("@log_kullanici", label1.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();




        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dataGridView1.Columns[1].Width = 110;
            this.dataGridView1.Columns[2].Width = 110; //genişlikleri

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            pilotad.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString(); //veritabanında seçtiğim kişiyi istediğim textbox ismini yazıyor
            pilotsoy.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            //  checkBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString(); 
            // checkBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString(); 


            //veritabanında seçtiğim kişiyi istediğim textbox ismini yazıyor
            // //veritabanında seçtiğim kişiyi istediğim textbox ismini yazıyor
            //pilotad.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString(); //veritabanında seçtiğim kişiyi istediğim textbox ismini yazıyor
            // pilotad.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString(); //veritabanında seçtiğim kişiyi istediğim textbox ismini yazıyor
            string a = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            if (a == "LTAC")
            {
                checkBox1.Checked = true;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
            }
            if (a == "LTFJ")
            {
                checkBox1.Checked = false;
                checkBox2.Checked = true;
                checkBox3.Checked = false;
            }
            if (a == "LTAI")
            {
                checkBox3.Checked = true;
                checkBox2.Checked = false;
                checkBox1.Checked = false;
            }
            string s = dataGridView1.CurrentRow.Cells[4].Value.ToString();

            if (s == "Airbus")
            {
                radioButton1.Checked = true;
            }

            else
            {
                radioButton2.Checked = true;


            }
            comboBox1.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString(); //veritabanında seçtiğim kişiyi istediğim textbox ismini yazıyor
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString(); //veritabanında seçtiğim kişiyi istediğim textbox ismini yazıyor
            comboBox2.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString(); //veritabanında seçtiğim kişiyi istediğim textbox ismini yazıyor
            comboBox2.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString(); //veritabanında seçtiğim kişiyi istediğim textbox ismini yazıyor
            textBox4.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString(); //veritabanında seçtiğim kişiyi istediğim textbox ismini yazıyor
            textBox7.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString(); //veritabanında seçtiğim kişiyi istediğim textbox ismini yazıyor
            textBox3.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString(); //veritabanında seçtiğim kişiyi istediğim textbox ismini yazıyor
            textBox6.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString(); //veritabanında seçtiğim kişiyi istediğim textbox ismini yazıyor
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sorgu = "Delete FROM pilot_table WHERE pilot_id=@pilot_id";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@pilot_id", Convert.ToInt32(textBox1.Text));
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            Pilotpanel();
            string logsil = "INSERT INTO log_kayitlari (log_kayit,log_tarih,log_kullanici) VALUES(@log_kayit,@log_tarih,@log_kullanici)";
            string kullaniciAdii = $"{pilotad.Text} {pilotsoy.Text}";
            string logKayitMesaji = $"{kullaniciAdii} : kullanıcısı silindi";
            komut = new SqlCommand(logsil, baglanti);
            komut.Parameters.AddWithValue("@log_tarih", DateTime.Now);
            komut.Parameters.AddWithValue("@log_kullanici", label1.Text);
            komut.Parameters.AddWithValue("@log_kayit", logKayitMesaji);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string sorgu = "UPDATE pilot_table SET pilot_ad=@pilot_ad,pilot_soyisim=@pilot_soyisim,pilot_base=@pilot_base,pilot_tip=@pilot_tip,pilot_saat=@pilot_saat,pilot_bas=@pilot_bas,pilot_rütbe=@pilot_rütbe,pilot_adres=@pilot_adres,pilot_tibbi=@pilot_tibbi,pilot_occnot=@pilot_occnot,pilot_pilotnot=@pilot_pilotnot WHERE pilot_id=@pilot_id";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@pilot_id", Convert.ToInt32(textBox1.Text));
            komut.Parameters.AddWithValue("@pilot_ad", pilotad.Text);
            komut.Parameters.AddWithValue("@pilot_soyisim", pilotsoy.Text);
            if (checkBox1.Checked)
            {
                komut.Parameters.AddWithValue("@pilot_base", checkBox1.Text);
            }
            if (checkBox2.Checked)
            {
                komut.Parameters.AddWithValue("@pilot_base", checkBox2.Text);
            }
            if (checkBox3.Checked)
            {
                komut.Parameters.AddWithValue("@pilot_base", checkBox3.Text);
            }
            if (radioButton1.Checked)
            {
                komut.Parameters.AddWithValue("@pilot_tip", radioButton1.Text);
            }
            if (radioButton2.Checked)
            {
                komut.Parameters.AddWithValue("@pilot_tip", radioButton2.Text);
            }
            komut.Parameters.AddWithValue("@pilot_saat", comboBox1.SelectedItem.ToString());
            komut.Parameters.AddWithValue("@pilot_bas", dateTimePicker1.Value);
            komut.Parameters.AddWithValue("@pilot_rütbe", comboBox2.SelectedItem.ToString());
            komut.Parameters.AddWithValue("@pilot_adres", textBox4.Text);
            komut.Parameters.AddWithValue("@pilot_tibbi", textBox7.Text);
            komut.Parameters.AddWithValue("@pilot_occnot", textBox3.Text);
            komut.Parameters.AddWithValue("@pilot_pilotnot", textBox6.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            Pilotpanel();
            string loggüncel = "INSERT INTO log_kayitlari (log_kayit,log_tarih,log_kullanici) VALUES(@log_kayit,@log_tarih,@log_kullanici)";
            komut = new SqlCommand(loggüncel, baglanti);
            komut.Parameters.AddWithValue("@log_kayit", "güncelleme yapıldı.");
            komut.Parameters.AddWithValue("@log_tarih", DateTime.Now);
            komut.Parameters.AddWithValue("@log_kullanici", label1.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();


        }

        private void button4_Click(object sender, EventArgs e)
        {

            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);

            // Belgeyi oluşturmak için bir PdfWriter örneği alın.
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("pilotbilgi.pdf", FileMode.Create));

            // Belgeyi açın.
            doc.Open();
            Paragraph title = new Paragraph("Pilot Bilgileri", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 13));
            title.Alignment = Element.ALIGN_CENTER;
            title.SpacingAfter = 100f;
            doc.Add(title);


            string[] texts = { pilotad.Text, pilotsoy.Text, comboBox1.Text, dateTimePicker1.Text, comboBox2.Text, textBox4.Text, textBox7.Text, textBox3.Text, textBox6.Text };

            // Her bir metnin etiketini ve metnini içeren Paragraph nesneleri oluşturun.
            Paragraph para1 = new Paragraph("Pilot Adı: " + texts[0]);
            para1.SpacingAfter = 5f;
            Paragraph para2 = new Paragraph("Pilot Soyadı: " + texts[1]);
            para2.SpacingAfter = 5f;
            Paragraph para3 = new Paragraph("Ucus Saatti: " + texts[2]);
            para3.SpacingAfter = 5f;
            Paragraph para4 = new Paragraph("Giris Tarihi: " + texts[3]);
            para4.SpacingAfter = 5f;
            Paragraph para5 = new Paragraph("Rütbe: " + texts[4]);
            para5.SpacingAfter = 5f;
            Paragraph para6 = new Paragraph("Adres: " + texts[5]);
            para6.SpacingAfter = 5f;
            Paragraph para7 = new Paragraph("Saglik bilgisi: " + texts[6]);
            para7.SpacingAfter = 5f;
            Paragraph para8 = new Paragraph("OCC Notu: " + texts[7]);
            para8.SpacingAfter = 5f;
            Paragraph para9 = new Paragraph("Pilot Notu: " + texts[8]);
            para9.SpacingAfter = 150f;
            para1.Alignment = Element.ALIGN_CENTER;
            para2.Alignment = Element.ALIGN_CENTER;
            para3.Alignment = Element.ALIGN_CENTER;
            para4.Alignment = Element.ALIGN_CENTER;
            para5.Alignment = Element.ALIGN_CENTER;
            para6.Alignment = Element.ALIGN_CENTER;
            para7.Alignment = Element.ALIGN_CENTER;
            para8.Alignment = Element.ALIGN_CENTER;
            para9.Alignment = Element.ALIGN_CENTER;
            PdfContentByte cb = wri.DirectContent;
            Paragraph para10 = new Paragraph("resmi evraktir!", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10));
            para10.Alignment = Element.ALIGN_CENTER;
            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(@"C:\Users\Mmber\OneDrive\Masaüstü\bitirme projesi\pilothandbook\img\imza2.jpg");
            img.ScaleToFit(120f, 120f); //resmin boyutu
            img.SetAbsolutePosition(doc.PageSize.Width - 225f, doc.PageSize.Height - 550f);
            img.SpacingAfter = 10f;


            // Add the image to the document



            // Paragraph nesnelerini PDF belgesine ekleyin.
            doc.Add(para1);
            doc.Add(para2);
            doc.Add(para3);
            doc.Add(para4);
            doc.Add(para5);
            doc.Add(para6);
            doc.Add(para7);
            doc.Add(para8);
            doc.Add(para9);
            doc.Add(img);
            doc.Add(para10);


            doc.Close();
            MessageBox.Show("PDF OLUŞTURULDU ", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            string logbelge = "INSERT INTO log_kayitlari (log_kayit,log_tarih,log_kullanici) VALUES(@log_kayit,@log_tarih,@log_kullanici)";
            komut = new SqlCommand(logbelge, baglanti);
            komut.Parameters.AddWithValue("@log_kayit", "OCC sistemi pdf kaydedildi.");
            komut.Parameters.AddWithValue("@log_tarih", DateTime.Now);
            komut.Parameters.AddWithValue("@log_kullanici", label1.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);

            // Belgeyi oluşturmak için bir PdfWriter örneği alın.
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("pilotbilgi.pdf", FileMode.Create));

            // Belgeyi açın.
            doc.Open();
            Paragraph title = new Paragraph("Pilot Bilgileri", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 13));
            title.Alignment = Element.ALIGN_CENTER;
            title.SpacingAfter = 100f;
            doc.Add(title);


            string[] texts = { pilotad.Text, pilotsoy.Text, comboBox1.Text, dateTimePicker1.Text, comboBox2.Text, textBox4.Text, textBox7.Text, textBox3.Text, textBox6.Text };

          
            Paragraph para1 = new Paragraph("Pilot Adı: " + texts[0]);
            para1.SpacingAfter = 5f;
            Paragraph para2 = new Paragraph("Pilot Soyadı: " + texts[1]);
            para2.SpacingAfter = 5f;
            Paragraph para3 = new Paragraph("Ucus Saatti: " + texts[2]);
            para3.SpacingAfter = 5f;
            Paragraph para4 = new Paragraph("Giris Tarihi: " + texts[3]);
            para4.SpacingAfter = 5f;
            Paragraph para5 = new Paragraph("Rütbe: " + texts[4]);
            para5.SpacingAfter = 5f;
            Paragraph para6 = new Paragraph("Adres: " + texts[5]);
            para6.SpacingAfter = 5f;
            Paragraph para7 = new Paragraph("Saglik bilgisi: " + texts[6]);
            para7.SpacingAfter = 5f;
            Paragraph para8 = new Paragraph("OCC Notu: " + texts[7]);
            para8.SpacingAfter = 5f;
            Paragraph para9 = new Paragraph("Pilot Notu: " + texts[8]);
            para9.SpacingAfter = 150f;
            para1.Alignment = Element.ALIGN_CENTER;
            para2.Alignment = Element.ALIGN_CENTER;
            para3.Alignment = Element.ALIGN_CENTER;
            para4.Alignment = Element.ALIGN_CENTER;
            para5.Alignment = Element.ALIGN_CENTER;
            para6.Alignment = Element.ALIGN_CENTER;
            para7.Alignment = Element.ALIGN_CENTER;
            para8.Alignment = Element.ALIGN_CENTER;
            para9.Alignment = Element.ALIGN_CENTER;
            PdfContentByte cb = wri.DirectContent;
            Paragraph para10 = new Paragraph("resmi evraktir!", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10));
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
            doc.Add(para8);
            doc.Add(para9);
            doc.Add(img);
            doc.Add(para10);


            doc.Close();
            MessageBox.Show("PDF OLUŞTURULDU ", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            string logbelge = "INSERT INTO log_kayitlari (log_kayit,log_tarih,log_kullanici) VALUES(@log_kayit,@log_tarih,@log_kullanici)";
            komut = new SqlCommand(logbelge, baglanti);
            komut.Parameters.AddWithValue("@log_kayit", "OCC sistemi pdf kaydedildi.");
            komut.Parameters.AddWithValue("@log_tarih", DateTime.Now);
            komut.Parameters.AddWithValue("@log_kullanici", label1.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
    }
}
