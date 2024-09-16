using FociWebapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FociWebapp.Pages
{
    public class AdatFeltoltesModel : PageModel
    {
        private readonly FociWebapp.Models.FociDBContext _context;

        public AdatFeltoltesModel(FociWebapp.Models.FociDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            IFormFile fajl = Request.Form.Files[0];

            using (var reader = new StreamReader(fajl.OpenReadStream()))
            {
                string[] sorok = reader.ReadToEnd().Split('\n').Select(x => x.Trim()).Where(x => x != "").ToArray();
                List<Meccs> meccsek = sorok.Skip(1).Select(x => new Meccs(x)).ToList();
                meccsek.ForEach(x => _context.Meccsek.Add(x));
            }

            await _context.SaveChangesAsync();

            return RedirectToPage("MeccsekListaja");
        }
    }
}
