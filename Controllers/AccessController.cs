using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sistema_login.Models;

namespace Sistema_login.Controllers
{
    public class AccessController : Controller
    {
        // GET: Access
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Enter(string user, string password)
        {
            try
            {

                using (ProductosAppEntities db = new ProductosAppEntities())
                {
                    var list = from d in db.Users
                               where d.username == user && d.password == password && d.idState == 1
                               select d;

                    if(list.Count() > 0)
                    {
                        Session["user"] = list.First();
                    }
                }

                return Content("1");
            }catch(Exception ex)
            {
                return Content("Ocurrio un error" + ex.Message);
            }
        }
    }
}