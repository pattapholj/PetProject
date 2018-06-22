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
    public class DeleteModel : PageModel
    {
        private readonly PetProject.Models.pubsContext _context;

        public DeleteModel(PetProject.Models.pubsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Pets Pets { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pets = await _context.Pets.FirstOrDefaultAsync(m => m.Id == id);

            if (Pets == null)
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

            Pets = await _context.Pets.FindAsync(id);

            if (Pets != null)
            {
                _context.Pets.Remove(Pets);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
