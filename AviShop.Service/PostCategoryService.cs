using AviShop.Data.Infrastructure;
using AviShop.Data.Repositories;
using AviShop.Model.Models;
using System.Collections.Generic;

namespace AviShop.Service
{
    public interface IPostCategoryService
    {
        PostCategory Add(PostCategory postCategory);

        PostCategory Delete(int id);

        void Update(PostCategory postCategory);

        IEnumerable<PostCategory> GetAll();        

        IEnumerable<PostCategory> GetAllByParentId(int parentId);

        PostCategory GetByID(int id);

        void Save();
    }

    public class PostCategoryService : IPostCategoryService
    {
        #region===============Properties=======================
        private IPostCategoryRepository _postCategoryRepository;
        private IUnitOfWork _unitOfWork;
        #endregion

        #region===============Contructor=======================

        public PostCategoryService(IPostCategoryRepository postCategoryRepository,
                                    IUnitOfWork unitOfWork)
        {
            this._postCategoryRepository = postCategoryRepository;
            this._unitOfWork = unitOfWork;
        }

        #endregion

        #region================Function========================

        public PostCategory Add(PostCategory postCategory)
        {
            return _postCategoryRepository.Add(postCategory);
        }

        public PostCategory Delete(int id)
        {
            return _postCategoryRepository.Delete(id);
        }

        public IEnumerable<PostCategory> GetAll()
        {
            return _postCategoryRepository.GetAll();
        }

        public IEnumerable<PostCategory> GetAllByParentId(int parentId)
        {
            return _postCategoryRepository.GetMulti(x => x.Status && x.ParentID == parentId);
        }

        public PostCategory GetByID(int id)
        {
            return _postCategoryRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(PostCategory postCategory)
        {
            _postCategoryRepository.Update(postCategory);
        }

        #endregion
    }
}