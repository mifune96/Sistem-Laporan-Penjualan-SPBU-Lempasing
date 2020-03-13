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
    public partial class Dialog_BBM : Form
    {
        Kelas.Koneksi konn = new Kelas.Koneksi();
        public Form_POMPA pompa = null;
        public Form_PENERIMAAN penerimaan = null;
        public Form_TRANSAKSI transaksi = null;
        public static string men;

        public Dialog_BBM()
        {
            InitializeComponent();
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
            dataGridView1.Columns[0].HeaderText = "Id BBM";
            dataGridView1.Columns[1].HeaderText = "Nama BBM";
            dataGridView1.Columns[2].HeaderText = "Harga";
        }//header
        public void loadDaftar()
        {
            DataSet data = getData();
            dataGridView1.DataSource = data;
            dataGridView1.DataMember = "tbl_bbm";
            header();
        }//loadDaftar

        private void Dialog_BBM_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (men == "penerimaan"){
                penerimaan.id_bbm_penerimaan = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                penerimaan.textBox_namaBbm_penerimaan.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                Dispose();

            }
            else if ( men == "pompa")
            {
                pompa.id_bbm_pompa = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                pompa.textBox_namabbm.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                Dispose();
            }
           // else if (men == "transaksi")
            //{
              //  transaksi.id_bbm_transaksi = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                //transaksi.textBox_namaBbm.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                //Dispose();
            //}
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
                    command.CommandText = "SELECT * FROM tbl_bbm WHERE id_bbm LIKE'%" + textBox_cari.Text + "%' OR nama_bbm LIKE'%" + textBox_cari.Text + "%'";
                    SqlDataAdapter data = new SqlDataAdapter(command);
                    data.Fill(dts, "tbl_bbm");
                    dataGridView1.DataSource = dts;
                    dataGridView1.DataMember = "tbl_bbm";
                }//try
                catch (SqlException)
                {

                }//catch 
            }//else
        }
    }
}
