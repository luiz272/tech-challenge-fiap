using System.ComponentModel.DataAnnotations.Schema;
using Domain.Base;

namespace Domain.Entities;

public class OrdersIngredients : BaseEntity, IAggregateRoot
{
    public OrdersIngredients(Guid ingredientId, Guid orderId, int quantity)
    {
        IngredientId = ingredientId;
        OrderId = orderId;
        Quantity = quantity;
    }

    [ForeignKey("Ingredient")]
    public Guid IngredientId { get; private set; }
    [ForeignKey("Order")]
    public Guid OrderId { get; private set; }
    public int Quantity { get; private set; }
    
    #region Virtual
    public virtual Order Order { get; set; }
    public virtual Ingredient Ingredient { get; set; }
    #endregion
}