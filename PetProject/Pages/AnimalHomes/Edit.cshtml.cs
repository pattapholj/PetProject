using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetProject.Models;

namespace PetProject.Pages.AnimalHomes
{
    public class EditModel : PageModel
    {
        private readonly PetProject.Models.pubsContext _context;

        public EditModel(PetProject.Models.pubsContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Shelters).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SheltersExists(Shelters.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SheltersExists(int id)
        {
            return _context.Shelters.Any(e => e.Id == id);
        }
    }
}