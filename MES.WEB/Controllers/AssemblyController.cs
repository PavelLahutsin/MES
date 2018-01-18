﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using MES.BLL.DTO;
using MES.BLL.Interfaces;
using MES.DAL.Entities;
using MES.DAL.Interfaces;
using MES.WEB.Models;

namespace MES.WEB.Controllers
{
    public class AssemblyController : Controller
    {
        private readonly IAssemblyService _service;
        private readonly IUnitOfWork _db;

        public AssemblyController(IAssemblyService service, IUnitOfWork db)
        {
            _service = service;
            _db = db;
        }


        /// <summary>
        /// Главная страница паек
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var now = DateTime.Now;
            var date = new DateVm
            {
                StartDate = new DateTime(now.Year, now.Month, 1),
                EndDate = now
            };
            return View(date);
        }

        public async Task<ActionResult> AddAssemblyPartial()
        {
            var assembly = new AssemblyVm { Date = DateTime.Now };
            var products = Mapper.Map<IEnumerable<Product>, List<ProductVm>>(await _db.Products.GetAllAsync());
            ViewBag.Products = new SelectList(products, "Id", "Name");
            return PartialView(assembly);
        }

        [HttpPost]
        public async Task<ActionResult> AddAssemblyPartial(AssemblyVm assembly)
        {
            var products = Mapper.Map<IEnumerable<Product>, List<ProductVm>>(await _db.Products.GetAllAsync());
            ViewBag.Products = new SelectList(products, "Id", "Name");
            if (ModelState.IsValid)
            {
                

                var result = await _service.AddAssemblyAsync(Mapper.Map<AssemblyDto>(assembly));

                if (result.Succedeed)
                    return RedirectToAction("Index");
                else
                    ModelState.AddModelError(result.Property, result.Message);
            }
            return PartialView(assembly);
        }




        public async Task<ActionResult> ShowAssemblyListPartial(string startDate, string endDate)
        {


            var assemblyVm = Mapper.Map<IEnumerable<AssemblyDto>, List<AssemblyVm>>(
                await _service.ShowAssemblysAsync(startDate, endDate));
            return PartialView(assemblyVm);
        }


        

        public async Task<ActionResult> DeleteAssembly(int id)
        {

            var result = await _service.DeleteAssembly(id);
            return RedirectToAction("Index");

        }
    }
}