using QuanLyDonHang.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDonHang.Services
{
    public class OrderService
    {
        private QLDonHangEntities entities = new QLDonHangEntities();

        public string OrderGenerateCode()
        {
            var dateNow = Utils.DateTimeNow();
            var orderCountToday = entities.Orders.Where(x => x.CreateDate.CompareTo(dateNow) == 0).Count() + 1;

            var defaultCode = "000";

            var length = defaultCode.Length - orderCountToday.ToString().Length;

            defaultCode = "#" + dateNow.ToString("dd/MM/yyyy").Replace("/", "") + "." + defaultCode.Substring(0, length) + orderCountToday.ToString();

            return defaultCode;
        }
    }
}