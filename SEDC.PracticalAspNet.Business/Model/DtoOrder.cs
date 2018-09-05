using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.PracticalAspNet.Business.Model
{
    public class DtoOrder
    {
        public int Id { get; set; }
        public List<DtoOrderItem> OrderItems { get; set; }
        public double Total { get; set; }
        public string Table { get; set; }
    }

    public class DtoOrderItem
    {
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
    }
}
