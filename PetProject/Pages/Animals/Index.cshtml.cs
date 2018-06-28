using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PetProject.Models;

namespace PetProject.Pages.Animals
{
    public class IndexModel : PageModel
    {
        private readonly PetProject.Models.PetProjectContext _context;

        public IndexModel(PetProject.Models.PetProjectContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public IList<Pets> Pets { get;set; }

        public async Task OnGetAsync(string sortOrder, string searchString)
        {

            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            CurrentFilter = searchString;

 

            IQueryable<Pets> petsIQ = from p in _context.Pets
                                            select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                petsIQ = petsIQ.Where(s => s.PetName.Contains(searchString)
                       || s.PetBreed1.Contains(searchString)
                        || s.PetBreed2.Contains(searchString)
                        || s.PetDetails.Contains(searchString));
            }


            switch (sortOrder)
            {
                case "name_desc":
                    petsIQ = petsIQ.OrderByDescending(s => s.PetName);
                    break;
 
                default:
                   petsIQ = petsIQ.OrderBy(s => s.PetName);
                   break;
            }


            //Pets = await _context.Pets
            //    .Include(p => p.Shelter).ToListAsync();

            Pets = await petsIQ.Include(p => p.Shelter).ToListAsync();
        }
    }
}
