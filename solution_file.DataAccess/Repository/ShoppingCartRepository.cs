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
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        private WebAppDbContext _db;
        public ShoppingCartRepository(WebAppDbContext db):base(db)
        {
                _db = db;
        }
    

        public void Update(ShoppingCart obj)
        {
            _db.ShoppingCarts.Update(obj);
        }
    }
}
