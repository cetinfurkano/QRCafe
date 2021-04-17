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
    public class SQLGunSonuDal:VeriTabani<GunSonu>
    {

        public override List<GunSonu> HepsiniGetir()
        {
            string commandText = "Exec spGunSonuGrid @Tarih";

            List<GunSonu> gunsonu = new List<GunSonu>();

            _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            _sqlCommand = new SqlCommand(commandText, _sqlConnection);
            _sqlCommand.Parameters.AddWithValue("@Tarih", DateTime.Now.ToString("dd.MM.yyyy"));

            SqlDataReader reader = _sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                gunsonu.Add(new GunSonu
                {
                    UrunAdi = reader["UrunAdi"].ToString(),
                    UrunAdet = Convert.ToInt32(reader["Adet"]),
                    Fiyat = Convert.ToSingle(reader["GecmisFiyat"])
                    
                });
            }

            reader.Close();
            _sqlConnection.Close();

            return gunsonu;
        }
    }
}
