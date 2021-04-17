using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Otomasyon.KullaniciArayuzu.Concrete;
using Otomasyon.İs.Concrete;
using Otomasyon.VeriErisim.Concrete.Sql;
using ePOSOne.btnProduct;
using Otomasyon.Veriler.Concrete;

namespace Otomasyon.KullaniciArayuzu
{	
    public partial class Form1 : Form
    {
		
        MasaYonetimi masaYonetimi = new MasaYonetimi(new SQLMasaDal());
        SiparisDetayYonetimi siparisDetayYonetimi = new SiparisDetayYonetimi(new SQLSiparisDetayiDal());
        MasaBilgiYonetimi masaBilgiYonetimi = new MasaBilgiYonetimi(new SQLMasaBilgileriDal());
        UstKategoriYonetimi ustKategoriYonetimi = new UstKategoriYonetimi(new SQLUstKategoriDal());
        SiparisYonetimi siparisYonetimi  = new SiparisYonetimi(new SQLSiparisDal());

        private bool siparisVermis = false;

        private List<Masa> masalar;
		private List<MasaBilgisi> masaBilgiler;
		private List<Siparis> siparisler;

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

        #region uygulamayı sürükle
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        #endregion

        public Form1()
        {

            InitializeComponent();

            //yuvarlak köşeler
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, -10, Width, Height, 20, 20));

            this.BackColor = Color.FromArgb(33, 23, 23);
            button1.BackColor = Color.FromArgb(33, 23, 23);
            button2.BackColor = Color.FromArgb(33, 23, 23);
            button3.BackColor = Color.FromArgb(33, 23, 23);
            flwMasalar.BackColor = Color.FromArgb(223, 221, 199);
            label1.ForeColor = Color.FromArgb(227, 176, 75);
        }


        private void Form1_Load(object sender, EventArgs e)
        {
			timer1.Start();
            ButonOlustur();
        }


        private void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //uygulamayı  sürükle
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }


		private void ButonOlustur() {
			masalar = masaYonetimi.HepsiniGetir();
			masaBilgiler = masaBilgiYonetimi.HepsiniGetir();
			siparisler = siparisYonetimi.HepsiniGetir();

			for (int i = 0; i < masalar.Count; i++) {
				RoundedButton2 yeniButon = new RoundedButton2();
				yeniButon.Width = 85;
				yeniButon.Height = 85;
				yeniButon.Margin = new Padding(10, 0, 0, 10);
				yeniButon.FlatStyle = FlatStyle.Flat;
				yeniButon.FlatAppearance.BorderSize = 0;
				yeniButon.Font = new Font("Ebrima", 13, FontStyle.Bold);
				yeniButon.Text = masalar[i].MasaId;
				yeniButon.Name = masalar[i].MasaId;
				yeniButon.ForeColor = Color.White;
				yeniButon.MouseEnter += (sender, e) => yeniButon.ForeColor = Color.Black;
				yeniButon.MouseLeave += (sender, e) => yeniButon.ForeColor = Color.White;

				if (masalar[i].MusaitlikDurumu) {
					yeniButon.BackColor = Color.FromArgb(135, 160, 116, 63);
				}
				else {
					yeniButon.BackColor = Color.FromArgb(135, 35, 116, 35);
				}

				flwMasalar.Controls.Add(yeniButon);
				yeniButon.Click += YeniButon_Click;
			}

			for (int j = 0; j < masaBilgiler.Count; j++)
            {
				if (masaBilgiler[j].Musteri != null)
                {
					siparisVermis = false;
					for (int k = 0; k < siparisler.Count; k++)
                    {
						if (masaBilgiler[j].Musteri.MusteriId == siparisler[k].Musteri.MusteriId)
                        {
                            siparisVermis = true;
                            RoundedButton2 masa = flwMasalar.Controls.Find(masaBilgiler[j].Masa.MasaId, true).FirstOrDefault() as RoundedButton2;
							masa.BackColor = Color.FromArgb(200, 25, 25); 
						}
					}

                    if (siparisVermis == false)
                    {
                        var zaman = Convert.ToDateTime(masaBilgiler[j].AcilmaZamani);
                        var simdi = DateTime.Now;

                        TimeSpan ts = simdi.Subtract(zaman);

                        if (ts.TotalMinutes > 1f && ts.TotalMinutes <= 2f)
                        {
                            RoundedButton2 masa = flwMasalar.Controls.Find(masaBilgiler[j].Masa.MasaId, true).FirstOrDefault() as RoundedButton2;
                            masa.BackColor = Color.FromArgb(155, 30, 30, 90);
                        }
                        else if (ts.TotalMinutes > 2f && ts.TotalMinutes <= 3f)
                        {
                            RoundedButton2 masa = flwMasalar.Controls.Find(masaBilgiler[j].Masa.MasaId, true).FirstOrDefault() as RoundedButton2;
                            masa.BackColor = Color.FromArgb(175, 40, 85, 100);
                        }

                        else if (ts.TotalMinutes > 3f && ts.TotalMinutes <= 4f)
                        {
                            RoundedButton2 masa = flwMasalar.Controls.Find(masaBilgiler[j].Masa.MasaId, true).FirstOrDefault() as RoundedButton2;
                            masa.BackColor = Color.FromArgb(195, 50, 75, 140);
                        }
                        else if (ts.TotalMinutes > 3f && ts.TotalMinutes <= 4f)
                        {
                            RoundedButton2 masa = flwMasalar.Controls.Find(masaBilgiler[j].Masa.MasaId, true).FirstOrDefault() as RoundedButton2;
                            masa.BackColor = Color.FromArgb(225, 50, 65, 160);
                        }

                        else if (ts.TotalMinutes > 4f)
                        {
                            RoundedButton2 masa = flwMasalar.Controls.Find(masaBilgiler[j].Masa.MasaId, true).FirstOrDefault() as RoundedButton2;
                            masa.BackColor = Color.FromArgb(255, 50, 55, 235);
                        }
                    }
					
				}
			}
		}

        private void YeniButon_Click(object sender, EventArgs e)
        {
            var siparisDetaylari = siparisDetayYonetimi.HepsiniGetir();


            Button yeni = (Button)sender;

            MasaBilgileri masaBilgileri = new MasaBilgileri(yeni.Text, masaBilgiler, siparisDetaylari, siparisler, masaBilgiYonetimi);

			masaBilgileri.masaAdi = yeni.Text;

            masaBilgileri.StartPosition = FormStartPosition.Manual;
            if (yeni.Location.X <= flwMasalar.Size.Width / 2)
            {
				masaBilgileri.Location = new Point(this.Location.X + yeni.Parent.Location.X + yeni.Location.X + yeni.Size.Width,
				  this.Location.Y + yeni.Parent.Location.Y + yeni.Location.Y);
			}
            else
            {
                masaBilgileri.Location = new Point(
                    (this.Location.X + yeni.Parent.Location.X + yeni.Location.X) - masaBilgileri.Size.Width,
                    this.Location.Y + yeni.Parent.Location.Y + yeni.Location.Y);
            }

			masaBilgileri.ShowDialog();
        }


        private void btnEkle_Click(object sender, EventArgs e)
        {
            MasaEkle masaEkle = new MasaEkle(flwMasalar,masalar);

            masaEkle.StartPosition = FormStartPosition.Manual;
            masaEkle.Location = new Point(
                (this.Location.X + btnEkle.Location.X + btnEkle.Size.Width / 2) - masaEkle.Size.Width / 2,
                (this.Location.Y + btnEkle.Location.Y) - masaEkle.Size.Height);

            masaEkle.ShowDialog();

        }

        private void btnKaldir_Click(object sender, EventArgs e)
        {
            MasaSil masaSil = new MasaSil(flwMasalar);

            masaSil.StartPosition = FormStartPosition.Manual;
            masaSil.Location = new Point(
                (this.Location.X + btnKaldir.Location.X + btnKaldir.Size.Width / 2) - masaSil.Size.Width / 2,
                (this.Location.Y + btnKaldir.Location.Y) - masaSil.Size.Height);

            masaSil.ShowDialog();
        }


        public void Reset(FlowLayoutPanel panel)
        {
            flwMasalar = panel;

            ButonOlustur();

        }

        private void btnUrunAyarlari_Click(object sender, EventArgs e)
        {
            Urun_Ayarları urunAyarları = new Urun_Ayarları();

            urunAyarları.StartPosition = FormStartPosition.Manual;
            urunAyarları.Location = new Point(
                (this.Location.X + btnUrunAyarlari.Location.X + btnUrunAyarlari.Size.Width / 2) - urunAyarları.Size.Width / 2,
                (this.Location.Y + btnUrunAyarlari.Location.Y) - urunAyarları.Size.Height);

            urunAyarları.ShowDialog();
        }

        private void btnKategoriAyar_Click(object sender, EventArgs e)
        {
            KategoriAyarlari kategoriAyarlari = new KategoriAyarlari(ustKategoriYonetimi.HepsiniGetir());

            kategoriAyarlari.StartPosition = FormStartPosition.Manual;
            kategoriAyarlari.Location = new Point(
                (this.Location.X + btnKategoriAyar.Location.X + btnKategoriAyar.Size.Width / 2) - kategoriAyarlari.Size.Width / 2,
                (this.Location.Y + btnKategoriAyar.Location.Y) - kategoriAyarlari.Size.Height);

            kategoriAyarlari.ShowDialog();
        }

        private void btnUstKategori_Click(object sender, EventArgs e)
        {
            UstKategoriAyarlari ustKategoriAyarlari = new UstKategoriAyarlari();

            ustKategoriAyarlari.StartPosition = FormStartPosition.Manual;
            ustKategoriAyarlari.Location = new Point(
                (this.Location.X + btnUstKategori.Location.X + btnUstKategori.Size.Width / 2) - ustKategoriAyarlari.Size.Width / 2,
                (this.Location.Y + btnUstKategori.Location.Y) - ustKategoriAyarlari.Size.Height);

            ustKategoriAyarlari.ShowDialog();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void flwMasalar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            GunSonuBilgileri gunSonu = new GunSonuBilgileri();
			gunSonu.StartPosition = FormStartPosition.Manual;
			gunSonu.Location = new Point(this.Location.X + btnGunSonu.Location.X + btnGunSonu.Width - gunSonu.Width, this.Location.Y + btnGunSonu.Location.Y + btnGunSonu.Height - gunSonu.Height - 5);
            gunSonu.ShowDialog();
        }

		private void panel1_Paint(object sender, PaintEventArgs e) {

		}

		private void timer1_Tick(object sender, EventArgs e) {
			flwMasalar.Controls.Clear();
			Reset(flwMasalar);
		}
	}
}
