using QuanLyDonHang.Lib;
using QuanLyDonHang.Model;
using QuanLyDonHang.Services;
using QuanLyDonHang.View.Main;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyDonHang.View.FormControl
{
    public partial class uc_PhieuThu : UserControl
    {
        private uc_ChiTietPhieuThu uc_ChiTietPhieuThu;
        public UserInfo userInfo;

        private CustomerService customerService = new CustomerService();
        private PaymentTypeService paymentTypeService = new PaymentTypeService();
        private DeliveryTypeService deliveryTypeService = new DeliveryTypeService();

        private OrderService orderService = new OrderService();

        private string err;
        private bool update = false;
        private int orderID = 0;
        private string actionSearch = "";

        private frmMain frmMain;

        public uc_PhieuThu(frmMain frmMain)
        {
            InitializeComponent();
            this.frmMain = frmMain;
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
                txtOrderCode.Enabled = false;
                cboKhachHang.Enabled = false;
                mskPhone.Enabled = false;
                txtAddress.Enabled = false;

                cboThanhToan.Enabled = false;
                cboGiaoHang.Enabled = false;
                dtpNgay.Enabled = false;
                txtGhiChu.Enabled = false;

                txtTotalPrice.Enabled = false;
                txtPrePayment.Enabled = false;
                txtVAT.Enabled = false;
                txtFinalMoney.Enabled = false;

                btnLuu.Enabled = false;
                btnHuy.Enabled = false;

                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnThem.Enabled = true;

                btnSearch.Enabled = true;
                btnXemChiTiet.Enabled = true;
            }
            else
            {
                txtOrderCode.Enabled = false;
                cboKhachHang.Enabled = true;
                mskPhone.Enabled = true;
                txtAddress.Enabled = true;

                cboThanhToan.Enabled = true;
                cboGiaoHang.Enabled = true;
                dtpNgay.Enabled = true;
                txtGhiChu.Enabled = true;

                txtTotalPrice.Enabled = false;
                txtPrePayment.Enabled = true;
                txtVAT.Enabled = true;
                txtFinalMoney.Enabled = false;
            }

            switch (funcNo)
            {
                case 0:

                    // Set lại trạng thái tìm kiếm
                    actionSearch = "";

                    btnLuu.Enabled = false;
                    btnHuy.Enabled = false;

                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                    btnThem.Enabled = true;

                    btnSearch.Enabled = true;
                    btnXemChiTiet.Enabled = true;

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

                    btnSearch.BackColor = Color.SkyBlue;
                    btnSearch.ForeColor = Color.White;

                    btnXemChiTiet.BackColor = Color.SandyBrown;
                    btnXemChiTiet.ForeColor = Color.White;

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

                    btnSearch.Enabled = false;
                    btnXemChiTiet.Enabled = false;

                    btnSearch.BackColor = Color.Gray;
                    btnSearch.ForeColor = Color.WhiteSmoke;

                    btnXemChiTiet.BackColor = Color.Gray;
                    btnXemChiTiet.ForeColor = Color.WhiteSmoke;
                    break;

                case 2:
                    btnLuu.Enabled = true;
                    btnHuy.Enabled = true;

                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                    btnThem.Enabled = false;

                    btnLuu.BackColor = Color.CornflowerBlue;
                    btnLuu.ForeColor = Color.White;

                    btnHuy.BackColor = Color.IndianRed;
                    btnHuy.ForeColor = Color.White;

                    btnThem.BackColor = Color.Gray;
                    btnSua.BackColor = Color.Gray;
                    btnXoa.BackColor = Color.Gray;

                    btnThem.ForeColor = Color.WhiteSmoke;
                    btnSua.ForeColor = Color.WhiteSmoke;
                    btnXoa.ForeColor = Color.WhiteSmoke;

                    btnSearch.Enabled = false;
                    btnXemChiTiet.Enabled = false;

                    btnSearch.BackColor = Color.Gray;
                    btnSearch.ForeColor = Color.WhiteSmoke;

                    btnXemChiTiet.BackColor = Color.Gray;
                    btnXemChiTiet.ForeColor = Color.WhiteSmoke;

                    break;

                default:
                    break;
            }
        }

        private void CallDisplayFrmMain(string ACTION = "", UserInfo USERINFO = null, int ORDERID = 0)
        {
            try
            {
                foreach (Control crtl in frmMain.pnlDisplay.Controls)
                {
                    crtl.Visible = false;
                }

                uc_ChiTietPhieuThu = new uc_ChiTietPhieuThu(this);
                uc_ChiTietPhieuThu.Visible = true;
                uc_ChiTietPhieuThu.uc_PhieuThu = this;
                uc_ChiTietPhieuThu.userInfo = USERINFO;
                uc_ChiTietPhieuThu.action = ACTION;
                uc_ChiTietPhieuThu.orderID = ORDERID;

                frmMain.pnlDisplay.Controls.Add(uc_ChiTietPhieuThu);

                this.Visible = false;

                uc_ChiTietPhieuThu.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nInnerException: " + ex.InnerException, "Phiếu giao hàng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string actionThem = "THEM";

            CallDisplayFrmMain(actionThem, userInfo);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            update = true;
            EnabledControl(true, 2);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (orderID <= 0)
                {
                    MessageBox.Show("Bạn chưa chọn phiếu giao hàng muốn xoá", "Phiếu giao hàng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult dialogResult = new DialogResult();

                dialogResult = MessageBox.Show("Bạn muốn xoá phiếu giao hàng này ?", "Xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    var isDeleted = orderService.DeleteOrder(orderID, userInfo, ref err);

                    if (isDeleted)
                    {
                        MessageBox.Show("Xoá thành công", "Phiếu giao hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Xoá thất bại\n" + err, "Phiếu giao hàng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nInnerException: " + ex.InnerException, "Phiếu giao hàng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            EnabledControl();
            LoadData();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtOrderCode.Text == "")
                {
                    epvKhachHang.SetError(this.txtOrderCode, "!");
                    MessageBox.Show("Chưa có Mã phiếu thu", "Lập phiếu giao hàng",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    epvKhachHang.Clear();
                    this.txtOrderCode.Focus();

                    return;
                }

                if (cboGiaoHang.Text == "")
                {
                    epvKhachHang.SetError(this.cboGiaoHang, "!");
                    MessageBox.Show("Vui lòng chọn hình thức giao hàng", "Lập phiếu giao hàng",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    epvKhachHang.Clear();
                    this.cboGiaoHang.Focus();

                    return;
                }

                if (cboThanhToan.Text == "")
                {
                    epvKhachHang.SetError(this.cboThanhToan, "!");
                    MessageBox.Show("Vui lòng chọn hình thức thanh toán", "Lập phiếu giao hàng",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    epvKhachHang.Clear();
                    this.cboThanhToan.Focus();

                    return;
                }

                if (string.IsNullOrEmpty(txtPrePayment.Text))
                {
                    txtPrePayment.Text = "0";
                }

                if (update)
                {
                    var orderUpdate = new OrderUpdateModel
                    {
                        ID = orderID,
                        Code = txtOrderCode.Text,
                        CustomerID = (int)cboKhachHang.SelectedValue,
                        Address = txtAddress.Text,
                        Phone = mskPhone.Text.Replace(" ", ""),
                        OrderDate = dtpNgay.Value.ToString("dd/MM/yyyy HH:mm:ss"),
                        PaymentTypeID = (int)cboThanhToan.SelectedValue,
                        DeliveryTypeID = (int)cboGiaoHang.SelectedValue,
                        Note = txtGhiChu.Text,
                        TotalMoney = Convert.ToDecimal(txtTotalPrice.Text),
                        VAT = Convert.ToDecimal(txtVAT.Text),
                        PrePayment = Convert.ToDecimal(txtPrePayment.Text),
                        FinalMoney = Convert.ToDecimal(txtFinalMoney.Text),
                    };

                    orderUpdate.Details = null;

                    var isUpdate = orderService.UpdateOrder(orderUpdate, userInfo, ref err);

                    if (isUpdate)
                    {
                        MessageBox.Show("Cập nhật thành công", "Phiếu giao hàng");
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thất bại", "Phiếu giao hàng");
                    }

                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nInnerException: " + ex.InnerException, "Phiếu giao hàng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            btnThem.BackColor = Color.Gray;
            btnSua.BackColor = Color.Gray;
            btnXoa.BackColor = Color.Gray;

            btnThem.ForeColor = Color.WhiteSmoke;
            btnSua.ForeColor = Color.WhiteSmoke;
            btnXoa.ForeColor = Color.WhiteSmoke;

            if (actionSearch == "")
            {
                txtOrderCode.Enabled = true;
                cboKhachHang.Enabled = true;
                dtpNgay.Enabled = true;

                actionSearch = "TIMKIEM";

                btnSearch.BackColor = Color.MediumAquamarine;

                btnHuy.Enabled = true;
                btnHuy.BackColor = Color.IndianRed;
                btnHuy.ForeColor = Color.White;
            }
            else if (actionSearch == "TIMKIEM")
            {
                var orderSearch = new OrderSearchModel
                {
                    Code = txtOrderCode.Text ?? "",
                    CustomerID = cboKhachHang.SelectedValue == null ? 0 : (int)cboKhachHang.SelectedValue,
                    OrderDate = dtpNgay.Value.ToString("dd/MM/yyy") ?? ""
                };

                var orderFinds = orderService.FindOrder(orderSearch, ref err);

                if (orderSearch == null)
                {
                    MessageBox.Show(err, "Phiếu giao hàng", MessageBoxButtons.OK);
                    return;
                }

                dgvKhachHang.DataSource = orderFinds;

                //actionSearch = "";

                //btnSearch.BackColor = Color.SkyBlue;

                //btnHuy.Enabled = false;
                //btnHuy.BackColor = Color.Gray;
                //btnHuy.ForeColor = Color.WhiteSmoke;
            }
        }

        private void uc_PhieuThu_Load(object sender, EventArgs e)
        {
            this.dgvKhachHang.ResumeLayout();

            LoadData();

            EnabledControl();
        }

        private void LoadData()
        {
            try
            {
                // generate code order
                //txtOrderCode.Text = orderService.OrderGenerateCode();

                // Khách hàng
                this.cboKhachHang.DataSource = customerService.CustomerSelect();
                this.cboKhachHang.ValueMember = "ID";
                this.cboKhachHang.DisplayMember = "Name";

                // Giao hàng
                this.cboGiaoHang.DataSource = deliveryTypeService.DeliveryTypeSelect();
                this.cboGiaoHang.ValueMember = "ID";
                this.cboGiaoHang.DisplayMember = "Name";

                // thanh toán
                this.cboThanhToan.DataSource = paymentTypeService.PaymentTypeSelect();
                this.cboThanhToan.ValueMember = "ID";
                this.cboThanhToan.DisplayMember = "Name";

                var orders = orderService.GetListOrder(ref err);

                if (orders != null)
                {
                    dgvKhachHang.DataSource = orders;
                }
                else
                {
                    MessageBox.Show(err, "Phiếu giao hàng", MessageBoxButtons.OK);
                }
                EnabledControl();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Phiếu giao hàng", MessageBoxButtons.OK);
            }
        }

        private void cboKhachHang_TextChanged(object sender, EventArgs e)
        {
            var customerID = cboGiaoHang.SelectedValue == null ? 0 : Convert.ToInt32(cboKhachHang.SelectedValue);

            var customer = customerService.GetCustomer(customerID);

            if (customer != null)
            {
                mskPhone.Text = customer.Phone;
                txtAddress.Text = customer.Address;
            }
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int r = dgvKhachHang.CurrentCell.RowIndex;

                var id = dgvKhachHang.Rows[r].Cells[0].Value.ToString();
                orderID = Convert.ToInt32(id);

                var order = orderService.GetOrder(orderID, ref err);

                if (order != null)
                {
                    txtOrderCode.Text = order.Code;
                    cboKhachHang.SelectedValue = order.CustomerID;
                    txtAddress.Text = order.Address;
                    mskPhone.Text = order.Phone;

                    cboThanhToan.SelectedValue = order.PaymentTypeID;
                    cboGiaoHang.SelectedValue = order.DeliveryTypeID;
                    dtpNgay.Value = DateTime.ParseExact(order.OrderDate, "dd/MM/yyyy HH:mm:ss", null);
                    txtGhiChu.Text = order.Note;


                    txtTotalPrice.Text = order.TotalMoney > 0 ? order.TotalMoney.ToString("#,###") : "0";
                    txtVAT.Text = order.VAT.ToString();
                    txtPrePayment.Text = order.PrePayment > 0 ? order.PrePayment.ToString("#,###") : "0";
                    txtFinalMoney.Text = order.FinalMoney > 0 ? order.FinalMoney.ToString("#,###") : "0";
                }
                else
                {
                    MessageBox.Show(err, "Phiếu giao hàng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nInnerException: " + ex.InnerException, "Phiếu giao hàng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            if (orderID <= 0)
            {
                MessageBox.Show("Bạn chưa chọn phiếu giao hàng muốn xem", "Phiếu giao hàng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CallDisplayFrmMain("XEMCHITIET", userInfo, orderID);
        }
    }
}