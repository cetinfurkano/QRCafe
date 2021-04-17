using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Otomasyon.VeriErisim.Abstracts;
using Otomasyon.Veriler.Concrete;

namespace Otomasyon.VeriErisim.Concrete.Sql
{
    public class SQLKategoriDal : VeriTabani<Kategori>
    {
        public override void Ekle(Kategori veri)
        {
            string commandText =
                "Exec spKategoriEkle @KategoriAdi,@UstKategoriId,@AktifMi";

            _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            _sqlCommand = new SqlCommand(commandText, _sqlConnection);

            _sqlCommand.Parameters.AddWithValue("@KategoriAdi", veri.KategoriAdi);
            _sqlCommand.Parameters.AddWithValue("@UstKategoriId", veri.UstKategori.UstKategoriId);
            _sqlCommand.Parameters.AddWithValue("@AktifMi", veri.AktifMi.ToString());

            _sqlCommand.ExecuteNonQuery();

            _sqlConnection.Close();
        }

        public override void Guncelle(Kategori veri)
        {
            string commandText =
                "Exec spKategoriGuncelle @id, @KategoriAdi,@AktifMi,@UstKategoriId";

            _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            _sqlCommand = new SqlCommand(commandText, _sqlConnection);

            _sqlCommand.Parameters.AddWithValue("@KategoriAdi", veri.KategoriAdi);
            _sqlCommand.Parameters.AddWithValue("@UstKategoriId", veri.UstKategori.UstKategoriId);
            _sqlCommand.Parameters.AddWithValue("@AktifMi", veri.AktifMi.ToString());

            _sqlCommand.Parameters.AddWithValue("@id", veri.KategoriId);

            _sqlCommand.ExecuteNonQuery();

            _sqlConnection.Close();
        }

        public override List<Kategori> HepsiniGetir()
        {
            string commandText = "Exec spKategoriHepsiniGetir";

            List<Kategori> kategoriler = new List<Kategori>();

            _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            _sqlCommand = new SqlCommand(commandText, _sqlConnection);

            SqlDataReader reader = _sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                kategoriler.Add(
                    new Kategori
                    {
                        KategoriId = Convert.ToInt32(reader["KategoriId"]),
                        KategoriAdi = reader["KategoriAdi"].ToString(),
                        UstKategori = UstKategoriGetir(Convert.ToInt32(reader["KategoriId"])),
                        AktifMi = Convert.ToBoolean(reader["AktifMi"])
                    });
            }

            reader.Close();
            _sqlConnection.Close();

            return kategoriler;


        }

        public override void Sil(Kategori veri)
        {
            string commandText =
                "Exec spKategoriSil @id";

            _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            _sqlCommand = new SqlCommand(commandText, _sqlConnection);

            _sqlCommand.Parameters.AddWithValue("@id", veri.KategoriId);

            _sqlCommand.ExecuteNonQuery();

            _sqlConnection.Close();
        }


        public UstKategori UstKategoriGetir(int id)
        {
            string commandText =
                "Exec spKategorininUstKategorisi @id";

            _sqlConnection = new SqlConnection(yol);

            UstKategori ustKategori = new UstKategori();

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            _sqlCommand = new SqlCommand(commandText, _sqlConnection);

            _sqlCommand.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = _sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                ustKategori.UstKategoriId = Convert.ToInt32(reader["UstKategoriId"]);
                ustKategori.UstKategoriAdi = reader["UstKategoriAdi"].ToString();
                ustKategori.AktifMi = Convert.ToBoolean(reader["AktifMi"]);
            }

            reader.Close();
            _sqlConnection.Close();

            return ustKategori;
        }
    }
}
