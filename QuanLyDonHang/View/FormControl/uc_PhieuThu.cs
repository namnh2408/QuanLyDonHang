using QuanLyDonHang.Lib;
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
    public partial class uc_PhieuThu : UserControl
    {
        public uc_ChiTietPhieuThu uc_ChiTietPhieuThu;
        public UserInfo userInfo;

        public uc_PhieuThu()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            uc_ChiTietPhieuThu.Show();
            uc_ChiTietPhieuThu.uc_PhieuThu = this;
            this.Hide();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
        }
    }
}