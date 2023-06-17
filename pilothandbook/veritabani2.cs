using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pilothandbook
{
    internal class veritabani2
    {
        //paket yöneticisinden System.Data.SqlClient indirdim
        SqlConnection connection = new SqlConnection(@"Data source=MEHMETPALILI; initial catalog = pilothandbook;integrated Security=True");
        SqlCommand command;
        SqlDataReader reader;
        public void girisYap(string ad, string sifre, pilotgiris frm4)
        {
            command = new SqlCommand("Select * from pilot_table where pilot_ad='" + ad + "'and pilot_soyisim='" + sifre + "'", connection);
            connection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                MessageBox.Show("Giriş Başarılı !", "Giriş", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //doğru şifre ve doğru ad okursa if
                //occgiris.gonderilecekAdminAdSoyad = reader["admin_adSoyad"].ToString(); 
  
                pilotgiris.pilotgirisss = reader["pilot_ad"].ToString();
                pilotgiris.pilotid = reader["pilot_id"].ToString();

                pilotanasayfa frmpilot = new pilotanasayfa();
                frm4.Hide();
                frmpilot.ShowDialog();// show ile showdialog arasındaki fark showda işlem yapılırken bunda yapılmaz
               
                Application.Exit();
               
               
              
            }
            else
            {
                frm4.BackColor = Color.Red;
                MessageBox.Show("Hatalı giriş !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
            command.Dispose();
        }
    }
}
