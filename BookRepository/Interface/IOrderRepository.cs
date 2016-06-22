using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookDB;

namespace BookRepository.Interface
{
    public interface IOrderRepository
    {
        Order GetById(int orderId);
        int? InsertOrder(int userId, DateTime nowDateTime);
    }

}
