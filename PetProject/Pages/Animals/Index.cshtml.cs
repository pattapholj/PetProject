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

        public IList<Pets> Pets { get;set; }

        public async Task OnGetAsync()
        {
            Pets = await _context.Pets
                .Include(p => p.Shelter).ToListAsync();
        }
    }
}
