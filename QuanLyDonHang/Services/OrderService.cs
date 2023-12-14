using QuanLyDonHang.Lib;
using QuanLyDonHang.Model;
using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;

namespace QuanLyDonHang.Services
{
    public class OrderService
    {
        private QLDonHangEntities entities = new QLDonHangEntities();


        public DataTable GetListOrder(ref string err)
        {

            try
            {
                var users = entities.Users.Where(a => a.IsDeleted == 0).ToList();

                var orders = entities.Orders.Where(x => x.IsDeleted == 0)
                                             .Include(a => a.PaymentType)
                                             .Include(x => x.DeliveryType)
                                             .Include(p => p.Customer)
                                            .AsEnumerable()
                                           .Select(x => new OrderModel
                                           {
                                               ID = x.ID,
                                               Code = x.Code,
                                               CustomerID = x.CustomerID,
                                               CustomerName = x.Customer.FullName,
                                               OrderDate = x.OrderDate,
                                               Phone = x.Phone,
                                               Address = x.Address,
                                               PaymentTypeID = x.PaymentTypeID,
                                               PaymentTypeName = x.PaymentType.Name,
                                               DeliveryTypeID = x.DeliveryTypeID,
                                               DeliveryTypeName  =x.DeliveryType.Name,

                                               TotalMoney = x.TotalMoney,
                                               PrePayment = x.PrePayment,
                                               FinalMoney = x.FinalMoney,
                                               VAT = x.VAT,
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
                dt.Columns.Add("CustomerID");
                dt.Columns.Add("OrderCode");
                dt.Columns.Add("CustomerName");
                dt.Columns.Add("Phone");
                dt.Columns.Add("Address");

                dt.Columns.Add("OrderDate");
                dt.Columns.Add("TotalMoney");
                dt.Columns.Add("VAT");
                dt.Columns.Add("PrePayment");
                dt.Columns.Add("FinalMoney");

                foreach (var item in orders)
                {
                    dt.Rows.Add(item.ID, 
                            item.CustomerID, 
                            item.Code,
                            item.CustomerName, item.Phone, item.Address, 
                            item.OrderDate,
                            item.TotalMoney.ToString("#,###"), 
                            item.VAT,
                            item.PrePayment.ToString("#,###"), 
                            item.FinalMoney.ToString("#,###")
                        );
                }

                return dt;
            }
            catch (Exception ex)
            {
                err = ex.Message;
                throw;
            }
        }

        public OrderModel GetOrder(int orderId, ref string err)
        {
            try
            {
                var users = entities.Users.Where(a => a.IsDeleted == 0).ToList();

                var order = entities.Orders.Where(x => x.IsDeleted == 0 && x.ID == orderId)
                                             .Include(a => a.PaymentType)
                                             .Include(x => x.DeliveryType)
                                             .Include(p => p.Customer)
                                            .AsEnumerable()
                                           .Select(x => new OrderModel
                                           {
                                               ID = x.ID,
                                               Code = x.Code,
                                               CustomerID = x.CustomerID,
                                               CustomerName = x.Customer.FullName,
                                               OrderDate = x.OrderDate,
                                               Phone = x.Phone,
                                               Address = x.Address,
                                               PaymentTypeID = x.PaymentTypeID,
                                               PaymentTypeName = x.PaymentType.Name,
                                               DeliveryTypeID = x.DeliveryTypeID,
                                               DeliveryTypeName = x.DeliveryType.Name,

                                               TotalMoney = x.TotalMoney,
                                               PrePayment = x.PrePayment,
                                               FinalMoney = x.FinalMoney,
                                               VAT = x.VAT,
                                               Note = x.Note,

                                               CreateUser = x.CreateUser,
                                               CreateUserName = users.FirstOrDefault(a => a.ID == x.CreateUser).Fullname,
                                               CreateDate = String.Format(SystemConstants.FormatDate, x.CreateDate),

                                               UpdateUser = x.UpdateUser,
                                               UpdateUserName = users.FirstOrDefault(a => a.ID == x.UpdateUser).Fullname,
                                               UpdateDate = String.Format(SystemConstants.FormatDate, x.UpdateDate)
                                           }).FirstOrDefault();

                return order;
            }
            catch(Exception ex)
            {
                err = ex.Message;
                throw;  
            }
        }

        public DataTable GetListOrderDetail(int orderID, ref string err)
        {
            try
            {
                int STT = 1;

                var orderDetails = entities.OrderDetails.Where(x => x.IsDeleted == 0 && x.OrderID == orderID)
                                                        .Include(x => x.Order)
                                                        .Include(a => a.Product)
                                                        .Include(a => a.ConstructionType)
                                                        .Include(a => a.MaterialType)
                                                        .AsEnumerable()
                                                        .Select( x => new
                                                        {
                                                            x.ID,
                                                            STT = STT++,
                                                            x.OrderID,
                                                            x.MaterialTypeID,
                                                            x.ConstructionTypeID,
                                                            x.ProductID,
                                                            ProductName = x.Product.Name,
                                                            x.Length, x.Width,
                                                            x.Quantity,
                                                            x.Price,
                                                            x.TotalPrice
                                                        }).OrderBy(x => x.ID).ToList();

                DataTable dt = new DataTable();

                dt.Columns.Add("ID");
                dt.Columns.Add("dgvSTT");
                dt.Columns.Add("dgvCboProductCode");
                dt.Columns.Add("dgvTxtProductName");
                dt.Columns.Add("dgvCboMaterialType");
                dt.Columns.Add("dgvCboConstructionType");

                dt.Columns.Add("dgvTxtLength");
                dt.Columns.Add("dgvTxtWidth");
                dt.Columns.Add("dgvTxtQuantity");
                dt.Columns.Add("dgvTxtPrice");
                dt.Columns.Add("dgvTxtTotalPrice");

                foreach (var item in orderDetails)
                {
                    dt.Rows.Add(item.ID,
                                item.STT,
                                item.ProductID,
                                item.ProductName,
                                item.MaterialTypeID,
                                item.ConstructionTypeID,
                                item.Length,
                                item.Width,
                                item.Quantity,
                                item.Price,
                                item.TotalPrice);
                }

                return dt;

            }
            catch( Exception ex ) { err = ex.Message; throw; }
        }

        public string OrderGenerateCode()
        {
            var dateNow = Utils.DateTimeNow();
            var orderCountToday = entities.Orders.Where(x => x.CreateDate.CompareTo(dateNow) == 0).Count() + 1;

            var defaultCode = "000";

            var length = defaultCode.Length - orderCountToday.ToString().Length;

            defaultCode = "#" + dateNow.ToString("dd/MM/yyyy").Replace("/", "") + "." + defaultCode.Substring(0, length) + orderCountToday.ToString();

            return defaultCode;
        }

        public bool CreateOrder(OrderCreateModel orderCreate, UserInfo userInfo, ref string err)
        {
            try
            {
                var dateNow = Utils.DateTimeNow();

                var order = new Order
                {
                    Code = orderCreate.Code,
                    CustomerID = orderCreate.CustomerID,
                    Address = orderCreate.Address,
                    Phone = orderCreate.Phone,
                    Note = orderCreate.Note,
                    PaymentTypeID = orderCreate.PaymentTypeID,
                    DeliveryTypeID = orderCreate.DeliveryTypeID,
                    IsDeleted = 0,
                    CreateDate = dateNow,
                    CreateUser = userInfo.UserID,
                    UpdateUser = userInfo.UserID,
                    UpdateDate = dateNow,
                    TotalMoney = orderCreate.TotalMoney,
                    VAT = orderCreate.VAT,
                    PrePayment = orderCreate.PrePayment,
                    FinalMoney = orderCreate.FinalMoney,
                    OrderDate = orderCreate.OrderDate,
                    ExportDate = dateNow.ToString("dd/MM/yyyy HH:mm:ss")
                };

                entities.Orders.Add(order);
                entities.SaveChanges();

                if (orderCreate.Details != null && orderCreate.Details.Any())
                {
                    var orderDetails = orderCreate.Details.Select(x => new OrderDetail
                    {
                        OrderID = order.ID,
                        ProductID = x.ProductID,
                        MaterialTypeID = x.MaterialTypeID,
                        ConstructionTypeID = x.ConstructionTypeID,
                        Length = x.Length,
                        Width = x.Width,
                        Quantity = x.Quantity,
                        Price = x.Price,
                        TotalPrice = x.TotalPrice,
                        CreateDate = dateNow,
                        CreateUser = userInfo.UserID,
                        UpdateUser = userInfo.UserID,
                        UpdateDate = dateNow
                    });

                    entities.OrderDetails.AddRange(orderDetails);

                    entities.SaveChanges();
                }

                if (entities.Entry(order).State == EntityState.Added)
                {
                    return true;
                }
                else
                {
                    return false;
                }
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

        public bool UpdateOrder(OrderUpdateModel orderUpdate, UserInfo userInfo, ref string err)
        {
            try
            {
                var dateNow = Utils.DateTimeNow();

                var order = entities.Orders.Where(x => (x.ID == orderUpdate.ID || x.Code == orderUpdate.Code) && x.IsDeleted == 0)
                                                .Include(x => x.OrderDetails)
                                .FirstOrDefault();

                if (order == null)
                {
                    err = "Phiếu giao hàng này không tồn tại";
                    return false;
                }

                order = AutoMapperHelper.Update(orderUpdate, order);

                order.UpdateDate = dateNow;
                order.UpdateUser = userInfo.UserID;

                entities.SaveChanges();

                if (orderUpdate.Details != null && orderUpdate.Details.Any())
                {
                    var orderDetailExist = orderUpdate.Details.Where(x => x.ID > 0).ToList();

                    var IDExist = orderDetailExist.Select(x => x.ID).ToList();

                    foreach (var item in IDExist)
                    {
                        var detailDelete = entities.OrderDetails.FirstOrDefault(a => a.ID == item);

                        detailDelete.IsDeleted = 1;
                        detailDelete.UpdateDate = dateNow;
                        detailDelete.UpdateUser = userInfo.UserID;

                        entities.SaveChanges();
                    }

                    foreach (var detail in orderDetailExist)
                    {
                        var orderDetail = entities.OrderDetails.FirstOrDefault(x => x.ID == detail.ID);

                        if (orderDetail != null)
                        {
                            orderDetail = AutoMapperHelper.Update(detail, orderDetail);

                            orderDetail.UpdateDate = dateNow;
                            orderDetail.UpdateUser = userInfo.UserID;

                            entities.SaveChanges();
                        }
                    }

                    var orderDetailNotExist = orderUpdate.Details.Where(x => x.ID == 0).ToList();

                    var createDetail = orderDetailNotExist.Select(x => new OrderDetail
                    {
                        OrderID = order.ID,
                        ProductID = x.ProductID,
                        MaterialTypeID = x.MaterialTypeID,
                        ConstructionTypeID = x.ConstructionTypeID,
                        Length = x.Length,
                        Width = x.Width,
                        Quantity = x.Quantity,
                        Price = x.Price,
                        TotalPrice = x.TotalPrice,
                        CreateDate = dateNow,
                        CreateUser = userInfo.UserID,
                        UpdateUser = userInfo.UserID,
                        UpdateDate = dateNow
                    });

                    entities.OrderDetails.AddRange(createDetail);
                    entities.SaveChanges();
                }

                // Lưu ý check điều kiện đúng sai ngay đây
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

        public bool DeleteOrder(int OrderID, UserInfo userInfo, ref string err)
        {
            try
            {
                var dateNow = Utils.DateTimeNow();

                var order = entities.Orders.Where(x => x.ID == OrderID && x.IsDeleted == 0)
                                           .Include(x => x.OrderDetails).FirstOrDefault();
                
                if (order == null)
                {
                    err = "Phiếu giao hàng này không tồn tại";

                    return false;
                }

                order.IsDeleted = 1;

                order.UpdateDate = dateNow;
                order.UpdateUser = userInfo.UserID;

                foreach (var item in order.OrderDetails)
                {
                    item.IsDeleted = 1;
                    item.UpdateDate = dateNow;
                    item.UpdateUser = userInfo.UserID;
                }

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

        public bool DeleteOrderCode(string OrderCode, UserInfo userInfo, ref string err)
        {
            try
            {
                var dateNow = Utils.DateTimeNow();

                var order = entities.Orders.Where(x => x.Code == OrderCode && x.IsDeleted == 0)
                                           .Include(x => x.OrderDetails).FirstOrDefault();

                if (order == null)
                {
                    err = "Phiếu giao hàng này không tồn tại";

                    return false;
                }

                order.IsDeleted = 1;

                order.UpdateDate = dateNow;
                order.UpdateUser = userInfo.UserID;

                foreach (var item in order.OrderDetails)
                {
                    item.IsDeleted = 1;
                    item.UpdateDate = dateNow;
                    item.UpdateUser = userInfo.UserID;
                }

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
    }
}