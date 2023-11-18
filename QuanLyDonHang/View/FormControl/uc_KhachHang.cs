﻿using QuanLyDonHang.Model;
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
    public partial class uc_KhachHang : UserControl
    {
        public UserService userService = new UserService();

        private string err = "";

        bool inserted = false;
        bool updated = false;

        private int userID = 0;
        public uc_KhachHang()
        {
            InitializeComponent();
        }

        /// <summary>
        /// cho phép theo tác với các control
        /// </summary>
        /// <param name="isChange"></param>
        /// <param name="funcNo"> 0: Huỷ   1 : Thêm  2: Sửa</param>
        private void EnabledControl(bool isChange = false, int funcNo = 0)
        {
            if (!isChange)
            {
                txtHoTen.Enabled = false;
                txtEmail.Enabled = false;
                mskPhone.Enabled = false;
                txtAddress.Enabled = false;

                btnLuu.Enabled = false;
                btnHuy.Enabled = false;

                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnThem.Enabled = true;
            }
            else
            {
                txtHoTen.Enabled = true;
                txtEmail.Enabled = true;
                mskPhone.Enabled = true;
                txtAddress.Enabled = true;
            }

            switch (funcNo)
            {
                case 0:
                    txtHoTen.ResetText();
                    txtEmail.ResetText();
                    txtAddress.ResetText();

                    mskPhone.ResetText();

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

                    btnLuu.BackColor = Color.BlueViolet;
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

                    btnLuu.BackColor = Color.BlueViolet;
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

        private void uc_KhachHang_Load(object sender, EventArgs e)
        {
            EnabledControl(false);

            LoadData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            inserted = true;
            updated = false;

            EnabledControl(inserted, 1);

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
                    if (this.txtHoTen.Text == "")
                    {
                        epvKhachHang.SetError(this.txtHoTen, "!");
                        MessageBox.Show("Bạn chưa nhập số điện thoại khách hàng!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        epvKhachHang.Clear();
                        this.txtHoTen.Focus();

                        return;
                    }

                    if (this.mskPhone.Text == "")
                    {
                        epvKhachHang.SetError(this.mskPhone, "!");
                        MessageBox.Show("Bạn chưa nhập số điện thoại khách hàng!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        epvKhachHang.Clear();
                        this.mskPhone.Focus();

                        return;
                    }

                    var userCreate = new CreateUser
                    {
                        Fullname = txtHoTen.Text,
                        Address = txtAddress.Text,
                        Phone = mskPhone.Text.Replace(" ", ""),
                        Email = txtEmail.Text,
                        IsActive = 1,
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
                        Fullname = txtHoTen.Text,
                        Address = txtAddress.Text,
                        Phone = mskPhone.Text.Replace(" ", ""),
                        Email = txtEmail.Text,
                        IsActive = 1,
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
                if (userID <= 0)
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Xoá", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvKhachHang.CurrentCell.RowIndex;

            var id = dgvKhachHang.Rows[r].Cells[0].Value.ToString();
            userID = Convert.ToInt32(string.IsNullOrEmpty(id) ? "0" : id);


            this.txtHoTen.Text = dgvKhachHang.Rows[r].Cells[1].Value.ToString();
            this.mskPhone.Text = dgvKhachHang.Rows[r].Cells[2].Value.ToString();
            this.txtEmail.Text = dgvKhachHang.Rows[r].Cells[3].Value.ToString();
            this.txtAddress.Text = dgvKhachHang.Rows[r].Cells[4].Value.ToString();
        }

        private void LoadData()
        {
            try
            {
                dgvKhachHang.ReadOnly = true;
                dgvKhachHang.DataSource = userService.GetListUser(ref err);

                dgvKhachHang.AutoResizeColumns();

                txtHoTen.ResetText();
                txtEmail.ResetText();
                txtAddress.ResetText();

                mskPhone.ResetText();
            }
            catch
            {
                MessageBox.Show(err, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
