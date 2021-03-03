
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

using Project1.Library.Model;



namespace Project1.Library.Interface
{
    public interface IProductRepository
    {
        Product GetById(int id);
        IEnumerable<Product> List();
        IEnumerable<Product> List(Expression<Func<Product, bool>> predicate);
        void Add(Product model);
        void Delete(Product model);
        void Edit(Product model);
    }
}