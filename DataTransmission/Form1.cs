using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataTransmission
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public delegate void delPassData(TextBox text);


        private void btnSend_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            delPassData del = new delPassData(frm.funData);
            del(this.txtForm1);
            frm.Show();
        }
    }
}
