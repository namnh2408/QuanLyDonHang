using QuanLyDonHang.Lib;
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
    public partial class uc_PhieuThu : UserControl
    {
        public uc_ChiTietPhieuThu uc_ChiTietPhieuThu;
        public UserInfo userInfo;

        private ProductService productService = new ProductService();
        private CustomerService customerService = new CustomerService();
        private PaymentTypeService paymentTypeService = new PaymentTypeService();
        private MaterialTypeService materialTypeService = new MaterialTypeService();
        private DeliveryTypeService deliveryTypeService = new DeliveryTypeService();
        private ConstructionTypeService constructionTypeService = new ConstructionTypeService();

        private OrderService orderService = new OrderService();

        private string err;

        private bool insert = false;

        public uc_PhieuThu()
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
                txtOrderCode.Enabled = false;
                cboKhachHang.Enabled = false;
                mskPhone.Enabled = false;
                txtAddress.Enabled = false;

                cboThanhToan.Enabled = false;
                cboGiaoHang.Enabled = false;
                dtpNgay.Enabled = false;
                txtNote.Enabled = false;

                txtTotalPrice.Enabled = false;
                txtPrePayment.Enabled = false;
                txtVAT.Enabled = false;
                txtFinalMoney.Enabled = false;

                btnLuu.Enabled = false;
                btnHuy.Enabled = false;

                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnThem.Enabled = true;
            }
            else
            {
                txtOrderCode.Enabled = true;
                cboKhachHang.Enabled = true;
                mskPhone.Enabled = true;
                txtAddress.Enabled = true;

                cboThanhToan.Enabled = true;
                cboGiaoHang.Enabled = true;
                dtpNgay.Enabled = true;
                txtNote.Enabled = true;

                txtTotalPrice.Enabled = true;
                txtPrePayment.Enabled = true;
                txtVAT.Enabled = true;
                txtFinalMoney.Enabled = true;
            }

            switch (funcNo)
            {
                case 0:
                   
       
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

        private void btnThem_Click(object sender, EventArgs e)
        {

            uc_ChiTietPhieuThu.Show();
            uc_ChiTietPhieuThu.action = "THEM";
            uc_ChiTietPhieuThu.uc_PhieuThu = this;
            
            this.Hide();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
        }

        private void uc_PhieuThu_Load(object sender, EventArgs e)
        {
            this.dgvKhachHang.SetFillSizeForAllColumns();

            this.dgvKhachHang.ResumeLayout();
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
    }
}