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

namespace _2022601829_NguyenQuocViet_call
{
    public partial class Form1 : Form
    {
        HttpClient client = new HttpClient();
        public Form1()
        {
            InitializeComponent();
            client.BaseAddress = new Uri("http://192.168.2.100/apiqlnv/api/"); // Window + V để mở clipboard
        }
        public void displayHeader()
        {
            dgv.Columns[0].HeaderText = "Mã nhân viên";
            dgv.Columns[1].HeaderText = "Họ tên";
            dgv.Columns[2].HeaderText = "Trình độ";
            dgv.Columns[3].HeaderText = "Lương";
            dgv.Columns[0].Width = 100;
            dgv.Columns[1].Width = 150;
            dgv.Columns[2].Width = 100;
            dgv.Columns[3].Width = 120;
        }
        private async Task getAllData()
        {
            HttpResponseMessage respone = await client.GetAsync("dsnv");
            string js = await respone.Content.ReadAsStringAsync();
            List<NhanVien> getalldata = JsonConvert.DeserializeObject<List<NhanVien>>(js);
            dgv.DataSource = getalldata;
            dgv.ReadOnly = true;
            displayHeader();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await getAllData(); 
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            // Xử lý nhập thiếu
            if (string.IsNullOrEmpty(txtMaNV.Text)
                || string.IsNullOrEmpty(txtTenNV.Text)
                || string.IsNullOrEmpty(txtTrinhDo.Text)
                || string.IsNullOrEmpty(txtLuong.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }
            // Xử lý kiểu dữ liệu nhập cho lương
            if (!double.TryParse(txtLuong.Text, out _))
            {
                MessageBox.Show("Lương phải là số!");
                return;
            }
            NhanVien nv = new NhanVien();
            nv.MaNV = txtMaNV.Text;
            nv.HoTen = txtTenNV.Text;
            nv.TrinhDo = txtTrinhDo.Text;
            nv.Luong = double.Parse(txtLuong.Text);
            string js = JsonConvert.SerializeObject(nv, Formatting.Indented);
            var send = new StringContent(js, Encoding.UTF8, "application/json");
            HttpResponseMessage respone = await client.PostAsync("themnv", send);
            MessageBox.Show(await respone.Content.ReadAsStringAsync(), "Thông báo");
            await getAllData();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            string id = txtMaNV.Text.Trim();
            DialogResult d = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d == DialogResult.Yes)
            {
                HttpResponseMessage respone = await client.DeleteAsync($"xoanv/{id}");
                MessageBox.Show(await respone.Content.ReadAsStringAsync());
                await getAllData();
            }
        }

        private void getARecord(object sender, DataGridViewCellEventArgs e)
        {
            NhanVien chosen = (NhanVien)dgv.CurrentRow.DataBoundItem;
            txtMaNV.Text = chosen.MaNV;
            txtTenNV.Text = chosen.HoTen;
            txtTrinhDo.Text = chosen.TrinhDo;
            txtLuong.Text = chosen.Luong.ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMaNV.Clear();
            txtTenNV.Clear();
            txtLuong.Clear();
            txtTrinhDo.Clear();
        }
    }
}
