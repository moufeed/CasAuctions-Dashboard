using IdentityModel;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TamTech.CasAuctions.Dashboard.SDK.Core.Constants;
using TamTech.CasAuctions.Dashboard.SDK.Services.Identity.Models;

namespace TamTech.CasAuctions.Dashboard.Web.StartUP
{
    public static class AuthenticationConfigurations
    {
        public static void AddAuthenticationConfigurations(this IServiceCollection services, IConfiguration Configuration)
        {

          

            string appUrl = Configuration.GetSection(AppSettings.WebApplicationSettings)
                                                           .GetSection(AppSettings.App_Url).Get<string>();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";
            })
            .AddCookie("Cookies")/*, option =>
            {
                option.AccessDeniedPath = "/";
            })*/
            .AddOpenIdConnect("oidc", options =>
            {
                options.SignInScheme = "Cookies";
                options.Authority = appUrl;
                options.RequireHttpsMetadata = false;
                options.ClientId = "WEB";
                options.ClientSecret = "h8yI4DydzI5ZsKCMGTs9hfTdI1vRS3qfTo9Go92q3aM=";
                options.ResponseType = "code id_token";
                options.SaveTokens = true;
                options.GetClaimsFromUserInfoEndpoint = true;
                options.Scope.Add("openid");
                options.Scope.Add("profile");
                options.Scope.Add("offline_access");
                options.Scope.Add("auctions.api");
                options.Scope.Add("auctions.identity.api");
                // options.Scope.Add("auctions.web.app");
                options.ClaimActions.Add(new JsonKeyClaimAction(JwtClaimTypes.Role, JwtClaimTypes.Role, JwtClaimTypes.Role));
                options.ClaimActions.Add(new JsonKeyClaimAction("imageurl", "imageurl", "imageurl"));
            });



            /*
              
            
            #region Identity Server Configuration
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = identityServiceSettings.DefaultScheme;
                options.DefaultChallengeScheme = identityServiceSettings.DefaultChallengeScheme;
            })
            .AddCookie(identityServiceSettings.CookieAuthenticationScheme)
            .AddOpenIdConnect(identityServiceSettings.OpenIdConnectAuthenticationScheme, options =>
            {
                options.SignInScheme = identityServiceSettings.SignInScheme;
                options.Authority = identityServiceSettings.Url;
                options.RequireHttpsMetadata = identityServiceSettings.RequireHttpsMetadata;
                options.ClientId = identityServiceSettings.ClientId;
                options.ClientSecret = identityServiceSettings.ClientSecrets;
                options.ResponseType = identityServiceSettings.ResponseType;
                options.SaveTokens = identityServiceSettings.SaveTokens;
                options.GetClaimsFromUserInfoEndpoint = identityServiceSettings.GetClaimsFromUserInfoEndpoint;
                foreach (string scop in identityServiceSettings.Scops)
                {
                    options.Scope.Add(scop);
                }
                //options.Events = new Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectEvents ()
                //{
                //    OnTokenValidated = tokenValidatedContext =>
                //    {
                //        return Task.FromResult(0);
                //    }
                //}
            });

              
  "IdentityService": {
    "Url": "http://localhost:50383",
    "ApiName": "whatcook.adminpanel",
    "RequireHttpsMetadata": false,
    "SignInScheme": "Cookies",
    "DefaultScheme": "Cookies",
    "CookieAuthenticationScheme": "Cookies",
    "OpenIdConnectAuthenticationScheme": "oidc",
    "DefaultChallengeScheme": "oidc",
    "ClientId": "whatcookapp",
    "ClientSecrets": "h8yI4DydzI5ZsKCMGTs9hfTdI1vRS3qfTo9Go92q3aM=",
    "ResponseType": "code id_token",
    "SaveTokens": true,
    "GetClaimsFromUserInfoEndpoint": true,
    "Scops": [
      "openid",
      "profile",
      "offline_access",
      "whatcook.api",
      "whatcook.realtime",
      "identity.api",
      "whatcook.upload",
      "whatcook.adminpanel",
      "content.api"
    ],
    "Policies": [
      {
        "Key": "UsersManager",
        "Value": "WhatcookSuperAdmin"
      },
      {
        "Key": "CreateBasicPage",
        "Value": "WhatcookUser"
      },
      {
        "Key": "CreateProduct",
        "Value": "WhatcookUser"
      },
      {
        "Key": "GetFavoriteItems",
        "Value": "WhatcookUser"
      },
      {
        "Key": "ContentManagement",
        "Value": "WhatcookUser,WhatcookSuperAdmin,WhatcookPromoter"
      }
    ]
  },
            #endregion



             "Clients": [
      {
        "ClientId": "whatcookapp",
        "ClientName": "whatcookapp",
        "AllowedGrantTypes": [
          "hybrid",
          "client_credentials"
        ],
        "ClientSecrets": [
          "h8yI4DydzI5ZsKCMGTs9hfTdI1vRS3qfTo9Go92q3aM="
        ],
        "RedirectUris": [
          "{0}/signin-oidc"
        ],
        "PostLogoutRedirectUris": [
          "{0}/signout-callback-oidc"
        ],
        "AllowedCorsOrigins": [
          "http://whatcookapp"
        ],
        "RequirePkce": false,
        "RequireConsent": false,
        "AllowPlainTextPkce": true,
        "AllowedScopes": [
          "openid",
          "profile",
          "offline_Access",
          "whatcook.api",
          "whatcook.realtime",
          "identity.api",
          "whatcook.upload",
          "whatcook.adminpanel",
          "content.api"
        ],
        "AllowOfflineAccess": true,
        "AllowAccessTokensViaBrowser": true,
        "AccessTokenLifetime": 2592000, // 30 days
        "IdentityTokenLifetime": 2592000, // 30 days
        "RefreshTokenExpiration": "Sliding",
        "SlidingRefreshTokenLifetime": 2592000 // 30 days

      },
      {
        "ClientId": "webadminpanel",
        "ClientName": "webadminpanel",
        "AllowedGrantTypes": [
          "hybrid",
          "client_credentials"
        ],
        "ClientSecrets": [
          "h8yI4DydzI5ZsKCMGTs9hfTdI1vRS3qfTo9Go92q3aM="
        ],
        "RedirectUris": [
          "{0}/signin-oidc"
        ],
        "PostLogoutRedirectUris": [
          "{0}/signout-callback-oidc"
        ],
        "AllowedCorsOrigins": [
          "https://adminpanel"
        ],
        "RequirePkce": false,
        "RequireConsent": false,
        "AllowPlainTextPkce": true,
        "AllowedScopes": [
          "openid",
          "profile",
          "offline_Access",
          "whatcook.api",
          "whatcook.realtime",
          "identity.api",
          "whatcook.upload",
          "whatcook.adminpanel",
          "content.api"
        ],
        "AllowOfflineAccess": true,
        "AllowAccessTokensViaBrowser": true,
        "AccessTokenLifetime": 2592000, // 30 days
        "IdentityTokenLifetime": 2592000, // 30 days
        "RefreshTokenExpiration": "Sliding",
        "SlidingRefreshTokenLifetime": 2592000 // 30 days

      }
    ]
             * */

        }

    }
}
