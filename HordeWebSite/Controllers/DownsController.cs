using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HordeWebSite.Data;
using HordeWebSite.Models;

namespace HordeWebSite.Controllers
{
    public class DownsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DownsController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult getCarouselAllDown()
        {
            IEnumerable<Down> ret = _db.Down.ToList();
            return PartialView("_PartialCarousel",ret);
        }
    }
}
