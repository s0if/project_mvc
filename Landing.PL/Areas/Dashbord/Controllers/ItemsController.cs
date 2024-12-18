﻿using AutoMapper;
using Landing.DAL.Data;
using Landing.DAL.Models;
using Landing.PL.Areas.Dashbord.ViewModels;
using Landing.PL.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Landing.PL.Areas.Dashbord.Controllers
{
    [Area("Dashbord")]
    public class ItemsController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ItemsController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            return View(mapper.Map<IEnumerable<BuildingVM>>(context.Buildings.ToList()));
        }
        [HttpGet]
        public IActionResult create()
        {
            var VM = new ItemsFormVM()
            {
                Buildings = mapper.Map<IEnumerable<BuildingVM>>(context.Buildings.ToList())
            };
            return View(VM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult create( ItemsFormVM VM)
        {
            if (ModelState.IsValid)
            {
               return Redirect(nameof(Index));
            }
            return View(VM);


        }
        [HttpGet]
        public IActionResult details(Guid id)
        {
            var details = context.Buildings.Find(id);
            if (details == null)
            {
                return NotFound();
            }
            return View(mapper.Map<BuildingDetailsVM>(details));

        }
        [HttpGet]
        public IActionResult edit(Guid id)
        {
            var building = context.Buildings.Find(id);
            if (building == null)
            {
                return NotFound();
            }

            return View(mapper.Map<BuildingFormVM>(building));
        }
        [HttpPost, ActionName("edit")]
        [ValidateAntiForgeryToken]
        public IActionResult edit(BuildingFormVM VM)
        {
            var isbuilding = context.Buildings.Find(VM.Id);
            if (VM.image is null)
            {
                ModelState.Remove("image");
            }
            else
            {

                FileSetting.deleteFile("Images", VM.Imageaname);
                VM.Imageaname = FileSetting.uploadFile(VM.image, "Images");
            }
            if (ModelState.IsValid)
            {



                if (isbuilding is not null)
                {
                    var building = mapper.Map(VM, isbuilding);
                    context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                return NotFound();
            }

            return View(VM);
        }
        [HttpGet]
        //public IActionResult delete(Guid id)
        //{
        //    var deleteBuilding = context.Buildings.Find(id);
        //    return View(mapper.Map<BuildingVM>(deleteBuilding));

        //}
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult delete(Guid id)
        {
            var deleteBuilding = context.Buildings.Find(id);

            if (deleteBuilding is not null)
            {
                FileSetting.deleteFile("Images", deleteBuilding.Imageaname);
                context.Buildings.Remove(deleteBuilding);
                context.SaveChanges();
                return Ok(new { messege = "building is deleted" });

            }
            return Ok();

        }

    }
}
