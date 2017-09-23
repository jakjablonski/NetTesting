using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASP_MVC_Testing.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ASP_MVC_Testing.Data
{
    public class WypoContext : DbContext, IWypoContext
    {
       

        public virtual DbSet<Stanowisko> Stanowisko { get; set; }
        public virtual DbSet<Pracownik> Pracownik { get; set; }

        IQueryable<Pracownik> IWypoContext.Pracownicy
        {
            get { return Pracownik; }
        }

        IQueryable<Stanowisko> IWypoContext.Stanowiska
        {
            get { return Stanowisko; }
        }

        int IWypoContext.SaveChanges()
        {
            return SaveChanges();
        }

        T IWypoContext.Add<T>(T entity)
        {
            return Set<T>().Add(entity);
        }

        Stanowisko IWypoContext.FindStanowiskoById(int ID)
        {
            Stanowisko stanowisko = (from s in Set<Stanowisko>()
                                   where s.StanowiskoId == ID
                                   select s).FirstOrDefault();
            return stanowisko;
        }

        Pracownik IWypoContext.FindPracownikById(int ID)
        {
            Pracownik pracownik = (from p in Set<Pracownik>()
                             where p.PracownikId == ID
                             select p).FirstOrDefault();
            return pracownik;
            //return Set<Pracownik>().Find(ID);
        }

        T IWypoContext.Delete<T>(T entity)
        {
            return Set<T>().Remove(entity);
        }
    }
}


