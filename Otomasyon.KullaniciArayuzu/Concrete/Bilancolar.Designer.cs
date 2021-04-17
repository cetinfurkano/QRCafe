namespace Otomasyon.KullaniciArayuzu.Concrete
{
    partial class Bilancolar
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			this.dateBaslangic = new System.Windows.Forms.DateTimePicker();
			this.dateBitis = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.grdBilanco = new System.Windows.Forms.DataGridView();
			this.cmbSecenekler = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.grbSecenekler = new System.Windows.Forms.GroupBox();
			this.rdYillik = new System.Windows.Forms.RadioButton();
			this.rdGunluk = new System.Windows.Forms.RadioButton();
			this.btnGuncelle = new ePOSOne.btnProduct.RoundedButton();
			((System.ComponentModel.ISupportInitialize)(this.grdBilanco)).BeginInit();
			this.grbSecenekler.SuspendLayout();
			this.SuspendLayout();
			// 
			// dateBaslangic
			// 
			this.dateBaslangic.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(221)))), ((int)(((byte)(199)))));
			this.dateBaslangic.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(131)))), ((int)(((byte)(109)))));
			this.dateBaslangic.Location = new System.Drawing.Point(12, 29);
			this.dateBaslangic.Name = "dateBaslangic";
			this.dateBaslangic.Size = new System.Drawing.Size(169, 20);
			this.dateBaslangic.TabIndex = 0;
			this.dateBaslangic.ValueChanged += new System.EventHandler(this.dateBaslangic_ValueChanged);
			// 
			// dateBitis
			// 
			this.dateBitis.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(221)))), ((int)(((byte)(199)))));
			this.dateBitis.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(131)))), ((int)(((byte)(109)))));
			this.dateBitis.Location = new System.Drawing.Point(188, 29);
			this.dateBitis.Name = "dateBitis";
			this.dateBitis.Size = new System.Drawing.Size(171, 20);
			this.dateBitis.TabIndex = 1;
			this.dateBitis.ValueChanged += new System.EventHandler(this.dateBitis_ValueChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label1.Location = new System.Drawing.Point(47, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(98, 17);
			this.label1.TabIndex = 2;
			this.label1.Text = "Başlangıç Tarihi";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label2.Location = new System.Drawing.Point(243, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(67, 17);
			this.label2.TabIndex = 3;
			this.label2.Text = "Bitiş Tarihi";
			// 
			// grdBilanco
			// 
			this.grdBilanco.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.grdBilanco.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(221)))), ((int)(((byte)(199)))));
			this.grdBilanco.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.grdBilanco.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
			this.grdBilanco.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(221)))), ((int)(((byte)(199)))));
			dataGridViewCellStyle5.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(131)))), ((int)(((byte)(109)))));
			dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.grdBilanco.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
			this.grdBilanco.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(221)))), ((int)(((byte)(199)))));
			dataGridViewCellStyle6.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(131)))), ((int)(((byte)(109)))));
			dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.grdBilanco.DefaultCellStyle = dataGridViewCellStyle6;
			this.grdBilanco.Location = new System.Drawing.Point(13, 55);
			this.grdBilanco.Name = "grdBilanco";
			this.grdBilanco.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			this.grdBilanco.RowHeadersVisible = false;
			this.grdBilanco.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.grdBilanco.Size = new System.Drawing.Size(346, 156);
			this.grdBilanco.TabIndex = 4;
			this.grdBilanco.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdBilanco_CellDoubleClick);
			// 
			// cmbSecenekler
			// 
			this.cmbSecenekler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbSecenekler.Font = new System.Drawing.Font("Ebrima", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.cmbSecenekler.FormattingEnabled = true;
			this.cmbSecenekler.Items.AddRange(new object[] {
            "En Çok Satılan Ürünler?",
            "Stok Düzeyi Tehlikede Olan Ürünler"});
			this.cmbSecenekler.Location = new System.Drawing.Point(12, 307);
			this.cmbSecenekler.Name = "cmbSecenekler";
			this.cmbSecenekler.Size = new System.Drawing.Size(278, 23);
			this.cmbSecenekler.TabIndex = 5;
			this.cmbSecenekler.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label3.Location = new System.Drawing.Point(10, 287);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(206, 17);
			this.label3.TabIndex = 6;
			this.label3.Text = "Buradan Seçenekleri Secebilirsiniz.";
			// 
			// grbSecenekler
			// 
			this.grbSecenekler.BackColor = System.Drawing.Color.Transparent;
			this.grbSecenekler.Controls.Add(this.rdYillik);
			this.grbSecenekler.Controls.Add(this.rdGunluk);
			this.grbSecenekler.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.grbSecenekler.Location = new System.Drawing.Point(12, 238);
			this.grbSecenekler.Name = "grbSecenekler";
			this.grbSecenekler.Size = new System.Drawing.Size(346, 46);
			this.grbSecenekler.TabIndex = 10;
			this.grbSecenekler.TabStop = false;
			this.grbSecenekler.Text = "Diğer Seçenekler";
			// 
			// rdYillik
			// 
			this.rdYillik.AutoSize = true;
			this.rdYillik.Location = new System.Drawing.Point(234, 19);
			this.rdYillik.Name = "rdYillik";
			this.rdYillik.Size = new System.Drawing.Size(83, 21);
			this.rdYillik.TabIndex = 2;
			this.rdYillik.TabStop = true;
			this.rdYillik.Text = "Yıllık Kayıt";
			this.rdYillik.UseVisualStyleBackColor = true;
			this.rdYillik.Click += new System.EventHandler(this.rdYillik_Click);
			// 
			// rdGunluk
			// 
			this.rdGunluk.AutoSize = true;
			this.rdGunluk.Location = new System.Drawing.Point(6, 19);
			this.rdGunluk.Name = "rdGunluk";
			this.rdGunluk.Size = new System.Drawing.Size(97, 21);
			this.rdGunluk.TabIndex = 0;
			this.rdGunluk.TabStop = true;
			this.rdGunluk.Text = "Günlük Kayıt";
			this.rdGunluk.UseVisualStyleBackColor = true;
			this.rdGunluk.Click += new System.EventHandler(this.rdGunluk_Click);
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
			this.btnGuncelle.Location = new System.Drawing.Point(139, 338);
			this.btnGuncelle.Name = "btnGuncelle";
			this.btnGuncelle.OnHoverBorderColor = System.Drawing.Color.Transparent;
			this.btnGuncelle.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(106)))), ((int)(((byte)(79)))));
			this.btnGuncelle.OnHoverTextColor = System.Drawing.Color.White;
			this.btnGuncelle.Size = new System.Drawing.Size(86, 34);
			this.btnGuncelle.TabIndex = 43;
			this.btnGuncelle.Text = "Tamam";
			this.btnGuncelle.TextColor = System.Drawing.Color.White;
			this.btnGuncelle.UseVisualStyleBackColor = false;
			this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
			// 
			// Bilancolar
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = global::Otomasyon.KullaniciArayuzu.Properties.Resources.bg21;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(371, 380);
			this.Controls.Add(this.btnGuncelle);
			this.Controls.Add(this.grbSecenekler);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.cmbSecenekler);
			this.Controls.Add(this.grdBilanco);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dateBitis);
			this.Controls.Add(this.dateBaslangic);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "Bilancolar";
			this.Text = "Bilancolar";
			this.Load += new System.EventHandler(this.Bilancolar_Load);
			((System.ComponentModel.ISupportInitialize)(this.grdBilanco)).EndInit();
			this.grbSecenekler.ResumeLayout(false);
			this.grbSecenekler.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateBaslangic;
        private System.Windows.Forms.DateTimePicker dateBitis;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView grdBilanco;
        private System.Windows.Forms.ComboBox cmbSecenekler;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox grbSecenekler;
        private System.Windows.Forms.RadioButton rdYillik;
        private System.Windows.Forms.RadioButton rdGunluk;
		private ePOSOne.btnProduct.RoundedButton btnGuncelle;
	}
}