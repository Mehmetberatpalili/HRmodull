namespace pilothandbook
{
    partial class supervisorgiris
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(supervisorgiris));
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            txtAdi = new TextBox();
            txtParola = new TextBox();
            btnGiris = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(12, 415);
            button1.Name = "button1";
            button1.Size = new Size(90, 23);
            button1.TabIndex = 3;
            button1.Text = "Güvenli Çıkış";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(236, 193);
            label1.Name = "label1";
            label1.Size = new Size(137, 25);
            label1.TabIndex = 0;
            label1.Text = "Kullanıcı Adı  :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(295, 233);
            label2.Name = "label2";
            label2.Size = new Size(78, 25);
            label2.TabIndex = 1;
            label2.Text = "Şifre    :";
            // 
            // txtAdi
            // 
            txtAdi.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtAdi.BorderStyle = BorderStyle.None;
            txtAdi.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            txtAdi.Location = new Point(375, 199);
            txtAdi.Name = "txtAdi";
            txtAdi.Size = new Size(168, 18);
            txtAdi.TabIndex = 2;
            txtAdi.TextChanged += txtAd_TextChanged;
            // 
            // txtParola
            // 
            txtParola.BorderStyle = BorderStyle.None;
            txtParola.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            txtParola.Location = new Point(375, 238);
            txtParola.Name = "txtParola";
            txtParola.Size = new Size(168, 18);
            txtParola.TabIndex = 3;
            // 
            // btnGiris
            // 
            btnGiris.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnGiris.Location = new Point(426, 282);
            btnGiris.Name = "btnGiris";
            btnGiris.Size = new Size(65, 33);
            btnGiris.TabIndex = 4;
            btnGiris.Text = "Giriş";
            btnGiris.UseVisualStyleBackColor = true;
            btnGiris.Click += btnGiris_Click;
            // 
            // supervisorgiris
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(800, 450);
            ControlBox = false;
            Controls.Add(button1);
            Controls.Add(btnGiris);
            Controls.Add(txtParola);
            Controls.Add(txtAdi);
            Controls.Add(label1);
            Controls.Add(label2);
            Name = "supervisorgiris";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "supervisorgiris";
            Load += supervisorgiris_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button1;
        private Label label1;
        private Label label2;
        private TextBox txtAdi;
        private TextBox txtParola;
        private Button btnGiris;
    }
}