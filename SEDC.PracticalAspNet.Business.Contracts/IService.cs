using SEDC.PracticalAspNet.Common.Contracts;
using System;

namespace SEDC.PracticalAspNet.Business.Contracts
{
    public interface IService<T> : IDisposable
    {
        ServiceResult<T> LoadAll();

        ServiceResult<T> Load(T item);

        ServiceResult<T> Add(T item);

        ServiceResult<T> Edit(T item);

        ServiceResult<T> Remove(T item);
    }
}
