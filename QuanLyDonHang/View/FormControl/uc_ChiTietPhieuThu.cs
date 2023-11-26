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
    public partial class uc_ChiTietPhieuThu : UserControl
    {
        public uc_PhieuThu uc_PhieuThu;
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

        public uc_ChiTietPhieuThu()
        {
            InitializeComponent();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            uc_PhieuThu.Show();
            this.Hide();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

        }

        private void btnTiepTuc_Click(object sender, EventArgs e)
        {

        }

        private void uc_ChiTietPhieuThu_Load(object sender, EventArgs e)
        {
            this.dgvChiTiet.SetFillSizeForAllColumns(150);

            this.ResumeLayout();

            LoadData();
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
                this.cboGiaoHang.DisplayMember= "Name";

                // thanh toán
                this.cboThanhToan.DataSource = paymentTypeService.PaymentTypeSelect();
                this.cboThanhToan.ValueMember = "ID";
                this.cboThanhToan.DisplayMember= "Name";

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
                MessageBox.Show(ex.Message, "Phiếu giao hàng", MessageBoxButtons.OK);
            }
        }

        private void cboKhachHang_SelectedValueChanged(object sender, EventArgs e)
        {
            var customerID = cboGiaoHang.SelectedValue == null ? 0 : Convert.ToInt32(cboKhachHang.SelectedValue);

            var customer  = customerService.GetCustomer(customerID);

            if (customer != null)
            {
                mskPhone.Text = customer.Phone;
                txtAddress.Text = customer.Address;
            }
            
        }

        private void dgvChiTiet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvChiTiet.CurrentCell.RowIndex;

            var STT = Convert.ToInt32(dgvChiTiet.Rows[r].Cells[0].Value == null ? 0
                                        : dgvChiTiet.Rows[r].Cells[0].Value);

            if( STT == 0)
            {
                STT = dgvChiTiet.Rows.Count;

                STT = STT > 0 ? STT : 1;

                dgvChiTiet.Rows[r].Cells[0].Value = STT;
            }

            
        }
    }
}
