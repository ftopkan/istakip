using Project.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repositories.UnitOfWork
{
    public class UnitOfWork
    {

        private AppDbContext context;
        private MembershipRepository _membership;
        private DemandRepository _demands;
        private TakenDemandRepository _takenDemands;
        private ResultDemandRepository _resultDemands;
        private ProductRepository _products;
        private PackageRepository _packages;
        private PackageProductRepository _packageProducts;
        private OrderRepository _orders;

        public UnitOfWork()
        {
            context = new AppDbContext();
        }

        public MembershipRepository Membership
        {
            get
            {
                if (_membership == null)
                    _membership = new MembershipRepository(context);

                return _membership;
            }
        }

        public DemandRepository Demands
        {
            get
            {
                if (_demands == null)
                    _demands = new DemandRepository(context);

                return _demands;
            }
        }

        public TakenDemandRepository TakenDemands
        {
            get
            {
                if (_takenDemands == null)
                    _takenDemands = new TakenDemandRepository(context);

                return _takenDemands;
            }
        }

        public ResultDemandRepository ResultDemands
        {
            get
            {
                if (_resultDemands == null)
                    _resultDemands = new ResultDemandRepository(context);

                return _resultDemands;
            }
        }

        public ProductRepository Products
        {
            get
            {
                if (_products == null)
                    _products = new ProductRepository(context);

                    return _products;
                
            }
        }

        public PackageRepository Packages
        {
            get
            {
                if (_packages == null)
                    _packages = new PackageRepository(context);

                return _packages;

            }
        }

        public PackageProductRepository PackageProducts
        {
            get
            {
                if (_packageProducts == null)
                    _packageProducts = new PackageProductRepository(context);

                return _packageProducts;

            }
        }

        public OrderRepository Orders
        {
            get
            {
                if (_orders == null)
                    _orders = new OrderRepository(context);

                return _orders;

            }
        }

        public int Save()
        {
            return context.SaveChanges();
        }
    }
}
