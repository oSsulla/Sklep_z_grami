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
    public class GameController : Controller
    {
        private readonly IGameService _service;

        public GameController(IGameService service)
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
        public async Task<IActionResult> Create([Bind("Nazwa,ImageURL,Opis,PublisherId,ShopId")] Game game)
        {
            if (!ModelState.IsValid)
            {
                return View(game);
            }
            await _service.addAsync(game);
            return RedirectToAction(nameof(Index));
        }

        //DETAILS
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var gameDetails = await _service.GetByIdAsync(id);
            if (gameDetails == null) return View("NotFound");
            return View(gameDetails);
        }

        //EDIT
        public async Task<IActionResult> Edit(int id)
        {
            var gameDetails = await _service.GetByIdAsync(id);
            if (gameDetails == null) return View("NotFound");
            return View(gameDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nazwa,ImageURL,Opis,PublisherId,ShopId")] Game game)
        {
            if (!ModelState.IsValid)
            {
                return View(game);
            }
            await _service.UpdateAsync(id, game);
            return RedirectToAction(nameof(Index));
        }

        //DELETE
        public async Task<IActionResult> Delete(int id)
        {
            var gameDetails = await _service.GetByIdAsync(id);
            if (gameDetails == null) return View("NotFound");
            return View(gameDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gameDetails = await _service.GetByIdAsync(id);
            if (gameDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
