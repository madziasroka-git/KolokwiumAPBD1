using KOLOS1.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace KOLOS1.Services;

public interface IVisitService
{
    
     Task<bool> DoesVisitExist(int id);
     Task<bool> DoesClientExist(int id);
     Task<bool> DoesMechanicExist(int id);
     Task<ReturnVisitTPO> GetVisitById(int id);
    // Task<bool> addVisit([FromBody] CreateVisitTPO createVisit);
}