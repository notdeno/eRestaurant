using SEDC.PracticalAspNet.Business.Model;
using SEDC.PracticalAspNet.Data.Model;
using SEDC.PracticalAspNet.Data.Repository;
using System;

namespace SEDC.PracticalAspNet.Business.Service
{
    public class OrdersService : BaseService<OrderRepository>
    {
        public DtoOrder CreateOrder(DtoOrder order)
        {
            throw new NotImplementedException();
            using (var transaction = DbContext.Database.BeginTransaction())
            {
                DbContext.Orders.Add(new Order
                {
                    Id = 0,
                    StatusId = (byte)OrderStatus.Created,
                    Table = order.Table,
                    WhenCreated = DateTime.UtcNow
                });
            }
        }
    }
}
