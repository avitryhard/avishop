using AviShop.Data.Infrastructure;
using AviShop.Data.Repositories;
using AviShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        #endregion

        #region ctor
        public ErrorService(ErrorRepository errorRepository,UnitOfWork unitOfWork)
        {
            this._errorRepository = errorRepository;
            this._unitOfWork = unitOfWork;
        }
        #endregion

        #region Function
        public Error Create(Error error)
        {
            return _errorRepository.Add(error);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
        #endregion
    }
}
