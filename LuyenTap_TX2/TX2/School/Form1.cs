using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DataUtil data = new DataUtil();
        private void ClearTextBox()
        {
            txtDiaChi.Clear();
            txtHoTen.Clear();
            txtMaLop.Clear();
            txtMaSV.Clear();
            txtPhongHoc.Clear();
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
            dgv.Columns[3].Width = 130;
            dgv.Columns[4].Width = 100;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearTextBox();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtHoTen.Text) ||
                string.IsNullOrEmpty(txtDiaChi.Text) ||
                string.IsNullOrEmpty(txtMaLop.Text) ||
                string.IsNullOrEmpty(txtMaSV.Text) ||
                string.IsNullOrEmpty(txtPhongHoc.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo");
                return;
            }
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Bạn có chắc chắn muốn xóa không?",
                "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
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
                MessageBox.Show("Sửa không thành công lớp học có mã lớp = " + lh.malop);
                return;
            }
            DisplayData();
            MessageBox.Show("Sửa thành công!");
        }

        private void btnFindByPhong_Click(object sender, EventArgs e)
        {

        }
    }
}
