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
    public class SQLSiparisDetayiDal : VeriTabani<SiparisDetayi>
    {
       
        public override void Ekle(SiparisDetayi veri)
        {
            string commandText =
                "Exec spSiparisDetayiEkle @SiparisId, @UrunId";

            _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            _sqlCommand = new SqlCommand(commandText, _sqlConnection);

            _sqlCommand.Parameters.AddWithValue("@SiparisId", veri.Siparis.SiparisId);
            _sqlCommand.Parameters.AddWithValue("@UrunId", veri.Urun.UrunId);
            


            _sqlCommand.ExecuteNonQuery();

            _sqlConnection.Close();
        }

        public override void Guncelle(SiparisDetayi veri)
        {
            string commandText =
                "Exec spSiparisDetayiGuncelle @SiparisId, @UrunId, @id";

            _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            _sqlCommand = new SqlCommand(commandText, _sqlConnection);


            _sqlCommand.Parameters.AddWithValue("@SiparisId", veri.Siparis.SiparisId);
            _sqlCommand.Parameters.AddWithValue("@UrunId", veri.Urun.UrunId);
            _sqlCommand.Parameters.AddWithValue("@id", veri.DetayId);

            _sqlCommand.ExecuteNonQuery();

            _sqlConnection.Close();
        }

        public override List<SiparisDetayi> HepsiniGetir()
        {
            string commandText = "Exec spSiparisDetayiHepsiniGetir";

            List<SiparisDetayi> siparisDetaylari = new List<SiparisDetayi>();

            _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            _sqlCommand = new SqlCommand(commandText, _sqlConnection);

            SqlDataReader reader = _sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                siparisDetaylari.Add(new SiparisDetayi
                {
                    DetayId = Convert.ToInt32(reader["DetayId"]),
                    Urun = UrunGetir(Convert.ToInt32(reader["DetayId"])),
                    Siparis = SiparisGetir(Convert.ToInt32(reader["DetayId"]))
                });
            }

            reader.Close();
            _sqlConnection.Close();

            return siparisDetaylari;
        }

        public override void Sil(SiparisDetayi veri)
        {
            string commandText =
                "Exec spSiparisDetayiSil @id";

            _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            _sqlCommand = new SqlCommand(commandText, _sqlConnection);

            _sqlCommand.Parameters.AddWithValue("@id", veri.Siparis.SiparisId);

            _sqlCommand.ExecuteNonQuery();

            _sqlConnection.Close();
        }


        public Urun UrunGetir(int id)
        {
            string commandText =
                "Exec spSiparisDetayiUrunu @id";

            _sqlConnection = new SqlConnection(yol);

            Urun urun = new Urun();

            SQLUrunDal urunDal = new SQLUrunDal();

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
                urun.UrunAdi = reader["UrunAdi"].ToString();
                urun.StokDuzeyi = Convert.ToInt32(reader["StokDuzeyi"]);
                urun.Fiyat = Convert.ToSingle(reader["Fiyat"]);
                urun.Kategori = urunDal.KategoriGetir(Convert.ToInt32(reader["UrunId"]));
                urun.UrunPuani = Convert.ToSingle(reader["UrunPuani"]);
                urun.AktifMi = Convert.ToBoolean(reader["AktifMi"]);
                urun.AlisPuani = Convert.ToSingle(reader["AlisPuani"]);

            }

            reader.Close();
            _sqlConnection.Close();

            return urun;


        }

        public Siparis SiparisGetir(int id)
        {
            string commandText =
                "Exec spSiparisDetayiSiparisi @id";

            _sqlConnection = new SqlConnection(yol);

            Siparis siparis = new Siparis();

            SQLSiparisDal siparisDal = new SQLSiparisDal();

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            _sqlCommand = new SqlCommand(commandText, _sqlConnection);

            _sqlCommand.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = _sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                siparis.Musteri = siparisDal.MusteriGetir(Convert.ToInt32(reader["SiparisId"]));
                siparis.SiparisId = Convert.ToInt32(reader["SiparisId"]);
                siparis.VerilmeZamani = reader["VerilmeZamani"].ToString();
               
            }

            reader.Close();
            _sqlConnection.Close();

            return siparis;
        }
    }
}
