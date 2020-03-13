namespace SPBU.GUI
{
    partial class Form_BBM
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_BBM));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_idBbm = new System.Windows.Forms.TextBox();
            this.textBox_namaBBM = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_harga = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button_baru = new System.Windows.Forms.Button();
            this.button_hapus = new System.Windows.Forms.Button();
            this.button_ubah = new System.Windows.Forms.Button();
            this.button_simpan = new System.Windows.Forms.Button();
            this.dataGridView_bbm = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_bbm)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // textBox_idBbm
            // 
            resources.ApplyResources(this.textBox_idBbm, "textBox_idBbm");
            this.textBox_idBbm.Name = "textBox_idBbm";
            // 
            // textBox_namaBBM
            // 
            resources.ApplyResources(this.textBox_namaBBM, "textBox_namaBBM");
            this.textBox_namaBBM.Name = "textBox_namaBBM";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // textBox_harga
            // 
            resources.ApplyResources(this.textBox_harga, "textBox_harga");
            this.textBox_harga.Name = "textBox_harga";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // button_baru
            // 
            resources.ApplyResources(this.button_baru, "button_baru");
            this.button_baru.Name = "button_baru";
            this.button_baru.UseVisualStyleBackColor = true;
            this.button_baru.Click += new System.EventHandler(this.button_baru_Click);
            // 
            // button_hapus
            // 
            resources.ApplyResources(this.button_hapus, "button_hapus");
            this.button_hapus.Name = "button_hapus";
            this.button_hapus.UseVisualStyleBackColor = true;
            this.button_hapus.Click += new System.EventHandler(this.button_hapus_Click);
            // 
            // button_ubah
            // 
            resources.ApplyResources(this.button_ubah, "button_ubah");
            this.button_ubah.Name = "button_ubah";
            this.button_ubah.UseVisualStyleBackColor = true;
            this.button_ubah.Click += new System.EventHandler(this.button_ubah_Click);
            // 
            // button_simpan
            // 
            resources.ApplyResources(this.button_simpan, "button_simpan");
            this.button_simpan.Name = "button_simpan";
            this.button_simpan.UseVisualStyleBackColor = true;
            this.button_simpan.Click += new System.EventHandler(this.button_simpan_Click);
            // 
            // dataGridView_bbm
            // 
            resources.ApplyResources(this.dataGridView_bbm, "dataGridView_bbm");
            this.dataGridView_bbm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_bbm.Name = "dataGridView_bbm";
            this.dataGridView_bbm.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_bbm_CellClick);
            // 
            // Form_BBM
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView_bbm);
            this.Controls.Add(this.button_simpan);
            this.Controls.Add(this.button_ubah);
            this.Controls.Add(this.button_hapus);
            this.Controls.Add(this.button_baru);
            this.Controls.Add(this.textBox_harga);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_namaBBM);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_idBbm);
            this.Controls.Add(this.label1);
            this.Name = "Form_BBM";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_bbm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_idBbm;
        private System.Windows.Forms.TextBox textBox_namaBBM;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_harga;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_baru;
        private System.Windows.Forms.Button button_hapus;
        private System.Windows.Forms.Button button_ubah;
        private System.Windows.Forms.Button button_simpan;
        private System.Windows.Forms.DataGridView dataGridView_bbm;

    }
}