﻿using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using MES.BLL.DTO;
using MES.BLL.Interfaces;
using MES.WEB.Models;

namespace MES.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDetailService _detailOn;

        public HomeController(IDetailService detailOn)
        {
            _detailOn = detailOn;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            var details = Mapper.Map<IEnumerable<DetailDTO>, List<DetailVm>>(_detailOn.GetDetailsJmt());
            SelectList detailList = new SelectList(details, "Id", "Name");
            ViewBag.Detail = detailList;
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}