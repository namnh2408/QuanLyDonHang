using QuanLyDonHang.Lib;
using QuanLyDonHang.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDonHang.Services
{
    public class UserServices
    {
        private QLDonHangEntities entities = new QLDonHangEntities();
        public UserInfo userInfo = new UserInfo();

        public bool LoginUser(Signin login, ref string err)
        {
            try
            {
                var passEncrytion = Encryptor.EncryptMD5(login.Password.Trim());

                var user = entities.Users.FirstOrDefault(x => x.UserName == login.UserName
                                                && x.Password.Trim() == passEncrytion
                                                && x.IsDeleted == 0
                                                && x.RoleID == login.RoleId);


                if (user != null)
                {
                    userInfo.UserID = user.ID;
                    userInfo.UserName = user.UserName;
                    userInfo.Code = user.Code;
                    user.Fullname = user.Fullname;

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
            
        }

        public bool CreateUser(CreateUser createUser, UserInfo userInfo, ref string err)
        {
            try
            {
                var userExists = entities.Users.FirstOrDefault(x => x.UserName.Equals(createUser.UserName.Trim())
                                                            || x.Code.Equals(createUser.Code.Trim()));
                if (userExists != null)
                {
                    err = @"Tài khoản đã tồn tại !";
                    return false;
                }

                var userCreate = new User
                {
                    UserName = createUser.UserName,
                    Password = Encryptor.EncryptMD5(createUser.Password.Trim()),
                    Fullname = createUser.Fullname,
                    Email = createUser.Email,
                    Phone = createUser.Phone,
                    Address = createUser.Address,
                    CreateUser = userInfo.UserID,
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                    UpdateUser = userInfo.UserID,
                    IsActive = createUser.IsActive,
                    IsDeleted = 0,
                    RoleID = createUser.RoleID
                };

                entities.Users.Add(userCreate);
                entities.SaveChanges();


                var defaultCode = "00000";
                if (string.IsNullOrEmpty(createUser.Code.Trim()))
                {
                    var length = defaultCode.Length - userCreate.ID.ToString().Length;

                    userCreate.Code = defaultCode.Substring(0, length) + userCreate.ID.ToString();
                }
                else
                {
                    userCreate.Code = createUser.Code.Trim();
                }

                entities.Entry(userCreate).State = System.Data.Entity.EntityState.Modified;
                entities.SaveChanges();

                return true;
            }
            catch (Exception ex) { err = ex.Message; return false; }
        }

        public bool Update(Update update, UserInfo userInfo, ref string err)
        {
            try
            {
                var dateNow = DateTime.Now;

                var user = entities.Users.FirstOrDefault(a => a.ID == update.ID && a.Code == update.Code);

                if (user == null)
                {
                    err = @"Người dùng này không tồn tại !";
                    return false;
                }

                user = AutoMapperHelper.Update(update, user);

                user.UpdateDate = dateNow;
                user.UpdateUser = userInfo.UserID;

                entities.Entry(user).State = System.Data.Entity.EntityState.Modified;
                entities.SaveChanges();
                return true;
            }
            catch (Exception ex) { err = ex.Message; return false; }
        }

        public bool Delete(int ID, UserInfo userInfo, ref string err)
        {
            try
            {
                var dateNow = DateTime.Now;

                var user = entities.Users.FirstOrDefault(a => a.ID == ID);

                if (user == null)
                {
                    err = @"Người dùng này không tồn tại !";
                    return false;
                }

                user.IsDeleted = 1;

                user.UpdateDate = dateNow;
                user.UpdateUser = userInfo.UserID;

                entities.Entry(user).State = System.Data.Entity.EntityState.Modified;
                entities.SaveChanges();
                return true;
            }
            catch (Exception ex) { err = ex.Message; return false; }
        }

        public List<SelectItem> RoleUserSelect()
        {
            var roles = entities.Roles.Select(x => new SelectItem
            {
                Id = x.ID,
                Name = x.Title
            }).ToList();
            
            return roles;
        }

    }
}
