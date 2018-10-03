using SEDC.PracticalAspNet.Business.Contracts;
using SEDC.PracticalAspNet.Common.Contracts;
using SEDC.PracticalAspNet.Data.Models;
using SEDC.PracticalAspNet.Data.Repository;
using System;
using System.Linq;

namespace SEDC.PracticalAspNet.Business.Service
{
    public class OrdersService : BaseService<OrderRepository>, IOrdersService, IService<DtoOrder>, IDisposable
    {
        public ServiceResult<DtoOrder> Add(DtoOrder order)
        {
            using (var transaction = DbContext.Database.BeginTransaction())
            {
                try
                {
                    //TODO: Implement validation
                    var newOrder = new Order
                    {
                        Id = 0,
                        StatusId = (byte)OrderStatus.Created,
                        Table = order.Table,
                        WhenCreated = DateTime.UtcNow
                    };
                    DbContext.Orders.Add(newOrder);
                    DbContext.SaveChanges();
                    DbContext.OrderItems.AddRange(order.OrderItems.Select(o => new OrderItem
                    {
                        Id = 0,
                        ItemId = o.ItemId,
                        OrderId = newOrder.Id,
                        Quantity = o.Quantity
                    }));
                    transaction.Commit();
                    return new ServiceResult<DtoOrder>
                    {
                        Success = true,
                        Item = new DtoOrder(newOrder)
                    };
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return new ServiceResult<DtoOrder>
                    {
                        Success = false,
                        Exception = ex,
                        ErrorMessage = "an exception occurred"
                    };
                }
            }
        }

        public ServiceResult<DtoOrder> Edit(DtoOrder order)
        {
            try
            {
                //TODO: Implement validation
                if (order == null) return new ServiceResult<DtoOrder>
                {
                    Success = false,
                    Exception = new ArgumentNullException("order")
                };

                var dbOrder = DbContext.Orders.FirstOrDefault(x => x.Id == order.Id);
                if (dbOrder == null) return new ServiceResult<DtoOrder>
                {
                    Success = false,
                    ErrorMessage = "order not found"
                };

                dbOrder.Table = order.Table;
                DbContext.SaveChanges();
                return new ServiceResult<DtoOrder>
                {
                    Success = true,
                    Item = new DtoOrder(dbOrder)
                };
            }
            catch (Exception ex)
            {
                return new ServiceResult<DtoOrder>
                {
                    Success = false,
                    Exception = ex,
                    ErrorMessage = "an exception occurred"
                };
            }
        }

        public ServiceResult<DtoOrder> Load(DtoOrder item)
        {
            throw new NotImplementedException();
        }

        public ServiceResult<DtoOrder> LoadAll()
        {
            throw new NotImplementedException();
        }

        public ServiceResult<DtoOrder> Remove(DtoOrder item)
        {
            throw new NotImplementedException();
        }

        public ServiceResult<DtoOrderItem> SetOrderItem(DtoOrderItem orderItemDto)
        {
            try
            {
                var dbOrderItem = DbContext.OrderItems
                    .FirstOrDefault(oi => oi.Id == orderItemDto.Id);

                if (dbOrderItem != null)
                {
                    if (dbOrderItem.Quantity == orderItemDto.Quantity)
                        return new ServiceResult<DtoOrderItem>
                        {
                            Success = true,
                            Item = new DtoOrderItem(dbOrderItem)
                        };
                    if (orderItemDto.Quantity > 0)
                    {
                        //exists => update-it
                        dbOrderItem.Quantity = orderItemDto.Quantity;
                        DbContext.SaveChanges();
                        return new ServiceResult<DtoOrderItem>
                        {
                            Success = true,
                            Item = new DtoOrderItem(dbOrderItem)
                        };
                    }
                    else if (orderItemDto.Quantity == 0)
                    {
                        //exists => delete-it
                        DbContext.OrderItems.Remove(dbOrderItem);
                        DbContext.SaveChanges();
                        return new ServiceResult<DtoOrderItem>
                        {
                            Success = true
                        };
                    }
                    else
                    {
                        //exists => return error because quantity cannot be negative
                        return new ServiceResult<DtoOrderItem>
                        {
                            Success = false,
                            ErrorMessage = "quantity cannot be negative"
                        };
                    }
                }
                else
                {
                    //TODO: Validation
                    if (orderItemDto.Quantity < 1)
                        return new ServiceResult<DtoOrderItem>
                        {
                            Success = false,
                            ErrorMessage = "quantity cannot be negative or zero"
                        };

                    var orderExists = DbContext.Orders
                        .Any(o => o.Id == orderItemDto.OrderId);

                    var itemExists = DbContext.Items
                        .Any(i => i.Id == orderItemDto.ItemId);

                    if (!orderExists)
                        return new ServiceResult<DtoOrderItem>
                        {
                            Success = false,
                            ErrorMessage = "order not found"
                        };

                    if (!itemExists)
                        return new ServiceResult<DtoOrderItem>
                        {
                            Success = false,
                            ErrorMessage = "item not found"
                        };

                    var newOrderItem = new OrderItem
                    {
                        ItemId = orderItemDto.ItemId,
                        OrderId = orderItemDto.OrderId,
                        Quantity = orderItemDto.Quantity
                    };

                    DbContext.OrderItems.Add(newOrderItem);
                    DbContext.SaveChanges();
                    return new ServiceResult<DtoOrderItem>
                    {
                        Success = true,
                        Item = new DtoOrderItem(newOrderItem)
                    };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResult<DtoOrderItem>
                {
                    Success = false,
                    Exception = ex
                };
            }
        }
    }
}
