using QuanLyDonHang.Model;
using QuanLyDonHang.Services;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyDonHang.View.FormControl
{
    public partial class uc_ThongTinCaNhan : UserControl
    {
        public UserService userService = new UserService();

        private string err = "";

        private bool updated = false;

        public uc_ThongTinCaNhan()
        {
            InitializeComponent();
        }

        private void EnabledControl(bool isChange = false, int funcNo = 0)
        {
            if (!isChange)
            {
                txtTaiKhoan.Enabled = false;
                txtMatKhau.Enabled = false;
                txtHoTen.Enabled = false;
                txtCode.Enabled = false;
                txtEmail.Enabled = false;
                txtAddress.Enabled = false;
                mskPhone.Enabled = false;
                cboGioiTinh.Enabled = false;
                cboQuyen.Enabled = false;

                btnLuu.Enabled = false;
                btnHuy.Enabled = false;
                
                btnSua.Enabled = true;
            }
            else
            {
               
                txtMatKhau.Enabled = true;
                txtHoTen.Enabled = true;
                //txtCode.Enabled = true;
                txtEmail.Enabled = true;
                txtAddress.Enabled = true;
                mskPhone.Enabled = true;
                cboGioiTinh.Enabled = true;
              
            }

            switch (funcNo)
            {
                case 0:
                   
                    btnLuu.Enabled = false;
                    btnHuy.Enabled = false;
                    btnSua.Enabled = true;

                    btnLuu.BackColor = Color.Gray;
                    btnLuu.ForeColor = Color.WhiteSmoke;

                    btnHuy.BackColor = Color.Gray;
                    btnHuy.ForeColor = Color.WhiteSmoke;
                   
                    btnSua.BackColor = Color.Blue;
                    btnSua.ForeColor = Color.White;

                    break;

                case 2:
                    txtMatKhau.ResetText();

                    btnLuu.Enabled = true;
                    btnHuy.Enabled = true;
                    btnSua.Enabled = false;

                    btnLuu.BackColor = Color.CornflowerBlue;
                    btnLuu.ForeColor = Color.White;

                    btnHuy.BackColor = Color.IndianRed;
                    btnHuy.ForeColor = Color.WhiteSmoke;

                    btnSua.BackColor = Color.Gray;
                    btnSua.ForeColor = Color.WhiteSmoke;

                    break;

                default:
                    break;
            }
        }

        private void uc_ThongTinCaNhan_Load(object sender, EventArgs e)
        {
            EnabledControl();
            LoadData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            updated = true;

            EnabledControl(updated, 2);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (updated)
                {
                    if (userService.userInfo.UserID <= 0)
                    {
                        MessageBox.Show("Bạn chưa chọn nhân viên cần sửa", "Thông tin cá nhân", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var userUpdate = new UpdateUser
                    {
                        ID = userService.userInfo.UserID,
                        Code = txtCode.Text,
                        UserName = txtTaiKhoan.Text,
                        Password = txtMatKhau.Text,
                        Fullname = txtHoTen.Text,
                        Address = txtAddress.Text,
                        Phone = mskPhone.Text.Replace(" ", ""),
                        Email = txtEmail.Text,
                        RoleID = (int)cboQuyen.SelectedValue,
                        IsActive = 1,
                        Gender = cboGioiTinh.SelectedItem.ToString()
                    };

                    var isUpdated = userService.Update(userUpdate, userService.userInfo, ref err);

                    if (isUpdated)
                    {
                        MessageBox.Show("Cập nhật thông tin thành công", "Thông tin cá nhân", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        updated = false;
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thất bại:\n" + err.ToString(), "Thông tin cá nhân", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                EnabledControl();
                LoadData();
            }
            catch
            {
                MessageBox.Show(err, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadData()
        {
            try
            {
                var user = userService.GetUserInfo(ref err);

                txtTaiKhoan.Text = user.UserName;
                txtHoTen.Text = user.Fullname;
                txtEmail.Text = user.Email;
                mskPhone.Text = user.Phone;

                cboGioiTinh.Text = user.Gender;
                cboQuyen.DataSource = userService.RoleUserSelect();
                cboQuyen.ValueMember = "ID";
                cboQuyen.DisplayMember = "Name";

                cboQuyen.SelectedValue = user.RoleID;

                txtAddress.Text = user.Address;
                txtCode.Text = user.Code;

                txtMatKhau.Text = "123456789";
            }
            catch
            {
                MessageBox.Show(err, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            updated = false;
            EnabledControl();

            LoadData();
        }
    }
}