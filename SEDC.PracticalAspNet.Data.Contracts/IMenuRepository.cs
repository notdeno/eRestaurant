using System;
using SEDC.PracticalAspNet.Data.Models;

namespace SEDC.PracticalAspNet.Data.Contracts
{
    public interface IMenuRepository:IRepository<Menu>, IDisposable
    {
    }
}