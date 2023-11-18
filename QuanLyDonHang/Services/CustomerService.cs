using QuanLyDonHang.Lib;
using QuanLyDonHang.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Data.Entity.Infrastructure.Design.Executor;

namespace QuanLyDonHang.Services
{
    public class CustomerService
    {
        private QLDonHangEntities entities = new QLDonHangEntities();

        /// <summary>
        /// select box hình thức thanh toán
        /// </summary>
        /// <returns></returns>
        public List<SelectItem> CustomerSelect()
        {
            var payment = entities.Customers.Where(x => x.IsDeleted == 0)
                              .Select(x => new SelectItem
                              {
                                  Id = x.ID,
                                  Name = x.FullName,
                              }).ToList();

            return payment;
        }

        /// <summary>
        /// danh sách hình thức thanh toán
        /// </summary>
        /// <returns></returns>
        public DataTable GetListCustomer(ref string err)
        {
            try
            {
                var users = entities.Users.Where(a => a.IsDeleted == 0).ToList();

                var customers = entities.Customers.Where(x => x.IsDeleted == 0).AsEnumerable()
                                           .Select(x => new CustomerModel
                                           {
                                               ID = x.ID,
                                               Fullname = x.FullName,
                                               Email = x.Email,
                                               Phone = x.Phone,
                                               Address = x.Address,
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
                dt.Columns.Add("Address");
                dt.Columns.Add("CreateDate");

                foreach (var item in customers)
                {
                    dt.Rows.Add(item.ID, item.Fullname, item.Phone, item.Email, item.Address, item.CreateDate);
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
        /// <param name="customerCreate"></param>
        /// <param name="userInfo"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool CreateCustomer(CustomerCreateModel customerCreate, UserInfo userInfo, ref string err)
        {
            try
            {
                var customer = new Customer
                {
                    FullName = customerCreate.Fullname,
                    Email = customerCreate.Email,
                    Address = customerCreate.Address,
                    Phone = customerCreate.Phone.Replace(" ", ""),
                    CreateDate = Utils.DateTimeNow(),
                    CreateUser = userInfo.UserID,
                    UpdateUser = userInfo.UserID,
                    UpdateDate = Utils.DateTimeNow(),
                    IsDeleted = 0
                };

                entities.Customers.Add(customer);
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
        /// <param name="customerUpdate"></param>
        /// <param name="userInfo"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool UpdatePaymentType(CustomerUpdateModel customerUpdate, UserInfo userInfo, ref string err)
        {
            try
            {
                var customer = entities.Customers.FirstOrDefault(x => x.ID == customerUpdate.ID
                                                            && x.IsDeleted == 0);

                if (customer is null)
                {
                    return false;
                }

                customer = AutoMapperHelper.Update(customerUpdate, customer);

                customer.UpdateDate = Utils.DateTimeNow();
                customer.UpdateUser = userInfo.UserID;

                entities.Customers.AddOrUpdate(customer);
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
        public bool DeleteCustomer(int ID, UserInfo userInfo, ref string err)
        {
            try
            {
                var customer = entities.Customers.FirstOrDefault(x => x.ID == ID
                                                            && x.IsDeleted == 0);

                if (customer is null)
                {
                    return false;
                }

                customer.IsDeleted = 1;

                entities.Customers.AddOrUpdate(customer);
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
