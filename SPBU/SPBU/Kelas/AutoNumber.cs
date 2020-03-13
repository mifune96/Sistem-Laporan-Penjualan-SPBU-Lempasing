using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPBU.Kelas
{
    class AutoNumber
    {
        Kelas.Koneksi konn = new Kelas.Koneksi();
        public string Auto(String NamaTabel, String Kode, String Id)
        {
            string kode = "";
            int a, x, cek = 0;
            string angka = null;
            string sql = "SELECT * FROM " + NamaTabel + " ORDER BY SUBSTRING(" + Id + ",3,6) ASC";
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = konn.GetConn();
                command.Connection.Open();
                command.CommandType = CommandType.Text;
                command.CommandText = sql; SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    cek++; angka = reader.GetString(0).ToString().Substring(2, 4);
                }
                command.Connection.Close();

                if (cek != 0)
                {
                    x = Int32.Parse(angka);
                    a = x + 1;
                    if (a >= 1 && a < 10)
                    {
                        kode = Kode + "-" + "000" + a;
                    }
                    else if (a >= 10 && a < 100)
                    {
                        kode = Kode + "-" + "00" + a;
                    }
                    else if (a >= 100 && a < 1000)
                    {
                        kode = Kode + "-" + "0" + a;
                    }
                    else if (a >= 1000 && a < 10000)
                    {
                        kode = Kode + "-" + "" + a;
                    }
                    else if (a >= 10000)
                    {
                        MessageBox.Show("Error", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Kode Habis", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    kode = Kode + "-" + "0001";
                }
            }
            catch (SqlException e) { MessageBox.Show("" + e); }
            return kode;
        }
    }
}
