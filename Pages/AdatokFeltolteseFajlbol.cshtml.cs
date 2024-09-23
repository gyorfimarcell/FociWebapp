using FociWebapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FociWebapp.Pages
{
    public class AdatokFeltolteseFajlbolModel : PageModel
    {
        private readonly IWebHostEnvironment _env;
        private readonly FociDBContext _context;

        public AdatokFeltolteseFajlbolModel(IWebHostEnvironment env, FociDBContext context)
        {
            _env = env;
            _context = context;
        }

        [BindProperty]
        public IFormFile Feltoltes { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Feltoltes == null)
            {
                return Page();
            }

            var UploadDirPath = Path.Combine(_env.ContentRootPath, "Uploads");
            var UploadFilePath = Path.Combine(UploadDirPath, Feltoltes.FileName);
            using (var stream = new FileStream(UploadFilePath, FileMode.Create))
            {
                await Feltoltes.CopyToAsync(stream);
            }

            StreamReader sr = new StreamReader(UploadFilePath);
            sr.ReadLine();

            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();
                Meccs ujMeccs = new Meccs(line);

                if (!_context.Meccsek.Any(x => x.HazaiNev == ujMeccs.HazaiNev && x.VendegNev == ujMeccs.VendegNev))
                {
                    _context.Meccsek.Add(ujMeccs);
                }
            }

            sr.Close();
            await _context.SaveChangesAsync();
            System.IO.File.Delete(UploadFilePath);

            return Page();
        }
    }
}
