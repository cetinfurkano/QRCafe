namespace Otomasyon.KullaniciArayuzu
{
    partial class MasaEkle
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
            this.txtMasaNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGuncelle = new ePOSOne.btnProduct.RoundedButton();
            this.iptalBtn2 = new ePOSOne.btnProduct.RoundedButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMasaNo
            // 
            this.txtMasaNo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMasaNo.Font = new System.Drawing.Font("Ebrima", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtMasaNo.Location = new System.Drawing.Point(12, 85);
            this.txtMasaNo.Name = "txtMasaNo";
            this.txtMasaNo.Size = new System.Drawing.Size(203, 21);
            this.txtMasaNo.TabIndex = 0;
            this.txtMasaNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMasaNo.TextChanged += new System.EventHandler(this.txtMasaNo_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Ebrima", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(18, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "Masa Numarası Gir";
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
            this.btnGuncelle.Location = new System.Drawing.Point(69, 122);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.OnHoverBorderColor = System.Drawing.Color.Transparent;
            this.btnGuncelle.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(106)))), ((int)(((byte)(79)))));
            this.btnGuncelle.OnHoverTextColor = System.Drawing.Color.White;
            this.btnGuncelle.Size = new System.Drawing.Size(86, 34);
            this.btnGuncelle.TabIndex = 41;
            this.btnGuncelle.Text = "Ekle";
            this.btnGuncelle.TextColor = System.Drawing.Color.White;
            this.btnGuncelle.UseVisualStyleBackColor = false;
            this.btnGuncelle.Click += new System.EventHandler(this.button1_Click);
            // 
            // iptalBtn2
            // 
            this.iptalBtn2.BackColor = System.Drawing.Color.Transparent;
            this.iptalBtn2.BorderColor = System.Drawing.Color.Transparent;
            this.iptalBtn2.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(96)))), ((int)(((byte)(69)))));
            this.iptalBtn2.FlatAppearance.BorderSize = 0;
            this.iptalBtn2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.iptalBtn2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.iptalBtn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iptalBtn2.Font = new System.Drawing.Font("Ebrima", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.iptalBtn2.Location = new System.Drawing.Point(83, 157);
            this.iptalBtn2.Name = "iptalBtn2";
            this.iptalBtn2.OnHoverBorderColor = System.Drawing.Color.Transparent;
            this.iptalBtn2.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(106)))), ((int)(((byte)(79)))));
            this.iptalBtn2.OnHoverTextColor = System.Drawing.Color.White;
            this.iptalBtn2.Size = new System.Drawing.Size(60, 28);
            this.iptalBtn2.TabIndex = 42;
            this.iptalBtn2.Text = "İptal";
            this.iptalBtn2.TextColor = System.Drawing.Color.White;
            this.iptalBtn2.UseVisualStyleBackColor = false;
            this.iptalBtn2.Click += new System.EventHandler(this.button2_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // MasaEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Otomasyon.KullaniciArayuzu.Properties.Resources.bg21;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(227, 232);
            this.Controls.Add(this.iptalBtn2);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMasaNo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MasaEkle";
            this.ShowInTaskbar = false;
            this.Text = "Masa Ekle";
            this.Load += new System.EventHandler(this.MasaEkle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMasaNo;
        private System.Windows.Forms.Label label1;
		private ePOSOne.btnProduct.RoundedButton btnGuncelle;
		private ePOSOne.btnProduct.RoundedButton iptalBtn2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}