using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDonHang.Model
{
    public class OrderModel
    {
    }

    public class OrderCreateModel
    {
        public string Code { get; set; }
        public int CustomerID { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int PaymentTypeID { get; set; }
        public int DeliveryTypeID { get; set; }
        public DateTime OrderDate { get; set; }
        public int Hour { get; set; }
        public int Minute { get; set; }

        public string Note { get; set; }
    }

    public class OrderDetailCreateModel
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int MaterialTypeID { get; set; }
        public int ConstructionTypeID { get; set; }
        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
