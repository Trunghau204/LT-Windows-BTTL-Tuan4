using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTTL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormNhanVien frmNhanVien = new FormNhanVien();
            if (frmNhanVien.ShowDialog() == DialogResult.OK)
            {
                ListViewItem dongMoi = new ListViewItem(frmNhanVien.MaNV);
                dongMoi.SubItems.Add(frmNhanVien.TenNV);
                dongMoi.SubItems.Add(frmNhanVien.LuongCoBan.ToString());
                listViewNhanVien.Items.Add(dongMoi);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (listViewNhanVien.SelectedItems.Count > 0)
            {
                ListViewItem dongDuocChon = listViewNhanVien.SelectedItems[0];
                FormNhanVien formNhanVien = new FormNhanVien
                {
                    MaNV = dongDuocChon.Text,
                    TenNV = dongDuocChon.SubItems[1].Text,
                    LuongCoBan = decimal.Parse(dongDuocChon.SubItems[2].Text)
                };

                if (formNhanVien.ShowDialog() == DialogResult.OK)
                {
                    dongDuocChon.Text = formNhanVien.MaNV;
                    dongDuocChon.SubItems[1].Text = formNhanVien.TenNV;
                    dongDuocChon.SubItems[2].Text = formNhanVien.LuongCoBan.ToString();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listViewNhanVien.SelectedItems.Count > 0)
            {
                List<ListViewItem> rm = new List<ListViewItem>();

                foreach (ListViewItem item in listViewNhanVien.SelectedItems)
                {
                    rm.Add(item);
                }

                foreach (ListViewItem item in rm)
                {
                    listViewNhanVien.Items.Remove(item);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn ít nhất một nhân viên để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

    }
}
