using QuanLyDonHang.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDonHang.Services
{
    public class Users
    {
        public int CheckLogin(string user, string pass)//kiểm tra đăng nhập
        {
            return (int)Function.ExcuteScalar("SELECT [dbo].[CheckLogin]('" + user + "', '" + pass + "')");
        }
        public int GetID(string user)
        {
            return (int)Function.ExcuteScalar("EXEC [GetIdUser] '" + user + "'");
        }
    }
}
