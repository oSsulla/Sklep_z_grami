using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sklep_z_grami.Data;
using Sklep_z_grami.Data.Services;
using Sklep_z_grami.Data.Static;
using Sklep_z_grami.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sklep_z_grami.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ShopController : Controller
    {
        private readonly IShopsService _service;

        public ShopController(IShopsService service)
        {
            _service = service;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        //CREATE
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Nazwa,Logo,Lokalizacja")] Shop shop)
        {
            if (!ModelState.IsValid)
            {
                return View(shop);
            }
            await _service.addAsync(shop);
            return RedirectToAction(nameof(Index));
        }

        //DETAILS
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var shopDetails = await _service.GetByIdAsync(id);
            if (shopDetails == null) return View("NotFound");
            return View(shopDetails);
        }

        //EDIT
        public async Task<IActionResult> Edit(int id)
        {
            var shopDetails = await _service.GetByIdAsync(id);
            if (shopDetails == null) return View("NotFound");
            return View(shopDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("Id,Nazwa,Logo,Lokalizacja")] Shop shop)
        {
            if (!ModelState.IsValid)
            {
                return View(shop);
            }
            await _service.UpdateAsync(id, shop);
            return RedirectToAction(nameof(Index));
        }

        //DELETE
        public async Task<IActionResult> Delete(int id)
        {
            var shopDetails = await _service.GetByIdAsync(id);
            if (shopDetails == null) return View("NotFound");
            return View(shopDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shopDetails = await _service.GetByIdAsync(id);
            if (shopDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
