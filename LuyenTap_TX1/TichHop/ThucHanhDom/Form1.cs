using System;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace ThucHanhDom
{
    public partial class Form1 : Form
    {
        string xmlFile = "thongtincuocgoi.xml";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!File.Exists(xmlFile))
            {
                MessageBox.Show("Không tìm thấy file XML: " + xmlFile, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            hienthi();
        }

        private void hienthi()
        {
            cbChiNhanh.Items.Clear();
            cbSoDien.Items.Clear();
            lvThongTinCuocGoi.Items.Clear();

            XmlDocument doc = new XmlDocument();
            doc.Load(xmlFile);
            XmlNodeList list = doc.GetElementsByTagName("cuocgoi");

            foreach (XmlNode node in list)
            {
                string sodien = node.Attributes["sodien"].Value;
                string chinhanh = node.Attributes["chinhanh"].Value;
                string sogoiden = node["sogoiden"].InnerText;
                string ngaygoi = node["ngaygoi"].InnerText;
                string sophut = node["sophut"].InnerText;

                if (!cbChiNhanh.Items.Contains(chinhanh)) cbChiNhanh.Items.Add(chinhanh);
                if (!cbSoDien.Items.Contains(sodien)) cbSoDien.Items.Add(sodien);

                ListViewItem item = new ListViewItem(sodien);
                item.SubItems.Add(chinhanh);
                item.SubItems.Add(sogoiden);
                item.SubItems.Add(ngaygoi);
                item.SubItems.Add(sophut);
                lvThongTinCuocGoi.Items.Add(item);
            }
        }

        private void them()
        {
            if (cbSoDien.Text == "" || cbChiNhanh.Text == "" || txtSoGoiDen.Text == "" || txtNgayGoi.Text == "" || txtSoPhut.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            XmlDocument doc = new XmlDocument();
            doc.Load(xmlFile);

            // Kiểm tra trùng số gọi đến
            XmlNodeList list = doc.GetElementsByTagName("cuocgoi");
            foreach (XmlNode node in list)
            {
                if (node["sogoiden"].InnerText == txtSoGoiDen.Text)
                {
                    MessageBox.Show("Số gọi đến đã tồn tại!", "Trùng dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            XmlElement root = doc.DocumentElement;

            XmlElement cuocgoi = doc.CreateElement("cuocgoi");
            cuocgoi.SetAttribute("sodien", cbSoDien.Text);
            cuocgoi.SetAttribute("chinhanh", cbChiNhanh.Text);

            XmlElement sogoiden = doc.CreateElement("sogoiden");
            sogoiden.InnerText = txtSoGoiDen.Text;

            XmlElement ngaygoi = doc.CreateElement("ngaygoi");
            ngaygoi.InnerText = txtNgayGoi.Text;

            XmlElement sophut = doc.CreateElement("sophut");
            sophut.InnerText = txtSoPhut.Text;

            cuocgoi.AppendChild(sogoiden);
            cuocgoi.AppendChild(ngaygoi);
            cuocgoi.AppendChild(sophut);

            root.AppendChild(cuocgoi);
            doc.Save(xmlFile);
            hienthi();
            MessageBox.Show("Đã thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void sua()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlFile);
            XmlNodeList list = doc.GetElementsByTagName("cuocgoi");

            foreach (XmlNode node in list)
            {
                if (node["sogoiden"].InnerText == txtSoGoiDen.Text)
                {
                    node.Attributes["sodien"].Value = cbSoDien.Text;
                    node.Attributes["chinhanh"].Value = cbChiNhanh.Text;
                    node["ngaygoi"].InnerText = txtNgayGoi.Text;
                    node["sophut"].InnerText = txtSoPhut.Text;

                    doc.Save(xmlFile);
                    hienthi();
                    MessageBox.Show("Đã sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            MessageBox.Show("Không tìm thấy số gọi đến để sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void xoa()
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa cuộc gọi này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes) return;

            XmlDocument doc = new XmlDocument();
            doc.Load(xmlFile);
            XmlNodeList list = doc.GetElementsByTagName("cuocgoi");

            foreach (XmlNode node in list)
            {
                if (node["sogoiden"].InnerText == txtSoGoiDen.Text)
                {
                    doc.DocumentElement.RemoveChild(node);
                    doc.Save(xmlFile);
                    hienthi();
                    MessageBox.Show("Đã xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            MessageBox.Show("Không tìm thấy số gọi đến để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnThem_Click(object sender, EventArgs e) => them();
        private void btnSua_Click(object sender, EventArgs e) => sua();
        private void btnXoa_Click(object sender, EventArgs e) => xoa();
        private void btnThoat_Click(object sender, EventArgs e) => this.Close();

        private void lvThongTinCuocGoi_Click(object sender, EventArgs e)
        {
            if (lvThongTinCuocGoi.SelectedItems.Count > 0)
            {
                ListViewItem item = lvThongTinCuocGoi.SelectedItems[0];
                cbSoDien.Text = item.SubItems[0].Text;
                cbChiNhanh.Text = item.SubItems[1].Text;
                txtSoGoiDen.Text = item.SubItems[2].Text;
                txtNgayGoi.Text = item.SubItems[3].Text;
                txtSoPhut.Text = item.SubItems[4].Text;
            }
        }

        private void cbSoDien_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Không yêu cầu xử lý gì thêm
        }
    }
}
