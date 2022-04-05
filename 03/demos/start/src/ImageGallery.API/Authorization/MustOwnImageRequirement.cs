using Microsoft.AspNetCore.Authorization;

namespace ImageGallery.API.Authorization
{
    public class MustOwnImageRequirement : IAuthorizationRequirement
    {
        // If you wanted some more info here, you can add a ctor and accept that info
    }
}
