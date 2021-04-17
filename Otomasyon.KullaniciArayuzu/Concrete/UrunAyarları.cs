using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Otomasyon.VeriErisim.Concrete.Sql;
using Otomasyon.Veriler.Concrete;
using Otomasyon.İs.Concrete;
using System.Runtime.InteropServices;
using Otomasyon.KullaniciArayuzu.Exceptions;

namespace Otomasyon.KullaniciArayuzu.Concrete
{
    public partial class Urun_Ayarları : Form
    {

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

        private UrunYonetimi _urunYonetimi;

        private KategoriYonetimi _kategoriYonetimi;
        private UrunResimYonetimi _urunResimYonetimi;

        private bool _guncellenecekMi;

        private List<Kategori> _kategoriler;
        private List<Urun> _urunler;
        private List<UrunResmi> _resimler;

        private byte[] _resim;

        private string _resimYolu;


        private bool _eklenecekMi = false;

        private bool resimliMi = false;

        private bool gncKtg, gncFyt, gncStok, gncPuan,gncAlis, rdgncEvet, rdgncHayır;

        private string _yeniAd;

        List<Panel> paneller = new List<Panel>();
        int index = 0;

        public Urun_Ayarları()
        {
            _urunYonetimi = new UrunYonetimi(new SQLUrunDal());
            _kategoriYonetimi = new KategoriYonetimi(new SQLKategoriDal());
            _urunResimYonetimi = new UrunResimYonetimi(new SQLUrunResmiDal());


            InitializeComponent();

			//yuvarlak köşeler
			
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private bool AktifMi()
        {
            if (rdEvet.Checked || rdGuncelleEvet.Checked)
            {
                return true;
            }

            return false;
        }

       

        private void Urun_Ayarları_Load(object sender, EventArgs e)
        {


            ComboDoldur();

            paneller.Add(panel1);
            paneller.Add(panel3);
            paneller.Add(panel2);

            geriBtn1.Click += new EventHandler(IndexAzalt);
            geriBtn2.Click += new EventHandler(IndexAzalt);
            geriBtn3.Click += new EventHandler(IndexAzalt);

            ileriBtn1.Click += new EventHandler(IndexArttir);
            ileriBtn2.Click += new EventHandler(IndexArttir);
            ileriBtn3.Click += new EventHandler(IndexArttir);

            iptalBtn1.Click += new EventHandler(Iptal);
            iptalBtn2.Click += new EventHandler(Iptal);
            iptalBtn3.Click += new EventHandler(Iptal);

            PanelGoster();
        }

        void PanelGoster()
        {
            for (int i = 0; i < paneller.Count; i++)
            {
                if (i == index)
                {
                    paneller[i].Show();
                    paneller[i].BringToFront();
                }
                else
                {
                    paneller[i].SendToBack();
                    paneller[i].Hide();
                }
            }
        }


        private Kategori KategoriGetir(string KategoriAdi)
        {

            foreach (var item in _kategoriler)
            {
                if (item.KategoriAdi.Equals(KategoriAdi))
                {
                    return item;
                }
            }
            return null;
        }


        private Urun UrunGetir(string UrunAdi)
        {
            _urunler = _urunYonetimi.HepsiniGetir();
            foreach (var item in _urunler)
            {
                if (item.UrunAdi.Equals(UrunAdi))
                {
                    return item;
                }
            }
            return null;
        }

        private UrunResmi ResimGetir(string urunAdi)
        {
            _resimler = _urunResimYonetimi.HepsiniGetir();
            foreach (var item in _resimler)
            {
                if (item.Urun.UrunAdi.Equals(urunAdi))
                {
                    return item;
                }
            }
            return null;
        }


        private void ComboDoldur()
        {
            cmbKategoriler.Items.Clear();
            cmbUrunAdi.Items.Clear();
            cmbGuncellenecekAd.Items.Clear();
            cmbGuncellenecekKategori.Items.Clear();

            cmbKategoriler.SelectionStart = 0;
            cmbGuncellenecekKategori.SelectionStart = 0;
            cmbUrunAdi.SelectionStart = 0;
            cmbGuncellenecekAd.SelectionStart = 0;

            _kategoriler = _kategoriYonetimi.HepsiniGetir();
            _urunler = _urunYonetimi.HepsiniGetir();
            _resimler = _urunResimYonetimi.HepsiniGetir();


            foreach (var item in _kategoriler)
            {
                cmbKategoriler.Items.Add(item.KategoriAdi);
                cmbGuncellenecekKategori.Items.Add(item.KategoriAdi);
            }

            foreach (var item in _urunler)
            {
                cmbUrunAdi.Items.Add(item.UrunAdi);
                cmbGuncellenecekAd.Items.Add(item.UrunAdi);
            }
        }

        private void Guncelle()
        {

            if (cmbGuncellenecekAd.SelectedItem == null || cmbGuncellenecekKategori == null || txtGuncellenecekAd.Text == null ||
                txtGuncellenecekFiyat == null || txtGuncellenecekPuan == null || txtGuncellenecekStok == null || txtGuncellenecekPuanUcreti.Text== null
                || (rdGuncelleEvet.Checked == false && rdGuncelleHayir.Checked == false))
            {
                throw new BosVeriGirmeHatasi("Lütfen tüm alanları doldurunuz.");
            }
            if (gncKtg == false & gncFyt == false & gncAlis==false & gncPuan == false & gncStok == false & (rdgncEvet == false || rdgncHayır == false))
            {
                if (AyniUrunVarMi(txtGuncellenecekAd.Text))
                {
                    throw new VeriTekrariHatasi("Bu kayıt zaten mevcut");
                }
            }

            _urunYonetimi.Guncelle(new Urun
            {
                Fiyat = Convert.ToSingle(txtGuncellenecekFiyat.Text),
                Kategori = KategoriGetir(cmbGuncellenecekKategori.SelectedItem.ToString()),
                UrunAdi = txtGuncellenecekAd.Text,
                UrunPuani = Convert.ToSingle(txtGuncellenecekFiyat.Text),
                StokDuzeyi = Convert.ToInt32(txtGuncellenecekStok.Text),
                UrunId = UrunGetir(cmbGuncellenecekAd.SelectedItem.ToString()).UrunId,
                AktifMi = AktifMi(),
				AlisPuani = Convert.ToSingle(txtGuncellenecekPuanUcreti.Text)
           });

            if (resimliMi)
            {

                var urun = UrunGetir(txtGuncellenecekAd.Text);

                if (_guncellenecekMi)
                {
                    _urunResimYonetimi.Guncelle(new UrunResmi
                    {
                        Urun = urun,
                        ResimAdi = _yeniAd,
                        ResimYolu = "/KafeResimleri/" + _yeniAd,
                        Resim = _resim
                    });
                }
                else
                {
                    _urunResimYonetimi.Ekle(new UrunResmi
                    {
                        Urun = urun,
                        ResimAdi = _yeniAd,
                        ResimYolu = "/KafeResimleri/" + _yeniAd,
                        Resim = _resim
                    });

                }

            }


            txtGuncellenecekAd.Text = txtGuncellenecekFiyat.Text = cmbGuncellenecekAd.Text =
            cmbGuncellenecekKategori.Text = txtGuncellenecekStok.Text = txtGuncellenecekPuanUcreti.Text = txtGuncellenecekPuan.Text = "";
            rdGuncelleEvet.Checked = rdGuncelleHayir.Checked = false;
            MessageBox.Show("Ürün güncellendi.");
            ComboDoldur();

        }



        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                Guncelle();
            }
            catch (BosVeriGirmeHatasi bv)
            {
                MessageBox.Show(bv.Message);
            }
            catch (VeriTekrariHatasi vt)
            {
                MessageBox.Show(vt.Message);
            }
        }

        private void UrunEkle()
        {

            if (String.IsNullOrEmpty(txtUrunAdi.Text) || cmbKategoriler.SelectedItem == null ||
                String.IsNullOrEmpty(txtStok.Text) || String.IsNullOrEmpty(txtFiyat.Text) ||
                String.IsNullOrEmpty(txtPuan.Text) || String.IsNullOrEmpty(txtEklePuanUcreti.Text) ||
                rdEvet.Checked == false && rdHayir.Checked == false)
                throw new BosVeriGirmeHatasi("Lütfen ilgili alanların tümünü doldurunuz.");
            if (AyniUrunVarMi(txtUrunAdi.Text))
                throw new VeriTekrariHatasi("Böyle bir ürün kaydı zaten mevcut");


            _urunYonetimi.Ekle(new Urun
            {
                Fiyat = Convert.ToSingle(txtFiyat.Text),
                Kategori = KategoriGetir(cmbKategoriler.SelectedItem.ToString()),
                StokDuzeyi = Convert.ToInt32(txtStok.Text),
                UrunAdi = txtUrunAdi.Text,
                UrunPuani = Convert.ToInt32(txtPuan.Text),
                AktifMi = AktifMi(),
				AlisPuani = Convert.ToSingle(txtEklePuanUcreti.Text)
                
            });
            if (_eklenecekMi)
            {
                _urunResimYonetimi.Ekle(new UrunResmi
                {
                    Urun = UrunGetir(txtUrunAdi.Text),
                    ResimAdi = _yeniAd,
                    ResimYolu = "/KafeResimleri/" + _yeniAd,
                    Resim = _resim
                });
            }


            txtFiyat.Text = txtPuan.Text = txtStok.Text = txtUrunAdi.Text = cmbKategoriler.Text = "";
            rdEvet.Checked = rdHayir.Checked = false;
            MessageBox.Show("Ürün kaydı yapıldı.");

            ComboDoldur();
        }

        private bool AyniUrunVarMi(string ad)
        {
            foreach (var item in _urunler)
            {
                if (item.UrunAdi.Equals(ad))
                {
                    return true;
                }
            }
            return false;
        }


        private void btnEkle_Click_1(object sender, EventArgs e)
        {
        
            try
            {
                UrunEkle();
            }
            catch (BosVeriGirmeHatasi bv)
            {
                MessageBox.Show(bv.Message);

            }
            catch (VeriTekrariHatasi vt)
            {
                MessageBox.Show(vt.Message);
            }

        }

        private void UrunSill()
        {
            if (cmbUrunAdi.SelectedItem == null)
                throw new BosVeriGirmeHatasi("Lütfen silinecek ürünü seçiniz.");
            foreach (var urun in _urunler)
            {
                if (urun.UrunAdi.Equals(cmbUrunAdi.SelectedItem.ToString()))
                {
                    _urunYonetimi.Sil(urun);
                    break;
                }

            }
            cmbUrunAdi.SelectedItem = null;
            MessageBox.Show("Ürün silindi.");
            ComboDoldur();
        }

        private void btnSil_Click_1(object sender, EventArgs e)
        {

            try
            {
                UrunSill();
            }
            catch (BosVeriGirmeHatasi bv)
            {
                MessageBox.Show(bv.Message);
            }
        }


        private void cmbGuncellenecekAd_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var item in _urunler)
            {
                if (item.UrunAdi.Equals(cmbGuncellenecekAd.SelectedItem.ToString()))
                {
                    txtGuncellenecekAd.Text = item.UrunAdi;
                    txtGuncellenecekFiyat.Text = item.Fiyat.ToString();
                    cmbGuncellenecekKategori.SelectedItem = item.Kategori.KategoriAdi;
                    txtGuncellenecekPuan.Text = item.UrunPuani.ToString();
                    txtGuncellenecekStok.Text = item.StokDuzeyi.ToString();
                    txtGuncellenecekPuanUcreti.Text = item.AlisPuani.ToString();
                    if (item.AktifMi)
                    {
                        rdGuncelleEvet.Checked = true;
                    }
                    else
                    {
                        rdGuncelleHayir.Checked = true;
                    }
                    break;
                }
            }

            gncKtg = gncFyt = gncStok = gncPuan = rdgncEvet = rdgncHayır = gncAlis =  false;

        }

        void IndexArttir(object sender, EventArgs e)
        {
            if (index < 2)
            {
                index++;
                PanelGoster();
            }
        }

        void IndexAzalt(object sender, EventArgs e)
        {
            if (index > 0)
            {
                index--;
                PanelGoster();
            }
        }

        void Iptal(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void cmbGuncellenecekKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            gncKtg = true;
        }

        private void txtGuncellenecekFiyat_TextChanged(object sender, EventArgs e)
        {
            gncFyt = true;
        }

        private void txtGuncellenecekStok_TextChanged(object sender, EventArgs e)
        {
            gncStok = true;
        }

        private void txtGuncellenecekPuan_TextChanged(object sender, EventArgs e)
        {
            gncPuan = true;
        }

        private void rdGuncelleEvet_CheckedChanged(object sender, EventArgs e)
        {
            rdgncEvet = true;
        }

        private void rdGuncelleHayir_CheckedChanged(object sender, EventArgs e)
        {
            rdgncHayır = true;
        }

        private void txtUrunAdi_Validating(object sender, CancelEventArgs e)
        {
            if (txtUrunAdi.Text == "")
                errorProvider1.SetError(txtUrunAdi, "Ürün adını giriniz.");
            else
                errorProvider1.Clear();
        }

        private void cmbKategoriler_Validating(object sender, CancelEventArgs e)
        {
            if (cmbKategoriler.SelectedItem == null)
                errorProvider1.SetError(cmbKategoriler, "Kategori seçiniz..");
            else
                errorProvider1.Clear();
        }

        private void txtFiyat_Validating(object sender, CancelEventArgs e)
        {
            if (txtFiyat.Text == "")
                errorProvider1.SetError(txtFiyat, "Ürün fiyatını giriniz.");
            else
                errorProvider1.Clear();
        }

        private void txtStok_Validating(object sender, CancelEventArgs e)
        {
            if (txtStok.Text == "")
                errorProvider1.SetError(txtStok, "Stok miktarını belirtiniz.");
            else
                errorProvider1.Clear();
        }

        private void txtPuan_Validating(object sender, CancelEventArgs e)
        {
            if (txtPuan.Text == "")
                errorProvider1.SetError(txtPuan, "Ürün puanını giriniz.");
            else
                errorProvider1.Clear();
        }

        private void cmbGuncellenecekAd_Validating(object sender, CancelEventArgs e)
        {
            if (cmbGuncellenecekAd.SelectedItem == null)
                errorProvider1.SetError(cmbGuncellenecekAd, "Güncellenecek ürünü seçiniz..");
            else
                errorProvider1.Clear();
        }

        private void txtGuncellenecekAd_Validating(object sender, CancelEventArgs e)
        {
            if (txtGuncellenecekAd.Text == "")
                errorProvider1.SetError(txtGuncellenecekAd, "Ürün adını giriniz.");
            else
                errorProvider1.Clear();
        }

        private void cmbGuncellenecekKategori_Validating(object sender, CancelEventArgs e)
        {
            if (cmbGuncellenecekKategori.SelectedItem == null)
                errorProvider1.SetError(cmbGuncellenecekKategori, "Güncellenecek kategoriyi seçiniz..");
            else
                errorProvider1.Clear();
        }

        private void txtGuncellenecekFiyat_Validating(object sender, CancelEventArgs e)
        {
            if (txtGuncellenecekFiyat.Text == "")
                errorProvider1.SetError(txtGuncellenecekFiyat, "Ürün fiyatını giriniz.");
            else
                errorProvider1.Clear();
        }

        private void txtGuncellenecekStok_Validating(object sender, CancelEventArgs e)
        {
            if (txtGuncellenecekStok.Text == "")
                errorProvider1.SetError(txtGuncellenecekStok, "Ürün stok miktarını giriniz.");
            else
                errorProvider1.Clear();
        }

        private void txtGuncellenecekPuan_Validating(object sender, CancelEventArgs e)
        {
            if (txtGuncellenecekPuan.Text == "")
                errorProvider1.SetError(txtGuncellenecekPuan, "Ürün puanını giriniz.");
            else
                errorProvider1.Clear();
        }

		private void txtGuncellenecekPuanUcreti_Validating(object sender, CancelEventArgs e) {
			if (txtGuncellenecekPuanUcreti.Text == "")
				errorProvider1.SetError(txtGuncellenecekPuanUcreti, "Ürün puan ücretini giriniz.");
			else
				errorProvider1.Clear();
		}

        private void txtGuncellenecekPuanUcreti_TextChanged(object sender, EventArgs e)
        {
            gncAlis = true;
        }

        private void txtEklePuanUcreti_Validated(object sender, EventArgs e) {
			if (txtEklePuanUcreti.Text == "")
				errorProvider1.SetError(txtEklePuanUcreti, "Ürün puan ücretini giriniz.");
			else
				errorProvider1.Clear();
		}

		private void btnResimEkle_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog()
            { Filter = "JPEG|*.jpg", ValidateNames = true, Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _resimYolu = ofd.FileName;

                    _yeniAd = Guid.NewGuid() + ".jpg";
                    _resim = BinaryYap(Image.FromFile(_resimYolu));
                    lblOnayMesaji.Text = "Başarılı";
                }
            }

            _eklenecekMi = true;
        }

        private void ileriBtn1_Click(object sender, EventArgs e)
        {

        }

        private void btnResimGuncelle_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog()
            { Filter = "JPEG|*.jpg", ValidateNames = true, Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _resimYolu = ofd.FileName;

                    if (ResimGetir(cmbGuncellenecekAd.SelectedItem.ToString()) == null)
                    {
                        _guncellenecekMi = false;
                         resimliMi = true;
                        _yeniAd = Guid.NewGuid() + ".jpg";
                        _resim = BinaryYap(Image.FromFile(_resimYolu));
                        lblGuncelOnay.Text = "Başarılı";
                    }
                    else
                    {
                        _guncellenecekMi = true;
                         resimliMi = true;
                        _yeniAd = ResimGetir(cmbGuncellenecekAd.SelectedItem.ToString()).ResimAdi;
                        _resim = BinaryYap(Image.FromFile(_resimYolu));
                        lblGuncelOnay.Text = "Başarılı";
                    }
                }
            }
        }

        private byte[] BinaryYap(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }

        }

		private void panel3_Paint(object sender, PaintEventArgs e) {

		}

		
	}
}
