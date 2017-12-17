using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment8.Controllers
{
    public class TrackController : Controller
    {
        public Manager m = new Manager();
        // GET: Track
        public ActionResult Index()
        {
            var a = m.TrackGetAllWithDetail();
            return View(a);
        }

        // GET: Track/Details/5
        public ActionResult Details(int? id)
        {
            var o = m.TrackGetByIdWithDetail(id.GetValueOrDefault());

            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(o);
            }
        }

        // GET: Track/Create
        [Authorize(Roles = "Coordinator")]
        public ActionResult Create()
        {
            var form = new TrackAddForm();

            form.GenreList = new SelectList
                    (items: m.GenreGetAll(),
                    dataValueField: "Name",
                    dataTextField: "Name");

            return View(form);
        }

        // POST: Track/Create
        [HttpPost]
        [Authorize(Roles = "Coordinator")]
        public ActionResult Create(TrackAdd collection)
        {
            collection.Clerk = HttpContext.User.Identity.Name;
            ModelState.Clear();

            if (!ModelState.IsValid)
            {
                return View(collection);
            }

            var addedItem = m.TrackAdd(collection);

            if (addedItem == null)
            {
                return View(collection);
            }
            else
            {
                return RedirectToAction("details", new { id = addedItem.Id });
            }
        }

        // GET: Track/Edit/5
        [Authorize(Roles = "Coordinator")]
        public ActionResult Edit(int? id)
        {
            var o = m.TrackGetByIdWithDetail(id.GetValueOrDefault());

            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                var form = m.mapper.Map<TrackEditForm>(o);

                form.GenreList = new SelectList
                    (items: m.GenreGetAll(),
                    dataValueField: "Name",
                    dataTextField: "Name",
                    selectedValue: o.Genre);

                return View(form);
            }
        }

        // POST: Track/Edit/5
        [Authorize(Roles = "Coordinator")]
        [HttpPost]
        public ActionResult Edit(int? id, TrackEdit collection)
        {
            collection.Clerk = HttpContext.User.Identity.Name;
            ModelState.Clear();

            if (!TryValidateModel(collection))
            {
                return RedirectToAction("Edit", new { id = collection.Id });
            }

            if (id.GetValueOrDefault() != collection.Id)
            {
                return RedirectToAction("Index");
            }

            var editedItem = m.TrackEdit(collection);

            if (editedItem == null)
            {
                return RedirectToAction("Edit", new { id = collection.Id });
            }
            else
            {
                return RedirectToAction("Details", new { id = collection.Id });
            }
        }

        // GET: Track/Delete/5
        [Authorize(Roles = "Coordinator")]
        public ActionResult Delete(int? id)
        {
            var itemToDelete = m.TrackGetByIdWithDetail(id.GetValueOrDefault());

            if (itemToDelete == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(itemToDelete);
            }
        }

        // POST: Track/Delete/5
        [Authorize(Roles = "Clerk")]
        [HttpPost]
        public ActionResult Delete(int? id, FormCollection collection)
        {
            var result = m.TrackDelete(id.GetValueOrDefault());
            return RedirectToAction("Index");
        }
    }
}
