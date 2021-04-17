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
    public class SQLMusteriDal : VeriTabani<Musteri>
    {
        
        public override void Ekle(Musteri veri)
        {
            string commandText =
                "Exec spMusteriEkle @Ad,@Soyad,@KullaniciAdi,@Parola,@KazanilanPuan,@Eposta";

            _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            _sqlCommand = new SqlCommand(commandText, _sqlConnection);

            _sqlCommand.Parameters.AddWithValue("@Ad", veri.Ad);
            _sqlCommand.Parameters.AddWithValue("@Soyad", veri.Soyad);
            _sqlCommand.Parameters.AddWithValue("@KullaniciAdi", veri.KullaniciAdi);
            _sqlCommand.Parameters.AddWithValue("@Parola", veri.Parola);
            _sqlCommand.Parameters.AddWithValue("@KazanilanPuan", veri.KazanilanPuan);
            _sqlCommand.Parameters.AddWithValue("@Eposta", veri.Eposta);


            _sqlCommand.ExecuteNonQuery();

            _sqlConnection.Close();

        }

        public override void Guncelle(Musteri veri)
        {
            string commandText =
                "Exec spMusteriGuncelle @id, @Ad, @Soyad, @KullaniciAdi, @Parola,@KazanilanPuan, @Eposta";


            _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            _sqlCommand = new SqlCommand(commandText, _sqlConnection);

            _sqlCommand.Parameters.AddWithValue("@Ad", veri.Ad);
            _sqlCommand.Parameters.AddWithValue("@Soyad", veri.Soyad);
            _sqlCommand.Parameters.AddWithValue("@KullaniciAdi", veri.KullaniciAdi);
            _sqlCommand.Parameters.AddWithValue("@Parola", veri.Parola);
            _sqlCommand.Parameters.AddWithValue("@KazanilanPuan", veri.KazanilanPuan);
            _sqlCommand.Parameters.AddWithValue("@Eposta", veri.Eposta);
            _sqlCommand.Parameters.AddWithValue("@id", veri.MusteriId);

            _sqlCommand.ExecuteNonQuery();

            _sqlConnection.Close();
        }

        public override List<Musteri> HepsiniGetir()
        {
            string commandText = "Exec spMusteriHepsiniGetir";

            List<Musteri> musteriler = new List<Musteri>();

            _sqlConnection = new SqlConnection(yol);



            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            _sqlCommand = new SqlCommand(commandText, _sqlConnection);

            SqlDataReader reader = _sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                musteriler.Add(new Musteri
                {
                    MusteriId = Convert.ToInt32(reader["MusteriId"]),
                    Ad = reader["Ad"].ToString(),
                    Soyad = reader["Soyad"].ToString(),
                    KullaniciAdi = reader["KullaniciAdi"].ToString(),
                    KazanilanPuan = Convert.ToSingle(reader["KazanilanPuan"]),
                    Parola = reader["Parola"].ToString(),
                    Eposta = reader["Eposta"].ToString()
                });
            }

            reader.Close();
            _sqlConnection.Close();

            return musteriler;
        }

        public override void Sil(Musteri veri)
        {
            string commandText =
                "Exec spMusteriSil @id";

            _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            _sqlCommand = new SqlCommand(commandText, _sqlConnection);

            _sqlCommand.Parameters.AddWithValue("@id", veri.MusteriId);

            _sqlCommand.ExecuteNonQuery();

            _sqlConnection.Close();
        }

    }
}
