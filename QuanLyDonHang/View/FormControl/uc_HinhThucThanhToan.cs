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
    public partial class uc_HinhThucThanhToan : UserControl
    {
        public UserInfo userInfo = new UserInfo();

        private PaymentTypeService paymentTypeService = new PaymentTypeService();

        private string err = "";

        private bool inserted = false;
        private bool updated = false;

        private int deliveryID = 0;

        public uc_HinhThucThanhToan()
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

        private void uc_HinhThucThanhToan_Load(object sender, EventArgs e)
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
                        epvThanhToan.SetError(this.txtTen, "!");
                        MessageBox.Show("Bạn chưa nhập tên hình thức thanh toán!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        epvThanhToan.Clear();
                        this.txtTen.Focus();

                        return;
                    }

                    var commonCreate = new CommonTypeCreateModel
                    {
                        Name = txtTen.Text,
                    };

                    var isInsert = paymentTypeService.CreatePaymentType(commonCreate, userInfo, ref err);

                    if (isInsert)
                    {
                        MessageBox.Show("Thêm thành công", "Quản lý hình thức thanh toán", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        inserted = false;
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại:\n" + err, "Quản lý hình thức thanh toán", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (updated)
                {
                    if (deliveryID <= 0)
                    {
                        MessageBox.Show("Bạn chưa chọn hình thức thanh toán muốn xoá", "Quản lý hình thức thanh toán", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var commonUpdate = new CommonTypeUpdateModel
                    {
                        ID = deliveryID,
                        Name = txtTen.Text,
                    };

                    var isUpdated = paymentTypeService.UpdatePaymentType(commonUpdate, userInfo, ref err);

                    if (isUpdated)
                    {
                        MessageBox.Show("Cập nhật thông tin thành công", "Quản lý hình thức thanh toán", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        updated = false;
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thất bại:\n" + err.ToString(), "Quản lý hình thức thanh toán", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (deliveryID <= 0)
                {
                    MessageBox.Show("Bạn chưa chọn hình thức thanh toán muốn xoá", "Quản lý hình thức thanh toán", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult dialogResult = new DialogResult();

                dialogResult = MessageBox.Show("Bạn muốn xoá hình thức thanh toán này ?", "Xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    var isDeleted = paymentTypeService.DeletePaymentType(deliveryID, userInfo, ref err);

                    if (isDeleted)
                    {
                        MessageBox.Show("Xoá thành công", "Quản lý hình thức thanh toán", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Xoá thất bại\n" + err, "Quản lý hình thức thanh toán", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Quản lý hình thức thanh toán", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvThanhToan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvThanhToan.CurrentCell.RowIndex;

            var id = dgvThanhToan.Rows[r].Cells[0].Value.ToString();
            deliveryID = Convert.ToInt32(string.IsNullOrEmpty(id) ? "0" : id);

            this.txtTen.Text = dgvThanhToan.Rows[r].Cells[1].Value.ToString();

        }

        private void LoadData()
        {
            try
            {
                dgvThanhToan.ReadOnly = true;
                dgvThanhToan.DataSource = paymentTypeService.GetListPayment(ref err);

                dgvThanhToan.AutoResizeColumns();

                txtTen.ResetText();

            }
            catch
            {
                MessageBox.Show(err, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
