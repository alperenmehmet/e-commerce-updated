using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductImageService : IProductImageService
    {
        IProductImageDal _productImageDal;

        public ProductImageService(IProductImageDal productImageDal)
        {
            _productImageDal = productImageDal;
        }
        [ValidationAspect(typeof(ProductImageValidator))]
        public IResult Add(IFormFile file, ProductImage productImage)
        {
            IResult result = BusinessRules.Run(CheckImageLimitExceed(productImage.ProductId));
            if (result != null)
            {
                return result;
            }
            productImage.ImagePath = FileHelper.Add(file);
            productImage.Date = DateTime.Now;
            _productImageDal.Add(productImage);
            return new SuccessResult();
        }

        [ValidationAspect(typeof(ProductImageValidator))]
        public IResult Delete(ProductImage productImage)
        {
            FileHelper.Delete(productImage.ImagePath);
            _productImageDal.Delete(productImage);
            return new SuccessResult();
        }

        [ValidationAspect(typeof(ProductImageValidator))]
        public IResult Update(IFormFile file, ProductImage productImage)
        {
            IResult result = BusinessRules.Run(CheckImageLimitExceed(productImage.ProductImageId));
            if (result != null)
            {
                return result;
            }
            productImage.ImagePath = FileHelper.Update(_productImageDal.Get(p => p.ProductId == productImage.ProductImageId).ImagePath, file);
            productImage.Date = DateTime.Now;
            _productImageDal.Update(productImage);
            return new SuccessResult();
        }

        [ValidationAspect(typeof(ProductImageValidator))]
        public IDataResult<ProductImage> Get(int id)
        {
            return new SuccessDataResult<ProductImage>(_productImageDal.Get(p => p.ProductImageId == id));
        }

        public IDataResult<List<ProductImage>> GetAll()
        {
            return new SuccessDataResult<List<ProductImage>>(_productImageDal.GetAll());
        }

        [ValidationAspect(typeof(ProductImageValidator))]
        public IDataResult<List<ProductImage>> GetImagesByProductId(int id)
        {
            return new SuccessDataResult<List<ProductImage>>(CheckIfProductImageNull(id));
        }

        private IResult CheckImageLimitExceed(int id)
        {
            var productImageCount = _productImageDal.GetAll(i => i.ProductId == id).Count;
            if (productImageCount>=5)
            {
                return new ErrorResult(Messages.ProductImageLimitExceed);
            }
            return new SuccessResult();
        }

        private List<ProductImage> CheckIfProductImageNull(int id)
        {
            string path = @"\Images\logo.jpg";
            var result = _productImageDal.GetAll(i => i.ProductId == id).Any();
            if (!result)
            {
                return new List<ProductImage>
                {
                    new ProductImage {ProductId=id, ImagePath=path, Date =DateTime.Now}
                };
            }
            return _productImageDal.GetAll(p => p.ProductId == id);
        }
    }
}
