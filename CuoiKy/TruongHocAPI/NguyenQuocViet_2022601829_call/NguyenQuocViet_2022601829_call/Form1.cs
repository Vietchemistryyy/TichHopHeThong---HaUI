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
            client.BaseAddress = new Uri("http://localhost/apischool/api/");
        }
        public void displayHeader()
        {
            dgv.Columns[0].HeaderText = "Mã lớp";
            dgv.Columns[1].HeaderText = "Phòng học";
            dgv.Columns[2].HeaderText = "Số sinh viên";
            dgv.Columns[3].HeaderText = "Chủ Nhiệm";
            dgv.Columns[0].Width = 100;
            dgv.Columns[1].Width = 100;
            dgv.Columns[2].Width = 100;
            dgv.Columns[3].Width = 150;
        }
        private async Task getAllData()
        {
            HttpResponseMessage respone = await client.GetAsync("getall");
            string js = await respone.Content.ReadAsStringAsync();
            List<LopHoc> datagetall = JsonConvert.DeserializeObject<List<LopHoc>>(js);
            dgv.DataSource = datagetall;
            displayHeader();
        }
        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await getAllData();
        }

        private void getARecord(object sender, DataGridViewCellEventArgs e)
        {
            LopHoc chosen = (LopHoc)dgv.CurrentRow.DataBoundItem;
            txtMaLop.Text = chosen.MaLop;
            txtPhongHoc.Text = chosen.PhongHoc;
            txtChuNhiem.Text = chosen.ChuNhiem;
            txtSoSinhVien.Text = chosen.SoSinhVien.ToString();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaLop.Text)
                || string.IsNullOrEmpty(txtChuNhiem.Text)
                || string.IsNullOrEmpty(txtPhongHoc.Text)
                || string.IsNullOrEmpty(txtSoSinhVien.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }
            if (!int.TryParse(txtSoSinhVien.Text, out _))
            {
                MessageBox.Show("Số sinh viên phải là số");
                return;
            }
            LopHoc lh = new LopHoc();
            lh.MaLop = txtMaLop.Text;
            lh.SoSinhVien = int.Parse(txtSoSinhVien.Text);
            lh.ChuNhiem = txtChuNhiem.Text;
            lh.PhongHoc = txtPhongHoc.Text;
            string js = JsonConvert.SerializeObject(lh, Formatting.Indented);
            var send = new StringContent(js, Encoding.UTF8, "application/json");
            HttpResponseMessage respone = await client.PostAsync("post", send);
            MessageBox.Show(await respone.Content.ReadAsStringAsync(), "Thông báo");
            await getAllData();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMaLop.Clear();
            txtPhongHoc.Clear();
            txtChuNhiem.Clear();
            txtSoSinhVien.Clear();
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaLop.Text)
                || string.IsNullOrEmpty(txtChuNhiem.Text)
                || string.IsNullOrEmpty(txtPhongHoc.Text)
                || string.IsNullOrEmpty(txtSoSinhVien.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }
            if (!int.TryParse(txtSoSinhVien.Text, out _))
            {
                MessageBox.Show("Số sinh viên phải là số");
                return;
            }
            LopHoc lh = new LopHoc();
            lh.MaLop = txtMaLop.Text;
            lh.SoSinhVien = int.Parse(txtSoSinhVien.Text);
            lh.ChuNhiem = txtChuNhiem.Text;
            lh.PhongHoc = txtPhongHoc.Text;
            string js = JsonConvert.SerializeObject(lh, Formatting.Indented);
            var send = new StringContent(js, Encoding.UTF8, "application/json");
            HttpResponseMessage respone = await client.PutAsync("put", send);
            MessageBox.Show(await respone.Content.ReadAsStringAsync(), "Thông báo");
            await getAllData();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            string id = txtMaLop.Text;
            DialogResult d = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xác nhận xóa",
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
