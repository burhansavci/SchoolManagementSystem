using SMS.Models.Contracts;

namespace SMS.BLL.Service
{
    interface IService
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
