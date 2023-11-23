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
        /// select box sản phẩm
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
        /// danh sách sản phẩm
        /// </summary>
        /// <returns></returns>
        public DataTable GetListProduct(ref string err)
        {
            try
            {
                var users = entities.Users.Where(a => a.IsDeleted == 0).ToList();

                var products = entities.Products.Where(x => x.IsDeleted == 0).AsEnumerable()
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
                dt.Columns.Add("Code");
                dt.Columns.Add("ProductName");
                dt.Columns.Add("Note");
                dt.Columns.Add("CreateDate");

                foreach (var item in products)
                {
                    dt.Rows.Add(item.ID, item.Code, item.Name, item.Note, item.CreateDate);
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
        /// Thêm mới sản phẩm
        /// </summary>
        /// <param name="productCreate"></param>
        /// <param name="userInfo"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool CreateProduct(ProductCreateModel productCreate, UserInfo userInfo, ref string err)
        {
            try
            {
                var product = new Product
                {
                    Code = productCreate.Code,
                    Name = productCreate.Name,
                    Note = productCreate.Note,
                    CreateDate = Utils.DateTimeNow(),
                    CreateUser = userInfo.UserID,
                    UpdateUser = userInfo.UserID,
                    UpdateDate = Utils.DateTimeNow(),
                    IsActive = productCreate.IsActive,
                    IsDeleted = 0
                };

                entities.Products.Add(product);
                entities.SaveChanges();

                var defaultCode = "SP000";
                if (string.IsNullOrEmpty(productCreate.Code.Trim()))
                {
                    var length = defaultCode.Length - product.ID.ToString().Length;

                    productCreate.Code = defaultCode.Substring(0, length) + product.ID.ToString();
                }
                else
                {
                    product.Code = productCreate.Code.Trim();
                }

                entities.Products.AddOrUpdate(product);
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
        /// Cập nhật thông tin sản phẩm
        /// </summary>
        /// <param name="productUpdate"></param>
        /// <param name="userInfo"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool UpdateProduct(ProductUpdateModel productUpdate, UserInfo userInfo, ref string err)
        {
            try
            {
                var product = entities.Products.FirstOrDefault(x => x.ID == productUpdate.ID
                                                            && x.IsDeleted == 0);

                if (product is null)
                {
                    return false;
                }

                product = AutoMapperHelper.Update(productUpdate, product);

                product.UpdateDate = Utils.DateTimeNow();
                product.UpdateUser = userInfo.UserID;


                entities.Products.AddOrUpdate(product);
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
        /// Xoá sản phẩm
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="userInfo"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool DeleteProduct(int ID, UserInfo userInfo, ref string err)
        {
            try
            {
                var product = entities.Products.FirstOrDefault(x => x.ID == ID
                                                            && x.IsDeleted == 0);

                if (product is null)
                {
                    return false;
                }

                product.IsDeleted = 1;
                product.UpdateUser = userInfo.UserID;
                product.UpdateDate= Utils.DateTimeNow();

                entities.Products.AddOrUpdate(product);
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
