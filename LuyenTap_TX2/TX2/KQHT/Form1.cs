using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KQHT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DataUtil data = new DataUtil();
        private void Form1_Load(object sender, EventArgs e)
        {
            DisplayData();
            LoadComboBoxData();

        }
        private void LoadComboBoxData()
        {
            List<SinhVien> ds = data.GetAllData();
            var dsMaSV = ds.Select(sv => sv.masv).Distinct().ToList();
            var dsMonHoc = ds.Select(sv => sv.monhoc).Distinct().ToList();

            cbbMaSV.Items.Clear();
            cbbMonHoc.Items.Clear();

            foreach (var ma in dsMaSV)
                cbbMaSV.Items.Add(ma);
            foreach (var mh in dsMonHoc)
                cbbMonHoc.Items.Add(mh);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (data.Exists(cbbMaSV.Text))
            {
                MessageBox.Show("Mã sinh viên đã tồn tại. Không thể thêm trùng.");
                return;
            }
            SinhVien s = new SinhVien();
            s.masv = cbbMaSV.Text;
            s.monhoc = cbbMonHoc.Text;
            s.diemlan1 = txtDiemLan1.Text;
            s.diemlan2 = txtDiemLan2.Text; 
            data.Add(s);
            ClearBox();
            DisplayData();
            LoadComboBoxData();
        }
        public void DisplayData()
        {
            dataGridView1.DataSource = data.GetAllData();

            dataGridView1.Columns[0].HeaderText = "Mã SV";
            dataGridView1.Columns[1].HeaderText = "Môn học";
            dataGridView1.Columns[2].HeaderText = "Điểm lần 1";
            dataGridView1.Columns[3].HeaderText = "Điểm lần 2";

            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 80;
            dataGridView1.Columns[3].Width = 80;
        }
        public void ClearBox()
        {
            cbbMaSV.Text = "";
            cbbMonHoc.Text = "";
            txtDiemLan1.Clear();
            txtDiemLan2.Clear();
            ActiveControl = cbbMaSV;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SinhVien s = new SinhVien();
            s.masv = cbbMaSV.Text;
            s.monhoc = cbbMonHoc.Text;
            s.diemlan1 = txtDiemLan1.Text;
            s.diemlan2 = txtDiemLan2.Text ;
            bool check = data.Update(s);
            if (!check)
            {
                MessageBox.Show("Không cập nhật được sinh viên có mã sv = " + s.masv);
            }
            DisplayData();
            LoadComboBoxData();
            MessageBox.Show("Cập nhật thành công!");
        }

        private void GetARecord(object sender, DataGridViewCellEventArgs e)
        {
            SinhVien s = (SinhVien)dataGridView1.CurrentRow.DataBoundItem;
            cbbMaSV.Text = s.masv;
            cbbMonHoc.Text = s.monhoc;
            txtDiemLan1.Text = s.diemlan1;
            txtDiemLan2.Text = s.diemlan2;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Bạn có chắc muốn xóa không?",
                "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (d == DialogResult.Yes) 
            { 
                bool check = data.Delete(cbbMaSV.Text);
                if (!check) 
                {
                    MessageBox.Show("Có lỗi khi xóa.", "Thông Báo");
                    return;
                }
                DisplayData();
                LoadComboBoxData();
                ClearBox();
            }
        }
    }
}
