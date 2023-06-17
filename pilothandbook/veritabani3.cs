using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pilothandbook
{
    internal class veritabani3
    {
        //paket yöneticisinden System.Data.SqlClient indirdim
        //paket yöneticisinden System.Data.SqlClient indirdim
        SqlConnection connection = new SqlConnection(@"Data source=MEHMETPALILI; initial catalog = pilothandbook;integrated Security=True");
        SqlCommand command;
        SqlDataReader reader;
        public void girisYap(string adi, string parola, supervisorgiris frm7)
        {
            command = new SqlCommand("Select * from admin where admin_ad='" + adi + "'and admin_sifre='" + parola + "'", connection);
            connection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                MessageBox.Show("Giriş Başarılı !", "Giriş", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //doğru şifre ve doğru ad okursa if
                //occgiris.gonderilecekAdminAdSoyad = reader["admin_adSoyad"].ToString(); 

                supervisorgiris.occgiris = reader["admin_ad"].ToString();
                supervisor.occid = reader["admin_id"].ToString();

                supervisor frmpilot = new supervisor();
                frm7.Hide();
                frmpilot.ShowDialog();// show ile showdialog arasındaki fark showda işlem yapılırken bunda yapılmaz

                Application.Exit();



            }
            else
            {
                frm7.BackColor = Color.Red;
                MessageBox.Show("Hatalı giriş !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
            command.Dispose();
        }
    }
}
