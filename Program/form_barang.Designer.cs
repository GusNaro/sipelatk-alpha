namespace Program
{
    partial class form_barang
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
            this.txtQty = new System.Windows.Forms.TextBox();
            this.txtKet = new System.Windows.Forms.TextBox();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.dgvBarang = new System.Windows.Forms.DataGridView();
            this.cmbNamaBarang = new System.Windows.Forms.ComboBox();
            this.btnPindah = new System.Windows.Forms.Button();
            this.dtpTanggal = new System.Windows.Forms.DateTimePicker();
            this.lblSatuan = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.txtIdB = new System.Windows.Forms.TextBox();
            this.txtNamaB = new System.Windows.Forms.TextBox();
            this.txtSatuanB = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBarang)).BeginInit();
            this.SuspendLayout();
            // 
            // txtQty
            // 
            this.txtQty.Location = new System.Drawing.Point(139, 93);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(200, 20);
            this.txtQty.TabIndex = 0;
            // 
            // txtKet
            // 
            this.txtKet.Location = new System.Drawing.Point(139, 119);
            this.txtKet.Multiline = true;
            this.txtKet.Name = "txtKet";
            this.txtKet.Size = new System.Drawing.Size(402, 64);
            this.txtKet.TabIndex = 0;
            // 
            // btnSimpan
            // 
            this.btnSimpan.Location = new System.Drawing.Point(398, 192);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(130, 23);
            this.btnSimpan.TabIndex = 1;
            this.btnSimpan.Text = "SIMPAN";
            this.btnSimpan.UseVisualStyleBackColor = true;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(534, 192);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(130, 23);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "UPDATE";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnHapus
            // 
            this.btnHapus.Location = new System.Drawing.Point(670, 192);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(130, 23);
            this.btnHapus.TabIndex = 3;
            this.btnHapus.Text = "HAPUS";
            this.btnHapus.UseVisualStyleBackColor = true;
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // dgvBarang
            // 
            this.dgvBarang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBarang.Location = new System.Drawing.Point(23, 221);
            this.dgvBarang.Name = "dgvBarang";
            this.dgvBarang.ReadOnly = true;
            this.dgvBarang.Size = new System.Drawing.Size(1088, 441);
            this.dgvBarang.TabIndex = 4;
            this.dgvBarang.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUser_Click);
            // 
            // cmbNamaBarang
            // 
            this.cmbNamaBarang.FormattingEnabled = true;
            this.cmbNamaBarang.Location = new System.Drawing.Point(139, 39);
            this.cmbNamaBarang.Name = "cmbNamaBarang";
            this.cmbNamaBarang.Size = new System.Drawing.Size(402, 21);
            this.cmbNamaBarang.TabIndex = 5;
            this.cmbNamaBarang.SelectedIndexChanged += new System.EventHandler(this.cmbNamaBarang_SelectedIndexChanged);
            // 
            // btnPindah
            // 
            this.btnPindah.Location = new System.Drawing.Point(548, 39);
            this.btnPindah.Name = "btnPindah";
            this.btnPindah.Size = new System.Drawing.Size(109, 74);
            this.btnPindah.TabIndex = 6;
            this.btnPindah.Text = ">>>";
            this.btnPindah.UseVisualStyleBackColor = true;
            this.btnPindah.Click += new System.EventHandler(this.btnPindah_Click);
            // 
            // dtpTanggal
            // 
            this.dtpTanggal.Location = new System.Drawing.Point(139, 67);
            this.dtpTanggal.Name = "dtpTanggal";
            this.dtpTanggal.Size = new System.Drawing.Size(200, 20);
            this.dtpTanggal.TabIndex = 7;
            // 
            // lblSatuan
            // 
            this.lblSatuan.AutoSize = true;
            this.lblSatuan.Location = new System.Drawing.Point(345, 96);
            this.lblSatuan.Name = "lblSatuan";
            this.lblSatuan.Size = new System.Drawing.Size(35, 13);
            this.lblSatuan.TabIndex = 8;
            this.lblSatuan.Text = "label1";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(140, 20);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(35, 13);
            this.lblID.TabIndex = 9;
            this.lblID.Text = "label1";
            // 
            // txtIdB
            // 
            this.txtIdB.Location = new System.Drawing.Point(822, 20);
            this.txtIdB.Name = "txtIdB";
            this.txtIdB.Size = new System.Drawing.Size(100, 20);
            this.txtIdB.TabIndex = 10;
            // 
            // txtNamaB
            // 
            this.txtNamaB.Location = new System.Drawing.Point(822, 47);
            this.txtNamaB.Name = "txtNamaB";
            this.txtNamaB.Size = new System.Drawing.Size(100, 20);
            this.txtNamaB.TabIndex = 11;
            // 
            // txtSatuanB
            // 
            this.txtSatuanB.Location = new System.Drawing.Point(822, 74);
            this.txtSatuanB.Name = "txtSatuanB";
            this.txtSatuanB.Size = new System.Drawing.Size(100, 20);
            this.txtSatuanB.TabIndex = 12;
            // 
            // form_barang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtSatuanB);
            this.Controls.Add(this.txtNamaB);
            this.Controls.Add(this.txtIdB);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.lblSatuan);
            this.Controls.Add(this.dtpTanggal);
            this.Controls.Add(this.btnPindah);
            this.Controls.Add(this.cmbNamaBarang);
            this.Controls.Add(this.dgvBarang);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.txtKet);
            this.Controls.Add(this.txtQty);
            this.Name = "form_barang";
            this.Size = new System.Drawing.Size(1150, 720);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBarang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.TextBox txtKet;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.DataGridView dgvBarang;
        private System.Windows.Forms.ComboBox cmbNamaBarang;
        private System.Windows.Forms.Button btnPindah;
        private System.Windows.Forms.DateTimePicker dtpTanggal;
        private System.Windows.Forms.Label lblSatuan;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox txtIdB;
        private System.Windows.Forms.TextBox txtNamaB;
        private System.Windows.Forms.TextBox txtSatuanB;
    }
}