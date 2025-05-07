using KOLOS1.Services;
using Microsoft.AspNetCore.Mvc;

namespace KOLOS1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class XXXControllers : ControllerBase
{
    
    private readonly IXXXService _xxxService;

    public XXXControllers(IXXXService xxxxService)
    {
        _xxxService = xxxxService;
    }
    
    
    
}