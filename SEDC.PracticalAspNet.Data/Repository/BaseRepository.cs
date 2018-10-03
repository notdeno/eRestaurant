using System;

namespace SEDC.PracticalAspNet.Data.Repository
{
    public class BaseRepository : IDisposable
    {
        protected RestaurantContext DbContext { get; private set; }

        public BaseRepository()
        {
            DbContext = new RestaurantContext();
        }

        public virtual void Dispose()
        {
            DbContext?.Dispose();
        }
    }
}
