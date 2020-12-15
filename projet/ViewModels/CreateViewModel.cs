using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using projet.Models;

namespace projet.ViewModels
{
    public class CreateViewModel
    {
        public string Name { get; set; }
        public string Categorie { get; set; }
        public int price { get; set; }
        public IFormFile Photo { get; set; }
    }
}
