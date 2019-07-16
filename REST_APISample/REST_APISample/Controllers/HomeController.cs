using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using REST_APISample.Models;

namespace REST_APISample.Controllers
{
    public class HomeController : Controller
    {
        private UserService service;

        public HomeController()
        {
            service = new UserService(new FakeUserStorage());
        }

        public ActionResult Index()
        {
            var users = new List<User>(service.GetAllBooks());

            return View(users);
        }

        public ActionResult Read(int id)
        {
            var user = service.FindByTag((user1 => user1.Id == id));

            return View(user);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            try
            {
                service.AddUser(user);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            return View(service.FindByTag((user1 => user1.Id == id)));
        }
        
        [AcceptVerbs("POST", "PUT")]
        [DisplayName("Update")]
        public void UpdateUser(int id)
        {
            var user = service.FindByTag((user1 => user1.Id == id));
            service.UpdateBook(user);
            RedirectToAction("Index");
        }

        [HttpDelete]
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var user = service.FindByTag((user1 => user1.Id == id));
            service.RemoveBook(user);
            return View("Index");
        }
    }
}