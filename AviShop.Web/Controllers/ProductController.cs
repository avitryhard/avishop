using AutoMapper;
using AviShop.Common;
using AviShop.Model.Models;
using AviShop.Service;
using AviShop.Web.Infrastructure.Core;
using AviShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace AviShop.Web.Controllers
{
    public class ProductController : Controller
    {
        IProductService _productService;
        IProductCategoryService _productCategoryService;

        public ProductController(IProductService productService,IProductCategoryService productCategoryService)
        {
            this._productService = productService;
            this._productCategoryService = productCategoryService;
        }

        public ActionResult Detail(int id)
        {
            var productModel = _productService.GetById(id);
            var productView = Mapper.Map<Product, ProductViewModel> (productModel);
            var relatedProduct = _productService.GetRelatedProducts(id, 6);
            ViewBag.RelatedProducts = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(relatedProduct);

            var moreImages = productView.MoreImages;
            List<string> listImages = new JavaScriptSerializer().Deserialize<List<string>>(moreImages);
            ViewBag.MoreImages = listImages;

            ViewBag.Tags = Mapper.Map<IEnumerable<Tag>,IEnumerable<TagViewModel>>(_productService.GetListTagProductID(id));
            return View(productView);
        }

        public ActionResult Category(int id, string sort,int page = 1)
        {
            int pageSize = int.Parse(ConfigHelper.GetByKey("PageSize"));
            int totalRow = 0;
            var productModel = _productService.GetListProductByCategoryIDPaging(id, page, pageSize,sort, out totalRow);
            var productView = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(productModel);

            int totalPage = (int)Math.Ceiling((double)totalRow / pageSize);

            var category = _productCategoryService.GetById(id);
            ViewBag.Category = Mapper.Map<ProductCategory, ProductCategoryViewModel>(category);

            var paginationSet = new PaginationSet<ProductViewModel>()
            {
                Items = productView,
                MaxPage = int.Parse(ConfigHelper.GetByKey("MaxPage")),
                Page = page,
                TotalCount = totalRow,
                TotalPages = totalPage,                
            };
            return View(paginationSet);
        }
        public ActionResult ListByTag(string tagID, int page = 1)
        {
            int pageSize = int.Parse(ConfigHelper.GetByKey("PageSize"));
            int totalRow = 0;
            var productModel = _productService.GetListProductByTag(tagID, page, pageSize, out totalRow);
            var productViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(productModel);
            int totalPage = (int)Math.Ceiling((double)totalRow / pageSize);

            ViewBag.Tag = Mapper.Map<Tag, TagViewModel>(_productService.GetTag(tagID));
            var paginationSet = new PaginationSet<ProductViewModel>()
            {
                Items = productViewModel,
                MaxPage = int.Parse(ConfigHelper.GetByKey("MaxPage")),
                Page = page,
                TotalCount = totalRow,
                TotalPages = totalPage
            };

            return View(paginationSet);
        }
        public JsonResult GetListProductByName(string keyword)
        {
            var model = _productService.GetListProductByName(keyword);            

            return Json(new
            {
                data = model
            },JsonRequestBehavior.AllowGet);            
        }

        public ActionResult Search(string keyword, string sort, int page = 1)
        {
            int pageSize = int.Parse(ConfigHelper.GetByKey("PageSize"));
            int totalRow = 0;
            var productModel = _productService.Search(keyword, page, pageSize, sort, out totalRow);
            var productView = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(productModel);
            int totalPage = (int)Math.Ceiling((double)totalRow / pageSize);
            
            ViewBag.Keyword = keyword;
            var paginationSet = new PaginationSet<ProductViewModel>()
            {
                Items = productView,
                MaxPage = int.Parse(ConfigHelper.GetByKey("MaxPage")),
                Page = page,
                TotalCount = totalRow,
                TotalPages = totalPage,
            };
            return View(paginationSet);
        }
    }
}