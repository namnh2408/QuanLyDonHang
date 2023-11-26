using QuanLyDonHang.Lib;
using QuanLyDonHang.View.FormControl;
using QuanLyDonHang.View.Login;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace QuanLyDonHang.View.Main
{
    public partial class frmMain : Form
    {
        public UserInfo userInfo;

        private uc_QuanLyTaiKhoan uc_QuanLyTaiKhoan;
        private uc_ChatLieu uc_ChatLieu;
        private uc_HinhThucGiaoHang uc_HinhThucGiaoHang;
        private uc_HinhThucThanhToan uc_HinhThucThanhToan;
        private uc_ThiCong uc_ThiCong;

        private uc_KhachHang uc_KhachHang;
        private uc_SanPham uc_SanPham;

        private uc_ThongTinCaNhan uc_ThongTinCaNhan;

        private uc_PhieuThu uc_PhieuThu;
        private uc_ChiTietPhieuThu uc_ChiTietPhieuThu;

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
            //if (MessageBox.Show("Bạn có chắc chắn muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //{
            //    Application.Exit();
            //}

            Application.Exit();
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

            uc_KhachHang = new uc_KhachHang();
            pnlDisplay.Controls.Add(uc_KhachHang);
            uc_KhachHang.Visible = false;

            uc_SanPham = new uc_SanPham();
            pnlDisplay.Controls.Add(uc_SanPham);
            uc_SanPham.Visible = false;

            uc_ThongTinCaNhan = new uc_ThongTinCaNhan();
            uc_ThongTinCaNhan.userService.userInfo = userInfo;
            pnlDisplay.Controls.Add(uc_ThongTinCaNhan);
            uc_ThongTinCaNhan.Visible = false;

            //uc_PhieuThu = new uc_PhieuThu();
            //pnlDisplay.Controls.Add(uc_PhieuThu);
            //uc_PhieuThu.Visible = false;

            //uc_ChiTietPhieuThu = new uc_ChiTietPhieuThu();
            //pnlDisplay.Controls.Add(uc_ChiTietPhieuThu);
            //uc_ChiTietPhieuThu.Visible = false;
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
            foreach (Control crtl in pnlDisplay.Controls)
            {
                crtl.Visible = false;
            }

            ptbTroVe.Visible = true;
            uc_ChatLieu.Visible = true;

            uc_ChatLieu.userInfo = userInfo;

            uc_ChatLieu.BringToFront();
        }

        private void btnThiCong_Click(object sender, EventArgs e)
        {
            foreach (Control crtl in pnlDisplay.Controls)
            {
                crtl.Visible = false;
            }

            ptbTroVe.Visible = true;
            uc_ThiCong.Visible = true;

            uc_ThiCong.userInfo = userInfo;

            uc_ThiCong.BringToFront();
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            foreach (Control crtl in pnlDisplay.Controls)
            {
                crtl.Visible = false;
            }

            ptbTroVe.Visible = true;
            uc_SanPham.Visible = true;

            uc_SanPham.userInfo = userInfo;
            uc_SanPham.BringToFront();
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

            ptbTroVe.Visible = true;
            uc_HinhThucGiaoHang.Visible = true;

            uc_HinhThucGiaoHang.userInfo = userInfo;
            uc_HinhThucGiaoHang.BringToFront();
        }

        private void btnPhieuGiaoHang_Click(object sender, EventArgs e)
        {
            foreach (Control crtl in this.pnlDisplay.Controls)
            {
                crtl.Visible = false;
            }

            uc_PhieuThu = new uc_PhieuThu();
            pnlDisplay.Controls.Add(uc_PhieuThu);
            //uc_PhieuThu.Visible = false;

            uc_ChiTietPhieuThu = new uc_ChiTietPhieuThu();
            pnlDisplay.Controls.Add(uc_ChiTietPhieuThu);
            uc_ChiTietPhieuThu.Visible = false;

            this.ptbTroVe.Visible = true;
            uc_PhieuThu.Visible = true;

            uc_PhieuThu.userInfo = userInfo;
            uc_PhieuThu.uc_ChiTietPhieuThu = uc_ChiTietPhieuThu;
            uc_PhieuThu.BringToFront();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            foreach (Control crtl in this.pnlDisplay.Controls)
            {
                crtl.Visible = false;
            }

            this.ptbTroVe.Visible = true;
            uc_KhachHang.Visible = true;

            uc_KhachHang.userInfo = userInfo;
            uc_KhachHang.BringToFront();
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
            btnPhieuGiaoHang_Click(null, null);
        }

        private void menuKhachHang_Click(object sender, EventArgs e)
        {
            btnCustomer_Click(null, null);
        }

        private void menuThoat_Click(object sender, EventArgs e)
        {
            btnExit_Click(null, null);
        }

        private void menuDangXuat_Click(object sender, EventArgs e)
        {
            btnlogout_Click(null, null);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            ptbTroVe_Click(null, null);
        }

        private void menuSanPham_Click(object sender, EventArgs e)
        {
            btnSanPham_Click(null, null);
        }

        private void btnCaNhan_Click(object sender, EventArgs e)
        {
            foreach (Control crtl in pnlDisplay.Controls)
            {
                crtl.Visible = false;
            }

            ptbTroVe.Visible = true;
            uc_ThongTinCaNhan.Visible = true;
            uc_ThongTinCaNhan.BringToFront();
        }

        private void frmMain_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Click");
        }

        private void frmMain_Leave(object sender, EventArgs e)
        {
            btnExit_Click(null, null);
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            // Confirm user wants to close
            switch (MessageBox.Show(this, "Bạn có chắc chắn muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.No:
                    e.Cancel = true;
                    break;
                default:
                    break;
            }
        }
    }
}