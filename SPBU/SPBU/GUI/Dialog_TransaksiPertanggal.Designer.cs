namespace SPBU.GUI
{
    partial class Dialog_TransaksiPertanggal
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.button_cetak = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(12, 48);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // button_cetak
            // 
            this.button_cetak.Location = new System.Drawing.Point(237, 41);
            this.button_cetak.Name = "button_cetak";
            this.button_cetak.Size = new System.Drawing.Size(75, 38);
            this.button_cetak.TabIndex = 1;
            this.button_cetak.Text = "Cetak";
            this.button_cetak.UseVisualStyleBackColor = true;
            this.button_cetak.Click += new System.EventHandler(this.button_cetak_Click);
            // 
            // Dialog_TransaksiPertanggal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 115);
            this.Controls.Add(this.button_cetak);
            this.Controls.Add(this.dateTimePicker1);
            this.Name = "Dialog_TransaksiPertanggal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dialog_TransaksiPertanggal";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button button_cetak;
    }
}