namespace pilothandbook
{
    public partial class giris : Form
    {


        public giris()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Visible = false;
            button1.Visible = (true);
            button2.Visible = (true);
            button4.Visible = (true);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            giris f1 = new giris();
            occgiris f2 = new occgiris();
            f2.Show();  // form2 göster diyoruz

            this.Hide();   // bu yani form1 gizle diyoruz
                           //Application.Exit();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            giris f1 = new giris();
            pilotgiris f4 = new pilotgiris();
            f4.Show();  // form2 göster diyoruz

            this.Hide();   // bu yani form1 gizle diyoruz
                           //Application.Exit();
        }

        private void giris_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            giris f8 = new giris();
            supervisorgiris f9 = new supervisorgiris();
            f9.Show();  // form2 göster diyoruz

            this.Hide();   // bu yani form1 gizle diyoruz
                           //Application.Exit();
        }
    }
}