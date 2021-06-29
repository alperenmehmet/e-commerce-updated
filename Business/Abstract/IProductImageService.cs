using Core.Utilities.Results;
using Entities.ScaffoldingConcrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductImageService
    {
        IResult Add(IFormFile file, ProductImage productImage);
        IResult Delete(ProductImage productImage);
        IResult Update(IFormFile file, ProductImage productImage);
        IDataResult<ProductImage> Get(int id);
        IDataResult<List<ProductImage>> GetAll();
        IDataResult<List<ProductImage>> GetImagesByProductId(int id);
    }
}
