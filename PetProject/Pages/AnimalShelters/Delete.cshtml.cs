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
    public class DeleteModel : PageModel
    {
        private readonly PetProject.Models.PetProjectContext _context;

        public DeleteModel(PetProject.Models.PetProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Shelters Shelters { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Shelters = await _context.Shelters.FirstOrDefaultAsync(m => m.Id == id);

            if (Shelters == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Shelters = await _context.Shelters.FindAsync(id);

            if (Shelters != null)
            {
                _context.Shelters.Remove(Shelters);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
