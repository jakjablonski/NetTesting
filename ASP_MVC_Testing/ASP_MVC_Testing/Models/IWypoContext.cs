using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace ASP_MVC_Testing.Models
{
    public interface IWypoContext
    {

        IQueryable<Pracownik> Pracownicy { get; }
        IQueryable<Stanowisko> Stanowiska { get; }
        int SaveChanges();
        T Add<T>(T entity) where T : class;
        Stanowisko FindStanowiskoById(int ID);
        Pracownik FindPracownikById(int ID);
        T Delete<T>(T entity) where T : class;
        DbEntityEntry<T> Entry<T>(T entity) where T : class;
    }
}