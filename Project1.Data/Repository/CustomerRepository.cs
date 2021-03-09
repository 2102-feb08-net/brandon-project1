
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using NLog;

using Project1.Library.Interface;
using Project1.Data.Entity;

namespace Project1.Data.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ProjectDBContext _customerContext;

        private static readonly ILogger s_logger = LogManager.GetCurrentClassLogger();

        public CustomerRepository(ProjectDBContext context) 
        {
            _customerContext = context;
        }



        public Library.Model.Customer GetById(int id)
        {
            try {
                var customer = _customerContext.Customers
                    .First(u => u.CustomerId == id);

                return new Library.Model.Customer
                {
                    CustomerId = customer.CustomerId,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Address = customer.Address,
                    City = customer.City,
                    State = customer.State,
                    Country = customer.Country,
                    PostalCode = customer.PostalCode,
                    Phone = customer.Phone,
                    Email = customer.Email
                };
            }
            catch (InvalidOperationException e)
            {
                s_logger.Debug(e.Message, e);
            }
            
            return null;
        }

        public IEnumerable<Library.Model.Customer> List()
        {
            return List(null);
        }

        public IEnumerable<Library.Model.Customer> List(Expression<Func<Library.Model.Customer, bool>> predicate)
        {
            IQueryable<Customer> items = _customerContext.Customers;
            
            // Figure out this predicate thing later

            // if (search != null)
            // {
            //     items = items.Where(c => (c.FirstName + " " + c.LastName).Contains(search));
            // }

            return items.Select(c => new Library.Model.Customer
            {
                CustomerId = c.CustomerId,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Address = c.Address,
                City = c.City,
                State = c.State,
                Country = c.Country,
                PostalCode = c.PostalCode,
                Phone = c.Phone,
                Email = c.Email
            });
        }

        /// <summary>
        /// Add a new customer.
        /// </summary>
        public void Add(Library.Model.Customer model)
        {
            if (model.CustomerId != 0)
            {
                s_logger.Warn($"Customer to be added has an ID ({model.CustomerId}) already: ignoring.");
            }

            s_logger.Info($"Adding Customer");

            // ID left at default 0
            Customer entity = new Customer
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Address = model.Address,
                City = model.City,
                State = model.State,
                Country = model.Country,
                PostalCode = model.PostalCode,
                Phone = model.Phone,
                Email = model.Email
            };
            _customerContext.Add(entity);
        }

        public void Delete(Library.Model.Customer model)
        {
            throw new NotImplementedException();
        }

        public void Edit(Library.Model.Customer model)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Persist changes to the data source.
        /// </summary>
        public void Save()
        {
            s_logger.Info("Saving changes to the database");
            _customerContext.SaveChanges();
        }
    }
}