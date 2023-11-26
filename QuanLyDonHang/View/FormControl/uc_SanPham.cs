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
    public partial class uc_SanPham : UserControl
    {
        public UserInfo userInfo = new UserInfo();

        private ProductService productService = new ProductService();

        private string err = "";

        bool inserted = false;
        bool updated = false;

        private int customerID = 0;
        public uc_SanPham()
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
                txtCode.Enabled = false;
                txtTenSP.Enabled = false;
                txtGhiChu.Enabled = false;

                btnLuu.Enabled = false;
                btnHuy.Enabled = false;

                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnThem.Enabled = true;
            }
            else
            {
                txtCode.Enabled = true;
                txtTenSP.Enabled = true;  
                txtGhiChu.Enabled = true;
            }

            switch (funcNo)
            {
                case 0:
                    txtCode.ResetText();
                    txtTenSP.ResetText();
                    txtGhiChu.ResetText();

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
                    if (this.txtTenSP.Text == "")
                    {
                        epvKhachHang.SetError(this.txtTenSP, "!");
                        MessageBox.Show("Bạn chưa nhập tên sản phẩm!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        epvKhachHang.Clear();
                        this.txtCode.Focus();

                        return;
                    }

                    var productCreate = new ProductCreateModel
                    {
                        Code = txtCode.Text,
                        Name = txtTenSP.Text,
                        Note = txtGhiChu.Text,
                        IsActive = 1,
                    };

                    var isInsert = productService.CreateProduct(productCreate, userInfo, ref err);

                    if (isInsert)
                    {
                        MessageBox.Show("Thêm thành công", "Quản lý sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        inserted = false;
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại:\n" + err, "Quản lý sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (updated)
                {
                    if (customerID <= 0)
                    {
                        MessageBox.Show("Bạn chưa chọn sản phẩm muốn xoá", "Quản lý sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var productUpdate = new ProductUpdateModel
                    {
                        ID = customerID,
                        Code = txtCode.Text,
                        Note = txtGhiChu.Text,
                        Name = txtTenSP.Text,
                        IsActive = 1,
                    };

                    var isUpdated = productService.UpdateProduct(productUpdate, userInfo, ref err);

                    if (isUpdated)
                    {
                        MessageBox.Show("Cập nhật thông tin thành công", "Quản lý sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        updated = false;
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thất bại:\n" + err.ToString(), "Quản lý sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (customerID <= 0)
                {
                    MessageBox.Show("Bạn chưa chọn sản phẩm muốn xoá", "Quản lý sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult dialogResult = new DialogResult();

                dialogResult = MessageBox.Show("Bạn muốn xoá sản phẩm này ?", "Xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    var isDeleted = productService.DeleteProduct(customerID, userInfo, ref err);

                    if (isDeleted)
                    {
                        MessageBox.Show("Xoá thành công", "Quản lý sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Xoá thất bại\n" + err, "Quản lý sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            customerID = Convert.ToInt32(string.IsNullOrEmpty(id) ? "0" : id);


            this.txtCode.Text = dgvKhachHang.Rows[r].Cells[1].Value.ToString();
            this.txtTenSP.Text = dgvKhachHang.Rows[r].Cells[2].Value.ToString();
            this.txtGhiChu.Text = dgvKhachHang.Rows[r].Cells[3].Value.ToString();
        }

        private void LoadData()
        {
            try
            {
                dgvKhachHang.ReadOnly = true;
                dgvKhachHang.DataSource = productService.GetListProduct(ref err);

                dgvKhachHang.AutoResizeColumns();

                txtCode.ResetText();
                txtTenSP.ResetText();
                txtGhiChu.ResetText();
            }
            catch
            {
                MessageBox.Show(err, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
