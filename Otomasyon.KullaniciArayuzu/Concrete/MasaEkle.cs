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

namespace Otomasyon.KullaniciArayuzu
{
    public partial class MasaEkle : Form
    {
		protected override CreateParams CreateParams {
			get {
				const int CS_DROPSHADOW = 0x20000;
				CreateParams cp = base.CreateParams;
				cp.ClassStyle |= CS_DROPSHADOW;
				return cp;
			}
		}

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

        private List<Masa> _masalar;

		private FlowLayoutPanel _panel;

        public MasaEkle()
        {
            InitializeComponent();

		}

		public MasaEkle(FlowLayoutPanel panel, List<Masa> masalar)
        {
            _panel = panel;
            _masalar = masalar;
            InitializeComponent();

			
		}

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                VeriEkle();
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

		private void MasaEkle_Load(object sender, EventArgs e) {
			//yuvarlak köşeler
			this.FormBorderStyle = FormBorderStyle.None;
			Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
		}

		private void button2_Click(object sender, EventArgs e) {
			this.Hide();
		}

        private bool AyniMasaVarMi(string ad)
        {
            foreach (var item in _masalar)
            {
                if (item.MasaId.Equals(ad))
                {
                    return true;
                }
            }
            return false;
        }

        private void VeriEkle()
        {
            if (String.IsNullOrEmpty(txtMasaNo.Text))
                throw new BosVeriGirmeHatasi("Eklemek istediğiniz masanın numarasını giriniz.");
            if (AyniMasaVarMi(txtMasaNo.Text))
            {
                throw new VeriTekrariHatasi("Bu kayıt zaten mevcut.");
            }
            MasaYonetimi masaYonetimi = new MasaYonetimi(new SQLMasaDal());
            masaYonetimi.Ekle(new Masa { MasaId = txtMasaNo.Text, MusaitlikDurumu = true });

            Form1 form = new Form1();
            _panel.Controls.Clear();

            form.Reset(_panel);


            this.Hide();
        }

        private void txtMasaNo_TextChanged(object sender, EventArgs e)
        {
            if (txtMasaNo.Text == "")
                errorProvider1.SetError(txtMasaNo, "Bu alanı boş bırakmamalısınız.");
            else
                errorProvider1.SetError(txtMasaNo, "");
        }
    }
}
