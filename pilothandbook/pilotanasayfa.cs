using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace pilothandbook
{
    public partial class pilotanasayfa : Form
    {
        public pilotanasayfa()
        {
            InitializeComponent();
        }
        SqlConnection bag;
        SqlCommand komut;
        SqlDataAdapter da;
        DataTable dt;

        void Pilotpanel()
        {

            SqlConnection baglanti = new SqlConnection("Data Source=MEHMETPALILI;Initial Catalog=pilothandbook;Integrated Security=True");


            da = new SqlDataAdapter("SELECT * FROM pilot_table", bag);

        }
        void Duyuruu()
        {

            bag = new SqlConnection("server=MEHMETPALILI; Initial Catalog=pilothandbook;Integrated Security=SSPI");
            bag.Open();
            da = new SqlDataAdapter("SELECT * FROM duyuru_table", bag);
            DataTable tablo8 = new DataTable();
            da.Fill(tablo8);
            dataGridView2.DataSource = tablo8;
            bag.Close();



        }
        void Derss()
        {

            bag = new SqlConnection("server=MEHMETPALILI; Initial Catalog=pilothandbook;Integrated Security=SSPI");
            bag.Open();
            da = new SqlDataAdapter("SELECT * FROM duyuru_table", bag);
            DataTable tablo8 = new DataTable();
            da.Fill(tablo8);
            dataGridView2.DataSource = tablo8;
            bag.Close();



        }
        private void pilotanasayfa_Load(object sender, EventArgs e)
        {

            groupBox4.Visible = true;


            label1.Text = pilotgiris.pilotgirisss;
            label3.Text = pilotgiris.pilotid;
            Duyuruu();

            string duyuru = GetLatestDuyuruFromDatabase();


            textBox2.Text = duyuru;
            string connectionString = "server=MEHMETPALILI; Initial Catalog=pilothandbook;Integrated Security=SSPI";
            bag = new SqlConnection(connectionString);


            int pilotId = Convert.ToInt32(label3.Text);


            string sorgu = "SELECT * FROM egitim_tablo WHERE pilot_id = @pilotId";
            komut = new SqlCommand(sorgu, bag);
            komut.Parameters.AddWithValue("@pilotId", pilotId);


            da = new SqlDataAdapter(komut);
            dt = new DataTable();


            da.Fill(dt);


            dataGridView1.DataSource = dt;
        }
        private string GetLatestDuyuruFromDatabase()
        {

            string sorgu = "SELECT TOP 1 duyuru FROM duyuru_table ORDER BY duyuru_id DESC";
            SqlCommand komut = new SqlCommand(sorgu, bag);
            bag.Open();
            string duyuru = komut.ExecuteScalar()?.ToString();
            bag.Close();

            return duyuru;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection baglanti = new SqlConnection("Data Source=MEHMETPALILI;Initial Catalog=pilothandbook;Integrated Security=True"))
            {
                string sorgu = "UPDATE pilot_table SET pilot_pilotnot=@pilot_pilotnot WHERE pilot_id=@pilot_id";
                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@pilot_id", label3.Text);
                komut.Parameters.AddWithValue("@pilot_pilotnot", textBox1.Text);
                baglanti.Open();
                komut.ExecuteNonQuery();
            }
            bag = new SqlConnection("server=MEHMETPALILI; Initial Catalog=pilothandbook;Integrated Security=SSPI");
            string logkayit = "INSERT INTO log_kayitlari (log_kayit,log_tarih,log_kullanici) VALUES(@log_kayit,@log_tarih,@log_kullanici)";
            komut = new SqlCommand(logkayit, bag);
            komut.Parameters.AddWithValue("@log_kayit", "PİLOT not gönderdi.");
            komut.Parameters.AddWithValue("@log_tarih", DateTime.Now);
            komut.Parameters.AddWithValue("@log_kullanici", label1.Text);
            bag.Open();
            komut.ExecuteNonQuery();
            bag.Close();
            Pilotpanel();

        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {




        }

        private void button2_Click(object sender, EventArgs e)
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
                bag = new SqlConnection("server=MEHMETPALILI; Initial Catalog=pilothandbook;Integrated Security=SSPI");
                string logcikis = "INSERT INTO log_kayitlari (log_kayit,log_tarih,log_kullanici) VALUES(@log_kayit,@log_tarih,@log_kullanici)";
                komut = new SqlCommand(logcikis, bag);
                komut.Parameters.AddWithValue("@log_kayit", "PİLOT sisteminden çıkış");
                komut.Parameters.AddWithValue("@log_tarih", DateTime.Now);
                komut.Parameters.AddWithValue("@log_kullanici", label1.Text);
                bag.Open();
                komut.ExecuteNonQuery();
                bag.Close();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            groupBox4.Visible = true; // Grup kutusunu görünür yapart

        }

        private void button3_Click(object sender, EventArgs e)
        {
            groupBox4.Visible = false; // Grup kutusunu görünür yapart

        }
    }
}
