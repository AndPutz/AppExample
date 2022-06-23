using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.Business;
using WebApp.Model;
using WebAppExample.Models;

namespace WebAppExample.Controllers
{
    public class ObjectController : Controller
    {
        // GET: ObjectController
        public ActionResult Index()
        {            
            return View(IndexProcess());
        }

        private ObjectViewModel IndexProcess()
        {
            ObjectViewModel objectView = new ObjectViewModel();

            ObjectList objects = ObjectBusiness.Instance.GetAllObjects();

            objectView.ListObjectsView.AddRange(
                    from x in objects
                    select new ObjectItemViewModel
                    {
                        ID = x.ID,
                        Name = x.Name,
                        Description = x.Description,
                        TypeId = x.Type.ID,
                        TypeDescription = x.Type.Description
                    }
                );
            return objectView;
        }

        // GET: ObjectController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ObjectController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ObjectController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ObjectController/Edit/5
        public ActionResult Edit(long id)
        {
            ObjectModel item = ObjectBusiness.Instance.GetObject(id);
            TypeList types = TypeBusiness.Instance.GetAll();

            ObjectViewModel viewModel = new ObjectViewModel();
            viewModel.ObjectView = new ObjectItemViewModel() { ID = item.ID, Name = item.Name, Description = item.Description, TypeId = item.Type.ID, TypeDescription = item.Type.Description };

            foreach (var itemType in types)
            {
                viewModel.ListTypeView.Add(new TypeViewModel() { ID = itemType.ID, Description = itemType.Description });
            }

            ViewData["Title"] = "Edit Object " + viewModel.ObjectView.Name;

            return View("~/Views/Shared/_ObjectForm.cshtml", viewModel);
        }

        // POST: ObjectController/SaveEdit
        [HttpPost]        
        public ActionResult SaveEdit(ObjectItemViewModel viewModel)
        {
            try
            {
                ObjectBusiness.Instance.Update(new ObjectModel() { ID = viewModel.ID, Name = viewModel.Name, Description = viewModel.Description, Type = new TypeModel() { ID = viewModel.TypeId, Description = "" } });

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: ObjectController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ObjectController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        
    }
}
