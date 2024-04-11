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
    public class OrderController : ControllerBase
    {
        private readonly DataContext _context;
        public OrderController(DataContext context)
        {
            _context = context;
        }
        [HttpPost("/addOrder")]
        public async Task<IActionResult> AddOrder(OrderRequest orderRequest)
        {
            if(orderRequest == null) return BadRequest();
            if(orderRequest.Goods.Count == 0 ) return BadRequest();
            List<Good> goods = new List<Good>();
            foreach(var item in orderRequest.Goods)
            {
                if (item.GoodId <= 0 || item.Count <= 0 ) return NotFound();
                var good = await _context.Good.FirstOrDefaultAsync(x => x.Id == item.GoodId);
                if(good == null) return NotFound();
                goods.Add(good);
            }
            var startPoint = await _context.Point.FirstOrDefaultAsync(x => x.Id == orderRequest.StartPointId);
            var endPoint = await _context.Point.FirstOrDefaultAsync(x => x.Id == orderRequest.EndPointId);
            if (startPoint == null || endPoint == null) return NotFound();
            var order = new Order
            {
                IsSale = orderRequest.IsSale,
                DeliveryRate = orderRequest.DeliveryRate,
                Description = orderRequest.Description,
                StartDate = DateTime.UtcNow,// если надо будет фронту передавать самому дату то будет грустно
                StartPointID = startPoint.Id,
                UserId = orderRequest.UserId,
                EndPointID = endPoint.Id,
            };
            await _context.Order.AddAsync(order);
            await _context.SaveChangesAsync();

            var orderGoods = orderRequest.Goods.Select(x => new OdersGoods
            {
                GoodId = x.GoodId,
                OrderId = order.Id,
                CountGoods = x.Count
            });
            await _context.OdersGoods.AddRangeAsync(orderGoods);

            var firstStatus = new HistoryStatuses
            {
                OrderId = order.Id,
                PointId = order.StartPointID,
                StatusId = 1,
                SubStatus = "Заказ создан"
            };
            await _context.HistoryStatuses.AddAsync(firstStatus);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpGet("/backOrders/userId={userId:long}")]
        public async Task<IActionResult> BackOrders(long userId)
        {
            if (userId <= 0) return BadRequest();
            if(await _context.User.FirstOrDefaultAsync(x=>x.Id==userId) == null) return NotFound();
            var orders = _context.Order.Include(x => x.StartPoint)
                .Include(x => x.EndPoint)
                .Include(x => x.HistoryStatuses)
                .ThenInclude(x=>x.Status)
                .Where(x => x.UserId == userId);
            var orderResponse = orders.Select(o => new OrderResponse()
            {
                Id = o.Id,
                IsSale = o.IsSale,
                LastStatus = o.HistoryStatuses.Last().Status.Name,
                DeliveryRate = o.DeliveryRate,
            });
            return Ok(orderResponse);
        }
        [HttpGet("/backOrder/orderId={orderId:long}")]
        public async Task<IActionResult> BackOrder(long orderId)
        {
            if (orderId <= 0) return BadRequest();
            var order = await _context.Order.Include(x => x.StartPoint)
                .ThenInclude(x => x.Locality)
                .Include(x => x.EndPoint)
                .ThenInclude(x => x.Locality)
                .Include(x=>x.OdersGoods)
                .ThenInclude(x=>x.Good)
                .Include(x => x.HistoryStatuses)
                .ThenInclude(x => x.Point)
                .ThenInclude(x=>x.Locality)
                .FirstOrDefaultAsync(x=>x.Id == orderId);
            if(order == null) return NotFound();
            var orderResponse = new OrderResponse
            {
                Id = orderId,
                DeliveryRate = order.DeliveryRate,
                Description = order.Description,
                StartDate = order.StartDate,
                EndDate = order.EndDate,
                IsSale = order.IsSale,
                EndPoint = new PointsResponse
                {
                    IsSortCenter = order.EndPoint.IsSortCenter,
                    Id = order.EndPoint.Id,
                    LocalityName = order.EndPoint.Locality.Name,
                },
                StartPoint = new PointsResponse
                {
                    IsSortCenter = order.StartPoint.IsSortCenter,
                    Id = order.StartPoint.Id,
                    LocalityName = order.StartPoint.Locality.Name,
                },
                Goods = order.OdersGoods.Select(og => new GoodResponse
                {
                    Name = og.Good.Name,
                    Price = og.Good.Price,
                    Pic = og.Good.Pic
                }).ToList(),
                HistrotyStatus = order.HistoryStatuses.Select(hs => new HistrotyStatusResponse
                {
                    Id = hs.Id,
                    SubStatus = hs.SubStatus,
                    Points = new PointsResponse()
                    {
                        Id = hs.Point.Id,
                        IsSortCenter = hs.Point.IsSortCenter,
                        LocalityId = hs.Point.Locality.Id,
                        LocalityName = hs.Point.Locality.Name,
                    }
                }).ToList()
            };
            return Ok(orderResponse);
        }
        [HttpPost("/addHistorOfStatus/orderId={orderId:long}")]
        public async Task<IActionResult> addHistorOfStatus(long orderId,HistrotyStatusRequest histrotyStatusRequest)
        {
            if (orderId <= 0) return BadRequest();
            var order = await _context.Order.FirstOrDefaultAsync(x => x.Id == orderId);
            if (order == null) return NotFound();
            var historyStatus = new HistoryStatuses
            {
                OrderId = orderId,
                PointId = histrotyStatusRequest.PointsId,
                StatusId = histrotyStatusRequest.StatusId,
                SubStatus = histrotyStatusRequest.SubStatus,
            };
            await _context.HistoryStatuses.AddAsync(historyStatus);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("/deleteHistorOfStatus/historOfStatusid={historOfStatusId:long}")]
        public async Task<IActionResult> deleteHistorOfStatus(long historOfStatusId)
        {
            if (historOfStatusId <= 0) return BadRequest();
            var hs = await _context.HistoryStatuses.FirstOrDefaultAsync(x => x.Id == historOfStatusId);
            if (hs is null) return NotFound();
            _context.Remove(hs);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
