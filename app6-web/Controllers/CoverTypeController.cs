using Microsoft.AspNetCore.Mvc;
using ntier.DataAccess.Repository.IRepository;
using ntier.Models;
using ntire.DataAccess;

namespace app6_web.Controllers
{
    public class CoverTypeController : Controller
    {
        private readonly IUnitOfWork _db;
        public CoverTypeController(IUnitOfWork db)
        {
            _db = db;
        }
        //index
        public IActionResult Index()
        {
            IEnumerable<CoverType> CoverTypeList = _db.CoverType.GetAll();
            return View(CoverTypeList);
        }
        //Get
        public IActionResult Create()
        {
            return View();
        }
        //post
        [HttpPost]
        public IActionResult Create(CoverType obj)
        {
            if (ModelState.IsValid)
            {
                _db.CoverType.Add(obj);
                _db.Save();
                TempData["success"] = "دسته با موفقیت ایجاد شد";
                return RedirectToAction("Index");
            }
            return View(obj);


        }
        //Get
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //var categoryFromDb = _db.Categories.Find(id);
            var coverTypeFirst = _db.CoverType.GetFirstOrDefault(c => c.Id == id);
            //var categorySingel = _db.Categories.SingleOrDefault(c => c.Id == id);
            if (coverTypeFirst == null)
            {
                return NotFound();
            }
            return View(coverTypeFirst);
        }
        //post
        [HttpPost]
        public IActionResult Edit(CoverType obj)
        {
            
            if (ModelState.IsValid)
            {
                _db.CoverType.Update(obj);
                _db.Save();
                TempData["success"] = "دسته با موفقیت  ویرایش شد";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //Get
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //var categoryFromDb = _db.Categories.Find(id);
            var coverTypeFirst = _db.CoverType.GetFirstOrDefault(c => c.Id == id);
            //var categorySingel = _db.Categories.SingleOrDefault(c => c.Id == id);
            if (coverTypeFirst == null)
            {
                return NotFound();
            }
            return View(coverTypeFirst);
        }
        //post
        [HttpPost]
        public IActionResult DeletePost(int? id)
        {

            var obj = _db.CoverType.GetFirstOrDefault(c => c.Id == id); ;

            _db.CoverType.Remove(obj);
            _db.Save();
            TempData["success"] = "دسته با موفقیت  حذف شد";
            return RedirectToAction("Index");
        }

    }
}
