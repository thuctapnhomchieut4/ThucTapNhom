namespace QuanLyDiemSinhVien
{
    partial class frmThemDMDiem
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
            this.txtDiemSo = new System.Windows.Forms.TextBox();
            this.txtDiemChu = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLanThi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.comboBoxMaMH = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxMaSV = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtDiemSo
            // 
            this.txtDiemSo.Location = new System.Drawing.Point(102, 164);
            this.txtDiemSo.Name = "txtDiemSo";
            this.txtDiemSo.Size = new System.Drawing.Size(403, 20);
            this.txtDiemSo.TabIndex = 30;
            // 
            // txtDiemChu
            // 
            this.txtDiemChu.Location = new System.Drawing.Point(102, 190);
            this.txtDiemChu.Name = "txtDiemChu";
            this.txtDiemChu.Size = new System.Drawing.Size(403, 20);
            this.txtDiemChu.TabIndex = 29;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(49, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Điểm Số";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(43, 193);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Điểm Chữ";
            // 
            // txtLanThi
            // 
            this.txtLanThi.Location = new System.Drawing.Point(102, 138);
            this.txtLanThi.Name = "txtLanThi";
            this.txtLanThi.Size = new System.Drawing.Size(403, 20);
            this.txtLanThi.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Lần Thi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(229, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 31);
            this.label2.TabIndex = 20;
            this.label2.Text = "ĐIỂM THI";
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(331, 234);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 31;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(430, 234);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 23);
            this.btnThoat.TabIndex = 32;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // comboBoxMaMH
            // 
            this.comboBoxMaMH.FormattingEnabled = true;
            this.comboBoxMaMH.Location = new System.Drawing.Point(102, 111);
            this.comboBoxMaMH.Name = "comboBoxMaMH";
            this.comboBoxMaMH.Size = new System.Drawing.Size(403, 21);
            this.comboBoxMaMH.TabIndex = 33;
            this.comboBoxMaMH.SelectedIndexChanged += new System.EventHandler(this.comboBoxMaMH_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 114);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 34;
            this.label7.Text = "Mã Môn Học";
            // 
            // comboBoxMaSV
            // 
            this.comboBoxMaSV.FormattingEnabled = true;
            this.comboBoxMaSV.Location = new System.Drawing.Point(102, 84);
            this.comboBoxMaSV.Name = "comboBoxMaSV";
            this.comboBoxMaSV.Size = new System.Drawing.Size(403, 21);
            this.comboBoxMaSV.TabIndex = 35;
            this.comboBoxMaSV.SelectedIndexChanged += new System.EventHandler(this.comboBoxMaSV_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(27, 87);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 13);
            this.label8.TabIndex = 36;
            this.label8.Text = "Mã Sinh Viên";
            // 
            // frmThemDMDiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 397);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.comboBoxMaSV);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBoxMaMH);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txtDiemSo);
            this.Controls.Add(this.txtDiemChu);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtLanThi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "frmThemDMDiem";
            this.Text = "frmThemDMDiem";
            this.Load += new System.EventHandler(this.frmThemDMDiem_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDiemSo;
        private System.Windows.Forms.TextBox txtDiemChu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtLanThi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.ComboBox comboBoxMaMH;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxMaSV;
        private System.Windows.Forms.Label label8;
    }
}