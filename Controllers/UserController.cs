using HakatonPIVATON.Data.Entities;
using HakatonPIVATON.Entity;
using HakatonPIVATON.Models.RequestModel;
using HakatonPIVATON.Models.RespnseModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace HakatonPIVATON.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;
        public UserController(DataContext context)
        {
            _context = context;
        }
        [HttpPost("/addUserInfo/userId={userId:long}")]
        public async Task<IActionResult> AddUserInfo(long userId,
            UserInfoRequest userInfo)
        {
            if (userId == 0)
                return BadRequest();
            var user = await _context.User.FirstOrDefaultAsync(x => x.Id == userId);
            if (user == null)
                return NotFound();
            var newUserInfo = new UserInfo
            {
                UserId = userId,
                FIO = userInfo.FIO,
                BirthDate = userInfo.BirthDate,
                INN = userInfo.INN,
            };
            await _context.UserInfo.AddAsync(newUserInfo);
            await _context.SaveChangesAsync();



            var newUserInfoResponse = new UserInfoRequest
            {
                FIO = userInfo.FIO,
                BirthDate = userInfo.BirthDate,
                INN = userInfo.INN,
            };
            return Ok(newUserInfoResponse);
        }
        [HttpGet("/backUserInfo/userId={userId:long}")]
        public async Task<IActionResult> BackUserInfo(long userId)
        {
            if (userId == 0)
                return BadRequest();
            var user = await _context.User.Include(x=>x.UserInfo)
                .Include(x=>x.Orders)
                .Include(x=>x.UsersGoods)
                .ThenInclude(x=>x.Good)
                .FirstOrDefaultAsync(x => x.Id == userId);
            if (user == null) return NotFound();

            var newUser = new UserResponse
            {
                Name = user.Name,
                IsCompany = user.IsCompany,
                UserInfo = user.UserInfo.Select(ui=> new UserInfoResponse
                {
                    FIO = ui.FIO,
                    BirthDate=ui.BirthDate,
                    INN = ui.INN,
                }).ToList(),
                Order = user.Orders.Select(o => new OrderResponse()
                {
                    Id = o.Id,
                    DeliveryRate = o.DeliveryRate,
                    Description = o.Description,
                    IsSale = o.IsSale,
                    StartDate = o.StartDate,
                    EndDate = o.EndDate,
                    StartPointId = o.StartPointID,
                    EndPointId = o.EndPointID,
                }).ToList(),
                Goods = user.UsersGoods.Select(ug => new GoodResponse()
                {
                    Id = ug.Id,
                    Name = ug.Good.Name,
                    Description = ug.Good.Description,
                    Pic = ug.Good.Pic,
                    Price = ug.Good.Price,
                    Remainder = ug.Remainder,
                    Weigh = ug.Good.Weigh
                }).ToList(),
            };
            return Ok(newUser);
        }
        [HttpPut("/updateUserInfo/userId={userId:long}/userInfoId={userInfoId:long}")]
        public async Task<IActionResult> BackUserInfo(long userId, long userInfoId, UserRequest userReq)
        {
            if (userId == 0)
                return BadRequest();
            var user = await _context.Users.Include(x=>x.UserInfo)
                .Include(x=>x.Orders)
                .Include(x=>x.UsersGoods)
                .FirstOrDefaultAsync(x => x.Id == userId);
            if (user == null)
                return NotFound();
            if(userReq== null) return BadRequest();
            if(String.IsNullOrEmpty(userReq.Name) || userReq.Name ==null)
                return BadRequest();
            if(userReq is null)
                return BadRequest();



            user.Name = userReq.Name;
            user.IsCompany = userReq.IsCompany;

            _context.Update(user);

            var userInfo = await _context.UserInfo.FirstOrDefaultAsync(x => x.Id == userInfoId);
            if (userInfo == null)
                return BadRequest();

            userInfo.FIO = userReq.UserInfo.FIO;
            userInfo.BirthDate = userReq.UserInfo.BirthDate;
            userInfo.INN = userReq.UserInfo.INN;
            _context.Update(userInfo);
            await _context.SaveChangesAsync();



            var userInfoResponseList = new List<UserInfoResponse>();
            var userInfoResponse = new UserInfoResponse()
            {
                Id = userInfoId,
                FIO = userInfo.FIO,
                BirthDate = userInfo.BirthDate,
                INN = userInfo.INN,
            };
            userInfoResponseList.Add(userInfoResponse);
            var userResponse = new UserResponse()
            {
                Id = userId,
                IsCompany = userReq.IsCompany,
                Name = userReq.Name,
                UserInfo = userInfoResponseList
            };
            return Ok(userResponse);
        }
    }
}
