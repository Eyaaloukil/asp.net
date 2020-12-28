using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projet.Models;
using projet.ViewModels;
using projet.Models.Repositories;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace projet.Controllers
{
    public class LivreController : Controller
    {
        private readonly ILivreRepositorye _LivreRepository;
                private readonly ICategoryRepository _CategoryRepository;

        private readonly IWebHostEnvironment hostingEnvironment;

        public LivreController(ILivreRepositorye LivreRepository,ICategoryRepository CategoryRepository, IWebHostEnvironment hostingEnvironment)
        {
            _LivreRepository = LivreRepository;
            _CategoryRepository=CategoryRepository;
            this.hostingEnvironment = hostingEnvironment;

        }
        // GET: LivreController
        public ActionResult Index()
        {
            var model = _LivreRepository.GetAllLivre();
            

            return View(model);
        }

        // GET: LivreController/Details/5
        public ActionResult Details(int id)
        {
            var liv = _LivreRepository.GetLivre(id);
            Category category=_CategoryRepository.GetCategory(liv.CategoryId);
            return View(liv);
        }

        // GET: LivreController/Create
        public ActionResult Create()
        {            ViewBag.CategoryId = new SelectList(_CategoryRepository.GetAllCategory(), "Id", "Name");

            return View();
        }

        // POST: LivreController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateViewModel model) {

            if (ModelState.IsValid)
            {
                string uniqueFileName = null;

                // If the Photo property on the incoming model object is not null, then the user
                // has selected an image to upload.
                if (model.Photo != null)
                {
                    // The image must be uploaded to the images folder in wwwroot
                    // To get the path of the wwwroot folder we are using the inject
                    // HostingEnvironment service provided by ASP.NET Core

                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");

                    // To make sure the file name is unique we are appending a new
                    // GUID value and an underscore to the file name

                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    // Use CopyTo() method provided by IFormFile interface to
                    // copy the file to wwwroot/images folder

                    model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }
            ViewBag.CategoryId = new SelectList(_CategoryRepository.GetAllCategory(), "Id", "Name");
                Livre newLivre = new Livre
                {
                    Name = model.Name,
                    price = model.price,
                    CategoryId=model.CategoryId,
                    PhotoPath = uniqueFileName
                };

                _LivreRepository.Add(newLivre);
                return RedirectToAction("details", new { id = newLivre.Id
                });
            }

            return View();

        }


        public ActionResult Edit(int id)
        {


            Livre Livre = _LivreRepository.GetLivre(id);
            LivreEditViewModel LivreEditViewModel = new LivreEditViewModel
            {
                Id = Livre.Id,
                Name = Livre.Name,
                price = Livre.price,
                
                ExistingPhotoPath = Livre.PhotoPath
            };
            return View(LivreEditViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LivreEditViewModel model)
        {
            // Check if the provided data is valid, if not rerender the edit view
            // so the user can correct and resubmit the edit form
            if (ModelState.IsValid)
            {
                // Retrieve the employee being edited from the database
                Livre Livre = _LivreRepository.GetLivre(model.Id);
                // Update the employee object with the data in the model object
                Livre.Name = model.Name;
                Livre.price = model.price;

                // If the user wants to change the photo, a new photo will be
                // uploaded and the Photo property on the model object receives
                // the uploaded photo. If the Photo property is null, user did
                // not upload a new photo and keeps his existing photo
                if (model.Photo != null)
                {
                    // If a new photo is uploaded, the existing photo must be
                    // deleted. So check if there is an existing photo and delete
                    if (model.ExistingPhotoPath != null)
                    {
                        string filePath = Path.Combine(hostingEnvironment.WebRootPath,
                            "images", model.ExistingPhotoPath);
                        System.IO.File.Delete(filePath);
                    }

                    Livre.PhotoPath = ProcessUploadedFile(model);
                }


                Livre updatedLivre = _LivreRepository.Update(Livre);
                if (updatedLivre != null)
                    return RedirectToAction("index");
                else
                    return NotFound();
            }

            return View(model);
        }
        [NonAction]
        private string ProcessUploadedFile(LivreEditViewModel model)
        {
            string uniqueFileName = null;

            if (model.Photo != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Photo.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }
        

        // GET: LivreController/Delete/5
        public ActionResult Delete(int id)
        {
            Livre liv = _LivreRepository.GetLivre(id);
            if (liv == null)
                return NotFound();
            else
                return View(liv);
        }

        // POST: LivreController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Livre e)
        {
            try
            {
                Livre e1 = _LivreRepository.Delete(e.Id);
                if (e1 != null)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
