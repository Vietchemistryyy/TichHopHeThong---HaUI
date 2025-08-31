using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TruongHoc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DataUtil data = new DataUtil();
        private void button2_Click(object sender, EventArgs e) // Nút xóa
        {
            DialogResult d = MessageBox.Show("Bạn có chắc chắn muốn xóa không?",
                "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (d == DialogResult.Yes)
            {
                bool check = data.DeleteClass(txtMaLop.Text);
                if (!check)
                {
                    MessageBox.Show("Có lỗi khi xóa", "Thông báo");
                    return;
                }
                DisplayData();
                ClearTextBox();
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
        public void DisplayData()
        {
            dgv.DataSource = data.GetAllClass();
            dgv.Columns[0].HeaderText = "Mã lớp";
            dgv.Columns[1].HeaderText = "Phòng học";
            dgv.Columns[2].HeaderText = "Mã sinh viên";
            dgv.Columns[3].HeaderText = "Họ tên";
            dgv.Columns[4].HeaderText = "Địa chỉ";

            dgv.Columns[0].Width = 80;
            dgv.Columns[1].Width = 90;
            dgv.Columns[2].Width = 90;
            dgv.Columns[3].Width = 150;
            dgv.Columns[4].Width = 150;
        }
        public void ClearTextBox()
        {
            txtMaLop.Clear();
            txtMaSV.Clear();
            txtHoTen.Clear();
            txtPhongHoc.Clear();
            txtDiaChi.Clear();
            ActiveControl = txtMaLop;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Kiểm tra rỗng
            if (string.IsNullOrWhiteSpace(txtMaLop.Text) ||
                string.IsNullOrWhiteSpace(txtPhongHoc.Text) ||
                string.IsNullOrWhiteSpace(txtMaSV.Text) ||
                string.IsNullOrWhiteSpace(txtHoTen.Text) ||
                string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo");
                return;
            }
            // Kiểm tra trùng
            if (data.Exists(txtMaLop.Text))
            {
                MessageBox.Show("Trùng mã lớp!");
                return;
            }
            LopHoc lh = new LopHoc();
            lh.malop = txtMaLop.Text;
            lh.phonghoc = txtPhongHoc.Text;
            lh.masv = txtMaSV.Text;
            lh.hoten = txtHoTen.Text;
            lh.diachi = txtDiaChi.Text;
            data.AddClass(lh);
            DisplayData();
            ClearTextBox();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void GetARecord(object sender, DataGridViewCellEventArgs e)
        {
            LopHoc lh = (LopHoc)dgv.CurrentRow.DataBoundItem;
            txtMaLop.Text = lh.malop;
            txtPhongHoc.Text = lh.phonghoc;
            txtMaSV.Text = lh.masv;
            txtHoTen.Text = lh.hoten;
            txtDiaChi.Text = lh.diachi;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearTextBox();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LopHoc lh = new LopHoc();
            lh.malop = txtMaLop.Text;
            lh.phonghoc = txtPhongHoc.Text;
            lh.masv = txtMaSV.Text;
            lh.hoten = txtHoTen.Text;
            lh.diachi = txtDiaChi.Text;
            bool check = data.UpdateClass(lh);
            if (!check)
            {
                MessageBox.Show("Không cập nhật lớp học có mã lớp = " + lh.malop);
                return;
            }
            DisplayData();
            MessageBox.Show("Cập nhật thành công!");
        }

        private void txtPhongCanTim_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnFindPhong(object sender, EventArgs e)
        {
            string phong = txtPhongCanTim.Text.Trim();

            if (string.IsNullOrEmpty(phong))
            {
                MessageBox.Show("Vui lòng nhập tên phòng cần tìm!", "Thông báo"
                    , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var res = data.FindPhongHoc(phong);

            if (res != null && res.Count > 0)
            {
                dgv.DataSource = res;
            }
            else
            {
                MessageBox.Show("Không tìm thấy phòng phù hợp!", "Thông báo"
                    , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            ClearTextBox();
        }

        private void btnFindByDiaChi_Click(object sender, EventArgs e)
        {
            string diachi = txtDiaChi.Text;
            if (string.IsNullOrEmpty(diachi))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ cần tìm!", "Thông báo"
                    , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var res = data.FindDiaChi(diachi);
            if (res != null && res.Count > 0)
            {
                dgv.DataSource = res;
            }
            else
            {
                MessageBox.Show("Không tìm thấy địa chỉ phù hợp!", "Thông báo"
                    , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            ClearTextBox();
        }
    }
}
