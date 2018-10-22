using AutoMapper;
using AviShop.Model.Models;
using AviShop.Service;
using AviShop.Web.Infrastructure.Core;
using AviShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AviShop.Web.Api
{
    [RoutePrefix("api/productcategory")]
    public class ProductCategoryController : ApiControllerBase
    {
        private readonly IProductCategoryService _productCategoryService;
        public ProductCategoryController(IErrorService errorService, IProductCategoryService productCategoryService) 
            :base(errorService)
        {
            this._productCategoryService = productCategoryService;
        }

        [Route("getall")]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
             {
                 var model = _productCategoryService.GetAll();

                 var resposeData = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(model);

                 HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK,resposeData);

                 return response;
             });
        }
    }
}
