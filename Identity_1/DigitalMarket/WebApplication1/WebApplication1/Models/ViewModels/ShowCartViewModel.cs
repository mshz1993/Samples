using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.ViewModels
{
    public class ShowCartViewModel
    {
        public string ImageName { get; set; }
        public string Title { get; set; }
        public int Count { get; set; }
        public int ProdectId { get; set; }
        public string Price { get; set; }
    }
}
