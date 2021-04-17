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
    public class SQLUrunResmiDal : VeriTabani<UrunResmi>
    {

        public override void Ekle(UrunResmi veri)
        {
            string commandText =
                "Exec spUrunResmiEkle @ResimAdi, @ResimYolu, @Resim, @UrunId";

            _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            _sqlCommand = new SqlCommand(commandText, _sqlConnection);

            _sqlCommand.Parameters.AddWithValue("@ResimAdi", veri.ResimAdi);
            _sqlCommand.Parameters.AddWithValue("@ResimYolu", veri.ResimYolu);
            _sqlCommand.Parameters.AddWithValue("@Resim", veri.Resim);
            _sqlCommand.Parameters.AddWithValue("@UrunId", veri.Urun.UrunId);
           

            _sqlCommand.ExecuteNonQuery();

            _sqlConnection.Close();
        }

        public override void Guncelle(UrunResmi veri)
        {
            string commandText =
                "Exec spUrunResmiGuncelle @ResimId, @ResimAdi, @ResimYolu,  @Resim, @UrunId";

            _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            _sqlCommand = new SqlCommand(commandText, _sqlConnection);

            _sqlCommand.Parameters.AddWithValue("@ResimAdi", veri.ResimAdi);
            _sqlCommand.Parameters.AddWithValue("@ResimYolu", veri.ResimYolu);
            _sqlCommand.Parameters.AddWithValue("@Resim", veri.Resim);
            _sqlCommand.Parameters.AddWithValue("@UrunId", veri.Urun.UrunId);
            _sqlCommand.Parameters.AddWithValue("@ResimId", veri.ResimId);


            _sqlCommand.ExecuteNonQuery();

            _sqlConnection.Close();
        }

        public override List<UrunResmi> HepsiniGetir()
        {
            string commandText = "Exec spUrunResmiHepsiniGetir";

            List<UrunResmi> urunResimleri = new List<UrunResmi>();

            _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            _sqlCommand = new SqlCommand(commandText, _sqlConnection);

            SqlDataReader reader = _sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                urunResimleri.Add(new UrunResmi
                {
                    Resim = (byte[]) reader["Resim"],
                    ResimAdi = reader["ResimAdi"].ToString(),
                    ResimId = Convert.ToInt32(reader["ResimId"]),
                    ResimYolu = reader["resimYolu"].ToString(),
                    Urun = UrunGetir(Convert.ToInt32(reader["ResimId"]))
                });
            }

            reader.Close();
            _sqlConnection.Close();

            return urunResimleri;
        }

        public override void Sil(UrunResmi veri)
        {

            string commandText =
                "Exec spUrunResmiSil @ResimId";

            _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            _sqlCommand = new SqlCommand(commandText, _sqlConnection);

            _sqlCommand.Parameters.AddWithValue("@ResimId", veri.ResimId);


            _sqlCommand.ExecuteNonQuery();

            _sqlConnection.Close();
        }

        public Urun UrunGetir(int id)
        {
            string commandText =
                "Exec spUrunResmiUrunu @id";

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
                urun.AktifMi = Convert.ToBoolean(reader["AktifMi"]);
                urun.Fiyat = Convert.ToSingle(reader["Fiyat"]);
                urun.StokDuzeyi = Convert.ToInt32(reader["StokDuzeyi"]);
                urun.UrunAdi = reader["UrunAdi"].ToString();
                urun.UrunPuani = Convert.ToSingle(reader["urunPuani"]);
                urun.Kategori = urunDal.KategoriGetir(Convert.ToInt32(reader["UrunId"]));
            }

            reader.Close();
            _sqlConnection.Close();

            return urun;
        }
    }
}
