using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDonHang.Model
{
    public class UserModel
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string UserName { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public int IsActive { get; set; }

        public int CreateUser { get; set; }
        public string CreateUserName { get; set; }
        public string CreateDate { get; set; }

        public int UpdateUser { get; set; }
        public string UpdateUserName { get; set; }
        public string UpdateDate { get; set; }

        public string Password { get; set; }
    }
    public class CreateUser
    {
        public string Code { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public int RoleID { get; set; }
        public int IsActive { get; set; }
    }

    public class UpdateUser : CreateUser
    {
        public int ID { get; set; }
    }

    public class Signin
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
    }

    public class RoleUsers
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
    }
}
