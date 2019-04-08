using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using MVCBookStore.Models;

namespace MVCBookStore.Controllers
{
    public class GioHangController : Controller
    {
        QLBANSACHEntities db = new QLBANSACHEntities();
        private readonly string strCart = "GioHang";
        // GET: GioHang
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DatHang(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            if(Session[strCart] == null)
            {
                List<GioHang> lstGHang = new List<GioHang>
                {
                    new GioHang(db.SACHes.Find(id),1)
                };
                Session[strCart] = lstGHang;
            }
            else
            {
                List<GioHang> lstGHang = (List<GioHang>)Session[strCart];
                int check = IsExistCheck(id);
                if (check == -1)
                    lstGHang.Add(new GioHang(db.SACHes.Find(id), 1));
                else
                    lstGHang[check].Soluong++;

                Session[strCart] = lstGHang;
            }
            return View("Index");
        }

        private int IsExistCheck(int? id)
        {
            List<GioHang> lstGHang = (List<GioHang>)Session[strCart];
            for (int i=0; i < lstGHang.Count; i++)
            {
                if (lstGHang[i].SACH.Masach == id) return i;
            }
            return -1;
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            int check = IsExistCheck(id);
            List<GioHang> lstGHang = (List<GioHang>)Session[strCart];
            lstGHang.RemoveAt(check);
            return View("Index");
        }
        public ActionResult Update(FormCollection f)
        {
            string[] quantities = f.GetValues("soluong");
            List<GioHang> lstGHang = (List<GioHang>)Session[strCart];
            for(int i = 0; i < lstGHang.Count; i++)
            {
                lstGHang[i].Soluong = Convert.ToInt32(quantities[i]);
            }
            Session[strCart] = lstGHang;
            return View("Index");
        }
        public ActionResult GioHangPartial()
        {
            return PartialView();
        }
        public ActionResult Thanhtoan()
        {
            return View("Thanhtoan");
        }
        public ActionResult Xacnhandathang(FormCollection frc)
        {
            List<GioHang> lstGHang = (List<GioHang>)Session[strCart];
            DONDATHANG donDatHang = new DONDATHANG()
            {
                TenKH = frc["hoTen"],
                SoDienthoaiKH = frc["soDienThoai"],
                DiachiKH = frc["diaChi"],
                Ngaydat = DateTime.Now,
                Ngaygiao = DateTime.Now,
                Dathanhtoan = false,
                Tinhtranggiohang = false,
                MaKH = int.Parse(Session["MaKH"].ToString())
            };
            db.DONDATHANGs.Add(donDatHang);
            db.SaveChanges();

            foreach (GioHang giohang in lstGHang)
            {
                CTDATHANG cTDATHANG = new CTDATHANG()
                {
                    MaDonHang = donDatHang.MaDonHang,
                    MaSach = giohang.SACH.Masach,
                    Soluong = giohang.Soluong,
                    Dongia = giohang.SACH.Giaban * giohang.Soluong
                };
                db.CTDATHANGs.Add(cTDATHANG);
                db.SaveChanges();
            }
            Session.Remove(strCart);
            return View("Dathangthanhcong");
        }

    }
}