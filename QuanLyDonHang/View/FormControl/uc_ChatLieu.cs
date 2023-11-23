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
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace QuanLyDonHang.View.FormControl
{
    public partial class uc_ChatLieu : UserControl
    {
        public UserInfo userInfo = new UserInfo();

        private MaterialTypeService materialTypeService = new MaterialTypeService();

        private string err = "";

        private bool inserted = false;
        private bool updated = false;

        private int materialID = 0;

        public uc_ChatLieu()
        {
            InitializeComponent();
        }

        private void EnabledControl(bool isChange = false, int funcNo = 0)
        {
            if (!isChange)
            {
                txtTen.Enabled = false;

                btnLuu.Enabled = false;
                btnHuy.Enabled = false;

                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnThem.Enabled = true;
            }
            else
            {
                txtTen.Enabled = true;

            }

            switch (funcNo)
            {
                case 0:
                    txtTen.ResetText();


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

                    btnLuu.BackColor = Color.DeepSkyBlue;
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

        private void uc_ChatLieu_Load(object sender, EventArgs e)
        {
            EnabledControl();
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
                    if (this.txtTen.Text == "")
                    {
                        epvTaiKhoan.SetError(this.txtTen, "!");
                        MessageBox.Show("Bạn chưa nhập tên chất liệu!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        epvTaiKhoan.Clear();
                        this.txtTen.Focus();

                        return;
                    }

                    var commonCreate = new CommonTypeCreateModel
                    {
                        Name = txtTen.Text,
                    };

                    var isInsert = materialTypeService.CreateMaterialType(commonCreate, userInfo, ref err);

                    if (isInsert)
                    {
                        MessageBox.Show("Thêm thành công", "Quản lý chất liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        inserted = false;
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại:\n" + err, "Quản lý chất liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (updated)
                {
                    if (materialID <= 0)
                    {
                        MessageBox.Show("Bạn chưa chọn chất liệu muốn xoá", "Quản lý chất liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var commonUpdate = new CommonTypeUpdateModel
                    {
                        ID = materialID,
                        Name = txtTen.Text,
                    };

                    var isUpdated = materialTypeService.UpdateMaterialType(commonUpdate, userInfo, ref err);

                    if (isUpdated)
                    {
                        MessageBox.Show("Cập nhật thông tin thành công", "Quản lý chất liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        updated = false;
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thất bại:\n" + err.ToString(), "Quản lý chất liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (materialID <= 0)
                {
                    MessageBox.Show("Bạn chưa chọn loại chất liệu muốn xoá", "Quản lý chất liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult dialogResult = new DialogResult();

                dialogResult = MessageBox.Show("Bạn muốn xoá chất liệu này ?", "Xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    var isDeleted = materialTypeService.DeleteMaterialType(materialID, userInfo, ref err);

                    if (isDeleted)
                    {
                        MessageBox.Show("Xoá thành công", "Quản lý chất liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Xoá thất bại\n" + err, "Quản lý chất liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Quản lý chất liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvChatLieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvChatLieu.CurrentCell.RowIndex;

            var id = dgvChatLieu.Rows[r].Cells[0].Value.ToString();
            materialID = Convert.ToInt32(string.IsNullOrEmpty(id) ? "0" : id);

            this.txtTen.Text = dgvChatLieu.Rows[r].Cells[1].Value.ToString();

        }

        private void LoadData()
        {
            try
            {
                dgvChatLieu.ReadOnly = true;
                dgvChatLieu.DataSource = materialTypeService.GetListMaterial(ref err);

                dgvChatLieu.AutoResizeColumns();

                txtTen.ResetText();

            }
            catch
            {
                MessageBox.Show(err, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}