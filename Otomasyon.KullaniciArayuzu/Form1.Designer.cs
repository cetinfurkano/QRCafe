namespace Otomasyon.KullaniciArayuzu
{
    partial class Form1
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
			this.components = new System.ComponentModel.Container();
			this.label1 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.button3 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.flwMasalar = new System.Windows.Forms.FlowLayoutPanel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.btnUstKategori = new ePOSOne.btnProduct.RoundedButton();
			this.btnUrunAyarlari = new ePOSOne.btnProduct.RoundedButton();
			this.btnKategoriAyar = new ePOSOne.btnProduct.RoundedButton();
			this.btnKaldir = new ePOSOne.btnProduct.RoundedButton();
			this.btnEkle = new ePOSOne.btnProduct.RoundedButton();
			this.btnGunSonu = new RoundedButton2();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Ebrima", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(176)))), ((int)(((byte)(75)))));
			this.label1.Location = new System.Drawing.Point(35, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(106, 32);
			this.label1.TabIndex = 10;
			this.label1.Text = "QRCAFE";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = global::Otomasyon.KullaniciArayuzu.Properties.Resources.qrcafelogo;
			this.pictureBox1.Location = new System.Drawing.Point(3, 3);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(32, 32);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 9;
			this.pictureBox1.TabStop = false;
			// 
			// button3
			// 
			this.button3.BackgroundImage = global::Otomasyon.KullaniciArayuzu.Properties.Resources.kapat;
			this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.button3.FlatAppearance.BorderSize = 0;
			this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button3.Location = new System.Drawing.Point(934, 12);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(18, 18);
			this.button3.TabIndex = 8;
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button2
			// 
			this.button2.BackgroundImage = global::Otomasyon.KullaniciArayuzu.Properties.Resources.tamekran;
			this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.button2.FlatAppearance.BorderSize = 0;
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button2.Location = new System.Drawing.Point(910, 12);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(18, 18);
			this.button2.TabIndex = 7;
			this.button2.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			this.button1.BackgroundImage = global::Otomasyon.KullaniciArayuzu.Properties.Resources.simge;
			this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.button1.FlatAppearance.BorderSize = 0;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Location = new System.Drawing.Point(884, 12);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(18, 18);
			this.button1.TabIndex = 6;
			this.button1.UseVisualStyleBackColor = true;
			// 
			// flwMasalar
			// 
			this.flwMasalar.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.flwMasalar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(221)))), ((int)(((byte)(199)))));
			this.flwMasalar.BackgroundImage = global::Otomasyon.KullaniciArayuzu.Properties.Resources.flwbg;
			this.flwMasalar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.flwMasalar.Location = new System.Drawing.Point(38, 38);
			this.flwMasalar.Name = "flwMasalar";
			this.flwMasalar.Padding = new System.Windows.Forms.Padding(10, 20, 0, 10);
			this.flwMasalar.Size = new System.Drawing.Size(888, 453);
			this.flwMasalar.TabIndex = 1;
			this.flwMasalar.Paint += new System.Windows.Forms.PaintEventHandler(this.flwMasalar_Paint);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnGunSonu);
			this.panel1.Location = new System.Drawing.Point(3, 38);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(960, 527);
			this.panel1.TabIndex = 16;
			this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
			// 
			// timer1
			// 
			this.timer1.Interval = 10000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// btnUstKategori
			// 
			this.btnUstKategori.BorderColor = System.Drawing.Color.Transparent;
			this.btnUstKategori.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
			this.btnUstKategori.FlatAppearance.BorderSize = 0;
			this.btnUstKategori.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
			this.btnUstKategori.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
			this.btnUstKategori.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnUstKategori.Font = new System.Drawing.Font("Ebrima", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.btnUstKategori.Location = new System.Drawing.Point(676, 493);
			this.btnUstKategori.Name = "btnUstKategori";
			this.btnUstKategori.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			this.btnUstKategori.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(146)))), ((int)(((byte)(115)))));
			this.btnUstKategori.OnHoverTextColor = System.Drawing.Color.Black;
			this.btnUstKategori.Size = new System.Drawing.Size(121, 71);
			this.btnUstKategori.TabIndex = 15;
			this.btnUstKategori.Text = "Üst Kategori Ayarları";
			this.btnUstKategori.TextColor = System.Drawing.Color.White;
			this.btnUstKategori.UseVisualStyleBackColor = true;
			this.btnUstKategori.Click += new System.EventHandler(this.btnUstKategori_Click);
			// 
			// btnUrunAyarlari
			// 
			this.btnUrunAyarlari.BorderColor = System.Drawing.Color.Transparent;
			this.btnUrunAyarlari.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
			this.btnUrunAyarlari.FlatAppearance.BorderSize = 0;
			this.btnUrunAyarlari.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
			this.btnUrunAyarlari.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
			this.btnUrunAyarlari.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnUrunAyarlari.Font = new System.Drawing.Font("Ebrima", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.btnUrunAyarlari.Location = new System.Drawing.Point(549, 492);
			this.btnUrunAyarlari.Name = "btnUrunAyarlari";
			this.btnUrunAyarlari.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			this.btnUrunAyarlari.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(146)))), ((int)(((byte)(115)))));
			this.btnUrunAyarlari.OnHoverTextColor = System.Drawing.Color.Black;
			this.btnUrunAyarlari.Size = new System.Drawing.Size(121, 71);
			this.btnUrunAyarlari.TabIndex = 14;
			this.btnUrunAyarlari.Text = "Ürün Ayarları";
			this.btnUrunAyarlari.TextColor = System.Drawing.Color.White;
			this.btnUrunAyarlari.UseVisualStyleBackColor = true;
			this.btnUrunAyarlari.Click += new System.EventHandler(this.btnUrunAyarlari_Click);
			// 
			// btnKategoriAyar
			// 
			this.btnKategoriAyar.BorderColor = System.Drawing.Color.Transparent;
			this.btnKategoriAyar.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
			this.btnKategoriAyar.FlatAppearance.BorderSize = 0;
			this.btnKategoriAyar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
			this.btnKategoriAyar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
			this.btnKategoriAyar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnKategoriAyar.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.btnKategoriAyar.Location = new System.Drawing.Point(422, 492);
			this.btnKategoriAyar.Name = "btnKategoriAyar";
			this.btnKategoriAyar.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			this.btnKategoriAyar.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(146)))), ((int)(((byte)(115)))));
			this.btnKategoriAyar.OnHoverTextColor = System.Drawing.Color.Black;
			this.btnKategoriAyar.Size = new System.Drawing.Size(121, 71);
			this.btnKategoriAyar.TabIndex = 13;
			this.btnKategoriAyar.Text = "Kategori Ayarları";
			this.btnKategoriAyar.TextColor = System.Drawing.Color.White;
			this.btnKategoriAyar.UseVisualStyleBackColor = true;
			this.btnKategoriAyar.Click += new System.EventHandler(this.btnKategoriAyar_Click);
			// 
			// btnKaldir
			// 
			this.btnKaldir.BorderColor = System.Drawing.Color.Transparent;
			this.btnKaldir.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
			this.btnKaldir.FlatAppearance.BorderSize = 0;
			this.btnKaldir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
			this.btnKaldir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
			this.btnKaldir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnKaldir.Font = new System.Drawing.Font("Ebrima", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.btnKaldir.Location = new System.Drawing.Point(295, 492);
			this.btnKaldir.Name = "btnKaldir";
			this.btnKaldir.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			this.btnKaldir.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(146)))), ((int)(((byte)(115)))));
			this.btnKaldir.OnHoverTextColor = System.Drawing.Color.Black;
			this.btnKaldir.Size = new System.Drawing.Size(121, 71);
			this.btnKaldir.TabIndex = 12;
			this.btnKaldir.Text = "Masa Kaldır";
			this.btnKaldir.TextColor = System.Drawing.Color.White;
			this.btnKaldir.UseVisualStyleBackColor = true;
			this.btnKaldir.Click += new System.EventHandler(this.btnKaldir_Click);
			// 
			// btnEkle
			// 
			this.btnEkle.BorderColor = System.Drawing.Color.Transparent;
			this.btnEkle.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
			this.btnEkle.FlatAppearance.BorderSize = 0;
			this.btnEkle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
			this.btnEkle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
			this.btnEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnEkle.Font = new System.Drawing.Font("Ebrima", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.btnEkle.Location = new System.Drawing.Point(168, 492);
			this.btnEkle.Name = "btnEkle";
			this.btnEkle.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			this.btnEkle.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(146)))), ((int)(((byte)(115)))));
			this.btnEkle.OnHoverTextColor = System.Drawing.Color.Black;
			this.btnEkle.Size = new System.Drawing.Size(121, 71);
			this.btnEkle.TabIndex = 11;
			this.btnEkle.Text = "Masa Ekle";
			this.btnEkle.TextColor = System.Drawing.Color.White;
			this.btnEkle.UseVisualStyleBackColor = true;
			this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
			// 
			// btnGunSonu
			// 
			this.btnGunSonu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
			this.btnGunSonu.BorderColor = System.Drawing.Color.Transparent;
			this.btnGunSonu.FlatAppearance.BorderSize = 0;
			this.btnGunSonu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnGunSonu.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.btnGunSonu.ForeColor = System.Drawing.SystemColors.ControlLight;
			this.btnGunSonu.Location = new System.Drawing.Point(875, 475);
			this.btnGunSonu.Name = "btnGunSonu";
			this.btnGunSonu.Size = new System.Drawing.Size(75, 43);
			this.btnGunSonu.TabIndex = 1;
			this.btnGunSonu.Text = "Gün Sonu";
			this.btnGunSonu.UseVisualStyleBackColor = false;
			this.btnGunSonu.Click += new System.EventHandler(this.button4_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
			this.ClientSize = new System.Drawing.Size(964, 567);
			this.ControlBox = false;
			this.Controls.Add(this.btnUstKategori);
			this.Controls.Add(this.btnUrunAyarlari);
			this.Controls.Add(this.btnKategoriAyar);
			this.Controls.Add(this.btnKaldir);
			this.Controls.Add(this.btnEkle);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.flwMasalar);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Patron Giriş Ekranı";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flwMasalar;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label1;
		private ePOSOne.btnProduct.RoundedButton btnEkle;
		private ePOSOne.btnProduct.RoundedButton btnKaldir;
		private ePOSOne.btnProduct.RoundedButton btnKategoriAyar;
		private ePOSOne.btnProduct.RoundedButton btnUrunAyarlari;
		private ePOSOne.btnProduct.RoundedButton btnUstKategori;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Timer timer1;
		private RoundedButton2 btnGunSonu;
	}
}

