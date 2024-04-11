using HakatonPIVATON.Entity;
using HakatonPIVATON.Entity.Date;
using HakatonPIVATON.Models.RequestModel;
using HakatonPIVATON.Models.RespnseModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HakatonPIVATON.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PointsAndRoutesController : ControllerBase
    {
        private readonly DataContext _context;
        public PointsAndRoutesController(DataContext context)
        {
            _context = context;
        }
        [HttpPost("/addPoint")]
        public async Task<IActionResult> AddPoint(PointsRequest point)
        {
            if (point == null) return BadRequest();
            var localiti = await _context.Locality.FirstOrDefaultAsync(x => x.Name == point.LocalityName);
            if (localiti == null)
            {
                await _context.Locality.AddAsync(new Entity.Date.Locality()
                {
                    Name = point.LocalityName
                });
                await _context.SaveChangesAsync();
            }
            var newPoint = new Point
            {
                IsSortCenter = point.IsSortCenter,
                UserId = point.UserId,
                LocalityId = localiti.Id
            };
            await _context.Point.AddAsync(newPoint);
            await _context.SaveChangesAsync();

            var pointResponse = new PointsResponse
            {
                Id = newPoint.Id,
                IsSortCenter = point.IsSortCenter,
                LocalityName = point.LocalityName,
                LocalityId = newPoint.LocalityId,
                UserId = newPoint.UserId,
            };
            return Ok(pointResponse); 
        }
        [HttpGet("/backPoints")]
        public async Task<IActionResult> BackPoints(long? userId)
        {
            var points = _context.Point.Include(x => x.Locality)
                .Include(x => x.User)
                .ToList();
            if (userId is null)
            {
                points = points.Where(x => x.UserId == userId).ToList();
            }
            var pointsResponse = points.Select(p => new PointsResponse
            {
                Id = p.Id,
                IsSortCenter = p.IsSortCenter,
                LocalityId = p.LocalityId,
                LocalityName = p.Locality.Name,
                UserId = p.UserId,
            });
            return Ok(pointsResponse);
        }
        [HttpPut("/updatePoints/pointId={pointId:long}")]
        public async Task<IActionResult> UpdatePoint(long pointId, PointsRequest pointRequest)
        {
            if (pointId == 0) return BadRequest();
            var point = await _context.Point.FindAsync(pointId);
            if (point is null) return NotFound();

            var locality = await _context.Locality.FirstOrDefaultAsync(x => x.Name == pointRequest.LocalityName);
            if(locality is null)
            {
                await _context.Locality.AddAsync(new Entity.Date.Locality()
                {
                    Name = pointRequest.LocalityName
                });
                await _context.SaveChangesAsync();
            }

            point.LocalityId = locality.Id;
            point.IsSortCenter = pointRequest.IsSortCenter;
            point.UserId = pointRequest.UserId;

            _context.Update(point);
            await _context.SaveChangesAsync();

            var pointResponse = new PointsResponse()
            {
                Id = pointId,
                IsSortCenter = point.IsSortCenter,
                LocalityId = locality.Id,
                LocalityName = locality.Name,
                UserId = point.UserId
            };
            return Ok(pointResponse);
        }
        [HttpDelete("/deletePoint/pointId={pointId:long}")]
        public async Task<IActionResult> DeletePoint(long pointId)
        {
            if(pointId < 0) return BadRequest();
            var point = await _context.Point.FirstOrDefaultAsync(x=>x.Id ==pointId);
            if (point is null) return NotFound();
            _context.Point.Remove(point);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPost("/addRoute")]
        public async Task<IActionResult> AddRoute(RoutesRequest routesRequest)
        {
            if(routesRequest == null) return BadRequest();
            var firstPoint = await _context.Point.FirstOrDefaultAsync(x => x.Id == routesRequest.FirstPointId);
            var secondPoint = await _context.Point.FirstOrDefaultAsync(x => x.Id == routesRequest.SecondPointId);
            if(firstPoint is null || secondPoint is null) return NotFound();
            if(routesRequest.Distance == 0 || routesRequest.Price==0) return BadRequest();
            var newRoute = new Entity.Date.Route
            {
                FirstPointId = firstPoint.Id,
                SecondPointId = secondPoint.Id,
                Distance = routesRequest.Distance,
                Price = routesRequest.Price
            };
            await _context.Route.AddAsync(newRoute);
            await _context.SaveChangesAsync();

            var routeResponse = new RoutesResponse
            {
                Id = newRoute.Id,
                FirstPointId = newRoute.FirstPointId,
                SecondPointId = newRoute.SecondPointId,
                Distance= newRoute.Distance,
                Price = newRoute.Price
            };
            return Ok(routeResponse);
        }
        [HttpDelete("/deleteRoute/routeId={routeId:long}")]
        public async Task<IActionResult> DeleteRoute(long routeId)
        {
            if(routeId <= 0) return BadRequest();
            var route = await _context.Route.FirstOrDefaultAsync(x=>x.Id == routeId);
            if(route == null) return NotFound();

            _context.Remove(route);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
