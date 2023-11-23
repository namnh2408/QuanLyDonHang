using QuanLyDonHang.Lib;
using QuanLyDonHang.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDonHang.Services
{
    public class UserService
    {
        private QLDonHangEntities entities = new QLDonHangEntities();
        public UserInfo userInfo = new UserInfo();

        public DataTable GetListUser(ref string err)
        {
            try
            {
                var users = entities.Users.Where(x => x.IsDeleted == 0)
                                       .Include(a => a.Role)
                                       .AsEnumerable()
                                       .Select(p => new UserModel
                                       {
                                           ID = p.ID,
                                           Code = p.Code,
                                           UserName = p.UserName,
                                           Fullname = p.Fullname,
                                           Phone = p.Phone,
                                           Email = p.Email,
                                           Gender = p.Gender,
                                           Address = p.Address,
                                           RoleID = p.RoleID,
                                           RoleName = p.Role.Title,
                                           IsActive = p.IsActive,

                                           CreateUser = p.CreateUser,
                                           CreateUserName = "",
                                           CreateDate = string.Format(SystemConstants.FormatDate, p.CreateDate),

                                           UpdateUser = p.UpdateUser,
                                           UpdateUserName = "",
                                           UpdateDate = string.Format(SystemConstants.FormatDate, p.UpdateDate)

                                       }).OrderBy(x => x.ID).ToList();

                DataTable dt = new DataTable();
                dt.Columns.Add("ID");
                dt.Columns.Add("Code");
                dt.Columns.Add("TenDN");
                dt.Columns.Add("HoTen");
                dt.Columns.Add("GioiTinh");
                dt.Columns.Add("Phone");
                dt.Columns.Add("Email");
                dt.Columns.Add("Quyen");
                dt.Columns.Add("Address");
                dt.Columns.Add("CreateDate");

                foreach(var item in users)
                {
                    dt.Rows.Add(item.ID, item.Code, item.UserName, item.Fullname, item.Gender, item.Phone, 
                                    item.Email, item.RoleName, item.Address, item.CreateDate);
                }

                return dt;
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return null;
            }
        }

        public UserModel GetUserInfo(ref string err)
        {
            try
            {
                var user = entities.Users.Where(x => x.IsDeleted == 0 && x.ID == userInfo.UserID)
                                       .Include(a => a.Role)
                                       .AsEnumerable()
                                       .Select(p => new UserModel
                                       {
                                           ID = p.ID,
                                           Code = p.Code,
                                           UserName = p.UserName,
                                           Fullname = p.Fullname,
                                           Phone = p.Phone,
                                           Email = p.Email,
                                           Gender = p.Gender,
                                           Address = p.Address,
                                           RoleID = p.RoleID,
                                           RoleName = p.Role.Title,
                                           IsActive = p.IsActive,

                                           CreateUser = p.CreateUser,
                                           CreateUserName = "",
                                           CreateDate = string.Format(SystemConstants.FormatDate, p.CreateDate),

                                           UpdateUser = p.UpdateUser,
                                           UpdateUserName = "",
                                           UpdateDate = string.Format(SystemConstants.FormatDate, p.UpdateDate),

                                           Password = p.Password
                                       }).FirstOrDefault();

                return user;
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    err = String.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        err += $"\n- Property: {ve.PropertyName}, Error: {ve.ErrorMessage}";
                    }
                }

                return null;

            }
            catch (Exception ex) { err = ex.Message; return null; }

            
        }

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
                    Code = createUser.Code,
                    UserName = createUser.UserName,
                    Password = Encryptor.EncryptMD5(createUser.Password.Trim()),
                    Fullname = createUser.Fullname,
                    Email = createUser.Email,
                    Phone = createUser.Phone.Replace(" ", ""),
                    Address = createUser.Address,
                    CreateUser = userInfo.UserID,
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                    UpdateUser = userInfo.UserID,
                    IsActive = createUser.IsActive,
                    IsDeleted = 0,
                    RoleID = createUser.RoleID,
                    Gender = createUser.Gender
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
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    err = String.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        err += $"\n- Property: {ve.PropertyName}, Error: {ve.ErrorMessage}";
                    }
                }

                return false;
                
            }
            catch (Exception ex) { err = ex.Message; return false; }
        }

        public bool Update(UpdateUser update, UserInfo userInfo, ref string err)
        {
            try
            {
                var dateNow = Utils.DateTimeNow();

                var user = entities.Users.FirstOrDefault(a => a.ID == update.ID && a.IsDeleted == 0);

                if (user == null)
                {
                    err = @"Người dùng này không tồn tại !";
                    return false;
                }

                update.Password = !string.IsNullOrEmpty(update.Password.Trim()) 
                                        ? Encryptor.EncryptMD5(update.Password.Trim())
                                        : user.Password;

                user = AutoMapperHelper.Update(update, user);

                user.UpdateDate = dateNow;
                user.UpdateUser = userInfo.UserID;

                entities.Entry(user).State = System.Data.Entity.EntityState.Modified;
                entities.SaveChanges();
                return true;
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    err = String.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        err += $"\n- Property: {ve.PropertyName}, Error: {ve.ErrorMessage}";
                    }
                }

                return false;

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
