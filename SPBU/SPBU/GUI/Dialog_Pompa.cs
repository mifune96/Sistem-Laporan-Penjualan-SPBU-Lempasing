using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System;

namespace SPBU.GUI
{
    public partial class Dialog_Pompa : Form
    {
        Kelas.Koneksi konn = new Kelas.Koneksi();
      //  public Form_TRANSAKSI transaksi = null;
        public static string pom;

        public Dialog_Pompa()
        {
            InitializeComponent();
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


        private void Dialog_Pompa_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*if(pom == "1"){
            transaksi.id_pompa1 = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            transaksi.textBox_pompa1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            Dispose();
            }
            else if (pom == "2")
            {
                transaksi.id_pompa2 = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                transaksi.textBox_pompa2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                Dispose();
            }
            else  if (pom == "3")
            {
                transaksi.id_pompa3 = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                transaksi.textBox_pompa3.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                Dispose();
            }
            else if (pom == "4")
            {
                transaksi.id_pompa4 = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                transaksi.textBox_pompa4.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                Dispose();
            }*/
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
                    command.CommandText = "SELECT * FROM vpompa WHERE id_pompa LIKE'%" + textBox_cari.Text + "%' OR nama_pompa LIKE'%" + textBox_cari.Text + "%'";
                    SqlDataAdapter data = new SqlDataAdapter(command);
                    data.Fill(dts, "vpompa");
                    dataGridView1.DataSource = dts;
                    dataGridView1.DataMember = "vpompa";
                }//try
                catch (SqlException)
                {

                }//catch 
            }//else
        }
    }
}
