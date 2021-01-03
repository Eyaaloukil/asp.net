using System;
using System.Collections.Generic;
using System.Dynamic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using projet.Models.Repositories;

namespace projet.Controllers
{
    public class AppController:Controller
    { private readonly ILivreRepositorye _LivreRepository;
    private readonly ICategoryRepository _CategoryRepository;
            private readonly IWebHostEnvironment hostingEnvironment;


        public AppController(ILivreRepositorye _LivreRepository,ICategoryRepository _CategoryRepository, IWebHostEnvironment hostingEnvironment){

            this.hostingEnvironment = hostingEnvironment;
            this._LivreRepository=_LivreRepository;
            this._CategoryRepository=_CategoryRepository;
        }
        [Authorize(Roles="User")]

         public ActionResult Index()
        { 
          string id=  HttpContext.Request.Query["id"];
           if( id==null){
ViewBag.Livre=_LivreRepository.GetAllLivre();

           }
           else{
               ViewBag.Livre=_LivreRepository.GetLivreByCategory((int)Int64.Parse(id));
           }

          ViewBag.Category=_CategoryRepository.GetAllCategory();
            return View();
        }

    }
}