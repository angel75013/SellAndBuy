using AutoMapper.QueryableExtensions;
using SellAndBuy.Data.Models;
using SellAndBuy.Services.Contracts;
using SellAndBuy.Web.Areas.Admin.Models;
using System.Linq;
using System.Web.Mvc;

namespace SellAndBuy.Web.Areas.Admin.Controllers
{
    public class AdminController:Controller
    {
        private readonly IAddsServices addService;
        public AdminController(IAddsServices addService)
        {
            this.addService = addService;
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var adds = addService.GetAll().ProjectTo<AddAdmin>().ToList() ;
            return this.View(adds);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(Add add)
        {
            this.addService.FindByIdAndDelete(add.Id);
            return RedirectToAction("Index");
        }

    }
}