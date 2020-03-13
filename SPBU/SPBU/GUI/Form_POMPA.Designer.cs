namespace SPBU.GUI
{
    partial class Form_POMPA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_POMPA));
            this.textBox1_idPompa = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1_namaPompa = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label_namabbm = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBox_namabbm = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_cari = new System.Windows.Forms.TextBox();
            this.button_id = new System.Windows.Forms.Button();
            this.button4_simpan = new System.Windows.Forms.Button();
            this.button3_ubah = new System.Windows.Forms.Button();
            this.button2_hapus = new System.Windows.Forms.Button();
            this.button1_baru = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1_idPompa
            // 
            this.textBox1_idPompa.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1_idPompa.Location = new System.Drawing.Point(109, 6);
            this.textBox1_idPompa.Name = "textBox1_idPompa";
            this.textBox1_idPompa.Size = new System.Drawing.Size(173, 22);
            this.textBox1_idPompa.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "ID Pompa";
            // 
            // textBox1_namaPompa
            // 
            this.textBox1_namaPompa.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1_namaPompa.Location = new System.Drawing.Point(109, 34);
            this.textBox1_namaPompa.Name = "textBox1_namaPompa";
            this.textBox1_namaPompa.Size = new System.Drawing.Size(173, 22);
            this.textBox1_namaPompa.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nama Pompa";
            // 
            // label_namabbm
            // 
            this.label_namabbm.AutoSize = true;
            this.label_namabbm.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_namabbm.Location = new System.Drawing.Point(18, 65);
            this.label_namabbm.Name = "label_namabbm";
            this.label_namabbm.Size = new System.Drawing.Size(63, 13);
            this.label_namabbm.TabIndex = 6;
            this.label_namabbm.Text = "Nama BBM";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 180);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(456, 265);
            this.dataGridView1.TabIndex = 14;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // textBox_namabbm
            // 
            this.textBox_namabbm.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_namabbm.Location = new System.Drawing.Point(109, 65);
            this.textBox_namabbm.Name = "textBox_namabbm";
            this.textBox_namabbm.Size = new System.Drawing.Size(173, 22);
            this.textBox_namabbm.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(264, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Cari";
            // 
            // textBox_cari
            // 
            this.textBox_cari.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_cari.Location = new System.Drawing.Point(306, 152);
            this.textBox_cari.Name = "textBox_cari";
            this.textBox_cari.Size = new System.Drawing.Size(164, 22);
            this.textBox_cari.TabIndex = 21;
            this.textBox_cari.TextChanged += new System.EventHandler(this.textBox_cari_TextChanged);
            // 
            // button_id
            // 
            this.button_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_id.Image = global::SPBU.Properties.Resources.search16;
            this.button_id.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_id.Location = new System.Drawing.Point(289, 56);
            this.button_id.Name = "button_id";
            this.button_id.Size = new System.Drawing.Size(71, 32);
            this.button_id.TabIndex = 16;
            this.button_id.Text = "Cari ID";
            this.button_id.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_id.UseVisualStyleBackColor = true;
            this.button_id.Click += new System.EventHandler(this.button_id_Click);
            // 
            // button4_simpan
            // 
            this.button4_simpan.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4_simpan.Image = global::SPBU.Properties.Resources.save16;
            this.button4_simpan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4_simpan.Location = new System.Drawing.Point(240, 101);
            this.button4_simpan.Name = "button4_simpan";
            this.button4_simpan.Size = new System.Drawing.Size(79, 37);
            this.button4_simpan.TabIndex = 13;
            this.button4_simpan.Text = "Simpan";
            this.button4_simpan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button4_simpan.UseVisualStyleBackColor = true;
            this.button4_simpan.Click += new System.EventHandler(this.button4_simpan_Click);
            // 
            // button3_ubah
            // 
            this.button3_ubah.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3_ubah.Image = global::SPBU.Properties.Resources.edit16;
            this.button3_ubah.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3_ubah.Location = new System.Drawing.Point(167, 100);
            this.button3_ubah.Name = "button3_ubah";
            this.button3_ubah.Size = new System.Drawing.Size(67, 37);
            this.button3_ubah.TabIndex = 12;
            this.button3_ubah.Text = "Ubah";
            this.button3_ubah.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3_ubah.UseVisualStyleBackColor = true;
            this.button3_ubah.Click += new System.EventHandler(this.button3_ubah_Click);
            // 
            // button2_hapus
            // 
            this.button2_hapus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2_hapus.Image = global::SPBU.Properties.Resources.delete16;
            this.button2_hapus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2_hapus.Location = new System.Drawing.Point(90, 100);
            this.button2_hapus.Name = "button2_hapus";
            this.button2_hapus.Size = new System.Drawing.Size(71, 36);
            this.button2_hapus.TabIndex = 11;
            this.button2_hapus.Text = "Hapus";
            this.button2_hapus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2_hapus.UseVisualStyleBackColor = true;
            this.button2_hapus.Click += new System.EventHandler(this.button2_hapus_Click);
            // 
            // button1_baru
            // 
            this.button1_baru.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1_baru.Image = global::SPBU.Properties.Resources.add16;
            this.button1_baru.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1_baru.Location = new System.Drawing.Point(21, 100);
            this.button1_baru.Name = "button1_baru";
            this.button1_baru.Size = new System.Drawing.Size(63, 37);
            this.button1_baru.TabIndex = 10;
            this.button1_baru.Text = "Baru";
            this.button1_baru.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1_baru.UseVisualStyleBackColor = true;
            this.button1_baru.Click += new System.EventHandler(this.button1_baru_Click);
            // 
            // Form_POMPA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 457);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_cari);
            this.Controls.Add(this.button_id);
            this.Controls.Add(this.textBox_namabbm);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button4_simpan);
            this.Controls.Add(this.button3_ubah);
            this.Controls.Add(this.button2_hapus);
            this.Controls.Add(this.button1_baru);
            this.Controls.Add(this.label_namabbm);
            this.Controls.Add(this.textBox1_namaPompa);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1_idPompa);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_POMPA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pompa";
            this.Load += new System.EventHandler(this.Form_POMPA_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1_idPompa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1_namaPompa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_namabbm;
        private System.Windows.Forms.Button button4_simpan;
        private System.Windows.Forms.Button button3_ubah;
        private System.Windows.Forms.Button button2_hapus;
        private System.Windows.Forms.Button button1_baru;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button_id;
        public System.Windows.Forms.TextBox textBox_namabbm;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_cari;
    }
}