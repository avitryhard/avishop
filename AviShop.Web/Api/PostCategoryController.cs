using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using AviShop.Model.Models;
using AviShop.Service;
using AviShop.Web.Infrastructure.Core;
using AviShop.Web.Infrastructure.Extensions;
using AviShop.Web.Models;

namespace AviShop.Web.Api
{
    [RoutePrefix("api/postcategory")]
    public class PostCategoryController : ApiControllerBase
    {
        private readonly IPostCategoryService _postCategoryService;

        public PostCategoryController(IErrorService errorService, IPostCategoryService postCategoryService)
            : base(errorService)
        {
            this._postCategoryService = postCategoryService;
        }

        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var listCategory = _postCategoryService.GetAll();

                var listPostCategoryVM = Mapper.Map<List<PostCategoryViewModel>>(listCategory);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listPostCategoryVM);

                return response;
            });
        }
        
        [Route("add")]
        public HttpResponseMessage Post(HttpRequestMessage request, PostCategoryViewModel postCategoryVM)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    PostCategory newPostCategory = new PostCategory();
                    newPostCategory.UpdatePostCategory(postCategoryVM);

                    var category = _postCategoryService.Add(newPostCategory);
                    _postCategoryService.Save();

                    response = request.CreateResponse(HttpStatusCode.Created, category);

                }
                return response;
            });
        }
        
        [Route("update")]
        public HttpResponseMessage Put(HttpRequestMessage request, PostCategoryViewModel postCategoryVM)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var postCategoryDb = _postCategoryService.GetByID(postCategoryVM.ID);
                    postCategoryDb.UpdatePostCategory(postCategoryVM);
                    _postCategoryService.Update(postCategoryDb);
                    _postCategoryService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }

        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    _postCategoryService.Delete(id);
                    _postCategoryService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
    }
}