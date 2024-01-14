using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController] // Indicates that this controller is an API controller
[Route("api/[controller]")] // Defines the route for this controller as "api/[controller]"
public class BaseApiController : ControllerBase
{

}
