using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDonHang.Model
{
    public class ProductModel
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public int IsActive { get; set; }

        public int CreateUser { get; set; }
        public string CreateUserName { get; set; }
        public string CreateDate { get; set; }

        public int UpdateUser { get; set; }
        public string UpdateUserName { get; set; }
        public string UpdateDate { get; set; }
    }

    public class ProductCreateModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public int IsActive { get; set; }
    }

    public class ProductUpdateModel : ProductCreateModel
    {
        public int ID { get; set; }
    }
}
