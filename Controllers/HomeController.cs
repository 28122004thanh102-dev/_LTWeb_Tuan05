using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LTWeb_Tuan05_Bai03.Models;

namespace LTWeb_Tuan05_Bai03.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        DuLieu csdl = new DuLieu();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult HienThiLoai()
        {
            List<Loai> dsloai = csdl.dsLoai;
            return View(dsloai);
        }
        public ActionResult HienThiSP()
        {
            List<SanPham> dsSP = csdl.dsSP;
            return View(dsSP);
        }
    }
}
