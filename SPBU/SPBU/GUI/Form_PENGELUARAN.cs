using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace SPBU.GUI
{
    public partial class Form_PENGELUARAN : Form
    {
        Kelas.Koneksi konn = new Kelas.Koneksi();
        Kelas.AutoNumber AutoNumber = new Kelas.AutoNumber();
        public Form_PENGELUARAN()
        {
            InitializeComponent();
            clear();
            loadDaftar();
            try
            {
                textBox_idPengeluaran.Text = AutoNumber.Auto("tbl_pengeluaran", "K", "id_pengeluaran");
            }
            catch (Exception e)
            {
                MessageBox.Show("" + e);
            }
        }
        public DataSet getData()
        {
            DataSet dts = new DataSet();

            try
            {
                string sql = "SELECT * FROM tbl_pengeluaran"; SqlCommand command = new SqlCommand();
                command.Connection = konn.GetConn(); command.CommandType = CommandType.Text;
                command.CommandText = sql;
                SqlDataAdapter data = new SqlDataAdapter(command); data.Fill(dts, "tbl_pengeluaran");
            }//try

            catch (Exception e)
            {
                MessageBox.Show("get\n" + e.ToString());

            }//catch

            return dts;

        }//getData
        void header()
        {
            dataGridView_pengeluaran.Columns[0].HeaderText = "Id Pengeluaran";
            dataGridView_pengeluaran.Columns[1].HeaderText = "Deskripsi";
            dataGridView_pengeluaran.Columns[2].HeaderText = "Jumlah Pengeluaran";
            dataGridView_pengeluaran.Columns[3].HeaderText = "Tgl Pengeluaran";

        }//header
        public void loadDaftar()
        {
            DataSet data = getData();
            dataGridView_pengeluaran.DataSource = data;
            dataGridView_pengeluaran.DataMember = "tbl_pengeluaran";
            header();
        }//loadDaftar
        public void clear()
        {
            textBox_idPengeluaran.Clear();
            textBox_jumlah.Clear();
            richTextBox_deskripsi.Clear();
            aturTombol(false, false);
        }//clear
        public void aturTombol(bool param1, bool param2)
        {
            button_baru.Enabled = true;
            button_simpan.Enabled = param1;
            button_ubah.Enabled = param2;
            button_hapus.Enabled = param2;
            textBox_idPengeluaran.Enabled = false;
            richTextBox_deskripsi.Enabled = param1;
            textBox_jumlah.Enabled = param1;
            dateTimePicker1.Enabled = param2;

        }//aturTombol 

        private void Form_PENGELUARAN_Load(object sender, EventArgs e)
        {

        }

        private void button_baru_Click(object sender, EventArgs e)
        {
            clear();
            textBox_idPengeluaran.Text = AutoNumber.Auto("tbl_pengeluaran", "K", "id_pengeluaran");
            aturTombol(true, true);
        }

        private void button_simpan_Click(object sender, EventArgs e)
        {
            if (textBox_idPengeluaran.Text == "" || textBox_jumlah.Text == "" || richTextBox_deskripsi.Text == "" || Convert.ToDateTime(dateTimePicker1.Value).ToString("yyyy-MM-dd") == "")
            {
                MessageBox.Show("Data Harus Di Isi !!!");
            }
            else
            {
                try
                {
                    textBox_idPengeluaran.Text = AutoNumber.Auto("tbl_pengeluaran", "K", "id_pengeluaran");
                    SqlCommand command = new SqlCommand();
                    command.Connection = konn.GetConn();
                    command.Connection.Open();
                    command.CommandType = CommandType.Text;
                    command.CommandText = "INSERT INTO tbl_pengeluaran VALUES('" + textBox_idPengeluaran.Text + "','" + richTextBox_deskripsi.Text + "','" + textBox_jumlah.Text + "','" + Convert.ToDateTime(dateTimePicker1.Value).ToString("yyyy-MM-dd") + "')";
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
        private void dataGridView_pengeluaran_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox_idPengeluaran.Text = dataGridView_pengeluaran.Rows[e.RowIndex].Cells[0].Value.ToString();
            richTextBox_deskripsi.Text = dataGridView_pengeluaran.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox_jumlah.Text = dataGridView_pengeluaran.Rows[e.RowIndex].Cells[2].Value.ToString();
            dateTimePicker1.Value = Convert.ToDateTime(dataGridView_pengeluaran.Rows[e.RowIndex].Cells[3].Value.ToString());
            aturTombol(true, true);
            button_simpan.Enabled = false;
        }

        private void button_ubah_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = konn.GetConn();
                command.Connection.Open();
                command.CommandType = CommandType.Text;
                command.CommandText = "UPDATE tbl_pengeluaran SET deskripsi='" + richTextBox_deskripsi.Text + "',jumlah_pengeluaran='" + textBox_jumlah.Text + "',tgl_pengeluaran='" + Convert.ToDateTime(dateTimePicker1.Value).ToString("yyyy-MM-dd") + "'WHERE id_pengeluaran='" + textBox_idPengeluaran.Text + "'";
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
            string id = textBox_idPengeluaran.Text;
            DialogResult akses = MessageBox.Show("Apakah data Pengeluaran dengan Deskripsi Pengeluaran " + richTextBox_deskripsi.Text + " akan dihapus??", "Informasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (akses == DialogResult.Yes)
            { //askes ke  controller 

                SqlCommand command = new SqlCommand();
                command.Connection = konn.GetConn();
                command.Connection.Open();
                command.CommandType = CommandType.Text;
                command.CommandText = "DELETE FROM tbl_pengeluaran WHERE id_pengeluaran='" + id + "'";
                command.ExecuteNonQuery();
                command.Connection.Close();//pesan berhasil 
                MessageBox.Show("Data Berhasil Dihapus", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information); //memanggil tampil data 
                loadDaftar(); //memanggil bersih data 
                clear();
            }//if
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
                    command.CommandText = "SELECT * FROM tbl_pengeluaran WHERE id_pengeluaran LIKE'%" + textBox_cari.Text + "%' OR deskripsi LIKE'%" + textBox_cari.Text + "%'";
                    SqlDataAdapter data = new SqlDataAdapter(command);
                    data.Fill(dts, "tbl_pengeluaran");
                    dataGridView_pengeluaran.DataSource = dts;
                    dataGridView_pengeluaran.DataMember = "tbl_pengeluaran";
                }//try
                catch (SqlException)
                {

                }//catch 
            }//else
        }
    }
}
