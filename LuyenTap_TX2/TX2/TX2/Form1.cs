using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TX2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DataUtil data = new DataUtil();

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void DisplayData()
        {
            dataGridView1.DataSource = data.GetAllStudents();
            dataGridView1.Columns[0].Width = 250;
            dataGridView1.Columns[1].Width = 250;
            dataGridView1.Columns[2].Width = 50;
            dataGridView1.Columns[3].Width = 200;
            lblCount.Text = dataGridView1.Rows.Count + "";
        }   

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Student s = new Student();
            s.id = txtId.Text;
            s.name = txtName.Text;
            s.age = txtAge.Text;
            s.city = txtCity.Text;
            data.AddStudent(s);
            ClearTextBox();
            DisplayData();
        }
        private void ClearTextBox() 
        {
            txtId.Clear();
            txtName.Clear();
            txtAge.Clear();
            txtCity.Clear();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void GetAStudent(object sender, DataGridViewCellEventArgs e)
        {
            Student s = (Student)dataGridView1.CurrentRow.DataBoundItem;
            txtId.Text = s.id;
            txtName.Text = s.name;
            txtAge.Text = s.age;
            txtCity.Text = s.city;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Student s = new Student();
            s.id = txtId.Text;
            s.name = txtName.Text;
            s.age = txtAge.Text;
            s.city = txtCity.Text;
            bool check = data.UpdateStudent(s);
            if(!check)
            {
                MessageBox.Show("Không cập nhật được sinh viên có id =" + s.id);
                return;
            }    
            DisplayData();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearTextBox();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Bạn có chắc muốn xóa không?",
                "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (d == DialogResult.Yes) 
            {
                bool check = data.DeleteStudent(txtId.Text);
                if (!check) 
                {
                    MessageBox.Show("Có lỗi khi xóa.", "Thông báo");
                    return;
                }
                DisplayData();
                ClearTextBox(); 
            }
        }

        private void btnFindByID_Click(object sender, EventArgs e)
        {
            string id = txtId.Text;
            List<Student> li = new List<Student>();
            Student s = data.FindByID(id);
            if (s != null) { 
                li.Add(s);
                dataGridView1.DataSource = li;
                lblCount.Text = dataGridView1.Rows.Count + " ";
                txtId.Text = s.id;    
                txtName.Text = s.name;    
                txtAge.Text = s.age;    
                txtCity.Text = s.city;    
            }
            else
            {
                MessageBox.Show("Không có sinh viên có mã = " + id, "Thông báo");
            }
        }

        private void btnFindByCity_Click(object sender, EventArgs e)
        {
            string city = txtCity.Text;
            dataGridView1.DataSource = data.FindByCity(city);
            lblCount.Text = dataGridView1.Rows.Count + "";
            ClearTextBox();
            txtCity.Text = city;
        }
    }
}
