using HakatonPIVATON.Entity;
using HakatonPIVATON.Entity.Date;
using HakatonPIVATON.Models;
using HakatonPIVATON.Models.RequestModel;
using HakatonPIVATON.Services.Algorithms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HakatonPIVATON.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculationController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly List<Entity.Date.Route> allRoutes;

        public CalculationController(DataContext context)
        {
            _context = context;
            allRoutes = _context.Route.ToList();
        }
        [HttpGet("backCheapRoute/firstPointId={firstPointId:long}/secondPointId={secondPointId:long}")]
        public async Task<IActionResult> BackCheapRoute(long firstPointId, long secondPointId)
        {
            if (firstPointId <= 0 && secondPointId <= 0) return BadRequest();
            var firstPoint = await _context.Point.FirstOrDefaultAsync(x => x.Id == firstPointId);
            var secondPoint = await _context.Point.FirstOrDefaultAsync(x => x.Id == secondPointId);
            if(firstPoint == null || secondPoint == null) return NotFound();
            var calcRoutes = allRoutes.Select(ar=> new CalcBestRouteModel(){
                FirstPointId = ar.FirstPointId,
                SecondPointId = ar.SecondPointId,
                Weigh = ar.Price
            }).ToList();

            var res = FloydWarshallAlgorithm.BackBestRoute(calcRoutes, firstPointId, secondPointId);
            return Ok(res);
        }
        [HttpGet("backShortRoute/firstPointId={firstPointId:long}/secondPointId={secondPointId:long}")]
        public async Task<IActionResult> BackShortRoute(long firstPointId, long secondPointId)
        {
            if (firstPointId <= 0 && secondPointId <= 0) return BadRequest();
            var firstPoint = await _context.Point.FirstOrDefaultAsync(x => x.Id == firstPointId);
            var secondPoint = await _context.Point.FirstOrDefaultAsync(x => x.Id == secondPointId);
            if (firstPoint == null || secondPoint == null) return NotFound();
            var calcRoutes = allRoutes.Select(ar => new CalcBestRouteModel()
            {
                FirstPointId = ar.FirstPointId,
                SecondPointId = ar.SecondPointId,
                Weigh = ar.Distance
            }).ToList();

            var res = FloydWarshallAlgorithm.BackBestRoute(calcRoutes, firstPointId, secondPointId);
            return Ok(res);
        }
    }
}
