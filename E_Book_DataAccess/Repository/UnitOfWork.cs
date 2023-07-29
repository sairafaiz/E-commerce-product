using E_Book_DataAccess.Data;
using E_Book_DataAccess.Repository.IRepository;
using E_Book_Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Book_DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public ICategoryRepository Category { get; private set; }

        public IProductRepository Product { get; private set; }
        public ICompanyRepository Company { get; private set; }

        public IShoppingCartRepository shoppingCart { get; private set; }

        public IApplicationUserRepository applicationUser { get; private set; }

		public IOrderHeaderRepository orderHeader { get; }
		public IOrderDetailsRepository orderDetail { get; }

        public IProductImageRepository productImage { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            applicationUser = new ApplicationUserRepository(_db);
            Category = new CategoryRepository(_db);
            Product = new ProductRepository(_db);
            Company = new CompanyRepository(_db);
            shoppingCart = new ShoppingCartRepository(_db);
            orderHeader = new OrderHeaderRepository(_db);
            orderDetail = new OrderDetailRepository(_db);
            productImage = new ProductImageRepository(_db);
        }



        public void save()
        {
            _db.SaveChanges();
        }
    }
}
