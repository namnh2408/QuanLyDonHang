using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDonHang.View.FormControl
{
    public partial class uc_ChiTietPhieuThu : UserControl
    {
        public uc_PhieuThu uc_PhieuThu;
        public uc_ChiTietPhieuThu()
        {
            InitializeComponent();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            uc_PhieuThu.Show();
            this.Hide();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

        }

        private void btnTiepTuc_Click(object sender, EventArgs e)
        {

        }
    }
}
