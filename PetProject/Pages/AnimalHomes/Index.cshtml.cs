using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PetProject.Models;

namespace PetProject.Pages.AnimalHomes
{
    public class IndexModel : PageModel
    {
        private readonly PetProject.Models.pubsContext _context;

        public IndexModel(PetProject.Models.pubsContext context)
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
