using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookDB;

namespace BookRepository.Interface
{
    public interface IOrderDetailRepository
    {
        List<OrderDetail> GetByOrderId(int orderId);
        bool InsertOrderDetail(List<OrderDetail> shoppingCarts, int orderId);
    }
}
