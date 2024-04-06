using HakatonPIVATON.Entity.Date;
using Microsoft.AspNetCore.Identity;

namespace HakatonPIVATON.Services.Identity
{
    public interface ITokenService
    {
        string CreateToken(User user, List<IdentityRole<long>> role);
    }
}
