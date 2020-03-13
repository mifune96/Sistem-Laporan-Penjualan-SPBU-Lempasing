using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPBU.GUI
{
    public partial class menuUtama : Form
    {
        public static menuUtama MenuUtama;

        Form_BBM BBM;
        Form_LOGIN login;
        Form_PENGELUARAN pengeluaran;
        Form_POMPA pompa;
        Form_TRANSAKSI transaksi;
        Form_PENERIMAAN penerimaan;
        Form_Laporan laporan;
        public menuUtama()
        {
            InitializeComponent();
        }

        private void menuUtama_Load(object sender, EventArgs e)
        {
            //File Tool Strip
            fileToolStripMenuItem.Enabled = true;
            logOutToolStripMenuItem.Enabled = false;
            exitToolStripMenuItem.Enabled = false;

            //Transaksi Tool Strip
            transaksiToolStripMenuItem.Enabled = false;
            transaksiToolStripMenuItem1.Enabled = false;

            //Master Tool Strip
            masterToolStripMenuItem.Enabled = false;
            bBMToolStripMenuItem.Enabled = false;
            pOMPAToolStripMenuItem.Enabled = false;
            pENGELUARANToolStripMenuItem.Enabled = false;

            //Laporan Tool Strip
            laporanToolStripMenuItem.Enabled = false;

            MenuUtama = this;
            Form_LOGIN login = new Form_LOGIN();
            login.ShowDialog();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //File Tool Strip
            fileToolStripMenuItem.Enabled = true;
            logOutToolStripMenuItem.Enabled = false;
            exitToolStripMenuItem.Enabled = false;

            //Transaksi Tool Strip
            transaksiToolStripMenuItem.Enabled = false;
            transaksiToolStripMenuItem1.Enabled = false;

            //Master Tool Strip
            masterToolStripMenuItem.Enabled = false;
            bBMToolStripMenuItem.Enabled = false;
            pOMPAToolStripMenuItem.Enabled = false;
            pENGELUARANToolStripMenuItem.Enabled = false;

            //Laporan Tool Strip
            laporanToolStripMenuItem.Enabled = false;


            MenuUtama = this;
            Form_LOGIN login = new Form_LOGIN();
            login.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void formtransaksi(Object sender, FormClosedEventArgs e)
        {
            transaksi = null;
        }

        private void transaksiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (transaksi == null)
            {
                transaksi= new Form_TRANSAKSI();

                transaksi.FormClosed += new FormClosedEventHandler(formtransaksi);
                transaksi.Show();


            }
            else
            {
                transaksi.Activate();
            }
        }

        void formbbm(Object sender, FormClosedEventArgs e)
        {
            BBM = null;
        }

        private void bBMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (BBM == null)
            {
                BBM = new Form_BBM();

                BBM.FormClosed += new FormClosedEventHandler(formbbm);
                BBM.Show();


            }
            else
            {
                BBM.Activate();
            }
        }

        void formpompa(Object sender, FormClosedEventArgs e)
        {
            pompa = null;
        }

        private void pOMPAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pompa == null)
            {
                pompa = new Form_POMPA();

                pompa.FormClosed += new FormClosedEventHandler(formpompa);
                pompa.Show();


            }
            else
            {
                pompa.Activate();
            }
        }

        void formpengeluaran(Object sender, FormClosedEventArgs e)
        {
            pengeluaran = null;
        }

        private void pENGELUARANToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pengeluaran == null)
            {
                pengeluaran= new Form_PENGELUARAN();

                pengeluaran.FormClosed += new FormClosedEventHandler(formpengeluaran);
                pengeluaran.Show();


            }
            else
            {
                pengeluaran.Activate();
            }
        }

        void formpenerimaan(Object sender, FormClosedEventArgs e)
        {
            penerimaan = null;
        }

        private void pENERIMAANToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (penerimaan == null)
            {
                penerimaan = new Form_PENERIMAAN();

                penerimaan.FormClosed += new FormClosedEventHandler(formpenerimaan);
                penerimaan.Show();


            }
            else
            {
                penerimaan.Activate();
            }
        }

        void formlaporan(Object sender, FormClosedEventArgs e)
        {
            laporan = null;
        }

        private void laporanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (laporan == null)
            {
                laporan = new Form_Laporan();

                laporan.FormClosed += new FormClosedEventHandler(formlaporan);
                laporan.Show();

            }
            else
            {
                penerimaan.Activate();
            }
        }

        private void harianToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void bulanToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

    }
}
