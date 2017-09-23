using ASP_MVC_Testing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Collections.ObjectModel;
using System.Data.Entity.Infrastructure;

namespace ASP_MVC_Testing.Tests
{
    class FakeWypoContext : IWypoContext
    {

        SetMap _map = new SetMap();

        public IQueryable<Pracownik> Pracownicy
        {
            get { return _map.Get<Pracownik>().AsQueryable(); }
            set { _map.Use<Pracownik>(value); }
        }

        public IQueryable<Stanowisko> Stanowiska
        {
            get { return _map.Get<Stanowisko>().AsQueryable(); }
            set { _map.Use<Stanowisko>(value); }
        }

        public T Add<T>(T entity) where T : class
        {
            _map.Get<T>().Add(entity);
            return entity;
        }

        public T Delete<T>(T entity) where T : class
        {
            _map.Get<T>().Remove(entity);
            return entity;
        }

        public Pracownik FindPracownikById(int ID)
        {

            Pracownik item = (from p in this.Pracownicy
                          where p.PracownikId == ID
                          select p).FirstOrDefault();

            return item;
        }

        public Stanowisko FindStanowiskoById(int ID)
        {

            Stanowisko item = (from s in this.Stanowiska
                              where s.StanowiskoId == ID
                              select s).FirstOrDefault();

            return item;
        }

        public bool ChangesSaved { get; set; }

        public int SaveChanges()
        {
            ChangesSaved = true;
            return 0;
        }

        public DbEntityEntry<T> Entry<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        class SetMap : KeyedCollection<Type, object>
        {
            public HashSet<T> Use<T>(IEnumerable<T> sourceData)
            {
                var set = new HashSet<T>(sourceData);
                if (Contains(typeof(T)))
                {
                    Remove(typeof(T));
                }
                Add(set);
                return set;
            }

            public HashSet<T> Get<T>()
            {
                return (HashSet<T>)this[typeof(T)];
            }

            protected override Type GetKeyForItem(object item)
            {
                return item.GetType().GetGenericArguments().Single();
            }
        }
    }
}
