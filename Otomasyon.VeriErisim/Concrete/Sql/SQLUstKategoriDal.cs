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
    public class SQLUstKategoriDal : VeriTabani<UstKategori>
    {
      
        public override void Ekle(UstKategori veri)
        {
            string commandText =
                "Exec spUstKategoriEkle @UstKategoriAdi,@AktifMi";

            _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            _sqlCommand = new SqlCommand(commandText, _sqlConnection);

            _sqlCommand.Parameters.AddWithValue("@UstKategoriAdi", veri.UstKategoriAdi);
            _sqlCommand.Parameters.AddWithValue("@AktifMi", veri.AktifMi.ToString());

            _sqlCommand.ExecuteNonQuery();

            _sqlConnection.Close();
        }

        public override void Sil(UstKategori veri)
        {
            string commandText =
                "Exec spUstKategoriSil @id";

            _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            _sqlCommand = new SqlCommand(commandText, _sqlConnection);

            _sqlCommand.Parameters.AddWithValue("@id", veri.UstKategoriId);


            _sqlCommand.ExecuteNonQuery();

            _sqlConnection.Close();
        }

        public override void Guncelle(UstKategori veri)
        {
            string commandText =
                "Exec spUstKategoriGuncelle @id,@UstKategoriAdi, @AktifMi";

            _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            _sqlCommand = new SqlCommand(commandText, _sqlConnection);

            _sqlCommand.Parameters.AddWithValue("@UstKategoriAdi", veri.UstKategoriAdi);
            _sqlCommand.Parameters.AddWithValue("@AktifMi", veri.AktifMi.ToString());
            _sqlCommand.Parameters.AddWithValue("@id", veri.UstKategoriId);


            _sqlCommand.ExecuteNonQuery();

            _sqlConnection.Close();
        }

        public override List<UstKategori> HepsiniGetir()
        {
            string commandText = "Exec spUstKategoriHepsiniGetir";

            List<UstKategori> UstKategoriler = new List<UstKategori>();

            _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            _sqlCommand = new SqlCommand(commandText, _sqlConnection);

            SqlDataReader reader = _sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                UstKategoriler.Add
                    (new UstKategori
                    {
                        UstKategoriId = Convert.ToInt32(reader["UstKategoriId"]),
                        UstKategoriAdi = reader["UstKategoriAdi"].ToString(),
                        AktifMi = Convert.ToBoolean(reader["AktifMi"])
                    });
            }

            reader.Close();
            _sqlConnection.Close();

            return UstKategoriler;
        }
    }
}
