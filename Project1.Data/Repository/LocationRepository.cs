
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using NLog;

using Project1.Data.Entity;
using Project1.Library.Interface;




namespace Project1.Data.Repository
{
    public class LocationRepository : ILocationRepository
    {

        private readonly ProjectDBContext _locationContext;

        private static readonly ILogger s_logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Initializes a OrderRepository instance given a suitable data source.
        /// </summary>
        /// <param name="context">The data source</param>
        public LocationRepository(ProjectDBContext context) 
        {
            _locationContext = context;
        }
        


        public Library.Model.Location GetById(int locationId)
        {
            try {
                Location location = _locationContext.Locations
                    .Include(l => l.InventoryLines)
                    .ThenInclude(il => il.Product)
                    .AsNoTracking()
                    .First(l => l.LocationId == locationId);

                return new Library.Model.Location
                {
                    LocationId = location.LocationId,
                    StoreNumber = location.StoreNumber,
                    Address = location.Address,
                    City = location.City,
                    State = location.State,
                    Country = location.Country,
                    PostalCode = location.PostalCode,
                    Phone = location.Phone,

                    Inventory = location.InventoryLines.Select(il => new Library.Model.InventoryLine
                    {
                        InventoryLineId = il.InventoryLineId,
                        ProductId = il.Product.ProductId,
                        Product = new Library.Model.Product
                        {
                            ProductId = il.Product.ProductId,
                            Name = il.Product.Name,
                            BestBy = il.Product.BestBy,
                            UnitPrice = il.Product.UnitPrice
                        },
                        Quantity = il.Quantity,
                        LineTotal = il.LineTotal
                    }).ToList()
                };
            }
            catch (InvalidOperationException e)
            {
                s_logger.Debug(e.Message, e);
            }
            
            return null;
        }

        public IEnumerable<Library.Model.Location> List()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Library.Model.Location> List(Expression<Func<Library.Model.Location, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Add(Library.Model.Location model)
        {
            throw new NotImplementedException();
        }

        public void Delete(Library.Model.Location model)
        {
            throw new NotImplementedException();
        }

        public void Edit(Library.Model.Location model)
        {
            IQueryable<Location> locations = _locationContext.Locations
                .Include(l => l.InventoryLines)
                .ThenInclude(il => il.Product);
            Location entity = locations.First(l => l.LocationId == model.LocationId);

            if (entity == null)
            {
                s_logger.Warn($"Location to be edited does not exist: ignoring.");
                return;
            }
            foreach (Library.Model.InventoryLine line in model.Inventory)
            {
                InventoryLine entity2 = entity.InventoryLines.First(il => il.InventoryLineId == line.InventoryLineId);
                if (entity2 == null)
                {
                    s_logger.Warn($"InventoryLine to be edited on location ${entity.LocationId} does not exist: ignoring.");
                    return;
                }
            }

            s_logger.Info($"Editing Location");

            var products = _locationContext.Products
                .AsNoTracking();

            foreach (Library.Model.InventoryLine line in model.Inventory)
            {
                InventoryLine entity2 = entity.InventoryLines.First(il => il.InventoryLineId == line.InventoryLineId);
                entity2.Quantity = line.Quantity;
                entity2.LineTotal = entity2.Quantity * entity2.Product.UnitPrice;
                _locationContext.Update(entity2);
            }
            _locationContext.Update(entity);
        }

        /// <summary>
        /// Persist changes to the data source.
        /// </summary>
        public void Save()
        {
            s_logger.Info("Saving changes to the database");
            _locationContext.SaveChanges();
        }
    }
}