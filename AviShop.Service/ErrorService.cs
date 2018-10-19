using AviShop.Data.Infrastructure;
using AviShop.Data.Repositories;
using AviShop.Model.Models;

namespace AviShop.Service
{
    public partial interface IErrorService
    {
        Error Create(Error error);

        void Save();
    }

    public class ErrorService : IErrorService
    {
        #region Properties

        private IErrorRepository _errorRepository;
        private IUnitOfWork _unitOfWork;

        #endregion Properties

        #region ctor

        public ErrorService(ErrorRepository errorRepository, UnitOfWork unitOfWork)
        {
            this._errorRepository = errorRepository;
            this._unitOfWork = unitOfWork;
        }

        #endregion ctor

        #region Function

        public Error Create(Error error)
        {
            return _errorRepository.Add(error);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        #endregion Function
    }
}