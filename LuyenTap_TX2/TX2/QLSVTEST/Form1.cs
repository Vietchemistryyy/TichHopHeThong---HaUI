using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSVTEST
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
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Student s = new Student();
            s.id = txtID.Text;
            s.name = txtName.Text;
            s.age = txtAge.Text;
            s.city = txtCity.Text;
            data.AddStudent(s);
            ClearTextBox();
            DisplayData();
        }
        private void ClearTextBox()
        {
            txtID.Clear();
            txtName.Clear();
            txtAge.Clear();
            txtCity.Clear();
            ActiveControl = txtID;
        }
        private void DisplayData()
        {
            dataGridView1.DataSource = data.GetAllStudent();
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 250;
            dataGridView1.Columns[2].Width = 50;
            dataGridView1.Columns[3].Width = 200;
            lblCount.Text = dataGridView1.Rows.Count.ToString();
        }
        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void GetAStudent(object sender, DataGridViewCellEventArgs e)
        {
            Student s = (Student)dataGridView1.CurrentRow.DataBoundItem;
            txtID.Text = s.id;
            txtName.Text = s.name;
            txtAge.Text = s.age;
            txtCity.Text = s.city;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Student s = new Student();
            s.id = txtID.Text;
            s.name = txtName.Text;
            s.age = txtAge.Text;
            s.city = txtCity.Text;
            bool check = data.UpdateStudent(s);
            if (!check)
            {
                MessageBox.Show("Không cập nhật được sinh viên có id = " + s.id);
            }
            DisplayData();
            MessageBox.Show("Cập nhật thành công!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", 
                "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (d == DialogResult.Yes) 
            { 
                bool check = data.DeleteStudent(txtID.Text);
                if (!check) 
                {
                    MessageBox.Show("Có lỗi khi xóa. ", "Thông báo");
                    return;
                }
                DisplayData();
                ClearTextBox();
            }
        }

        private void btnFindByID_Click(object sender, EventArgs e)
        {
            string id = txtID.Text;
            List<Student> li = new List<Student>();
            Student s = data.FindByID(id);
            if (s != null) 
            { 
                li.Add(s);
                dataGridView1.DataSource = li;
                lblCount.Text = dataGridView1.Rows.Count + "";   
                txtID.Text = s.id;
                txtName.Text = s.name;
                txtAge.Text = s.age;
                txtCity.Text = s.city;  
            }
            else
            {
                MessageBox.Show("Không có sinh viên có mã id = " + id, "Thông báo");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearTextBox();
        }
    }
}
