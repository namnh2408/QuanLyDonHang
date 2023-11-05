using QuanLyDonHang.Lib;
using QuanLyDonHang.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDonHang.Services
{
    public class DeliveryTypeService
    {
        private QLDonHangEntities entities = new QLDonHangEntities();

        public List<SelectItem> DeliveryTypeSelect()
        {
            var delivery = entities.DeliveryTypes.Where(x => x.IsDeleted == 0)
                              .Select(x => new SelectItem
                              {
                                  Id = x.ID,
                                  Name = x.Name,
                              }).ToList();

            return delivery;
        }

        /// <summary>
        /// Danh sách hình thức giao hàng
        /// </summary>
        /// <returns></returns>
        public List<CommonTypeModel> GetListDelivery()
        {
            var users = entities.Users.Where(a => a.IsDeleted == 0).ToList();

            var delivery = entities.DeliveryTypes.Where(x => x.IsDeleted == 0)
                                       .Select(x => new CommonTypeModel
                                       {
                                           ID = x.ID,
                                           Name = x.Name,
                                           CreateUser = x.CreateUser,
                                           CreateUserName = users.FirstOrDefault(a => a.ID == x.CreateUser).Fullname,
                                           CreateDate = String.Format(SystemConstants.FormatDate, x.CreateDate),

                                           UpdateUser = x.UpdateUser,
                                           UpdateUserName = users.FirstOrDefault(a => a.ID == x.UpdateUser).Fullname,
                                           UpdateDate = String.Format(SystemConstants.FormatDate, x.UpdateDate)
                                       }).ToList();

            return delivery;
        }

        /// <summary>
        /// Thêm mới chất liệu
        /// </summary>
        /// <param name="commonTypeCreate"></param>
        /// <param name="userInfo"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool CreateDeliveryType(CommonTypeCreateModel commonTypeCreate, UserInfo userInfo, ref string err)
        {
            try
            {
                var Delivery = new DeliveryType
                {
                    Name = commonTypeCreate.Name,
                    CreateDate = Utils.DateTimeNow(),
                    CreateUser = userInfo.UserID,
                    UpdateUser = userInfo.UserID,
                    UpdateDate = Utils.DateTimeNow(),
                    IsDeleted = 0
                };

                entities.DeliveryTypes.Add(Delivery);
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
        /// Cập nhật thông tin hình thức giao hàng
        /// </summary>
        /// <param name="commonTypeUpdate"></param>
        /// <param name="userInfo"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool UpdateDeliveryType(CommonTypeUpdateModel commonTypeUpdate, UserInfo userInfo, ref string err)
        {
            try
            {
                var Delivery = entities.DeliveryTypes.FirstOrDefault(x => x.ID == commonTypeUpdate.ID
                                                            && x.IsDeleted == 0);

                if (Delivery is null)
                {
                    return false;
                }

                Delivery.UpdateDate = Utils.DateTimeNow();
                Delivery.UpdateUser = userInfo.UserID;
                Delivery.Name = commonTypeUpdate.Name.Trim();


                entities.DeliveryTypes.AddOrUpdate(Delivery);
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
        /// Xoá hình thức giao hàng
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="userInfo"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool DeleteDeliveryType(int ID, UserInfo userInfo, ref string err)
        {
            try
            {
                var Delivery = entities.DeliveryTypes.FirstOrDefault(x => x.ID == ID
                                                            && x.IsDeleted == 0);

                if (Delivery is null)
                {
                    err = "ID không hợp lệ !";
                    return false;
                }

                Delivery.IsDeleted = 1;
                Delivery.UpdateDate = Utils.DateTimeNow();
                Delivery.UpdateUser = userInfo.UserID;

                entities.DeliveryTypes.AddOrUpdate(Delivery);
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
