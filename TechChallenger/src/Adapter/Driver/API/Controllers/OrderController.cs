using Application.UseCases;
using Application.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : Controller
    {
        private IOrderUseCase _orderUseCase;
        public OrderController(IOrderUseCase orderUseCase)
        {
            _orderUseCase = orderUseCase;
        }

        [HttpGet]
        public IActionResult Get()
        {

            return Ok(_orderUseCase.GetAllOrder());
        }

        [HttpPost]
        public IActionResult Post(OrderViewModel data)
        {
            return Ok(_orderUseCase.Post(data));
        }
    }
}
