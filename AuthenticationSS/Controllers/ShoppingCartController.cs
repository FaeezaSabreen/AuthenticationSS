using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyClassLibrary;

namespace YourAppName.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ShoppingCartController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ShoppingCartController(AppDbContext context)
        {
            _context = context;
        }

        // Implement action methods here
        [HttpGet]
public IActionResult GetProductsInCart()
{
    // Get the current user's ID (you might need to adjust this based on your authentication setup)
    var userId = User.Identity.Name; // Assuming the username is the user's ID for simplicity

    // Query the database to get the user's shopping cart and products
    var userShoppingCart = _context.ShoppingCarts
        .Include(cart => cart.Products)
        .FirstOrDefault(cart => cart.User == userId);

    if (userShoppingCart == null)
    {
        return NotFound("Shopping cart not found for the current user.");
    }

    return Ok(userShoppingCart.Products);
}

    }
}
