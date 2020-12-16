using Microsoft.AspNetCore.Mvc;
using projet.Models;
using projet.Models.Repositories;
using projet.ViewModels;

namespace projet.Controllers
{
    public class CategoryController:Controller
    {
        readonly ICategoryRepository categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        // GET: SchoolController
        public ActionResult Index()
        {
            return View(categoryRepository.GetAllCategory());
        }

        // GET: SchoolController/Details/5
        public ActionResult Details(int id)
        {
            var category = categoryRepository.GetCategory(id);
            return View(category);
        }

        // GET: SchoolController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SchoolController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category s)
        {
            try
            {
                categoryRepository.Add(s);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SchoolController/Edit/5
        public ActionResult Edit(int id)
        {


            Category Category = categoryRepository.GetCategory(id);
            CategoryEditViewModel CategoryEditViewModel = new CategoryEditViewModel
            {
                Id = Category.Id,
                Name = Category.Name,
               
            };
            return View(CategoryEditViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoryEditViewModel model)
        {
            // Check if the provided data is valid, if not rerender the edit view
            // so the user can correct and resubmit the edit form
            if (ModelState.IsValid)
            {
                // Retrieve the employee being edited from the database
                Category Category = categoryRepository.GetCategory(model.Id);
                // Update the employee object with the data in the model object
                Category.Name = model.Name;

                // If the user wants to change the photo, a new photo will be
                // uploaded and the Photo property on the model object receives
                // the uploaded photo. If the Photo property is null, user did
                // not upload a new photo and keeps his existing photo
               

                Category updatedCategory = categoryRepository.Update(Category);
                if (updatedCategory != null)
                    return RedirectToAction("index");
                else
                    return NotFound();
            }

            return View(model);
        }

        // GET: SchoolController/Delete/5
        public ActionResult Delete(int id)
        {
            var category = categoryRepository.GetCategory(id);
            return View(category);
        }

        // POST: SchoolController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Category c)
        {
            try
            {
                categoryRepository.Delete(c.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}