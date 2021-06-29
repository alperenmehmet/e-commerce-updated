using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Dtos;
using Entities.ScaffoldingConcrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfOrderDetail : EfEntityRepositoryBase<OrderDetail, ECommerceDbContext>, IOrderDetailDal
    {
        public List<OrderDetailDto> GetOrderDetails(int id)
        {
            using (ECommerceDbContext context = new ECommerceDbContext())
            {
                var result = from p in context.Products.Where(p => p.ProductId == id)
                             join c in context.Categories on p.ProductId equals c.CategoryId
                             join od in context.OrderDetails on p.ProductId equals od.OrderDetailId
                             join o in context.Orders on p.ProductId equals o.OrderId
                             select new OrderDetailDto
                             {
                                 ProductName = p.ProductName,
                                 CategoryName = c.CategoryName,
                                 UnitPrice = p.UnitPrice,
                                 Quantity = od.Quantity,
                                 OrderDate = o.OrderDate
                             };
                return result.ToList();
            }
        }
    }
}
