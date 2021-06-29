using Core.DataAccess;
using Entities.Dtos;
using Entities.ScaffoldingConcrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IOrderDetailDal : IEntityRepository<OrderDetail>
    {
        List<OrderDetailDto> GetOrderDetails(int id);
    }
}
