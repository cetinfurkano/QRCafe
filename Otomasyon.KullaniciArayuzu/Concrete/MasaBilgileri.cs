using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Otomasyon.VeriErisim.Concrete.Sql;
using Otomasyon.Veriler.Concrete;
using Otomasyon.İs.Concrete;
using System.Runtime.InteropServices;

namespace Otomasyon.KullaniciArayuzu.Concrete
{
    public partial class MasaBilgileri : Form
    {
        //deneme
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

        private string _id;
        private MasaBilgiYonetimi masaBilgiYonetimi;

        private List<MasaBilgisi> _masaBilgileri;

        private List<Musteri> _musteriler;
        private List<SiparisDetayi> _siparisDetaylari;
        private List<Siparis> _siparisler;
        private List<GecmisSiparis> _gecmisSiparisler;

        private SiparisYonetimi siparisYonetimi;
        private GecmisDetayYonetimi gecmisDetayYonetimi;
        private GecmisSiparisYonetimi gecmisSiparisYonetimi;

		public string masaAdi;


        public MasaBilgileri()
        {
            InitializeComponent();


        }

        public MasaBilgileri(string id, List<MasaBilgisi> masaBilgileri, List<SiparisDetayi> siparisDetaylari, List<Siparis> siparisler, MasaBilgiYonetimi yonetim)
        {
            siparisYonetimi = new SiparisYonetimi(new SQLSiparisDal());
            gecmisDetayYonetimi = new GecmisDetayYonetimi(new SQLGecmisDetayDal());
            gecmisSiparisYonetimi = new GecmisSiparisYonetimi(new SQLGecmisSiparisDal());

            _id = id;
            _masaBilgileri = masaBilgileri;
            _siparisler = siparisler;
            _siparisDetaylari = siparisDetaylari;
            masaBilgiYonetimi = yonetim;
            InitializeComponent();


            //yuvarlak köşeler
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

			
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MasaBilgileri_Load(object sender, EventArgs e)
        {
			label1.Text = "Masa " + masaAdi + " Siparişi";

			ToplamMasaSiparisleri();

            ButonOlustur();


            if (flwMusteriler.Controls.Count > 2)
            {
                foreach (RoundedButton2 btn in flwMusteriler.Controls)
                {
                    if (flwMusteriler.Controls.Count < 5)
                    {
                        btn.Width = (btn.Parent.Width / btn.Parent.Controls.Count) - 20;
                        btn.Height = btn.Width;
                    }
                    else
                    {
                        btn.Width = 50;
                        btn.Height = 50;
                    }
                }
            }


            if (flwToplamSiparisler.Controls.Count > 0)
            {
                btnTeslim.Visible = true;
            }
            else
            {
                btnTeslim.Visible = false;
            }

        }
        /*
				private List<Siparis> HangiMusteriKacSiparis(int id)
				{
					List<Siparis> siparisler = new List<Siparis>();

					foreach (var siparis in _siparisler)
					{
						if (siparis.Musteri.MusteriId == id)
						{
							siparisler.Add(siparis);
						}
					}

					return siparisler;
				}
				*/
        private List<Urun> HangiSiparisHangiUrun(int id)
        {
            List<Urun> urunler = new List<Urun>();

            foreach (var siparisDetayi in _siparisDetaylari)
            {
                if (siparisDetayi.Siparis.Musteri.MusteriId == id)
                {
                    urunler.Add(siparisDetayi.Urun);
                }
            }

            return urunler;
        }

        private void ToplamMasaSiparisleri()
        {
            var masaMusterileri = KacMusteriVar();

            foreach (var masaMusterisi in masaMusterileri)
            {
                foreach (var siparisDetayi in _siparisDetaylari)
                {
                    if (siparisDetayi.Siparis.Musteri.MusteriId == masaMusterisi.MusteriId)
                    {
                        Label label = new Label();
                        label.Text = siparisDetayi.Urun.UrunAdi;
                        label.Font = new Font("Ebrima", 11f, FontStyle.Bold);
                        label.AutoSize = true;
                        flwToplamSiparisler.Controls.Add(label);
                    }
                }
            }
            for (int i = 0; i < flwToplamSiparisler.Controls.Count; i++)
            {
                int a = 1;
                for (int j = 0; j < flwToplamSiparisler.Controls.Count; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }
                    if (flwToplamSiparisler.Controls[i].Text == flwToplamSiparisler.Controls[j].Text)
                    {
                        flwToplamSiparisler.Controls.Remove(flwToplamSiparisler.Controls[j]);
                        a++;
                    }
                }
                if (a > 1)
                {
                    flwToplamSiparisler.Controls[i].Text += " x" + a.ToString();
                }
            }
        }
        private List<Musteri> KacMusteriVar()
        {
            List<Musteri> musteriler = new List<Musteri>();

            foreach (var masaBilgisi in _masaBilgileri)
            {
                if (masaBilgisi.Masa.MasaId.Equals(_id))
                {
                    musteriler.Add(masaBilgisi.Musteri);
                }
            }
            return musteriler;
        }

        private void ButonOlustur()
        {
            _musteriler = KacMusteriVar();

            for (int i = 0; i < _musteriler.Count; i++)
            {
                RoundedButton2 yeniButon = new RoundedButton2();
                yeniButon.Width = 95;
                yeniButon.Height = 95;
                yeniButon.Margin = new Padding(10, 0, 0, 0);
                yeniButon.FlatStyle = FlatStyle.Flat;
                yeniButon.FlatAppearance.BorderColor = Color.FromArgb(85, 181, 140, 60);
                yeniButon.FlatAppearance.BorderSize = 0;
                yeniButon.Font = new Font("Ebrima", 10, FontStyle.Regular);
                yeniButon.BackgroundImage = Otomasyon.KullaniciArayuzu.Properties.Resources.userbg;
                yeniButon.BackgroundImageLayout = ImageLayout.Stretch;
                yeniButon.Text = _musteriler[i].KullaniciAdi;
                yeniButon.Name = _musteriler[i].MusteriId.ToString();

                yeniButon.MouseEnter += (sender, e) => yeniButon.FlatAppearance.BorderSize = 3;
                yeniButon.MouseLeave += (sender, e) => yeniButon.FlatAppearance.BorderSize = 0;

                flwMusteriler.Controls.Add(yeniButon);
                yeniButon.Click += YeniButon_Click;

            }

        }

        private void YeniButon_Click(object sender, EventArgs e)
        {
            Button yeni = (Button)sender;

            MusteriBilgileri musteriBilgileri = new MusteriBilgileri(MusteriGetir(Convert.ToInt32(yeni.Name)), HangiSiparisHangiUrun(Convert.ToInt32(yeni.Name)));

            musteriBilgileri.StartPosition = FormStartPosition.Manual;

            int yeniPosX = this.Location.X + yeni.Parent.Location.X + yeni.Location.X;
            int yeniPosY = this.Location.Y + yeni.Parent.Location.Y + yeni.Location.Y;

            if (yeniPosY > this.Location.Y + (this.Height / 2) && yeniPosX < this.Location.X + (this.Width / 2))
            {
                musteriBilgileri.Location = new Point(yeniPosX + yeni.Size.Width,
                  yeniPosY - (musteriBilgileri.Height - yeni.Height));
            }
            else if (yeniPosY < this.Location.Y + (this.Height / 2) && yeniPosX < this.Location.X + (this.Width / 2))
            {
                musteriBilgileri.Location = new Point(yeniPosX + yeni.Size.Width,
                  yeniPosY);
            }
            else if (yeniPosY < this.Location.Y + (this.Height / 2) && yeniPosX > this.Location.X + (this.Width / 2))
            {
                musteriBilgileri.Location = new Point(yeniPosX - musteriBilgileri.Width,
                  yeniPosY);
            }
            else if (yeniPosY > this.Location.Y + (this.Height / 2) && yeniPosX > this.Location.X + (this.Width / 2))
            {
                musteriBilgileri.Location = new Point(yeniPosX - musteriBilgileri.Width,
                  yeniPosY - (musteriBilgileri.Height - yeni.Height));
            }


            musteriBilgileri.Show();
            musteriBilgileri.BringToFront();


        }

        private Musteri MusteriGetir(int id)
        {
            foreach (var musteri in _musteriler)
            {
                if (musteri.MusteriId == id)
                {
                    return musteri;
                }
            }

            return null;
        }


        private void flwMusteriler_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flwToplamSiparisler_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnTeslim_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < _musteriler.Count; i++)
            {
                var siparis = SiparisGetir(_musteriler[i].MusteriId);
                if (siparis != null)
                {
                    gecmisSiparisYonetimi.Ekle(new GecmisSiparis
                    {
                        Musteri = _musteriler[i],
                        GecmisSiparisId = siparis.SiparisId,
                        VerilmeTarihi = siparis.VerilmeTarihi,
                        VerilmeZamani = siparis.VerilmeZamani,
                        TeslimTarihi = DateTime.Now.ToString("dd.MM.yyyy"),
                        TeslimZamani = DateTime.Now.ToString("HH:mm")


                    });
                    var gecmisSiparis = GecmisSiparisGetir(_musteriler[i].MusteriId);
                    

                    for (int j = 0; j < HangiSiparisHangiUrun(_musteriler[i].MusteriId).Count; j++)
                    {
                        var urun = HangiSiparisHangiUrun(_musteriler[i].MusteriId)[j];
                        gecmisDetayYonetimi.Ekle(new GecmisDetay
                        {
                            GecmisSiparis = gecmisSiparis,
                            GecmisUrun = urun,
                            GecmisFiyat = urun.Fiyat
                        });
                    }
                    siparisYonetimi.Sil(siparis);
                }
            }

            _siparisDetaylari.Clear();
            _siparisler.Clear();
            flwToplamSiparisler.Controls.Clear();
            btnTeslim.Hide();
        }

        private GecmisSiparis GecmisSiparisGetir(int id)
        {
            _gecmisSiparisler = gecmisSiparisYonetimi.HepsiniGetir();
            foreach (var item in _gecmisSiparisler)
            {
                if (item.Musteri.MusteriId == id)
                {
                    return item;
                }
            }

            return null;
        }
        private Siparis SiparisGetir(int id)
        {
            foreach (var item in _siparisler)
            {
                if (item.Musteri.MusteriId == id)
                {
                    return item;
                }
            }
            return null;
        }

        private void btnMusteriKaldir_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < _masaBilgileri.Count; i++)
            {
                if (_id == _masaBilgileri[i].Masa.MasaId)
                {
                    masaBilgiYonetimi.Sil(_masaBilgileri[i]);
                }
            }

            _masaBilgileri = masaBilgiYonetimi.HepsiniGetir();
            flwToplamSiparisler.Controls.Clear();
            flwMusteriler.Controls.Clear();
        }
    }
}
