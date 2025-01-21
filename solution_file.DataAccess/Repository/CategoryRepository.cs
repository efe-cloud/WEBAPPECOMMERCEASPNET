using solution_file.DataAccess.Data;
using solution_file.DataAccess.Repository.IRepository;
using solution_file.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace solution_file.DataAccess.Repository
{
    public class CategoryRepository :Repository<Category>, ICategoryRepository 
    {
        private WebAppDbContext _db;
        public CategoryRepository(WebAppDbContext db):base(db)
        {
                _db = db;
        }
    

        public void Update(Category obj)
        {
            _db.ShoppingCart.Update(obj);
        }
    }
}
