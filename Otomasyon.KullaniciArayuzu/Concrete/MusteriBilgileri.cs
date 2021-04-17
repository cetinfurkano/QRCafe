using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Otomasyon.Veriler.Concrete;
using System.Runtime.InteropServices;

namespace Otomasyon.KullaniciArayuzu.Concrete {
	public partial class MusteriBilgileri : Form {

		#region yuvarlak köşeler
		[DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
		private static extern IntPtr CreateRoundRectRgn
			(
				int nLeftRect,     // x-coordinate of upper-left corner
				int nTopRect,      // y-coordinate of upper-left corner
				int nRightRect,    // x-coordinate of lower-right corner
				int nBottomRect,   // y-coordinate of lower-right corner
				int nWidthEllipse, // height of ellipse
				int nHeightEllipse // width of ellipse
			);

		#endregion


		private Musteri _musteri;
		private List<Urun> _urunler;

		public MusteriBilgileri() {
			InitializeComponent();
		}

		public MusteriBilgileri(Musteri musteri, List<Urun> urunler) {
			_musteri = musteri;
			_urunler = urunler;
			InitializeComponent();

			//yuvarlak köşeler
			this.FormBorderStyle = FormBorderStyle.None;
			Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
		}

		private void MusteriBilgileri_Load(object sender, EventArgs e) {
			lblAd.Text = _musteri.Ad;
			lblKullaniciAdi.Text = _musteri.KullaniciAdi;
			lblKazanilanPuan.Text = _musteri.KazanilanPuan.ToString();
			lblSoyad.Text = _musteri.Soyad;

			foreach (var urun in _urunler) {
				Label lbl = new Label();
				lbl.Font = new Font("Ebrima", 10, FontStyle.Regular);
				lbl.Text += urun.UrunAdi + ", ";
				flowLayoutPanel1.Controls.Add(lbl);
			}

		}

		private void btnTamam_Click(object sender, EventArgs e) {
			this.Hide();
		}

		private void lblSiparisler_Click(object sender, EventArgs e) {

		}
	}
}
