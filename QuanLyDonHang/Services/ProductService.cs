using QuanLyDonHang.Lib;
using QuanLyDonHang.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDonHang.Services
{
    public class ProductService
    {
        private QLDonHangEntities entities = new QLDonHangEntities();

        /// <summary>
        /// select box hình thức thanh toán
        /// </summary>
        /// <returns></returns>
        public List<SelectItem> ProductSelect()
        {
            var payment = entities.Products.Where(x => x.IsDeleted == 0)
                              .Select(x => new SelectItem
                              {
                                  Id = x.ID,
                                  Name = x.Name,
                              }).ToList();

            return payment;
        }

        /// <summary>
        /// danh sách hình thức thanh toán
        /// </summary>
        /// <returns></returns>
        public DataTable GetListProduct(ref string err)
        {
            try
            {
                var users = entities.Users.Where(a => a.IsDeleted == 0).ToList();

                var payments = entities.Products.Where(x => x.IsDeleted == 0).AsEnumerable()
                                           .Select(x => new ProductModel
                                           {
                                               ID = x.ID,
                                               Code = x.Code,
                                               Name = x.Name,
                                               Note = x.Note,
                                               CreateUser = x.CreateUser,
                                               CreateUserName = users.FirstOrDefault(a => a.ID == x.CreateUser).Fullname,
                                               CreateDate = String.Format(SystemConstants.FormatDate, x.CreateDate),

                                               UpdateUser = x.UpdateUser,
                                               UpdateUserName = users.FirstOrDefault(a => a.ID == x.UpdateUser).Fullname,
                                               UpdateDate = String.Format(SystemConstants.FormatDate, x.UpdateDate)
                                           }).OrderBy(x => x.ID).ToList();

                DataTable dt = new DataTable();
                dt.Columns.Add("ID");
                dt.Columns.Add("Hoten");
                dt.Columns.Add("Phone");
                dt.Columns.Add("Email");
                dt.Columns.Add("CreateDate");

                foreach (var item in payments)
                {
                    dt.Rows.Add(item.ID, item.Name, item.CreateDate);
                }

                return dt;
            }
            catch (Exception ex)
            {
                err = ex.Message;
                throw;
            }
        }

        /// <summary>
        /// Thêm mới hình thức thanh toán
        /// </summary>
        /// <param name="commonTypeCreate"></param>
        /// <param name="userInfo"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool CreatePaymentType(CommonTypeCreateModel commonTypeCreate, UserInfo userInfo, ref string err)
        {
            try
            {
                var payment = new PaymentType
                {
                    Name = commonTypeCreate.Name,
                    CreateDate = Utils.DateTimeNow(),
                    CreateUser = userInfo.UserID,
                    UpdateUser = userInfo.UserID,
                    UpdateDate = Utils.DateTimeNow(),
                    IsDeleted = 0
                };

                entities.PaymentTypes.Add(payment);
                entities.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Cập nhật thông tin hình thức thanh toán
        /// </summary>
        /// <param name="commonTypeUpdate"></param>
        /// <param name="userInfo"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool UpdatePaymentType(CommonTypeUpdateModel commonTypeUpdate, UserInfo userInfo, ref string err)
        {
            try
            {
                var payments = entities.PaymentTypes.FirstOrDefault(x => x.ID == commonTypeUpdate.ID
                                                            && x.IsDeleted == 0);

                if (payments is null)
                {
                    return false;
                }

                payments.UpdateDate = Utils.DateTimeNow();
                payments.UpdateUser = userInfo.UserID;
                payments.Name = commonTypeUpdate.Name.Trim();


                entities.PaymentTypes.AddOrUpdate(payments);
                entities.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Xoá hình thức thanh toán
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="userInfo"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool DeletePaymentType(int ID, UserInfo userInfo, ref string err)
        {
            try
            {
                var payments = entities.PaymentTypes.FirstOrDefault(x => x.ID == ID
                                                            && x.IsDeleted == 0);

                if (payments is null)
                {
                    return false;
                }

                payments.IsDeleted = 1;

                entities.PaymentTypes.AddOrUpdate(payments);
                entities.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }
    }
}
