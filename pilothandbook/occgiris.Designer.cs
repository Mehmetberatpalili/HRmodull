namespace pilothandbook
{
    partial class occgiris
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(occgiris));
            groupBox1 = new GroupBox();
            sifreunuttum = new Button();
            btnGiris = new Button();
            txtSifre = new TextBox();
            txtAd = new TextBox();
            label2 = new Label();
            label1 = new Label();
            button1 = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Transparent;
            groupBox1.Controls.Add(sifreunuttum);
            groupBox1.Controls.Add(btnGiris);
            groupBox1.Controls.Add(txtSifre);
            groupBox1.Controls.Add(txtAd);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(160, 64);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(495, 349);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "OCC Girişi";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // sifreunuttum
            // 
            sifreunuttum.BackColor = Color.Red;
            sifreunuttum.BackgroundImageLayout = ImageLayout.None;
            sifreunuttum.FlatAppearance.BorderColor = Color.Black;
            sifreunuttum.FlatStyle = FlatStyle.Flat;
            sifreunuttum.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            sifreunuttum.ForeColor = SystemColors.ButtonHighlight;
            sifreunuttum.Location = new Point(246, 197);
            sifreunuttum.Name = "sifreunuttum";
            sifreunuttum.Size = new Size(149, 33);
            sifreunuttum.TabIndex = 5;
            sifreunuttum.Text = "Şifremi Unuttum !";
            sifreunuttum.UseVisualStyleBackColor = false;
            sifreunuttum.Click += sifreunuttum_Click;
            // 
            // btnGiris
            // 
            btnGiris.FlatStyle = FlatStyle.Flat;
            btnGiris.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnGiris.Location = new Point(176, 197);
            btnGiris.Name = "btnGiris";
            btnGiris.Size = new Size(65, 33);
            btnGiris.TabIndex = 4;
            btnGiris.Text = "Giriş";
            btnGiris.UseVisualStyleBackColor = true;
            btnGiris.Click += btnGiris_Click;
            btnGiris.MouseLeave += btnGiris_MouseLeave;
            btnGiris.MouseHover += btnGiris_MouseHover;
            // 
            // txtSifre
            // 
            txtSifre.Location = new Point(184, 146);
            txtSifre.Name = "txtSifre";
            txtSifre.Size = new Size(211, 33);
            txtSifre.TabIndex = 3;
            txtSifre.TextChanged += txtSifre_TextChanged;
            // 
            // txtAd
            // 
            txtAd.Location = new Point(184, 105);
            txtAd.Name = "txtAd";
            txtAd.Size = new Size(211, 33);
            txtAd.TabIndex = 2;
            txtAd.TextChanged += txtAd_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(96, 148);
            label2.Name = "label2";
            label2.Size = new Size(78, 25);
            label2.TabIndex = 1;
            label2.Text = "Şifre    :";
            label2.Click += label2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 105);
            label1.Name = "label1";
            label1.Size = new Size(137, 25);
            label1.TabIndex = 0;
            label1.Text = "Kullanıcı Adı  :";
            label1.Click += label1_Click;
            // 
            // button1
            // 
            button1.Location = new Point(12, 445);
            button1.Name = "button1";
            button1.Size = new Size(103, 23);
            button1.TabIndex = 1;
            button1.Text = "Güvenli Çıkış";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // occgiris
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(761, 480);
            ControlBox = false;
            Controls.Add(button1);
            Controls.Add(groupBox1);
            Name = "occgiris";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "occgiris";
            Load += occgiris_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label2;
        private Label label1;
        private TextBox txtSifre;
        private TextBox txtAd;
        private Button sifreunuttum;
        private Button btnGiris;
        private Button button1;
    }
}