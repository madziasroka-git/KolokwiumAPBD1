using KOLOS1.DTOs;
using KOLOS1.Services;
using Microsoft.AspNetCore.Mvc;

namespace KOLOS1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VisitsControllers : ControllerBase
{
    
    private readonly IVisitService _visitService;

    public VisitsControllers(IVisitService visitService)
    {
        _visitService = visitService;
    }
    
     [HttpGet("/{id}")]
        public async Task<IActionResult> GetVisitById(int id)
        {
            if (!await _visitService.DoesVisitExist(id))
                return NotFound($"Visit with given ID - {id} doesn't exist");

            var visit = await _visitService.GetVisitById(id);
            
            return Ok(visit);
        }
     
  

 /*  [HttpPost]
   public async Task<IActionResult> createVisit([FromBody] CreateVisitTPO createVisit)
   {
       var createClient = await _visitService.addVisit(createVisit);
       return Ok(createClient);
   }

*/

    
    
}