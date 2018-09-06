using SEDC.PracticalAspNet.Business.Model;
using SEDC.PracticalAspNet.Data.Model;
using SEDC.PracticalAspNet.Data.Repository;
using System;
using System.Linq;

namespace SEDC.PracticalAspNet.Business.Service
{
    public class OrdersService : BaseService<OrderRepository>, IService<DtoOrder>
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
                        OrderItemId = 0,
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

        public ServiceResult<DtoOrder> Edit(DtoOrder item)
        {
            throw new NotImplementedException();
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
    }
}
