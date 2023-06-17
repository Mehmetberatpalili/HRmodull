using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;

namespace pilothandbook
{
    internal class veritabani
    {
        //paket yöneticisinden System.Data.SqlClient indirdim
        SqlConnection connection = new SqlConnection(@"Data source=MEHMETPALILI; initial catalog = pilothandbook;integrated Security=True");
        SqlCommand command;
        SqlDataReader reader;
        public void girisYap(string ad,string sifre,Form frm1)
        {
            command = new SqlCommand("Select * from occ_bilgi where occad='" +ad+ "'and occsoyad='"+sifre+"'", connection);
            connection.Open();
            reader = command.ExecuteReader();
            if (reader.Read ())
            {
                MessageBox.Show("Giriş Başarılı !", "Giriş", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //doğru şifre ve doğru ad okursa if
                //occgiris.gonderilecekAdminAdSoyad = reader["admin_adSoyad"].ToString(); 
                occgiris.gonderilecekAdminAdSoyad = reader["occad"].ToString();
                
                
                occanasayfa frmocc = new occanasayfa();
                frm1.Hide();
                frmocc.ShowDialog();// show ile showdialog arasındaki fark showda işlem yapılırken bunda yapılmaz
                Application.Exit();
            }
            else
            {
                frm1.BackColor = Color.Red;
                MessageBox.Show("Hatalı giriş !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
            command.Dispose();  
        }
    }
}
