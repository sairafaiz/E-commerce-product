using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Book_DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
        IProductRepository Product { get; }

        ICompanyRepository Company { get; }
        IShoppingCartRepository shoppingCart { get; }

        IApplicationUserRepository applicationUser { get; }
        IOrderHeaderRepository orderHeader { get; }
        IOrderDetailsRepository orderDetail { get; }
        IProductImageRepository productImage { get; }

        void save();
    }
}
