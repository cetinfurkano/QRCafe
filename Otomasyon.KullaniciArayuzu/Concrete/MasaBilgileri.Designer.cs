namespace Otomasyon.KullaniciArayuzu.Concrete
{
    partial class MasaBilgileri
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
			this.flwMusteriler = new System.Windows.Forms.FlowLayoutPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.flwToplamSiparisler = new System.Windows.Forms.FlowLayoutPanel();
			this.btnTeslim = new ePOSOne.btnProduct.RoundedButton();
			this.btnGuncelle = new ePOSOne.btnProduct.RoundedButton();
			this.btnMusteriKaldir = new ePOSOne.btnProduct.RoundedButton();
			this.SuspendLayout();
			// 
			// flwMusteriler
			// 
			this.flwMusteriler.BackColor = System.Drawing.Color.Transparent;
			this.flwMusteriler.Location = new System.Drawing.Point(4, 194);
			this.flwMusteriler.Name = "flwMusteriler";
			this.flwMusteriler.Padding = new System.Windows.Forms.Padding(10, 10, 0, 0);
			this.flwMusteriler.Size = new System.Drawing.Size(339, 105);
			this.flwMusteriler.TabIndex = 13;
			this.flwMusteriler.Paint += new System.Windows.Forms.PaintEventHandler(this.flwMusteriler_Paint);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.label1.Font = new System.Drawing.Font("Ebrima", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label1.Location = new System.Drawing.Point(110, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(123, 25);
			this.label1.TabIndex = 15;
			this.label1.Text = "Masa Siparişi";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.label2.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label2.Location = new System.Drawing.Point(142, 178);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(67, 17);
			this.label2.TabIndex = 16;
			this.label2.Text = "Müşteriler";
			// 
			// flwToplamSiparisler
			// 
			this.flwToplamSiparisler.AutoScroll = true;
			this.flwToplamSiparisler.BackColor = System.Drawing.Color.Transparent;
			this.flwToplamSiparisler.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flwToplamSiparisler.Font = new System.Drawing.Font("Ebrima", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.flwToplamSiparisler.Location = new System.Drawing.Point(41, 37);
			this.flwToplamSiparisler.MinimumSize = new System.Drawing.Size(267, 94);
			this.flwToplamSiparisler.Name = "flwToplamSiparisler";
			this.flwToplamSiparisler.Padding = new System.Windows.Forms.Padding(10, 15, 0, 0);
			this.flwToplamSiparisler.Size = new System.Drawing.Size(267, 94);
			this.flwToplamSiparisler.TabIndex = 42;
			this.flwToplamSiparisler.WrapContents = false;
			this.flwToplamSiparisler.Paint += new System.Windows.Forms.PaintEventHandler(this.flwToplamSiparisler_Paint);
			// 
			// btnTeslim
			// 
			this.btnTeslim.BackColor = System.Drawing.Color.Transparent;
			this.btnTeslim.BorderColor = System.Drawing.Color.Transparent;
			this.btnTeslim.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(96)))), ((int)(((byte)(69)))));
			this.btnTeslim.FlatAppearance.BorderSize = 0;
			this.btnTeslim.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.btnTeslim.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.btnTeslim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnTeslim.Font = new System.Drawing.Font("Ebrima", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.btnTeslim.Location = new System.Drawing.Point(132, 138);
			this.btnTeslim.Name = "btnTeslim";
			this.btnTeslim.OnHoverBorderColor = System.Drawing.Color.Transparent;
			this.btnTeslim.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(106)))), ((int)(((byte)(79)))));
			this.btnTeslim.OnHoverTextColor = System.Drawing.Color.White;
			this.btnTeslim.Size = new System.Drawing.Size(86, 34);
			this.btnTeslim.TabIndex = 43;
			this.btnTeslim.Text = "Teslim Edildi";
			this.btnTeslim.TextColor = System.Drawing.Color.White;
			this.btnTeslim.UseVisualStyleBackColor = false;
			this.btnTeslim.Click += new System.EventHandler(this.btnTeslim_Click);
			// 
			// btnGuncelle
			// 
			this.btnGuncelle.BackColor = System.Drawing.Color.Transparent;
			this.btnGuncelle.BorderColor = System.Drawing.Color.Transparent;
			this.btnGuncelle.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(96)))), ((int)(((byte)(69)))));
			this.btnGuncelle.FlatAppearance.BorderSize = 0;
			this.btnGuncelle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.btnGuncelle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.btnGuncelle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnGuncelle.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.btnGuncelle.Location = new System.Drawing.Point(132, 308);
			this.btnGuncelle.Name = "btnGuncelle";
			this.btnGuncelle.OnHoverBorderColor = System.Drawing.Color.Transparent;
			this.btnGuncelle.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(106)))), ((int)(((byte)(79)))));
			this.btnGuncelle.OnHoverTextColor = System.Drawing.Color.White;
			this.btnGuncelle.Size = new System.Drawing.Size(86, 34);
			this.btnGuncelle.TabIndex = 41;
			this.btnGuncelle.Text = "Tamam";
			this.btnGuncelle.TextColor = System.Drawing.Color.White;
			this.btnGuncelle.UseVisualStyleBackColor = false;
			this.btnGuncelle.Click += new System.EventHandler(this.button1_Click);
			// 
			// btnMusteriKaldir
			// 
			this.btnMusteriKaldir.BackColor = System.Drawing.Color.Transparent;
			this.btnMusteriKaldir.BorderColor = System.Drawing.Color.Transparent;
			this.btnMusteriKaldir.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(96)))), ((int)(((byte)(69)))));
			this.btnMusteriKaldir.FlatAppearance.BorderSize = 0;
			this.btnMusteriKaldir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.btnMusteriKaldir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.btnMusteriKaldir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnMusteriKaldir.Font = new System.Drawing.Font("Ebrima", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.btnMusteriKaldir.Location = new System.Drawing.Point(257, 138);
			this.btnMusteriKaldir.Name = "btnMusteriKaldir";
			this.btnMusteriKaldir.OnHoverBorderColor = System.Drawing.Color.Transparent;
			this.btnMusteriKaldir.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(106)))), ((int)(((byte)(79)))));
			this.btnMusteriKaldir.OnHoverTextColor = System.Drawing.Color.White;
			this.btnMusteriKaldir.Size = new System.Drawing.Size(86, 34);
			this.btnMusteriKaldir.TabIndex = 45;
			this.btnMusteriKaldir.Text = "Masayı Temizle";
			this.btnMusteriKaldir.TextColor = System.Drawing.Color.White;
			this.btnMusteriKaldir.UseVisualStyleBackColor = false;
			this.btnMusteriKaldir.Click += new System.EventHandler(this.btnMusteriKaldir_Click);
			// 
			// MasaBilgileri
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ControlLight;
			this.BackgroundImage = global::Otomasyon.KullaniciArayuzu.Properties.Resources.bg21;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(350, 350);
			this.Controls.Add(this.btnMusteriKaldir);
			this.Controls.Add(this.btnTeslim);
			this.Controls.Add(this.flwToplamSiparisler);
			this.Controls.Add(this.btnGuncelle);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.flwMusteriler);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "MasaBilgileri";
			this.ShowInTaskbar = false;
			this.Text = "MasaBilgileri";
			this.Load += new System.EventHandler(this.MasaBilgileri_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flwMusteriler;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private ePOSOne.btnProduct.RoundedButton btnGuncelle;
		private System.Windows.Forms.FlowLayoutPanel flwToplamSiparisler;
		private ePOSOne.btnProduct.RoundedButton btnTeslim;
		private ePOSOne.btnProduct.RoundedButton btnMusteriKaldir;
	}
}