// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityModel;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Json;
using IdentityServer4;

namespace IdentityServerHost.Quickstart.UI
{
    public class TestUsers
    {
        public static List<TestUser> Users
        {
            get
            {
                return new List<TestUser>
                {
                    new TestUser
                    {
                        SubjectId = "b7539694-97e7-4dfe-84da-b4256e1ff5c7",
                        Username = "alisa",
                        Password = "Ali$@",
                        Claims =
                        {
                            new Claim(JwtClaimTypes.GivenName, "Alisa"),
                            new Claim(JwtClaimTypes.FamilyName, "Pussah"),
                            new Claim(JwtClaimTypes.Address, "2220 S 66th Street, Norwood, Essignton EX 11001"),
                            new Claim("role", "FreeUser"),
                            new Claim("subscriptionlevel", "FreeUser"),
                            new Claim("country", "us")
                        }
                    },
                    new TestUser
                    {
                        SubjectId = "d860efca-22d9-47fd-8249-791ba61b07c7",
                        Username = "kadija",
                        Password = "K@dij@",
                        Claims =
                        {
                            new Claim(JwtClaimTypes.GivenName, "Kadija"),
                            new Claim(JwtClaimTypes.FamilyName, "Pussah"),
                            new Claim(JwtClaimTypes.Address, "2222 S 66th Street, Norwood, Essignton EX 11001"),
                            new Claim("role", "PayingUser"),
                            new Claim("subscriptionlevel", "PayingUser"),
                            new Claim("country", "be")
                        }
                    }
                };
            }
        }
    }
}