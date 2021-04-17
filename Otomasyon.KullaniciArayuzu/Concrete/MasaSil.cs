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
    public partial class MasaSil : Form
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

        private bool secildiMi = false;

		MasaYonetimi masaYonetimi = new MasaYonetimi(new SQLMasaDal());
		private FlowLayoutPanel _panel;

        public MasaSil()
        {
            InitializeComponent();
        }

        public MasaSil(FlowLayoutPanel panel)
        {
            _panel = panel;
            InitializeComponent();

			
		}
        private void MasaSill()
        {
            if (secildiMi == false)
                throw new BosVeriGirmeHatasi("Silmek istediğiniz masayı seçiniz.");

            MasaYonetimi masaYonetimi = new MasaYonetimi(new SQLMasaDal());
            masaYonetimi.Sil(new Masa { MasaId = comboBox1.SelectedItem.ToString() });

            _panel.Controls.Clear();

            Form1 form1 = new Form1();
            form1.Reset(_panel);

            this.Hide();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                MasaSill();
            }
            catch (BosVeriGirmeHatasi bv)
            {

                MessageBox.Show(bv.Message);
            }
        }
        
		private void button1_Click(object sender, EventArgs e) {
			this.Hide();
		}

		private void MasaSil_Load(object sender, EventArgs e) {
			//yuvarlak köşeler
			this.FormBorderStyle = FormBorderStyle.None;
			Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

			var masalar = masaYonetimi.HepsiniGetir();

			for (int i = 0; i < masalar.Count; i++) {
				comboBox1.Items.Add(masalar[i].MasaId);
			}

           
        }

		private void txtMasaNo_TextChanged(object sender, EventArgs e) {

		}

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            secildiMi = true;
        }
    }
}
