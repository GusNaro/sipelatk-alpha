namespace Program
{
    partial class form_transaksi
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
            this.cmbBarang = new System.Windows.Forms.ComboBox();
            this.txtKet = new System.Windows.Forms.TextBox();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.dgvTransaksi = new System.Windows.Forms.DataGridView();
            this.dtpBarang = new System.Windows.Forms.DateTimePicker();
            this.lblID = new System.Windows.Forms.Label();
            this.lblSatuan = new System.Windows.Forms.Label();
            this.lblJumlah = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransaksi)).BeginInit();
            this.SuspendLayout();
            // 
            // txtQty
            // 
            this.txtQty.Location = new System.Drawing.Point(112, 110);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(131, 20);
            this.txtQty.TabIndex = 2;
            // 
            // cmbBarang
            // 
            this.cmbBarang.FormattingEnabled = true;
            this.cmbBarang.Location = new System.Drawing.Point(112, 28);
            this.cmbBarang.Name = "cmbBarang";
            this.cmbBarang.Size = new System.Drawing.Size(247, 21);
            this.cmbBarang.TabIndex = 0;
            this.cmbBarang.SelectedIndexChanged += new System.EventHandler(this.cmbBarang_SelectedIndexChanged);
            // 
            // txtKet
            // 
            this.txtKet.Location = new System.Drawing.Point(112, 137);
            this.txtKet.Multiline = true;
            this.txtKet.Name = "txtKet";
            this.txtKet.Size = new System.Drawing.Size(402, 52);
            this.txtKet.TabIndex = 3;
            // 
            // btnSimpan
            // 
            this.btnSimpan.Location = new System.Drawing.Point(112, 195);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(130, 23);
            this.btnSimpan.TabIndex = 4;
            this.btnSimpan.Text = "button1";
            this.btnSimpan.UseVisualStyleBackColor = true;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(248, 195);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(130, 23);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "button2";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnHapus
            // 
            this.btnHapus.Location = new System.Drawing.Point(384, 195);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(130, 23);
            this.btnHapus.TabIndex = 6;
            this.btnHapus.Text = "button3";
            this.btnHapus.UseVisualStyleBackColor = true;
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // dgvTransaksi
            // 
            this.dgvTransaksi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransaksi.Location = new System.Drawing.Point(24, 229);
            this.dgvTransaksi.Name = "dgvTransaksi";
            this.dgvTransaksi.Size = new System.Drawing.Size(1082, 470);
            this.dgvTransaksi.TabIndex = 7;
            this.dgvTransaksi.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTransaksi_Click);
            // 
            // dtpBarang
            // 
            this.dtpBarang.Location = new System.Drawing.Point(112, 56);
            this.dtpBarang.Name = "dtpBarang";
            this.dtpBarang.Size = new System.Drawing.Size(200, 20);
            this.dtpBarang.TabIndex = 1;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(112, 9);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(35, 13);
            this.lblID.TabIndex = 8;
            this.lblID.Text = "label1";
            // 
            // lblSatuan
            // 
            this.lblSatuan.AutoSize = true;
            this.lblSatuan.Location = new System.Drawing.Point(249, 113);
            this.lblSatuan.Name = "lblSatuan";
            this.lblSatuan.Size = new System.Drawing.Size(35, 13);
            this.lblSatuan.TabIndex = 9;
            this.lblSatuan.Text = "label2";
            // 
            // lblJumlah
            // 
            this.lblJumlah.AutoSize = true;
            this.lblJumlah.Location = new System.Drawing.Point(112, 86);
            this.lblJumlah.Name = "lblJumlah";
            this.lblJumlah.Size = new System.Drawing.Size(35, 13);
            this.lblJumlah.TabIndex = 10;
            this.lblJumlah.Text = "label1";
            // 
            // form_transaksi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblJumlah);
            this.Controls.Add(this.lblSatuan);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.dtpBarang);
            this.Controls.Add(this.dgvTransaksi);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.txtKet);
            this.Controls.Add(this.cmbBarang);
            this.Controls.Add(this.txtQty);
            this.Name = "form_transaksi";
            this.Size = new System.Drawing.Size(1150, 720);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransaksi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.ComboBox cmbBarang;
        private System.Windows.Forms.TextBox txtKet;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.DataGridView dgvTransaksi;
        private System.Windows.Forms.DateTimePicker dtpBarang;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblSatuan;
        private System.Windows.Forms.Label lblJumlah;
    }
}