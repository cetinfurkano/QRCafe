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

namespace Otomasyon.KullaniciArayuzu.Concrete
{
    public partial class GunSonuBilgileri : Form
    {
        private GunSonuYonetimi gunSonuYonetimi = new GunSonuYonetimi(new SQLGunSonuDal());
        private UrunYonetimi urunYonetimi = new UrunYonetimi(new SQLUrunDal());
        
        private List<GunSonu> gunsonu;
     
        private List<Urun> urunler;
      


        private int toplamUrun = 0;

        private float toplamHasilat = 0;

        public GunSonuBilgileri()
        {
            InitializeComponent();
        }

        private void GunSonuBilgileri_Load(object sender, EventArgs e)
        {
            gunsonu = gunSonuYonetimi.HepsiniGetir();
            urunler = urunYonetimi.HepsiniGetir();

            

            dataGridView1.DataSource = gunsonu;

            foreach (var item in gunsonu)
            {
                toplamUrun += item.UrunAdet;
                
            }

            lblToplamUrun.Text = toplamUrun.ToString();
           
            lblToplamHasilat.Text = ToplamHasilat().ToString();

        }


        private float ToplamHasilat()
        {
            float hasilat = 0;
            foreach (var item in gunsonu)
            {
                hasilat += item.UrunAdet * item.Fiyat;
            }

            return hasilat;
        }

        private void lblToplamUrun_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bilancolar bilanco = new Bilancolar(urunler);
			bilanco.StartPosition = FormStartPosition.Manual;
			bilanco.Location = new Point(roundedButton1.Parent.Location.X + roundedButton1.Location.X + roundedButton1.Width - bilanco.Width, roundedButton1.Parent.Location.Y + roundedButton1.Location.Y - bilanco.Height);
            bilanco.ShowDialog();
        }

		private void btnGuncelle_Click(object sender, EventArgs e) {
			this.Close();
		}
	}
}
