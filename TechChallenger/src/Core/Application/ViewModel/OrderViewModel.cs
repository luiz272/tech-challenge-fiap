namespace Application.ViewModel
{
    public class OrderViewModel
    {
        public Guid CustomerId { get; set; }

        public double Discount { get; set; }

        public IEnumerable<OrdersProductsViewModel>?  OrdersProducts { get; set; }
        public IEnumerable<OrdersIngredientsViewModel>?  OrdersIngredients { get; set; }
        
    }
}
