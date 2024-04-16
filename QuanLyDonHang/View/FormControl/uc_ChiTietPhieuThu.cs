using QuanLyDonHang.Lib;
using QuanLyDonHang.Model;
using QuanLyDonHang.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyDonHang.View.FormControl
{
    public partial class uc_ChiTietPhieuThu : UserControl
    {
        public uc_PhieuThu uc_PhieuThu;
        public UserInfo userInfo;

        /// <summary>
        /// Tên chức năng
        /// THEM, SUA, XOA, XEMCHITIET
        /// </summary>
        public string action;

        public int orderID = 0;

        private ProductService productService = new ProductService();
        private CustomerService customerService = new CustomerService();
        private PaymentTypeService paymentTypeService = new PaymentTypeService();
        private MaterialTypeService materialTypeService = new MaterialTypeService();
        private DeliveryTypeService deliveryTypeService = new DeliveryTypeService();
        private ConstructionTypeService constructionTypeService = new ConstructionTypeService();

        private OrderService orderService = new OrderService();

        private string err;
        private string historyAction;

        public uc_ChiTietPhieuThu(uc_PhieuThu uc_PhieuThu)
        {
            InitializeComponent();
            this.uc_PhieuThu = uc_PhieuThu;
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
                txtGhiChu.Enabled = false;

                dtpNgay.Enabled = false;

                txtTotalPrice.Enabled = false;
                txtVAT.Enabled = false;
                txtPrePayment.Enabled = false;
                txtFinalMoney.Enabled = false;

                btnLuu.Enabled = false;
                btnHuy.Enabled = false;

                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnTiepTuc.Enabled = true;
            }
            else
            {
                if(historyAction != "XEMCHITIET")
                {
                    cboKhachHang.ResetText();
                    cboThanhToan.ResetText();
                    cboGiaoHang.ResetText();

                    txtFinalMoney.Text = "0";
                    txtTotalPrice.Text = "0";
                    txtPrePayment.Text = "0";
                }
                

                //txtOrderCode.Enabled = true;

                cboKhachHang.Enabled = true;
                mskPhone.Enabled = true;
                txtAddress.Enabled = true;

                cboThanhToan.Enabled = true;
                cboGiaoHang.Enabled = true;
                txtGhiChu.Enabled = true;

                dtpNgay.Enabled = true;

                txtTotalPrice.Enabled = false;
                txtVAT.Enabled = true;
                txtPrePayment.Enabled = true;
                txtFinalMoney.Enabled = false;            
            }

            switch (funcNo)
            {
                case 0:
                    txtOrderCode.ResetText();
                    cboKhachHang.ResetText();
                    txtAddress.ResetText();
                    mskPhone.ResetText();

                    cboThanhToan.ResetText();
                    cboGiaoHang.ResetText();
                    dtpNgay.ResetText();
                    txtGhiChu.ResetText();

                    txtTotalPrice.ResetText();
                    txtVAT.ResetText();
                    txtPrePayment.ResetText();
                    txtFinalMoney.ResetText();

                    btnLuu.Enabled = false;
                    btnHuy.Enabled = false;

                    btnTiepTuc.Enabled = true;
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                    btnInPhieu.Enabled = true;
                    btnThem.Enabled = true;

                    btnLuu.BackColor = Color.Gray;
                    btnHuy.BackColor = Color.Gray;

                    btnLuu.ForeColor = Color.WhiteSmoke;
                    btnHuy.ForeColor = Color.WhiteSmoke;

                    btnSua.BackColor = Color.Blue;
                    btnXoa.BackColor = Color.Red;

                    btnSua.ForeColor = Color.White;
                    btnXoa.ForeColor = Color.White;

                    btnThem.BackColor = Color.IndianRed;
                    btnThem.ForeColor = Color.White;

                    btnInPhieu.BackColor = Color.CornflowerBlue;
                    btnInPhieu.ForeColor = Color.White;

                    btnTiepTuc.BackColor = Color.OrangeRed;
                    btnTiepTuc.ForeColor = Color.White;

                    break;

                case 1:                    
                    cboKhachHang.ResetText();
                    txtAddress.ResetText();
                    mskPhone.ResetText();

                    cboThanhToan.ResetText();
                    cboGiaoHang.ResetText();
                    dtpNgay.ResetText();
                    txtGhiChu.ResetText();

                    btnLuu.Enabled = true;
                    btnHuy.Enabled = true;

                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                    btnThem.Enabled = false;

                    btnLuu.BackColor = Color.CornflowerBlue;
                    btnHuy.BackColor = Color.IndianRed;

                    btnLuu.ForeColor = Color.White;
                    btnHuy.ForeColor = Color.White;

                    btnSua.BackColor = Color.Gray;
                    btnXoa.BackColor = Color.Gray;

                    btnSua.ForeColor = Color.WhiteSmoke;
                    btnXoa.ForeColor = Color.WhiteSmoke;

                    btnThem.BackColor = Color.Gray;
                    btnThem.ForeColor = Color.WhiteSmoke;

                    btnInPhieu.Enabled = false;
                    btnInPhieu.BackColor = Color.Gray;
                    btnInPhieu.ForeColor = Color.WhiteSmoke;

                    btnTiepTuc.Enabled = false;
                    btnTiepTuc.BackColor = Color.Gray;
                    btnTiepTuc.ForeColor = Color.WhiteSmoke;

                    dgvChiTiet.Rows.Clear();
                    dgvChiTiet.Refresh();

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

                    btnSua.BackColor = Color.Gray;
                    btnXoa.BackColor = Color.Gray;

                    btnSua.ForeColor = Color.WhiteSmoke;
                    btnXoa.ForeColor = Color.WhiteSmoke;

                    btnThem.BackColor = Color.Gray;
                    btnThem.ForeColor = Color.WhiteSmoke;

                    btnInPhieu.Enabled = false;
                    btnInPhieu.BackColor = Color.Gray;
                    btnInPhieu.ForeColor = Color.WhiteSmoke;

                    btnTiepTuc.Enabled = false;
                    btnTiepTuc.BackColor = Color.Gray;
                    btnTiepTuc.ForeColor = Color.WhiteSmoke;

                    break;

                default:
                    btnLuu.Enabled = false;
                    btnHuy.Enabled = false;

                    btnTiepTuc.Enabled = true;
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                    btnInPhieu.Enabled = true;
                    btnThem.Enabled = true;

                    btnLuu.BackColor = Color.Gray;
                    btnHuy.BackColor = Color.Gray;

                    btnLuu.ForeColor = Color.WhiteSmoke;
                    btnHuy.ForeColor = Color.WhiteSmoke;

                    btnSua.BackColor = Color.Blue;
                    btnXoa.BackColor = Color.Red;

                    btnSua.ForeColor = Color.White;
                    btnXoa.ForeColor = Color.White;

                    btnThem.BackColor = Color.IndianRed;
                    btnThem.ForeColor = Color.White;

                    btnInPhieu.BackColor = Color.CornflowerBlue;
                    btnInPhieu.ForeColor = Color.White;

                    btnTiepTuc.BackColor = Color.OrangeRed;
                    btnTiepTuc.ForeColor = Color.White;
                    break;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {

            if (historyAction == SystemConstants.XEMCHITIET)
            {
                GetFullOrder(orderID);
                EnabledControl(false, -1);

                dgvChiTiet.DataSource = null;

                return;
            }
            switch (action)
            {
                case "THEM":
                    uc_PhieuThu.Show();
                    this.Hide();
                    break;

                case "SUA":
                case "THEM_1":
                    EnabledControl(false);
                    break;

                case SystemConstants.XEMCHITIET:
                    GetFullOrder(orderID);
                    EnabledControl(false, -1);
                    break;

                default:
                    break;
            }
            
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

                if (historyAction != SystemConstants.XEMCHITIET && dtpNgay.Value <= DateTime.Now)
                {
                    epvKhachHang.SetError(this.dtpNgay, "!");
                    MessageBox.Show("Thời gian giao hàng phải lớn hơn thời gian hiện tại", "Lập phiếu giao hàng",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    epvKhachHang.Clear();

                    this.dtpNgay.Focus();

                    return;
                }

                if (string.IsNullOrEmpty(txtPrePayment.Text))
                {
                    txtPrePayment.Text = "0";
                }
                if (string.IsNullOrEmpty(txtFinalMoney.Text))
                {
                    txtFinalMoney.Text = "0";
                }

                var orderDetail = ConvertDataGridViewToList();

                if (action == SystemConstants.THEM || action == SystemConstants.THEM_1)
                {
                    var orderCreate = new OrderCreateModel
                    {
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

                    orderCreate.Details = new List<OrderDetail>();

                    orderCreate.Details.AddRange(orderDetail);

                    var isInsert = orderService.CreateOrder(orderCreate, userInfo, ref err);

                    if (isInsert)
                    {
                        MessageBox.Show("Thêm thành công", "Lập phiếu giao hàng");
                    }
                    else
                    {
                        MessageBox.Show(err, "Lập phiếu giao hàng");
                    }

                    LoadData();
                }
                else if (action == SystemConstants.SUA)
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

                    orderUpdate.Details = new List<OrderDetail>();

                    orderUpdate.Details.AddRange(orderDetail);

                    var isUpdate = orderService.UpdateOrder(orderUpdate, userInfo, ref err);

                    if (isUpdate)
                    {
                        MessageBox.Show("Cập nhật thành công", "Lập phiếu giao hàng");
                    }
                    else
                    {
                        MessageBox.Show(err, "Lập phiếu giao hàng");
                    }

                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.InnerException, "Lập phiếu giao hàng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTiepTuc_Click(object sender, EventArgs e)
        {
        }

        private void uc_ChiTietPhieuThu_Load(object sender, EventArgs e)
        {
            this.dgvChiTiet.SetFillSizeForAllColumns(150);
            this.dgvChiTiet.ResumeLayout();

            LoadData();
            historyAction = action;

            switch (action)
            {
                case SystemConstants.THEM:
                case SystemConstants.THEM_1:
                    EnabledControl(true, 1);
                    break;

                case SystemConstants.SUA:
                    EnabledControl(true, 2);
                    break;

                case SystemConstants.XEMCHITIET:
                    GetFullOrder(orderID);
                    EnabledControl(false, -1);
                    break;

                default:
                    EnabledControl();
                    break;
            }
        }

        private List<OrderDetail> ConvertDataGridViewToList()
        {
            var orderDetails = new List<OrderDetail>();

            if (dgvChiTiet.RowCount > 0)
            {
                foreach (DataGridViewRow row in dgvChiTiet.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        var detail = new OrderDetail
                        {
                            ID = Convert.ToInt32(row.Cells["dgvOrderDetailID"].Value ?? 0),
                            Length = Convert.ToDecimal(row.Cells["dgvTxtLength"].Value),
                            Width = Convert.ToDecimal(row.Cells["dgvTxtWidth"].Value),
                            Quantity = Convert.ToInt32(row.Cells["dgvTxtQuantity"].Value),
                            Price = Convert.ToDecimal(row.Cells["dgvTxtPrice"].Value),
                            TotalPrice = Convert.ToDecimal(row.Cells["dgvTxtTotalPrice"].Value)
                        };

                        if (row.Cells["dgvCboProductCode"] is DataGridViewComboBoxCell cboProduct)
                        {
                            var productID = cboProduct.Value.ToString();

                            detail.ProductID = Convert.ToInt32(productID);
                        }

                        if (row.Cells["dgvCboMaterialType"] is DataGridViewComboBoxCell cboMaterial)
                        {
                            detail.MaterialTypeID = Convert.ToInt32(cboMaterial.Value);
                        }

                        if (row.Cells["dgvCboConstructionType"] is DataGridViewComboBoxCell cboConstruction)
                        {
                            detail.ConstructionTypeID = Convert.ToInt32(cboConstruction.Value);
                        }

                        orderDetails.Add(detail);
                    }
                }
            }

            return orderDetails;
        }

        private void LoadData()
        {
            try
            {
                // generate code order
                txtOrderCode.Text = orderService.OrderGenerateCode();

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

                //Mã sản phẩm

                this.dgvCboProductCode.DataSource = productService.ProductSelect();
                this.dgvCboProductCode.ValueMember = "ID";
                this.dgvCboProductCode.DisplayMember = "Name";

                // Chất liệu
                this.dgvCboMaterialType.DataSource = materialTypeService.MaterialTypeSelect();
                this.dgvCboMaterialType.ValueMember = "ID";
                this.dgvCboMaterialType.DisplayMember = "Name";

                // Thi công
                this.dgvCboConstructionType.DataSource = constructionTypeService.ConstructionTypeSelect();
                this.dgvCboConstructionType.ValueMember = "ID";
                this.dgvCboConstructionType.DisplayMember = "Name";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lập phiếu giao hàng", MessageBoxButtons.OK);
            }
        }

        private void cboKhachHang_SelectedValueChanged(object sender, EventArgs e)
        {
            var customerID = cboGiaoHang.SelectedValue == null ? 0 : Convert.ToInt32(cboKhachHang.SelectedValue);

            var customer = customerService.GetCustomer(customerID);

            if (customer != null)
            {
                mskPhone.Text = customer.Phone;
                txtAddress.Text = customer.Address;
            }
        }

        private void dgvChiTiet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //int r = dgvChiTiet.CurrentCell.RowIndex;

            //var STT = Convert.ToInt32(dgvChiTiet.Rows[r].Cells[0].Value == null ? 0
            //                            : dgvChiTiet.Rows[r].Cells[0].Value);

            //if (STT == 0)
            //{
            //    STT = dgvChiTiet.Rows.Count;

            //    STT = STT > 0 ? STT : 1;

            //    dgvChiTiet.Rows[r].Cells[1].Value = STT;
            //}
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            action = "SUA";
            EnabledControl(true, 2);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                var orderCode = txtOrderCode.Text;

                var isDelete = orderService.DeleteOrderCode(orderCode, userInfo, ref err);

                if (isDelete)
                {
                    MessageBox.Show("Xoá thành công !!!", "Lập phiếu giao hàng");
                }
                else
                {
                    MessageBox.Show(err, "Lập phiếu giao hàng");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.InnerException, "Lập phiếu giao hàng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInPhieu_Click(object sender, EventArgs e)
        {
        }

        private void dgvChiTiet_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!(e.ColumnIndex >= 0 && e.RowIndex >= 0))
            {
                return;
            }

            DataGridViewColumn sttColumn = dgvChiTiet.Columns["dgvSTT"];

            if (sttColumn != null)
            {
                var STT = Convert.ToInt32(dgvChiTiet.Rows[e.RowIndex].Cells[1].Value == null ? 0
                                        : dgvChiTiet.Rows[e.RowIndex].Cells[1].Value);

                if (STT == 0)
                {
                    STT = dgvChiTiet.Rows.Count - 1;

                    STT = STT > 0 ? STT : 1;

                    dgvChiTiet.Rows[e.RowIndex].Cells[1].Value = STT;
                }
            }

            DataGridViewColumn dongiaColumn = dgvChiTiet.Columns["dgvTxtPrice"];
            DataGridViewColumn soluongColumn = dgvChiTiet.Columns["dgvTxtQuantity"];
            DataGridViewColumn thanhtienColumn = dgvChiTiet.Columns["dgvTxtTotalPrice"];
            DataGridViewColumn maspColumn = dgvChiTiet.Columns["dgvCboProductCode"];

            if (dongiaColumn != null && e.ColumnIndex == dongiaColumn.Index)
            {
                // Access the specific cell
                DataGridViewTextBoxCell dongia = (DataGridViewTextBoxCell)dgvChiTiet.Rows[e.RowIndex].Cells[e.ColumnIndex];
                DataGridViewTextBoxCell thanhtien = (DataGridViewTextBoxCell)dgvChiTiet.Rows[e.RowIndex].Cells[e.ColumnIndex + 1];
                DataGridViewTextBoxCell soluong = (DataGridViewTextBoxCell)dgvChiTiet.Rows[e.RowIndex].Cells[e.ColumnIndex - 1];

                // Check if the cell value is not null
                if (dongia.Value != null && soluong.Value != null)
                {
                    // Get the text from the TextBox
                    string newValueDG = dongia.Value.ToString();

                    // Do something with the new text
                    if (!string.IsNullOrEmpty(newValueDG))
                    {
                        var amount = Convert.ToDecimal(dongia.Value) * Convert.ToDecimal(soluong.Value);
                        thanhtien.Value = amount.ToString("#,###");

                        var dongiaFinal = Convert.ToDecimal(dongia.Value);
                        dongia.Value = dongiaFinal.ToString("#,###");
                    }
                }
            }

            if (soluongColumn != null && e.ColumnIndex == soluongColumn.Index)
            {
                // Access the specific cell
                DataGridViewTextBoxCell dongia = (DataGridViewTextBoxCell)dgvChiTiet.Rows[e.RowIndex].Cells[e.ColumnIndex + 1];
                DataGridViewTextBoxCell thanhtien = (DataGridViewTextBoxCell)dgvChiTiet.Rows[e.RowIndex].Cells[e.ColumnIndex + 2];
                DataGridViewTextBoxCell soluong = (DataGridViewTextBoxCell)dgvChiTiet.Rows[e.RowIndex].Cells[e.ColumnIndex];

                // Check if the cell value is not null
                if (soluong.Value != null && dongia.Value != null)
                {
                    // Get the text from the TextBox
                    string newValueSL = soluong.Value.ToString();

                    // Do something with the new text
                    if (!string.IsNullOrEmpty(newValueSL))
                    {
                        var amount = Convert.ToDecimal(dongia.Value) * Convert.ToDecimal(soluong.Value);

                        thanhtien.Value = amount.ToString("#,###");
                    }
                }
            }

            if (thanhtienColumn != null && e.ColumnIndex == thanhtienColumn.Index)
            {
                DataGridViewTextBoxCell thanhtien = (DataGridViewTextBoxCell)dgvChiTiet.Rows[e.RowIndex].Cells[e.ColumnIndex];

                // Check if the cell value is not null
                if (thanhtien.Value != null)
                {
                    // Get the text from the TextBox
                    string newValueThanhTien = thanhtien.Value.ToString();

                    // Do something with the new text
                    if (!string.IsNullOrEmpty(newValueThanhTien))
                    {
                        decimal totalAmount = 0;
                        foreach (DataGridViewRow row in dgvChiTiet.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                totalAmount += Convert.ToDecimal(row.Cells["dgvTxtTotalPrice"].Value);
                            }
                        }

                        txtTotalPrice.Text = totalAmount.ToString("#,###");
                    }
                }
            }

            if (maspColumn != null && e.ColumnIndex == maspColumn.Index)
            {
                DataGridViewComboBoxCell masp = (DataGridViewComboBoxCell)dgvChiTiet.Rows[e.RowIndex].Cells[e.ColumnIndex];
                DataGridViewTextBoxCell tensanpham = (DataGridViewTextBoxCell)dgvChiTiet.Rows[e.RowIndex].Cells[e.ColumnIndex + 1];

                // Check if the cell value is not null
                if (masp.Value != null)
                {
                    // Get the text from the TextBox
                    string newText = masp.Value.ToString();

                    // Do something with the new text
                    if (!string.IsNullOrEmpty(newText))
                    {
                        var product = productService.GetProduct(Convert.ToInt32(masp.Value));

                        tensanpham.Value = product.Name;
                    }
                }
            }
        }

        private void dgvChiTiet_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn chắc chắn muốn xoá sản phẩm này ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                e.Cancel = true; // Cancel the row deletion
            }
        }

        private void dgvChiTiet_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            decimal totalAmount = 0;
            foreach (DataGridViewRow row in dgvChiTiet.Rows)
            {
                if (!row.IsNewRow)
                {
                    totalAmount += Convert.ToDecimal(row.Cells["dgvTxtTotalPrice"].Value);
                }
            }

            txtTotalPrice.Text = totalAmount.ToString("#,###");
        }

        private void txtVAT_ValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTotalPrice.Text))
            {
                return;
            }

            var vat = Convert.ToDouble(txtVAT.Value);
            var tongtien = Convert.ToDouble(txtTotalPrice.Text);

            txtFinalMoney.Text = Utils.CalculatorVAT(vat, tongtien);
        }

        private void txtPrePayment_TextChanged(object sender, EventArgs e)
        {
            //    if (!Utils.CheckSpecialCharacter(txtPrePayment.Text))
            //    {
            //        epvKhachHang.SetError(this.txtPrePayment, "!");
            //        MessageBox.Show("Chỉ chứa số 0-9", "Lập phiếu giao hàng",
            //            MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        epvKhachHang.Clear();
            //        this.txtPrePayment.Focus();

            //        return;
            //    }

            //    var value = Convert.ToDecimal(txtPrePayment.Text.Replace(",", ""));
            //    txtPrePayment.Text = value.ToString("#,###");
        }

        private void txtTotalPrice_TextChanged(object sender, EventArgs e)
        {
            var vat = Convert.ToDouble(txtVAT.Value);
            var tongtien = Convert.ToDouble( string.IsNullOrEmpty(txtTotalPrice.Text) ? "0" : txtTotalPrice.Text);

            txtFinalMoney.Text = Utils.CalculatorVAT(vat, tongtien);
        }

        private void txtPrePayment_MouseLeave(object sender, EventArgs e)
        {
            if (!Utils.CheckSpecialCharacter(txtPrePayment.Text))
            {
                epvKhachHang.SetError(this.txtPrePayment, "!");
                MessageBox.Show("Chỉ chứa số 0-9", "Lập phiếu giao hàng",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                epvKhachHang.Clear();
                this.txtPrePayment.Focus();

                return;
            }

            var value = Convert.ToDecimal(txtPrePayment.Text.Replace(",", ""));
            txtPrePayment.Text = value.ToString("#,###");
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            action = "THEM_1";
            historyAction = action;

            EnabledControl(true, 1);
            

            // generate code order
            txtOrderCode.Text = orderService.OrderGenerateCode();


        }

        private void GetFullOrder(int orderId)
        {
            if (orderID <= 0)
            {
                MessageBox.Show("Không có mã phiếu giao hàng", "Lập phiếu giao hàng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var order = orderService.GetOrder(orderId, ref err);

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
                //else
                //{
                //    MessageBox.Show(err, "Lập phiếu giao hàng 1", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}

                var orderDetails = orderService.GetListOrderDetail(orderId, ref err);

                if (orderDetails.Rows.Count > 0)
                {
                    foreach (DataRow row in orderDetails.Rows)
                    {
                        int rowIndex = dgvChiTiet.Rows.Add();

                        dgvChiTiet.Rows[rowIndex].Cells["dgvOrderDetailID"].Value = row["dgvOrderDetailID"];
                        dgvChiTiet.Rows[rowIndex].Cells["dgvSTT"].Value = row["dgvSTT"];
                        dgvChiTiet.Rows[rowIndex].Cells["dgvTxtProductName"].Value = row["dgvTxtProductName"];

                        dgvChiTiet.Rows[rowIndex].Cells["dgvTxtLength"].Value = row["dgvTxtLength"];
                        dgvChiTiet.Rows[rowIndex].Cells["dgvTxtWidth"].Value = row["dgvTxtWidth"];
                        dgvChiTiet.Rows[rowIndex].Cells["dgvTxtQuantity"].Value = row["dgvTxtQuantity"];
                        dgvChiTiet.Rows[rowIndex].Cells["dgvTxtPrice"].Value = row["dgvTxtPrice"];
                        dgvChiTiet.Rows[rowIndex].Cells["dgvTxtTotalPrice"].Value = row["dgvTxtTotalPrice"];

                        var productID = row["dgvCboProductID"];
                        if (productID != null)
                        {
                            var cellProduct = dgvChiTiet.Rows[rowIndex].Cells["dgvCboProductCode"] as DataGridViewComboBoxCell;

                            if (cellProduct == null)
                            {
                                // If the cell doesn't exist, create a new one
                                cellProduct = new DataGridViewComboBoxCell();
                                dgvChiTiet.Rows[rowIndex].Cells["dgvCboProductCode"] = cellProduct;
                            }

                            cellProduct.Value = Convert.ToInt32(productID);
                        }

                        var materialType = row["dgvCboMaterialType"];
                        if (materialType != null)
                        {
                            var cellMaterialType = dgvChiTiet.Rows[rowIndex].Cells["dgvCboMaterialType"] as DataGridViewComboBoxCell;

                            if (cellMaterialType == null)
                            {
                                // If the cell doesn't exist, create a new one
                                cellMaterialType = new DataGridViewComboBoxCell();
                                dgvChiTiet.Rows[rowIndex].Cells["dgvCboMaterialType"] = cellMaterialType;
                            }

                            cellMaterialType.Value = Convert.ToInt32(materialType);
                        }

                        var constructionType = row["dgvCboConstructionType"];
                        if (constructionType != null)
                        {
                            var cellConstructionType = dgvChiTiet.Rows[rowIndex].Cells["dgvCboConstructionType"] as DataGridViewComboBoxCell;

                            if (cellConstructionType == null)
                            {
                                // If the cell doesn't exist, create a new one
                                cellConstructionType = new DataGridViewComboBoxCell();
                                dgvChiTiet.Rows[rowIndex].Cells["dgvCboConstructionType"] = cellConstructionType;
                            }

                            cellConstructionType.Value = Convert.ToInt32(constructionType);
                        }
                    }
                }
                //else
                //{
                //    MessageBox.Show(err, "Lập phiếu giao hàng 2", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nInnerException: " + ex.InnerException, "Lập phiếu giao hàng 3", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}