using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using HordeWebSite.Data;
using HordeWebSite.Models;
using HordeWebSite.Models.ViewModel;


namespace HordeWebSite.Controllers
{
    public class GazettesController : Controller
    {
        private readonly ApplicationDbContext _db;

        private byte[] GetByteArrayFromImage(IFormFile file)
        {
            using (var target = new MemoryStream())
            {
                file.CopyTo(target);
                return target.ToArray();
            }
        }

        public GazettesController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<string> objList = _db.Gazettes.Select(o => o.date).Distinct().ToList();
            return View(objList);
        }


        public IActionResult OnSelectDate(string Date)
        {
            Gazette ret=new Gazette { };
            ret.date = Date;
            ret.page = 1;
            if (ret.date == null)
            {
                ret.date = _db.Gazettes.Max(g => g.date);
            }
            //ret.maxPage = _db.Gazettes.Where(g => g.date == ret.date).Count();

            ret.image = _db.Gazettes.Where(g => g.date == ret.date).Where(h => h.page == ret.page).FirstOrDefault().image;

            return PartialView("_PartialDetails", ret);
        }

        public IActionResult OnClickNext(string Date,string page)
        {
            Gazette ret;
            var _page = Int32.Parse(page);
            var max = _db.Gazettes.Where(g => g.date == Date).Count();

            if ( _page < max)
            {
                _page++;
            }
            else
            {
                _page = max;
            }
                

            ret = _db.Gazettes.Where(g => g.date == Date).Where(h => h.page == _page).FirstOrDefault();

            return PartialView("_PartialDetails", ret);
        }


        public int getMax(string Date)
        {
            var max = _db.Gazettes.Where(g => g.date == Date).Count();
            return max;
        }

        public IActionResult OnClickPrevious(string Date, string page)
        {
            Gazette ret;
            var _page = Int32.Parse(page);
            if (_page > 1)
            {
                _page--;
            }
            
            var max = _db.Gazettes.Where(g => g.date == Date).Count();

            if (_page > max)
            {
                _page=max;
            }

            ret = _db.Gazettes.Where(g => g.date == Date).Where(h => h.page == _page).FirstOrDefault();

            return PartialView("_PartialDetails", ret);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(GazetteForm _obj)
        {
            int pg = 1;
            foreach(var img in _obj.image)
            {
                var post = new Gazette()
                {
                    date = _obj.date,
                    page = pg
                };
                if (img != null)
                {
                    post.image = GetByteArrayFromImage(img);
                }
                _db.Gazettes.Add(post);
                _db.SaveChanges();
                pg++;
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(string str)
        {
            var Object=_db.Gazettes.Where(o => o.date.Contains(str));
            foreach(var obj in Object)
            {
                _db.Gazettes.Remove(_db.Gazettes.Find(obj.Id));
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(string str)
        {
            IEnumerable<Gazette> objList = _db.Gazettes.Where(o => o.date.Contains(str));
            return View("_PartialDetails", objList);
        }
    }
}
