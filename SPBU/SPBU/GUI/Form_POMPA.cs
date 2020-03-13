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
    public partial class Form_POMPA : Form
    {
        Kelas.Koneksi konn = new Kelas.Koneksi();
        public String id_bbm_pompa;
       

        public Form_POMPA()
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
                string sql = "SELECT * FROM vpompa"; SqlCommand command = new SqlCommand();
                command.Connection = konn.GetConn(); command.CommandType = CommandType.Text;
                command.CommandText = sql;
                SqlDataAdapter data = new SqlDataAdapter(command); data.Fill(dts, "vpompa");
            }//try

            catch (Exception e)
            {
                MessageBox.Show("get\n" + e.ToString());

            }//catch

            return dts;

        }//getData
        void header()
        {
            dataGridView1.Columns[0].HeaderText = "Id Pompa";
            dataGridView1.Columns[1].HeaderText = "Nama Pompa";
            dataGridView1.Columns[2].HeaderText = "Nama BBM";

        }//header
        public void loadDaftar()
        {
            DataSet data = getData();
            dataGridView1.DataSource = data;
            dataGridView1.DataMember = "vpompa";
            header();
        }//loadDaftar
        public void clear()
        {
            textBox1_idPompa.Clear();
            textBox1_namaPompa.Clear();
            textBox_namabbm.Clear();
            aturTombol(false, false);
        }//clear
        public void aturTombol(bool param1, bool param2)
        {
            button1_baru.Enabled = true;
            button4_simpan.Enabled = param1;
            button3_ubah.Enabled = param2;
            button2_hapus.Enabled = param2;
            button_id.Enabled = true;
            textBox1_idPompa.Enabled = param1;
            textBox1_namaPompa.Enabled = param1;
            textBox_namabbm.Enabled = false;
        }//aturTombol 

        private void Form_POMPA_Load(object sender, EventArgs e)
        {

        }

        private void button1_baru_Click(object sender, EventArgs e)
        {
            clear();
            aturTombol(true, false);
        }

        private void button4_simpan_Click(object sender, EventArgs e)
        {
            if (textBox_namabbm.Text == "" || textBox1_idPompa.Text == "" || textBox1_namaPompa.Text == "")
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
                    command.CommandText = "INSERT INTO tbl_pompa VALUES('" + textBox1_idPompa.Text + "','" + textBox1_namaPompa.Text + "','" + id_bbm_pompa + "')";
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

        private void button3_ubah_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = konn.GetConn();
                command.Connection.Open();
                command.CommandType = CommandType.Text;
                command.CommandText = "UPDATE tbl_pompa SET nama_pompa='" + textBox1_namaPompa.Text + "',id_bbm='" + id_bbm_pompa + "'WHERE id_pompa='" + textBox1_idPompa.Text + "'";
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

        private void button2_hapus_Click(object sender, EventArgs e)
        {
            string id = textBox1_idPompa.Text;
            DialogResult akses = MessageBox.Show("Apakah data pompa dengan nama " + textBox1_namaPompa.Text + " akan dihapus??", "Informasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (akses == DialogResult.Yes)
            { //askes ke  controller 

                SqlCommand command = new SqlCommand();
                command.Connection = konn.GetConn();
                command.Connection.Open();
                command.CommandType = CommandType.Text;
                command.CommandText = "DELETE FROM tbl_pompa WHERE id_pompa='" + id + "'";
                command.ExecuteNonQuery();
                command.Connection.Close();//pesan berhasil 
                MessageBox.Show("Data Berhasil Dihapus", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information); //memanggil tampil data 
                loadDaftar(); //memanggil bersih data 
                clear();
            }//if
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox1_idPompa.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox1_namaPompa.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox_namabbm.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                aturTombol(true, true);
                button4_simpan.Enabled = false;
            }//try 
            catch
            {
            }//catch
        }

        private void button_id_Click(object sender, EventArgs e)
        {
            Dialog_BBM bbm = new Dialog_BBM();
            Dialog_BBM.men = "pompa";
            bbm.pompa = this;
            bbm.ShowDialog();
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
                    command.CommandText = "SELECT * FROM tbl_pompa WHERE id_pompa LIKE'%" + textBox_cari.Text + "%' OR nama_pompa LIKE'%" + textBox_cari.Text + "%'";
                    SqlDataAdapter data = new SqlDataAdapter(command);
                    data.Fill(dts, "tbl_pompa");
                    dataGridView1.DataSource = dts;
                    dataGridView1.DataMember = "tbl_pompa";
                }//try
                catch (SqlException)
                {

                }//catch 
            }//else
        }
    }
}
