using Application.ViewModel;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public interface IOrderUseCase 
    {
        IEnumerable<Order> GetAllOrder();
        object Post(CreateOrderViewModel data);
        bool NextStep(Guid orderId);
    }
}
