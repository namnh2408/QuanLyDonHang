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
    public class ContructionTypeService
    {
        private QLDonHangEntities entities = new QLDonHangEntities();

        public List<SelectItem> ConstructionTypeSelect()
        {
            var construction = entities.ConstructionTypes.Where(x => x.IsDeleted == 0)
                              .Select(x => new SelectItem
                              {
                                  Id = x.ID,
                                  Name = x.Name,
                              }).ToList();

            return construction;
        }

        public List<CommonTypeModel> GetListConstruction()
        {
            var users = entities.Users.Where(a => a.IsDeleted == 0).ToList();

            var construction = entities.ConstructionTypes.Where(x => x.IsDeleted == 0)
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

            return construction;
        }

        /// <summary>
        /// Thêm mới thi công
        /// </summary>
        /// <param name="commonTypeCreate"></param>
        /// <param name="userInfo"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool CreateConstructionType(CommonTypeCreateModel commonTypeCreate, UserInfo userInfo, ref string err)
        {
            try
            {
                var Construction = new ConstructionType
                {
                    Name = commonTypeCreate.Name,
                    CreateDate = Utils.DateTimeNow(),
                    CreateUser = userInfo.UserID,
                    UpdateUser = userInfo.UserID,
                    UpdateDate = Utils.DateTimeNow(),
                    IsDeleted = 0
                };

                entities.ConstructionTypes.Add(Construction);
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
        /// Cập nhật thông tin thi công
        /// </summary>
        /// <param name="commonTypeUpdate">thông tin cập nhật</param>
        /// <param name="userInfo">user đăng nhập</param>
        /// <param name="err">lỗi</param>
        /// <returns></returns>
        public bool UpdateConstructionType(CommonTypeUpdateModel commonTypeUpdate, UserInfo userInfo, ref string err)
        {
            try
            {
                var construction = entities.ConstructionTypes.FirstOrDefault(x => x.ID == commonTypeUpdate.ID
                                                            && x.IsDeleted == 0);

                if (construction is null)
                {
                    return false;
                }

                construction.UpdateDate = Utils.DateTimeNow();
                construction.UpdateUser = userInfo.UserID;
                construction.Name = commonTypeUpdate.Name.Trim();


                entities.ConstructionTypes.AddOrUpdate(construction);
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
        /// Xoá thi công
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="userInfo"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool DeleteConstructionType(int ID, UserInfo userInfo, ref string err)
        {
            try
            {
                var Construction = entities.ConstructionTypes.FirstOrDefault(x => x.ID == ID
                                                            && x.IsDeleted == 0);

                if (Construction is null)
                {
                    err = "ID không hợp lệ !";
                    return false;
                }

                Construction.IsDeleted = 1;
                Construction.UpdateDate = Utils.DateTimeNow();
                Construction.UpdateUser = userInfo.UserID;

                entities.ConstructionTypes.AddOrUpdate(Construction);
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
