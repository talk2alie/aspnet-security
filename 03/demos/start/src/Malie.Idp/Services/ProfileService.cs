using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Malie.Idp.Services
{
    public class ProfileService : IProfileService
    {
        private readonly ILocalUserService localUserService;
        public ProfileService(ILocalUserService localUserService)
        {
            this.localUserService = localUserService;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var subject = context.Subject.GetSubjectId();

            var claims = await localUserService.GetUserClaimsBySubjectAsync(subject);
            context.AddRequestedClaims(claims.Select(c => new Claim(c.Type, c.Value)));
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            var subject = context.Subject.GetSubjectId();
            return localUserService.IsUserActive(subject);
        }
    }
}
