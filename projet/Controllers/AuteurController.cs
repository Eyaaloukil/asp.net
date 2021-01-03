using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using projet.Models;
using projet.Models.Repositories;
using projet.ViewModels;

namespace projet.Controllers
{
    public class AuteurController:Controller
    {
        readonly IAuteurRepository auteurRepository;
        public AuteurController(IAuteurRepository auteurRepository)
        {
            this.auteurRepository = auteurRepository;
        }
        // GET: SchoolController
               [Authorize(Roles="Admin")]
 public ActionResult Index()
        {
            return View(auteurRepository.GetAllAuteurs());
        }

        // GET: SchoolController/Details/5
                [Authorize(Roles="Admin")]
public ActionResult Details(int id)
        {
            var auteur = auteurRepository.GetAuteur(id);
            return View(auteur);
        }

        // GET: SchoolController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SchoolController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
               [Authorize(Roles="Admin")]
 public ActionResult Create(Auteur s)
        {
            try
            {
                auteurRepository.Add(s);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SchoolController/Edit/5
               [Authorize(Roles="Admin")]
 public ActionResult Edit(int id)
        {


            Auteur auteur = auteurRepository.GetAuteur(id);
            AuteurEditViewModel AuteurEditViewModel = new AuteurEditViewModel
            {
                Id = auteur.Id,
                Nom = auteur.Nom,
            Prenom = auteur.Prenom

            };
            return View(AuteurEditViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
                [Authorize(Roles="Admin")]
public ActionResult Edit(AuteurEditViewModel model)
        {
            // Check if the provided data is valid, if not rerender the edit view
            // so the user can correct and resubmit the edit form
            if (ModelState.IsValid)
            {
                // Retrieve the employee being edited from the database
                Auteur auteur = auteurRepository.GetAuteur(model.Id);
                // Update the employee object with the data in the model object
                auteur.Nom = model.Nom;
                                auteur.Prenom = model.Prenom;


                // If the user wants to change the photo, a new photo will be
                // uploaded and the Photo property on the model object receives
                // the uploaded photo. If the Photo property is null, user did
                // not upload a new photo and keeps his existing photo
               

                Auteur updatedAuteur = auteurRepository.Update(auteur);
                if (updatedAuteur != null)
                    return RedirectToAction("index");
                else
                    return NotFound();
            }

            return View(model);
        }

        // GET: SchoolController/Delete/5
               [Authorize(Roles="Admin")]
 public ActionResult Delete(int id)
        {
            var auteur = auteurRepository.GetAuteur(id);
            return View(auteur);
        }

        // POST: SchoolController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
               [Authorize(Roles="Admin")]
 public ActionResult Delete(Category c)
        {
            try
            {
                auteurRepository.Delete(c.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}