using System;
using SEDC.PracticalAspNet.Business.Contracts;
using SEDC.PracticalAspNet.Data.Repository;

namespace SEDC.PracticalAspNet.Business.Service
{
    public class BaseService<T> : BaseRepository, IBaseService<T>, IDisposable where T : BaseRepository
    {
        public T Repository { get; private set; }
        public BaseService()
        {
            Repository = Activator.CreateInstance<T>();
        }

        public override void Dispose()
        {
            Repository.Dispose();
        }
    }
}
