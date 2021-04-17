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
    public class SQLUrunDal : VeriTabani<Urun>
    {
        public override void Ekle(Urun veri)
        {
            string commandText =
                "Exec spUrunEkle @UrunAdi, @StokDuzeyi, @Fiyat, @UrunPuani, @KategoriId, @AktifMi,@AlisPuani";

            _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            _sqlCommand = new SqlCommand(commandText, _sqlConnection);

            _sqlCommand.Parameters.AddWithValue("@UrunAdi", veri.UrunAdi);
            _sqlCommand.Parameters.AddWithValue("@KategoriId", veri.Kategori.KategoriId);
            _sqlCommand.Parameters.AddWithValue("@Fiyat", veri.Fiyat);
            _sqlCommand.Parameters.AddWithValue("@StokDuzeyi", veri.StokDuzeyi);
            _sqlCommand.Parameters.AddWithValue("@UrunPuani", veri.UrunPuani);
            _sqlCommand.Parameters.AddWithValue("@AktifMi", veri.AktifMi.ToString());
            _sqlCommand.Parameters.AddWithValue("@AlisPuani", veri.AlisPuani.ToString());

            _sqlCommand.ExecuteNonQuery();

            _sqlConnection.Close();
        }

        public override void Guncelle(Urun veri)
        {
            string commandText =
                "Exec spUrunGuncelle @id, @UrunAdi, @StokDuzeyi, @Fiyat, @UrunPuani, @KategoriId, @AktifMi, @AlisPuani";

            _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            _sqlCommand = new SqlCommand(commandText, _sqlConnection);

            _sqlCommand.Parameters.AddWithValue("@UrunAdi", veri.UrunAdi);
            _sqlCommand.Parameters.AddWithValue("@KategoriId", veri.Kategori.KategoriId);
            _sqlCommand.Parameters.AddWithValue("@Fiyat", veri.Fiyat);
            _sqlCommand.Parameters.AddWithValue("@StokDuzeyi", veri.StokDuzeyi);
            _sqlCommand.Parameters.AddWithValue("@UrunPuani", veri.UrunPuani);
            _sqlCommand.Parameters.AddWithValue("@AktifMi", veri.AktifMi.ToString());
            _sqlCommand.Parameters.AddWithValue("@AlisPuani", veri.AlisPuani.ToString());
            _sqlCommand.Parameters.AddWithValue("@id", veri.UrunId);
         

            _sqlCommand.ExecuteNonQuery();

            _sqlConnection.Close();

        }

        public override List<Urun> HepsiniGetir()
        {
            string commandText = "Exec spUrunHepsiniGetir";

            List<Urun> urunler = new List<Urun>();

            _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            _sqlCommand = new SqlCommand(commandText, _sqlConnection);

            SqlDataReader reader = _sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                urunler.Add(new Urun
                {
                    Fiyat = Convert.ToSingle(reader["Fiyat"]),
                    Kategori = KategoriGetir(Convert.ToInt32(reader["UrunId"])),
                    UrunId = Convert.ToInt32(reader["UrunId"]),
                    StokDuzeyi = Convert.ToInt32(reader["StokDuzeyi"]),
                    UrunAdi = reader["UrunAdi"].ToString(),
                    UrunPuani = Convert.ToInt32(reader["UrunPuani"]),
                    AktifMi = Convert.ToBoolean(reader["AktifMi"]),
                    AlisPuani = Convert.ToSingle(reader["AlisPuani"])
               
                });
            }

            reader.Close();
            _sqlConnection.Close();

            return urunler;


        }

        public override void Sil(Urun veri)
        {
            string commandText =
                "Exec spUrunSil @id";


            _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            _sqlCommand = new SqlCommand(commandText, _sqlConnection);

            _sqlCommand.Parameters.AddWithValue("@id", veri.UrunId);

            _sqlCommand.ExecuteNonQuery();

            _sqlConnection.Close();

        }


        public Kategori KategoriGetir(int id)
        {
            string commandText =
                "Exec spUrunKategorisi @id";

            _sqlConnection = new SqlConnection(yol);


            Kategori kategori = new Kategori();

            SQLKategoriDal kategoriDal = new SQLKategoriDal();

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            _sqlCommand = new SqlCommand(commandText, _sqlConnection);

            _sqlCommand.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = _sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                kategori.KategoriId = Convert.ToInt32(reader["KategoriId"]);
                kategori.KategoriAdi = reader["KategoriAdi"].ToString();
                kategori.UstKategori = kategoriDal.UstKategoriGetir(Convert.ToInt32(reader["KategoriId"]));
                kategori.AktifMi = Convert.ToBoolean(reader["AktifMi"]);
            }

            reader.Close();
            _sqlConnection.Close();

            return kategori;
        }

    }
}
