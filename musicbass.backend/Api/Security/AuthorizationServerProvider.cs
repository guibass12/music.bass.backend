using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using service;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;


namespace api.Security
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private readonly UsuarioService _service;

        public AuthorizationServerProvider()
        {
            _service = new UsuarioService();
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {

            await Task.Run(() =>
            {
                context.Validated();
            });
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            await Task.Run(() =>
           {

               try
               {
                   var user = _service.Autenticar(context.UserName, context.Password);

                   if (user == null)
                   {
                       context.SetError("invalid_grant", "Usuário ou senha incorreto!");
                                              
                       return;
                   }

                   var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                                      
                   identity.AddClaim(new Claim(ClaimTypes.Name, user.Email));
                   identity.AddClaim(new Claim(ClaimTypes.GivenName, user.Nome));

                   GenericPrincipal principal = new GenericPrincipal(identity, null);
                   Thread.CurrentPrincipal = principal;                   
                   var props = new AuthenticationProperties(new Dictionary<string, string>());

                   //Formatters                         
                   var jsonSettings = new HttpConfiguration().Formatters.JsonFormatter.SerializerSettings;
                   jsonSettings.Formatting = Formatting.Indented;
                   jsonSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();


                   //props.Dictionary.Add(new KeyValuePair<string, string>("DadosUsuario", JsonConvert.SerializeObject(Mapper.Map<Usuario, UsuarioViewModel>(user), jsonSettings)));

                   props.Dictionary.Add(new KeyValuePair<string, string>("email", user.Email));
                   props.Dictionary.Add(new KeyValuePair<string, string>("nome", user.Nome));

                   context.Validated(new AuthenticationTicket(identity, props)); 
               }
               catch(Exception)
               {
                   context.SetError("error_grant", "Usuário não existe!");
               }
           });
        }
        
        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }
    }
}