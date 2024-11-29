using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppDataListView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Student> students;
        private void Form1_Load(object sender, EventArgs e)
        {
            students = new List<Student>();
            students.Add(new Student(1,"a",20));
            students.Add(new Student(2,"a",22));
            students.Add(new Student(3,"a",23));
            dtaNhanVien.DataSource = students;
        }


        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            try
            {
                Student s = new Student()
                {
                    id = int.Parse(txtId.Text),
                    name = txtName.Text,
                    age = int.Parse(txtAge.Text)
                };

                students.Add(s);
                RefreshGrid();
                MessageBox.Show("Thêm sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm sinh viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtaNhanVien.CurrentRow != null)
                {
                    int index = dtaNhanVien.CurrentRow.Index; // Lấy dòng hiện tại
                    students[index].id = int.Parse(txtId.Text);
                    students[index].name = txtName.Text;
                    students[index].age = int.Parse(txtAge.Text);
                    RefreshGrid();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một sinh viên để sửa.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa sinh viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtaNhanVien.CurrentRow != null)
                {
                    int index = dtaNhanVien.CurrentRow.Index; // Lấy dòng hiện tại
                    students.RemoveAt(index); // Xóa phần tử theo chỉ mục
                    RefreshGrid();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một sinh viên để xóa.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa sinh viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshGrid()
        {
            dtaNhanVien.DataSource = null; // Hủy liên kết nguồn dữ liệu
            dtaNhanVien.DataSource = new BindingList<Student>(students); // Cập nhật lại
        }

    }
    
}
