using AutoMapper;
using AutoMapper.QueryableExtensions;
using Bytes2you.Validation;
using Microsoft.AspNet.Identity;
using SellAndBuy.Services.Contracts;
using SellAndBuy.Web.Models.Adds;
using SellAndBuy.Web.Models.Adds.AddModels;
using SellAndBuy.Web.Models.Adds.CityModels;
using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace SellAndBuy.Web.Controllers
{
    public class AddController : Controller
    {
        const int TakeLastElement = 5;
        private readonly IAddsServices addService;
        private readonly IMapper mapper;
        private readonly ICategoriesServices categoriesService;
        private readonly IProvincesServices provinceServices;
        private readonly ICitiesServices citiesServices;


        public AddController(
            IAddsServices service,
            IMapper mapper,
            ICategoriesServices categoriesService,
            IProvincesServices provinceServices,
            ICitiesServices citiesServices)

        {
            Guard.WhenArgument(service,"service").IsNull().Throw();
            Guard.WhenArgument(mapper, "mapper").IsNull().Throw();
            Guard.WhenArgument(categoriesService, "categoriesService").IsNull().Throw();
            Guard.WhenArgument(provinceServices, "provinceServices").IsNull().Throw();
            Guard.WhenArgument(citiesServices, "citiesServices").IsNull().Throw();

            this.addService = service;
            this.mapper = mapper;
            this.categoriesService = categoriesService;
            this.provinceServices = provinceServices;
            this.citiesServices = citiesServices;

        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult CreateAdd()
        {
            var allCategoris = this.categoriesService.GetAll().Select(x => x.CategorieName).ToList();
            var allCities = this.citiesServices.GetAll().Select(x => x.Name).ToList();

            var searchModel = new CreateAddViewModel();
            searchModel.Categories = allCategoris;
            searchModel.Cities = allCities;
            return View(searchModel);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAdd(CreationalAddModel model)
        {            
            if (this.ModelState.IsValid)
            {
                var user = User.Identity.GetUserId();
                var categoryId = this.categoriesService.GetId(model.Category);
                var cityId = this.citiesServices.GetId(model.CityName);
                var image = model.File;

                var fileName = Path.GetFileName(image.FileName);
                string randomFileName = Path.GetFileNameWithoutExtension(fileName) +
                                    "_" +
                                    Guid.NewGuid().ToString()
                                        + Path.GetExtension(fileName);
                var path = Server.MapPath("~/Content/Upload/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                path = Path.Combine(Server.MapPath("~/Content/Upload/"), randomFileName);
                image.SaveAs(path);

                this.addService.CreateAdd(user, cityId, categoryId, model.Price, model.Description, randomFileName);

                return RedirectToAction("MyAdds", "Add");
            }
            else
            {               
                return View();
            }           
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(SearchedValuesViewModel searchModel)
        {
            IQueryable<AddViewModel> result = this.addService.GetAllNotDeleted().ProjectTo<AddViewModel>();

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
            var res = result.ProjectTo<ResultSearchAddViewModel>();

            return View("SearchedAdds", res);
        }
        [HttpGet]
        public ActionResult Search()
        {
            var allCategoris = this.categoriesService.GetAll().Select(x => x.CategorieName).ToList();
            var allProvinces = this.provinceServices.GetAll().Select(x => x.ProvinceName).ToList();
            var allCities = this.citiesServices.GetAll().Select(x => x.Name).ToList();

            
            var searchModel = new SearchViewModel();
            searchModel.Categories = allCategoris;
            searchModel.Provinces = allProvinces;
            searchModel.Cities = allCities;

            return View(searchModel);
        }
        [ChildActionOnly]
        [OutputCache(Duration =60)]
        public ActionResult LoadLastFive()
        {
            var adds = this.addService.GetAllNotDeleted();
            var lastFive = adds.OrderByDescending(p => p.CreatedOn).Take(TakeLastElement).ProjectTo<MyAddsViewModel>();
            return PartialView("_LoadLastFive",lastFive);
        }
        [Authorize]
        public ActionResult LoadConcreteAdd(Guid Id)
        {
            var foundAdd = this.addService.GetAllNotDeleted().ProjectTo<AddDetailViewModel>().FirstOrDefault(x => x.Id == Id);
            
            return View(foundAdd);
        }
        public JsonResult SelectCities(string id)
        {
            if (id != "")
            {
                var provinceId = this.provinceServices.GetId(id);
                var cities = this.citiesServices.GetCitiesByProvinceId(provinceId).ProjectTo<SearchCityViewModel>();
                return Json(cities, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var cities = this.citiesServices.GetAll().ProjectTo<SearchCityViewModel>();

                return Json(cities, JsonRequestBehavior.AllowGet);

            }

        }
        [Authorize]
        public ActionResult MyAdds(string userId)
        {
            var user = User.Identity.GetUserId();
            var usersAdds = this.addService.GetAllNotDeleted().Where(x => x.UserId == user && x.IsDeleted == false).ProjectTo<MyAddsViewModel>();

            return View(usersAdds);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAdd(Guid Id)
        {
            var foundAdd = this.addService.FindById(Id);
            
            this.addService.FindByIdAndDelete(Id);
            var user = User.Identity.GetUserId();
            this.TempData["add"] = String.Format(@"Вашата обява - {0} 
                                                           беше успешно изтрита",foundAdd.Description);
            return RedirectToAction("MyAdds", "Add", new { userId = user });
        }
    }
}