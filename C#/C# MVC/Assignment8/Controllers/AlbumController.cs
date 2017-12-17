using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment8.Controllers
{
    public class AlbumController : Controller
    {
        public Manager m = new Manager();
        // GET: Album
        public ActionResult Index()
        {
            var a = m.AlbumGetAllWithDetail();
            return View(a);
        }

        // GET: Album/Details/5
        public ActionResult Details(int? id)
        {
            var o = m.AlbumGetByIdWithDetail(id.GetValueOrDefault());

            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(o);
            }
        }

        // GET: Album/Create
        [Authorize(Roles = "Coordinator")]
        public ActionResult Create(int? id)
        {
            

            var form = new AlbumAddForm();

            form.ArtistList = new SelectList(items: m.ArtistGetAll(),
                        dataValueField: "Id",
                        dataTextField: "Name");

            form.TrackList = new SelectList
                    (items: m.TrackGetAll(),
                    dataValueField: "Id",
                    dataTextField: "Name");

            form.GenreList = new SelectList
                (items: m.GenreGetAll(),
                dataValueField: "Name",
                dataTextField: "Name");

            return View(form);
            
        }

        // POST: Album/Create
        [Authorize(Roles = "Coordinator")]
        [HttpPost]
        public ActionResult Create(AlbumAdd collection)
        {
            collection.Coordinator = HttpContext.User.Identity.Name;
            ModelState.Clear();

            if (!ModelState.IsValid)
            {
                return View(collection);
            }

            var addedItem = m.AlbumAdd(collection);

            if (addedItem == null)
            {

                return View(collection);
            }
            else
            {
                return RedirectToAction("details", new { id = addedItem.Id });
            }
        }

        // GET: Album/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Album/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Album/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Album/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
