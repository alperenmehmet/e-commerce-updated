﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, ApplicationDbContext>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetails(int id)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var result = from p in context.Products.Where(p => p.ProductId == id)
                             join c in context.Categories on p.ProductId equals c.CategoryId
                             select new ProductDetailDto
                             {
                                 ProductName = p.ProductName,
                                 CategoryName = c.CategoryName,
                                 UnitsInStock = p.UnitsInStock
                             };
                return result.ToList();
            }
        }
    }
}
