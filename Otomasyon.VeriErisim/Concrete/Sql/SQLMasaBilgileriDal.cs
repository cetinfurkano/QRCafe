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
    public class SQLMasaBilgileriDal : VeriTabani<MasaBilgisi>
    {
        public override void Ekle(MasaBilgisi veri)
        {
            string commandText =
                "Exec spMasaBilgileriEkle @MasaId, @MusteriId,@AcilmaTarihi, @AcilmaZamani";

            _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            _sqlCommand = new SqlCommand(commandText, _sqlConnection);

            _sqlCommand.Parameters.AddWithValue("@MasaId", veri.Masa.MasaId);
            _sqlCommand.Parameters.AddWithValue("@MusteriId", veri.Musteri.MusteriId);
            _sqlCommand.Parameters.AddWithValue("@AcilmaTarihi", veri.AcilmaTarihi);
            _sqlCommand.Parameters.AddWithValue("@AcilmaZamani", veri.AcilmaZamani);
          

            _sqlCommand.ExecuteNonQuery();

            _sqlConnection.Close();
        }

        public override void Guncelle(MasaBilgisi veri)
        {
            string commandText =
                "Exec spMasaBilgileriGuncelle @BilgiId,@MasaId,@MusteriId, @AcilmaTarihi, @AcilmaZamani";

            _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            _sqlCommand = new SqlCommand(commandText, _sqlConnection);

            _sqlCommand.Parameters.AddWithValue("@MasaId", veri.Masa.MasaId);
            _sqlCommand.Parameters.AddWithValue("@MusteriId", veri.Musteri.MusteriId);
            _sqlCommand.Parameters.AddWithValue("@AcilmaTarihi", veri.AcilmaTarihi);
            _sqlCommand.Parameters.AddWithValue("@AcilmaZamani", veri.AcilmaZamani);
            _sqlCommand.Parameters.AddWithValue("@BilgiId", veri.BilgiId);

            _sqlCommand.ExecuteNonQuery();

            _sqlConnection.Close();
        }

        public override List<MasaBilgisi> HepsiniGetir()
        {
            string commandText = "Exec spMasaBilgileriHepsiniGetir";

            List<MasaBilgisi> masaBilgileri = new List<MasaBilgisi>();

            _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            _sqlCommand = new SqlCommand(commandText, _sqlConnection);

            SqlDataReader reader = _sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                masaBilgileri.Add(new MasaBilgisi
                {
                    BilgiId = Convert.ToInt32(reader["BilgiId"]),
                    Musteri = MusteriGetir(Convert.ToInt32(reader["BilgiId"])),
                    Masa = MasaGetir(Convert.ToInt32(reader["BilgiId"])),
                    AcilmaTarihi = reader["AcilmaTarihi"].ToString(),
                    AcilmaZamani = reader["AcilmaZamani"].ToString()
                });
            }

            reader.Close();
            _sqlConnection.Close();

            return masaBilgileri;
        }

        public override void Sil(MasaBilgisi veri)
        {
            string commandText =
                "Exec spMasaBilgileriSil @id";

            _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            _sqlCommand = new SqlCommand(commandText, _sqlConnection);

            _sqlCommand.Parameters.AddWithValue("@id", veri.BilgiId);

            _sqlCommand.ExecuteNonQuery();

            _sqlConnection.Close();
        }

        public Musteri MusteriGetir(int id)
        {
            string commandText =
                "Exec spMasaBilgileriMusterisi @id";

            _sqlConnection = new SqlConnection(yol);

            Musteri musteri = new Musteri();


            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            _sqlCommand = new SqlCommand(commandText, _sqlConnection);

            _sqlCommand.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = _sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                musteri.MusteriId = Convert.ToInt32(reader["MusteriId"]);
                musteri.Ad = reader["Ad"].ToString();
                musteri.Soyad = reader["Soyad"].ToString();
                musteri.KullaniciAdi = reader["KullaniciAdi"].ToString();
                musteri.Parola = reader["Parola"].ToString();
                musteri.KazanilanPuan = Convert.ToSingle(reader["KazanilanPuan"]);
                musteri.Eposta = reader["Eposta"].ToString();
            }

            reader.Close();
            _sqlConnection.Close();

            return musteri;
        }


        public Masa MasaGetir(int id)
        {
            string commandText =
                "Exec spMasaBilgileriMasasi @BilgiId";

            _sqlConnection = new SqlConnection(yol);

            Masa masa = new Masa();


            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            _sqlCommand = new SqlCommand(commandText, _sqlConnection);

            _sqlCommand.Parameters.AddWithValue("@BilgiId", id);

            SqlDataReader reader = _sqlCommand.ExecuteReader();

            while (reader.Read())
            {
               masa.MasaId = reader["MasaId"].ToString();
               masa.MusaitlikDurumu = Convert.ToBoolean(reader["MusaitlikDurumu"]);
            }

            reader.Close();
            _sqlConnection.Close();

            return masa;
        }
    }
}
