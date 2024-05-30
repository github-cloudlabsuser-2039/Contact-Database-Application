using CRUD_application_2.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CRUD_application_2.Controllers
{
    public class UserController : Controller
    {
        // Using a dictionary for O(1) lookup times
        public static Dictionary<int, User> userlist = new Dictionary<int, User>();

        // GET: User
        public ActionResult Index()
        {
            return View(userlist.Values);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            if (userlist.TryGetValue(id, out var user))
            {
                return View(user);
            }
            return HttpNotFound();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                userlist[user.Id] = user;
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            if (userlist.TryGetValue(id, out var user))
            {
                return View(user);
            }
            return HttpNotFound();
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User user)
        {
            if (userlist.ContainsKey(id) && ModelState.IsValid)
            {
                userlist[id] = user;
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            if (userlist.TryGetValue(id, out var user))
            {
                return View(user);
            }
            return HttpNotFound();
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            if (userlist.ContainsKey(id))
            {
                userlist.Remove(id);
                return RedirectToAction("Index");
            }
            return HttpNotFound();
        }

        // GET: User/Search
        public ActionResult Search(string searchTerm)
        {
            var results = userlist.Values.Where(u => u.Name.Contains(searchTerm) || u.Email.Contains(searchTerm));
            return View(results);
        }

    }
}
