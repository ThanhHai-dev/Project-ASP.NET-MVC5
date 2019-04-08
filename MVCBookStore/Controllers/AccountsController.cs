using MVCBookStore.Models;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCBookStore.Controllers
{
    public class AccountsController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(KHACHHANG user)
        {
            using (QLBANSACHEntities db = new QLBANSACHEntities())
            {
                var userDetails = db.KHACHHANGs.Where(x => x.Taikhoan == user.Taikhoan && x.Matkhau == user.Matkhau).SingleOrDefault();
                if (userDetails != null)
                {
                    
                    Session["MaKH"] = userDetails.MaKH.ToString();
                    Session["HoTen"] = userDetails.HoTen.ToString();
                    return RedirectToAction("Index", "BookStore");
                }
                else {
                    ModelState.AddModelError("", "User Name or Password is wrong.");
                }
            }
            return View();
        }
        //public ActionResult LoggedIn()
        //{
        //    if(Session["MaKH"] != null)
        //    {
        //        return View();
        //    }
        //    else
        //    {
        //        return RedirectToAction("Login");
        //    }
        //}

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "BookStore");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(KHACHHANG user)
        {
            if(ModelState.IsValid)
            {
                using (QLBANSACHEntities db = new QLBANSACHEntities())
                {
                    db.KHACHHANGs.Add(user);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = "Succesfully Registered!!";
            }
            return View();
        }


        // Login Admin
        public ActionResult LoginAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginAdmin(Admin user)
        {
            using (QLBANSACHEntities db = new QLBANSACHEntities())
            {
                var admins = db.Admins.Where(x => x.UserName == user.UserName && x.Password == user.Password).SingleOrDefault();
                if (admins != null)
                {
                    Session["UserName"] = admins.UserName.ToString();
                    return RedirectToAction("Index", "DonDatHang");
                }
                else
                {
                    ModelState.AddModelError("", "User Name or Password is wrong.");
                }
            }
            return View();
        }

        public ActionResult AdminLogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("LoginAdmin");
        }
    }
}