using AviShop.Common;
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
    public interface ICommonService
    {
        Footer GetFooter();
        IEnumerable<Slide> GetSlides();
    }

    public class CommonService: ICommonService
    {
        IFooterRepository _footerRepository;
        ISlideRepository _slideRepository;
        IUnitOfWork _unitOfWork;

        public CommonService(ISlideRepository slideRepository,IFooterRepository footerRepository, IUnitOfWork unitOfWork)
        {
            this._slideRepository = slideRepository;
            this._footerRepository = footerRepository;
            this._unitOfWork = unitOfWork;
        }

        public Footer GetFooter()
        {
            return _footerRepository.GetSingleByCondition(x => x.ID == CommonConstants.DefaultFooterID);
        }

        public IEnumerable<Slide> GetSlides()
        {
            return _slideRepository.GetMulti(x => x.Status == true);
        }
    }
}
