using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Otomasyon.VeriErisim.Abstracts;
using Otomasyon.Veriler.Concrete;

namespace Otomasyon.VeriErisim.Concrete.Sql
{
   public class SQLGecmisDetayDal:VeriTabani<GecmisDetay>
    {
       
        public override void Ekle(GecmisDetay veri)
        {
            string commandText =
                "Exec spGecmisSiparisDetayiEkle @GecmisSiparisId, @UrunId,@GecmisFiyat";

            _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            _sqlCommand = new SqlCommand(commandText, _sqlConnection);

            _sqlCommand.Parameters.AddWithValue("@GecmisSiparisId", veri.GecmisSiparis.GecmisSiparisId);
            _sqlCommand.Parameters.AddWithValue("@UrunId", veri.GecmisUrun.UrunId);
            _sqlCommand.Parameters.AddWithValue("@GecmisFiyat", veri.GecmisFiyat);

            _sqlCommand.ExecuteNonQuery();

            _sqlConnection.Close();
        }
        
        public override List<GecmisDetay> HepsiniGetir()
        {
            string commandText = "Exec spGecmisSiparisDetayiGetir";

            List<GecmisDetay> gecmisDetaylar = new List<GecmisDetay>();

            _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            _sqlCommand = new SqlCommand(commandText, _sqlConnection);

            SqlDataReader reader = _sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                gecmisDetaylar.Add(new GecmisDetay
                {
                    GecmisSiparis = GecmisSiparisGetir(Convert.ToInt32(reader["GecmisDetayId"])),
                    GecmisUrun = GecmisUrunGetir(Convert.ToInt32(reader["GecmisDetayId"])),
                    GecmisDetayId = Convert.ToInt32(reader["GecmisDetayId"]),
                    GecmisFiyat = Convert.ToSingle(reader["GecmisFiyat"])
                });
            }

            reader.Close();
            _sqlConnection.Close();

            return gecmisDetaylar;
        }


        public GecmisSiparis GecmisSiparisGetir(int id)
        {
            string commandText =
                "Exec spGecmisSiparisDetaySiparisi @id";

            _sqlConnection = new SqlConnection(yol);

            SQLGecmisSiparisDal gsDal = new SQLGecmisSiparisDal();
            GecmisSiparis gs = new GecmisSiparis();


            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            _sqlCommand = new SqlCommand(commandText, _sqlConnection);

            _sqlCommand.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = _sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                gs.GecmisSiparisId = Convert.ToInt32(reader["GecmisSiparisId"]);
                gs.Musteri = gsDal.MusteriGetir(Convert.ToInt32(reader["GecmisSiparisId"]));
                gs.VerilmeTarihi = reader["VerilmeTarihi"].ToString();
                gs.VerilmeZamani = reader["VerilmeZamani"].ToString();
                gs.TeslimTarihi = reader["TeslimTarihi"].ToString();
                gs.TeslimZamani = reader["TeslimZamani"].ToString();
           }

            reader.Close();
            _sqlConnection.Close();

            return gs;
        }

        public Urun GecmisUrunGetir(int id)
        {
            string commandText =
                "Exec spGecmisSiparisDetayUrunu @id";

            _sqlConnection = new SqlConnection(yol);

           SQLUrunDal urunDal = new SQLUrunDal();
           Urun urun = new Urun();


            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            _sqlCommand = new SqlCommand(commandText, _sqlConnection);

            _sqlCommand.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = _sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                urun.UrunId = Convert.ToInt32(reader["UrunId"]);
                urun.AktifMi = Convert.ToBoolean(reader["AktifMi"]);
                urun.Fiyat = Convert.ToSingle(reader["Fiyat"]);
                urun.Kategori = urunDal.KategoriGetir(Convert.ToInt32(reader["UrunId"]));
                urun.UrunAdi = reader["UrunAdi"].ToString();
                urun.StokDuzeyi = Convert.ToInt32(reader["StokDuzeyi"]);
                urun.UrunPuani = Convert.ToSingle(reader["UrunPuani"]);
                urun.AlisPuani = Convert.ToSingle(reader["AlisPuani"]);

            }

            reader.Close();
            _sqlConnection.Close();

            return urun;
        }
    }
}
