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
            client.BaseAddress = new Uri("http://localhost/apiqlsach/api/");
        }
        public void DisplayHeader()
        {
            dgv.Columns[0].HeaderText = "Mã sách";
            dgv.Columns[1].HeaderText = "Tên sách";
            dgv.Columns[2].HeaderText = "Thể loại";
            dgv.Columns[3].HeaderText = "Nhà xuất bản";
            dgv.Columns[4].HeaderText = "Số lượng";
            dgv.Columns[0].Width = 80;
            dgv.Columns[1].Width = 200;
            dgv.Columns[2].Width = 150;
            dgv.Columns[3].Width = 150;
            dgv.Columns[4].Width = 80;
        }
        private async Task getAllData()
        {
            HttpResponseMessage respone = await client.GetAsync("getall");
            string js = await respone.Content.ReadAsStringAsync();
            List<Sach> datagetall = JsonConvert.DeserializeObject<List<Sach>>(js);
            dgv.DataSource = datagetall;
            DisplayHeader();
            dgv.ReadOnly = true;
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
            if (string.IsNullOrEmpty(txtMaSach.Text)
                || string.IsNullOrEmpty(txtTenSach.Text)
                || string.IsNullOrEmpty(txtTheLoai.Text)
                || string.IsNullOrEmpty(txtNhaXuatBan.Text)
                || string.IsNullOrEmpty(txtSoLuong.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }
            if (!int.TryParse(txtSoLuong.Text, out _))
            {
                MessageBox.Show("Số lượng phải là số");
                return;
            }
            Sach s = new Sach();
            s.MaSach = txtMaSach.Text;
            s.TenSach = txtTenSach.Text;
            s.TheLoai = txtTheLoai.Text;
            s.NhaXuatBan = txtNhaXuatBan.Text;
            s.SoLuong = int.Parse(txtSoLuong.Text);
            string js = JsonConvert.SerializeObject(s, Formatting.Indented);
            var send = new StringContent(js, Encoding.UTF8, "application/json");
            HttpResponseMessage respone = await client.PostAsync("post", send);
            MessageBox.Show(await respone.Content.ReadAsStringAsync(), "Thông báo");
            await getAllData();
        }

        private void getARecord(object sender, DataGridViewCellEventArgs e)
        {
            Sach chosen = (Sach)dgv.CurrentRow.DataBoundItem;
            txtMaSach.Text = chosen.MaSach;
            txtTenSach.Text = chosen.TenSach;
            txtTheLoai.Text = chosen.TheLoai;
            txtNhaXuatBan.Text = chosen.NhaXuatBan;
            txtSoLuong.Text = chosen.SoLuong.ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMaSach.Clear();
            txtTenSach.Clear();
            txtTheLoai.Clear();
            txtNhaXuatBan.Clear();
            txtSoLuong.Clear();
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaSach.Text)
                || string.IsNullOrEmpty(txtTenSach.Text)
                || string.IsNullOrEmpty(txtTheLoai.Text)
                || string.IsNullOrEmpty(txtNhaXuatBan.Text)
                || string.IsNullOrEmpty(txtSoLuong.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }
            if (!int.TryParse(txtSoLuong.Text, out _))
            {
                MessageBox.Show("Số lượng phải là số");
                return;
            }
            Sach s = new Sach();
            s.MaSach = txtMaSach.Text;  
            s.TenSach = txtTenSach.Text;
            s.TheLoai = txtTheLoai.Text;
            s.NhaXuatBan = txtNhaXuatBan.Text;
            s.SoLuong = int.Parse(txtSoLuong.Text);
            string js = JsonConvert.SerializeObject(s, Formatting.Indented);
            var send = new StringContent(js, Encoding.UTF8, "application/json");
            HttpResponseMessage respone = await client.PutAsync("put", send);
            MessageBox.Show(await respone.Content.ReadAsStringAsync(), "Thông báo");
            await getAllData();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            string id = txtMaSach.Text;
            DialogResult d = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d == DialogResult.Yes)
            {
                HttpResponseMessage respone = await client.DeleteAsync($"delete/{id}");
                MessageBox.Show(await respone.Content.ReadAsStringAsync(), "Thông báo");
                await getAllData();
            }
        }
    }
}
