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
    public partial class UstKategoriAyarlari : Form
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

		UstKategoriYonetimi ustKategoriYonetimi = new UstKategoriYonetimi(new SQLUstKategoriDal());

        private List<UstKategori> _ustKategoriler;

		List<Panel> paneller = new List<Panel>();
		int index = 0;
        private bool rdGncEvet, rdGncHayır;

        public UstKategoriAyarlari()
        {
            InitializeComponent();
            

			//yuvarlak köşeler
			this.FormBorderStyle = FormBorderStyle.None;
			Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
		}
        private void ustKategoriEkle()
        {
            if (String.IsNullOrEmpty(txtUstKategoriAdi.Text) || rdEvet.Checked == false & rdHayir.Checked == false)
                throw new BosVeriGirmeHatasi("Lütfen tüm alanları doldurunuz.");
            if (UstKategoriGetir(txtUstKategoriAdi.Text) != null)
                throw new VeriTekrariHatasi("Bu kayıt zaten mevcut.");
            ustKategoriYonetimi.Ekle(new UstKategori
            {
                UstKategoriAdi = txtUstKategoriAdi.Text,
                AktifMi = AktifMi(),

            });
            MessageBox.Show("Üst kategori eklendi.");
            txtUstKategoriAdi.Text = "";
            rdEvet.Checked = rdHayir.Checked = false;
            ComboDoldur();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                ustKategoriEkle();
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

        private bool AktifMi()
        {
            if (rdEvet.Checked || rdGuncelleEvet.Checked)
            {
                return true;
            }

            return false;
        }
        private void ustKategoriGuncelle()
        {
            if (cmbGuncellenecekAd.SelectedItem == null || String.IsNullOrEmpty(txtGuncellenecekAd.Text))
                throw new BosVeriGirmeHatasi("Lütfen tüm alanları doldurunuz.");
            if (cmbGuncellenecekAd.SelectedItem != null & rdGncEvet == false && rdGncHayır == false)
                if (UstKategoriGetir(txtGuncellenecekAd.Text) != null)
                    throw new VeriTekrariHatasi("Bu kayıt zaten mevcut.");


            ustKategoriYonetimi.Guncelle(new UstKategori
            {
                UstKategoriId = UstKategoriGetir(cmbGuncellenecekAd.SelectedItem.ToString()).UstKategoriId,
                UstKategoriAdi = txtGuncellenecekAd.Text,
                AktifMi = AktifMi()
            });

            MessageBox.Show("Üst kategori güncellendi.");
            cmbGuncellenecekAd.Text = "";
            txtGuncellenecekAd.Text = "";
            rdGuncelleEvet.Checked = rdGuncelleHayir.Checked = false;
            ComboDoldur();
        }




        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                ustKategoriGuncelle();

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

        private void UstKategoriAyarlari_Load(object sender, EventArgs e)
        {
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

		void PanelGoster() {
			for (int i = 0; i < paneller.Count; i++) {
				if (i == index) {
					paneller[i].Show();
					paneller[i].BringToFront();
				}
				else {
					paneller[i].SendToBack();
					paneller[i].Hide();
				}
			}
		}


		private void ComboDoldur()
        {
            _ustKategoriler = ustKategoriYonetimi.HepsiniGetir();

            cmbSilinecekKategoriAdi.Items.Clear();

            cmbSilinecekKategoriAdi.SelectionStart = 0;

            cmbGuncellenecekAd.Items.Clear();
            cmbGuncellenecekAd.SelectionStart = 0;

            
           
            foreach (var item in _ustKategoriler)
            {
                cmbSilinecekKategoriAdi.Items.Add(item.UstKategoriAdi);
                cmbGuncellenecekAd.Items.Add(item.UstKategoriAdi);
            }
            
        }


        private void ustKategoriSil()
        {
            if (cmbSilinecekKategoriAdi.SelectedItem == null)
                throw new BosVeriGirmeHatasi("Silmek istediğiniz üst kategoriyi seçiniz.");
            ustKategoriYonetimi.Sil(new UstKategori
            {
                UstKategoriId = UstKategoriGetir(cmbSilinecekKategoriAdi.SelectedItem.ToString()).UstKategoriId
            });
            MessageBox.Show("Üst kategori silindi.");
            cmbSilinecekKategoriAdi.Text = "";
            ComboDoldur();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {

            try
            {
                ustKategoriSil();
            }
            catch (BosVeriGirmeHatasi bv)
            {

                MessageBox.Show(bv.Message);
            }

        }

        private void cmbGuncellenecekAd_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtGuncellenecekAd.Text = UstKategoriGetir(cmbGuncellenecekAd.SelectedItem.ToString()).UstKategoriAdi;
            if (UstKategoriGetir(cmbGuncellenecekAd.SelectedItem.ToString()).AktifMi)
            {
                rdGuncelleEvet.Checked = true;
            }
            else
            {
                rdGuncelleHayir.Checked = true;
            }
            rdGncEvet = rdGncHayır = false;


        }


		void IndexArttir(object sender, EventArgs e) {
			if (index < 2) {
				index++;
				PanelGoster();
			}
		}

		void IndexAzalt(object sender, EventArgs e) {
			if (index > 0) {
				index--;
				PanelGoster();
			}
		}

		void Iptal(object sender, EventArgs e) {
			this.Hide();
		}

        private void txtUstKategoriAdi_TextChanged(object sender, EventArgs e)
        {
            if (txtUstKategoriAdi.Text == "")
                errorProvider1.SetError(txtUstKategoriAdi, "Üst kategorinin adını giriniz.");
            else
                errorProvider1.Clear();
        }

        private void cmbGuncellenecekAd_Validating(object sender, CancelEventArgs e)
        {
            if (cmbGuncellenecekAd.SelectedItem == null)
                errorProvider1.SetError(cmbGuncellenecekAd, "Güncellenecek üst kategoriyi seçiniz.");
            else
                errorProvider1.Clear();
        }

        private void txtGuncellenecekAd_TextChanged(object sender, EventArgs e)
        {
            if (txtGuncellenecekAd.Text == "")
                errorProvider1.SetError(txtGuncellenecekAd, "Üst kategorinin adını giriniz.");
            else
                errorProvider1.Clear();
        }

        private void rdGuncelleEvet_CheckedChanged(object sender, EventArgs e)
        {
            rdGncEvet = true;
        }

        private void rdGuncelleHayir_CheckedChanged(object sender, EventArgs e)
        {
            rdGncHayır = true;
        }

        private void panel3_Paint(object sender, PaintEventArgs e) {

		}

	}
}
