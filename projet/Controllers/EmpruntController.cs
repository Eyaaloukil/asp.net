using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using projet.Models;
using projet.Models.Repositories;
using projet.ViewModels;

namespace projet.Controllers
{
    public class EmpruntController:Controller
    {
        readonly IEmpruntRepository iEmpruntRepository;
         public EmpruntController(IEmpruntRepository iEmpruntRepository)
        {
            this.iEmpruntRepository = iEmpruntRepository;
        }

        public ActionResult Index()
        {
            var model = iEmpruntRepository.GetEmpruntsByUser(1);


            return View("/Views/App/list.cshtml",model);
        }
        public ActionResult IndexList()
        {
            var model = iEmpruntRepository.GetAllEmprunts();


            return View("/Views/Emprunt/index.cshtml",model);
        }

          [Authorize(Roles="User")]
        public ActionResult Create()
        {             string UserId=  HttpContext.Request.Query["user_id"];
string livreId=  HttpContext.Request.Query["livre_id"];
          Emprunt newEmprunt=new Emprunt{
              LivreId= (int)Int64.Parse(livreId),
              UserId=(int)Int64.Parse(UserId),
              DateRetour=DateTime.Now.AddDays(+7)

          };
          iEmpruntRepository.Add(newEmprunt);
          return RedirectToAction("Index", "Emprunt");
            
        }
        public ActionResult Delete(int id)
        {
            iEmpruntRepository.Delete(id);
                      return RedirectToAction("Index", "Emprunt");

        }
    }
}