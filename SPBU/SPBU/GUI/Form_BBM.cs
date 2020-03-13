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
    public partial class Form_BBM : Form
    {
        Kelas.Koneksi konn = new Kelas.Koneksi();
        
        public Form_BBM()
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
                string sql = "SELECT * FROM tbl_bbm"; SqlCommand command = new SqlCommand();
                command.Connection = konn.GetConn(); command.CommandType = CommandType.Text;
                command.CommandText = sql;
                SqlDataAdapter data = new SqlDataAdapter(command); data.Fill(dts, "tbl_bbm");
            }//try

            catch (Exception e)
            {
                MessageBox.Show("get\n" + e.ToString());

            }//catch

            return dts;

        }//getData

        void header()
        {
            dataGridView_bbm.Columns[0].HeaderText = "Id BBM";
            dataGridView_bbm.Columns[1].HeaderText = "Nama BBM";
            dataGridView_bbm.Columns[2].HeaderText = "Harga";
       
        }//header
        public void loadDaftar()
        {
            DataSet data = getData();
            dataGridView_bbm.DataSource = data;
            dataGridView_bbm.DataMember = "tbl_bbm";
            header();
        }//loadDaftar
        public void clear()
        {
            textBox_idBbm.Clear();
            textBox_namaBBM.Clear();
            textBox_harga.Clear();
            aturTombol(false, false);
        }//clear

        public void aturTombol(bool param1, bool param2)
        {
            button_baru.Enabled = true;
            button_simpan.Enabled = param1;
            button_ubah.Enabled = param2;
            button_hapus.Enabled = param2;
            textBox_idBbm.Enabled = param1;
            textBox_namaBBM.Enabled = param1;
            textBox_harga.Enabled = param1;
        }//aturTombol       
        private void button_baru_Click(object sender, EventArgs e)
        {
            clear();
            aturTombol(true, false);
        }

        private void dataGridView_bbm_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                clear();
                textBox_idBbm.Text = dataGridView_bbm.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox_namaBBM.Text = dataGridView_bbm.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox_harga.Text = dataGridView_bbm.Rows[e.RowIndex].Cells[2].Value.ToString();
                aturTombol(true, true);
                button_simpan.Enabled = false;
            }//try 
            catch
            {
            }//catch
        }

        private void button_simpan_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = konn.GetConn();
                command.Connection.Open();
                command.CommandType = CommandType.Text;
                command.CommandText = "INSERT INTO tbl_bbm VALUES('" + textBox_idBbm.Text + "','" + textBox_namaBBM.Text + "','" + textBox_harga.Text + "')";
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

        private void button_ubah_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = konn.GetConn();
                command.Connection.Open();
                command.CommandType = CommandType.Text;
                command.CommandText = "UPDATE tbl_bbm SET nama_bbm='" + textBox_namaBBM.Text + "',harga='" + textBox_harga.Text + "'WHERE id_bbm='" + textBox_idBbm.Text + "'";
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
            string id = textBox_idBbm.Text;
            DialogResult akses = MessageBox.Show("Apakah data BBM dengan Nama BBM " + textBox_namaBBM.Text + " akan dihapus??", "Informasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (akses == DialogResult.Yes)
            { //askes ke  controller 

                SqlCommand command = new SqlCommand();
                command.Connection = konn.GetConn();
                command.Connection.Open();
                command.CommandType = CommandType.Text;
                command.CommandText = "DELETE FROM tbl_bbm WHERE id_bbm='" + id + "'";
                command.ExecuteNonQuery();
                command.Connection.Close();//pesan berhasil 
                MessageBox.Show("Data Berhasil Dihapus", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information); //memanggil tampil data 
                loadDaftar(); //memanggil bersih data 
                clear();
            }//if
        }
    }
}
