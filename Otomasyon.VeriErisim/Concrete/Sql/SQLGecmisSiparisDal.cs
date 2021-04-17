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
    public class SQLGecmisSiparisDal: VeriTabani<GecmisSiparis>
    {
        public override void Ekle(GecmisSiparis veri)
        {
            string commandText =
                "Exec spGecmisSiparisEkle @SiparisId, @MusteriId, @VerilmeTarihi, @VerilmeZamani, @TeslimTarihi, @TeslimZamani";

            _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            _sqlCommand = new SqlCommand(commandText, _sqlConnection);

            _sqlCommand.Parameters.AddWithValue("@SiparisId", veri.GecmisSiparisId);
            _sqlCommand.Parameters.AddWithValue("@MusteriId", veri.Musteri.MusteriId);
            _sqlCommand.Parameters.AddWithValue("@VerilmeTarihi", veri.VerilmeTarihi);
            _sqlCommand.Parameters.AddWithValue("@VerilmeZamani", veri.VerilmeZamani);
            _sqlCommand.Parameters.AddWithValue("@TeslimTarihi", veri.TeslimTarihi);
            _sqlCommand.Parameters.AddWithValue("@TeslimZamani", veri.TeslimZamani);

            _sqlCommand.ExecuteNonQuery();

            _sqlConnection.Close();
        }
        
        public override List<GecmisSiparis> HepsiniGetir()
        {
            string commandText = "Exec spGecmisSiparisGetir";

            List<GecmisSiparis> gecmisSiparisler = new List<GecmisSiparis>();

            _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            _sqlCommand = new SqlCommand(commandText, _sqlConnection);

            SqlDataReader reader = _sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                gecmisSiparisler.Add(new GecmisSiparis
                {
                    Musteri = MusteriGetir(Convert.ToInt32(reader["GecmisSiparisId"])),
                    GecmisSiparisId = Convert.ToInt32(reader["GecmisSiparisId"]),
                    VerilmeTarihi = reader["VerilmeTarihi"].ToString(),
                    VerilmeZamani = reader["VerilmeZamani"].ToString(),
                    TeslimTarihi = reader["TeslimTarihi"].ToString(),
                    TeslimZamani = reader["TeslimZamani"].ToString()
                });
            }

            reader.Close();
            _sqlConnection.Close();

            return gecmisSiparisler;
        }

        public Musteri MusteriGetir(int id)
        {
            string commandText =
                "Exec spGecmisSiparisMusterisi @id";

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
