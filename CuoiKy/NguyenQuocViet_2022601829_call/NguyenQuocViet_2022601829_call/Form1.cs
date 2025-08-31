using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NguyenQuocViet_2022601829_call
{
    public partial class Form1 : Form
    {
        HttpClient client = new HttpClient();

        public Form1()
        {
            InitializeComponent();
            client.BaseAddress = new Uri("http://192.168.2.100/apiqlsv/api/");
        }
        public void displayHeader()
        {
            dgv.Columns[0].HeaderText = "Mã sinh viên";
            dgv.Columns[0].Width = 100;
            dgv.Columns[1].HeaderText = "Họ tên";
            dgv.Columns[1].Width = 160;
            dgv.Columns[2].HeaderText = "Điểm trung bình";
            dgv.Columns[2].Width = 120;
            dgv.Columns[3].HeaderText = "Lớp";
            dgv.Columns[3].Width = 100;
        }
        private async Task getAllData()
        {
            HttpResponseMessage respone = await client.GetAsync("getAll");
            string js = await respone.Content.ReadAsStringAsync();
            List<SinhVien> data_getall = JsonConvert.DeserializeObject<List<SinhVien>>(js);
            dgv.DataSource = data_getall;
            cbbLop.DataSource = data_getall.Select(x => x.Lop).Distinct().ToList();
            dgv.ReadOnly = true;
            displayHeader();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await getAllData();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            SinhVien sv = new SinhVien();
            if (string.IsNullOrEmpty(txtMaSV.Text)
                || string.IsNullOrEmpty(txtTenSV.Text)
                || string.IsNullOrEmpty(txtDiemTB.Text)
                || string.IsNullOrEmpty(cbbLop.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }
            if (!float.TryParse(txtDiemTB.Text, out _))
            {
                MessageBox.Show("Điểm phải là số!");
                return;
            }
            sv.MaSV = txtMaSV.Text;
            sv.HoTen = txtTenSV.Text;
            sv.Lop = cbbLop.Text;
            sv.DiemTB = float.Parse(txtDiemTB.Text);
            string js = JsonConvert.SerializeObject(sv, Formatting.Indented);
            var send = new StringContent(js, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("post", send);
            MessageBox.Show(await response.Content.ReadAsStringAsync(), "Thông báo");
            await getAllData();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMaSV.Clear();
            txtTenSV.Clear();
            txtDiemTB.Clear();
            cbbLop.Text = "";
        }

        private void getARecord(object sender, DataGridViewCellEventArgs e)
        {
            SinhVien chosen = (SinhVien)dgv.CurrentRow.DataBoundItem;
            txtMaSV.Text = chosen.MaSV;
            txtTenSV.Text = chosen.HoTen;
            txtDiemTB.Text = chosen.DiemTB.ToString();
            cbbLop.Text = chosen.Lop;
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            SinhVien sv = new SinhVien();
            sv.MaSV = txtMaSV.Text;
            sv.HoTen = txtTenSV.Text;
            sv.Lop = cbbLop.Text;
            sv.DiemTB = float.Parse(txtDiemTB.Text);
            string js = JsonConvert.SerializeObject(sv, Formatting.Indented);
            var send = new StringContent(js, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync("put", send);
            MessageBox.Show(await response.Content.ReadAsStringAsync(), "Thông báo");
            await getAllData();
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            SinhVien sv = new SinhVien();
            sv.MaSV = txtMaSV.Text;
            sv.HoTen = txtTenSV.Text;
            sv.Lop = cbbLop.Text;
            sv.DiemTB = float.Parse(txtDiemTB.Text);
            string js = JsonConvert.SerializeObject(sv, Formatting.Indented);
            var send = new StringContent(js, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync("put", send);
            MessageBox.Show(await response.Content.ReadAsStringAsync(), "Thông báo");
            await getAllData();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            string id = txtMaSV.Text;
            DialogResult d = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xác nhận xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d == DialogResult.Yes)
            {
                HttpResponseMessage response = await client.DeleteAsync($"delete/{id}");
                MessageBox.Show(await response.Content.ReadAsStringAsync(), "Thông báo");
                await getAllData();
            }
        }

        private async void btnFindByClass_Click(object sender, EventArgs e)
        {
            string lop = cbbLop.Text;
            HttpResponseMessage respone = await client.GetAsync($"getByClass/{lop}");
            string js = await respone.Content.ReadAsStringAsync();
            List<SinhVien> data_find = JsonConvert.DeserializeObject<List<SinhVien>>(js);
            dgv.DataSource = data_find;
            dgv.ReadOnly = true;
            if (data_find.Count > 0)
            {
                MessageBox.Show($"Tìm được {data_find.Count} sinh viên học lớp {lop}", "Kết quả");
                dgv.DataSource = data_find;
            }
            else
            {
                MessageBox.Show($"Không tìm được sinh viên nào học lớp {lop}", "Kết quả");
            }
        }
    }
}
