using System;
using SMS.DAL.Repositories;
using SMS.Models.Contracts;

namespace SMS.BLL.Service
{
    public class DataService : IService, IDisposable
    {
        private IUnitOfWork unitOfWork;
        public IUnitOfWork UnitOfWork
        {
            get
            {
                if (unitOfWork == null)
                    unitOfWork = new UnitOfWork();
                return unitOfWork;
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
