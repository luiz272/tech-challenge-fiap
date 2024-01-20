namespace Application.ViewModel;

public class CreateProductViewModel
{
    public string Name { get; private set; }
    public Guid CategoryId { get; private set; }
    public double Price { get; private set; }
    public string Description { get; private set; }
    public string ImageUrl { get; private set; }
    public int Estimative { get; private set; }
}