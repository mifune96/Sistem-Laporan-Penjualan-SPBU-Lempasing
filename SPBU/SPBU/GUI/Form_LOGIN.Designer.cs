namespace SPBU.GUI
{
    partial class Form_LOGIN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_LOGIN));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_namaPengguna = new System.Windows.Forms.TextBox();
            this.textBox_kataSandi = new System.Windows.Forms.TextBox();
            this.button_exit = new System.Windows.Forms.Button();
            this.button_masuk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nama Pengguna";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Kata Sandi";
            // 
            // textBox_namaPengguna
            // 
            this.textBox_namaPengguna.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_namaPengguna.Location = new System.Drawing.Point(107, 70);
            this.textBox_namaPengguna.Name = "textBox_namaPengguna";
            this.textBox_namaPengguna.Size = new System.Drawing.Size(100, 22);
            this.textBox_namaPengguna.TabIndex = 2;
            // 
            // textBox_kataSandi
            // 
            this.textBox_kataSandi.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_kataSandi.Location = new System.Drawing.Point(107, 108);
            this.textBox_kataSandi.Name = "textBox_kataSandi";
            this.textBox_kataSandi.PasswordChar = '*';
            this.textBox_kataSandi.Size = new System.Drawing.Size(100, 22);
            this.textBox_kataSandi.TabIndex = 3;
            // 
            // button_exit
            // 
            this.button_exit.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_exit.Image = global::SPBU.Properties.Resources.exit16;
            this.button_exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_exit.Location = new System.Drawing.Point(127, 161);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(96, 33);
            this.button_exit.TabIndex = 70;
            this.button_exit.Text = "Exit";
            this.button_exit.UseVisualStyleBackColor = true;
            this.button_exit.Click += new System.EventHandler(this.button_exit_Click);
            // 
            // button_masuk
            // 
            this.button_masuk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button_masuk.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_masuk.Image = global::SPBU.Properties.Resources.login16;
            this.button_masuk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_masuk.Location = new System.Drawing.Point(12, 161);
            this.button_masuk.Name = "button_masuk";
            this.button_masuk.Size = new System.Drawing.Size(96, 33);
            this.button_masuk.TabIndex = 69;
            this.button_masuk.Text = "Masuk";
            this.button_masuk.UseVisualStyleBackColor = true;
            this.button_masuk.Click += new System.EventHandler(this.button_masuk_Click);
            // 
            // Form_LOGIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 215);
            this.Controls.Add(this.button_exit);
            this.Controls.Add(this.button_masuk);
            this.Controls.Add(this.textBox_kataSandi);
            this.Controls.Add(this.textBox_namaPengguna);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_LOGIN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Form_LOGIN_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_namaPengguna;
        private System.Windows.Forms.TextBox textBox_kataSandi;
        private System.Windows.Forms.Button button_masuk;
        private System.Windows.Forms.Button button_exit;
    }
}