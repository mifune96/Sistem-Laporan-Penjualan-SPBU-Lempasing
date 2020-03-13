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
    public partial class Form_LOGIN : Form
    {
        private SqlDataReader dr;
        Kelas.Koneksi konn = new Kelas.Koneksi();
        public Form_LOGIN()
        {
            InitializeComponent();
        }
        void Bersih_Enable()
        {
            textBox_namaPengguna.Enabled = true;
            textBox_kataSandi.Enabled = true;
            textBox_namaPengguna.Clear();
            textBox_kataSandi.Clear();
            textBox_namaPengguna.Focus();
        }

        private void Form_LOGIN_Load(object sender, EventArgs e)
        {

        }

        private void button_masuk_Click(object sender, EventArgs e)
        {
            SqlConnection conn = konn.GetConn(); conn = konn.GetConn();

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_pengguna where nama_pengguna='" + textBox_namaPengguna.Text + "'and kata_sandi='" + textBox_kataSandi.Text + "'", conn);
                dr = cmd.ExecuteReader();
                int count = 0;
                while (dr.Read())
                {
                    count += 1;

                }
                if (count == 1)
                {
                    MessageBox.Show("Anda Berhasil Login!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //File Tool Strip Aktif
                    menuUtama.MenuUtama.fileToolStripMenuItem.Enabled = true;
                    menuUtama.MenuUtama.logOutToolStripMenuItem.Enabled = true;
                    menuUtama.MenuUtama.exitToolStripMenuItem.Enabled = true;

                    //Transaksi Tool Strip Aktif
                    menuUtama.MenuUtama.transaksiToolStripMenuItem.Enabled = true;
                    menuUtama.MenuUtama.transaksiToolStripMenuItem1.Enabled = true;

                    //Master Tool Strip Aktif
                    menuUtama.MenuUtama.masterToolStripMenuItem.Enabled = true;
                    menuUtama.MenuUtama.bBMToolStripMenuItem.Enabled = true;
                    menuUtama.MenuUtama.pOMPAToolStripMenuItem.Enabled = true;
                    menuUtama.MenuUtama.pENGELUARANToolStripMenuItem.Enabled = true;

                    //Laporan Tool Strip Aktif
                    menuUtama.MenuUtama.laporanToolStripMenuItem.Enabled = true;

                    this.Close();

                }

                else if ((textBox_namaPengguna.Text == "") && (textBox_kataSandi.Text == ""))
                {
                    MessageBox.Show("Harap isi Username dan Password terlebih dahulu !", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Bersih_Enable();
                    textBox_namaPengguna.Focus();
                }
                else if (textBox_namaPengguna.Text == "")
                {
                    MessageBox.Show("Harap isi Username terlebih dahulu !", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Bersih_Enable();
                    textBox_namaPengguna.Focus();
                }
                else if (textBox_kataSandi.Text == "")
                {
                    MessageBox.Show("Harap isi Password terlebih dahulu !", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Bersih_Enable();
                    textBox_namaPengguna.Focus();
                }

                else
                {
                    MessageBox.Show("Username / Password yang anda inputkan salah !", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Bersih_Enable();
                    textBox_namaPengguna.Focus();
                }
                conn.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString());
            }
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
