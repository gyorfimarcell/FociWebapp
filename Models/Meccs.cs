﻿namespace FociWebapp.Models
{
    public class Meccs
    {
        public Meccs() { }

        public Meccs(string csvSor)
        {
            string[] mezok = csvSor.Split(' ');
            Fordulo = Convert.ToInt32(mezok[0]);
            HazaiFelido = Convert.ToInt32(mezok[1]);
            VendegFelido = Convert.ToInt32(mezok[2]);
            HazaiVeg = Convert.ToInt32(mezok[3]);
            VendegVeg = Convert.ToInt32(mezok[4]);
            HazaiNev = mezok[5];
            VendegNev = mezok[6];
        }

        public int Id { get; set; }
        public int Fordulo { get; set; }    
        public int HazaiFelido { get; set; }
        public int VendegFelido { get; set; }
        public int HazaiVeg { get; set; }
        public int VendegVeg { get; set; }
        public string HazaiNev { get; set; }
        public string VendegNev { get; set; }


    }
}
