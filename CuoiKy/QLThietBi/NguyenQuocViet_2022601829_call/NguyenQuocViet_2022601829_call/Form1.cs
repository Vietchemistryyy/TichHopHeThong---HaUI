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
            client.BaseAddress = new Uri("http://localhost/apiqltb/api/");
        }
        public void DisplayHeader()
        {
            dgv.Columns[0].HeaderText = "Mã thiết bị";
            dgv.Columns[1].HeaderText = "Tên thiết bị";
            dgv.Columns[2].HeaderText = "Loại";
            dgv.Columns[3].HeaderText = "Giá bán";
            dgv.Columns[0].Width = 100;
            dgv.Columns[1].Width = 200;
            dgv.Columns[2].Width = 100;
            dgv.Columns[3].Width = 100;
        }
        private async Task getAllData()
        {
            HttpResponseMessage respone = await client.GetAsync("getall");
            string js = await respone.Content.ReadAsStringAsync();
            List<ThietBi> datagetall = JsonConvert.DeserializeObject<List<ThietBi>>(js);
            dgv.DataSource = datagetall;
            DisplayHeader();
        }
        private async void Form1_Load(object sender, EventArgs e)
        {
            await getAllData();
        }

        private void getARecord(object sender, DataGridViewCellEventArgs e)
        {
            ThietBi chosen = (ThietBi)dgv.CurrentRow.DataBoundItem;
            txtMaTB.Text = chosen.MaTB;
            txtTenTB.Text = chosen.TenTB;
            txtLoai.Text = chosen.Loai;
            txtGiaBan.Text = chosen.GiaBan.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaTB.Text)
                || string.IsNullOrEmpty(txtTenTB.Text)
                || string.IsNullOrEmpty(txtLoai.Text)
                || string.IsNullOrEmpty(txtGiaBan.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }
            if (!double.TryParse(txtGiaBan.Text, out _))
            {
                MessageBox.Show("Giá bán phải là số");
                return;
            }
            ThietBi tb = new ThietBi();
            tb.MaTB = txtMaTB.Text;
            tb.TenTB = txtTenTB.Text;
            tb.Loai = txtLoai.Text;
            tb.GiaBan = double.Parse(txtGiaBan.Text);
            string js = JsonConvert.SerializeObject(tb, Formatting.Indented);
            var send = new StringContent(js, Encoding.UTF8, "application/json");
            HttpResponseMessage respone = await client.PostAsync("post", send);
            MessageBox.Show(await respone.Content.ReadAsStringAsync(), "Thông báo");
            await getAllData();
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaTB.Text)
                || string.IsNullOrEmpty(txtTenTB.Text)
                || string.IsNullOrEmpty(txtLoai.Text)
                || string.IsNullOrEmpty(txtGiaBan.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }
            if (!double.TryParse(txtGiaBan.Text, out _))
            {
                MessageBox.Show("Giá bán phải là số");
                return;
            }
            ThietBi tb = new ThietBi();
            tb.MaTB = txtMaTB.Text;
            tb.TenTB = txtTenTB.Text;
            tb.Loai = txtLoai.Text;
            tb.GiaBan = double.Parse(txtGiaBan.Text);
            string js = JsonConvert.SerializeObject(tb, Formatting.Indented);
            var send = new StringContent(js, Encoding.UTF8, "application/json");
            HttpResponseMessage respone = await client.PutAsync("put", send);
            MessageBox.Show(await respone.Content.ReadAsStringAsync(), "Thông báo");
            await getAllData();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            string id = txtMaTB.Text;
            DialogResult d = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d == DialogResult.Yes)
            {
                HttpResponseMessage respone = await client.DeleteAsync($"delete/{id}");
                MessageBox.Show(await respone.Content.ReadAsStringAsync(), "Thông báo");
                await getAllData();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtGiaBan.Clear();
            txtLoai.Clear();
            txtMaTB.Clear();
            txtTenTB.Clear();
        }
    }
}
