using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PetProject.Models;

namespace PetProject.Pages.AnimalShelters
{
    public class IndexModel : PageModel
    {
        private readonly PetProject.Models.PetProjectContext _context;

        public IndexModel(PetProject.Models.PetProjectContext context)
        {
            _context = context;
        }

        public IList<Shelters> Shelters { get;set; }

        public async Task OnGetAsync()
        {
            Shelters = await _context.Shelters.ToListAsync();
        }
    }
}
