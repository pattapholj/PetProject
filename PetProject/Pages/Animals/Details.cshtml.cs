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
    public class DetailsModel : PageModel
    {
        private readonly PetProject.Models.PetProjectContext _context;

        public DetailsModel(PetProject.Models.PetProjectContext context)
        {
            _context = context;
        }

        public Pets Pets { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pets = await _context.Pets
                .Include(p => p.Shelter).FirstOrDefaultAsync(m => m.Id == id);

            if (Pets == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
