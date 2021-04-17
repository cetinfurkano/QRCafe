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
using Otomasyon.KullaniciArayuzu.Exceptions;

namespace Otomasyon.KullaniciArayuzu.Concrete
{
    public partial class KategoriAyarlari : Form
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

        KategoriYonetimi kategoriYonetimi = new KategoriYonetimi(new SQLKategoriDal());

        private List<Kategori> _kategoriler;

        private List<UstKategori> _ustKategoriler;

        List<Panel> paneller = new List<Panel>();
        int index = 0;

        private bool ustKtg, rdGncEvet, rdGncHayır;


        public KategoriAyarlari()
        {
            InitializeComponent();
        }

        public KategoriAyarlari(List<UstKategori> ustKategoriler)
        {
            _ustKategoriler = ustKategoriler;

            InitializeComponent();

            

            //yuvarlak köşeler
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void KategoriAyarlari_Load(object sender, EventArgs e)
        {

            _kategoriler = kategoriYonetimi.HepsiniGetir();

            ComboDoldur();

            paneller.Add(panel1);
            paneller.Add(panel2);
            paneller.Add(panel3);

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

        private void kategoriSill()
        {
            if (cmbKategoriAdi.SelectedItem == null)
                throw new BosVeriGirmeHatasi("Silmek istediğiniz kategoriyi seçiniz.");

            kategoriYonetimi.Sil(KategoriGetir(cmbKategoriAdi.SelectedItem.ToString()));

            cmbKategoriAdi.SelectedItem = null;
            MessageBox.Show("Kategori silindi.");

            ComboDoldur();
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
        
        private void btnSil_Click(object sender, EventArgs e)
        {

            try
            {
                kategoriSill();
            }
            catch (BosVeriGirmeHatasi bv)
            {

                MessageBox.Show(bv.Message);
            }

        }

        private UstKategori UstKategoriGetir(string ad)
        {
            foreach (var item in _ustKategoriler)
            {
                if (item.UstKategoriAdi.Equals(ad))
                {
                    return item;
                }
            }

            return null;
        }

        private void ComboDoldur()
        {
            cmbKategoriAdi.Items.Clear();
            cmbGuncellenecekAd.Items.Clear();
            cmbUstKategori.Items.Clear();
            cmbUstKategoriGuncelle.Items.Clear();

            cmbKategoriAdi.SelectionStart = 0;
            cmbGuncellenecekAd.SelectionStart = 0;
            cmbUstKategori.SelectionStart = 0;
            cmbUstKategoriGuncelle.SelectionStart = 0;

            _kategoriler = kategoriYonetimi.HepsiniGetir();


            foreach (var item in _kategoriler)
            {
                cmbKategoriAdi.Items.Add(item.KategoriAdi);
                cmbGuncellenecekAd.Items.Add(item.KategoriAdi);

            }

            foreach (var item in _ustKategoriler)
            {
                cmbUstKategori.Items.Add(item.UstKategoriAdi);
                cmbUstKategoriGuncelle.Items.Add(item.UstKategoriAdi);
            }
        }

        private void KtgEkle()
        {

            if (String.IsNullOrEmpty(txtKategoriAdi.Text) || cmbUstKategori.SelectedItem == null ||
                rdEvet.Checked == false & rdHayir.Checked == false)
                throw new BosVeriGirmeHatasi("Lütfen tüm alanları doldurunuz.");

            if (KategoriGetir(txtKategoriAdi.Text) != null)
                throw new VeriTekrariHatasi("Böyle bir kayıt zaten mevcut.");

            kategoriYonetimi.Ekle(new Kategori
            {
                KategoriAdi = txtKategoriAdi.Text,
                AktifMi = AktifMi(),
                UstKategori = UstKategoriGetir(cmbUstKategori.SelectedItem.ToString())
            });

            txtKategoriAdi.Text = null;
            cmbUstKategori.SelectedItem = null;
            rdEvet.Checked = rdHayir.Checked = false;
            MessageBox.Show("Kategori eklendi.");
            ComboDoldur();
        }

        private void btnEkle_Click_1(object sender, EventArgs e)
        {
            try
            {
                KtgEkle();
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

        private void KtgGuncelle()
        {
            if (cmbGuncellenecekAd.SelectedItem == null || String.IsNullOrEmpty(txtGuncellenecekAd.Text) || cmbUstKategoriGuncelle.SelectedItem == null ||
                rdGuncelleEvet.Checked == false & rdGuncelleHayir.Checked == false)
                throw new BosVeriGirmeHatasi("Lütfen tüm alanları doldurunuz.");
            if (ustKtg == false && (rdGncEvet == false || rdGncHayır == false))
                if (KategoriGetir(txtGuncellenecekAd.Text) != null)
                {
                    throw new VeriTekrariHatasi("Böyle bir kayıt zaten mevcut.");
                    //ustKtg = rdGncEvet = rdGncHayır = false;
                }


            kategoriYonetimi.Guncelle(new Kategori
            {
                KategoriId = KategoriGetir(cmbGuncellenecekAd.SelectedItem.ToString()).KategoriId,
                KategoriAdi = txtGuncellenecekAd.Text,
                UstKategori = UstKategoriGetir(cmbUstKategoriGuncelle.SelectedItem.ToString()),
                AktifMi = AktifMi()

            });


            cmbGuncellenecekAd.Text = "";
            txtGuncellenecekAd.Text = "";
            cmbUstKategoriGuncelle.Text = "";
            rdGuncelleEvet.Checked = rdGuncelleHayir.Checked = false;
            MessageBox.Show("Kategori güncellendi.");

            ComboDoldur();
            // cmbGuncellenecekAd.Text = null;
            //txtGuncellenecekAd.Text = null;
            //cmbUstKategoriGuncelle = null;


        }


        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                KtgGuncelle();

            }
            catch (BosVeriGirmeHatasi bv)
            {
                MessageBox.Show(bv.Message);

            }
            catch (VeriTekrariHatasi bv)
            {
                MessageBox.Show(bv.Message);
            }
        }

        private void cmbGuncellenecekAd_SelectedIndexChanged(object sender, EventArgs e)
        {
            var guncellenecekKategori = KategoriGetir(cmbGuncellenecekAd.SelectedItem.ToString());

            txtGuncellenecekAd.Text = cmbGuncellenecekAd.Text;
            cmbUstKategoriGuncelle.SelectedItem =
                guncellenecekKategori.UstKategori.UstKategoriAdi;

            if (guncellenecekKategori.AktifMi)
            {
                rdGuncelleEvet.Checked = true;
            }
            else
            {
                rdGuncelleHayir.Checked = true;
            }


            ustKtg = rdGncHayır = rdGncEvet = false;
        }

        private bool AktifMi()
        {
            if (rdEvet.Checked || rdGuncelleEvet.Checked)
            {
                return true;
            }

            return false;
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

        private void rdGuncelleEvet_CheckedChanged(object sender, EventArgs e)
        {
            rdGncEvet = true;
        }

        private void rdGuncelleHayir_CheckedChanged(object sender, EventArgs e)
        {
            rdGncHayır = true;
        }

        private void cmbUstKategoriGuncelle_SelectedIndexChanged(object sender, EventArgs e)
        {
            ustKtg = true;
        }

        private void txtKategoriAdi_Validated(object sender, EventArgs e)
        {
            if (txtKategoriAdi.Text == "")
                errorProvider1.SetError(txtKategoriAdi, "Kategori adını giriniz.");
            else
                errorProvider1.Clear();
        }

        private void cmbUstKategori_Validated(object sender, EventArgs e)
        {
            if (cmbUstKategori.SelectedText == "")
                errorProvider1.SetError(cmbUstKategori, "Üst kategori seçiniz.");
            else
                errorProvider1.Clear();
        }

        private void cmbGuncellenecekAd_Validated(object sender, EventArgs e)
        {
            if (cmbGuncellenecekAd.SelectedItem == null)
                errorProvider1.SetError(cmbGuncellenecekAd, "Güncellenecek kategoriyi seçiniz.");
            else
                errorProvider1.Clear();
        }

        private void cmbUstKategoriGuncelle_Validated(object sender, EventArgs e)
        {
            if (cmbUstKategoriGuncelle.SelectedItem == null)
                errorProvider1.SetError(cmbUstKategoriGuncelle, "Güncellenecek üst kategoriyi seçiniz.");
            else
                errorProvider1.Clear();
        }

        private void txtGuncellenecekAd_Validated(object sender, EventArgs e)
        {
            if (txtGuncellenecekAd.Text == "")
                errorProvider1.SetError(txtGuncellenecekAd, "Kategori adını giriniz.");
            else
                errorProvider1.Clear();
        }

        void Iptal(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
