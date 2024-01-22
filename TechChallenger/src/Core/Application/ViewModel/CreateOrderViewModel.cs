using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel
{
    public class CreateOrderViewModel
    {
        public Guid CustomerId { get; set; }

        public double Discount { get; set; }

        public IEnumerable<OrdersProductsViewModel>?  OrdersProducts { get; set; }
        public IEnumerable<OrdersIngredientsViewModel>?  OrdersIngredients { get; set; }



    }
}
