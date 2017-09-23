using ASP_MVC_Testing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_MVC_Testing.Data
{
    public class WypoInitializer : System.Data.Entity.DropCreateDatabaseAlways<WypoContext>
    {
        protected override void Seed(WypoContext context)
        {
            var stanowisko = new List<Stanowisko>
            {
                new Stanowisko {Nazwa="Kucharz",Pensja=400 ,StanowiskoId=1 },
                new Stanowisko {Nazwa="Sprzątacz",Pensja=240 ,StanowiskoId=2},
                new Stanowisko {Nazwa="Tester",Pensja=206 ,StanowiskoId=3 },
                new Stanowisko {Nazwa="Szef",Pensja=208 ,StanowiskoId=4}

            };
            stanowisko.ForEach(f => context.Stanowisko.Add(f));
            context.SaveChanges();
            var pracownik = new List<Pracownik>
            {
                new Pracownik {Imie="Jan",Nazwisko = "Kowalski", Pesel="12345678912", StanowiskoId=1},
                new Pracownik {Imie="Robert",Nazwisko = "Nowak", Pesel="12345778934", StanowiskoId=2},
                new Pracownik {Imie="Tomasz",Nazwisko = "Nóz", Pesel="78945612312", StanowiskoId=3 },
                new Pracownik {Imie="Anna",Nazwisko = "Jaku", Pesel="95365478951", StanowiskoId=1 },
            };
            pracownik.ForEach(k => context.Pracownik.Add(k));
            context.SaveChanges();

        }
    }
}