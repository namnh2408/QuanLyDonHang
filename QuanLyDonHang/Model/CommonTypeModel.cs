using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDonHang.Model
{
    public class CommonTypeModel
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public int CreateUser { get; set; }

        public string CreateUserName { get; set; }
        public string CreateDate { get; set; }

        public int UpdateUser { get; set; }
        public string UpdateUserName { get; set; }
        public string UpdateDate { get; set; }
    }

    public class CommonTypeCreateModel
    {
        public string Name { get; set; }
    }

    public class CommonTypeUpdateModel : CommonTypeCreateModel
    {
        public int ID { get; set; }
    }

    public class CommonTypeDeleteModel
    {
        public int ID { get; set; }
    }

    public class CommonTypeFilter
    {
        public int CurrentPage { get; set; }

        public string filter { get; set; }
    }
}
