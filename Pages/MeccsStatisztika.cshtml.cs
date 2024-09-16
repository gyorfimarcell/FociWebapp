using FociWebapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FociWebapp.Pages
{
    public class MeccsStatisztikaModel : PageModel
    {
        private readonly FociWebapp.Models.FociDBContext _context;

        public MeccsStatisztikaModel(FociWebapp.Models.FociDBContext context)
        {
            _context = context;
        }

        public List<Csapat> Csapatok { get; set; } = [];

        public async Task OnGetAsync()
        {
            IList<Meccs> meccsek = await _context.Meccsek.ToListAsync();

            List<string> csapatNevek = meccsek.Select(x => x.HazaiNev).Concat(meccsek.Select(x => x.VendegNev)).Distinct().ToList();
            foreach (string nev in csapatNevek)
            {
                Csapat csapat = new();
                csapat.Nev = nev;

                List<Meccs> jatszottMeccsek = meccsek.Where(x => x.HazaiNev == nev || x.VendegNev == nev).ToList();

                csapat.Merkozesek = jatszottMeccsek.Count;
                csapat.Gyozelem = jatszottMeccsek.Count(x => x.HazaiNev == nev ? x.HazaiVeg > x.VendegVeg : x.VendegVeg > x.HazaiVeg);
                csapat.Dontetlen = jatszottMeccsek.Count(x => x.HazaiVeg == x.VendegVeg);
                csapat.Vereseg = csapat.Merkozesek - csapat.Gyozelem - csapat.Dontetlen;

                csapat.Pontszam = (csapat.Gyozelem * 3) + csapat.Dontetlen;

                csapat.LottGol = jatszottMeccsek.Sum(x => x.HazaiNev == nev ? x.HazaiVeg : x.VendegVeg);
                csapat.KapottGol = jatszottMeccsek.Sum(x => x.HazaiNev == nev ? x.VendegVeg : x.HazaiVeg);

                Csapatok.Add(csapat);
            }

            Csapatok = Csapatok.OrderByDescending(x => x.Pontszam).ToList();
        }
    }

    public class Csapat
    {
        public string Nev { get; set; }
        public int Merkozesek { get; set; }
        public int Gyozelem { get; set; }
        public int Dontetlen { get; set; }
        public int Vereseg { get; set; }
        public int Pontszam { get; set; }
        public int LottGol { get; set; }
        public int KapottGol { get; set; }
    }
}
