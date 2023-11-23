using QuanLyDonHang.Lib;
using QuanLyDonHang.Model;
using QuanLyDonHang.Services;
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
    public partial class uc_QuanLyTaiKhoan : UserControl
    {
        public UserService userService = new UserService();

        private string err = "";

        bool inserted = false;
        bool updated = false;

        private int userID = 0;
        public uc_QuanLyTaiKhoan()
        {
            InitializeComponent();
        }

        /// <summary>
        /// cho phép theo tác với các control
        /// </summary>
        /// <param name="isChange"></param>
        /// <param name="funcNo"> 0: Huỷ   1 : Thêm  2: Sửa</param>
        private void EnabledControl( bool isChange = false, int funcNo = 0)
        {
            if (!isChange)
            {
                txtCode.Enabled = false;
                txtHoTen.Enabled = false;
                txtTaiKhoan.Enabled = false;
                txtMatKhau.Enabled = false;
                txtEmail.Enabled = false;
                mskPhone.Enabled = false;
                txtAddress.Enabled = false;

                cboGioiTinh.Enabled = false;
                cboQuyen.Enabled = false;

                btnLuu.Enabled = false;
                btnHuy.Enabled = false;

                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnThem.Enabled = true;
            }
            else
            {
                txtCode.Enabled = true;
                txtHoTen.Enabled = true;
                txtTaiKhoan.Enabled = true;
                txtMatKhau.Enabled = true;
                txtEmail.Enabled = true;
                mskPhone.Enabled = true;
                txtAddress.Enabled = true;

                cboGioiTinh.Enabled = true;
                cboQuyen.Enabled = true;
            }

            switch (funcNo)
            {
                case 0:
                    txtCode.ResetText();
                    txtHoTen.ResetText();
                    txtEmail.ResetText();
                    txtAddress.ResetText();
                    txtTaiKhoan.ResetText();
                    txtMatKhau.ResetText();

                    mskPhone.ResetText();
                    cboGioiTinh.ResetText();
                    cboQuyen.ResetText();

                    btnLuu.Enabled = false;
                    btnHuy.Enabled = false;

                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                    btnThem.Enabled = true;

                    btnLuu.BackColor = Color.Gray;
                    btnHuy.BackColor = Color.Gray;

                    btnLuu.ForeColor = Color.WhiteSmoke;
                    btnHuy.ForeColor = Color.WhiteSmoke;

                    btnThem.BackColor = Color.Green;
                    btnSua.BackColor = Color.Blue;
                    btnXoa.BackColor = Color.Red;

                    btnThem.ForeColor = Color.White;
                    btnSua.ForeColor = Color.White;
                    btnXoa.ForeColor = Color.White;

                    break;
                case 1:
                    btnLuu.Enabled = true;
                    btnHuy.Enabled = true;

                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                    btnThem.Enabled = false;

                    btnLuu.BackColor = Color.CornflowerBlue;
                    btnHuy.BackColor = Color.IndianRed;

                    btnLuu.ForeColor = Color.White;
                    btnHuy.ForeColor = Color.White;

                    btnThem.BackColor = Color.Gray;
                    btnSua.BackColor = Color.Gray;
                    btnXoa.BackColor = Color.Gray;

                    btnThem.ForeColor = Color.WhiteSmoke;
                    btnSua.ForeColor = Color.WhiteSmoke;
                    btnXoa.ForeColor = Color.WhiteSmoke;
                    break;
                case 2:
                    btnLuu.Enabled = true;
                    btnHuy.Enabled = true;

                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                    btnThem.Enabled = false;

                    btnLuu.BackColor = Color.CornflowerBlue;
                    btnHuy.BackColor = Color.IndianRed;

                    btnLuu.ForeColor = Color.White;
                    btnHuy.ForeColor = Color.White;

                    btnThem.BackColor = Color.Gray;
                    btnSua.BackColor = Color.Gray;
                    btnXoa.BackColor = Color.Gray;

                    btnThem.ForeColor = Color.WhiteSmoke;
                    btnSua.ForeColor = Color.WhiteSmoke;
                    btnXoa.ForeColor = Color.WhiteSmoke;

                    break;
                default:
                    break;
            }            
        }

        private void uc_QuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            EnabledControl(false);

            LoadData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            inserted = true;
            updated = false;

            EnabledControl(inserted,1);
           
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            updated = true;
            inserted = false;

            EnabledControl(updated, 2);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            inserted = false;
            updated = false;

            EnabledControl(inserted, 0);
            LoadData();

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (inserted)
                {
                    if (this.txtTaiKhoan.Text == "")
                    {
                        epvTaiKhoan.SetError(this.txtTaiKhoan, "!");
                        MessageBox.Show("Bạn chưa nhập Tài khoản!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        epvTaiKhoan.Clear();
                        this.txtTaiKhoan.Focus();

                        return;
                    }

                    var userCreate = new CreateUser
                    {
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

                    var isInsert = userService.CreateUser(userCreate, userService.userInfo, ref err);

                    if (isInsert)
                    {
                        MessageBox.Show("Thêm thành công", "Quản lý nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        inserted = false;
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại:\n" + err, "Quản lý nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (updated)
                {
                    if (userID <= 0)
                    {
                        MessageBox.Show("Bạn chưa chọn nhân viên muốn xoá", "Quản lý nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var userUpdate = new UpdateUser
                    {
                        ID = userID,
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
                        MessageBox.Show("Cập nhật thông tin thành công", "Quản lý nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        updated = false;
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thất bại:\n" + err.ToString(), "Quản lý nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if( userID <= 0)
                {
                    MessageBox.Show("Bạn chưa chọn nhân viên muốn xoá", "Quản lý nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult dialogResult = new DialogResult();

                dialogResult = MessageBox.Show("Bạn muốn xoá nhân viên này ?", "Xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    var isDeleted = userService.Delete(userID, userService.userInfo, ref err);

                    if (isDeleted)
                    {
                        MessageBox.Show("Xoá thành công", "Quản lý nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Xoá thất bại\n" + err, "Quản lý nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Xoá", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvLogin_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvLogin.CurrentCell.RowIndex;

            var id = dgvLogin.Rows[r].Cells[0].Value.ToString();
            userID = Convert.ToInt32(string.IsNullOrEmpty(id) ? "0" : id);

            this.txtCode.Text = dgvLogin.Rows[r].Cells[1].Value.ToString();
            this.txtTaiKhoan.Text = dgvLogin.Rows[r].Cells[2].Value.ToString();
            this.txtHoTen.Text = dgvLogin.Rows[r].Cells[3].Value.ToString();
            this.cboGioiTinh.Text = dgvLogin.Rows[r].Cells[4].Value.ToString();
            this.mskPhone.Text = dgvLogin.Rows[r].Cells[5].Value.ToString();
            this.txtEmail.Text =  dgvLogin.Rows[r].Cells[6].Value.ToString();
            this.cboQuyen.Text = dgvLogin.Rows[r].Cells[7].Value.ToString();
            this.txtAddress.Text = dgvLogin.Rows[r].Cells[8].Value.ToString();
        }

        private void LoadData()
        {
            try
            {
                dgvLogin.ReadOnly = true;
                dgvLogin.DataSource = userService.GetListUser(ref err);

                dgvLogin.AutoResizeColumns();

                txtCode.ResetText();
                txtHoTen.ResetText();
                txtEmail.ResetText();
                txtAddress.ResetText();
                txtTaiKhoan.ResetText();
                txtMatKhau.ResetText();

                mskPhone.ResetText();
                cboGioiTinh.ResetText();
                cboQuyen.ResetText();

                var dataQuyen = userService.RoleUserSelect();
                cboQuyen.DataSource = dataQuyen;

                cboQuyen.ValueMember = "ID";
                cboQuyen.DisplayMember = "Name";
            }
            catch 
            {
                MessageBox.Show(err, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
