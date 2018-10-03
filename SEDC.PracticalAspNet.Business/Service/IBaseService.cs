using SEDC.PracticalAspNet.Data.Repository;
using System;

namespace SEDC.PracticalAspNet.Business.Service
{
    public interface IBaseService<T> : IDisposable where T : BaseRepository
    {
        T Repository { get; }
    }
}