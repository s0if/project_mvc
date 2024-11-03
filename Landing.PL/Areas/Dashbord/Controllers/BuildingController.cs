using AutoMapper;
using Landing.DAL.Data;
using Landing.DAL.Models;
using Landing.PL.Areas.Dashbord.ViewModels;
using Landing.PL.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Landing.PL.Areas.Dashbord.Controllers
{
    [Area("Dashbord")]
    [Authorize(Roles ="Admin,superAdmin")]
    public class BuildingController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public BuildingController(ApplicationDbContext context, IMapper mapper)
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
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult create(BuildingFormVM VM)
        {
            if (ModelState.IsValid)
            {
                VM.Imageaname = FileSetting.uploadFile(VM.image, "Images");
                var building = mapper.Map<Building>(VM);
                context.Add(building);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
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
                VM.Imageaname= FileSetting.uploadFile(VM.image, "Images");
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
                return Ok(new {messege="building is deleted" });

            }
            return Ok();

        }

    }
}
