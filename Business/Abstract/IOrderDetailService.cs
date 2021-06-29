using Core.Utilities.Results;
using Entities.Dtos;
using Entities.ScaffoldingConcrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOrderDetailService
    {
        IDataResult<List<OrderDetail>> GetAll();
        IDataResult<OrderDetail> GetById(int id);
        IDataResult<List<OrderDetailDto>> GetOrderDetails(int id);
    }
}
