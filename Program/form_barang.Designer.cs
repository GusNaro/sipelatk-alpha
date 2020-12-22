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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.dgvBarang = new System.Windows.Forms.DataGridView();
            this.btnPindah = new System.Windows.Forms.Button();
            this.grbDetail = new System.Windows.Forms.GroupBox();
            this.lblID = new System.Windows.Forms.Label();
            this.lblSatuan = new System.Windows.Forms.Label();
            this.dtpTanggal = new System.Windows.Forms.DateTimePicker();
            this.cmbNamaBarang = new System.Windows.Forms.ComboBox();
            this.txtKet = new System.Windows.Forms.TextBox();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grbBarang = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtPenyediaB = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtHargaB = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSatuanB = new System.Windows.Forms.TextBox();
            this.txtNamaB = new System.Windows.Forms.TextBox();
            this.txtIdB = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBarang)).BeginInit();
            this.grbDetail.SuspendLayout();
            this.grbBarang.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSimpan
            // 
            this.btnSimpan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSimpan.Image = global::Program.Properties.Resources.save;
            this.btnSimpan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSimpan.Location = new System.Drawing.Point(182, 263);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(250, 60);
            this.btnSimpan.TabIndex = 1;
            this.btnSimpan.Text = "SIMPAN";
            this.btnSimpan.UseVisualStyleBackColor = true;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Image = global::Program.Properties.Resources.update;
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.Location = new System.Drawing.Point(463, 263);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(250, 60);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "UPDATE";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnHapus
            // 
            this.btnHapus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHapus.Image = global::Program.Properties.Resources.delete;
            this.btnHapus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHapus.Location = new System.Drawing.Point(733, 263);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(250, 60);
            this.btnHapus.TabIndex = 3;
            this.btnHapus.Text = "HAPUS";
            this.btnHapus.UseVisualStyleBackColor = true;
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // dgvBarang
            // 
            this.dgvBarang.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvBarang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBarang.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBarang.Location = new System.Drawing.Point(11, 330);
            this.dgvBarang.Name = "dgvBarang";
            this.dgvBarang.ReadOnly = true;
            this.dgvBarang.Size = new System.Drawing.Size(1114, 339);
            this.dgvBarang.TabIndex = 4;
            this.dgvBarang.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUser_Click);
            // 
            // btnPindah
            // 
            this.btnPindah.Font = new System.Drawing.Font("Ravie", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPindah.ForeColor = System.Drawing.Color.Red;
            this.btnPindah.Image = global::Program.Properties.Resources.change;
            this.btnPindah.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPindah.Location = new System.Drawing.Point(647, 100);
            this.btnPindah.Name = "btnPindah";
            this.btnPindah.Size = new System.Drawing.Size(109, 77);
            this.btnPindah.TabIndex = 6;
            this.btnPindah.Text = ">>>";
            this.btnPindah.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPindah.UseVisualStyleBackColor = true;
            this.btnPindah.Click += new System.EventHandler(this.btnPindah_Click);
            // 
            // grbDetail
            // 
            this.grbDetail.Controls.Add(this.lblID);
            this.grbDetail.Controls.Add(this.lblSatuan);
            this.grbDetail.Controls.Add(this.dtpTanggal);
            this.grbDetail.Controls.Add(this.cmbNamaBarang);
            this.grbDetail.Controls.Add(this.txtKet);
            this.grbDetail.Controls.Add(this.txtQty);
            this.grbDetail.Controls.Add(this.label5);
            this.grbDetail.Controls.Add(this.label4);
            this.grbDetail.Controls.Add(this.label3);
            this.grbDetail.Controls.Add(this.label2);
            this.grbDetail.Controls.Add(this.label1);
            this.grbDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbDetail.Location = new System.Drawing.Point(9, 3);
            this.grbDetail.Name = "grbDetail";
            this.grbDetail.Size = new System.Drawing.Size(624, 253);
            this.grbDetail.TabIndex = 13;
            this.grbDetail.TabStop = false;
            this.grbDetail.Text = "Input Barang";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblID.Location = new System.Drawing.Point(161, 33);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(51, 20);
            this.lblID.TabIndex = 15;
            this.lblID.Text = "label1";
            // 
            // lblSatuan
            // 
            this.lblSatuan.AutoSize = true;
            this.lblSatuan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblSatuan.Location = new System.Drawing.Point(371, 138);
            this.lblSatuan.Name = "lblSatuan";
            this.lblSatuan.Size = new System.Drawing.Size(51, 20);
            this.lblSatuan.TabIndex = 14;
            this.lblSatuan.Text = "label1";
            // 
            // dtpTanggal
            // 
            this.dtpTanggal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dtpTanggal.Location = new System.Drawing.Point(165, 102);
            this.dtpTanggal.Name = "dtpTanggal";
            this.dtpTanggal.Size = new System.Drawing.Size(280, 26);
            this.dtpTanggal.TabIndex = 13;
            // 
            // cmbNamaBarang
            // 
            this.cmbNamaBarang.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cmbNamaBarang.FormattingEnabled = true;
            this.cmbNamaBarang.Location = new System.Drawing.Point(165, 65);
            this.cmbNamaBarang.Name = "cmbNamaBarang";
            this.cmbNamaBarang.Size = new System.Drawing.Size(402, 28);
            this.cmbNamaBarang.TabIndex = 12;
            this.cmbNamaBarang.SelectedIndexChanged += new System.EventHandler(this.cmbNamaBarang_SelectedIndexChanged);
            // 
            // txtKet
            // 
            this.txtKet.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtKet.Location = new System.Drawing.Point(165, 173);
            this.txtKet.Multiline = true;
            this.txtKet.Name = "txtKet";
            this.txtKet.Size = new System.Drawing.Size(402, 64);
            this.txtKet.TabIndex = 10;
            // 
            // txtQty
            // 
            this.txtQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtQty.Location = new System.Drawing.Point(165, 135);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(200, 26);
            this.txtQty.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label5.Location = new System.Drawing.Point(17, 173);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Keterangan";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(17, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Jumlah";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(17, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tanggal";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(17, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nama Barang";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(17, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "No Pemasukan";
            // 
            // grbBarang
            // 
            this.grbBarang.Controls.Add(this.label11);
            this.grbBarang.Controls.Add(this.txtPenyediaB);
            this.grbBarang.Controls.Add(this.label9);
            this.grbBarang.Controls.Add(this.txtHargaB);
            this.grbBarang.Controls.Add(this.label8);
            this.grbBarang.Controls.Add(this.label7);
            this.grbBarang.Controls.Add(this.label6);
            this.grbBarang.Controls.Add(this.txtSatuanB);
            this.grbBarang.Controls.Add(this.txtNamaB);
            this.grbBarang.Controls.Add(this.txtIdB);
            this.grbBarang.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbBarang.Location = new System.Drawing.Point(769, 3);
            this.grbBarang.Name = "grbBarang";
            this.grbBarang.Size = new System.Drawing.Size(356, 253);
            this.grbBarang.TabIndex = 14;
            this.grbBarang.TabStop = false;
            this.grbBarang.Text = "Jenis Barang";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label11.Location = new System.Drawing.Point(18, 174);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(74, 20);
            this.label11.TabIndex = 22;
            this.label11.Text = "Penyedia";
            // 
            // txtPenyediaB
            // 
            this.txtPenyediaB.Location = new System.Drawing.Point(146, 174);
            this.txtPenyediaB.Multiline = true;
            this.txtPenyediaB.Name = "txtPenyediaB";
            this.txtPenyediaB.Size = new System.Drawing.Size(199, 63);
            this.txtPenyediaB.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label9.Location = new System.Drawing.Point(18, 141);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 20);
            this.label9.TabIndex = 20;
            this.label9.Text = "Harga";
            // 
            // txtHargaB
            // 
            this.txtHargaB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtHargaB.Location = new System.Drawing.Point(146, 138);
            this.txtHargaB.Name = "txtHargaB";
            this.txtHargaB.Size = new System.Drawing.Size(199, 26);
            this.txtHargaB.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label8.Location = new System.Drawing.Point(18, 103);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 20);
            this.label8.TabIndex = 18;
            this.label8.Text = "Satuan";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label7.Location = new System.Drawing.Point(18, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 20);
            this.label7.TabIndex = 17;
            this.label7.Text = "Nama Barang";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label6.Location = new System.Drawing.Point(18, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 20);
            this.label6.TabIndex = 16;
            this.label6.Text = "Kode Barang";
            // 
            // txtSatuanB
            // 
            this.txtSatuanB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtSatuanB.Location = new System.Drawing.Point(146, 100);
            this.txtSatuanB.Name = "txtSatuanB";
            this.txtSatuanB.Size = new System.Drawing.Size(199, 26);
            this.txtSatuanB.TabIndex = 15;
            // 
            // txtNamaB
            // 
            this.txtNamaB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtNamaB.Location = new System.Drawing.Point(146, 65);
            this.txtNamaB.Name = "txtNamaB";
            this.txtNamaB.Size = new System.Drawing.Size(199, 26);
            this.txtNamaB.TabIndex = 14;
            // 
            // txtIdB
            // 
            this.txtIdB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtIdB.Location = new System.Drawing.Point(146, 30);
            this.txtIdB.Name = "txtIdB";
            this.txtIdB.Size = new System.Drawing.Size(199, 26);
            this.txtIdB.TabIndex = 13;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(647, 78);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(109, 18);
            this.label10.TabIndex = 15;
            this.label10.Text = "PINDAH";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // form_barang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1134, 682);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.grbBarang);
            this.Controls.Add(this.grbDetail);
            this.Controls.Add(this.btnPindah);
            this.Controls.Add(this.dgvBarang);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnSimpan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "form_barang";
            this.Load += new System.EventHandler(this.form_barang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBarang)).EndInit();
            this.grbDetail.ResumeLayout(false);
            this.grbDetail.PerformLayout();
            this.grbBarang.ResumeLayout(false);
            this.grbBarang.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.DataGridView dgvBarang;
        private System.Windows.Forms.Button btnPindah;
        private System.Windows.Forms.GroupBox grbDetail;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblSatuan;
        private System.Windows.Forms.DateTimePicker dtpTanggal;
        private System.Windows.Forms.ComboBox cmbNamaBarang;
        private System.Windows.Forms.TextBox txtKet;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grbBarang;
        private System.Windows.Forms.TextBox txtSatuanB;
        private System.Windows.Forms.TextBox txtNamaB;
        private System.Windows.Forms.TextBox txtIdB;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtHargaB;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtPenyediaB;
    }
}