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
    public partial class Form_TRANSAKSI : Form
    {

        Kelas.Koneksi konn = new Kelas.Koneksi();
        public String id_bbm_transaksi;
        Kelas.AutoNumber AutoNumber = new Kelas.AutoNumber();
        String id_transaksi_detail;
        long hargapertalite;
        long hargasolar;
        long hargapremium;
        long hargapertamax;

        public Form_TRANSAKSI()
        {
            InitializeComponent();
            clear();
            loadDaftar();
            //disabledCombo();
            isicombobox();
            try
            {
                textBox_idTransaksi.Text = AutoNumber.Auto("tbl_transaksi", "T", "id_transaksi");
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
                string sql = "SELECT * FROM vtransaksi"; SqlCommand command = new SqlCommand();
                command.Connection = konn.GetConn(); command.CommandType = CommandType.Text;
                command.CommandText = sql;
                SqlDataAdapter data = new SqlDataAdapter(command); data.Fill(dts, "vtransaksi");
            }//try

            catch (Exception e)
            {
                MessageBox.Show("get\n" + e.ToString());

            }//catch

            return dts;

        }//getData
        void header()
        {
            dataGridView_transaksi.Columns[0].HeaderText = "Id Transaksi";
            dataGridView_transaksi.Columns[1].HeaderText = "Tanggal Transaksi";
            dataGridView_transaksi.Columns[2].HeaderText = "Id Transaksi  Detail";
            dataGridView_transaksi.Columns[3].HeaderText = "Id Pompa";
            dataGridView_transaksi.Columns[4].HeaderText = "Nama Pompa";
            dataGridView_transaksi.Columns[5].HeaderText = "Id BBM";
            dataGridView_transaksi.Columns[6].HeaderText = "Nama BBM";
            dataGridView_transaksi.Columns[7].HeaderText = "Stand Meter Awal";
            dataGridView_transaksi.Columns[8].HeaderText = "Stand Meter Akhir";
            dataGridView_transaksi.Columns[9].HeaderText = "Harga";
            dataGridView_transaksi.Columns[10].HeaderText = "Total";
        }//header
        public void loadDaftar()
        {
            //hargapertalite
            SqlConnection sqlConnection = konn.GetConn();
            SqlCommand sqlCmd1 = new SqlCommand("SELECT harga FROM tbl_bbm WHERE id_bbm ='B-001'", sqlConnection);// ambil pertalite
            sqlConnection.Open();
            SqlDataReader sqlReader = sqlCmd1.ExecuteReader();

            while (sqlReader.Read())
            {
                hargapertalite = Convert.ToInt64(sqlReader[0].ToString());
            }
            sqlReader.Close();
            sqlConnection.Close();
            //hargasolar
            SqlCommand sqlCmd2 = new SqlCommand("SELECT harga FROM tbl_bbm WHERE id_bbm ='B-002'", sqlConnection);// ambil pertalite
            sqlConnection.Open();
            sqlReader = sqlCmd2.ExecuteReader();
            while (sqlReader.Read())
            {
                hargasolar = Convert.ToInt64(sqlReader[0].ToString());
            }
            sqlReader.Close();
            DataSet data = getData();
            dataGridView_transaksi.DataSource = data;
            dataGridView_transaksi.DataMember = "vtransaksi";
            header();
            sqlConnection.Close();
            //hargapremium
            SqlCommand sqlCmd3 = new SqlCommand("SELECT harga FROM tbl_bbm WHERE id_bbm ='B-003'", sqlConnection);// ambil pertalite
            sqlConnection.Open();
            sqlReader = sqlCmd3.ExecuteReader();

            while (sqlReader.Read())
            {
                hargapremium = Convert.ToInt64(sqlReader[0].ToString());
            }
            sqlConnection.Close();
            //hargapertamax
            SqlCommand sqlCmd4 = new SqlCommand("SELECT harga FROM tbl_bbm WHERE id_bbm ='B-004'", sqlConnection);// ambil pertalite
            sqlConnection.Open();
            sqlReader = sqlCmd4.ExecuteReader();
            while (sqlReader.Read())
            {
                hargapertamax = Convert.ToInt64(sqlReader[0].ToString());
            }

        }//loadDaftar

        public void disabledCombo()
        {
            long jumlahPertalite = 0, jumlahSolar = 0, jumlahPremium = 0, jumlahPertamax = 0;
            SqlConnection sqlConnection = konn.GetConn();
            SqlCommand sqlCmd = new SqlCommand("SELECT COUNT(*) FROM tbl_pompa WHERE id_bbm ='B-001'", sqlConnection);// ambil pertalite
            sqlConnection.Open();
            SqlDataReader sqlReader = sqlCmd.ExecuteReader();

            while (sqlReader.Read())
            {
                jumlahPertalite = Convert.ToInt64(sqlReader[0].ToString());
            }
            sqlReader.Close();


            sqlCmd = new SqlCommand("SELECT COUNT(*) FROM tbl_pompa WHERE id_bbm ='B-002'", sqlConnection);// ambil solar

            sqlReader = sqlCmd.ExecuteReader();

            while (sqlReader.Read())
            {
                jumlahSolar = Convert.ToInt64(sqlReader[0].ToString());
            }
            sqlReader.Close();

            sqlCmd = new SqlCommand("SELECT COUNT(*) FROM tbl_pompa WHERE id_bbm ='B-003'", sqlConnection);// ambil premium

            sqlReader = sqlCmd.ExecuteReader();

            while (sqlReader.Read())
            {
                jumlahPremium = Convert.ToInt64(sqlReader[0].ToString());
            }
            sqlReader.Close();

            sqlCmd = new SqlCommand("SELECT COUNT(*) FROM tbl_pompa WHERE id_bbm ='B-004'", sqlConnection);// ambil pertamax

            sqlReader = sqlCmd.ExecuteReader();

            while (sqlReader.Read())
            {
                jumlahPertamax = Convert.ToInt64(sqlReader[0].ToString());
            }
            sqlReader.Close();

            //pertalite
            if (jumlahPertalite == 0)
            {
                comboBox_namapompa_pertalite1.Enabled = false;
                comboBox_namapompa_pertalite2.Enabled = false;
                comboBox_namapompa_pertalite3.Enabled = false;
                comboBox_namapompa_pertalite4.Enabled = false;
            }
            else if (jumlahPertalite == 1)
            {
                comboBox_namapompa_pertalite1.Enabled = true;
                comboBox_namapompa_pertalite2.Enabled = false;
                comboBox_namapompa_pertalite3.Enabled = false;
                comboBox_namapompa_pertalite4.Enabled = false;
            }
            else if (jumlahPertalite == 2)
            {
                comboBox_namapompa_pertalite1.Enabled = true;
                comboBox_namapompa_pertalite2.Enabled = true;
                comboBox_namapompa_pertalite3.Enabled = false;
                comboBox_namapompa_pertalite4.Enabled = false;
            }
            else if (jumlahPertalite == 3)
            {
                comboBox_namapompa_pertalite1.Enabled = true;
                comboBox_namapompa_pertalite2.Enabled = true;
                comboBox_namapompa_pertalite3.Enabled = true;
                comboBox_namapompa_pertalite4.Enabled = false;
            }
            else if (jumlahPertalite == 4)
            {
                comboBox_namapompa_pertalite1.Enabled = true;
                comboBox_namapompa_pertalite2.Enabled = true;
                comboBox_namapompa_pertalite3.Enabled = true;
                comboBox_namapompa_pertalite4.Enabled = true;
            }

            //pertamax
            if (jumlahPertamax == 0)
            {
                comboBox_namapompa_pertamax1.Enabled = false;
                comboBox_namapompa_pertamax2.Enabled = false;
                comboBox_namapompa_pertamax3.Enabled = false;
                comboBox_namapompa_pertamax4.Enabled = false;
            }
            else if (jumlahPertamax == 1)
            {
                comboBox_namapompa_pertamax1.Enabled = true;
                comboBox_namapompa_pertamax2.Enabled = false;
                comboBox_namapompa_pertamax3.Enabled = false;
                comboBox_namapompa_pertamax4.Enabled = false;
            }

            else if (jumlahPertamax == 2)
            {
                comboBox_namapompa_pertamax1.Enabled = true;
                comboBox_namapompa_pertamax2.Enabled = true;
                comboBox_namapompa_pertamax3.Enabled = false;
                comboBox_namapompa_pertamax4.Enabled = false;
            }
            else if (jumlahPertamax == 3)
            {
                comboBox_namapompa_pertamax1.Enabled = true;
                comboBox_namapompa_pertamax2.Enabled = true;
                comboBox_namapompa_pertamax3.Enabled = true;
                comboBox_namapompa_pertamax4.Enabled = false;
            }
            else if (jumlahPertamax == 4)
            {
                comboBox_namapompa_pertamax1.Enabled = true;
                comboBox_namapompa_pertamax2.Enabled = true;
                comboBox_namapompa_pertamax3.Enabled = true;
                comboBox_namapompa_pertamax4.Enabled = true;
            }
            //premoium
            if (jumlahPremium == 0)
            {
                comboBox_namapompa_premium1.Enabled = false;
                comboBox_namapompa_premium2.Enabled = false;
                comboBox_namapompa_premium3.Enabled = false;
                comboBox_namapompa_premium4.Enabled = false;
            }
            else if (jumlahPremium == 1)
            {
                comboBox_namapompa_premium1.Enabled = true;
                comboBox_namapompa_premium2.Enabled = false;
                comboBox_namapompa_premium3.Enabled = false;
                comboBox_namapompa_premium4.Enabled = false;
            }
            else if (jumlahPremium == 2)
            {
                comboBox_namapompa_premium1.Enabled = true;
                comboBox_namapompa_premium2.Enabled = true;
                comboBox_namapompa_premium3.Enabled = false;
                comboBox_namapompa_premium4.Enabled = false;
            }
            else if (jumlahPremium == 3)
            {
                comboBox_namapompa_premium1.Enabled = true;
                comboBox_namapompa_premium2.Enabled = true;
                comboBox_namapompa_premium3.Enabled = true;
                comboBox_namapompa_premium4.Enabled = false;
            }
            else if (jumlahPremium == 4)
            {
                comboBox_namapompa_premium1.Enabled = true;
                comboBox_namapompa_premium2.Enabled = true;
                comboBox_namapompa_premium3.Enabled = true;
                comboBox_namapompa_premium4.Enabled = true;
            }
            //solar
            if (jumlahSolar == 0)
            {
                comboBox_namapompa_solat1.Enabled = false;
                comboBox_namapompa_solat2.Enabled = false;
                comboBox_namapompa_solat3.Enabled = false;
                comboBox_namapompa_solat4.Enabled = false;
            }
            else if (jumlahSolar == 1)
            {
                comboBox_namapompa_solat1.Enabled = true;
                comboBox_namapompa_solat2.Enabled = false;
                comboBox_namapompa_solat3.Enabled = false;
                comboBox_namapompa_solat4.Enabled = false;
            }
            else if (jumlahSolar == 2)
            {
                comboBox_namapompa_solat1.Enabled = true;
                comboBox_namapompa_solat2.Enabled = true;
                comboBox_namapompa_solat3.Enabled = false;
                comboBox_namapompa_solat4.Enabled = false;
            }
            else if (jumlahSolar == 3)
            {
                comboBox_namapompa_solat1.Enabled = true;
                comboBox_namapompa_solat2.Enabled = true;
                comboBox_namapompa_solat3.Enabled = true;
                comboBox_namapompa_solat4.Enabled = false;
            }
            else if (jumlahSolar == 4)
            {
                comboBox_namapompa_solat1.Enabled = true;
                comboBox_namapompa_solat2.Enabled = true;
                comboBox_namapompa_solat3.Enabled = true;
                comboBox_namapompa_solat4.Enabled = true;
            }


        }//disabledCombo

        public void isicombobox()
        {
            SqlConnection sqlConnection = konn.GetConn();
            SqlCommand sqlCmd = new SqlCommand("SELECT * FROM tbl_pompa WHERE id_bbm='B-001'", sqlConnection);// ambil pertalite
            sqlConnection.Open();
            SqlDataReader sqlReader = sqlCmd.ExecuteReader();

            while (sqlReader.Read())
            {
                comboBox_namapompa_pertalite1.Items.Add(sqlReader["nama_pompa"].ToString());
            }
            sqlReader.Close();

            sqlReader = sqlCmd.ExecuteReader();
            while (sqlReader.Read())
            {
                comboBox_namapompa_pertalite2.Items.Add(sqlReader["nama_pompa"].ToString());
            }
            sqlReader.Close();

            sqlReader = sqlCmd.ExecuteReader();
            while (sqlReader.Read())
            {
                comboBox_namapompa_pertalite3.Items.Add(sqlReader["nama_pompa"].ToString());
            }
            sqlReader.Close();

            sqlReader = sqlCmd.ExecuteReader();
            while (sqlReader.Read())
            {
                comboBox_namapompa_pertalite4.Items.Add(sqlReader["nama_pompa"].ToString());
            }
            sqlReader.Close();
            //solar

            sqlCmd = new SqlCommand("SELECT * FROM tbl_pompa WHERE id_bbm='B-002'", sqlConnection);// ambil solar
            sqlReader = sqlCmd.ExecuteReader();
            while (sqlReader.Read())
            {
                comboBox_namapompa_solat1.Items.Add(sqlReader["nama_pompa"].ToString());
            }
            sqlReader.Close();

            sqlReader = sqlCmd.ExecuteReader();
            while (sqlReader.Read())
            {
                comboBox_namapompa_solat2.Items.Add(sqlReader["nama_pompa"].ToString());
            }
            sqlReader.Close();

            sqlReader = sqlCmd.ExecuteReader();
            while (sqlReader.Read())
            {
                comboBox_namapompa_solat3.Items.Add(sqlReader["nama_pompa"].ToString());
            }
            sqlReader.Close();

            sqlReader = sqlCmd.ExecuteReader();
            while (sqlReader.Read())
            {
                comboBox_namapompa_solat4.Items.Add(sqlReader["nama_pompa"].ToString());
            }
            sqlReader.Close();

            //premium
            sqlCmd = new SqlCommand("SELECT * FROM tbl_pompa WHERE id_bbm='B-003'", sqlConnection);// ambil premium
            sqlReader = sqlCmd.ExecuteReader();
            while (sqlReader.Read())
            {
                comboBox_namapompa_premium1.Items.Add(sqlReader["nama_pompa"].ToString());
            }
            sqlReader.Close();

            sqlReader = sqlCmd.ExecuteReader();
            while (sqlReader.Read())
            {
                comboBox_namapompa_premium2.Items.Add(sqlReader["nama_pompa"].ToString());
            }
            sqlReader.Close();

            sqlReader = sqlCmd.ExecuteReader();
            while (sqlReader.Read())
            {
                comboBox_namapompa_premium3.Items.Add(sqlReader["nama_pompa"].ToString());
            }
            sqlReader.Close();

            sqlReader = sqlCmd.ExecuteReader();
            while (sqlReader.Read())
            {
                comboBox_namapompa_premium4.Items.Add(sqlReader["nama_pompa"].ToString());
            }
            sqlReader.Close();

            //pertamax
            sqlCmd = new SqlCommand("SELECT * FROM tbl_pompa WHERE id_bbm='B-004'", sqlConnection);// ambil pertamax
            sqlReader = sqlCmd.ExecuteReader();
            while (sqlReader.Read())
            {
                comboBox_namapompa_pertamax1.Items.Add(sqlReader["nama_pompa"].ToString());
            }
            sqlReader.Close();

            sqlReader = sqlCmd.ExecuteReader();
            while (sqlReader.Read())
            {
                comboBox_namapompa_pertamax2.Items.Add(sqlReader["nama_pompa"].ToString());
            }
            sqlReader.Close();

            sqlReader = sqlCmd.ExecuteReader();
            while (sqlReader.Read())
            {
                comboBox_namapompa_pertamax3.Items.Add(sqlReader["nama_pompa"].ToString());
            }
            sqlReader.Close();

            sqlReader = sqlCmd.ExecuteReader();
            while (sqlReader.Read())
            {
                comboBox_namapompa_pertamax4.Items.Add(sqlReader["nama_pompa"].ToString());
            }
            sqlReader.Close();
        }

        public void clear()
        {
            // textBox_idTransaksi.Clear();
            textBox_cari.Clear();
            //pertalite
            comboBox_namapompa_pertalite1.Enabled = false;
            comboBox_namapompa_pertalite2.Enabled = false;
            comboBox_namapompa_pertalite3.Enabled = false;
            comboBox_namapompa_pertalite4.Enabled = false;
            comboBox_namapompa_pertalite1.Text = "";
            comboBox_namapompa_pertalite2.Text = "";
            comboBox_namapompa_pertalite3.Text = "";
            comboBox_namapompa_pertalite4.Text = "";
            textBox_standAwalpertalitePompa1.Clear();
            textBox_standAwalpertalitePompa2.Clear();
            textBox_standAwalpertalitePompa3.Clear();
            textBox_standAwalpertalitePompa4.Clear();
            textBox_standAkhirPertalitePompa1.Clear();
            textBox_standAkhirPertalitePompa2.Clear();
            textBox_standAkhirPertalitePompa3.Clear();
            textBox_standAkhirPertalitePompa4.Clear();
            textBox_totalPertalitePompa1.Clear();
            textBox_totalPertalitePompa2.Clear();
            textBox_totalPertalitePompa3.Clear();
            textBox_totalPertalitePompa4.Clear();
            //pertamax
            comboBox_namapompa_pertamax1.Enabled = false;
            comboBox_namapompa_pertamax2.Enabled = false;
            comboBox_namapompa_pertamax3.Enabled = false;
            comboBox_namapompa_pertamax4.Enabled = false;
            comboBox_namapompa_pertamax1.Text = "";
            comboBox_namapompa_pertamax2.Text = "";
            comboBox_namapompa_pertamax3.Text = "";
            comboBox_namapompa_pertamax4.Text = "";
            textBox_standAwalPertamaxPompa1.Clear();
            textBox_standAwalPertamaxPompa2.Clear();
            textBox_standAwalPertamaxPompa3.Clear();
            textBox_standAwalPertamaxPompa4.Clear();
            textBox_standAkhirPertamaxPompa1.Clear();
            textBox_standAkhirPertamaxPompa2.Clear();
            textBox_standAkhirPertamaxPompa3.Clear();
            textBox_standAkhirPertamaxPompa4.Clear();
            textBox_totalPertamaxPompa1.Clear();
            textBox_totalPertamaxPompa2.Clear();
            textBox_totalPertamaxPompa3.Clear();
            textBox_totalPertamaxPompa4.Clear();
            //solar
            comboBox_namapompa_solat1.Enabled = false;
            comboBox_namapompa_solat2.Enabled = false;
            comboBox_namapompa_solat3.Enabled = false;
            comboBox_namapompa_solat4.Enabled = false;
            comboBox_namapompa_solat1.Text = "";
            comboBox_namapompa_solat2.Text = "";
            comboBox_namapompa_solat3.Text = "";
            comboBox_namapompa_solat4.Text = "";
            textBox_standAwalSolarPompa1.Clear();
            textBox_standAwalSolarPompa2.Clear();
            textBox_standAwalSolarPompa3.Clear();
            textBox_standAwalSolarPompa4.Clear();
            textBox_standAkhirSolarPompa1.Clear();
            textBox_standAkhirSolarPompa2.Clear();
            textBox_standAkhirSolarPompa3.Clear();
            textBox_standAkhirSolarPompa4.Clear();
            textBox_totalSolarPompa1.Clear();
            textBox_totalSolarPompa2.Clear();
            textBox_totalSolarPompa3.Clear();
            textBox_totalSolarPompa4.Clear();
            //premium
            comboBox_namapompa_premium1.Enabled = false;
            comboBox_namapompa_premium2.Enabled = false;
            comboBox_namapompa_premium3.Enabled = false;
            comboBox_namapompa_premium4.Enabled = false;
            comboBox_namapompa_premium1.Text = "";
            comboBox_namapompa_premium2.Text = "";
            comboBox_namapompa_premium3.Text = "";
            comboBox_namapompa_premium4.Text = "";
            textBox_standAwalPremiumPompa1.Clear();
            textBox_standAwalPremiumPompa2.Clear();
            textBox_standAwalPremiumPompa3.Clear();
            textBox_standAwalPremiumPompa4.Clear();
            textBox_standAkhirPremiumPompa1.Clear();
            textBox_standAkhirPremiumPompa2.Clear();
            textBox_standAkhirPremiumPompa3.Clear();
            textBox_standAkhirPremiumPompa4.Clear();
            textBox_totalPremiumPompa1.Clear();
            textBox_totalPremiumPompa2.Clear();
            textBox_totalPremiumPompa3.Clear();
            textBox_totalPremiumPompa4.Clear();

            aturTombol(false, false);
        }//clear
        public void aturTombol(bool param1, bool param2)
        {
            button_baru.Enabled = true;
            textBox_cari.Enabled = true;
            button_simpan.Enabled = param1;
            button_hapus.Enabled = param2;
            textBox_idTransaksi.Enabled = false;
            //pertalite
            comboBox_namapompa_pertalite1.Enabled = param1;
            comboBox_namapompa_pertalite2.Enabled = param1;
            comboBox_namapompa_pertalite3.Enabled = param1;
            comboBox_namapompa_pertalite4.Enabled = param1;
            textBox_standAwalpertalitePompa1.Enabled = false;
            textBox_standAwalpertalitePompa2.Enabled = false;
            textBox_standAwalpertalitePompa3.Enabled = false;
            textBox_standAwalpertalitePompa4.Enabled = false;
            textBox_standAkhirPertalitePompa1.Enabled = param1;
            textBox_standAkhirPertalitePompa2.Enabled = param1;
            textBox_standAkhirPertalitePompa3.Enabled = param1;
            textBox_standAkhirPertalitePompa4.Enabled = param1;
            textBox_totalPertalitePompa1.Enabled = false;
            textBox_totalPertalitePompa2.Enabled = false;
            textBox_totalPertalitePompa3.Enabled = false;
            textBox_totalPertalitePompa4.Enabled = false;
            //Pertamax
            comboBox_namapompa_pertamax1.Enabled = param1;
            comboBox_namapompa_pertamax2.Enabled = param1;
            comboBox_namapompa_pertamax3.Enabled = false;
            comboBox_namapompa_pertamax4.Enabled = false;
            textBox_standAwalPertamaxPompa1.Enabled = false;
            textBox_standAwalPertamaxPompa2.Enabled = false;
            textBox_standAwalPertamaxPompa3.Enabled = false;
            textBox_standAwalPertamaxPompa4.Enabled = false;
            textBox_standAkhirPertamaxPompa1.Enabled = param1;
            textBox_standAkhirPertamaxPompa2.Enabled = param1;
            textBox_standAkhirPertamaxPompa3.Enabled = param1;
            textBox_standAkhirPertamaxPompa4.Enabled = param1;
            textBox_totalPertamaxPompa1.Enabled = false;
            textBox_totalPertamaxPompa2.Enabled = false;
            textBox_totalPertamaxPompa3.Enabled = false;
            textBox_totalPertamaxPompa4.Enabled = false;
            //premium
            comboBox_namapompa_premium1.Enabled = param1;
            comboBox_namapompa_premium2.Enabled = param1;
            comboBox_namapompa_premium3.Enabled = false;
            comboBox_namapompa_premium4.Enabled = false;
            textBox_standAwalPremiumPompa1.Enabled = false;
            textBox_standAwalPremiumPompa2.Enabled = false;
            textBox_standAwalPremiumPompa3.Enabled = false;
            textBox_standAwalPremiumPompa4.Enabled = false;
            textBox_standAkhirPremiumPompa1.Enabled = param1;
            textBox_standAkhirPremiumPompa2.Enabled = param1;
            textBox_standAkhirPremiumPompa3.Enabled = false;
            textBox_standAkhirPremiumPompa4.Enabled = false;
            textBox_totalPremiumPompa1.Enabled = false;
            textBox_totalPremiumPompa2.Enabled = false;
            textBox_totalPremiumPompa3.Enabled = false;
            textBox_totalPremiumPompa4.Enabled = false;
            //solar
            comboBox_namapompa_solat1.Enabled = param1;
            comboBox_namapompa_solat2.Enabled = param1;
            comboBox_namapompa_solat3.Enabled = false;
            comboBox_namapompa_solat4.Enabled = false;
            textBox_standAwalSolarPompa1.Enabled = false;
            textBox_standAwalSolarPompa2.Enabled = false;
            textBox_standAwalSolarPompa3.Enabled = false;
            textBox_standAwalSolarPompa4.Enabled = false;
            textBox_standAkhirSolarPompa1.Enabled = param1;
            textBox_standAkhirSolarPompa2.Enabled = param1;
            textBox_standAkhirSolarPompa3.Enabled = false;
            textBox_standAkhirSolarPompa4.Enabled = false;
            textBox_totalSolarPompa1.Enabled = false;
            textBox_totalSolarPompa2.Enabled = false;
            textBox_totalSolarPompa3.Enabled = false;
            textBox_totalSolarPompa4.Enabled = false;

            dateTimePicker_tglTransaksi.Enabled = param2;
        }//aturTombol 
        string ambilidpompa(string namapompa)
        {
            string id = "";
            SqlConnection sqlConnection = konn.GetConn();
            SqlCommand sqlCmd = new SqlCommand("select id_pompa from tbl_pompa where nama_pompa = '" + namapompa + "'", sqlConnection);// ambil pertalite
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

        private void insertstok()
        {
            //pertalite
            long stockAwalPertalite = 0;
            long stockAkhirPertalite = 0;
            long penerimaanPertalite = 0;
            long pengeluaranPertalite = 0;
            SqlConnection sqlConnection = konn.GetConn();
            SqlCommand sqlCmd = new SqlCommand("SELECT jumlah_stok FROM tbl_stock WHERE id_bbm='B-001' and tgl_stok = (select max (tgl_stok)from tbl_stock)", sqlConnection);// ambil pertalite
            sqlConnection.Open();
            SqlDataReader sqlReader = sqlCmd.ExecuteReader();

            while (sqlReader.Read())
            {
                stockAwalPertalite = Convert.ToInt64(sqlReader["jumlah_stok"].ToString());
            }
            sqlReader.Close();
            sqlCmd = new SqlCommand("SELECT jumlah_penerimaan FROM tbl_penerimaan WHERE id_bbm='B-001' and tgl_penerimaan = (select max (tgl_penerimaan)from tbl_penerimaan)", sqlConnection);// ambil pertalite
            sqlConnection.Close();
            sqlConnection.Open();
            sqlReader = sqlCmd.ExecuteReader();

            while (sqlReader.Read())
            {
                penerimaanPertalite = Convert.ToInt64(sqlReader["jumlah_penerimaan"].ToString());
            }
            sqlReader.Close();
            sqlCmd = new SqlCommand("SELECT SUM(total) FROM vtransaksi WHERE id_bbm='B-001' and tgl_transaksi = (select max (tgl_transaksi)from vtransaksi)", sqlConnection);// ambil pertalite
            sqlConnection.Close();
            sqlConnection.Open();
            sqlReader = sqlCmd.ExecuteReader();

            while (sqlReader.Read())
            {
                pengeluaranPertalite = Convert.ToInt64(sqlReader[0].ToString());
            }
            sqlReader.Close();

            stockAkhirPertalite = stockAwalPertalite + penerimaanPertalite - pengeluaranPertalite;
            //pertamax
            long stockAwalPertamax = 0;
            long stockAkhirPertamax = 0;
            long penerimaanPertamax = 0;
            long pengeluaranPertamax = 0;
            sqlConnection = konn.GetConn();
            sqlCmd = new SqlCommand("SELECT jumlah_stok FROM tbl_stock WHERE id_bbm='B-004' and tgl_stok = (select max (tgl_stok)from tbl_stock)", sqlConnection);// ambil pertalite
            sqlConnection.Close();
            sqlConnection.Open();
            sqlReader = sqlCmd.ExecuteReader();

            while (sqlReader.Read())
            {
                stockAwalPertamax = Convert.ToInt64(sqlReader["jumlah_stok"].ToString());
            }
            sqlReader.Close();
            sqlCmd = new SqlCommand("SELECT jumlah_penerimaan FROM tbl_penerimaan WHERE id_bbm='B-004' and tgl_penerimaan = (select max (tgl_penerimaan)from tbl_penerimaan)", sqlConnection);// ambil pertalite
            sqlConnection.Close();
            sqlConnection.Open();
            sqlReader = sqlCmd.ExecuteReader();

            while (sqlReader.Read())
            {
                penerimaanPertamax = Convert.ToInt64(sqlReader["jumlah_penerimaan"].ToString());
            }
            sqlReader.Close();
            sqlCmd = new SqlCommand("SELECT SUM(total) FROM vtransaksi WHERE id_bbm='B-004' and tgl_transaksi = (select max (tgl_transaksi)from vtransaksi)", sqlConnection);// ambil pertalite
            sqlConnection.Close();
            sqlConnection.Open();
            sqlReader = sqlCmd.ExecuteReader();

            while (sqlReader.Read())
            {
                pengeluaranPertamax = Convert.ToInt64(sqlReader[0].ToString());
            }
            sqlReader.Close();

            stockAkhirPertamax = stockAwalPertamax + penerimaanPertamax - pengeluaranPertamax;
            //solar
            long stockAwalSolar = 0;
            long stockAkhirSolar = 0;
            long penerimaanSolar = 0;
            long pengeluaranSolar = 0;
            sqlConnection = konn.GetConn();
            sqlCmd = new SqlCommand("SELECT jumlah_stok FROM tbl_stock WHERE id_bbm='B-002' and tgl_stok = (select max (tgl_stok)from tbl_stock)", sqlConnection);// ambil pertalite
            sqlConnection.Close();
            sqlConnection.Open();
            sqlReader = sqlCmd.ExecuteReader();

            while (sqlReader.Read())
            {
                stockAwalSolar = Convert.ToInt64(sqlReader["jumlah_stok"].ToString());
            }
            sqlReader.Close();
            sqlCmd = new SqlCommand("SELECT jumlah_penerimaan FROM tbl_penerimaan WHERE id_bbm='B-002' and tgl_penerimaan = (select max (tgl_penerimaan)from tbl_penerimaan)", sqlConnection);// ambil pertalite
            sqlConnection.Close();
            sqlConnection.Open();
            sqlReader = sqlCmd.ExecuteReader();

            while (sqlReader.Read())
            {
                penerimaanSolar = Convert.ToInt64(sqlReader["jumlah_penerimaan"].ToString());
            }
            sqlReader.Close();
            sqlCmd = new SqlCommand("SELECT SUM(total) FROM vtransaksi WHERE id_bbm='B-002' and tgl_transaksi = (select max (tgl_transaksi)from vtransaksi)", sqlConnection);// ambil pertalite
            sqlConnection.Close();
            sqlConnection.Open();
            sqlReader = sqlCmd.ExecuteReader();

            while (sqlReader.Read())
            {
                pengeluaranSolar = Convert.ToInt64(sqlReader[0].ToString());
            }
            sqlReader.Close();

            stockAkhirSolar = stockAwalSolar + penerimaanSolar - pengeluaranSolar;
            //premium
            long stockAwalPremium = 0;
            long stockAkhirPremium = 0;
            long penerimaanPremium = 0;
            long pengeluaranPremium = 0;
            sqlConnection = konn.GetConn();
            sqlCmd = new SqlCommand("SELECT jumlah_stok FROM tbl_stock WHERE id_bbm='B-003' and tgl_stok = (select max (tgl_stok)from tbl_stock)", sqlConnection);// ambil pertalite
            sqlConnection.Close();
            sqlConnection.Open();
            sqlReader = sqlCmd.ExecuteReader();

            while (sqlReader.Read())
            {
                stockAwalPremium = Convert.ToInt64(sqlReader["jumlah_stok"].ToString());
            }
            sqlReader.Close();
            sqlCmd = new SqlCommand("SELECT jumlah_penerimaan FROM tbl_penerimaan WHERE id_bbm='B-003' and tgl_penerimaan = (select max (tgl_penerimaan)from tbl_penerimaan)", sqlConnection);// ambil pertalite
            sqlConnection.Close();
            sqlConnection.Open();
            sqlReader = sqlCmd.ExecuteReader();

            while (sqlReader.Read())
            {
                penerimaanPremium = Convert.ToInt64(sqlReader["jumlah_penerimaan"].ToString());
            }
            sqlReader.Close();
            sqlCmd = new SqlCommand("SELECT SUM(total) FROM vtransaksi WHERE id_bbm='B-003' and tgl_transaksi = (select max (tgl_transaksi)from vtransaksi)", sqlConnection);// ambil pertalite
            sqlConnection.Close();
            sqlConnection.Open();
            sqlReader = sqlCmd.ExecuteReader();

            while (sqlReader.Read())
            {
                pengeluaranPremium = Convert.ToInt64(sqlReader[0].ToString());
            }
            sqlReader.Close();
            stockAkhirPremium = stockAwalPremium + penerimaanPremium - pengeluaranPremium;
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = konn.GetConn();
                command.Connection.Open();
                command.CommandType = CommandType.Text;
                command.CommandText = "INSERT INTO tbl_stock VALUES ('B-001','" + Convert.ToDateTime(dateTimePicker_tglTransaksi.Value).ToString("yyyy-MM-dd") + "','" + stockAkhirPertalite + "')";
                command.ExecuteNonQuery();
                command.CommandText = "INSERT INTO tbl_stock VALUES ('B-002','" + Convert.ToDateTime(dateTimePicker_tglTransaksi.Value).ToString("yyyy-MM-dd") + "','" + stockAkhirSolar + "')";
                command.ExecuteNonQuery();
                command.CommandText = "INSERT INTO tbl_stock VALUES ('B-003','" + Convert.ToDateTime(dateTimePicker_tglTransaksi.Value).ToString("yyyy-MM-dd") + "','" + stockAkhirPremium + "')";
                command.ExecuteNonQuery();
                command.CommandText = "INSERT INTO tbl_stock VALUES ('B-004','" + Convert.ToDateTime(dateTimePicker_tglTransaksi.Value).ToString("yyyy-MM-dd") + "','" + stockAkhirPertamax + "')";
                command.ExecuteNonQuery();
                command.Connection.Close();
            }
            catch (SqlException h)
            {
                MessageBox.Show("Gagal Simpan Data\n" + h, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void insertcombobox()
        {
            //premium
            if (comboBox_namapompa_premium1.Text != "")
            {
                SqlCommand command = new SqlCommand();
                command.Connection = konn.GetConn();
                command.Connection.Open();
                command.CommandType = CommandType.Text;

                command.CommandText = "INSERT INTO tbl_transaksi_detail VALUES('" + textBox_idTransaksi.Text + "','" + ambilidpompa(comboBox_namapompa_premium1.Text) + "','B-003','" + textBox_standAwalPremiumPompa1.Text + "','" + textBox_standAkhirPremiumPompa1.Text + "','" + hargapremium + "')";
                command.ExecuteNonQuery();
                command.Connection.Close(); //pesan berhasil 
            }
            if (comboBox_namapompa_premium2.Text != "")
            {
                SqlCommand command = new SqlCommand();
                command.Connection = konn.GetConn();
                command.Connection.Open();
                command.CommandType = CommandType.Text;
                command.CommandText = "INSERT INTO tbl_transaksi_detail VALUES('" + textBox_idTransaksi.Text + "','" + ambilidpompa(comboBox_namapompa_premium2.Text) + "','B-003','" + textBox_standAwalPremiumPompa2.Text + "','" + textBox_standAkhirPremiumPompa2.Text + "','" + hargapremium + "')";
                command.ExecuteNonQuery();
                command.Connection.Close(); //pesan berhasil 
            }
            if (comboBox_namapompa_premium3.Text != "")
            {
                SqlCommand command = new SqlCommand();
                command.Connection = konn.GetConn();
                command.Connection.Open();
                command.CommandType = CommandType.Text;
                command.CommandText = "INSERT INTO tbl_transaksi_detail VALUES('" + textBox_idTransaksi.Text + "','" + ambilidpompa(comboBox_namapompa_premium3.Text) + "','B-003','" + textBox_standAwalPremiumPompa3.Text + "','" + textBox_standAkhirPremiumPompa3.Text + "','" + hargapremium + "')";
                command.ExecuteNonQuery();
                command.Connection.Close(); //pesan berhasil 
            }
            if (comboBox_namapompa_premium4.Text != "")
            {
                SqlCommand command = new SqlCommand();
                command.Connection = konn.GetConn();
                command.Connection.Open();
                command.CommandType = CommandType.Text;
                command.CommandText = "INSERT INTO tbl_transaksi_detail VALUES('" + textBox_idTransaksi.Text + "','" + ambilidpompa(comboBox_namapompa_premium1.Text) + "','B-003','" + textBox_standAwalPremiumPompa4.Text + "','" + textBox_standAkhirPremiumPompa4.Text + "','" + hargapremium + "')";
                command.ExecuteNonQuery();
                command.Connection.Close(); //pesan berhasil 
            }
            //pertamax
            if (comboBox_namapompa_pertamax1.Text != "")
            {
                SqlCommand command = new SqlCommand();
                command.Connection = konn.GetConn();
                command.Connection.Open();
                command.CommandType = CommandType.Text;

                command.CommandText = "INSERT INTO tbl_transaksi_detail VALUES('" + textBox_idTransaksi.Text + "','" + ambilidpompa(comboBox_namapompa_pertamax1.Text) + "','B-004','" + textBox_standAwalPertamaxPompa1.Text + "','" + textBox_standAkhirPertamaxPompa1.Text + "','" + hargapertamax + "')";
                command.ExecuteNonQuery();
                command.Connection.Close(); //pesan berhasil 
            } if (comboBox_namapompa_pertamax2.Text != "")
            {
                SqlCommand command = new SqlCommand();
                command.Connection = konn.GetConn();
                command.Connection.Open();
                command.CommandType = CommandType.Text;

                command.CommandText = "INSERT INTO tbl_transaksi_detail VALUES('" + textBox_idTransaksi.Text + "','" + ambilidpompa(comboBox_namapompa_pertamax2.Text) + "','B-004','" + textBox_standAwalPertamaxPompa2.Text + "','" + textBox_standAkhirPertamaxPompa2.Text + "','" + hargapertamax + "')";
                command.ExecuteNonQuery();
                command.Connection.Close(); //pesan berhasil 
            }
            if (comboBox_namapompa_pertamax3.Text != "")
            {
                SqlCommand command = new SqlCommand();
                command.Connection = konn.GetConn();
                command.Connection.Open();
                command.CommandType = CommandType.Text;

                command.CommandText = "INSERT INTO tbl_transaksi_detail VALUES('" + textBox_idTransaksi.Text + "','" + ambilidpompa(comboBox_namapompa_pertamax3.Text) + "','B-004','" + textBox_standAwalPertamaxPompa3.Text + "','" + textBox_standAkhirPertamaxPompa3.Text + "','" + hargapertamax + "')";
                command.ExecuteNonQuery();
                command.Connection.Close(); //pesan berhasil 
            }
            if (comboBox_namapompa_pertamax4.Text != "")
            {
                SqlCommand command = new SqlCommand();
                command.Connection = konn.GetConn();
                command.Connection.Open();
                command.CommandType = CommandType.Text;

                command.CommandText = "INSERT INTO tbl_transaksi_detail VALUES('" + textBox_idTransaksi.Text + "','" + ambilidpompa(comboBox_namapompa_pertamax4.Text) + "','B-004','" + textBox_standAwalPertamaxPompa4.Text + "','" + textBox_standAkhirPertamaxPompa4.Text + "','" + hargapertamax + "')";
                command.ExecuteNonQuery();
                command.Connection.Close(); //pesan berhasil 
            }
            //solar
            if (comboBox_namapompa_solat1.Text != "")
            {
                SqlCommand command = new SqlCommand();
                command.Connection = konn.GetConn();
                command.Connection.Open();
                command.CommandType = CommandType.Text;

                command.CommandText = "INSERT INTO tbl_transaksi_detail VALUES('" + textBox_idTransaksi.Text + "','" + ambilidpompa(comboBox_namapompa_solat1.Text) + "','B-002','" + textBox_standAwalSolarPompa1.Text + "','" + textBox_standAkhirSolarPompa1.Text + "','" + hargasolar + "')";
                command.ExecuteNonQuery();
                command.Connection.Close(); //pesan berhasil 
            }
            if (comboBox_namapompa_solat2.Text != "")
            {
                SqlCommand command = new SqlCommand();
                command.Connection = konn.GetConn();
                command.Connection.Open();
                command.CommandType = CommandType.Text;

                command.CommandText = "INSERT INTO tbl_transaksi_detail VALUES('" + textBox_idTransaksi.Text + "','" + ambilidpompa(comboBox_namapompa_solat2.Text) + "','B-002','" + textBox_standAwalSolarPompa2.Text + "','" + textBox_standAkhirSolarPompa2.Text + "','" + hargasolar + "')";
                command.ExecuteNonQuery();
                command.Connection.Close(); //pesan berhasil 
            }
            if (comboBox_namapompa_solat3.Text != "")
            {
                SqlCommand command = new SqlCommand();
                command.Connection = konn.GetConn();
                command.Connection.Open();
                command.CommandType = CommandType.Text;

                command.CommandText = "INSERT INTO tbl_transaksi_detail VALUES('" + textBox_idTransaksi.Text + "','" + ambilidpompa(comboBox_namapompa_solat3.Text) + "','B-002','" + textBox_standAwalSolarPompa3.Text + "','" + textBox_standAkhirSolarPompa3.Text + "','" + hargasolar + "')";
                command.ExecuteNonQuery();
                command.Connection.Close(); //pesan berhasil 
            }
            if (comboBox_namapompa_solat4.Text != "")
            {
                SqlCommand command = new SqlCommand();
                command.Connection = konn.GetConn();
                command.Connection.Open();
                command.CommandType = CommandType.Text;

                command.CommandText = "INSERT INTO tbl_transaksi_detail VALUES('" + textBox_idTransaksi.Text + "','" + ambilidpompa(comboBox_namapompa_solat4.Text) + "','B-002','" + textBox_standAwalSolarPompa4.Text + "','" + textBox_standAkhirSolarPompa4.Text + "','" + hargasolar + "')";
                command.ExecuteNonQuery();
                command.Connection.Close(); //pesan berhasil 
            }
            //pertalite
            if (comboBox_namapompa_pertalite1.Text != "")
            {
                SqlCommand command = new SqlCommand();
                command.Connection = konn.GetConn();
                command.Connection.Open();
                command.CommandType = CommandType.Text;

                command.CommandText = "INSERT INTO tbl_transaksi_detail VALUES('" + textBox_idTransaksi.Text + "','" + ambilidpompa(comboBox_namapompa_pertalite1.Text) + "','B-001','" + textBox_standAwalpertalitePompa1.Text + "','" + textBox_standAkhirPertalitePompa1.Text + "','" + hargapertalite + "')";
                command.ExecuteNonQuery();
                command.Connection.Close(); //pesan berhasil 
            }
            if (comboBox_namapompa_pertalite2.Text != "")
            {
                SqlCommand command = new SqlCommand();
                command.Connection = konn.GetConn();
                command.Connection.Open();
                command.CommandType = CommandType.Text;

                command.CommandText = "INSERT INTO tbl_transaksi_detail VALUES('" + textBox_idTransaksi.Text + "','" + ambilidpompa(comboBox_namapompa_pertalite2.Text) + "','B-001','" + textBox_standAwalpertalitePompa2.Text + "','" + textBox_standAkhirPertalitePompa2.Text + "','" + hargapertalite + "')";
                command.ExecuteNonQuery();
                command.Connection.Close(); //pesan berhasil 
            }
            if (comboBox_namapompa_pertalite3.Text != "")
            {
                SqlCommand command = new SqlCommand();
                command.Connection = konn.GetConn();
                command.Connection.Open();
                command.CommandType = CommandType.Text;

                command.CommandText = "INSERT INTO tbl_transaksi_detail VALUES('" + textBox_idTransaksi.Text + "','" + ambilidpompa(comboBox_namapompa_pertalite3.Text) + "','B-001','" + textBox_standAwalpertalitePompa3.Text + "','" + textBox_standAkhirPertalitePompa3.Text + "','" + hargapertalite + "')";
                command.ExecuteNonQuery();
                command.Connection.Close(); //pesan berhasil 
            }
            if (comboBox_namapompa_pertalite4.Text != "")
            {
                SqlCommand command = new SqlCommand();
                command.Connection = konn.GetConn();
                command.Connection.Open();
                command.CommandType = CommandType.Text;

                command.CommandText = "INSERT INTO tbl_transaksi_detail VALUES('" + textBox_idTransaksi.Text + "','" + ambilidpompa(comboBox_namapompa_pertalite4.Text) + "','B-001','" + textBox_standAwalpertalitePompa4.Text + "','" + textBox_standAkhirPertalitePompa4.Text + "','" + hargapertalite + "')";
                command.ExecuteNonQuery();
                command.Connection.Close(); //pesan berhasil 
            }
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form_TRANSAKSI_Load(object sender, EventArgs e)
        {

        }

        private void button_baru_Click(object sender, EventArgs e)
        {
            textBox_idTransaksi.Text = AutoNumber.Auto("tbl_transaksi", "T", "id_transaksi");
            clear();
            aturTombol(true, false);
            disabledCombo();
        }

        private void button_hapus_Click(object sender, EventArgs e)
        {
            string id = textBox_idTransaksi.Text;
            DialogResult akses = MessageBox.Show("Apakah data Ini akan dihapus??", "Informasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (akses == DialogResult.Yes)
            { //askes ke  controller 

                SqlCommand command = new SqlCommand();
                command.Connection = konn.GetConn();
                command.Connection.Open();
                command.CommandType = CommandType.Text;
                command.CommandText = "DELETE FROM tbl_transaksi_detail WHERE id_transaksi='" + id + "'";
                command.ExecuteNonQuery();
                command.Connection.Close();//pesan berhasil 
                command.Connection.Open();
                command.CommandType = CommandType.Text;
                command.CommandText = "DELETE FROM tbl_transaksi WHERE id_transaksi='" + id + "'";
                command.ExecuteNonQuery();
                command.Connection.Close();//pesan berhasil 
                command.Connection.Open();
                command.CommandType = CommandType.Text;
                command.CommandText = "DELETE FROM tbl_stock WHERE tgl_stok='" + Convert.ToDateTime(dateTimePicker_tglTransaksi.Value).ToString("yyyy-MM-dd") + "'";
                command.ExecuteNonQuery();
                command.Connection.Close();//pesan berhasil 
                MessageBox.Show("Data Berhasil Dihapus", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information); //memanggil tampil data 
                loadDaftar(); //memanggil bersih data 
                clear();
            }//if
        }

        private void dataGridView_transaksi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox_idTransaksi.Text = dataGridView_transaksi.Rows[e.RowIndex].Cells[0].Value.ToString();
                dateTimePicker_tglTransaksi.Text = dataGridView_transaksi.Rows[e.RowIndex].Cells[1].Value.ToString();
                id_transaksi_detail = dataGridView_transaksi.Rows[e.RowIndex].Cells[2].Value.ToString();
                //3 id pompa
                // textBox_pompa1.Text = dataGridView_transaksi.Rows[e.RowIndex].Cells[4].Value.ToString();
                //5 id bbm
                //textBox_namaBbm.Text = dataGridView_transaksi.Rows[e.RowIndex].Cells[6].Value.ToString();
                textBox_standAwalpertalitePompa1.Text = dataGridView_transaksi.Rows[e.RowIndex].Cells[7].Value.ToString();
                textBox_standAkhirPertalitePompa1.Text = dataGridView_transaksi.Rows[e.RowIndex].Cells[8].Value.ToString();
                //9 harga
                textBox_totalPertalitePompa1.Text = dataGridView_transaksi.Rows[e.RowIndex].Cells[10].Value.ToString();
                aturTombol(true, true);
                button_simpan.Enabled = false;
            }//try 
            catch
            {
            }//catch
        }

        private void button_simpan_Click(object sender, EventArgs e)
        {
            if (textBox_standAkhirPertalitePompa1.Text == "" || textBox_standAkhirPertalitePompa2.Text == "" || textBox_standAkhirPertalitePompa3.Text == "" || textBox_standAkhirPertalitePompa4.Text == "" || textBox_standAwalpertalitePompa1.Text == "" || textBox_standAwalpertalitePompa2.Text == "" || textBox_standAwalpertalitePompa3.Text == "" || textBox_standAwalpertalitePompa4.Text == "" || textBox_totalPertalitePompa1.Text == "" || textBox_totalPertalitePompa2.Text == "" || textBox_totalPertalitePompa3.Text == "" || textBox_totalPertalitePompa4.Text == "" || comboBox_namapompa_pertalite1.Text == "" || comboBox_namapompa_pertalite2.Text == "" || comboBox_namapompa_pertalite3.Text == "" || comboBox_namapompa_pertalite4.Text == "" ||
               textBox_standAkhirPertamaxPompa1.Text == "" || textBox_standAkhirPertamaxPompa2.Text == "" || textBox_standAkhirPertamaxPompa3.Text == "" || textBox_standAkhirPertamaxPompa4.Text == ""
               || textBox_standAwalPertamaxPompa1.Text == "" || textBox_standAwalPertamaxPompa2.Text == "" || textBox_standAwalPertamaxPompa3.Text == "" || textBox_standAwalPertamaxPompa4.Text == ""
               || textBox_totalPertalitePompa1.Text == "" || textBox_totalPertalitePompa2.Text == "" || textBox_totalPertalitePompa3.Text == "" || textBox_totalPertalitePompa4.Text == ""
               || comboBox_namapompa_pertamax1.Text == "" || comboBox_namapompa_pertamax2.Text == "" || comboBox_namapompa_pertamax3.Text == "" || comboBox_namapompa_pertamax4.Text == "" ||

               textBox_standAkhirPremiumPompa1.Text == "" || textBox_standAkhirPremiumPompa2.Text == ""
               || textBox_standAwalPremiumPompa1.Text == "" || textBox_standAwalPremiumPompa2.Text == ""
               || textBox_totalPremiumPompa1.Text == "" || textBox_totalPremiumPompa2.Text == ""
               || comboBox_namapompa_premium1.Text == "" || comboBox_namapompa_premium2.Text == "" ||
               textBox_standAkhirSolarPompa1.Text == "" || textBox_standAkhirSolarPompa2.Text == ""
               || textBox_standAwalSolarPompa1.Text == "" || textBox_standAwalSolarPompa2.Text == ""
               || textBox_totalPremiumPompa1.Text == "" || textBox_totalPremiumPompa2.Text == ""
               || comboBox_namapompa_solat1.Text == "" || comboBox_namapompa_solat2.Text == "")
            {
                MessageBox.Show("Data Harus Di Isi !!!");
            }
            else
            {
                try
                {
                    textBox_idTransaksi.Text = AutoNumber.Auto("tbl_transaksi", "T", "id_transaksi");
                    SqlCommand command = new SqlCommand();
                    command.Connection = konn.GetConn();
                    command.Connection.Open();
                    command.CommandType = CommandType.Text;
                    command.CommandText = "INSERT INTO tbl_transaksi VALUES('" + textBox_idTransaksi.Text + "','" + Convert.ToDateTime(dateTimePicker_tglTransaksi.Value).ToString("yyyy-MM-dd") + "')";
                    command.ExecuteNonQuery();
                    command.Connection.Close(); //pesan berhasil 
                    insertcombobox();
                    insertstok();
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
        private void comboBox_namapompa_pertalite1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = konn.GetConn();
            SqlCommand sqlli = new SqlCommand("select stand_meter_akhir from vtransaksi where nama_pompa = '" + comboBox_namapompa_pertalite1.Text + "' and tgl_transaksi = (select max (tgl_transaksi)from vtransaksi)", sqlConnection);// ambil pertalite
            sqlConnection.Open();
            SqlDataReader sqlReader = sqlli.ExecuteReader();
            textBox_standAwalpertalitePompa1.Text = "0";
            while (sqlReader.Read())
            {
                textBox_standAwalpertalitePompa1.Text = (sqlReader["stand_meter_akhir"].ToString());
            }
            sqlReader.Close();

        }

        private void comboBox_namapompa_pertalite2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = konn.GetConn();
            SqlCommand sqlli = new SqlCommand("select stand_meter_akhir from vtransaksi where nama_pompa = '" + comboBox_namapompa_pertalite2.Text + "' and tgl_transaksi = (select max (tgl_transaksi)from vtransaksi)", sqlConnection);// ambil pertalite
            sqlConnection.Open();
            SqlDataReader sqlReader = sqlli.ExecuteReader();
            textBox_standAwalpertalitePompa2.Text = "0";
            while (sqlReader.Read())
            {
                textBox_standAwalpertalitePompa2.Text = (sqlReader["stand_meter_akhir"].ToString());
            }
            sqlReader.Close();

        }

        private void comboBox_namapompa_pertalite3_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = konn.GetConn();
            SqlCommand sqlli = new SqlCommand("select stand_meter_akhir from vtransaksi where nama_pompa = '" + comboBox_namapompa_pertalite3.Text + "' and tgl_transaksi = (select max (tgl_transaksi)from vtransaksi)", sqlConnection);// ambil pertalite
            sqlConnection.Open();
            SqlDataReader sqlReader = sqlli.ExecuteReader();
            textBox_standAwalpertalitePompa3.Text = "0";
            while (sqlReader.Read())
            {
                textBox_standAwalpertalitePompa3.Text = (sqlReader["stand_meter_akhir"].ToString());
            }
            sqlReader.Close();

        }

        private void comboBox_namapompa_pertalite4_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = konn.GetConn();
            SqlCommand sqlli = new SqlCommand("select stand_meter_akhir from vtransaksi where nama_pompa = '" + comboBox_namapompa_pertalite4.Text + "' and tgl_transaksi = (select max (tgl_transaksi)from vtransaksi)", sqlConnection);// ambil pertalite
            sqlConnection.Open();
            SqlDataReader sqlReader = sqlli.ExecuteReader();
            textBox_standAwalpertalitePompa4.Text = "0";
            while (sqlReader.Read())
            {
                textBox_standAwalpertalitePompa4.Text = (sqlReader["stand_meter_akhir"].ToString());
            }
            sqlReader.Close();

        }

        private void comboBox_namapompa_solat1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = konn.GetConn();
            SqlCommand sqlli = new SqlCommand("select stand_meter_akhir from vtransaksi where nama_pompa = '" + comboBox_namapompa_solat1.Text + "' and tgl_transaksi = (select max (tgl_transaksi)from vtransaksi)", sqlConnection);// ambil pertalite
            sqlConnection.Open();
            SqlDataReader sqlReader = sqlli.ExecuteReader();
            textBox_standAwalSolarPompa1.Text = "0";
            while (sqlReader.Read())
            {
                textBox_standAwalSolarPompa1.Text = (sqlReader["stand_meter_akhir"].ToString());
            }
            sqlReader.Close();

        }

        private void comboBox_namapompa_solat2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = konn.GetConn();
            SqlCommand sqlli = new SqlCommand("select stand_meter_akhir from vtransaksi where nama_pompa = '" + comboBox_namapompa_solat2.Text + "' and tgl_transaksi = (select max (tgl_transaksi)from vtransaksi)", sqlConnection);// ambil pertalite
            sqlConnection.Open();
            SqlDataReader sqlReader = sqlli.ExecuteReader();
            textBox_standAwalSolarPompa2.Text = "0";
            while (sqlReader.Read())
            {
                textBox_standAwalSolarPompa2.Text = (sqlReader["stand_meter_akhir"].ToString());
            }
            sqlReader.Close();
        }

        private void comboBox_namapompa_premium1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = konn.GetConn();
            SqlCommand sqlli = new SqlCommand("select stand_meter_akhir from vtransaksi where nama_pompa = '" + comboBox_namapompa_premium1.Text + "' and tgl_transaksi = (select max (tgl_transaksi)from vtransaksi)", sqlConnection);// ambil pertalite
            sqlConnection.Open();
            SqlDataReader sqlReader = sqlli.ExecuteReader();
            textBox_standAwalPremiumPompa1.Text = "0";
            while (sqlReader.Read())
            {
                textBox_standAwalPremiumPompa1.Text = (sqlReader["stand_meter_akhir"].ToString());
            }
            sqlReader.Close();
        }

        private void comboBox_namapompa_premium2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = konn.GetConn();
            SqlCommand sqlli = new SqlCommand("select stand_meter_akhir from vtransaksi where nama_pompa = '" + comboBox_namapompa_premium2.Text + "' and tgl_transaksi = (select max (tgl_transaksi)from vtransaksi)", sqlConnection);// ambil pertalite
            sqlConnection.Open();
            SqlDataReader sqlReader = sqlli.ExecuteReader();
            textBox_standAwalPremiumPompa2.Text = "0";
            while (sqlReader.Read())
            {
                textBox_standAwalPremiumPompa2.Text = (sqlReader["stand_meter_akhir"].ToString());
            }
            sqlReader.Close();
        }

        private void comboBox_namapompa_pertamax1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = konn.GetConn();
            SqlCommand sqlli = new SqlCommand("select stand_meter_akhir from vtransaksi where nama_pompa = '" + comboBox_namapompa_pertamax1.Text + "' and tgl_transaksi = (select max (tgl_transaksi)from vtransaksi)", sqlConnection);// ambil pertalite
            sqlConnection.Open();
            SqlDataReader sqlReader = sqlli.ExecuteReader();
            textBox_standAwalPertamaxPompa1.Text = "0";
            while (sqlReader.Read())
            {
                textBox_standAwalPertamaxPompa1.Text = (sqlReader["stand_meter_akhir"].ToString());
            }
            sqlReader.Close();
        }

        private void comboBox_namapompa_pertamax2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = konn.GetConn();
            SqlCommand sqlli = new SqlCommand("select stand_meter_akhir from vtransaksi where nama_pompa = '" + comboBox_namapompa_pertamax2.Text + "' and tgl_transaksi = (select max (tgl_transaksi)from vtransaksi)", sqlConnection);// ambil pertalite
            sqlConnection.Open();
            SqlDataReader sqlReader = sqlli.ExecuteReader();
            textBox_standAwalPertamaxPompa2.Text = "0";
            while (sqlReader.Read())
            {
                textBox_standAwalPertamaxPompa2.Text = (sqlReader["stand_meter_akhir"].ToString());
            }
            sqlReader.Close();
        }

        private void comboBox_namapompa_pertamax3_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = konn.GetConn();
            SqlCommand sqlli = new SqlCommand("select stand_meter_akhir from vtransaksi where nama_pompa = '" + comboBox_namapompa_pertamax3.Text + "' and tgl_transaksi = (select max (tgl_transaksi)from vtransaksi)", sqlConnection);// ambil pertalite
            sqlConnection.Open();
            SqlDataReader sqlReader = sqlli.ExecuteReader();
            textBox_standAwalPertamaxPompa3.Text = "0";
            while (sqlReader.Read())
            {
                textBox_standAwalPertamaxPompa3.Text = (sqlReader["stand_meter_akhir"].ToString());
            }
            sqlReader.Close();
        }

        private void comboBox_namapompa_pertamax4_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = konn.GetConn();
            SqlCommand sqlli = new SqlCommand("select stand_meter_akhir from vtransaksi where nama_pompa = '" + comboBox_namapompa_pertamax4.Text + "' and tgl_transaksi = (select max (tgl_transaksi)from vtransaksi)", sqlConnection);// ambil pertalite
            sqlConnection.Open();
            SqlDataReader sqlReader = sqlli.ExecuteReader();
            textBox_standAwalPertamaxPompa4.Text = "0";
            while (sqlReader.Read())
            {
                textBox_standAwalPertamaxPompa4.Text = (sqlReader["stand_meter_akhir"].ToString());
            }
            sqlReader.Close();
        }

        private void textBox_standAkhirPertalitePompa1_TextChanged(object sender, EventArgs e)
        {
            if (textBox_standAkhirPertalitePompa1.Text == "")
            {
                loadDaftar();
            }//if
            else
            {
                DataSet dts = new DataSet();
                try
                {
                    long total = 0;
                    total = Convert.ToInt64(textBox_standAkhirPertalitePompa1.Text) - Convert.ToInt64(textBox_standAwalpertalitePompa1.Text);
                    if (total >= 0)
                    {
                        textBox_totalPertalitePompa1.Text = total.ToString();
                    }

                }//try
                catch (SqlException)
                {

                }//catch 
            }//else
        }

        private void textBox_standAkhirPertalitePompa2_TextChanged(object sender, EventArgs e)
        {
            if (textBox_standAkhirPertalitePompa2.Text == "")
            {
                loadDaftar();
            }//if
            else
            {
                DataSet dts = new DataSet();
                try
                {
                    long total = 0;
                    total = Convert.ToInt64(textBox_standAkhirPertalitePompa2.Text) - Convert.ToInt64(textBox_standAwalpertalitePompa2.Text);
                    if (total >= 0)
                    {
                        textBox_totalPertalitePompa2.Text = total.ToString();
                    }

                }//try
                catch (SqlException)
                {

                }//catch 
            }//else
        }

        private void textBox_standAkhirPertalitePompa3_TextChanged(object sender, EventArgs e)
        {
            if (textBox_standAkhirPertalitePompa3.Text == "")
            {
                loadDaftar();
            }//if
            else
            {
                DataSet dts = new DataSet();
                try
                {
                    long total = 0;
                    total = Convert.ToInt64(textBox_standAkhirPertalitePompa3.Text) - Convert.ToInt64(textBox_standAwalpertalitePompa3.Text);
                    if (total >= 0)
                    {
                        textBox_totalPertalitePompa3.Text = total.ToString();
                    }

                }//try
                catch (SqlException)
                {

                }//catch 
            }//else
        }

        private void textBox_standAkhirPertalitePompa4_TextChanged(object sender, EventArgs e)
        {
            if (textBox_standAkhirPertalitePompa4.Text == "")
            {
                loadDaftar();
            }//if
            else
            {
                DataSet dts = new DataSet();
                try
                {
                    long total = 0;
                    total = Convert.ToInt64(textBox_standAkhirPertalitePompa4.Text) - Convert.ToInt64(textBox_standAwalpertalitePompa4.Text);
                    if (total >= 0)
                    {
                        textBox_totalPertalitePompa4.Text = total.ToString();
                    }

                }//try
                catch (SqlException)
                {

                }//catch 
            }//else
        }

        private void textBox_standAkhirSolarPompa1_TextChanged(object sender, EventArgs e)
        {
            if (textBox_standAkhirSolarPompa1.Text == "")
            {
                loadDaftar();
            }//if
            else
            {
                DataSet dts = new DataSet();
                try
                {
                    long total = 0;
                    total = Convert.ToInt64(textBox_standAkhirSolarPompa1.Text) - Convert.ToInt64(textBox_standAwalSolarPompa1.Text);
                    if (total >= 0)
                    {
                        textBox_totalSolarPompa1.Text = total.ToString();
                    }

                }//try
                catch (SqlException)
                {

                }//catch 
            }//else
        }

        private void textBox_standAkhirSolarPompa2_TextChanged(object sender, EventArgs e)
        {
            if (textBox_standAkhirSolarPompa2.Text == "")
            {
                loadDaftar();
            }//if
            else
            {
                DataSet dts = new DataSet();
                try
                {
                    long total = 0;
                    total = Convert.ToInt64(textBox_standAkhirSolarPompa2.Text) - Convert.ToInt64(textBox_standAwalSolarPompa2.Text);
                    if (total >= 0)
                    {
                        textBox_totalSolarPompa2.Text = total.ToString();
                    }

                }//try
                catch (SqlException)
                {

                }//catch 
            }//else
        }

        private void textBox_standAkhirSolarPompa3_TextChanged(object sender, EventArgs e)
        {
            if (textBox_standAkhirSolarPompa3.Text == "")
            {
                loadDaftar();
            }//if
            else
            {
                DataSet dts = new DataSet();
                try
                {
                    long total = 0;
                    total = Convert.ToInt64(textBox_standAkhirSolarPompa3.Text) - Convert.ToInt64(textBox_standAwalSolarPompa3.Text);
                    if (total >= 0)
                    {
                        textBox_totalSolarPompa3.Text = total.ToString();
                    }

                }//try
                catch (SqlException)
                {

                }//catch 
            }//else
        }

        private void textBox_standAkhirSolarPompa4_TextChanged(object sender, EventArgs e)
        {
            if (textBox_standAkhirSolarPompa4.Text == "")
            {
                loadDaftar();
            }//if
            else
            {
                DataSet dts = new DataSet();
                try
                {
                    long total = 0;
                    total = Convert.ToInt64(textBox_standAkhirSolarPompa4.Text) - Convert.ToInt64(textBox_standAwalSolarPompa4.Text);
                    if (total >= 0)
                    {
                        textBox_totalSolarPompa4.Text = total.ToString();
                    }

                }//try
                catch (SqlException)
                {

                }//catch 
            }//else
        }

        private void textBox_standAwalPremiumPompa1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_standAkhirPremiumPompa1_TextChanged(object sender, EventArgs e)
        {
            if (textBox_standAkhirPremiumPompa1.Text == "")
            {
                loadDaftar();
            }//if
            else
            {
                DataSet dts = new DataSet();
                try
                {
                    long total = 0;
                    total = Convert.ToInt64(textBox_standAkhirPremiumPompa1.Text) - Convert.ToInt64(textBox_standAwalPremiumPompa1.Text);
                    if (total >= 0)
                    {
                        textBox_totalPremiumPompa1.Text = total.ToString();
                    }

                }//try
                catch (SqlException)
                {

                }//catch 
            }//else
        }

        private void textBox_standAkhirPremiumPompa2_TextChanged(object sender, EventArgs e)
        {
            if (textBox_standAkhirPremiumPompa2.Text == "")
            {
                loadDaftar();
            }//if
            else
            {
                DataSet dts = new DataSet();
                try
                {
                    long total = 0;
                    total = Convert.ToInt64(textBox_standAkhirPremiumPompa2.Text) - Convert.ToInt64(textBox_standAwalPremiumPompa2.Text);
                    if (total >= 0)
                    {
                        textBox_totalPremiumPompa2.Text = total.ToString();
                    }

                }//try
                catch (SqlException)
                {

                }//catch 
            }//else
        }

        private void textBox_standAkhirPremiumPompa3_TextChanged(object sender, EventArgs e)
        {
            if (textBox_standAkhirPremiumPompa3.Text == "")
            {
                loadDaftar();
            }//if
            else
            {
                DataSet dts = new DataSet();
                try
                {
                    long total = 0;
                    total = Convert.ToInt64(textBox_standAkhirPremiumPompa3.Text) - Convert.ToInt64(textBox_standAwalPremiumPompa3.Text);
                    if (total >= 0)
                    {
                        textBox_totalPremiumPompa3.Text = total.ToString();
                    }

                }//try
                catch (SqlException)
                {

                }//catch 
            }//else
        }

        private void textBox_standAkhirPremiumPompa4_TextChanged(object sender, EventArgs e)
        {
            if (textBox_standAkhirPremiumPompa4.Text == "")
            {
                loadDaftar();
            }//if
            else
            {
                DataSet dts = new DataSet();
                try
                {
                    long total = 0;
                    total = Convert.ToInt64(textBox_standAkhirPremiumPompa4.Text) - Convert.ToInt64(textBox_standAwalPremiumPompa4.Text);
                    if (total >= 0)
                    {
                        textBox_totalPremiumPompa4.Text = total.ToString();
                    }

                }//try
                catch (SqlException)
                {

                }//catch 
            }//else
        }

        private void textBox_standAkhirPertamaxPompa1_TextChanged(object sender, EventArgs e)
        {
            if (textBox_standAkhirPertamaxPompa1.Text == "")
            {
                loadDaftar();
            }//if
            else
            {
                DataSet dts = new DataSet();
                try
                {
                    long total = 0;
                    total = Convert.ToInt64(textBox_standAkhirPertamaxPompa1.Text) - Convert.ToInt64(textBox_standAwalPertamaxPompa1.Text);
                    if (total >= 0)
                    {
                        textBox_totalPertamaxPompa1.Text = total.ToString();
                    }

                }//try
                catch (SqlException)
                {

                }//catch 
            }//else
        }

        private void textBox_standAkhirPertamaxPompa2_TextChanged(object sender, EventArgs e)
        {
            if (textBox_standAkhirPertamaxPompa2.Text == "")
            {
                loadDaftar();
            }//if
            else
            {
                DataSet dts = new DataSet();
                try
                {
                    long total = 0;
                    total = Convert.ToInt64(textBox_standAkhirPertamaxPompa2.Text) - Convert.ToInt64(textBox_standAwalPertamaxPompa2.Text);
                    if (total >= 0)
                    {
                        textBox_totalPertamaxPompa2.Text = total.ToString();
                    }

                }//try
                catch (SqlException)
                {

                }//catch 
            }//else
        }

        private void textBox_standAkhirPertamaxPompa3_TextChanged(object sender, EventArgs e)
        {
            if (textBox_standAkhirPertamaxPompa3.Text == "")
            {
                loadDaftar();
            }//if
            else
            {
                DataSet dts = new DataSet();
                try
                {
                    long total = 0;
                    total = Convert.ToInt64(textBox_standAkhirPertamaxPompa3.Text) - Convert.ToInt64(textBox_standAwalPertamaxPompa3.Text);
                    if (total >= 0)
                    {
                        textBox_totalPertamaxPompa3.Text = total.ToString();
                    }

                }//try
                catch (SqlException)
                {

                }//catch 
            }//else
        }

        private void textBox_standAkhirPertamaxPompa4_TextChanged(object sender, EventArgs e)
        {
            if (textBox_standAkhirPertamaxPompa4.Text == "")
            {
                loadDaftar();
            }//if
            else
            {
                DataSet dts = new DataSet();
                try
                {
                    long total = 0;
                    total = Convert.ToInt64(textBox_standAkhirPertamaxPompa4.Text) - Convert.ToInt64(textBox_standAwalPertamaxPompa4.Text);
                    if (total >= 0)
                    {
                        textBox_totalPertamaxPompa4.Text = total.ToString();
                    }

                }//try
                catch (SqlException)
                {

                }//catch 
            }//else
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
                    command.CommandText = "SELECT * FROM vtransaksi WHERE id_transaksi LIKE'%" + textBox_cari.Text + "%' OR nama_pompa LIKE'%" + textBox_cari.Text + "%'";
                    SqlDataAdapter data = new SqlDataAdapter(command);
                    data.Fill(dts, "vtransaksi");
                    dataGridView_transaksi.DataSource = dts;
                    dataGridView_transaksi.DataMember = "vtransaksi";
                }//try
                catch (SqlException)
                {

                }//catch 
            }//else
        }

        private void textBox_idTransaksi_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
