using MVCBookStore.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVCBookStore.Controllers
{
    public class DonDatHangController : Controller
    {
        QLBANSACHEntities db = new QLBANSACHEntities();
        // GET: DonDatHang
        public ActionResult Index(int? page)
        {
            var pageNumber = page ?? 1;
            var pageSize = 5;
            var donHangList = db.DONDATHANGs.OrderByDescending(x => x.MaDonHang).ToPagedList(pageNumber, pageSize);

            return View(donHangList);
        }

        // GET: DonDatHang/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var dONDATHANG = db.DONDATHANGs.Find(id);
            if (dONDATHANG == null)
            {
                return HttpNotFound();
            }
            return View(dONDATHANG);   
        }

    }
}
