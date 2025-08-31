namespace ThucHanhDom
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelChiNhanh = new System.Windows.Forms.Label();
            this.labelSoGoiDi = new System.Windows.Forms.Label();
            this.labelSoGoiDen = new System.Windows.Forms.Label();
            this.labelNgayGoi = new System.Windows.Forms.Label();
            this.labelSoPhut = new System.Windows.Forms.Label();
            this.cbChiNhanh = new System.Windows.Forms.ComboBox();
            this.cbSoDien = new System.Windows.Forms.ComboBox();
            this.txtSoGoiDen = new System.Windows.Forms.TextBox();
            this.txtNgayGoi = new System.Windows.Forms.TextBox();
            this.txtSoPhut = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.lvThongTinCuocGoi = new System.Windows.Forms.ListView();
            this.colChiNhanh = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSoGoiDi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSoGoiDen = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNgayGoi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSoPhut = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.labelTitle.Location = new System.Drawing.Point(200, 20);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(488, 32);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "CẬP NHẬT THÔNG TIN CUỘC GỌI";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelChiNhanh
            // 
            this.labelChiNhanh.Location = new System.Drawing.Point(30, 80);
            this.labelChiNhanh.Name = "labelChiNhanh";
            this.labelChiNhanh.Size = new System.Drawing.Size(100, 23);
            this.labelChiNhanh.TabIndex = 1;
            this.labelChiNhanh.Text = "Chi nhánh";
            // 
            // labelSoGoiDi
            // 
            this.labelSoGoiDi.Location = new System.Drawing.Point(30, 120);
            this.labelSoGoiDi.Name = "labelSoGoiDi";
            this.labelSoGoiDi.Size = new System.Drawing.Size(100, 23);
            this.labelSoGoiDi.TabIndex = 3;
            this.labelSoGoiDi.Text = "Số gọi đi";
            // 
            // labelSoGoiDen
            // 
            this.labelSoGoiDen.Location = new System.Drawing.Point(30, 160);
            this.labelSoGoiDen.Name = "labelSoGoiDen";
            this.labelSoGoiDen.Size = new System.Drawing.Size(100, 23);
            this.labelSoGoiDen.TabIndex = 5;
            this.labelSoGoiDen.Text = "Số gọi đến";
            // 
            // labelNgayGoi
            // 
            this.labelNgayGoi.Location = new System.Drawing.Point(30, 200);
            this.labelNgayGoi.Name = "labelNgayGoi";
            this.labelNgayGoi.Size = new System.Drawing.Size(100, 23);
            this.labelNgayGoi.TabIndex = 7;
            this.labelNgayGoi.Text = "Ngày gọi";
            // 
            // labelSoPhut
            // 
            this.labelSoPhut.Location = new System.Drawing.Point(30, 240);
            this.labelSoPhut.Name = "labelSoPhut";
            this.labelSoPhut.Size = new System.Drawing.Size(100, 23);
            this.labelSoPhut.TabIndex = 9;
            this.labelSoPhut.Text = "Số phút";
            // 
            // cbChiNhanh
            // 
            this.cbChiNhanh.Location = new System.Drawing.Point(150, 75);
            this.cbChiNhanh.Name = "cbChiNhanh";
            this.cbChiNhanh.Size = new System.Drawing.Size(180, 28);
            this.cbChiNhanh.TabIndex = 2;
            // 
            // cbSoDien
            // 
            this.cbSoDien.Location = new System.Drawing.Point(150, 115);
            this.cbSoDien.Name = "cbSoDien";
            this.cbSoDien.Size = new System.Drawing.Size(180, 28);
            this.cbSoDien.TabIndex = 4;
            // 
            // txtSoGoiDen
            // 
            this.txtSoGoiDen.Location = new System.Drawing.Point(150, 155);
            this.txtSoGoiDen.Name = "txtSoGoiDen";
            this.txtSoGoiDen.Size = new System.Drawing.Size(180, 26);
            this.txtSoGoiDen.TabIndex = 6;
            // 
            // txtNgayGoi
            // 
            this.txtNgayGoi.Location = new System.Drawing.Point(150, 195);
            this.txtNgayGoi.Name = "txtNgayGoi";
            this.txtNgayGoi.Size = new System.Drawing.Size(180, 26);
            this.txtNgayGoi.TabIndex = 8;
            // 
            // txtSoPhut
            // 
            this.txtSoPhut.Location = new System.Drawing.Point(150, 235);
            this.txtSoPhut.Name = "txtSoPhut";
            this.txtSoPhut.Size = new System.Drawing.Size(180, 26);
            this.txtSoPhut.TabIndex = 10;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(370, 75);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(120, 30);
            this.btnThem.TabIndex = 11;
            this.btnThem.Text = "Thêm mới";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(370, 115);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(120, 30);
            this.btnSua.TabIndex = 12;
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(370, 155);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(120, 30);
            this.btnXoa.TabIndex = 13;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(370, 195);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(120, 30);
            this.btnThoat.TabIndex = 14;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // lvThongTinCuocGoi
            // 
            this.lvThongTinCuocGoi.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colChiNhanh,
            this.colSoGoiDi,
            this.colSoGoiDen,
            this.colNgayGoi,
            this.colSoPhut});
            this.lvThongTinCuocGoi.FullRowSelect = true;
            this.lvThongTinCuocGoi.GridLines = true;
            this.lvThongTinCuocGoi.HideSelection = false;
            this.lvThongTinCuocGoi.Location = new System.Drawing.Point(30, 290);
            this.lvThongTinCuocGoi.Name = "lvThongTinCuocGoi";
            this.lvThongTinCuocGoi.Size = new System.Drawing.Size(700, 160);
            this.lvThongTinCuocGoi.TabIndex = 15;
            this.lvThongTinCuocGoi.UseCompatibleStateImageBehavior = false;
            this.lvThongTinCuocGoi.View = System.Windows.Forms.View.Details;
            this.lvThongTinCuocGoi.Click += new System.EventHandler(this.lvThongTinCuocGoi_Click);
            // 
            // colChiNhanh
            // 
            this.colChiNhanh.Text = "Chi nhánh";
            this.colChiNhanh.Width = 140;
            // 
            // colSoGoiDi
            // 
            this.colSoGoiDi.Text = "Số gọi đi";
            this.colSoGoiDi.Width = 140;
            // 
            // colSoGoiDen
            // 
            this.colSoGoiDen.Text = "Số gọi đến";
            this.colSoGoiDen.Width = 140;
            // 
            // colNgayGoi
            // 
            this.colNgayGoi.Text = "Ngày gọi";
            this.colNgayGoi.Width = 140;
            // 
            // colSoPhut
            // 
            this.colSoPhut.Text = "Số phút";
            this.colSoPhut.Width = 100;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 470);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.labelChiNhanh);
            this.Controls.Add(this.cbChiNhanh);
            this.Controls.Add(this.labelSoGoiDi);
            this.Controls.Add(this.cbSoDien);
            this.Controls.Add(this.labelSoGoiDen);
            this.Controls.Add(this.txtSoGoiDen);
            this.Controls.Add(this.labelNgayGoi);
            this.Controls.Add(this.txtNgayGoi);
            this.Controls.Add(this.labelSoPhut);
            this.Controls.Add(this.txtSoPhut);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.lvThongTinCuocGoi);
            this.Name = "Form1";
            this.Text = "Cập nhật cuộc gọi";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelChiNhanh;
        private System.Windows.Forms.Label labelSoGoiDi;
        private System.Windows.Forms.Label labelSoGoiDen;
        private System.Windows.Forms.Label labelNgayGoi;
        private System.Windows.Forms.Label labelSoPhut;

        private System.Windows.Forms.ComboBox cbChiNhanh;
        private System.Windows.Forms.ComboBox cbSoDien;
        private System.Windows.Forms.TextBox txtSoGoiDen;
        private System.Windows.Forms.TextBox txtNgayGoi;
        private System.Windows.Forms.TextBox txtSoPhut;

        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThoat;

        private System.Windows.Forms.ListView lvThongTinCuocGoi;
        private System.Windows.Forms.ColumnHeader colChiNhanh;
        private System.Windows.Forms.ColumnHeader colSoGoiDi;
        private System.Windows.Forms.ColumnHeader colSoGoiDen;
        private System.Windows.Forms.ColumnHeader colNgayGoi;
        private System.Windows.Forms.ColumnHeader colSoPhut;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}
