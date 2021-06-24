using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OrderDetailService : IOrderDetailService
    {
        IOrderDetailDal _orderDetailDal;

        public OrderDetailService(IOrderDetailDal orderDetailDal)
        {
            _orderDetailDal = orderDetailDal;
        }

        public IDataResult<List<OrderDetail>> GetAll()
        {
            return new SuccessDataResult<List<OrderDetail>>(_orderDetailDal.GetAll());
        }

        public IDataResult<OrderDetail> GetById(int id)
        {
            return new SuccessDataResult<OrderDetail>(_orderDetailDal.Get(od => od.OrderDetailId == id));
        }

        public IDataResult<List<OrderDetailDto>> GetOrderDetails(int id)
        {
            return new SuccessDataResult<List<OrderDetailDto>>(_orderDetailDal.GetOrderDetails(id));
        }
    }
}
