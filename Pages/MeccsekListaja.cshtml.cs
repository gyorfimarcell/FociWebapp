using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FociWebapp.Models;

namespace FociWebapp.Pages
{
    public class MeccsekListajaModel : PageModel
    {
        private readonly FociWebapp.Models.FociDBContext _context;

        public MeccsekListajaModel(FociWebapp.Models.FociDBContext context)
        {
            _context = context;
        }

        public IList<Meccs> Meccs { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Meccs = await _context.Meccsek.ToListAsync();
        }
    }
}
