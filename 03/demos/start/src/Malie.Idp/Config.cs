// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace Malie.Idp
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> Ids =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Address(),
                new IdentityResource("roles", "Your role(s)", new List<string>{"role"}),
                new IdentityResource("subscriptionlevel", "Your subscription level", new [] {"subscriptionlevel"}),
                new IdentityResource("country", "The country in which you live", new[] {"country"})
            };

        public static IEnumerable<ApiScope> Apis =>
            new ApiScope[]
            { 
                new ApiScope("imagegalleryapi", "Image Gallery API")
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[] {
                new ApiResource("imagegalleryapi", "Image Gallery API", new [] {"subscriptionlevel"})
                    {
                        Scopes = { "imagegalleryapi"},
                        ApiSecrets = { new Secret("apisecret".Sha256())}
                    }
                };

        public static IEnumerable<Client> Clients =>
            new Client[]
            { 
                new Client
                {
                    AccessTokenType = AccessTokenType.Reference,
                    AllowOfflineAccess = true,
                    IdentityTokenLifetime = 300,
                    AccessTokenLifetime = 120,
                    AuthorizationCodeLifetime = 300,
                    ClientId = "imagegalleryclient",
                    ClientName = "Image Gallery",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    RequireConsent = true,
                    PostLogoutRedirectUris = new List<string>
                    {
                        "https://localhost:44389/signout-callback-oidc"
                    },
                    
                    RedirectUris = new List<string>
                    {
                        "https://localhost:44389/signin-oidc"
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Address,
                        "roles",
                        "imagegalleryapi",
                        "subscriptionlevel",
                        "country"
                    },
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    }
                }
            };
    }
}