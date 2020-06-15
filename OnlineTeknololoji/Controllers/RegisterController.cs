using OnlineTeknololoji.DAL1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTeknololoji.Controllers
{
    public class RegisterController : Controller
    {
        teknomarketDB1Entities db = new teknomarketDB1Entities();  
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult SaveData(Uyeler model)
        {
            db.Uyeler.Add(model);
            db.SaveChanges();
            return Json("Kayıt Başarılı", JsonRequestBehavior.AllowGet);
        }
    }
}