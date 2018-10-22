using AviShop.Data.Infrastructure;
using AviShop.Data.Repositories;
using AviShop.Model.Models;
using System.Collections.Generic;

namespace AviShop.Service
{
    public interface IProductCategoryService
    {
        ProductCategory Add(ProductCategory productCategory);

        void Update(ProductCategory producCategory);

        void Delete(int data);

        IEnumerable<ProductCategory> GetAll();

        IEnumerable<ProductCategory> GetAllByParentId(int parentId);

        ProductCategory GetById(int id);
    }

    public class ProductCategoryService : IProductCategoryService
    {
        #region Properties

        private IProductCategoryRepository _productCategoryRepository;
        private IUnitOfWork _unitOfWork;

        #endregion Properties

        #region ================Constructor==============

        public ProductCategoryService(IProductCategoryRepository productCategoryRepository,
                                       IUnitOfWork unitOfWork)
        {
            this._productCategoryRepository = productCategoryRepository;
            this._unitOfWork = unitOfWork;
        }

        #endregion ================Constructor==============

        #region ===============Function=============

        public ProductCategory Add(ProductCategory productCategory)
        {
            return _productCategoryRepository.Add(productCategory);
        }

        public void Update(ProductCategory producCategory)
        {
            _productCategoryRepository.Update(producCategory);
        }

        public void Delete(int data)
        {
            _productCategoryRepository.Delete(data);
        }

        public IEnumerable<ProductCategory> GetAll()
        {
            return _productCategoryRepository.GetAll();
        }

        public IEnumerable<ProductCategory> GetAllByParentId(int parentId)
        {
            return _productCategoryRepository.GetMulti(x => x.Status && x.ParentID == parentId);
        }

        public ProductCategory GetById(int id)
        {
            return _productCategoryRepository.GetSingleById(id);
        }

        #endregion ===============Function=============
    }
}