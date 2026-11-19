using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using ServicesWebApp.Controllers;
using ServicesWebApp.Entities.PortalWebApp;
using ServicesWebApp.Interfaces.PortalWebApp;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;

namespace ServicesWebApp.Models
{
    public class Jwt
    {      
        public static async Task<dynamic> validarTokenAsync(ClaimsIdentity identity)
        {
            try 
            {
                if(identity.Claims.Count() == 0)
                {
                    return new
                    {
                        success= false,
                        menssage= "Token invalido"

                    };
                }
                var Application = identity.Claims.FirstOrDefault(x => x.Type == "IdApplication");
                if (Application == null)
                {
                    return new
                    {
                        success = false,
                        menssage = "Token invalido"
                    };
                }
                else if (Application.Value ==((int)Enumerators.Applications.WebServicesInfoPortal).ToString())
                {
                    var id = identity.Claims.FirstOrDefault(x => x.Type == "IdPerson").Value;
                    vtPerson person = new vtPerson();
                    using (PortalRepositoryContext context = new PortalRepositoryContext())
                    {

                        person = context.vtPersons.FirstOrDefault(x => x.IdPerson == (Convert.ToInt32(id)));
                    }
                    return new
                    {
                        success = true,
                        menssage = "Exito",
                        result = person,
                        

                    };
                }
                else
                {
                    return new
                    {
                        success = false,
                        menssage = "No envio token",
                        result = ""
                    };
                }
            }
            catch( Exception ex) 
            {
                return new
                {
                    success = false,
                    menssage="Catch : "+ ex.Message,
                    result=""
                };
            }
        }
    }
}
