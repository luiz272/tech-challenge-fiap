using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel
{
    public class OrdersIngredientsViewModel
    {
        //public Guid IngredientId { get; private set; }
        //public Guid OrderId { get; private set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
