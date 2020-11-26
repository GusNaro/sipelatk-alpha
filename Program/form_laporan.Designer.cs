namespace Program
{
    partial class form_laporan
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
            this.dtpDari = new System.Windows.Forms.DateTimePicker();
            this.dtpSampai = new System.Windows.Forms.DateTimePicker();
            this.cmbList = new System.Windows.Forms.ComboBox();
            this.dgvLaporan = new System.Windows.Forms.DataGridView();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnTampil = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLaporan)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpDari
            // 
            this.dtpDari.Location = new System.Drawing.Point(165, 48);
            this.dtpDari.Name = "dtpDari";
            this.dtpDari.Size = new System.Drawing.Size(200, 20);
            this.dtpDari.TabIndex = 1;
            // 
            // dtpSampai
            // 
            this.dtpSampai.Location = new System.Drawing.Point(165, 74);
            this.dtpSampai.Name = "dtpSampai";
            this.dtpSampai.Size = new System.Drawing.Size(200, 20);
            this.dtpSampai.TabIndex = 2;
            // 
            // cmbList
            // 
            this.cmbList.FormattingEnabled = true;
            this.cmbList.Location = new System.Drawing.Point(165, 21);
            this.cmbList.Name = "cmbList";
            this.cmbList.Size = new System.Drawing.Size(200, 21);
            this.cmbList.TabIndex = 0;
            this.cmbList.SelectedIndexChanged += new System.EventHandler(this.cmbList_SelectedIndexChanged);
            // 
            // dgvLaporan
            // 
            this.dgvLaporan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLaporan.Location = new System.Drawing.Point(16, 153);
            this.dgvLaporan.Name = "dgvLaporan";
            this.dgvLaporan.ReadOnly = true;
            this.dgvLaporan.Size = new System.Drawing.Size(1116, 549);
            this.dgvLaporan.TabIndex = 5;
            // 
            // btnExport
            // 
            this.btnExport.Enabled = false;
            this.btnExport.Location = new System.Drawing.Point(924, 43);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 70);
            this.btnExport.TabIndex = 4;
            this.btnExport.Text = "EXPORT KE EXCEL";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnTampil
            // 
            this.btnTampil.Location = new System.Drawing.Point(165, 101);
            this.btnTampil.Name = "btnTampil";
            this.btnTampil.Size = new System.Drawing.Size(200, 23);
            this.btnTampil.TabIndex = 3;
            this.btnTampil.Text = "TAMPILKAN";
            this.btnTampil.UseVisualStyleBackColor = true;
            this.btnTampil.Click += new System.EventHandler(this.btnTampil_Click);
            // 
            // form_laporan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnTampil);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.dgvLaporan);
            this.Controls.Add(this.cmbList);
            this.Controls.Add(this.dtpSampai);
            this.Controls.Add(this.dtpDari);
            this.Name = "form_laporan";
            this.Size = new System.Drawing.Size(1150, 720);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLaporan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpDari;
        private System.Windows.Forms.DateTimePicker dtpSampai;
        private System.Windows.Forms.ComboBox cmbList;
        private System.Windows.Forms.DataGridView dgvLaporan;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnTampil;
    }
}