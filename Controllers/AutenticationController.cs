using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ServicesWebApp.Models;
using ServicesWebApp.Entities.PortalWebApp;
using Newtonsoft.Json;
using System;
using AutoMapper;
using ServicesWebApp.Interfaces.PortalWebApp;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.EntityFrameworkCore;


namespace ServicesWebApp.Controllers
{


    [Route("apiQMAX/[controller]")]
    [ApiController]
    public class AutenticationController : ControllerBase
    {
        private readonly string secretKey;
        private readonly IPortalRepositoryWrapper _repository;
        private readonly IMapper _mapper;
        public AutenticationController(IConfiguration config, IPortalRepositoryWrapper repository, IMapper mapper)
        {
            secretKey = config.GetSection("AppSettings").GetSection("SecretKey").ToString();
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Ingrese el usuario y la contraseña correctos para generar un token de autenticazion.
        /// </summary>
        /// <returns>Jwt Token .</returns>
        // Post: api/Autentication/Validar

        [HttpPost]
        [Route("Validar")]
        public async Task<IActionResult> Validar([FromBody] Object optData)
        {
            var data = JsonConvert.DeserializeObject<dynamic>(optData.ToString());
            string email = data.Email.ToString();
            string idUserAzure = data.IdUserAzure.ToString();
            Person person = await _repository.Person.FindByCondition(x => x.Email.Equals(email) && x.IdUserAzure.Equals(idUserAzure)).SingleOrDefaultAsync();

            if (person.Email == "soporte@qmaxmexico.com" && person.IdUserAzure == "6718b8ce-ccd1-4c17-aa63-7a6766e0a254")
            {
                var keyBytes = Encoding.ASCII.GetBytes(secretKey);
                var claims = new ClaimsIdentity();
                claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, person.Name));                               
                claims.AddClaim(new Claim("IdPerson", person.IdPerson.ToString()));
                claims.AddClaim(new Claim("IdToken",1.ToString()));
                claims.AddClaim(new Claim("IdApplication",((int)Enumerators.Applications.WebServicesInfoPortal).ToString()));
                claims.AddClaim(new Claim("Status", 1.ToString()));

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddYears(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);
                string tokencreado = tokenHandler.WriteToken(tokenConfig);
                return StatusCode(StatusCodes.Status200OK, new { token = tokencreado });
            }
            else
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new { token = "" });
            }
        }
    }
}
