namespace Otomasyon.KullaniciArayuzu.Concrete
{
    partial class MasaSil
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnSil = new ePOSOne.btnProduct.RoundedButton();
            this.iptalBtn2 = new ePOSOne.btnProduct.RoundedButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Ebrima", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(19, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 30);
            this.label1.TabIndex = 4;
            this.label1.Text = "Masa Numarası Seç";
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.SystemColors.Window;
            this.comboBox1.DropDownHeight = 95;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox1.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.IntegralHeight = false;
            this.comboBox1.Location = new System.Drawing.Point(55, 83);
            this.comboBox1.MaxDropDownItems = 5;
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 25);
            this.comboBox1.TabIndex = 7;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btnSil
            // 
            this.btnSil.BackColor = System.Drawing.Color.Transparent;
            this.btnSil.BorderColor = System.Drawing.Color.Transparent;
            this.btnSil.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(96)))), ((int)(((byte)(69)))));
            this.btnSil.FlatAppearance.BorderSize = 0;
            this.btnSil.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSil.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSil.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSil.Location = new System.Drawing.Point(69, 122);
            this.btnSil.Name = "btnSil";
            this.btnSil.OnHoverBorderColor = System.Drawing.Color.Transparent;
            this.btnSil.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(106)))), ((int)(((byte)(79)))));
            this.btnSil.OnHoverTextColor = System.Drawing.Color.White;
            this.btnSil.Size = new System.Drawing.Size(86, 34);
            this.btnSil.TabIndex = 42;
            this.btnSil.Text = "Kaldır";
            this.btnSil.TextColor = System.Drawing.Color.White;
            this.btnSil.UseVisualStyleBackColor = false;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
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
            this.iptalBtn2.TabIndex = 43;
            this.iptalBtn2.Text = "İptal";
            this.iptalBtn2.TextColor = System.Drawing.Color.White;
            this.iptalBtn2.UseVisualStyleBackColor = false;
            this.iptalBtn2.Click += new System.EventHandler(this.button1_Click);
            // 
            // MasaSil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Otomasyon.KullaniciArayuzu.Properties.Resources.bg21;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(227, 232);
            this.Controls.Add(this.iptalBtn2);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MasaSil";
            this.ShowInTaskbar = false;
            this.Text = "MasaSil";
            this.Load += new System.EventHandler(this.MasaSil_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox comboBox1;
		private ePOSOne.btnProduct.RoundedButton btnSil;
		private ePOSOne.btnProduct.RoundedButton iptalBtn2;
	}
}