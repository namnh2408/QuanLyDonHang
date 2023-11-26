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

        private void btnThem_Click(object sender, EventArgs e)
        {

            uc_ChiTietPhieuThu.Show();
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