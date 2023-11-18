using QuanLyDonHang.Lib;
using QuanLyDonHang.View.FormControl;
using QuanLyDonHang.View.Login;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDonHang.View.Main
{
    public partial class frmMain : Form
    {
        public UserInfo userInfo;

        uc_QuanLyTaiKhoan uc_QuanLyTaiKhoan;
        uc_ChatLieu uc_ChatLieu;
        uc_HinhThucGiaoHang uc_HinhThucGiaoHang;
        uc_HinhThucThanhToan uc_HinhThucThanhToan;
        uc_ThiCong uc_ThiCong;


        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        public frmMain()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);

           
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            FrmLogin f = new FrmLogin();
            f.Show();
            this.Hide();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            uc_QuanLyTaiKhoan = new uc_QuanLyTaiKhoan();
            pnlDisplay.Controls.Add(uc_QuanLyTaiKhoan);
            uc_QuanLyTaiKhoan.Visible = false;

            uc_ChatLieu = new uc_ChatLieu();
            pnlDisplay.Controls.Add(uc_ChatLieu);
            uc_ChatLieu.Visible = false;

            uc_HinhThucGiaoHang = new uc_HinhThucGiaoHang();
            pnlDisplay.Controls.Add(uc_HinhThucGiaoHang);
            uc_HinhThucGiaoHang.Visible = false;

            uc_HinhThucThanhToan = new uc_HinhThucThanhToan();
            pnlDisplay.Controls.Add(uc_HinhThucThanhToan);
            uc_HinhThucThanhToan.Visible = false;

            uc_ThiCong = new uc_ThiCong();
            pnlDisplay.Controls.Add(uc_ThiCong);
            uc_ThiCong.Visible = false;
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            foreach (Control crtl in this.pnlDisplay.Controls)
            {
                crtl.Visible = false;
            }

            this.ptbTroVe.Visible = true;
            uc_QuanLyTaiKhoan.Visible = true;

            uc_QuanLyTaiKhoan.userService.userInfo = userInfo;

            this.uc_QuanLyTaiKhoan.BringToFront();
        }

        private void ptbTroVe_Click(object sender, EventArgs e)
        {
            foreach (Control crtl in this.pnlDisplay.Controls)
            {
                crtl.Visible = false;
            }

            ptbTroVe.Visible = false;

            btnChatLieu.Visible = true;
            btnNhanVien.Visible = true;
            btnPhieuGiaoHang.Visible = true;
            btnGiaoHang.Visible = true;
            btnThanhToan.Visible = true;
            btnThiCong.Visible = true;
            btnSanPham.Visible = true;
            btnCustomer.Visible = true;

        }

        private void btnChatLieu_Click(object sender, EventArgs e)
        {
            foreach (Control crtl in this.pnlDisplay.Controls)
            {
                crtl.Visible = false;
            }

            this.ptbTroVe.Visible = true;
            uc_ChatLieu.Visible = true;

            uc_ChatLieu.userInfo = userInfo;

            this.uc_ChatLieu.BringToFront();
        }

        private void btnThiCong_Click(object sender, EventArgs e)
        {

            foreach (Control crtl in this.pnlDisplay.Controls)
            {
                crtl.Visible = false;
            }

            this.ptbTroVe.Visible = true;
            uc_ThiCong.Visible = true;

            uc_ThiCong.userInfo = userInfo;

            this.uc_ThiCong.BringToFront();
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {

        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            foreach (Control crtl in this.pnlDisplay.Controls)
            {
                crtl.Visible = false;
            }

            this.ptbTroVe.Visible = true;
            uc_HinhThucThanhToan.Visible = true;

            uc_HinhThucThanhToan.userInfo = userInfo;

            this.uc_HinhThucThanhToan.BringToFront();
        }

        private void btnGiaoHang_Click(object sender, EventArgs e)
        {
            foreach (Control crtl in this.pnlDisplay.Controls)
            {
                crtl.Visible = false;
            }

            this.ptbTroVe.Visible = true;
            uc_HinhThucGiaoHang.Visible = true;

            uc_HinhThucGiaoHang.userInfo = userInfo;

            this.uc_HinhThucGiaoHang.BringToFront();
        }

        private void btnPhieuGiaoHang_Click(object sender, EventArgs e)
        {

        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {

        }

        private void menuNhanVien_Click(object sender, EventArgs e)
        {
            btnNhanVien_Click(null, null);
        }

        private void menuChatLieu_Click(object sender, EventArgs e)
        {
            btnChatLieu_Click(null, null);
        }

        private void menuThiCong_Click(object sender, EventArgs e)
        {
            btnThiCong_Click(sender, null);
        }

        private void menuThanhToan_Click(object sender, EventArgs e)
        {
            btnThanhToan_Click(null, null);
        }

        private void menuGiaoHang_Click(object sender, EventArgs e)
        {
            btnGiaoHang_Click(null, null);
        }

        private void menuPhieuGiaoHang_Click(object sender, EventArgs e)
        {

        }
    }
}
