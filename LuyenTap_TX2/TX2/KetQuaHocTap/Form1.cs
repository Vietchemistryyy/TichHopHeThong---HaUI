using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KetQuaHocTap
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DataUtil data = new DataUtil();
        public void DisplayData()
        {
            dgv.DataSource = data.GetAllSinhVien();

            dgv.Columns[0].HeaderText = "Mã SV";
            dgv.Columns[1].HeaderText = "Môn học";
            dgv.Columns[2].HeaderText = "Điểm lần 1";
            dgv.Columns[3].HeaderText = "Điểm lần 2";

        }
        public void ClearBox() 
        {
            cbbMaSV.Text = "";
            cbbMonHoc.Text = "";
            txtDiemLan1.Clear();
            txtDiemLan2.Clear();
        }
        public void LoadComboBox()
        {
            var list = data.GetAllSinhVien();
            cbbMaSV.DataSource = list.Select(sv => sv.masv).Distinct().ToList();
            cbbMonHoc.DataSource = list.Select(sv => sv.monhoc).Distinct().ToList();
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void GetARecord(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                SinhVien sv = (SinhVien)dgv.CurrentRow.DataBoundItem;
                cbbMaSV.Text = sv.masv;
                cbbMonHoc.Text = sv.monhoc;
                txtDiemLan1.Text = sv.diemlan1;
                txtDiemLan2.Text = sv.diemlan2;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbbMaSV.Text) ||
                string.IsNullOrWhiteSpace(cbbMonHoc.Text) ||
                string.IsNullOrWhiteSpace(txtDiemLan1.Text) ||
                string.IsNullOrWhiteSpace(txtDiemLan2.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }
            if (data.Exists(cbbMaSV.Text))
            {
                MessageBox.Show("Trùng mã sinh viên!");
                return;
            }

            SinhVien sv = new SinhVien();
            sv.masv = cbbMaSV.Text;
            sv.monhoc = cbbMonHoc.Text;
            sv.diemlan1 = txtDiemLan1.Text;
            sv.diemlan2 = txtDiemLan2.Text;

            data.AddSinhVien(sv);
            DisplayData();
            //LoadComboBox();
            ClearBox();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Bạn có chắc muốn xóa?", "Thông báo", MessageBoxButtons.YesNo);
            if (d == DialogResult.Yes)
            {
                bool check = data.DeleteSinhVien(cbbMaSV.Text);
                if (!check)
                {
                    MessageBox.Show("Không tìm thấy sinh viên!");
                    return;
                }
                DisplayData();
                ClearBox();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SinhVien sv = new SinhVien();
            sv.masv = cbbMaSV.Text;
            sv.monhoc = cbbMonHoc.Text;
            sv.diemlan1 = txtDiemLan1.Text;
            sv.diemlan2 = txtDiemLan2.Text;

            bool check = data.UpdateSinhVien(sv);
            if (!check)
            {
                MessageBox.Show("Không tìm thấy sinh viên có mã " + sv.masv);
                return;
            }
            DisplayData();
            MessageBox.Show("Cập nhật thành công!");
        }
    }
}
