using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDonHang.Model
{
    public class CustomerModel
    {
        public int ID { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int IsActive { get; set; }

        public int CreateUser { get; set; }
        public string CreateUserName { get; set; }
        public string CreateDate { get; set; }

        public int UpdateUser { get; set; }
        public string UpdateUserName { get; set; }
        public string UpdateDate { get; set; }
    }

    public class CustomerCreateModel
    {
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int IsActive { get; set; }
    }

    public class  CustomerUpdateModel : CustomerCreateModel
    {
        public int ID { get; set; }
    }
}
