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
    public class SQLSiparisDal : VeriTabani<Siparis>
    {
      

        public override void Ekle(Siparis veri)
        {
            string commandText =
                "Exec spSiparisEkle @MusteriId, @VerilmeTarihi, @VerilmeZamani";

            _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            _sqlCommand = new SqlCommand(commandText, _sqlConnection);

            _sqlCommand.Parameters.AddWithValue("@VerilmeZamani", veri.VerilmeZamani);
            _sqlCommand.Parameters.AddWithValue("@VerilmeTarihi", veri.VerilmeTarihi);
            _sqlCommand.Parameters.AddWithValue("@MusteriId", veri.Musteri.MusteriId);


            _sqlCommand.ExecuteNonQuery();

            _sqlConnection.Close();
        }

        public override void Guncelle(Siparis veri)
        {
            string commandText =
                "Exec spSiparisGuncelle  @id, @MusteriId, @VerilmeTarihi, @VerilmeZamani";

            _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            _sqlCommand = new SqlCommand(commandText, _sqlConnection);


            _sqlCommand.Parameters.AddWithValue("@MusteriId", veri.Musteri.MusteriId);
            _sqlCommand.Parameters.AddWithValue("@VerilmeZamani", veri.VerilmeZamani);
            _sqlCommand.Parameters.AddWithValue("@VerilmeTarihi", veri.VerilmeTarihi);
            _sqlCommand.Parameters.AddWithValue("@id", veri.SiparisId);

            _sqlCommand.ExecuteNonQuery();

            _sqlConnection.Close();
        }

        public override List<Siparis> HepsiniGetir()
        {
            string commandText = "Exec spSiparisHepsiniGetir";

            List<Siparis> siparisler = new List<Siparis>();

            _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            _sqlCommand = new SqlCommand(commandText, _sqlConnection);

            SqlDataReader reader = _sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                siparisler.Add(new Siparis
                {
                    SiparisId = Convert.ToInt32(reader["SiparisId"]),
                    Musteri = MusteriGetir(Convert.ToInt32(reader["SiparisId"])),
                    VerilmeZamani = reader["VerilmeZamani"].ToString(),
                    VerilmeTarihi = reader["VerilmeTarihi"].ToString()
                });
            }

            reader.Close();
            _sqlConnection.Close();

            return siparisler;
        }

        public override void Sil(Siparis veri)
        {
            string commandText =
                "Exec spSiparisSil @id";

            _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            _sqlCommand = new SqlCommand(commandText, _sqlConnection);

            _sqlCommand.Parameters.AddWithValue("@id", veri.SiparisId);

            _sqlCommand.ExecuteNonQuery();

            _sqlConnection.Close();

        }

      

        public Musteri MusteriGetir(int id)
        {
            string commandText =
                "Exec spSiparisinMusterisi @id";

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
    }
}
