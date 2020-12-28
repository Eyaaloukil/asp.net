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
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public int price { get; set; }
        public IFormFile Photo { get; set; }
    }
}
