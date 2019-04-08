using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using MVCBookStore.Models;

namespace MVCBookStore.Controllers
{
    public class SACHController : Controller
    {
        private QLBANSACHEntities db = new QLBANSACHEntities();

        // GET: SACH
        public ActionResult Index(string searchString, int maCD = 0, int maNXB = 0)
        {
            //1. Tạo danh sách danh mục để hiển thị ở giao diện View thông qua DropDownList
            var chudes = from c in db.CHUDEs select c;
            ViewBag.maCD = new SelectList(chudes, "MaCD", "TenChuDe"); // danh sách ChuDe

            var nhaxbs = from n in db.NHAXUATBANs select n;
            ViewBag.maNXB = new SelectList(nhaxbs, "MaNXB", "TenNXB"); // danh sach nha xuat ban

            // (1 cach) Tạo câu truy vấn kết 2 bảng Sach, ChuDe bằng mệnh đề join
            //var sachs = from l in data.SACHes
            //            join c in data.CHUDEs on l.MaCD equals c.MaCD
            //            join n in data.NHAXUATBANs on l.MaNXB equals n.MaNXB
            //            select new { l.Masach, l.Tensach, l.Giaban, l.Mota, l.Anhbia, l.Anhmota, l.Ngaycapnhat, l.Soluongton, l.MaCD, l.MaNXB, c.TenChuDe, n.TenNXB };

            var sachs = db.SACHes.Include(l => l.CHUDE).Include(l => l.NHAXUATBAN);
            //sachs = data.SACHes.Where(x=>x.NHAXUATBAN.TenNXB.Contains(searchString));


            //3. Tìm kiếm chuỗi truy vấn
            if (!String.IsNullOrEmpty(searchString))
            {
                sachs = sachs.Where(s => s.Tensach.Contains(searchString));
            }

            //4. Tìm kiếm theo MaCD va maNXB
            if (maCD != 0)
            {
                sachs = sachs.Where(x => x.MaCD == maCD);
            }

            if (maNXB != 0)
            {
                sachs = sachs.Where(x => x.MaNXB == maNXB);
            }

            //5. Chuyển đổi kết quả từ var sang danh sách List<Sach>
            //List<SACH> listSachs = new List<SACH>();
            //foreach (var item in sachs)
            //{
            //    SACH temp = new SACH
            //    {
            //        MaCD = item.MaCD,
            //        TenChuDe = item.TenChuDe,
            //        Giaban = item.Giaban,
            //        Mota = item.Mota,
            //        Anhbia = item.Anhbia,
            //        Anhmota = item.Anhmota,
            //        Ngaycapnhat = item.Ngaycapnhat,
            //        Soluongton = item.Soluongton,
            //        Masach = item.Masach,
            //        Tensach = item.Tensach,
            //        TenNXB = item.TenNXB
            //    };
            //    listSachs.Add(temp);
            //}

            return View(sachs.ToList());
        }

        // GET: SACH/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SACH sACH = db.SACHes.Find(id);
            if (sACH == null)
            {
                return HttpNotFound();
            }
            return View(sACH);
        }

        // GET: SACH/Create
        public ActionResult Create()
        {
            ViewBag.MaCD = new SelectList(db.CHUDEs, "MaCD", "TenChuDe");
            ViewBag.MaNXB = new SelectList(db.NHAXUATBANs, "MaNXB", "TenNXB");
            return View();
        }

        // POST: SACH/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Masach,Tensach,Giaban,Mota,Anhbia,Anhmota,Ngaycapnhat,Soluongton,MaCD,MaNXB")] SACH sACH)
        {
            if (ModelState.IsValid)
            {
                db.SACHes.Add(sACH);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaCD = new SelectList(db.CHUDEs, "MaCD", "TenChuDe", sACH.MaCD);
            ViewBag.MaNXB = new SelectList(db.NHAXUATBANs, "MaNXB", "TenNXB", sACH.MaNXB);
            return View(sACH);
        }

        // GET: SACH/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SACH sACH = db.SACHes.Find(id);
            if (sACH == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaCD = new SelectList(db.CHUDEs, "MaCD", "TenChuDe", sACH.MaCD);
            ViewBag.MaNXB = new SelectList(db.NHAXUATBANs, "MaNXB", "TenNXB", sACH.MaNXB);
            return View(sACH);
        }

        // POST: SACH/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Masach,Tensach,Giaban,Mota,Anhbia,Anhmota,Ngaycapnhat,Soluongton,MaCD,MaNXB")] SACH sACH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sACH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaCD = new SelectList(db.CHUDEs, "MaCD", "TenChuDe", sACH.MaCD);
            ViewBag.MaNXB = new SelectList(db.NHAXUATBANs, "MaNXB", "TenNXB", sACH.MaNXB);
            return View(sACH);
        }

        // GET: SACH/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SACH sACH = db.SACHes.Find(id);
            if (sACH == null)
            {
                return HttpNotFound();
            }
            return View(sACH);
        }

        // POST: SACH/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SACH sACH = db.SACHes.Find(id);
            db.SACHes.Remove(sACH);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
