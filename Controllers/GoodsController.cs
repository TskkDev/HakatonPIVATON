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
    public class GoodsController : ControllerBase
    {
        private readonly DataContext _context;

        public GoodsController(DataContext context)
        {
            _context = context;
        }
        [HttpPost("/addGood")]
        public async Task<IActionResult> AddGood( GoodRequest goodRequest)
        {
            // если фронт сфидит и не выкупет как передать массив байт сделать тут IFormFile  
            if (goodRequest == null)
                return BadRequest();
            if(goodRequest.Remainder == 0 || goodRequest.Price == 0|| goodRequest.Weigh ==0)
                return BadRequest("Uncorrect values");
            var newGood = new Good()
            {
                Name = goodRequest.Name,
                Description = goodRequest.Description,
                Pic = goodRequest.Pic,
                Price = goodRequest.Price,
                Weigh = goodRequest.Weigh,
            };
            await _context.AddAsync(newGood);
            await _context.SaveChangesAsync();
            var newUserGood = new UsersGoods()
            {
                GoodId = newGood.Id,
                UserId = goodRequest.UserId
            };
            await _context.AddAsync(newUserGood);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpGet("/backGoods")]
        public async Task<IActionResult> BackGoods(long? userId)
        {
            var goods = _context.UsersGoods.Include(x=>x.Good).ToList();
            if(userId == null)
            {
                var goodWithNoSeller = goods.Select(g => new GoodResponse()
                {
                    Id = g.GoodId,
                    Name = g.Good.Name,
                    Description = g.Good.Description,
                    Remainder = g.Remainder,
                    Weigh = g.Good.Weigh,
                    Pic = g.Good.Pic,
                    Price = g.Good.Price
                });
                return Ok(goodWithNoSeller);
            }
            var goodWithSeller = goods.Where(x => x.UserId == userId).Select(g => new GoodResponse()
            {
                Id = g.GoodId,
                Name = g.Good.Name,
                Description = g.Good.Description,
                Remainder = g.Remainder,
                Weigh = g.Good.Weigh,
                Pic = g.Good.Pic,
                Price = g.Good.Price
            });
            return Ok(goodWithSeller);
        }
        [HttpPut("/updateGood/goodId={goodId:long}/userId={userId:long}")]
        public async Task<IActionResult>UpdateGood(long goodId, long userId, GoodRequest goodRequest)
        {
            if (goodId == 0 || userId ==0) return NotFound();
            if (goodRequest == null)
                return BadRequest();
            if (goodRequest.Remainder == 0 || goodRequest.Price == 0 || goodRequest.Weigh == 0)
                return BadRequest("Uncorrect values");
            var userGood = _context.UsersGoods
                .Where(x => x.GoodId == goodId && x.UserId == userId).First();
            if(userGood == null) return NotFound();
            var good = _context.Good.Find(goodId);
            if (good == null) return NotFound();

            //мне впадлу думать как правильно там делается простите
            userGood.UserId = userId;
            userGood.Remainder = goodRequest.Remainder;
            _context.Update(userGood);
            await _context.SaveChangesAsync();
            good.Name = goodRequest.Name;
            good.Price = goodRequest.Price;
            good.Description = goodRequest.Description;
            good.Pic = goodRequest.Pic;
            good.Weigh = goodRequest.Weigh;
            _context.Update(good);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("/deleteGood/goodId={goodId:long}")]
        public async Task<IActionResult> DeleteGood(long goodId)
        {
            if(goodId == 0) return NotFound();
            var good = _context.Good.Find(goodId);
            if(good == null) return NotFound();
            _context.Remove(good);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
