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
using CrystalDecisions.CrystalReports.Engine;

namespace SPBU.GUI
{
    public partial class Form_Laporan : Form
    {
        private DataSet dts;
        private SqlDataAdapter data;
        Kelas.Koneksi konn = new Kelas.Koneksi();
        public Form_Laporan()
        {
            InitializeComponent();
        }

        private void Form_Laporan_Load(object sender, EventArgs e)
        {
            /*SqlConnection conn = konn.GetConn();
            conn.Open();
            data = new SqlDataAdapter("TglLPR", conn);
            data.SelectCommand.CommandType = CommandType.StoredProcedure;
            dts = new DataSet();
            data.Fill(dts, "vtransaksi");*/
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Laporan.LaporanHarian myReport = new Laporan.LaporanHarian();
            crystalReportViewer1.ReportSource = myReport;
            crystalReportViewer1.SelectionFormula = "date({vtransaksi.tgl_transaksi}) in date ('" + dateTimeHarian.Text + "') to date ('" + dateTimeHarian.Text + "')";
            myReport.SetDataSource(dts);
            myReport.Refresh();
            crystalReportViewer1.Refresh();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Laporan.LaporanBulanan reportBulanan = new Laporan.LaporanBulanan();
            crystalReportViewer1.ReportSource = reportBulanan;
            crystalReportViewer1.SelectionFormula = "date({vtransaksi.tgl_transaksi}) in date ('" + DateTimeDari.Text + "') to date ('" + DateTimeKe.Text + "')";
            reportBulanan.SetDataSource(dts);
            reportBulanan.Refresh();
            crystalReportViewer1.ReportSource = reportBulanan;
            crystalReportViewer1.Refresh();
        }


    }
}
