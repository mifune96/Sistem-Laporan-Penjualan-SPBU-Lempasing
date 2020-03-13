namespace SPBU.GUI
{
    partial class Form_PENGELUARAN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_PENGELUARAN));
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_jumlah = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_idPengeluaran = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_simpan = new System.Windows.Forms.Button();
            this.button_ubah = new System.Windows.Forms.Button();
            this.button_hapus = new System.Windows.Forms.Button();
            this.button_baru = new System.Windows.Forms.Button();
            this.dataGridView_pengeluaran = new System.Windows.Forms.DataGridView();
            this.richTextBox_deskripsi = new System.Windows.Forms.RichTextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_cari = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_pengeluaran)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Deskripsi";
            // 
            // textBox_jumlah
            // 
            this.textBox_jumlah.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_jumlah.Location = new System.Drawing.Point(143, 40);
            this.textBox_jumlah.Name = "textBox_jumlah";
            this.textBox_jumlah.Size = new System.Drawing.Size(148, 22);
            this.textBox_jumlah.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Jumlah Pengeluaran";
            // 
            // textBox_idPengeluaran
            // 
            this.textBox_idPengeluaran.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_idPengeluaran.Location = new System.Drawing.Point(143, 12);
            this.textBox_idPengeluaran.Name = "textBox_idPengeluaran";
            this.textBox_idPengeluaran.Size = new System.Drawing.Size(148, 22);
            this.textBox_idPengeluaran.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "ID Pengeluaran";
            // 
            // button_simpan
            // 
            this.button_simpan.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_simpan.Image = global::SPBU.Properties.Resources.save16;
            this.button_simpan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_simpan.Location = new System.Drawing.Point(446, 138);
            this.button_simpan.Name = "button_simpan";
            this.button_simpan.Size = new System.Drawing.Size(81, 33);
            this.button_simpan.TabIndex = 71;
            this.button_simpan.Text = "Simpan";
            this.button_simpan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_simpan.UseVisualStyleBackColor = true;
            this.button_simpan.Click += new System.EventHandler(this.button_simpan_Click);
            // 
            // button_ubah
            // 
            this.button_ubah.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_ubah.Image = global::SPBU.Properties.Resources.edit16;
            this.button_ubah.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_ubah.Location = new System.Drawing.Point(349, 138);
            this.button_ubah.Name = "button_ubah";
            this.button_ubah.Size = new System.Drawing.Size(72, 33);
            this.button_ubah.TabIndex = 70;
            this.button_ubah.Text = "Ubah";
            this.button_ubah.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_ubah.UseVisualStyleBackColor = true;
            this.button_ubah.Click += new System.EventHandler(this.button_ubah_Click);
            // 
            // button_hapus
            // 
            this.button_hapus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_hapus.Image = global::SPBU.Properties.Resources.delete16;
            this.button_hapus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_hapus.Location = new System.Drawing.Point(250, 138);
            this.button_hapus.Name = "button_hapus";
            this.button_hapus.Size = new System.Drawing.Size(73, 33);
            this.button_hapus.TabIndex = 69;
            this.button_hapus.Text = "Hapus";
            this.button_hapus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_hapus.UseVisualStyleBackColor = true;
            this.button_hapus.Click += new System.EventHandler(this.button_hapus_Click);
            // 
            // button_baru
            // 
            this.button_baru.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_baru.Image = global::SPBU.Properties.Resources.add16;
            this.button_baru.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_baru.Location = new System.Drawing.Point(143, 137);
            this.button_baru.Name = "button_baru";
            this.button_baru.Size = new System.Drawing.Size(79, 33);
            this.button_baru.TabIndex = 68;
            this.button_baru.Text = "Baru";
            this.button_baru.UseVisualStyleBackColor = true;
            this.button_baru.Click += new System.EventHandler(this.button_baru_Click);
            // 
            // dataGridView_pengeluaran
            // 
            this.dataGridView_pengeluaran.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_pengeluaran.Location = new System.Drawing.Point(16, 234);
            this.dataGridView_pengeluaran.Name = "dataGridView_pengeluaran";
            this.dataGridView_pengeluaran.Size = new System.Drawing.Size(511, 215);
            this.dataGridView_pengeluaran.TabIndex = 72;
            this.dataGridView_pengeluaran.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_pengeluaran_CellContentClick);
            // 
            // richTextBox_deskripsi
            // 
            this.richTextBox_deskripsi.Location = new System.Drawing.Point(143, 68);
            this.richTextBox_deskripsi.Name = "richTextBox_deskripsi";
            this.richTextBox_deskripsi.Size = new System.Drawing.Size(384, 51);
            this.richTextBox_deskripsi.TabIndex = 73;
            this.richTextBox_deskripsi.Text = "";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(327, 14);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 74;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(321, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 76;
            this.label5.Text = "Cari";
            // 
            // textBox_cari
            // 
            this.textBox_cari.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_cari.Location = new System.Drawing.Point(363, 194);
            this.textBox_cari.Name = "textBox_cari";
            this.textBox_cari.Size = new System.Drawing.Size(164, 22);
            this.textBox_cari.TabIndex = 75;
            this.textBox_cari.TextChanged += new System.EventHandler(this.textBox_cari_TextChanged);
            // 
            // Form_PENGELUARAN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 461);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_cari);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.richTextBox_deskripsi);
            this.Controls.Add(this.dataGridView_pengeluaran);
            this.Controls.Add(this.button_simpan);
            this.Controls.Add(this.button_ubah);
            this.Controls.Add(this.button_hapus);
            this.Controls.Add(this.button_baru);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_jumlah);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_idPengeluaran);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_PENGELUARAN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pengeluaran";
            this.Load += new System.EventHandler(this.Form_PENGELUARAN_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_pengeluaran)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_jumlah;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_idPengeluaran;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_simpan;
        private System.Windows.Forms.Button button_ubah;
        private System.Windows.Forms.Button button_hapus;
        private System.Windows.Forms.Button button_baru;
        private System.Windows.Forms.DataGridView dataGridView_pengeluaran;
        private System.Windows.Forms.RichTextBox richTextBox_deskripsi;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_cari;
    }
}