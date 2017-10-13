using AutoMapper;
using SellAndBuy.Services;
using SellAndBuy.Services.Contracts;
using SellAndBuy.Web.Models;
using SellAndBuy.Web.Models.Adds;
using SellAndBuy.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using AutoMapper.QueryableExtensions;
using System.IO;
using System.Reflection;
using System.Web.Security;


namespace SellAndBuy.Web.Controllers
{
    public class AddController : Controller
    {
        private readonly IAddsServices addService;
        private readonly IMapper mapper;
        private readonly ICategoriesServices categoriesService;
        private readonly IProvincesServices provinceServices;
        private readonly ICitiesServices citiesServices;
        private readonly ImagesServices imageService;

        public AddController(IAddsServices service, IMapper mapper,
            ICategoriesServices categoriesService,
            IProvincesServices provinceServices,
            ICitiesServices citiesServices,
            ImagesServices imageService)
        {
            this.addService = service;
            this.mapper = mapper;
            this.categoriesService = categoriesService;
            this.provinceServices = provinceServices;
            this.citiesServices = citiesServices;
            this.imageService = imageService;
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult CreateAdd()
        {
            var allCategoris = this.categoriesService.GetAll().Select(x => x.CategorieName).ToList();
            var allProvinces = this.provinceServices.GetAll().Select(x => x.ProvinceName).ToList();
            var allCities = this.citiesServices.GetAll().Select(x => x.Name).ToList();


            var searchModel = new ListViewModel();
            searchModel.Categories = allCategoris;
            searchModel.Provinces = allProvinces;
            searchModel.Cities = allCities;
            return View(searchModel);
        }

        [HttpPost]
        public ActionResult CreateAdd(string cityName, string category, decimal price, string description, HttpPostedFileBase image)
        {

            var user = User.Identity.GetUserId();
            var categoryId = this.categoriesService.GetId(category);
            var cityId = this.citiesServices.GetId(cityName);

            var fileName = Path.GetFileName(image.FileName);
            string randomFileName = Path.GetFileNameWithoutExtension(fileName) +
                                "_" +
                                Guid.NewGuid().ToString()
                                    + Path.GetExtension(fileName);
            string path = Path.Combine(Server.MapPath("~/Content/Upload/"), randomFileName);
            image.SaveAs(path);
            this.imageService.CreateImage(path);




            this.addService.CreateAdd(user, cityId, categoryId, price, description, randomFileName);

            return RedirectToAction("MyAdds", "Add");

        }
        [HttpPost]
        public ActionResult Search(SearchViewModel searchModel)
        {
            IQueryable<AddViewModel> result = this.addService.GetAll().Where(x=>x.IsDeleted == false).ProjectTo<AddViewModel>();

            if (searchModel != null)
            {
                if (!string.IsNullOrEmpty(searchModel.Province))
                {
                    var searchModelProvinceId = this.provinceServices.GetId(searchModel.Province);
                    result = result.Where(x => x.ProvinceId == searchModelProvinceId);
                }

                if (!string.IsNullOrEmpty(searchModel.City))
                {
                    var searchModelCityId = this.citiesServices.GetId(searchModel.City);
                    result = result.Where(x => x.CityId == searchModelCityId);

                }

                if (!string.IsNullOrEmpty(searchModel.Category))
                {
                    var searchModelCateoryId = this.categoriesService.GetId(searchModel.Category);
                    result = result.Where(x => x.CategoryId == searchModelCateoryId);
                }

                if (!string.IsNullOrEmpty(searchModel.Description))
                    result = result.Where(x => x.Description.Contains(searchModel.Description));
            }


            return View("SearchedAdds", result.ToList());
        }
        [HttpGet]
        public ActionResult Search()
        {
            //da se mapnat kam view modeli
            var allCategoris = this.categoriesService.GetAll().Select(x => x.CategorieName).ToList();
            var allProvinces = this.provinceServices.GetAll().Select(x => x.ProvinceName).ToList();
            var allCities = this.citiesServices.GetAll().Select(x => x.Name).ToList();


            var searchModel = new SearchViewModel();
            searchModel.Categories = allCategoris;
            searchModel.Provinces = allProvinces;
            searchModel.Cities = allCities;


            return View(searchModel);
        }
        public ActionResult LoadConcreteAdd(Guid Id)
        {
            
            var foundAdd = this.addService.GetAll().ProjectTo<AddViewModel>().SingleOrDefault(x => x.Id == Id);
            var model =new  UserAddViewModel();

            model.Adds = foundAdd;
            model.TelephoneNumber = foundAdd.Phone;
            model.Email = foundAdd.Email;
            model.Name = foundAdd.Name;

            return View(model);
        }
        public JsonResult SelectCities(string id)
        {
            if (id != "")
            {
                var provinceId = this.provinceServices.GetId(id);
                var cities = this.citiesServices.GetCitiesByProvinceId(provinceId).ProjectTo<CityViewModel>();
                return Json(cities, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var cities = this.citiesServices.GetAll().ProjectTo<CityViewModel>();

                return Json(cities, JsonRequestBehavior.AllowGet);

            }

        }
        
        public ActionResult MyAdds(string userId)
        {
            var user = User.Identity.GetUserId();
            var usersAdds = this.addService.GetAll().Where(x => x.UserId == user&&x.IsDeleted==false).ProjectTo<AddViewModel>();
      
            return View(usersAdds);
        }
        [HttpGet  ]
        public ActionResult DeleteAdd(Guid Id)
        {
            this.addService.FindByIdAndDelete(Id);
            var user = User.Identity.GetUserId();
            this.TempData["add"] = "your add is deleted";
            return RedirectToAction("MyAdds", "Add",new {userId=user });
        }
    }
}