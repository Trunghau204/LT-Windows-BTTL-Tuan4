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
    public partial class FormNhanVien : Form
    {
        public string MaNV { get; set; }
        public string TenNV { get; set; }
        public decimal LuongCoBan { get; set; }
        public FormNhanVien()
        {
            InitializeComponent();
        }


        private void btnAccept_Click(object sender, EventArgs e)
        {
            MaNV = txtMssv.Text;
            TenNV = txtTenNhanVien.Text;
            LuongCoBan = decimal.Parse(txtLuongCB.Text);

            DialogResult = DialogResult.OK;
        }

        private void btnSkip_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
