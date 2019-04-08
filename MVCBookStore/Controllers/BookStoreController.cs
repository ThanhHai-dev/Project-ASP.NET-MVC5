using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MVCBookStore.Models;
using System.Net;
using PagedList;

namespace MVCBookStore.Controllers
{
    public class BookStoreController : Controller
    {
        // GET: BookStore

        private QLBANSACHEntities data = new QLBANSACHEntities();


        private List<SACH> Laysachmoi(int count)
        {
            return data.SACHes.OrderByDescending(a => a.Masach).Take(count).ToList();
        }

        public ActionResult Index()
        {
            var sachmoi = Laysachmoi(8);
            return View(sachmoi);
        }

        public ActionResult Chude()
        {
            var chude = from cd in data.CHUDEs select cd;
            return PartialView(chude);
        }

        public ActionResult Nhaxuatban()
        {
            var nhaxb = from nxb in data.NHAXUATBANs select nxb;
            return PartialView(nhaxb);
        }

        public ActionResult SPTheochude(int id)
        {
            var sach = from s in data.SACHes where s.MaCD == id select s;
            return View(sach);
        }

        public ActionResult SPTheoNXB(int id)
        {
            var sach = from s in data.SACHes where s.MaNXB == id select s;
            return View(sach);
        }

        public ActionResult Details(int id)
        {
            var sach = from s in data.SACHes
                       where s.Masach == id
                       select s;
            return View(sach.Single());
        }

        private List<SACH> Laysach(int count)
        {
            return data.SACHes.OrderByDescending(a => a.Masach).Take(count).ToList();
        }

        public ActionResult SachmoiPartial()
        {
            var sachmoi = Laysach(3);
            return PartialView(sachmoi);
        }

        public ActionResult TatcaSach(string searchString)
        {
            var sachs = from l in data.SACHes select l;
            //var sach = from s in data.SACHes select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                sachs = sachs.Where(s => s.Tensach.Contains(searchString));
            }
            return View(sachs);
        }
    }
}