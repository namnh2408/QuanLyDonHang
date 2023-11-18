using QuanLyDonHang.Model;
using QuanLyDonHang.Services;
using QuanLyDonHang.View.Main;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDonHang.View.Login
{
    public partial class FrmLogin : Form
    {
        string QuyenTruyCap = "";
        int roleId = 0;
        string err;
        UserService userServices = new UserService();
        
        

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        public FrmLogin()
        {
            InitializeComponent();
            rdoNhanVien.Checked = true;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtUserName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập", "Đăng nhập", MessageBoxButtons.OK);
                return;
            }

            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu", "Đăng nhập", MessageBoxButtons.OK);
                return;
            }

            var signin = new Signin
            {
                UserName = txtUserName.Text,
                Password = txtPassword.Text,
                RoleId = roleId
            };

            var isLogin = userServices.LoginUser(signin, ref err);

            if (isLogin)
            {
                //MessageBox.Show("Đăng nhập hệ thống thành công", "Đăng nhập");

                frmMain frm = new frmMain();
                frm.WindowState = FormWindowState.Maximized;

                frm.userInfo = userServices.userInfo;

                frm.Show();
                this.Hide();
            }
            else
            {
                if (!string.IsNullOrEmpty(err))
                {
                    MessageBox.Show(err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại.Vui lòng thử lại !", "Đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void rdoAdmin_CheckedChanged(object sender, EventArgs e)
        {
            QuyenTruyCap = "Admin";
            roleId = 1;
        }

        private void pnlTittle_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }


        private void rdoNhanVien_CheckedChanged(object sender, EventArgs e)
        {
            QuyenTruyCap = "NhanVien";
            roleId = 2;
        }
    }
}
