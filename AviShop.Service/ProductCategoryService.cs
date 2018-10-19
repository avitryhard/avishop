using AviShop.Data.Infrastructure;
using AviShop.Data.Repositories;
using AviShop.Model.Models;
using System;
using System.Collections.Generic;

namespace AviShop.Service
{
    public interface IProductCategoryService
    {
        void Add(ProductCategory productCategory);

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
        #endregion

        #region ================Constructor==============

        public ProductCategoryService(IProductCategoryRepository productCategoryRepository,
                                       IUnitOfWork unitOfWork)
        {
            this._productCategoryRepository = productCategoryRepository;
            this._unitOfWork = unitOfWork;
        }

        #endregion ================Constructor==============

        #region ===============Function=============

        public void Add(ProductCategory productCategory)
        {
            throw new NotImplementedException();
        }

        public void Update(ProductCategory producCategory)
        {
            throw new NotImplementedException();
        }

        public void Delete(int data)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductCategory> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductCategory> GetAllByParentId(int parentId)
        {
            throw new NotImplementedException();
        }

        public ProductCategory GetById(int id)
        {
            throw new NotImplementedException();
        }

        #endregion ===============Function=============
    }
}