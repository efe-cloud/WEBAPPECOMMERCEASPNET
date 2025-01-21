using solution_file.DataAccess.Data;
using solution_file.DataAccess.Repository.IRepository;
using solution_file.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace solution_file.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private WebAppDbContext _db;
    public ProductRepository(WebAppDbContext db) : base(db)
    {
        _db = db;
    }
        public void Update(Product obj)
        {
           var objFromDb = _db.Products.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Title = obj.Title;
                objFromDb.ProductCode = obj.ProductCode;
                objFromDb.Price = obj.Price;
                objFromDb.Price50 = obj.Price50;
                objFromDb.ListPrice = obj.ListPrice;
                objFromDb.Price100 = obj.Price100;
                objFromDb.Description = obj.Description;
               objFromDb.CategoryId = obj.CategoryId;
                objFromDb.Producer = obj.Producer;
                if (obj.ImageUrl != null) 
                {
                    objFromDb.ImageUrl = obj.ImageUrl;
                }
            }
        }


   
}
}
