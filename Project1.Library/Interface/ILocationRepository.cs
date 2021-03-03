
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

using Project1.Library.Model;



namespace Project1.Library.Interface
{
    public interface ILocationRepository
    {
        Location GetById(int id);
        IEnumerable<Location> List();
        IEnumerable<Location> List(Expression<Func<Location, bool>> predicate);
        void Add(Location model);
        void Delete(Location model);
        void Edit(Location model);
    }
}