using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SPBU.Kelas
{
    class Koneksi
    {
          public SqlConnection GetConn()
        {
            SqlConnection conn = new SqlConnection();
            string serverName = "DESKTOP-023L1MG"; string namaDatabase = "db_SPBU";
            conn.ConnectionString = "Data Source= " + serverName + "; Initial Catalog= " + namaDatabase + "; Integrated Security=True";
            return conn;
        }//sqlConnection
    }
}
