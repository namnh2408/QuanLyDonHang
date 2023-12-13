using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDonHang.Model
{
    public class OrderModel
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int PaymentTypeID { get; set; }
        public string PaymentTypeName { get; set; }
        public int DeliveryTypeID { get; set; }
        public string DeliveryTypeName { get; set; }
        public string OrderDate { get; set; }

        public string Note { get; set; }

        public decimal TotalMoney { get; set; }
        public decimal VAT { get; set; }
        public decimal PrePayment { get; set; }
        public decimal FinalMoney { get; set; }

        public int CreateUser { get; set; }
        public string CreateUserName { get; set; }
        public string CreateDate { get; set; }

        public int UpdateUser { get; set; }
        public string UpdateUserName { get; set; }
        public string UpdateDate { get; set; }
    }

    public class OrderCreateModel
    {
        public string Code { get; set; }
        public int CustomerID { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int PaymentTypeID { get; set; }
        public int DeliveryTypeID { get; set; }
        public string OrderDate { get; set; }

        public string Note { get; set; }

        public decimal TotalMoney { get; set; }
        public decimal VAT { get; set; }
        public decimal PrePayment { get; set; }
        public decimal FinalMoney { get; set; }

        public List<OrderDetail> Details { get; set; }
    }

    public class OrderUpdateModel : OrderCreateModel
    {
        public int ID { get; set; }
        
    }
}
