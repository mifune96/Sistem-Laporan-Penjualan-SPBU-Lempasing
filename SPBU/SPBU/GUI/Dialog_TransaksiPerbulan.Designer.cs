namespace SPBU.GUI
{
    partial class Dialog_TransaksiPerbulan
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
            this.button_cetak = new System.Windows.Forms.Button();
            this.dateTimePicker_tglawal = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_tglakhir = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // button_cetak
            // 
            this.button_cetak.Location = new System.Drawing.Point(170, 48);
            this.button_cetak.Name = "button_cetak";
            this.button_cetak.Size = new System.Drawing.Size(75, 55);
            this.button_cetak.TabIndex = 0;
            this.button_cetak.Text = "Cetak";
            this.button_cetak.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker_tglawal
            // 
            this.dateTimePicker_tglawal.Location = new System.Drawing.Point(12, 48);
            this.dateTimePicker_tglawal.Name = "dateTimePicker_tglawal";
            this.dateTimePicker_tglawal.Size = new System.Drawing.Size(143, 20);
            this.dateTimePicker_tglawal.TabIndex = 1;
            this.dateTimePicker_tglawal.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // dateTimePicker_tglakhir
            // 
            this.dateTimePicker_tglakhir.Location = new System.Drawing.Point(12, 83);
            this.dateTimePicker_tglakhir.Name = "dateTimePicker_tglakhir";
            this.dateTimePicker_tglakhir.Size = new System.Drawing.Size(143, 20);
            this.dateTimePicker_tglakhir.TabIndex = 2;
            // 
            // Dialog_TransaksiPerbulan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(255, 136);
            this.Controls.Add(this.dateTimePicker_tglakhir);
            this.Controls.Add(this.dateTimePicker_tglawal);
            this.Controls.Add(this.button_cetak);
            this.Name = "Dialog_TransaksiPerbulan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "*";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_cetak;
        private System.Windows.Forms.DateTimePicker dateTimePicker_tglawal;
        private System.Windows.Forms.DateTimePicker dateTimePicker_tglakhir;
    }
}