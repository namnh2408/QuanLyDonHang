using QuanLyDonHang.Lib;
using QuanLyDonHang.Model;
using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;

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
                    OrderDate = orderCreate.OrderDate,
                    IsDeleted = 0,
                    CreateDate = dateNow,
                    CreateUser = userInfo.UserID,
                    UpdateUser = userInfo.UserID,
                    UpdateDate = dateNow,
                    TotalMoney = orderCreate.TotalMoney,
                    VAT = orderCreate.VAT,
                    PrePayment = orderCreate.PrePayment,
                    FinalMoney = orderCreate.FinalMoney
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

                var order = entities.Orders.Where(x => x.ID == orderUpdate.ID && x.IsDeleted == 0)
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