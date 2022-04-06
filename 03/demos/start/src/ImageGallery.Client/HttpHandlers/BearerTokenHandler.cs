using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ImageGallery.Client.HttpHandlers
{
    public class BearerTokenHandler : DelegatingHandler
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IHttpClientFactory _httpClientFactory;

        public BearerTokenHandler(IHttpContextAccessor httpContextAccessor, IHttpClientFactory httpClientFactory)
        {
            _contextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory; 
        }

        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = await GetAccessTokenAsync();
            if(!string.IsNullOrWhiteSpace(token))
            {
                request.SetBearerToken(token);
            }

            return await base.SendAsync(request, cancellationToken);
        }

        private async Task<string> GetAccessTokenAsync()
        {
            var token = await _contextAccessor.HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
            if(string.IsNullOrWhiteSpace(token))
            {
                return token;
            }

            var expiresAt = await _contextAccessor.HttpContext.GetTokenAsync("expires_at");
            var expiresAtOffset = DateTimeOffset.Parse(expiresAt, CultureInfo.InvariantCulture);
            if(expiresAtOffset.AddSeconds(-60).ToUniversalTime() > DateTime.UtcNow)
            {
                return token;
            }

            var idpClient = _httpClientFactory.CreateClient("IDPClient");
            var discoveryDoc = await idpClient.GetDiscoveryDocumentAsync();

            var refreshToken = await _contextAccessor.HttpContext.GetTokenAsync("refresh_token");
            var refreshTokenResponse = await idpClient.RequestRefreshTokenAsync(new RefreshTokenRequest
            {
                Address = discoveryDoc.TokenEndpoint,
                ClientId = "imagegalleryclient",
                ClientSecret = "secret",
                RefreshToken = refreshToken
            });

            token = refreshTokenResponse.AccessToken;

            // Save the tokens
            var newTokens = new List<AuthenticationToken>();
            newTokens.AddRange(new [] 
            { 
                new AuthenticationToken
                {
                    Name = "id_token",
                    Value = refreshTokenResponse.IdentityToken
                },
                new AuthenticationToken
                {
                    Name = "access_token",
                    Value = refreshTokenResponse.AccessToken
                },
                new AuthenticationToken
                {
                    Name = "refresh_token",
                    Value = refreshTokenResponse.RefreshToken
                },
                new AuthenticationToken
                {
                    Name = "expires_at",
                    Value = (DateTime.UtcNow + TimeSpan.FromSeconds(refreshTokenResponse.ExpiresIn))
                                    .ToString("o", CultureInfo.InvariantCulture)
                }
            });

            var currentAuthenticationResult = await _contextAccessor.HttpContext.AuthenticateAsync("Cookies");
            currentAuthenticationResult.Properties.StoreTokens(newTokens);

            await _contextAccessor.HttpContext.SignInAsync("Cookies", 
                currentAuthenticationResult.Principal, 
                currentAuthenticationResult.Properties);

            return token;
        }
    }
}
