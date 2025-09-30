using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LTWeb_Tuan05_Bai01.Models;
using LTWeb_Tuan05_Bai01.ViewModels;

namespace LTWeb_Tuan05_Bai01.Controllers
{
    public class Bai1Controller : Controller
    {
        //
        // GET: /Bai1/
        DuLieu csdl = new DuLieu();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult HienThiNhanVien()
        {
            List<Employee> dsnv = csdl.dsNV;
            return View(dsnv);
        }
        public ActionResult HienThiPhongBan()
        {
            List<Department> dspb = csdl.dsPhongBan;
            return View(dspb);
        }
        [HttpGet]
        public ActionResult Detail_PhongBan(int id)
        {
            DepartmentViewModel department = new DepartmentViewModel();
            Department ds = csdl.ChiTietPhongBan(id);
            List<Employee> dsnv = csdl.DanhSachNhanVienTheoMaPhong(id);
            department.Department = ds;
            department.Employees = dsnv;
            return View(department);
        }
    }
}
