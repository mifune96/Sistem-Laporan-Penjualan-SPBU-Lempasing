using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SPBU.GUI
{
    public partial class Form_PENERIMAAN : Form
    {
        Kelas.Koneksi konn = new Kelas.Koneksi();
        public String id_bbm_penerimaan;

        public Form_PENERIMAAN()
        {
            InitializeComponent();
            clear();
            loadDaftar();
        }
        public DataSet getData()
        {
            DataSet dts = new DataSet();

            try
            {
                string sql = "SELECT * FROM vpenerimaan"; SqlCommand command = new SqlCommand();
                command.Connection = konn.GetConn(); command.CommandType = CommandType.Text;
                command.CommandText = sql;
                SqlDataAdapter data = new SqlDataAdapter(command); data.Fill(dts, "vpenerimaan");
            }//try

            catch (Exception e)
            {
                MessageBox.Show("get\n" + e.ToString());

            }//catch

            return dts;

        }//getData
        void header()
        {
            dataGridView_pernerimaan.Columns[0].HeaderText = "Id Penerimaan";
            dataGridView_pernerimaan.Columns[1].HeaderText = "Nama BBM";
            dataGridView_pernerimaan.Columns[2].HeaderText = "Tanggal Penerimaan";
            dataGridView_pernerimaan.Columns[3].HeaderText = "Jumlah Penerimaan";

        }//header
        public void loadDaftar()
        {
            DataSet data = getData();
            dataGridView_pernerimaan.DataSource = data;
            dataGridView_pernerimaan.DataMember = "vpenerimaan";
            header();
        }//loadDaftar
        public void clear()
        {
            textBox_idpenerimaan.Clear();
            textBox_namaBbm_penerimaan.Clear();
            textBox_jumlahPenerimaan.Clear();
            aturTombol(false, false);
        }//clear
        public void aturTombol(bool param1, bool param2)
        {
            button_baru.Enabled = true;
            button_simpan.Enabled = param1;
            button_ubah.Enabled = param2;
            button_hapus.Enabled = param2;
            button_caribbm.Enabled = true;
            textBox_idpenerimaan.Enabled = false;
            textBox_namaBbm_penerimaan.Enabled = false;
            textBox_jumlahPenerimaan.Enabled = param1;
            dateTimePicker_penerimaan.Enabled = param2;
        }//aturTombol 

        string ambilidbbm(string namabbm)
        {
            string id = "";
            SqlConnection sqlConnection = konn.GetConn();
            SqlCommand sqlCmd = new SqlCommand("select id_bbm from tbl_bbm where nama_bbm = '" + namabbm + "'", sqlConnection);// ambil pertalite
            sqlConnection.Open();
            SqlDataReader sqlReader = sqlCmd.ExecuteReader();

            while (sqlReader.Read())
            {
                id = Convert.ToString(sqlReader[0].ToString());
                // MessageBox.Show("" + id);
            }
            sqlReader.Close();
            //MessageBox.Show("" + id);
            return id;
        }

        private void textBox_cari_TextChanged(object sender, EventArgs e)
        {
            if (textBox_cari.Text == "")
            {
                loadDaftar();
            }//if
            else
            {
                DataSet dts = new DataSet();
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = konn.GetConn();
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT * FROM vpenerimaan WHERE id_penerimaan LIKE'%" + textBox_cari.Text + "%' OR nama_bbm LIKE'%" + textBox_cari.Text + "%'";
                    SqlDataAdapter data = new SqlDataAdapter(command);
                    data.Fill(dts, "vpenerimaan");
                    dataGridView_pernerimaan.DataSource = dts;
                    dataGridView_pernerimaan.DataMember = "vpenerimaan";
                }//try
                catch (SqlException)
                {

                }//catch 
            }//else
        }

        private void button_baru_Click(object sender, EventArgs e)
        {

            SqlConnection sqlConnection = konn.GetConn();
            SqlCommand sqlCmd = new SqlCommand("SELECT MAX(id_penerimaan) FROM tbl_penerimaan", sqlConnection);// ambil pertalite
            sqlConnection.Open();
            SqlDataReader sqlReader = sqlCmd.ExecuteReader();

            while (sqlReader.Read())
            {
                textBox_idpenerimaan.Text = (Convert.ToInt64(sqlReader[0].ToString()).ToString());
            }
            sqlReader.Close();
            clear();
            aturTombol(true, true);
        }

        private void Form_PENERIMAAN_Load(object sender, EventArgs e)
        {

        }

        private void button_simpan_Click(object sender, EventArgs e)
        {
            if (textBox_namaBbm_penerimaan.Text == "" || textBox_namaBbm_penerimaan.Text == "" || textBox_jumlahPenerimaan.Text == "" || Convert.ToDateTime(dateTimePicker_penerimaan.Value).ToString("yyyy-MM-dd") == "")
            {
                MessageBox.Show("Data Harus Di Isi !!!");
            }
            else
            {
                try
                {

                    SqlCommand command = new SqlCommand();
                    command.Connection = konn.GetConn();
                    command.Connection.Open();
                    command.CommandType = CommandType.Text;
                    command.CommandText = "INSERT INTO tbl_penerimaan VALUES('" + id_bbm_penerimaan + "','" + Convert.ToDateTime(dateTimePicker_penerimaan.Value).ToString("yyyy-MM-dd") + "','" + textBox_jumlahPenerimaan.Text + "')";
                    command.ExecuteNonQuery();
                    command.Connection.Close(); //pesan berhasil 
                    MessageBox.Show("Data Berhasil Disimpan", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information); //memanggil tampil data 
                    loadDaftar(); //memanggil bersih data 
                    clear();
                }//try 

                catch (SqlException h)
                {
                    MessageBox.Show("Gagal Simpan Data\n" + h, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }//catch
            }
        }

        private void button_ubah_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = konn.GetConn();
                command.Connection.Open();
                command.CommandType = CommandType.Text;
                command.CommandText = "UPDATE tbl_penerimaan SET id_bbm='" + ambilidbbm(textBox_namaBbm_penerimaan.Text) + "',tgl_penerimaan='" + Convert.ToDateTime(dateTimePicker_penerimaan.Value).ToString("yyyy-MM-dd") + "',jumlah_penerimaan='" + textBox_jumlahPenerimaan.Text + "'WHERE id_penerimaan='" + textBox_idpenerimaan.Text + "'";
                Console.WriteLine(command.CommandText); command.ExecuteNonQuery();
                command.Connection.Close(); //pesan berhasil
                MessageBox.Show("Data Berhasil Diubah", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information); //memanggil tampil data 
                loadDaftar(); //memanggil bersih data 
                clear();
            }//try
            catch (SqlException exc)
            {
                MessageBox.Show("Gagal Ubah Data\n" + exc, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }//catch
        }

        private void button_hapus_Click(object sender, EventArgs e)
        {
            string id = textBox_idpenerimaan.Text;
            DialogResult akses = MessageBox.Show("Apakah data penerimaan dengan nama " + textBox_namaBbm_penerimaan.Text + " akan dihapus??", "Informasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (akses == DialogResult.Yes)
            { //askes ke  controller 

                SqlCommand command = new SqlCommand();
                command.Connection = konn.GetConn();
                command.Connection.Open();
                command.CommandType = CommandType.Text;
                command.CommandText = "DELETE FROM tbl_penerimaan WHERE id_penerimaan='" + id + "'";
                command.ExecuteNonQuery();
                command.Connection.Close();//pesan berhasil 
                MessageBox.Show("Data Berhasil Dihapus", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information); //memanggil tampil data 
                loadDaftar(); //memanggil bersih data 
                clear();
            }//if
        }

        private void button_caribbm_Click(object sender, EventArgs e)
        {
            Dialog_BBM bbm = new Dialog_BBM();
            Dialog_BBM.men = "penerimaan";
            bbm.penerimaan = this;
            bbm.ShowDialog();
        }

        private void dataGridView_pernerimaan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox_idpenerimaan.Text = dataGridView_pernerimaan.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox_namaBbm_penerimaan.Text = dataGridView_pernerimaan.Rows[e.RowIndex].Cells[1].Value.ToString();
                dateTimePicker_penerimaan.Value = Convert.ToDateTime(dataGridView_pernerimaan.Rows[e.RowIndex].Cells[2].Value.ToString());
                textBox_jumlahPenerimaan.Text = dataGridView_pernerimaan.Rows[e.RowIndex].Cells[3].Value.ToString();
                aturTombol(true, true);
                button_simpan.Enabled = false;
            }//try 
            catch
            {
            }//catch
        }

        private void dataGridView_pernerimaan_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
             try
            {
                textBox_idpenerimaan.Text = dataGridView_pernerimaan.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox_namaBbm_penerimaan.Text = dataGridView_pernerimaan.Rows[e.RowIndex].Cells[1].Value.ToString();
                dateTimePicker_penerimaan.Value = Convert.ToDateTime(dataGridView_pernerimaan.Rows[e.RowIndex].Cells[2].Value.ToString());
                textBox_jumlahPenerimaan.Text = dataGridView_pernerimaan.Rows[e.RowIndex].Cells[3].Value.ToString();
                aturTombol(true, true);
                button_simpan.Enabled = false;
            }//try 
            catch
             {

             }
        }
    }
}
