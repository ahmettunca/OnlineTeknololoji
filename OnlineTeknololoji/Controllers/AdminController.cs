using Newtonsoft.Json;
using OnlineTeknololoji.DAL1;
using OnlineTeknololoji.Models;
using OnlineTeknololoji.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace OnlineTeknololoji.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public GenericUnitOfWork _unitOfWork = new GenericUnitOfWork();
        
        public List<SelectListItem> GetCategory()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            var cat = _unitOfWork.GetRepositoryInstance<OnlineTeknololoji.DAL1.KategoriTablo>().GetAllRecords();
            foreach(var item in cat)
            {
                list.Add(new SelectListItem { Value = item.KategoriId.ToString(), Text = item.KategoriIsim });
            }
            return list;
        }
        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult Categories()
        {
            List<OnlineTeknololoji.DAL1.KategoriTablo> allcategories = _unitOfWork.GetRepositoryInstance<OnlineTeknololoji.DAL1.KategoriTablo>().GetAllRecordsIQueryable().Where(i => i.SilindiMi == false).ToList();
            return View(allcategories);
        }
        public ActionResult AddCategory()
        {
            return UpdateCategory(0);
        }
        public ActionResult UpdateCategory(int categoryId)
        {
            CategoryDetail cd;
            if (categoryId != null)
            {
                cd = JsonConvert.DeserializeObject<OnlineTeknololoji.Models.CategoryDetail>(JsonConvert.SerializeObject(_unitOfWork.GetRepositoryInstance<OnlineTeknololoji.DAL1.KategoriTablo>().GetFirstorDefault(categoryId)));
            }
            else
            {
                cd = new CategoryDetail();
            }
            return View("UpdateCategory",cd);
        }
        public ActionResult CategoryEdit(int catId)
        {
            return View(_unitOfWork.GetRepositoryInstance<OnlineTeknololoji.DAL1.KategoriTablo>().GetFirstorDefault(catId));
        }
        [HttpPost]
        public ActionResult CategoryEdit(KategoriTablo table)
        {
            _unitOfWork.GetRepositoryInstance<KategoriTablo>().Update(table);
            return RedirectToAction("Categories");
        }
        public ActionResult Product()
        {
            return View(_unitOfWork.GetRepositoryInstance<OnlineTeknololoji.DAL1.UrunTablo>().GetProduct());
        }
        public ActionResult ProductEdit(int productId)
        {
            ViewBag.CategoryList = GetCategory();
            return View(_unitOfWork.GetRepositoryInstance<OnlineTeknololoji.DAL1.UrunTablo>().GetFirstorDefault(productId));
        }
        [HttpPost]
        public ActionResult ProductEdit(UrunTablo table, HttpPostedFileBase file)
        {
            string pic = null;
            if (file != null)
            {
                pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/ProductImage/"), pic);
                // dosya yüklendi
                file.SaveAs(path);
            }
            table.UrunFoto = file != null ? pic : table.UrunFoto;
            table.DegistirilmeTarihi = DateTime.Now;
            _unitOfWork.GetRepositoryInstance<UrunTablo>().Update(table);
            return RedirectToAction("Product");
        }
        public ActionResult ProductAdd()
        {
            ViewBag.CategoryList = GetCategory();
            return View();
        }
        [HttpPost]
        public ActionResult ProductAdd(UrunTablo table, HttpPostedFileBase file)
        {
            string pic =null;
            if (file != null)
            {
                pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/ProductImage/"), pic);
                // dosya yüklendi
                file.SaveAs(path);
            }
            table.UrunFoto = pic;
            table.OlusturmaTarihi = DateTime.Now;
            _unitOfWork.GetRepositoryInstance<UrunTablo>().Add(table);
            return RedirectToAction("Product");
        }
    }
}