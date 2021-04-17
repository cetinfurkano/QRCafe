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
    public class SQLMasaDal : VeriTabani<Masa>
    {
        public override void Ekle(Masa veri)
        {
            string commandText =
                "Exec spMasaEkle @MasaId, @MusaitlikDurumu";

            _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            _sqlCommand = new SqlCommand(commandText, _sqlConnection);

            _sqlCommand.Parameters.AddWithValue("@MasaId", veri.MasaId);

            _sqlCommand.Parameters.AddWithValue("@MusaitlikDurumu", veri.MusaitlikDurumu.ToString());

            _sqlCommand.ExecuteNonQuery();

            _sqlConnection.Close();


        }

        public override void Guncelle(Masa veri)
        {
            string commandText =
                "Exec spMasaGuncelle @MasaId, @MusaitlikDurumu";

            _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            _sqlCommand = new SqlCommand(commandText, _sqlConnection);
            
            _sqlCommand.Parameters.AddWithValue("@MusaitlikDurumu", veri.MusaitlikDurumu);
            _sqlCommand.Parameters.AddWithValue("@id", veri.MasaId);

            _sqlCommand.ExecuteNonQuery();

            _sqlConnection.Close();
        }
        

        public override void Sil(Masa veri)
        {
            string commandText =
                "Exec spMasaSil @id";

            _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            _sqlCommand = new SqlCommand(commandText, _sqlConnection);

            _sqlCommand.Parameters.AddWithValue("@id", veri.MasaId);

            _sqlCommand.ExecuteNonQuery();

            _sqlConnection.Close();

       }

       
        public override List<Masa> HepsiniGetir()
        {
            string commandText = "Exec spMasaHepsiniGetir";

            List<Masa> masalar = new List<Masa>();

            _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            _sqlCommand = new SqlCommand(commandText, _sqlConnection);

            SqlDataReader reader = _sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                masalar.Add(new Masa{ MasaId = reader["MasaId"].ToString(), MusaitlikDurumu = Convert.ToBoolean(reader["MusaitlikDurumu"])});
            }

            reader.Close();
            _sqlConnection.Close();

            return masalar;

        } 
    }
}
