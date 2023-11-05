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
    public class MaterialTypeService
    {
        private QLDonHangEntities entities = new QLDonHangEntities();

        public List<SelectItem> MaterialTypeSelect()
        {
            var material = entities.MaterialTypes.Where(x => x.IsDeleted == 0)
                              .Select(x => new SelectItem
                              {
                                  Id = x.ID,
                                  Name = x.Name,
                              }).ToList();

            return material;
        }

        public List<CommonTypeModel> GetListMaterial()
        {
            var users = entities.Users.Where(a => a.IsDeleted == 0).ToList();

            var material = entities.MaterialTypes.Where(x => x.IsDeleted == 0)
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

            return material;
        }

        /// <summary>
        /// Thêm mới chất liệu
        /// </summary>
        /// <param name="commonTypeCreate"></param>
        /// <param name="userInfo"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool CreateMaterialType(CommonTypeCreateModel commonTypeCreate, UserInfo userInfo, ref string err)
        {
            try
            {
                var material = new MaterialType
                {
                    Name = commonTypeCreate.Name,
                    CreateDate = Utils.DateTimeNow(),
                    CreateUser = userInfo.UserID,
                    UpdateUser = userInfo.UserID,
                    UpdateDate = Utils.DateTimeNow(),
                    IsDeleted = 0
                };

                entities.MaterialTypes.Add(material);
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
        /// Cập nhật thông tin chất liệu
        /// </summary>
        /// <param name="commonTypeUpdate"></param>
        /// <param name="userInfo"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool UpdateMaterialType(CommonTypeUpdateModel commonTypeUpdate, UserInfo userInfo, ref string err)
        {
            try
            {
                var material = entities.MaterialTypes.FirstOrDefault(x => x.ID == commonTypeUpdate.ID
                                                            && x.IsDeleted == 0);

                if (material is null)
                {
                    return false;
                }

                material.UpdateDate = Utils.DateTimeNow();
                material.UpdateUser = userInfo.UserID;
                material.Name = commonTypeUpdate.Name.Trim();


                entities.MaterialTypes.AddOrUpdate(material);
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
        /// Xoá chất liệu
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="userInfo"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool DeleteMaterialType(int ID, UserInfo userInfo, ref string err)
        {
            try
            {
                var material = entities.MaterialTypes.FirstOrDefault(x => x.ID == ID
                                                            && x.IsDeleted == 0);

                if (material is null)
                {
                    err = "ID không hợp lệ !";
                    return false;
                }

                material.IsDeleted = 1;
                material.UpdateDate = Utils.DateTimeNow();
                material.UpdateUser = userInfo.UserID;

                entities.MaterialTypes.AddOrUpdate(material);
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
