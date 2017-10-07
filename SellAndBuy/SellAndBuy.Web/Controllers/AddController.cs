using AutoMapper;
using SellAndBuy.Services;
using SellAndBuy.Web.Models;
using SellAndBuy.Web.Models.Adds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SellAndBuy.Web.Controllers
{
    public class AddController: Controller
    {
        private readonly AddsServices service;
        //private readonly IMapper mapper;

        public AddController(AddsServices service)//, IMapper mapper)
        {
            this.service = service;
           // this.mapper = mapper;
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult CreateAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateAdd(AddViewModel model)
        {
            return View();
        }
    }
}