using AutoMapper;
using AviShop.Model.Models;
using AviShop.Service;
using AviShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace AviShop.Web.Controllers
{
    public class HomeController : Controller
    {
        IProductCategoryService _productCategoryService;
        IProductService _productService;
        ICommonService _commonService;
        
        public HomeController(IProductService productService,IProductCategoryService productCategoryService, ICommonService commonService)
        {
            this._productCategoryService = productCategoryService;
            this._productService = productService;
            this._commonService = commonService;
        }

        [OutputCache(Duration = 60, Location = OutputCacheLocation.Client)]
        public ActionResult Index()
        {
            var slideModel = _commonService.GetSlides();
            var slideView = Mapper.Map<IEnumerable<Slide>, IEnumerable<SlideViewModel>>(slideModel);
            var homeViewModel = new HomeViewModel();
            homeViewModel.Slides = slideView;

            var lastedProductModel = _productService.GetLasted(3);
            var topSaleProductModel = _productService.GetHotProduct(3);
            var lastedProductView = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(lastedProductModel);
            var topSaleProductView = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(topSaleProductModel);
            homeViewModel.LastedProducts = lastedProductView;
            homeViewModel.TopSaleProducts = topSaleProductView;
            return View(homeViewModel);
        }

        [ChildActionOnly]
        [OutputCache(Duration = 3600)]
        public ActionResult Footer()
        {
            var footerModel = _commonService.GetFooter();
            var footerViewModel = Mapper.Map<Footer, FooterViewModel>(footerModel);
            return PartialView(footerViewModel);
        }

        [ChildActionOnly]
        public ActionResult Header()
        {
            return PartialView();
        }

        [ChildActionOnly]
        [OutputCache(Duration = 3600)]
        public ActionResult Category()
        {
            var model = _productCategoryService.GetAll();
            var listProductCategoryViewModel = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(model);
            return PartialView(listProductCategoryViewModel);
        }
    }
}