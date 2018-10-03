namespace SEDC.PracticalAspNet.Business.Contracts
{
    public interface IBaseService<T>
    {
        T Repository { get; }
    }
}