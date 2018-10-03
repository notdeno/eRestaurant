using System;
using System.Collections.Generic;

namespace SEDC.PracticalAspNet.Data.Contracts
{
    public interface IRepository<T>: IDisposable
    {
        IList<T> GetAll();

        T Get(int id);

        T Create(T item);

        void Update(T item);

        void Delete(T item);
    }
}
